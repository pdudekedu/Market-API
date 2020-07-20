using Market.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Models
{
    /// <summary>
    /// Model class of asset's property.
    /// </summary>
    public class PropertyValue
    {
        /// <summary>
        /// Id of the asset.
        /// </summary>
        public int AssetId { get; set; }
        /// <summary>
        /// Id of the property.
        /// </summary>
        public int PropertyId { get; set; }
        /// <summary>
        /// Asset object.
        /// </summary>
        public Asset Asset { get; set; }
        /// <summary>
        /// Property object.
        /// </summary>
        public Property Property { get; set; }
        /// <summary>
        /// Value of the property.
        /// </summary>
        public bool Value { get; set; } = false;
        /// <summary>
        /// Timestamp of the last update.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.MinValue;
    }
}
