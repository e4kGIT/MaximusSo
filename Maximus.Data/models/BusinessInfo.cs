using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class BusinessInfo
    {
        public string Currency_Name { get; set; }
        public double CurrencyExchangeRate { get; set; }
        public int Rep_Id { get; set; }
    }
}