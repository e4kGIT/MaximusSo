﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class SaveOrderResultSet
    {
        public long OrderNo { get; set; }
        public string EmployeeId { get; set; }
        public string OrderConfirmation { get; set; }

    }
    public class AcceptResultSet
    {
        public List<SaveOrderResultSet> results { get; set; }
        public string type { get; set; }
    }
}