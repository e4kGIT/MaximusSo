using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class TblAlternateTable : BaseRepository<tblaccemp_ucode_alternates>
    {
        public TblAlternateTable(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
