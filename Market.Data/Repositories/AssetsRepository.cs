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
    /// Repository implementation for the asset.
    /// </summary>
    public class AssetsRepository : IAssetsRepository
    {
        private readonly DataContext _context;
        public AssetsRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets if the asset if given ID exists.
        /// </summary>
        /// <param name="id">Asset's ID.</param>
        /// <returns>True - if asset exists.</returns>
        public async Task<bool> AssetExists(int id)
        {
            if (_context == null)
                return false;
            return await _context.Assets.Where(x => x.Id == id).AnyAsync();
        }
        /// <summary>
        /// Gets all assets IDs.
        /// </summary>
        /// <returns>Collection of assets IDs.</returns>
        public async Task<IEnumerable<int>> GetAssetsIDs()
        {
            if (_context == null)
                return null;
            return await _context.Assets.Select(x => x.Id).ToListAsync();
        }
        /// <summary>
        /// Gets assets IDs by property value.
        /// </summary>
        /// <param name="propertyValue">Property value to search.</param>
        /// <returns>Collection of assets IDs.</returns>
        public async Task<IEnumerable<int>> GetAssetsIDs(PropertyValueToSearch propertyValue)
        {
            if (_context == null || propertyValue == null || propertyValue.Property == null)
                return null;
            return await (from pv in _context.PropertiesValues
                          join a in _context.Assets on pv.AssetId equals a.Id
                          join p in _context.Properties on pv.PropertyId equals p.Id
                          where p.Name.ToLower() == propertyValue.Property.ToLower() && pv.Value == propertyValue.Value
                          select a.Id).Distinct().ToListAsync();
        }
    }
}
