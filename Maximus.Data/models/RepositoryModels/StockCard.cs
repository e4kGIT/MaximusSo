using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class StockCard : BaseRepository<tblaccemp_stockcard>
    {
        public StockCard(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
