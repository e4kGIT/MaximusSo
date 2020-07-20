using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class StyleByFreetextAndUcode : BaseRepository<styleby_freetextview_ucode>
    {
        public StyleByFreetextAndUcode(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
