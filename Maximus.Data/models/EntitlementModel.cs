﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Data.Models
{
    public class EntitlementModel
    {
        public string  EmpId   { get; set; }
        public string  Result { get; set; }
        public int minMandatoryPts { get; set; }
        public int availPts { get; set; }
        public bool isfreestk { get; set; }
        public bool isPrivate { get; set; }
    }
}