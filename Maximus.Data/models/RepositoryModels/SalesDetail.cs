using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class SalesDetail : BaseRepository<tblsop_salesorder_detail>
    {
        public SalesDetail(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
