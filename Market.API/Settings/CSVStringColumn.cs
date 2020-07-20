using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Settings
{
    public class CSVStringColumn : CSVColumn<string>
    {
        public override bool TryParse(string s, out string value)
        {
            value = s;
            return true;
        }
    }
}
