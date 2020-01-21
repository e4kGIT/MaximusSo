using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class FskStyleGroups : BaseRepository<tblfsk_style_groups>
    {
        public FskStyleGroups(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
