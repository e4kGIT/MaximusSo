//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maximus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblaccemp_ucodes_dimension
    {
        public string CompanyID { get; set; }
        public string UCodeID { get; set; }
        public string Dimension { get; set; }
        public string ColourID { get; set; }
        public int ReasonCode { get; set; }
        public Nullable<int> PeriodQty { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ReOccur { get; set; }
    }
}
