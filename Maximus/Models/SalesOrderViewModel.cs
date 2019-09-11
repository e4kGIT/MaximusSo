using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class SalesOrderViewModel
    {
        public string BusinessId { get; set; }
        public string EmpId { get; set; }
        public List<SalesOrderHeaderViewModel> SalesOrders { get; set; }
    }
}