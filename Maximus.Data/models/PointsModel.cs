using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class PointsModel
    {
        public string CompanyID { get; set; }
        public string BusinessID { get; set; }
        public string UcodeID { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public   int  TotalPoints { get; set; }
        public  int  UsedPoints { get; set; }
        public int  AvailablePoints { get; set; }
        public string EmployeeID { get; set; }
        public string StyleID { get; set; }
        public string ColourID { get; set; }
        public int Year { get; set; }
        public Nullable<int> SOPoints { get; set; }
        public Nullable<int> PickPoints { get; set; }
        public Nullable<int> InvPoints { get; set; }
        public Nullable<System.DateTime> FirstIssueDate { get; set; }
        public Nullable<System.DateTime> StartIssueDate { get; set; }
        public Nullable<System.DateTime> LastIssueDate { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<int> MandatoryQty { get; set; }
        public Nullable<int> MinPts { get; set; }
        public Nullable<int> MaxPts { get; set; }
        public List<PointsStyle> LstStyles { get; set; }
    }
    public class PointsStyle
    {
        public string Style { get; set; }
        public int Points { get; set; }
    }
}
