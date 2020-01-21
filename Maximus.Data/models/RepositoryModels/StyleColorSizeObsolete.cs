using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class StyleColorSizeObsolete : BaseRepository<tblfsk_style_colour_size_obsolete>
    {
        public StyleColorSizeObsolete(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
