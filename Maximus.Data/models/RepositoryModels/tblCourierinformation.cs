using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class tblCourierinformation : BaseRepository<tblsop_courier_information>
    {
        public tblCourierinformation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
