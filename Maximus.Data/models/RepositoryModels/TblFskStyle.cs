using Maximus.Data.Interface.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models.RepositoryModels
{
    public class TblFskStyle: BaseRepository<tblfsk_style>
    {
        public TblFskStyle(IUnitOfWork unitOfWork) :base(unitOfWork)
        {

        }
    }
}
