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
    
    public partial class tblasm_assemblyheader
    {
        public string CompanyID { get; set; }
        public int AssemblyID { get; set; }
        public string CustID { get; set; }
        public string StyleID { get; set; }
        public sbyte Enabled { get; set; }
        public sbyte CanEdit { get; set; }
        public Nullable<int> LeadTimeBase { get; set; }
        public Nullable<double> LeadTimePer { get; set; }
        public Nullable<int> BaseItemLine { get; set; }
        public sbyte Live { get; set; }
    }
}
