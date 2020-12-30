using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
  public  class OrderDeletePopModel
    {
        public string  OrderType { get; set; }
        public int Ordeno { get; set; }
        public string EmployeeId { get; set; }
        [Required]
        public string  Reason { get; set; }
        public bool isEmergency { get; set; }

    }
}
