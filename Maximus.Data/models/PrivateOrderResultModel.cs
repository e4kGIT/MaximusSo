using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class PrivateOrderResultModel
    {
        
        public long retnorderno { get; set; }
        public int orderno { get; set; }
        public string orderdate { get; set; }

        public double totalgoods { get; set; }
        public double ordergoods { get; set; }
        public double vat { get; set; }
        public string  deliveryto { get; set; }
        public string  txnid { get; set; }
        public string txnip { get; set; }
        public string  txndate { get; set; }
        public string paymentdate { get; set; }
        public string responsedate { get; set; }
        public string  responsestatus { get; set; }
        public string  gateway { get; set; }
        public string employeeid { get; set; }
        public string employeename { get; set; }
        //public int MyProperty { get; set; }
    }
}
