using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.Models;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.models;
using Maximus.Services;

namespace Maximus.Services
{
    public class EmployeeService : IEmployee
    {
        #region declarations
        public readonly IUnitOfWork _unitOfWork;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly BusAddress _busAddress;
        public readonly BusContact _busContact;
        public readonly CountryCodes _countryCodes;
        public readonly CustomAssembly _customAssembly;
        public readonly Departments _departments;
        public readonly Employee _employee;
        public readonly FskStyleFreetext _fskStyleFreetext;
        public readonly Nextno _nextno;
        public readonly StockCard _stockCard;
        public readonly Style_Colour _style_Colour;
        public readonly Style_Sizes _style_Sizes;
        public readonly StyleByFreetext _styleByFreetext;
        public readonly StyleColorSizeObsolete _styleColorSizeObsolete;
        public readonly StyleGroups _styleGroups;
        public readonly StylesView _stylesView;
        public readonly TblFskStyle _tblFskStyle;
        public readonly Ucode_Description _ucode_Description;
        public readonly UcodeByFreeTextView _ucodeByFreeText;
        public readonly UcodeEmployees _ucodeEmployees;
        public readonly Ucodes _ucodes;
        public readonly DataProcessing _dp;
        public readonly IDataConnection _dataConnection;
        #endregion

