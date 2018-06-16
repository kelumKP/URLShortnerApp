using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URLShortnerWebApp.Models
{
    public class VisitedUserData
    {
        public string HostMachineName { get; set; }
        public string MachinePrivateIP { get; set; }
        public string MachinePublicIP { get; set; } 
        public string LongURL { get; set; }
        public string ShortenURL { get; set; }
        public string VisitedCountry { get; set; }  
        public string VisitedRegion { get; set; }  
        public string VisitedCity { get; set; }  
        public string ServiceProviderName { get; set; }

    }
}