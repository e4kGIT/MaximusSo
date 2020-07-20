using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class EmployeeRollout : BaseRepository<tblaccemp_employee_rollout>
    {
        public EmployeeRollout(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
