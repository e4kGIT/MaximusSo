using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class AssemblyModel
    {
        public string StyleID { get; set; } 
       public string Instruction { get; set; }
       public int IsChargeable { get; set; }
        public string StyleImage { get; set; }
        public int SeqNo { get; set; }
    }
}