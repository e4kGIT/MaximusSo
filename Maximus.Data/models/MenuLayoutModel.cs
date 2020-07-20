using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class MenuLayoutModel
    {
        public List<ParentMenuLayout> ParentMenuItms { get; set; }
        public List<ChildMenuLayout> ChildMenuItms { get; set; }
    }
}
