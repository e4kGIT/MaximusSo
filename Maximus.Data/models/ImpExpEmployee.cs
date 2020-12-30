using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class ImpExpEmployee
    {
        public string EmployeeId { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string SurName { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Ucode { get; set; }
        public string MapTo { get; set; }
    }
}
