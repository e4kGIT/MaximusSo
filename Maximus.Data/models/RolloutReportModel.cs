using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class RolloutReportModel
    {
        public int OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string EmployeeName { get; set; }
        public string Employeeid { get; set; }
        public string IsActive { get; set; }
        public string OnlineUserId { get; set; }
        public string Access { get; set; }
        public int UsedPoints { get; set; }
        public string RolloutName { get; set; }
        public string Custref { get; set; }
        public string Styleid { get; set; }
        public string Description{ get; set; }
        public string BaseStyle { get; set; }
        public string BaseStyleDesc { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Freetext { get; set; }
        public int TotQty { get; set; }
        public int TotPts { get; set; }
        public double TotValue { get; set; }
        public int OrdPoints { get; set; }
    }
}
