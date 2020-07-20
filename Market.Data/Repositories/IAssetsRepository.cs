using Market.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repositories
{
    /// <summary>
    /// Repository for the asset.
    /// </summary>
    public interface IAssetsRepository
    {
        /// <summary>
        /// Gets all assets IDs.
        /// </summary>
        /// <returns>Collection of assets IDs.</returns>
        Task<IEnumerable<int>> GetAssetsIDs();
        /// <summary>
        /// Gets assets IDs by property value.
        /// </summary>
        /// <param name="propertyValue">Property value to search.</param>
        /// <returns>Collection of assets IDs.</returns>
        Task<IEnumerable<int>> GetAssetsIDs(PropertyValueToSearch propertyValue);
        /// <summary>
        /// Gets if the asset if given ID exists.
        /// </summary>
        /// <param name="id">Asset's ID.</param>
        /// <returns>True - if asset exists.</returns>
        Task<bool> AssetExists(int id);
    }
}
