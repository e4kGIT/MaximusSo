//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maximus.Data.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblsap_log
    {
        public long LogID { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public string userid { get; set; }
        public string postData { get; set; }
        public string responseData { get; set; }
        public string logstatus { get; set; }
    }
}