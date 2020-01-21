using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class FilterModel
    {
        public string ColorId { get; set; }
        public string StyleID { get; set; }
        public string SizeId { get; set; }
        public List<string> StyleIDList { get; set; }
        public List<string> ColorIdList { get; set; }
        public List<string> SizeIdList { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }

    }
}