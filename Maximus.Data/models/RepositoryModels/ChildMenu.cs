using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class ChildMenu : BaseRepository<tblchildmenu_newlayout_newsystem>
    {
        public ChildMenu(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
