using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class BusBusiness : BaseRepository<tblbus_business>
    {
        public BusBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
