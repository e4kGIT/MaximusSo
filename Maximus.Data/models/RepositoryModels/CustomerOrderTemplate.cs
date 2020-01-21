using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class CustomerOrderTemplate : BaseRepository<tblsop_customerorder_template>
    {
        public CustomerOrderTemplate(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
