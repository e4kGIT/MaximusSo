using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class StyleByFreetextView_Emergency : BaseRepository<styleby_freetextview_emergency>
    {
        public StyleByFreetextView_Emergency(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
