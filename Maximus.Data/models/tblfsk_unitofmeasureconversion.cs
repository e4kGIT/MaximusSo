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
    
    public partial class tblfsk_unitofmeasureconversion
    {
        public string CompanyID { get; set; }
        public string StyleID { get; set; }
        public int LargerUnit { get; set; }
        public Nullable<int> SmallerUnit { get; set; }
        public Nullable<int> Ratio { get; set; }
        public Nullable<int> BaseRatio { get; set; }
    }
}