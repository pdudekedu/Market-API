using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Settings
{
    public class CSVInt32Column : CSVColumn<int>
    {
        public override bool TryParse(string s, out int result)
        {
            return int.TryParse(s, out result);
        }
    }
}
