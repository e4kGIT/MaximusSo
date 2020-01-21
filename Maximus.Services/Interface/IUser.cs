using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
    public interface IUser
    {
        List<EmployeeLoginModel> GetLoginDetails(string userName, string passWord);
    }
}
