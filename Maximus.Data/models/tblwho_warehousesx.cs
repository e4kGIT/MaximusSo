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
    
    public partial class tblwho_warehousesx
    {
        public string CompanyID { get; set; }
        public string WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public bool LocationControled { get; set; }
        public Nullable<int> NoOfAisles { get; set; }
        public Nullable<long> NoOfBays { get; set; }
        public Nullable<int> NoOfShelfs { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public short Live { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string VATno { get; set; }
    }
}
