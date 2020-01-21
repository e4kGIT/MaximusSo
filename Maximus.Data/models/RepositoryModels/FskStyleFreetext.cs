using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class FskStyleFreetext : BaseRepository<tblfsk_style_freetext>
    {
        public FskStyleFreetext(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
