using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Models;
using Maximus.Data.models;
using Maximus.Data.Interface.Concrete;

namespace Maximus.Services
{
    public class UserService : IUser
    {
        private readonly DataProcessing _dp;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
               DataProcessing dp = new DataProcessing(_unitOfWork);
            _dp = dp;
        }
        public List<EmployeeLoginModel> GetLoginDetails(string userName, string passWord)
        {
            return _dp.GetLoginDetails(userName, passWord);
        }
    }
}
