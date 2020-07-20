using Market.Data;
using Market.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repositories
{
    /// <summary>
    /// Repository implementation for the property.
    /// </summary>
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly DataContext _context;
        public PropertiesRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets all properties in form of dictionary.
        /// </summary>
        /// <returns>Dictionary where Key is name and Value is ID of property.</returns>
        public async Task<IDictionary<string, int>> GetPropertiesForSearching()
        {
            if (_context == null)
                return null;
            return await _context.Properties.ToDictionaryAsync(x => x.Name, x => x.Id);
        }
        /// <summary>
        /// Gets if property of given name exists.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>True - if property exists.</returns>
        public async Task<bool> PropertyExists(string propertyName)
        {
            if (_context == null || propertyName == null)
                return false;
            return await _context.Properties
                .Where(x => x.Name.ToLower() == propertyName.ToLower())
                .AnyAsync();
        }
        /// <summary>
        /// Gets ID of property of given name exists.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>ID of property.</returns>
        public async Task<int?> GetPropertyId(string propertyName)
        {
            if (_context == null || propertyName == null)
                return null;
            return await _context.Properties
                .Where(x => x.Name.ToLower() == propertyName.ToLower())
                .Select(x => (int?)x.Id)
                .FirstOrDefaultAsync();
        }
    }
}
