using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class ChildMenuLayout
    {
        public int ParentID { get; set; }
        public string ChildID { get; set; }
        public string Description { get; set; }
        public Nullable<sbyte> IsEnable { get; set; }
        public Nullable<int> SeqNo { get; set; }
        public string URL { get; set; }
        public string TitleDesc { get; set; }
        public Nullable<sbyte> IsPopUp { get; set; }
        public Nullable<sbyte> OnlyNewLayout { get; set; }
    }
}
