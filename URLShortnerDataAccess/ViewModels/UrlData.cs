using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortnerDataAccess.ViewModels
{
    public class UrlData
    {
        public int SHORTEN_URL_ID { get; set; }
        public string SHORTEN_URL_NAME { get; set; }
        public string LONG_URL_NAME { get; set; }
        public int? TOTAL_VISIT_COUNT { get; set; }
    }
}
