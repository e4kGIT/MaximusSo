using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class Structrues
    {
        public struct TStyle
        {
            public string StyleID;
            public string SizeID;
            public string Description;
            public string NominalCode;
            public string VatCode;
            public string VatPercent;
            public string GroupID;
            public bool booSet;
        }
        public struct TVATCODE
        {
            public int VatCode;
            public double VatPercent;
            public bool booSet;
        }

        public struct TKAM
        {
            public int RepID;
            public int KamID;
            public bool booSet;
        }

        
        public struct TStyleReps
        {
            public string StyleID;
            public int RepID;
            public int SeqNo;
            public bool booSet;
        }

    }
    public class TStyle
    {
        public string StyleID { get; set; } 
        public string SizeID { get; set; }
        public string Description { get; set; }
        public string NominalCode { get; set; }
        public string VatCode { get; set; }
        public string VatPercent { get; set; }
        public string GroupID { get; set; }
        public bool booSet { get; set; }
    }
    public class  TBusinessAccount
    {
        public string BusinessID { get; set; }
        public double Credit_Limit{ get; set; }
        public int Cash_Days1{ get; set; }
        public int Cash_Days2{ get; set; }
        public string Currency{ get; set; }
        public int VatCode{ get; set; }
        public string VatFlag{ get; set; }
        public double Balance{ get; set; }
        public int RepID{ get; set; }
        public int Rep_Comission { get; set; }
        public int KAM_Comission { get; set; }
        //s  Rep_Comission As Single
        //  KAM_Comission As Single
        public int PaymentTermsID{ get; set; }
        public int Country_CurrencyID{ get; set; }
        public string CurrencyName{ get; set; }
        public double ExchangeRate{ get; set; }
        public bool booSet{ get; set; }
    }
}