using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;

namespace Maximus.Data.models.RepositoryModels
{
    public class User : BaseRepository<tbluser>
    {
        public User(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
