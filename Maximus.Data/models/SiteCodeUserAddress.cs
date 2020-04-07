using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class SiteCodeUserAddress
    {
        public List<string> SiteCode { get; set; }
        public tblbus_address UserAddress { get; set; }
    }
}
