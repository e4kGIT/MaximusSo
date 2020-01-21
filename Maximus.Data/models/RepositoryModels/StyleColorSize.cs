using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class StyleColorSize : BaseRepository<tblfsk_style_colour_size>
    {
        public StyleColorSize(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
