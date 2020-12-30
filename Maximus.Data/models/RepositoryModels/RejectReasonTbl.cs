using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models
{
    public class RejectReasonTbl : BaseRepository<tblonline_rejectorder_reasons>
    {
        public RejectReasonTbl(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
