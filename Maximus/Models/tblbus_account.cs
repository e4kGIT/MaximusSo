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
    
    public partial class tblbus_account
    {
        public string CompanyID { get; set; }
        public string BusinessID { get; set; }
        public string Bank_Name { get; set; }
        public Nullable<int> Bank_Address_ID { get; set; }
        public string Bank_Account_Name { get; set; }
        public string Bank_Sort_Code { get; set; }
        public string Bank_Account_Num { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<double> Credit_Limit { get; set; }
        public Nullable<int> Cash_Days1 { get; set; }
        public Nullable<int> Cash_Days2 { get; set; }
        public Nullable<int> Cash_Discount1 { get; set; }
        public Nullable<int> Cash_Discount2 { get; set; }
        public string Currency { get; set; }
        public Nullable<int> VATCode { get; set; }
        public string VATFlag { get; set; }
        public string VATNo { get; set; }
        public string Special_Instructions1 { get; set; }
        public string Special_Instructions2 { get; set; }
        public Nullable<System.DateTime> Date_Used { get; set; }
        public Nullable<System.DateTime> Date_Opened { get; set; }
        public bool Conditions { get; set; }
        public string Nominal_Code { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<decimal> Chase_Amount { get; set; }
        public Nullable<System.DateTime> Chase_Date { get; set; }
        public Nullable<int> RepID { get; set; }
        public Nullable<double> Rep_Comission { get; set; }
        public Nullable<double> KAM_Comission { get; set; }
        public Nullable<short> PaymentTermsID { get; set; }
    }
}
