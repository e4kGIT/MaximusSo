using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class tblCntRef : BaseRepository<tblbus_contact_ref>
    {
        public tblCntRef(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
