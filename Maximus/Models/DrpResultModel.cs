using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class DrpResultModel
    {
        public string Description { get; set; }
        public List<string> ColorList { get; set; }
        public List<string> SizeList { get; set; }
        public decimal Price { get; set; }
    }
}