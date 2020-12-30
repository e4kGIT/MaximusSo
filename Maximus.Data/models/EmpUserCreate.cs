using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class EmpUserCreate
    {
        public DateTime? nextOrdDate { get; set; }
        public DateTime? lastOrdDate { get; set; }
        public string rollout { get; set; }
        public string role { get; set; }
        public string Email { get; set; }
    }
}
