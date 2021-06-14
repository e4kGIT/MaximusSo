using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Data.models
{
   public class ImpExptModel
    {
        public List<ImpExpUsers> UserModel { get; set; }
        public List<EmployeeImportModel> EmpModel { get; set; }
        public List<AddressImportModel> AddressModel { get; set; }
    }
}
