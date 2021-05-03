using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class TblReturnsCredited : BaseRepository<tblsop_return_credited>
    {
        public TblReturnsCredited(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
