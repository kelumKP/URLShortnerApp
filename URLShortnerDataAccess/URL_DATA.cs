//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace URLShortnerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class URL_DATA
    {
        public URL_DATA()
        {
            this.USER_URL_RECORDS = new HashSet<USER_URL_RECORDS>();
        }
    
        public int SHORTEN_URL_ID { get; set; }
        public string SHORTEN_URL_NAME { get; set; }
        public string LONG_URL_NAME { get; set; }
        public Nullable<int> TOTAL_VISIT_COUNT { get; set; }
    
        public virtual ICollection<USER_URL_RECORDS> USER_URL_RECORDS { get; set; }
    }
}