using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Data.models.RepositoryModels
{
    public class ContentLanguage : BaseRepository<tblcontent_lang>
    {
        public ContentLanguage(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
