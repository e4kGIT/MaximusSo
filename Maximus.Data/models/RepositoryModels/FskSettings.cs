using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class FskSettings : BaseRepository<tblfsk_settings>
    {
        public FskSettings(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
