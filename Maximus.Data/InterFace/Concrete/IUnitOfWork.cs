using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.Interface.Concrete
{
    public interface IUnitOfWork:IDisposable
    {
        DbContext Db { get; }
    }
}
