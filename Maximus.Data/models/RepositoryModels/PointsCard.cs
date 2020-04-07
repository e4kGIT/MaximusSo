using Maximus.Data.Interface.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models.RepositoryModels
{
    public class PointsCard : BaseRepository<tblaccemp_pointscard>
    {
        public PointsCard(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
