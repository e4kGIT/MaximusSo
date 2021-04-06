using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Maximus.Data.models
{
  public  class Worldpaysuccess
    {
        public string TransactionID { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string OrderKey { get; set; }
       
    }
}
