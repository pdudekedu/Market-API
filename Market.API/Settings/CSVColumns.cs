namespace Market.API.Settings
{
    public class CSVColumns
    {
        public CSVInt32Column AssetId { get; } = new CSVInt32Column() { Name = "AssetId" };
        public CSVStringColumn Property { get; } = new CSVStringColumn() { Name = "Properties" };
        public CSVBoolColumn Value { get; } = new CSVBoolColumn() { Name = "Value" };
        public CSVDateTimeColumn Timestamp { get; } = new CSVDateTimeColumn() { Name = "Timestamp" };
        public string[] Headers => new string[] { AssetId.Name, Property.Name, Value.Name, Timestamp.Name };
    }
}
