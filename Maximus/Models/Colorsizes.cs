using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maximus.Models
{
    public class Colorsizes
    {
        public string styleid{ get; set; }
        public List<Colors> Colours { get; set; }
        public List<Size> Size { get; set; }
    }
}