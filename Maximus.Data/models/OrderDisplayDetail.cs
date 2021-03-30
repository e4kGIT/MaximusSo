using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class OrderDisplayDetail
    {
        public long OrgOrderNo { get; set; }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public string SizeID { get; set; }
        public string Description { get; set; }
        public long OrdQty { get; set; }
        public int Points { get; set; }
        public long linno { get; set; }
        public string  Reason { get; set; }
        public int ReturnOrderNo { get; set; }
        public int ReOrderNo { get; set; }
    }
}
