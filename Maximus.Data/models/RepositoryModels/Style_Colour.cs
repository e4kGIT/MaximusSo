using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class Style_Colour : BaseRepository<tblfsk_style_colour>
    {
        public Style_Colour(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