        #region constructor
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
            Departments departments = new Departments(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            FskStyleFreetext fskStyleFreetext = new FskStyleFreetext(_unitOfWork);
            Nextno nextno = new Nextno(_unitOfWork);
            StockCard stockCard = new StockCard(_unitOfWork);
            Style_Colour style_Colour = new Style_Colour(_unitOfWork);
            Style_Sizes style_Sizes = new Style_Sizes(_unitOfWork);
            StyleByFreetext styleByFreetext = new StyleByFreetext(_unitOfWork);
            StyleColorSizeObsolete styleColorSizeObsolete = new StyleColorSizeObsolete(_unitOfWork);
            StyleGroups styleGroups = new StyleGroups(_unitOfWork);
            StylesView stylesView = new StylesView(_unitOfWork);
            TblFskStyle tblFskStyle = new TblFskStyle(_unitOfWork);
            Ucode_Description ucode_Description = new Ucode_Description(_unitOfWork);
            UcodeByFreeTextView ucodeByFreeText = new UcodeByFreeTextView(_unitOfWork);
            UcodeEmployees ucodeEmployees = new UcodeEmployees(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            Ucodes ucodes = new Ucodes(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            _dp = dp;
            _allAssemblies = allAssemblies;
            _assemblyDetail = assemblyDetail;
            _assemblyHeader = assemblyHeader;
            _busContact = busContact;
            _busAddress = busAddress;
            _countryCodes = countryCodes;
            _customAssembly = customAssembly;
            _departments = departments;
            _employee = employee;
            _fskStyleFreetext = fskStyleFreetext;
            _nextno = nextno;
            _stockCard = stockCard;
            _style_Colour = style_Colour;
            _style_Sizes = style_Sizes;
            _styleByFreetext = styleByFreetext;
            _styleColorSizeObsolete = styleColorSizeObsolete;
            _styleGroups = styleGroups;
            _stylesView = stylesView;
            _tblFskStyle = tblFskStyle;
            _ucode_Description = ucode_Description;
            _ucodeByFreeText = ucodeByFreeText;
            _ucodeEmployees = ucodeEmployees;
            _ucodes = ucodes;
        }
        #endregion

        #region GetRoles 
        public List<string> GetRoles(string busId = "")
        {
            return _dp.GetRoles(busId);
        }
        #endregion

        #region LimitEmpUsers
        public bool LimitEmpUsers(string access, string busId)
        {
            return _dp.LimitEmpUsers(access, busId);
        }
        #endregion

        #region ShowHourse
        public bool ShowHourse(string busId = "")
        {
            return _dp.ShowHourse(busId);
        }
        #endregion

        #region GetEmployeeByProcedure
        public List<EmployeeViewModel> GetEmployeeByProcedure(string busId, string userId = "")
        {
            return _dp.GetEmployeeByProcedure(busId, userId);
        }
        #endregion

        #region GetEmployeeTemplate 
        public List<EmployeeViewModel> GetEmployeeTemplate(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "")
        {
            return _dp.GetEmployeeTemplate(busId, userId, OrderPermission, txtUcode, ddlAddress, txtUcodeDesc, txtCDepartment, txtRole, txtEmpNo, txtName, txtStDate);
        }
        #endregion

        #region GetEmployee
        public List<EmployeeViewModel> GetEmployee(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "")
        {
            return _dp.GetEmployee(busId, userId, OrderPermission, txtUcode, ddlAddress, txtUcodeDesc, txtCDepartment, txtRole, txtEmpNo, txtName, txtStDate);
        }
        #endregion

        #region GetEmployeeDetailsForTemplates
        public EmployeeViewModel GetEmployeeDetailsTemplatesById(string BuisnessId, string EmpID)
        {
            return _dp.getEmployeeDetailsTemplatesById(BuisnessId, EmpID);
        }

        #endregion

        #region GetEmployeeById
        public EmployeeViewModel GetEmployeeById(string businessId, string empID)
        {
            return _dp.GetEmployeeById(businessId, empID);
        }
        #endregion

        #region DeleteEmployee
        public int DeleteEmployee(string Ucode, string employeeId, string busId)
        {
            return _dp.DeleteEmployee(Ucode, employeeId, busId);
        }
        #endregion

        #region UpdateEmployee
        public int UpdateEmployee(int cmpId, int addressId, string employeeId, string busId)
        {
            return _dp.UpdateEmployee(cmpId, addressId, employeeId, busId);
        }
        #endregion

        #region editEmployee
        public string EditEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", string hrsCmb = "", string hoursNo = "", string hoursDept = "", bool isActive = false, string busId = "", List<string> templates = null, string ShowHourse = "", string REQ_REASONPAGE = "")
        {
            try
            {
                if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "" & Department != "")
                {
                    var cmpId = _employee.GetAll(x => x.BusinessID == busId & x.EmployeeID == EmployeeId).Select(x => x.CompanyID).First();
                    var deptData = _departments.GetAll(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID;
                    var emp =_employee.GetAll(x => x.EmployeeID == EmployeeId && x.BusinessID == busId).First();
                    emp.Forename = EmpFirstName;
                    emp.Surname = EmpLastName;
                    emp.DepartmentID = deptData;
                    emp.EmployeeClosed = isActive == false ? true : false;
                    emp.StartDate = StartDate;
                    emp.EndDate = EndDate;
                    _employee.Update(emp);
                    var busAddsId = _busAddress.GetAll(x => x.Description == Address).First().AddressID;
                    if (templates.Count == 0)
                    {
                        var ucodes =_ucodeEmployees.GetAll(x => x.BusinessID == busId & x.EmployeeID == EmployeeId).Select(x => x.UCodeID.Trim()).ToList();
                        if (EmpUcodes.Contains(';'))
                        {
                            foreach (string ucode in EmpUcodes.Split(';'))
                            {
                                if (!ucodes.Contains(ucode.Trim()))
                                {
                                    var updateUcode = new tblaccemp_ucodesemployees();
                                    updateUcode.CompanyID = cmpId;
                                    updateUcode.UCodeID = ucode;
                                    updateUcode.EmployeeID = EmployeeId;
                                    updateUcode.BusinessID = busId;
                                    _ucodeEmployees.Insert(updateUcode);
                                }


                            }
                        }
                        else
                        {
                            if (ucodes.Contains(EmpUcodes))
                            {
                                ucodes.Remove(EmpUcodes);
                                var ucode1 = ucodes[0];
                                DeleteEmployee(ucode1, EmployeeId, busId);
                            }
                        }
                    }
                    if (hoursNo != "" && hoursDept != "")
                    {
                        if (Convert.ToBoolean(ShowHourse) && Convert.ToBoolean(REQ_REASONPAGE))
                        {
                            var hrsUcode = new tblaccemp_ucodesemployees();
                            hrsUcode.BusinessID = busId;
                            hrsUcode.CompanyID = cmpId;
                            hrsUcode.EmployeeID = EmployeeId;
                            hrsUcode.UCodeID = "SQ" + hoursDept + hoursNo;
                            _ucodeEmployees.Insert(hrsUcode);
                        }
                    }
                    if (hrsCmb != "")
                    {
                        var hrsUcode = new tblaccemp_ucodesemployees();
                        hrsUcode.CompanyID = cmpId;
                        hrsUcode.UCodeID = hrsCmb;
                        hrsUcode.EmployeeID = EmployeeId;
                        hrsUcode.BusinessID = busId;
                        _ucodeEmployees.Insert(hrsUcode);
                    }

                    if (Address != "")
                    {
                        int res = UpdateEmployee(Convert.ToInt32(cmpId), Convert.ToInt32(busAddsId), EmployeeId, busId);
                        if (res > -1)
                        {
                            return "success";
                        }
                    }
                }
                else
                {
                    return "Validation";
                }
                return "success";
            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }
        #endregion

        #region createEmployee

        public string CreateNewEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string hrsCmb = "", string Department = "", bool isActive = false, bool isMapped = false, string hoursDept = "", string hoursNo = "", List<string> templates = null, string busId = "", string UserName = "", string ShowHourse = "", string REQ_REASONPAGE = "")
        {
            try
            {
                if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "" & Department != "")
                {
                    var deptData = _departments.GetAll(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID;
                    var cmpId = _employee.GetAll(x => x.BusinessID == busId).First().CompanyID;
                    var emp = new tblaccemp_employee();
                    emp.CompanyID = cmpId;
                    emp.BusinessID = busId;
                    emp.EmployeeID = EmployeeId;
                    emp.Forename = EmpFirstName;
                    emp.Surname = EmpLastName;
                    emp.DepartmentID = deptData;
                    emp.EmployeeClosed = isActive == false ? true : false;
                    emp.StartDate = StartDate == null ? DateTime.Now : StartDate;
                    emp.EndDate = EndDate == null ? DateTime.Now : StartDate;
                    _employee.Insert(emp);
                    if (isMapped)
                    {
                        var onlineUser = new tblonline_userid_employee();
                        onlineUser.BusinessID = busId;
                        onlineUser.CompanyID = cmpId;
                        onlineUser.EmployeeID = EmployeeId;
                        onlineUser.OnlineUserID = UserName.ToString().Trim();

                    }
                    var busAddsId = _busAddress.GetAll(x => x.Description == Address).First().AddressID;
                    if (templates.Count == 0)
                    {
                        if (EmpUcodes.Contains(';'))
                        {
                            foreach (string ucode in EmpUcodes.Trim().Split(';'))
                            {
                                var tblEmpUcode = new tblaccemp_ucodesemployees();
                                tblEmpUcode.BusinessID = busId;
                                tblEmpUcode.CompanyID = cmpId;
                                tblEmpUcode.UCodeID = ucode;
                                tblEmpUcode.EmployeeID = EmployeeId;
                                _ucodeEmployees.Insert(tblEmpUcode);
                            }
                        }
                        else
                        {
                            var tblEmpUcode = new tblaccemp_ucodesemployees();
                            tblEmpUcode.BusinessID = busId;
                            tblEmpUcode.CompanyID = cmpId;
                            tblEmpUcode.UCodeID = EmpUcodes;
                            tblEmpUcode.EmployeeID = EmployeeId;
                            _ucodeEmployees.Insert(tblEmpUcode);

                        }

                    }
                    if (hrsCmb != "")
                    {
                        var hrsUcode = new tblaccemp_ucodesemployees();
                        hrsUcode.BusinessID = busId;
                        hrsUcode.CompanyID = cmpId;
                        hrsUcode.UCodeID = hrsCmb;
                        hrsUcode.EmployeeID = EmployeeId;
                        _ucodeEmployees.Insert(hrsUcode);
                    }
                    if (hoursNo == "" && hoursDept == "")
                    {
                        if (Convert.ToBoolean(ShowHourse) && Convert.ToBoolean(REQ_REASONPAGE))
                        {
                            var hrsUcode = new tblaccemp_ucodesemployees();
                            hrsUcode.BusinessID = busId;
                            hrsUcode.CompanyID = cmpId;
                            hrsUcode.EmployeeID = EmployeeId;
                            hrsUcode.UCodeID = "SQ" + hoursDept + hoursNo;
                            _ucodeEmployees.Insert(hrsUcode);
                        }
                    }
                    if (Address != "")
                    {
                        if (templates.Count == 0)
                        {

                            int res = UpdateEmployee(Convert.ToInt32(cmpId), Convert.ToInt32(busAddsId), EmployeeId, busId);
                            if (res > -1)
                            {
                                return "success";
                            }
                        }
                        else
                        {
                            int res = UpdateEmployee(Convert.ToInt32(cmpId), Convert.ToInt32(busAddsId), EmployeeId, busId);
                            if (res > -1)
                            {
                                return "success";
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                }
                else
                {
                    return "Validation";
                }
                return "success";
            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }

        #endregion
    }
}
