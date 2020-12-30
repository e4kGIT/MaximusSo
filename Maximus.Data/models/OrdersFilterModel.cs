using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
  public  class OrdersFilterModel
    {
        public int frmOrderno { get; set; }
        public int toOrderNo { get; set; }
        public DateTime? frmOrderdate { get; set; }
        public DateTime? toOrderDate { get; set; }
        public string custRef { get; set; }
        public string ordStatus { get; set; }
        public string users { get; set; }
        public string Empid { get; set; }
        public string Empname { get; set; }
        public string OrderType { get; set; }
    }
}
