using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class CountryCodes : BaseRepository<tblbus_countrycodes>
    {
        public CountryCodes(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
