using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Maximus.Data.Interface.Concrete;
using Maximus.Data.Models;

namespace Maximus.Data.models.RepositoryModels
{
    public class AccVatCodes : BaseRepository<tblacc_vatcodes>
    {
        public AccVatCodes(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
