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
    
    public partial class tblpayment_gateways
    {
        public int GatewayID { get; set; }
        public string GatewayName { get; set; }
        public string GatewayImg { get; set; }
        public string RedirectURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GateWayURL { get; set; }
        public Nullable<sbyte> IsEncripted { get; set; }
    }
}
