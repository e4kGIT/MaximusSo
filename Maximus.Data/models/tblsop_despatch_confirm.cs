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
    
    public partial class tblsop_despatch_confirm
    {
        public long OrderNo { get; set; }
        public long DeliveryNote { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> AmendDate { get; set; }
        public string OnlineUserID { get; set; }
        public Nullable<int> PrevStatus { get; set; }
        public Nullable<System.DateTime> PrevAmendDate { get; set; }
        public string Reasons { get; set; }
    }
}
