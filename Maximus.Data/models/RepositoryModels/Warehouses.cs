using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class Warehouses : BaseRepository<tblwho_warehouses>
    {
        public Warehouses(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
