﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class SalesOrderLineViewModel
    {
        public int IssueUOM1 { get; set; }
         
        public int IssueQty1 { get; set; }
        public int StockingUOM1 { get; set; }
        public int Ratio1 { get; set; }
        public double RepRate1 { get; set; }
        public double KAMRate1 { get; set; }
        public string ProjectCode { get; set; }
        public string SOPDetail4 { get; set; }
        public long ReasonCodeLine { get; set; }
        public string EntQty { get; set; }
        public string RequireData { get; set; }
        public double VatPercent { get; set; }
        public string DeliveryDate { get; set; }
        public int KAMID { get; set; }
        public int RepId { get; set; }
        public static string CompanyID { get { return "001"; } }
        public static string Warehouseid { get { return "MAX01"; } }
        public long OrderNo { get { return 10000; } }
        public long LineNo { get; set; }
        public static int LineType { get { return 1; } }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public string SizeID { get; set; }
        public string Description { get; set; }
        public   double  Price { get; set; }
        public decimal  Cost { get { return 100; } }
        public double Cost1 { get; set; }
        public long  OrdQty { get; set; }
        public double VAT { get; set; }
        public double Total { get; set; }
        public   long  AllQty { get; set; }
        public   long  InvQty { get; set; }
        public static long  DespQty { get { return 0; } }
        public static double CommissionRate { get { return 0; } }
        public static double Discount { get { return 0; } }
        public static System.DateTime  Deliverydate { get { return DateTime.Now.Date; } }
        public static int VatCode { get { return 2; } }
        public int VatCode1 { get; set; }
        public int NomCode { get { return 3011; } }
        public int NomCode1 { get; set; }
        public static sbyte PartShip { get { return 0; } }
        public static float  LineNoRef { get { return 0; } }
        public double  Currency_Exchange_Rate { get; set; }
        public   string StyleIDref { get; set; }
        public static string FreeText { get { return ""; } }
     
        public string FreeText1 { get; set; }
        public static long  RepID { get { return 0; } }
        public static double  RepRate { get { return 0; } }
        public static long  KamID { get { return 0; } }
        public static double  KAMRate { get { return 0; } }
        public static long  IssueUOM { get { return 1; } }
        public static double  IssueQty { get { return 0; } }
        public static long  StockingUOM { get { return 1; } }
        public   long  OriginalOrderNo { get; set; }
        public Nullable<long> OriginalLineNo { get; set; }
        public static string SOPDETAIL1 { get { return null; } }
        public static string SOPDETAIL2 { get { return null; } }
        public static string SOPDETAIL3 { get { return null; } }
        public static string SOPDETAIL4 { get { return null; } }
        public static string SOPDETAIL5 { get { return null; } }
        public static int Jobsheetno { get { return 0; } }
        public static int JobsheetLineNo { get { return 0; } }
        public   int AssemblyID { get; set; }
        public  int AsmLineNo { get; set; }
        public static int ReasonCode { get { return 0; } }
        public static long ReturnOrderNo { get { return 0; } }
        public static long  ReturnLineNo { get { return 0; } }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool? Ischargable { get; set; }
        public bool Assembly { get; set; }
        public string StyleImage { get; set; }

        public string orgStyleId { get; set; }
    }
}