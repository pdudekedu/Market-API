using Market.Data;
using Market.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repositories
{
    /// <summary>
    /// Repository implementation for the property value.
    /// </summary>
    public class PropertyValuesRepository : IPropertyValuesRepository
    {
        private readonly DataContext _context;
        public PropertyValuesRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Updates properties values in the DB, if timestamp is newer. Creates instation of DbContext internally.
        /// </summary>
        /// <param name="configuration">Configuration of DbContext.</param>
        /// <param name="propertyValues">Values to update.</param>
        /// <returns>Count of modified rows.</returns>
        public async Task<int> UpdateIfNewer(IConfiguration configuration, IEnumerable<PropertyValue> propertyValuesToSet)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            using var context = new DataContext(optionsBuilder.Options);
            if (propertyValuesToSet == null || !propertyValuesToSet.Any())
                return 0;

            string query = GetPropertiesValuesQuery(propertyValuesToSet);
            if (query == null)
                return 0;
            IEnumerable<PropertyValue> propertyValues = await (from pv in context.PropertiesValues.FromSqlRaw(query)
                                                               select pv).ToListAsync();

            var joined = (from pv in propertyValues
                          join pvs in propertyValuesToSet on new { pv.AssetId, pv.PropertyId } equals new { pvs.AssetId, pvs.PropertyId }
                          where pvs.Timestamp > pv.Timestamp
                          select new { pv, pvs });
            foreach (var propertyValue in joined)
            {
                if (propertyValue.pvs.Timestamp > propertyValue.pv.Timestamp)
                {
                    if (context.Entry(propertyValue.pv).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                        context.Attach(propertyValue.pv);
                    propertyValue.pv.Timestamp = propertyValue.pvs.Timestamp;
                    propertyValue.pv.Value = propertyValue.pvs.Value;
                }
            }
            return await SaveAndProcessConcurencyErrors(context);
        }
        /// <summary>
        /// Updates property value in the DB, if timestamp is newer.
        /// </summary>
        /// <param name="propertyValue">Value to update.</param>
        /// <returns>Count of modified rows.</returns>
        public async Task<int> UpdateIfNewer(PropertyValueToSet propertyValueToSet)
        {
            if (_context == null || propertyValueToSet?.Property == null
                    || propertyValueToSet.Timestamp == null || propertyValueToSet.Value == null)
                return 0;
            var propertyValue = await (from pv in _context.PropertiesValues
                                       join p in _context.Properties on pv.PropertyId equals p.Id
                                       where pv.AssetId == propertyValueToSet.AssetId
                                       && p.Name.ToLower() == propertyValueToSet.Property.ToLower()
                                       && pv.Timestamp < propertyValueToSet.Timestamp
                                       select pv).FirstOrDefaultAsync();

            int result = 0;
            if (propertyValue != null)
            {
                _context.Attach(propertyValue);
                propertyValue.Timestamp = propertyValueToSet.Timestamp.Value;
                propertyValue.Value = propertyValueToSet.Value.Value;
                result = await SaveAndProcessConcurencyErrors(_context);
            }
            return result;
        }
        /// <summary>
        /// Saves changes and resolves concurrency violation.
        /// </summary>
        /// <param name="context">DbContext.</param>
        /// <returns>Count of modified rows.</returns>
        private async Task<int> SaveAndProcessConcurencyErrors(DataContext context)
        {
            int result = 0;
            bool saved = false;
            while (!saved)
            {
                try
                {
                    result = await context.SaveChangesAsync();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException exc)
                {
                    foreach (var entry in exc.Entries)
                    {
                        if (entry.Entity is PropertyValue)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            var valueProperty = proposedValues.Properties.FirstOrDefault(x => x.Name == nameof(PropertyValue.Value));
                            var timestampProperty = proposedValues.Properties.FirstOrDefault(x => x.Name == nameof(PropertyValue.Timestamp));
                            if (valueProperty != null && timestampProperty != null)
                            {
                                bool proposedValue = (bool)proposedValues[valueProperty];
                                DateTime proposedTimestamp = (DateTime)proposedValues[timestampProperty];
                                bool databaseValue = (bool)databaseValues[valueProperty];
                                DateTime databaseTimestamp = (DateTime)databaseValues[timestampProperty];

                                if (proposedTimestamp > databaseTimestamp)
                                {
                                    proposedValues[valueProperty] = proposedValue;
                                    proposedValues[timestampProperty] = proposedTimestamp;
                                }
                                else
                                {
                                    proposedValues[valueProperty] = databaseValue;
                                    proposedValues[timestampProperty] = databaseTimestamp;
                                }
                            }
                            else
                                throw new NotSupportedException();
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                            throw new NotSupportedException();
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Gets query for fetching  property values for given properties and asstets.
        /// </summary>
        /// <param name="propertyValuesToSet">Property values.</param>
        /// <returns>Query.</returns>
        private string GetPropertiesValuesQuery(IEnumerable<PropertyValue> propertyValuesToSet)
        {
            if (_context == null || propertyValuesToSet == null || !propertyValuesToSet.Any())
                return null;

            var entityType = _context.Model.FindEntityType(typeof(PropertyValue));
            var asssetIdColumnName = entityType.FindProperty(nameof(PropertyValue.AssetId)).Name;
            var propertyIdColumnName = entityType.FindProperty(nameof(PropertyValue.PropertyId)).Name;

            List<string> filters = new List<string>();
            foreach (var pvs in propertyValuesToSet)
                filters.Add($"({asssetIdColumnName} = {pvs.AssetId} AND {propertyIdColumnName} = {pvs.PropertyId})");
            return $"SELECT * FROM {entityType.GetSchema()}.{entityType.GetTableName()} WHERE {string.Join(" OR ", filters)}";
        }
    }
}
