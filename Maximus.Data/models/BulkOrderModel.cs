using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class BulkOrderModel
    {
        public int qty { get; set; }
        public string size { get; set; }
        public string style { get; set; }
        public decimal price { get; set; }
    }
}