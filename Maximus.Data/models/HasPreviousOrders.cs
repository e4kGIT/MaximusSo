using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class HasPreviousOrders
    {
        public bool PrevOrder { get; set; }
        public string Access { get; set; }

        public bool AddressChanged { get; set; }

        
    }
}
