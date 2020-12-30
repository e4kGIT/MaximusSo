using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class TotalModel
    {
        public string vatSpan { get; set; }
        public double ordeTotal { get; set; }
        public double Total { get; set; }
        public double totalVat { get; set; }
        public double carriage { get; set; }
        public double gross { get; set; }
        public bool isreord { get; set; }
        public bool isreturn { get; set; }

    }
}