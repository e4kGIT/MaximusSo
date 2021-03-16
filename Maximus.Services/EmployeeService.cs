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
using System.Web.Security;

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
        public readonly EmployeeRollout _employeeRo;
        public readonly User _user;
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
        public readonly ParentMenu _parentMenu;
        public readonly ChildMenu _childMenu;
        public readonly DataProcessing _dp;
        public readonly IDataConnection _dataConnection;
        public readonly tblSalesOrderHeader _salesOrdHead;
        public readonly OnlineUserIdEmployee _onlUserId;
        public readonly RolloutNames _empRolloutName;
        #endregion

        #region constructor
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            User user = new User(_unitOfWork);
            ParentMenu parentMenu = new ParentMenu(_unitOfWork);
            tblSalesOrderHeader salesOrdHead = new tblSalesOrderHeader(_unitOfWork);
            ChildMenu childMenu = new ChildMenu(_unitOfWork);
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
            OnlineUserIdEmployee onlUserId = new OnlineUserIdEmployee(_unitOfWork);
            EmployeeRollout employeeRo = new EmployeeRollout(_unitOfWork);
            RolloutNames empRolloutName = new RolloutNames(_unitOfWork);
            _dataConnection = dataConnection;
            _dp = dp;
            _empRolloutName = empRolloutName;
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
            _parentMenu = parentMenu;
            _childMenu = childMenu;
            _stockCard = stockCard;
            _style_Colour = style_Colour;
            _employeeRo = employeeRo;
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
            _salesOrdHead = salesOrdHead;
            _user = user;
            _onlUserId = onlUserId;
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
        public List<EmployeeViewModel> GetEmployee(string busId, string userId = "", string OrderPermission = "", string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "",string  RequirePermissionUSR ="")
        {
            return _dp.GetEmployee(busId, userId, OrderPermission, txtUcode, ddlAddress, txtUcodeDesc, txtCDepartment, txtRole, txtEmpNo, txtName, txtStDate, RequirePermissionUSR);
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

        #region GetMenu
        public MenuLayoutModel GetAllMenu()
        {
            MenuLayoutModel menu = new MenuLayoutModel();
            try
            {
                menu.ChildMenuItms = _childMenu.GetAll(x => x.IsEnable == 1).OrderBy(x => x.SeqNo).Select(x => new ChildMenuLayout
                {
                    ChildID = x.ChildID,
                    Description = x.Description,
                    SeqNo = x.SeqNo,
                    IsEnable = x.IsEnable,
                    IsPopUp = x.IsPopUp,
                    OnlyNewLayout = x.OnlyNewLayout,
                    ParentID = x.ParentID,
                    TitleDesc = x.TitleDesc,
                    URL = x.URL
                }).OrderBy(x => x.SeqNo).ToList().ToList();
                menu.ParentMenuItms = _parentMenu.GetAll(x => x.IsEnable == 1).OrderBy(x => x.SeqNo).Select(x => new ParentMenuLayout
                {
                    Description = x.Description,
                    IsEnable = x.IsEnable,
                    IsPermissionReq = x.IsPermissionReq,
                    OnlyNewLayout = x.OnlyNewLayout,
                    ParentID = x.ParentID,
                    SeqNo = x.SeqNo,
                    URL = x.URL
                }).OrderBy(x => x.SeqNo).ToList();
            }
            catch
            {

            }
            return menu;

        }
        #endregion

        #region DeleteEmployee
        public int DeleteEmployee(string Ucode, string employeeId, string busId)
        {
            return _dp.DeleteEmployee(Ucode, employeeId, busId);
        }
        #endregion

        #region UpdateEmployee
        public int UpdateEmployee(string cmpId, int addressId, string employeeId, string busId)
        {
            return _dp.UpdateEmployee(cmpId, addressId, employeeId, busId);
        }
        #endregion




        #region editEmployee
        public string EditEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", string hrsCmb = "", string hoursNo = "", string hoursDept = "", bool isActive = false, string busId = "", List<string> templates = null, string ShowHourse = "", string REQ_REASONPAGE = "", bool updOrder = false, bool mapUserEmp = false, string emailUsr = "", string roleUsr = "", string reissueUsr = "", bool chkMapAddr = false, DateTime? lstOrddat = null, DateTime? nextOrddat = null, bool usrActive = true)
        {
            if (EmpUcodes.Contains(','))
            {
                EmpUcodes = EmpUcodes.Replace(',', ';');
            }
            var depts = _departments.GetAll(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            var cmpId = _employee.GetAll(x => x.BusinessID == busId).First().CompanyID;
            try
            {
                if (depts.Count() > 0)
                {
                    if (emailUsr != "")
                    {
                        var user = _user.Exists(s => s.UserName == EmployeeId && s.BusinessID == busId) ? _user.GetAll(s => s.UserName == EmployeeId && s.BusinessID == busId).First() : new tbluser();
                        if (user.UserName != null)
                        {
                            user.ForeName = EmpFirstName;
                            user.SurName = EmpLastName;
                            user.Active = usrActive == true ? "Y" : "N";
                            user.Email_ID = emailUsr;
                            _user.Update(user);
                        }
                    }
                    if (reissueUsr != "" && _employeeRo.Exists(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()))
                    {
                        var empRo = _employeeRo.Exists(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()) ? _employeeRo.GetAll(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()).First() : new tblaccemp_employee_rollout();
                        ////empRo.BusinessID = busId;
                        ////empRo.CompanyID = cmpId;
                        ////empRo.EmployeeID = EmployeeId;
                        ////empRo.RolloutName = reissueUsr;
                        var LastOrder = lstOrddat == null ? DateTime.Now : lstOrddat.Value;
                        var NextOrder = nextOrddat == null ? DateTime.Now : nextOrddat.Value;
                        ////_employeeRo.Update(empRo);
                        string qry = "update tblaccemp_employee_rollout set RolloutName='" + reissueUsr + "', LastOrder='" + LastOrder.ToString("yyyy-MM-dd") + "', NextOrder='" + NextOrder.ToString("yyyy-MM-dd") + "' where BusinessID='" + busId + "' and CompanyID='" + cmpId + "'  and EmployeeID='" + EmployeeId + "'";
                        if (_dp.ExecuteQuerywidTrans(qry) >= 0)
                        {

                        }
                        else
                        {
                            return "An error occured while updating please try again ";
                        }
                    }

                    if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "" & Department != "")
                    {
                        var deptData = _departments.GetAll(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID;
                        var emp = _employee.GetAll(x => x.EmployeeID == EmployeeId && x.BusinessID == busId).First();
                        emp.Forename = EmpFirstName;
                        emp.Surname = EmpLastName;
                        emp.DepartmentID = deptData;
                        emp.EmployeeClosed = isActive == false ? Convert.ToSByte(true) : Convert.ToSByte(false);
                        emp.StartDate = StartDate;
                        emp.EndDate = EndDate;
                        _employee.Update(emp);
                        int a = 0;
                        var busAddsId = int.TryParse(Address, out a) ? _busAddress.GetAll(x => x.AddressID.ToString() == Address).First().AddressID : _busAddress.GetAll(x => x.Description == Address).First().AddressID;
                        if (updOrder)
                        {
                            var address = _busAddress.GetAll(x => x.AddressID == busAddsId).First();
                            if (address.Description != null)
                            {
                                if (_salesOrdHead.Exists(s => s.PinNo == EmployeeId && s.OrderType.ToLower() == "so" && s.OnlineConfirm == 0))
                                {
                                    foreach (var salesHeader in _salesOrdHead.GetAll(s => s.PinNo == EmployeeId && s.OrderType.ToLower()=="so" && s.OnlineConfirm == 0 && s.CustRef.ToLower().Contains("private")==false).ToList())
                                    {
                                        if (address.Description.Trim() != salesHeader.DelDesc.Trim())
                                        {
                                            salesHeader.DelAddress1 = address.Address1;
                                            salesHeader.DelAddress2 = address.Address2;
                                            salesHeader.DelAddress3 = address.Address3;
                                            salesHeader.DelCity = address.City;
                                            salesHeader.DelDesc = address.Description;
                                            salesHeader.DelPostCode = address.Postcode;
                                            salesHeader.DelTown = address.Town;
                                            salesHeader.CustRef = address.Postcode;
                                            _salesOrdHead.Update(salesHeader);
                                        }
                                    }
                                }
                            }
                        }
                        if (templates.Count == 0)
                        {
                            _ucodeEmployees.Delete(s => s.BusinessID == busId && s.EmployeeID == EmployeeId);
                            var ucodes = _ucodeEmployees.Exists(x => x.BusinessID == busId & x.EmployeeID == EmployeeId) ? _ucodeEmployees.GetAll(x => x.BusinessID == busId & x.EmployeeID == EmployeeId).Select(x => x.UCodeID.Trim()).ToList() : new List<string>();
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
                                if (!ucodes.Contains(EmpUcodes))
                                {
                                    var updateUcode = new tblaccemp_ucodesemployees();
                                    updateUcode.CompanyID = cmpId;
                                    updateUcode.UCodeID = EmpUcodes;
                                    updateUcode.EmployeeID = EmployeeId;
                                    updateUcode.BusinessID = busId;
                                    _ucodeEmployees.Insert(updateUcode);
                                    //commented on (03-02-21)
                                    //ucodes.Remove(EmpUcodes);
                                    //var ucode1 = ucodes[0];
                                    //DeleteEmployee(ucode1, EmployeeId, busId);
                                }
                                //else
                                //{
                                //    var updateUcode = new tblaccemp_ucodesemployees();
                                //    updateUcode.CompanyID = cmpId;
                                //    updateUcode.UCodeID = EmpUcodes;
                                //    updateUcode.EmployeeID = EmployeeId;
                                //    updateUcode.BusinessID = busId;
                                //    _ucodeEmployees.Insert(updateUcode);
                                //}
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
                            int res = UpdateEmployee(cmpId, Convert.ToInt32(busAddsId), EmployeeId, busId);
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
                else
                {
                    if (emailUsr != "")
                    {
                        var user = _user.Exists(s => s.UserName == EmployeeId && s.BusinessID == busId) ? _user.GetAll(s => s.UserName == EmployeeId && s.BusinessID == busId).First() : new tbluser();
                        if (user.UserName != null)
                        {
                            user.ForeName = EmpFirstName;
                            user.SurName = EmpLastName;
                            user.Active = usrActive == true ? "Y" : "N";
                            user.Email_ID = emailUsr;
                            _user.Update(user);
                        }
                    }
                    if (reissueUsr != "" && _employeeRo.Exists(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()))
                    {
                        var empRo = _employeeRo.Exists(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()) ? _employeeRo.GetAll(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()).First() : new tblaccemp_employee_rollout();
                        ////empRo.BusinessID = busId;
                        ////empRo.CompanyID = cmpId;
                        ////empRo.EmployeeID = EmployeeId;
                        ////empRo.RolloutName = reissueUsr;
                        var LastOrder = lstOrddat == null ? DateTime.Now : lstOrddat.Value;
                        var NextOrder = nextOrddat == null ? DateTime.Now : nextOrddat.Value;
                        ////_employeeRo.Update(empRo);
                        string qry = "update tblaccemp_employee_rollout set RolloutName='" + reissueUsr + "', LastOrder='" + LastOrder.ToString("yyyy-MM-dd") + "', NextOrder='" + NextOrder.ToString("yyyy-MM-dd") + "' where BusinessID='" + busId + "' and CompanyID='" + cmpId + "'  and EmployeeID='" + EmployeeId + "'";
                        if (_dp.ExecuteQuerywidTrans(qry) >= 0)
                        {

                        }
                        else
                        {
                            return "An error occured while updating please try again ";
                        }
                        ////var empRo = _employeeRo.Exists(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()) ? _employeeRo.GetAll(s => s.BusinessID == busId && s.CompanyID == cmpId && s.EmployeeID.Trim().ToLower() == EmployeeId.Trim().ToLower()).First() : new tblaccemp_employee_rollout();
                        ////empRo.BusinessID = busId;
                        ////empRo.CompanyID = cmpId;
                        ////empRo.EmployeeID = EmployeeId;
                        ////empRo.RolloutName = reissueUsr;
                        ////empRo.LastOrder = lstOrddat == null ? DateTime.Now : lstOrddat.Value;
                        ////empRo.NextOrder = nextOrddat == null ? DateTime.Now : lstOrddat.Value;
                        ////_employeeRo.Update(empRo);
                    }
                    if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "")
                    {

                        var deptData = _departments.Exists(x => x.BusinessID == busId && x.Department == Department) ? _departments.GetAll(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID : 0;
                        var emp = _employee.GetAll(x => x.EmployeeID == EmployeeId && x.BusinessID == busId).First();
                        emp.Forename = EmpFirstName;
                        emp.Surname = EmpLastName;
                        emp.DepartmentID = deptData;
                        emp.EmployeeClosed = isActive == false ? Convert.ToSByte(true) : Convert.ToSByte(false);
                        emp.StartDate = StartDate;
                        emp.EndDate = EndDate;
                        _employee.Update(emp);
                        int a = 0;
                        var busAddsId = int.TryParse(Address, out a) ? _busAddress.GetAll(x => x.AddressID.ToString() == Address).First().AddressID : _busAddress.GetAll(x => x.Description == Address).First().AddressID;
                        if (updOrder)
                        {
                            var address = _busAddress.GetAll(x => x.AddressID == busAddsId).First();
                            if (address.Description != null)
                            {
                                if (_salesOrdHead.Exists(s => s.PinNo == EmployeeId && s.OrderType.ToLower() == "so" && s.OnlineConfirm==0))
                                {
                                    foreach (var salesHeader in _salesOrdHead.GetAll(s => s.PinNo == EmployeeId && s.OrderType.ToLower() == "so" && s.OnlineConfirm == 0    && s.CustRef.ToLower().Contains("private") == false).ToList())
                                    {
                                        if (address.Description.Trim() != salesHeader.DelDesc.Trim())
                                        {
                                            salesHeader.DelAddress1 = address.Address1;
                                            salesHeader.DelAddress2 = address.Address2;
                                            salesHeader.DelAddress3 = address.Address3;
                                            salesHeader.DelCity = address.City;
                                            salesHeader.DelDesc = address.Description;
                                            salesHeader.DelPostCode = address.Postcode;
                                            salesHeader.DelTown = address.Town;
                                            salesHeader.CustRef = address.Postcode;
                                            _salesOrdHead.Update(salesHeader);
                                        }
                                    }
                                }
                            }
                        }
                        if (templates.Count == 0)
                        {
                            _ucodeEmployees.Delete(s => s.BusinessID == busId && s.EmployeeID == EmployeeId);
                            var ucodes = _ucodeEmployees.Exists(x => x.BusinessID == busId & x.EmployeeID == EmployeeId) ? _ucodeEmployees.GetAll(x => x.BusinessID == busId & x.EmployeeID == EmployeeId).Select(x => x.UCodeID.Trim()).ToList() : new List<string>();
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
                                if (!ucodes.Contains(EmpUcodes))
                                {
                                    var updateUcode = new tblaccemp_ucodesemployees();
                                    updateUcode.CompanyID = cmpId;
                                    updateUcode.UCodeID = EmpUcodes;
                                    updateUcode.EmployeeID = EmployeeId;
                                    updateUcode.BusinessID = busId;
                                    _ucodeEmployees.Insert(updateUcode);
                                    //ucodes.Remove(EmpUcodes);
                                    //var ucode1 = ucodes[0];
                                    //DeleteEmployee(ucode1, EmployeeId, busId);
                                }
                                //else
                                //{
                                //    var updateUcode = new tblaccemp_ucodesemployees();
                                //    updateUcode.CompanyID = cmpId;
                                //    updateUcode.UCodeID = EmpUcodes;
                                //    updateUcode.EmployeeID = EmployeeId;
                                //    updateUcode.BusinessID = busId;
                                //    _ucodeEmployees.Insert(updateUcode);
                                //}
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
                            int res = UpdateEmployee(cmpId, Convert.ToInt32(busAddsId), EmployeeId, busId);
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

            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }
        #endregion

        #region createEmployee

        public string CreateNewEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string hrsCmb = "", string Department = "", bool isActive = false, bool isMapped = false, string hoursDept = "", string hoursNo = "", List<string> templates = null, string busId = "", string UserName = "", string ShowHourse = "", string REQ_REASONPAGE = "", bool chkMapAddr = false, bool createUsr = false, string emailUsr = "", bool mapUserEmp = false, string roleUsr = "", string reissueUsr = "", DateTime? lstOrddat = null, DateTime? nextOrddat = null, MembershipUser mu = null)
        {
            var depts = _departments.GetAll(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            try
            {
                if (depts.Count() > 0)
                {

                    if (EmpFirstName != "" & EmployeeId != "" & Department != "")
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
                        emp.EmployeeClosed = isActive == false ? Convert.ToSByte(true) : Convert.ToSByte(false);
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
                            _onlUserId.Insert(onlineUser);
                        }
                        if (createUsr)
                        {
                            if (EmpFirstName != "" && EmployeeId != "" && roleUsr != "" && reissueUsr != "")
                            {
                                string rndPwd = _dp.BusinessParam("RNDPASSWORD", busId);
                                tbluser usr = new tbluser();
                                usr.ForeName = EmpFirstName;
                                usr.SurName = EmpLastName;
                                usr.UserName = EmployeeId;
                                usr.Email_ID = emailUsr;
                                usr.AccessID = roleUsr;
                                usr.Password = rndPwd;
                                usr.Createdby = UserName.ToString().Trim();
                                usr.Active = isActive ? "Y" : "N";
                                usr.BusinessID = busId;
                                usr.BusinessName = busId;
                                usr.AspUserID = mu != null ? mu.ProviderName : EmployeeId;
                                usr.CreateDate = DateTime.Now;
                                _user.Insert(usr);
                                if (mapUserEmp)
                                {
                                    var onlineUser = new tblonline_userid_employee();
                                    onlineUser.BusinessID = busId;
                                    onlineUser.CompanyID = cmpId;
                                    onlineUser.EmployeeID = EmployeeId;
                                    onlineUser.OnlineUserID = EmployeeId.ToString().Trim();
                                    _onlUserId.Insert(onlineUser);

                                }
                                if (reissueUsr != "" && _empRolloutName.Exists(s => s.Businessid == busId && s.IsClosed == 0 && s.Rollname.Trim().ToLower() == reissueUsr.Trim().ToLower()))
                                {
                                    tblaccemp_employee_rollout tblROl = new tblaccemp_employee_rollout();
                                    tblROl.BusinessID = busId;
                                    tblROl.CompanyID = cmpId;
                                    tblROl.EmployeeID = EmployeeId;
                                    tblROl.RolloutName = reissueUsr;
                                    tblROl.LastOrder = lstOrddat == null ? DateTime.Now : lstOrddat.Value;
                                    tblROl.NextOrder = nextOrddat == null ? DateTime.Now : nextOrddat.Value;
                                    _employeeRo.Insert(tblROl);
                                }

                            }
                        }
                        int a = 0;
                        var busAddsId = Address != "" ? int.TryParse(Address, out a) ? _busAddress.GetAll(x => x.AddressID.ToString() == Address).First().AddressID : _busAddress.GetAll(x => x.Description == Address).First().AddressID : 0;
                        if (chkMapAddr)
                        {

                            busAddsId = _dp.GetUserAddress(busId, UserName);
                        }
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

                                int res = UpdateEmployee(cmpId, Convert.ToInt32(busAddsId), EmployeeId, busId);
                                if (res > -1)
                                {
                                    return "success";
                                }
                            }
                            else
                            {
                                int res = UpdateEmployee(cmpId, Convert.ToInt32(busAddsId), EmployeeId, busId);
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
                else
                {

                    if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "")
                    {
                        var deptData = _departments.Exists(x => x.BusinessID == busId && x.Department == Department) ? _departments.GetAll(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID : 0;
                        var cmpId = _employee.GetAll(x => x.BusinessID == busId).First().CompanyID;
                        var emp = new tblaccemp_employee();
                        emp.CompanyID = cmpId;
                        emp.BusinessID = busId;
                        emp.EmployeeID = EmployeeId;
                        emp.Forename = EmpFirstName;
                        emp.Surname = EmpLastName;
                        emp.DepartmentID = deptData;
                        emp.EmployeeClosed = isActive == false ? Convert.ToSByte(true) : Convert.ToSByte(false);
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
                            _onlUserId.Insert(onlineUser);
                        }
                        if (createUsr)
                        {
                            if (EmpFirstName != "" && EmployeeId != "" && roleUsr != "" && reissueUsr != "")
                            {
                                string rndPwd = _dp.BusinessParam("RNDPASSWORD", busId);
                                tbluser usr = new tbluser();
                                usr.ForeName = EmpFirstName;
                                usr.SurName = EmpLastName;
                                usr.UserName = EmployeeId;
                                usr.Email_ID = emailUsr;
                                usr.AccessID = roleUsr;
                                usr.Password = rndPwd;
                                usr.Createdby = UserName.ToString().Trim();
                                usr.Active = isActive ? "Y" : "N";
                                usr.BusinessID = busId;
                                usr.AspUserID = mu != null ? mu.ProviderName : EmployeeId;
                                usr.BusinessName = busId;
                                usr.CreateDate = DateTime.Now;
                                _user.Insert(usr);
                                if (mapUserEmp)
                                {
                                    var onlineUser = new tblonline_userid_employee();
                                    onlineUser.BusinessID = busId;
                                    onlineUser.CompanyID = cmpId;
                                    onlineUser.EmployeeID = EmployeeId;
                                    onlineUser.OnlineUserID = EmployeeId.ToString().Trim();
                                    _onlUserId.Insert(onlineUser);
                                }
                                if (reissueUsr != "" && _empRolloutName.Exists(s => s.Businessid == busId && s.IsClosed == 0 && s.Rollname.Trim().ToLower() == reissueUsr.Trim().ToLower()))
                                {
                                    tblaccemp_employee_rollout tblROl = new tblaccemp_employee_rollout();
                                    tblROl.BusinessID = busId;
                                    tblROl.CompanyID = cmpId;
                                    tblROl.EmployeeID = EmployeeId;
                                    tblROl.RolloutName = reissueUsr;
                                    tblROl.LastOrder = lstOrddat == null ? DateTime.Now : lstOrddat.Value;
                                    tblROl.NextOrder = nextOrddat == null ? DateTime.Now : nextOrddat.Value;
                                    _employeeRo.Insert(tblROl);
                                }
                            }
                        }
                        int a = 0;
                        var busAddsId = Address != "" ? int.TryParse(Address, out a) ? _busAddress.GetAll(x => x.AddressID.ToString() == Address).First().AddressID : _busAddress.GetAll(x => x.Description == Address).First().AddressID : 0;
                        if (chkMapAddr)
                        {

                            busAddsId = _dp.GetUserAddress(busId, UserName);
                        }

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

                                int res = UpdateEmployee(cmpId, Convert.ToInt32(busAddsId), EmployeeId, busId);
                                if (res > -1)
                                {
                                    return "success";
                                }
                            }
                            else
                            {
                                int res = UpdateEmployee(cmpId, Convert.ToInt32(busAddsId), EmployeeId, busId);
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

            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }

        #endregion

        #region  GetContactRef 
        public string GetContactRef(int cntId)
        {
            return _busContact.Exists(s => s.ContactID == cntId && s.ContactType_ID == 7) ? _busContact.GetAll(s => s.ContactID == cntId && s.ContactType_ID == 7).First().Value : "";
        }

        public string ChangeEmpPwd(string oldPwd, string newPwd, string cnfPwd, string empId)
        {
            string result = "";
            if (_user.Exists(s => s.UserName == empId && s.Password == oldPwd))
            {
                if (newPwd == cnfPwd)
                {
                    var user = _user.GetAll(s => s.UserName == empId && s.Password == oldPwd).First();
                    user.Password = newPwd;
                    _user.Update(user);
                    result = "success";
                }
                else
                {
                    result = "The new password and confirm password does not match";
                }
            }
            else
            {
                result = "The Existing password you entered is wrong";
            }
            return result;
        }


        #endregion
        #region GetReturnOrders
        public List<EmployeeViewModel> GetReturnOrders(bool pointsReq, string role, string busId, string userID, string orderPermission,bool isEmergency=false,string rtnType="")
        {
            var reseult = _dp.GetReturnOrders(pointsReq, role, busId, userID, orderPermission, isEmergency, rtnType);
            return reseult;
        }

        public List<UserModule> GatAllUser()
        {
            var result = new List<UserModule>();
            result = _user.GetAll().AsEnumerable().Select(s => new UserModule { UserId = s.UserName, Name = s.ForeName + " " + s.SurName, EmailId = s.Email_ID, Access = s.AccessID, IsActive = s.Active }).ToList();
            return result;
        }
        #endregion

    }
}
