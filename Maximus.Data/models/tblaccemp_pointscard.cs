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
    
    public partial class tblaccemp_pointscard
    {
        public string CompanyID { get; set; }
        public string BusinessID { get; set; }
        public string EmployeeID { get; set; }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public int Year { get; set; }
        public Nullable<int> SOPoints { get; set; }
        public Nullable<int> PickPoints { get; set; }
        public Nullable<int> InvPoints { get; set; }
        public Nullable<System.DateTime> FirstIssueDate { get; set; }
        public Nullable<System.DateTime> StartIssueDate { get; set; }
        public Nullable<System.DateTime> LastIssueDate { get; set; }
    }
}
