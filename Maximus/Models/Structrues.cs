using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
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

        public struct TBusinessAccount
        {
            public string BusinessID;
            public double Credit_Limit;
            public int Cash_Days1;
            public int Cash_Days2;
            public string Currency;
            public int VatCode;
            public string VatFlag;
            public double Balance;
            public int RepID;
            public Single Rep_Comission;
            public Single KAM_Comission;
            //s  Rep_Comission As Single
            //  KAM_Comission As Single
            public int PaymentTermsID;
            public int Country_CurrencyID;
            public string CurrencyName;
            public double ExchangeRate;
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
}