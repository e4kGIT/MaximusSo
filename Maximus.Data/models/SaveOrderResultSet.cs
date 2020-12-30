using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class SaveOrderResultSet
    {
        public long OrderNo { get; set; }
        public string EmployeeId { get; set; }
        public string OrderConfirmation { get; set; }

        public bool IsReturn { get; set; }
        public string OrderConfirmationPop { get; set; }

        public bool isedit   { get; set; }
    }
    public class AcceptResultSet
    {
        public List<SaveOrderResultSet> results { get; set; }
        public bool IsReturn { get; set; }
        public string type { get; set; }
    }
    public class PointsResult
    {
        public List<string> pointsStyle { get; set; }
        public string message { get; set; }
    }
}