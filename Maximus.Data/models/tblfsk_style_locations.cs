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
    
    public partial class tblfsk_style_locations
    {
        public string CompanyId { get; set; }
        public string WarehouseID { get; set; }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public string SizeID { get; set; }
        public string LocationId { get; set; }
        public Nullable<double> SOQty { get; set; }
        public Nullable<double> POQty { get; set; }
        public Nullable<double> StockQty { get; set; }
        public Nullable<double> AllQty { get; set; }
        public Nullable<System.DateTime> Rec_date { get; set; }
        public int Rec_No { get; set; }
        public Nullable<int> Ref_No { get; set; }
        public Nullable<System.DateTime> Ref_Date { get; set; }
        public string Ref_Type { get; set; }
    }
}