using Maximus.Data.Interface.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models.RepositoryModels
{
   public class StyleGroups:BaseRepository<tblfsk_style_groups>
    {
        public StyleGroups(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
