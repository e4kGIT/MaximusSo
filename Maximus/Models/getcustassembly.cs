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
    
    public partial class getcustassembly
    {
        public string CustID { get; set; }
        public string ParentStyleID { get; set; }
        public string CompanyID { get; set; }
        public int AssemblyID { get; set; }
        public int LineNo { get; set; }
        public Nullable<int> seqno { get; set; }
        public string StyleID { get; set; }
        public string Instruction { get; set; }
        public Nullable<int> Qty { get; set; }
        public sbyte isChargeable { get; set; }
        public sbyte isOptional { get; set; }
        public string Description { get; set; }
        public Nullable<short> OperationMode { get; set; }
        public string Warehouseid { get; set; }
        public sbyte IsZeroPrice { get; set; }
        public sbyte IsExcludeMargin { get; set; }
    }
}
