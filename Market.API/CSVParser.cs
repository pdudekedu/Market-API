using Market.API.Settings;
using Market.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API
{
    /// <summary>
    /// Parser for CSV files.
    /// </summary>
    public class CSVParser : TextFieldParser
    {
        public CSVParser(UpdateDataSettings settings) : base(settings.Path)
        {
            Settings = settings;
            Delimiters = new string[] { settings.Delimiter };
            HasFieldsEnclosedInQuotes = true;
            TrimWhiteSpace = true;

            Headers = ReadHeaders();
            ValidHeaders = Headers.Count == Settings.Columns.Headers.Length;
        }
        /// <summary>
        /// Settings for data file.
        /// </summary>
        public UpdateDataSettings Settings { get; }
        /// <summary>
        /// Headers of CSV file.
        /// </summary>
        public IDictionary<string, int> Headers { get; }
        /// <summary>
        /// Indicates if header are valid.
        /// </summary>
        public bool ValidHeaders { get; } = false;
        /// <summary>
        /// Reads the file line, parses and validates fields.
        /// </summary>
        /// <param name="assets">List of assets.</param>
        /// <param name="properties">Dictionary of properties.</param>
        /// <param name="propertyValue">Parsed property value.</param>
        /// <param name="error">Validation error.</param>
        /// <returns>True - if line has been read correctly.</returns>
        public bool ReadPropertyValue(IEnumerable<int> assets, IDictionary<string, int> properties, out PropertyValue propertyValue, out string error)
        {
            propertyValue = null;
            if (!ValidHeaders)
            {
                error = "Invalid headers.";
                return false;
            }

            string[] fields;
            try
            {
                fields = ReadFields();
            }
            catch (MalformedLineException exc)
            {
                error = exc.Message;
                return false;
            }
            if (fields == null)
            {
                error = "No fields read.";
                return false;
            }

            if (fields.Length <= Headers[Settings.Columns.AssetId.Name] 
                || !Settings.Columns.AssetId.TryParse(fields[Headers[Settings.Columns.AssetId.Name]], out int assetId))
            {
                error = $"Unable to parse {Settings.Columns.AssetId.Name} column.";
                return false;
            }
            if (!assets.Contains(assetId))
            {
                error = $"No asset of id {assetId} found.";
                return false;
            }

            if (fields.Length <= Headers[Settings.Columns.Property.Name]
                || !Settings.Columns.Property.TryParse(fields[Headers[Settings.Columns.Property.Name]], out string property))
            {
                error = $"Unable to parse {Settings.Columns.AssetId.Name} column.";
                return false;
            }
            if (!properties.ContainsKey(property))
            {
                error = $"No property of name \"{property}\" found.";
                return false;
            }

            if (fields.Length <= Headers[Settings.Columns.Value.Name]
                || !Settings.Columns.Value.TryParse(fields[Headers[Settings.Columns.Value.Name]], out bool value))
            {
                error = $"Unable to parse {Settings.Columns.Value.Name} column.";
                return false;
            }
            if (fields.Length <= Headers[Settings.Columns.Timestamp.Name]
                || !Settings.Columns.Timestamp.TryParse(fields[Headers[Settings.Columns.Timestamp.Name]], out DateTime timestamp))
            {
                error = $"Unable to parse {Settings.Columns.Timestamp.Name} column.";
                return false;
            }

            propertyValue = new PropertyValue()
            {
                AssetId = assetId,
                PropertyId = properties[property],
                Value = value,
                Timestamp = timestamp
            };
            error = null;
            return true;
        }
        /// <summary>
        /// Reads header line.
        /// </summary>
        /// <returns>Dictionary of header names and indexes.</returns>
        private IDictionary<string, int> ReadHeaders()
        {
            var result = new Dictionary<string, int>();
            if (!EndOfData)
            {
                string[] columns = Settings.Columns.Headers;
                string[] fields;
                try
                {
                    fields = ReadFields();
                }
                catch (MalformedLineException)
                {
                    return result;
                }
                if (fields == null)
                    return result;
                int i = 0;
                foreach (var headerField in fields)
                {
                    if (columns.Contains(headerField) && !result.ContainsKey(headerField))
                        result.Add(headerField, i);
                    ++i;
                }
            }
            return result;
        }
    }
}
