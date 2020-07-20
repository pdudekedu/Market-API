using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Market.Models
{
    /// <summary>
    /// Model of the property's value to set.
    /// </summary>
    public class PropertyValueToSet
    {
        /// <summary>
        /// Id of the asset.
        /// </summary>
        [Required]
        public int? AssetId { get; set; }
        /// <summary>
        /// Name of the property.
        /// </summary>
        [Required]
        public string Property { get; set; }
        /// <summary>
        /// Value of the property.
        /// </summary>
        [Required]
        public bool? Value { get; set; } = null;
        /// <summary>
        /// Timestamp of the property's value.
        /// </summary>
        [Required]
        public DateTime? Timestamp { get; set; } = null;
    }
}
