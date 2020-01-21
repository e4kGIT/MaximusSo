using Maximus.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class StylesView : BaseRepository<getstylesview>
    {
        public StylesView(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
