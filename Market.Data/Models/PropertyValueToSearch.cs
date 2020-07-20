using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Market.Models
{
    /// <summary>
    /// Model of property value for searching.
    /// </summary>
    public class PropertyValueToSearch
    {
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
    }
}
