using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class SalesOrderLineViewModel
    {
        public static string CompanyID { get { return "001"; } }
        public static string Warehouseid { get { return "MAX01"; } }
        public long OrderNo { get { return 10000; } }
        public long LineNo { get; set; }
        public static Nullable<int> LineType { get { return 1; } }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public string SizeID { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Cost { get {return 100; } }
        public  Nullable<long> OrdQty { get; set; }
        public static Nullable<long> AllQty { get { return 0; } }
        public static Nullable<long> InvQty { get { return 0; } }
        public static Nullable<long> DespQty { get { return 0; } }
        public static Nullable<double> CommissionRate { get { return 0; } }
        public static Nullable<double> Discount { get { return 0; } }
        public static Nullable<System.DateTime> Deliverydate { get { return DateTime.Now.Date; } }
        public static Nullable<int> VatCode { get { return 2; } }
        public Nullable<int> NomCode { get { return 3011; } }
        public static Nullable<sbyte> PartShip { get { return null; } }
        public static Nullable<float> LineNoRef { get { return 0; } }
        public Nullable<double> Currency_Exchange_Rate { get { return 1.4; } }
        public static string StyleIDref { get { return ""; } }
        public static string FreeText { get { return ""; } }
        public static Nullable<long> RepID { get { return 0; } }
        public static Nullable<double> RepRate { get { return 0; } }
        public static Nullable<long> KamID { get { return 0; } }
        public static  Nullable<double> KAMRate { get { return 0; } }
        public static Nullable<long> IssueUOM { get { return 1; } }
        public static Nullable<double> IssueQty { get { return 0; } }
        public static Nullable<long> StockingUOM { get { return 1; } }
        public static Nullable<long> OriginalOrderNo { get { return 1; } }
        public  Nullable<long> OriginalLineNo { get; set; }
        public static string SOPDETAIL1 { get { return null; } }
        public static string SOPDETAIL2 { get { return null; } }
        public static string SOPDETAIL3 { get { return null; } }
        public static string SOPDETAIL4 { get { return null; } }
        public static string SOPDETAIL5 { get { return null; } }
        public static Nullable<int> Jobsheetno { get { return null; } }
        public static Nullable<int> JobsheetLineNo { get { return null; } }
        public static Nullable<int> AssemblyID { get { return 0; } }
        public static Nullable<int> AsmLineNo { get { return 0; } }
        public static Nullable<int> ReasonCode { get { return 0; } }
        public static Nullable<long> ReturnOrderNo { get { return null; } }
        public static Nullable<long> ReturnLineNo { get { return null; } }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool? Ischargable { get; set; }
        public bool Assembly { get; set; }
        public string StyleImage { get; set; }

        public string orgStyleId { get; set; }
    }
}