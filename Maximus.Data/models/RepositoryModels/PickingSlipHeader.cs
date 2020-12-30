using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class PickingSlipHeader : BaseRepository<tblsop_pickingslip_header>
    {
        public PickingSlipHeader(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
