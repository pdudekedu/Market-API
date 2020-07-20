using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Settings
{
    public class UpdateDataSettings
    {
        public string Path { get; set; }
        public string Delimiter { get; set; } = ";";
        public int BatchSize { get; set; } = 10;
        public CSVColumns Columns { get; } = new CSVColumns();
    }
}
