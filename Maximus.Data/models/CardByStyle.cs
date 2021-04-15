using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class CardByStyle
    {
        public int orderno { get; set; }
        public string ordertype { get; set; }
        public string orderdate { get; set; }
        public string styleid { get; set; }
        public string  colourid { get; set; }
        public string empid { get; set; }
        public string  sizeid { get; set; }
        public int ordqty { get; set; }
        public string ucode { get; set; }
        public int points { get; set; }
        
    }
}
