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
    
    public partial class hr_s27_adcpvt_lines
    {
        public string CustID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string CompanyID { get; set; }
        public string Warehouseid { get; set; }
        public long OrderNo { get; set; }
        public long LineNo { get; set; }
        public Nullable<int> LineType { get; set; }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public string SizeID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<long> OrdQty { get; set; }
        public Nullable<long> AllQty { get; set; }
        public Nullable<long> InvQty { get; set; }
        public Nullable<long> DespQty { get; set; }
        public Nullable<double> CommissionRate { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<System.DateTime> Deliverydate { get; set; }
        public Nullable<int> VatCode { get; set; }
        public Nullable<int> NomCode { get; set; }
        public Nullable<sbyte> PartShip { get; set; }
        public Nullable<float> LineNoRef { get; set; }
        public Nullable<double> Currency_Exchange_Rate { get; set; }
        public string StyleIDref { get; set; }
        public string FreeText { get; set; }
        public Nullable<long> RepID { get; set; }
        public Nullable<double> RepRate { get; set; }
        public Nullable<long> KamID { get; set; }
        public Nullable<double> KAMRate { get; set; }
        public Nullable<long> IssueUOM { get; set; }
        public Nullable<double> IssueQty { get; set; }
        public Nullable<long> StockingUOM { get; set; }
        public Nullable<long> OriginalOrderNo { get; set; }
        public Nullable<long> OriginalLineNo { get; set; }
        public string SOPDETAIL1 { get; set; }
        public string SOPDETAIL2 { get; set; }
        public string SOPDETAIL3 { get; set; }
        public string SOPDETAIL4 { get; set; }
        public string SOPDETAIL5 { get; set; }
        public Nullable<int> Jobsheetno { get; set; }
        public Nullable<int> JobsheetLineNo { get; set; }
        public Nullable<int> AssemblyID { get; set; }
        public Nullable<int> AsmLineNo { get; set; }
        public Nullable<int> ReasonCode { get; set; }
        public Nullable<long> ReturnOrderNo { get; set; }
        public Nullable<long> ReturnLineNo { get; set; }
    }
}
