using Maximus.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
   public interface IImportExport
    {
          List<ImpExpUsers> GetAllUsers(string busId);
    }
}
