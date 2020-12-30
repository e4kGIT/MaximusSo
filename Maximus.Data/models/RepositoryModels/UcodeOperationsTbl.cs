using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class UcodeOperationsTbl : BaseRepository<tblonline_ucode_operations>
    {
        public UcodeOperationsTbl(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
