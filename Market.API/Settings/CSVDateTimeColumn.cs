using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Settings
{
    public class CSVDateTimeColumn : CSVColumn<DateTime>
    {
        public string Format { get; set; } = "yyyy-MM-ddTHH:mm:ss";
        public override bool TryParse(string s, out DateTime value)
        {
            return DateTime.TryParseExact(s, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
        }
    }
}
