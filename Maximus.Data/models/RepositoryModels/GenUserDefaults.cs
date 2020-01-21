using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class GenUserDefaults : BaseRepository<tblgen_user_defaults>
    {
        public GenUserDefaults(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
