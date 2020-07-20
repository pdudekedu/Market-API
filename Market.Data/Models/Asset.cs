using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Models
{
    /// <summary>
    /// Model class of the asset.
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Asset ID.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the asset.
        /// </summary>
        public string Name { get; set; }
    }
}
