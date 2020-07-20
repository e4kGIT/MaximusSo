using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Models;
using Maximus.Data.models;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;

namespace Maximus.Services
{
    public class UserService : IUser
    {
        private readonly DataProcessing _dp;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BusAddress _busAddress;
        private readonly CUstomerOrderTemplateCostcenters _costcenters;
        private readonly UcodeEmployees _ucodeEmployees;
        private readonly OnlineUserIdEmployee _onlineUserIdEmployee;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DataProcessing dp = new DataProcessing(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);

            CUstomerOrderTemplateCostcenters costcenters = new CUstomerOrderTemplateCostcenters(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            OnlineUserIdEmployee onlineUserIdEmployee = new OnlineUserIdEmployee(_unitOfWork);
            _busAddress = busAddress;
            _onlineUserIdEmployee = onlineUserIdEmployee;
            _ucodeEmployees = ucodeEmployees;
            _costcenters = costcenters;
            _dp = dp;
        }
        public List<EmployeeLoginModel> GetLoginDetails(string userName, string passWord)
        {
            return _dp.GetLoginDetails(userName, passWord);
        }
        public bool HasCostCenter(string busId)
        {
            return _costcenters.Exists(x => x.BusinessID == busId) ? true : false;
        }

        public SiteCodeUserAddress GetSiteCodeAndUserAddress(string userName, string busId)
        {
            SiteCodeUserAddress result = new SiteCodeUserAddress();
            var addresId = _dp.GetScalar("Select AddressId from tblonline_emp_address where OnlineUserid='" + userName + "'") != "" ? Convert.ToInt32(_dp.GetScalar("Select AddressId from tblonline_emp_address where OnlineUserid='" + userName + "'")) : 0;
            if (addresId > 0)
            {
                var UserAddress = _busAddress.Exists(x => x.BusinessID.Trim() == busId.Trim() && x.AddressID == addresId) ? _busAddress.GetAll(x => x.BusinessID.Trim() == busId.Trim() && x.AddressID == addresId).First() : new tblbus_address();
                if (UserAddress.Description != "")
                {
                    result.UserAddress = UserAddress;
                    result.SiteCode = _costcenters.GetAll(x => x.BusinessID.Trim() == busId.Trim() && x.SiteName.ToLower().Trim() == UserAddress.Description.ToLower().Trim()).Select(x => x.ProjectCode).ToList();
                }
            }
            if (result.SiteCode == null || result.SiteCode.Count < 1)
            {

                var empLst = _onlineUserIdEmployee.GetAll(x => x.OnlineUserID.ToLower() == userName.ToLower() && x.BusinessID == busId).Select(x => x.EmployeeID).ToList();
                var ucodeLst = _ucodeEmployees.GetAll(x => empLst.Contains(x.EmployeeID)).Select(x => x.UCodeID).ToList();
                var Sitecodes = _costcenters.GetAll(x => ucodeLst.Contains(x.Uniformcode)).Select(x => x.ProjectCode).ToList();
                result.SiteCode = Sitecodes;

            }
            return result;
        }

        public tblbus_address GetUserAddress(string userName, string busId)
        {
            tblbus_address busAdd = new tblbus_address();
            var addresId = _dp.GetScalar("Select AddressId from tblonline_emp_address where OnlineUserid='" + userName + "'") != "" ? Convert.ToInt32(_dp.GetScalar("Select AddressId from tblonline_emp_address where OnlineUserid='" + userName + "'")) : 0;
            if (addresId > 0)
            {
                var UserAddress = _busAddress.Exists(x => x.BusinessID.Trim() == busId.Trim() && x.AddressID == addresId) ? _busAddress.GetAll(x => x.BusinessID.Trim() == busId.Trim() && x.AddressID == addresId).First() : new tblbus_address();
                if (UserAddress.Description != "")
                {
                    busAdd = UserAddress;
                     
                }
            }
            return busAdd;
        }
        public int GetUserCount(string userName)
        {
            return _dp.GetUserCount(userName);
        }
    }
}
