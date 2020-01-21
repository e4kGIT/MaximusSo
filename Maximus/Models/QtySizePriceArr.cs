using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class QtySizePriceArr
    {
        [JsonProperty("Size")]
        public string Size { get; set; }
        [JsonProperty("Price")]
        public double Price { get; set; }
        [JsonProperty("Qty")]
        public int Qty { get; set; }
        [JsonProperty("ReqData")]
        public string ReqData { get; set; }
         
    }
}