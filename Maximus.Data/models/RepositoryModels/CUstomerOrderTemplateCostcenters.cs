using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class CUstomerOrderTemplateCostcenters : BaseRepository<tblsop_customerorder_template_costcentre>
    {
        public CUstomerOrderTemplateCostcenters(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
