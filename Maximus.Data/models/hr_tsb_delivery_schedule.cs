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
    
    public partial class hr_tsb_delivery_schedule
    {
        public int OrderNo { get; set; }
        public Nullable<System.DateTime> Orderdate { get; set; }
        public string BusinessID { get; set; }
        public Nullable<int> SortCode { get; set; }
        public string PostCode { get; set; }
        public Nullable<int> TotQty { get; set; }
        public string UserID { get; set; }
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> PickDate { get; set; }
    }
}