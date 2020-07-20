using Market.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repositories
{
    /// <summary>
    /// Repository for the property.
    /// </summary>
    public interface IPropertiesRepository
    {
        /// <summary>
        /// Gets all properties in form of dictionary.
        /// </summary>
        /// <returns>Dictionary where Key is name and Value is ID of property.</returns>
        Task<IDictionary<string, int>> GetPropertiesForSearching();
        /// <summary>
        /// Gets if property of given name exists.
        /// </summary>
        /// <param name="propertyName">Name of the property to check.</param>
        /// <returns>True - if property exists.</returns>
        Task<bool> PropertyExists(string propertyName);
        /// <summary>
        /// Gets ID of property of given name exists.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>ID of property.</returns>
        Task<int?> GetPropertyId(string propertyName);
    }
}
