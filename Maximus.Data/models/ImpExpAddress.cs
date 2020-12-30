using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
  public  class ImpExpAddress
    {
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string CityCounty { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string ContactName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string CostCenter { get; set; }
        public string MapTo { get; set; }
    }
}
