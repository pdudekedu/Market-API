using Market.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repositories
{
    /// <summary>
    /// Repository for the property value.
    /// </summary>
    public interface IPropertyValuesRepository
    {
        /// <summary>
        /// Updates properties values in the DB, if timestamp is newer. Creates instation of DbContext internally.
        /// </summary>
        /// <param name="configuration">Configuration of DbContext.</param>
        /// <param name="propertyValues">Values to update.</param>
        /// <returns>Count of modified rows.</returns>
        Task<int> UpdateIfNewer(IConfiguration configuration, IEnumerable<PropertyValue> propertyValues);
        /// <summary>
        /// Updates property value in the DB, if timestamp is newer.
        /// </summary>
        /// <param name="propertyValue">Value to update.</param>
        /// <returns>Count of modified rows.</returns>
        Task<int> UpdateIfNewer(PropertyValueToSet propertyValue);
    }
}
