using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class Ucode_Description : BaseRepository<tblaccemp_ucodes_desc>
    {
        public Ucode_Description(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
