using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortnerDataAccess.ViewModels
{
    public class UserData
    {
        public int USER_ID { get; set; }
        public string USER_MACHINE_NAME { get; set; }
        public string USER_PRIVATE_IP_ADDRESS { get; set; }
        public string USER_PUBLIC_IP_ADDRESS { get; set; }
        public string USER_LOCATION_COUNTRY { get; set; }
        public string USER_LOCATION_REGION { get; set; }
        public string USER_LOCATION_CITY { get; set; }
        public string USER_SERVICE_PROVIDER { get; set; }
    }
}
