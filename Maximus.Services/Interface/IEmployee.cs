using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Models;
using Maximus.Data.models;

namespace Maximus.Services.Interface
{
    public interface IEmployee
    {
        List<string> GetRoles(string busId = "");
        bool LimitEmpUsers(string access, string busId);
        bool ShowHourse(string busId = "");
       string GetContactRef(int cntId);
        List<EmployeeViewModel> GetEmployeeByProcedure(string busId, string userId = "");
        List<EmployeeViewModel> GetEmployeeTemplate(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "");
        List<EmployeeViewModel> GetEmployee(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "");
        EmployeeViewModel GetEmployeeDetailsTemplatesById(string BuisnessId, string EmpID);
        EmployeeViewModel GetEmployeeById(string businessId, string empID);
        int DeleteEmployee(string Ucode, string employeeId, string busId);
        int UpdateEmployee(int cmpId, int addressId, string employeeId, string busId);
        string EditEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", string hrsCmb = "", string hoursNo = "", string hoursDept = "", bool isActive = false, string busId = "", List<string> templates = null, string ShowHourse = "", string REQ_REASONPAGE = "");
        string CreateNewEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string hrsCmb = "", string Department = "", bool isActive = false, bool isMapped = false, string hoursDept = "", string hoursNo = "", List<string> templates = null, string busId = "", string UserName = "", string ShowHourse = "", string REQ_REASONPAGE = "");

        MenuLayoutModel GetAllMenu();

    }
}
