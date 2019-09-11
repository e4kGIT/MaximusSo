using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class EmployeeLoginModel
    { 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public string Active { get; set; }
        public string AccessID { get; set; }
        public string BusinessID { get; set; }
        public string Email_ID { get; set; }
    }
}