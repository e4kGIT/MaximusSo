using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class CardReportModel
    {
        public string employeeid { get; set; }
        public string replenishmentdate { get; set; }
        public string styledescription { get; set; }
        public string employeename { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string colour { get; set; }
        public string styleid { get; set; }
        public string firstissuedate { get; set; }
        public string lastissuedate { get; set; }
        public string startissuedate { get; set; }
        public string year { get; set; }
        public int soqty { get; set; }
        public int sopoints { get; set; }
        public int invoiceqty { get; set; }
        public int invoicepoints { get; set; }
        public int pickqty { get; set; }
        public int pickpoints { get; set; }
        public int total  { get; set; }
        public int intyear { get; set; }

        public string  ucodedata { get; set; }

    }
}
