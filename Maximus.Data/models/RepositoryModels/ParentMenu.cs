using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class ParentMenu : BaseRepository<tblparentmenu_newlayout_newsystem>
    {
        public ParentMenu(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
