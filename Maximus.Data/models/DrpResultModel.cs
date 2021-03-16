using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class DrpResultModel
    {
        public string Description { get; set; }
        public List<string> ColorList { get; set; }
        public List<string> SizeList { get; set; }
        public List<SizePrice> PriceList { get; set; }
        public decimal Price { get; set; }
        public string PriceVAT { get; set; }
        public bool isManpack { get; set; }
        public bool isBulk { get; set; }
        public bool showVat { get; set; }
        public bool HasReqData { get; set; }
        public string ReqData { get; set; }
    }

    public class SizePrice
    {
        public string Size { get; set; }
        public string Price { get; set; }
        public string PriceVAT { get; set; }
        public bool showVat { get; set; }
        public string Currency { get; set; }
    }
}