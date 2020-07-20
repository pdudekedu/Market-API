using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Market.Data
{
    /// <summary>
    /// Generates data for the database.
    /// </summary>
    internal class DataSeeder
    {
        /// <summary>
        /// Generates given count of assets.
        /// </summary>
        /// <param name="count">Assets count.</param>
        /// <returns>Collection of assets.</returns>
        public IEnumerable<Asset> GetAssets(int count)
        {
            for (int i = 1; i <= count; ++i)
                yield return new Asset()
                {
                    Id = i,
                    Name = $"Asset {i}"
                };
        }
        /// <summary>
        /// Generates pre-defined properties.
        /// </summary>
        /// <returns>Collection of properties.</returns>
        public IEnumerable<Property> GetProperties()
        {
            return new List<Property>()
            {
                new Property() { Id = 1, Name = "is fix income" },
                new Property() { Id = 2, Name = "is convertible" },
                new Property() { Id = 3, Name = "is swap" },
                new Property() { Id = 4, Name = "is cash" },
                new Property() { Id = 5, Name = "is future" }
            };
        }
        /// <summary>
        /// Generates collection of default property values for assets and properties.
        /// </summary>
        /// <param name="assets">Collection of assets.</param>
        /// <param name="properties">Collection of properties.</param>
        /// <returns>Collection of property values.</returns>
        public IEnumerable<PropertyValue> GetPropertyValues(IEnumerable<Asset> assets, IEnumerable<Property> properties)
        {
            return (from a in assets.AsQueryable()
                    from p in properties.AsQueryable()
                    select new PropertyValue()
                    {
                        AssetId = a.Id,
                        PropertyId = p.Id
                    }).ToList();
        }
    }
}
