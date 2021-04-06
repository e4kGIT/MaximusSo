using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class GatewayTbl : BaseRepository<tblpayment_gateways>
    {
        public GatewayTbl(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
