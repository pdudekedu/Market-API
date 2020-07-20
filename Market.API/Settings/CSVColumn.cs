using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Settings
{
    public abstract class CSVColumn<T>
    {
        public string Name { get; set; }

        public abstract bool TryParse(string s, out T value);
    }
}
