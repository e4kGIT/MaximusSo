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
    
    public partial class tblonlinesop_backorders
    {
        public string CustID { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<short> OrderLine { get; set; }
        public int PickingSlipNo { get; set; }
        public int LineNo { get; set; }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public string SizeID { get; set; }
        public Nullable<System.DateTime> DatePicked { get; set; }
        public Nullable<int> OrdQty { get; set; }
        public Nullable<int> AllQty { get; set; }
        public bool PickSlipPrinted { get; set; }
        public bool DelNotePrinted { get; set; }
        public bool Cancelled { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string FullDate { get; set; }
        public string DelDesc { get; set; }
        public string DelAddress1 { get; set; }
        public string CustRef { get; set; }
        public Nullable<double> Value1 { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string CommentsExternal { get; set; }
    }
}
