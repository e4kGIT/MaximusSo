using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class ImportExportResult
    {
      public  string faillisttbl { get; set; }
      public int failcount { get; set; }
        public int passcount { get; set; }
        public bool result { get; set; }
        public string alertstring { get; set; }
    }
}
