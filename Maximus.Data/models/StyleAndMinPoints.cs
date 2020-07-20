using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class StyleAndMinPoints
    {
        public int MinPoints { get; set; }
        public int TruePoints { get; set; }
        public int OrgMinPoints { get; set; }
        public string OrgStyle { get; set; }

        public string Style { get; set; }
        public string CatCaption { get; set; }
        public int Points { get; set; }
    }
    public class pointsChange
    {
        public string type { get; set; }
        public string styl { get; set; }
    }
}
