using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class ImpExpUsers
    {
        public string UserName { get; set; }
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string AccessRole { get; set; }
        public bool Active { get; set; }
        public string MapTo { get; set; }
        public string RolloutName { get; set; }
       
    }
}
