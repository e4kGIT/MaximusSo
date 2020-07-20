using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
    public class ParentMenuLayout
    {
        public int ParentID { get; set; }
        public string Description { get; set; }
        public Nullable<sbyte> IsEnable { get; set; }
        public Nullable<int> SeqNo { get; set; }
        public string URL { get; set; }
        public Nullable<sbyte> IsPermissionReq { get; set; }
        public Nullable<sbyte> OnlyNewLayout { get; set; }
    }
}
