using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class PaymentDetails
    {
        public string firstname { get; set; }
        public string gateway { get; set; }
        public string ordtotal { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string emailid { get; set; }
        public string invaddr1 { get; set; }
        public string invaddr2 { get; set; }
        public string invaddrcity { get; set; }
        public string invaddrtown { get; set; }
        public string deladdr1 { get; set; }
        public string deladdr2 { get; set; }
        public string delcity { get; set; }
        public string deltown { get; set; }
        public string delcountry { get; set; }
        public string invcountry { get; set; }
        public string invpostcode { get; set; }
        public string delpostcode{ get; set; }
        public string paypaltokenid { get; set; }

    }
}
