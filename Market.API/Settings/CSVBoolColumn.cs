using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Settings
{
    public class CSVBoolColumn : CSVColumn<bool>
    {
        public override bool TryParse(string s, out bool value)
        {
            return bool.TryParse(s, out value);
        }
    }
}
