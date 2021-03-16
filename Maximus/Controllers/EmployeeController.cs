using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using Maximus.Data.Interface.Concrete;
using Maximus.Services.Interface;
using Maximus.Services;
using Maximus.Data.Models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.models;
using DevExpress.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace Maximus.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {  // GET: Employee
        #region declarations
        //DataProcessing dp = new DataProcessing();
        //e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataConnection _dataConnection;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly BusContact _busContact;
        public readonly CountryCodes _countryCodes;
        public readonly CustomAssembly _customAssembly;
        public readonly Departments _departments;
        public readonly Employee _employee1;
        public readonly FskStyleFreetext _fskStyleFreetext;
        public readonly Nextno _nextno;
        public readonly StockCard _stockCard;
        public readonly Style_Colour _style_Colour;
        public readonly Style_Sizes _style_Sizes;
        public readonly StyleByFreetext _styleByFreetext;
        private readonly PointStyle _stylePoints;
        public readonly StyleColorSizeObsolete _styleColorSizeObsolete;
        public readonly StyleGroups _styleGroups;
        public readonly StylesView _stylesView;
        public readonly TblFskStyle _tblFskStyle;
        public readonly Ucode_Description _ucode_Description;
        public readonly UcodeByFreeTextView _ucodeByFreeText;
        public readonly UcodeEmployees _ucodeEmployees;
        public readonly Ucodes _ucodes;
        public readonly BusAddress _busAddress;
        public readonly DataProcessing _dp;
        public readonly StyleSizePrice _styleSizePrice;
        public readonly CustomerOrderTemplate _customerOrderTemplate;
        public readonly tblSalesOrderHeader _salesOrderHeader;
        public readonly BusBusiness _busBusiness;
        public readonly FskSetValues _fskSetValues;
        public readonly Dimension1 _dimension1;
        public readonly DimFitCaption _dimFitCap;
        public readonly Reasoncodes _reason;
        public readonly FskColour _fskColor;
        public readonly IEmployee _employee;
        public readonly BusSetValues _busSetValues;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointsCard _pointsCard;
        public readonly EmployeeRollout _empRollout;
        public readonly UcodeReasons _ucodeReason;
        public readonly User _user;
        public readonly UcodeOperationsTbl _ucodeOperationsTbl;
        #endregion

        #region EmployeeController constructor
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            HomeService home = new HomeService(_unitOfWork);

            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            DimFitCaption dimFitCap = new DimFitCaption(_unitOfWork);
            PointStyle stylePoints = new PointStyle(_unitOfWork);
            FskColour fskColor = new FskColour(_unitOfWork);
            Reasoncodes reason = new Reasoncodes(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            BusBusiness busBusiness = new BusBusiness(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            UcodeOperationsTbl ucodeOperationsTbl = new UcodeOperationsTbl(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
            Departments departments = new Departments(_unitOfWork);
            Employee employee1 = new Employee(_unitOfWork);
            FskStyleFreetext fskStyleFreetext = new FskStyleFreetext(_unitOfWork);
            Nextno nextno = new Nextno(_unitOfWork);
            EmployeeRollout empRollout = new EmployeeRollout(_unitOfWork);
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
            Ucodes ucodes = new Ucodes(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            StyleSizePrice styleSizePrice = new StyleSizePrice(_unitOfWork);
            CustomerOrderTemplate customerOrderTemplate = new CustomerOrderTemplate(_unitOfWork);
            tblSalesOrderHeader salesOrderHeader = new tblSalesOrderHeader(_unitOfWork);
            Dimension1 dimension = new Dimension1(_unitOfWork);
            FskSetValues fskSetValues = new FskSetValues(_unitOfWork);
            EmployeeService employee = new EmployeeService(_unitOfWork);
            BusSetValues busSetValues = new BusSetValues(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            UcodeReasons ucodeReason = new UcodeReasons(_unitOfWork);
            User tblUser = new Data.models.RepositoryModels.User(_unitOfWork);
            _user = tblUser;
            _pointsByUcode = pointsByUcode;
            _pointsCard = pointsCard;
            _busSetValues = busSetValues;
            _ucodeOperationsTbl = ucodeOperationsTbl;
            _employee = employee;
            _fskSetValues = fskSetValues;
            _dimFitCap = dimFitCap;
            _dimension1 = dimension;
            _salesOrderHeader = salesOrderHeader;
            _customerOrderTemplate = customerOrderTemplate;
            _allAssemblies = allAssemblies;
            _assemblyDetail = assemblyDetail;
            _assemblyHeader = assemblyHeader;
            _busContact = busContact;
            _stylePoints = stylePoints;
            _countryCodes = countryCodes;
            _customAssembly = customAssembly;
            _departments = departments;
            _employee1 = employee1;
            _fskStyleFreetext = fskStyleFreetext;
            _nextno = nextno;
            _empRollout = empRollout;
            _stockCard = stockCard;
            _style_Colour = style_Colour;
            _style_Sizes = style_Sizes;
            _styleByFreetext = styleByFreetext;
            _ucodeReason = ucodeReason;
            _styleColorSizeObsolete = styleColorSizeObsolete;
            _styleGroups = styleGroups;
            _stylesView = stylesView;
            _tblFskStyle = tblFskStyle;
            _ucode_Description = ucode_Description;
            _ucodeByFreeText = ucodeByFreeText;
            _ucodeEmployees = ucodeEmployees;
            _ucodes = ucodes;
            _busAddress = busAddress;
            _styleSizePrice = styleSizePrice;
            _dp = dp;
            _busBusiness = busBusiness;
            _reason = reason;
            _fskColor = fskColor;
        }
        #endregion

        #region Welcome
        public ActionResult Welcome(string BusinessID)
        {
            ViewBag.HideSearch = true;
            Session["SelectedTemplates"] = new List<string>();
            Session["StyleMinPoints"] = new List<StyleAndMinPoints>();
            Session["updateEmailTemplate"] = new UpdateMailModel();
            Session["cardRows"] = 10;
            Session["cardColumns"] = 1;
            Session["ISEDITING"] = false;
            Session["Proceedrollout"] = false;
            Session["ColorSizestyle"] = Session["ColorSizestyle"] == null ? "SWATCHES" : Session["ColorSizestyle"].ToString();
            if (Session["BuisnessId"] == null || Session["UserName"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }
            Session["MenuItems"] = _employee.GetAllMenu();
            if (Session["BuisnessId"] == null)
            {
                Session["qty"] = "0";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
            }
            else if (Session["BuisnessId"].ToString() != BusinessID)
            {
                Session["qty"] = "0";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
            }
            else
            {
                if (Session["SalesOrderHeader"] == null)
                {
                    Session["qty"] = "0";
                    Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                    Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                    Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
                }
            }
            if (Session["EmployeeViewModel"] == null)
            {
                Session["EmployeeViewModel"] = (List<EmployeeViewModel>)_employee.GetEmployee(BusinessID, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), "", "", "", "", "", "", "", "", Session["RequirePermissionUSR"].ToString());
                if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 1)
                {
                    if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpIsActive)
                    {
                        ViewBag.HideSearch = false;
                        if (!((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes.Contains(',') || GetEmergencyOrderDetail(BusinessID))
                        {

                            GotoCard(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpFirstName + " " + ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpLastName, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes);

                            var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                            if (templates.Count > 0)
                            {
                                Session["Templates"] = templates;
                            }
                            else
                            {
                                Session["Templates"] = new List<string>();
                            }
                        }
                    }
                }
                else
                {
                    ViewBag.HideSearch = true;
                    var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                    if (templates.Count > 0)
                    {
                        Session["Templates"] = templates;
                    }
                    else
                    {
                        Session["Templates"] = new List<string>();

                    }
                }
            }
            return View();
        }

        #endregion

        #region Index and EmpGrid
        public ActionResult Index(string BusinessID)
        {

            ViewBag.HideSearch = true;
            Session["SelectedTemplates"] = new List<string>();
            if (Session["StyleMinPoints"] == null)
            {
                Session["StyleMinPoints"] = new List<StyleAndMinPoints>();
            }
            Session["updateEmailTemplate"] = new UpdateMailModel();
            Session["cardRows"] = 10;
            Session["cardColumns"] = 1;
            Session["ISEDITING"] = false;
            Session["Proceedrollout"] = false;
            Session["ColorSizestyle"] = Session["ColorSizestyle"] == null ? "SWATCHES" : Session["ColorSizestyle"].ToString();
            if (Session["BuisnessId"] == null || Session["UserName"] == null)
            {
                return RedirectToAction("LogOff", "User");
            }
            Session["MenuItems"] = _employee.GetAllMenu();
            if (Session["BuisnessId"] == null)
            {
                Session["qty"] = "0";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
            }
            else if (Session["BuisnessId"].ToString() != BusinessID)
            {
                Session["qty"] = "0";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
            }
            else
            {
                if (Session["SalesOrderHeader"] == null)
                {
                    Session["qty"] = "0";
                    Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                    Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                    Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
                }
            }
            if (Session["EmployeeViewModel"] == null)
            {
                Session["EmployeeViewModel"] = (List<EmployeeViewModel>)_employee.GetEmployee(BusinessID, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), "", "", "", "", "", "", "", "", Session["RequirePermissionUSR"].ToString());
                if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 1)
                {
                    if (Convert.ToBoolean(Session["PRIVATEORDER"]))
                    {
                        var ucodeID = _dp.BusinessParam("PRIVATEUCODE", BusinessID);
                        GotoCard(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpFirstName + " " + ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpLastName, ucodeID);

                        var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                        if (templates.Count > 0)
                        {
                            Session["Templates"] = templates;
                        }
                        else
                        {
                            Session["Templates"] = new List<string>();
                        }
                        if (Convert.ToBoolean(Session["IsEmergency"]) != true && IsEmergencyUcde(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes))
                        {
                            return RedirectToAction("Welcome", new { BusinessID = BusinessID });
                        }

                        return RedirectToAction("Index", "Private");
                    }
                    else if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpIsActive)
                    {
                        ViewBag.HideSearch = false;
                        if (!((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes.Contains(',') || GetEmergencyOrderDetail(BusinessID))
                        {
                            var empFrst = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First();
                            GotoCard(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpFirstName + " " + ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpLastName, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes);

                            var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                            if (templates.Count > 0)
                            {
                                Session["Templates"] = templates;
                            }
                            else
                            {
                                Session["Templates"] = new List<string>();
                            }
                            if (Convert.ToBoolean(Session["IsEmergency"]) != true && IsEmergencyUcde(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes))
                            {
                                return RedirectToAction("Welcome", new { BusinessID = BusinessID });
                            }

                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ViewBag.HideSearch = true;
                    var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                    if (templates.Count > 0)
                    {
                        Session["Templates"] = templates;
                    }
                    else
                    {
                        Session["Templates"] = new List<string>();

                    }
                }
            }
            else
            {

                if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 1)
                {

                    if (Convert.ToBoolean(Session["PRIVATEORDER"]))
                    {
                        var ucodeID = _dp.BusinessParam("PRIVATEUCODE", BusinessID);
                        GotoCard(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpFirstName + " " + ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpLastName, ucodeID);

                        var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                        if (templates.Count > 0)
                        {
                            Session["Templates"] = templates;
                        }
                        else
                        {
                            Session["Templates"] = new List<string>();
                        }
                        if (Convert.ToBoolean(Session["IsEmergency"]) != true && IsEmergencyUcde(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes))
                        {
                            return RedirectToAction("Welcome", new { BusinessID = BusinessID });
                        }

                        return RedirectToAction("Index", "Private");
                    }
                    else if (!((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes.Contains(','))
                    {
                        GotoCard(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpFirstName + " " + ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpLastName, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes);
                        var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                        if (templates.Count > 0)
                        {
                            Session["Templates"] = templates;
                        }
                        else
                        {
                            Session["Templates"] = new List<string>();

                        }
                        if (Convert.ToBoolean(Session["IsEmergency"]) != true && IsEmergencyUcde(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes))
                        {
                            return RedirectToAction("Welcome", new { BusinessID = BusinessID });
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.HideSearch = true;
                    var templates = _customerOrderTemplate.Exists(x => x.BusinessID == BusinessID) ? _customerOrderTemplate.GetAll(x => x.BusinessID == BusinessID).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();
                    if (templates.Count > 0)
                    {
                        Session["Templates"] = templates;
                    }
                    else
                    {
                        Session["Templates"] = new List<string>();
                    }
                }
            }
            return View("Employee");
        }
        #region IsEmergencyUcde

        public bool IsEmergencyUcde(string ucode)
        {
            var result = false;
            if (ucode != "" && ucode != null)
            {
                if (ucode.Contains(","))
                {
                    var ucodeArr = ucode.Split(',');
                    result = _pointsByUcode.Exists(s => ucodeArr.Contains(s.UcodeID)) ? false : true;
                }
                else
                {
                    result = _pointsByUcode.Exists(s => s.UcodeID == ucode) ? false : true;
                }
            }
            return result;
        }
        #endregion

        #region GetEmergencyMessage
        public string EmergencyMessagePop()
        {

            if (Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["EmergencyMsg"]) == false)
            {
                var result = _dp.GetEmergencyMessage();
                Session["EmergencyMsg"] = true;
                return result;
            }
            else
            {
                return "";
            }
        }
        #endregion 

        public bool GetEmergencyOrderDetail(string BusinessID)
        {
            bool result = true;
            var arr = new string[] { };
            List<string> normUcode = new List<string>();
            List<string> matUcode = new List<string>();
            List<string> emergencyUcode = new List<string>();
            var selEmpUcode = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes;
            if (selEmpUcode.Contains(","))
            {
                arr = selEmpUcode.Split(',');
            }
            foreach (var ucode in arr)
            {
                if (_pointsByUcode.Exists(s => s.UcodeID == ucode))
                {
                    if (ucode.ToLower().Contains("maternity"))
                    {
                        matUcode.Add(ucode);
                    }
                    else
                    {
                        normUcode.Add(ucode);
                    }
                }
                else
                {
                    emergencyUcode.Add(ucode);
                }
            }
            if (normUcode.Count > 1 && normUcode.Count != 0 && Convert.ToBoolean(Session["IsEmergency"]) == false)
            {
                return false;
            }
            else if (emergencyUcode.Count > 1 && emergencyUcode.Count != 0 && normUcode.Count == 1)
            {

                Session["normUcode"] = normUcode.First();
                Session["emergencyUcode"] = string.Join(",", emergencyUcode.ToArray());
                if (Convert.ToBoolean(Session["IsEmergency"]) == false)
                {
                    ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes = normUcode.First();
                    return true;
                }
                else
                {
                    var mvjvb = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes;
                    ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes = string.Join(",", emergencyUcode.ToArray());
                    var mvjvb1 = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes;
                    return false;
                }
            }
            else if (emergencyUcode.Count > 1 && emergencyUcode.Count != 0)
            {
                var mvjvb = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes;
                ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes = string.Join(",", emergencyUcode.ToArray());
                var mvjvb1 = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes;
                return false;
            }
            else
            {
                Session["normUcode"] = Convert.ToBoolean(Session["Maternity"]) && matUcode.Count > 0 ? matUcode.First() : Convert.ToBoolean(Session["Maternity"]) == false ? normUcode.Count > 0 ? normUcode.First() : "" : "";
                Session["emergencyUcode"] = emergencyUcode.First();
                ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes = selEmpUcode.Replace(emergencyUcode.First(), "").TrimEnd(',');
                var mvjvb = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes;
                return true;
            }


        }

        public JsonResult GetEmployeeResultValue()
        {
            var arr = (List<EmployeeViewModel>)Session["EmployeeViewModel"];
            var jsonResult = Json(new { arr }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult BulkOrderPartial()
        {
            var templates = (List<string>)Session["Templates"];
            if (templates.Count > 0)
            {
                var businessId = Session["BuisnessId"].ToString();
                var ucodeLst = _dataConnection.GetAllTemplates(businessId);
                return PartialView("_bulkOrderPartial", ucodeLst);
            }
            else
            {
                var businessId = Session["BuisnessId"].ToString();
                var ucodeLst = _dataConnection.GetAllUcodesAndDesc(businessId);
                return PartialView("_bulkOrderPartial", ucodeLst);
            }
        }



        [AllowAnonymous]
        public ActionResult EmployeeGridViewPartial(string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "", bool IsCallBack = false)
        {
            if (IsCallBack == false)
            {
                EmployeeGridFilterModal filterModel = new EmployeeGridFilterModal();
                filterModel.Ucode = txtUcodeDesc;
                filterModel.EmployeeId = txtEmpNo;
                filterModel.Name = txtName;
                filterModel.Department = txtCDepartment;
                filterModel.Role = txtRole;
                Session["FilterModal"] = filterModel;
            }
            var templates = new List<string>();
            var businessId = Session["BuisnessId"].ToString();
            templates = _customerOrderTemplate.Exists(x => x.BusinessID == businessId) ? _customerOrderTemplate.GetAll(x => x.BusinessID == businessId).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();

            Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 1)
                {
                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(s => s.SalesOrderLine.Count == 0))
                    {
                        foreach (var hed in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.SalesOrderLine.Count == 0).ToList())
                        {
                            ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Remove(hed);
                        }
                    }
                }
                var modelq = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                Session["SalesOrderLine"] = new List<SalesOrderLineViewModel>();
            }
            var result = new List<EmployeeViewModel>();

            if (templates.Count > 0)
            {
                Session["Templates"] = templates;
                result = _employee.GetEmployeeTemplate(businessId, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), ((EmployeeGridFilterModal)Session["FilterModal"]).Ucode, ddlAddress, ((EmployeeGridFilterModal)Session["FilterModal"]).Ucode, ((EmployeeGridFilterModal)Session["FilterModal"]).Department, ((EmployeeGridFilterModal)Session["FilterModal"]).Role, ((EmployeeGridFilterModal)Session["FilterModal"]).EmployeeId, ((EmployeeGridFilterModal)Session["FilterModal"]).Name, txtStDate);
                if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 0)
                {
                    Session["EmployeeViewModel"] = result;
                }
                //result = _dataConnection.getEmployeeDetailsTemplates(Session["BuisnessId"].ToString());
            }
            else
            {
                Session["Templates"] = new List<string>();
                result = _employee.GetEmployee(businessId, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), ((EmployeeGridFilterModal)Session["FilterModal"]).Ucode, ddlAddress, ((EmployeeGridFilterModal)Session["FilterModal"]).Ucode, ((EmployeeGridFilterModal)Session["FilterModal"]).Department, ((EmployeeGridFilterModal)Session["FilterModal"]).Role, ((EmployeeGridFilterModal)Session["FilterModal"]).EmployeeId, ((EmployeeGridFilterModal)Session["FilterModal"]).Name, txtStDate, Session["RequirePermissionUSR"].ToString());
                Session["EmployeeViewModel"] = result;
            }
            if (((EmployeeGridFilterModal)Session["FilterModal"]).Ucode != "" && ((EmployeeGridFilterModal)Session["FilterModal"]).EmployeeId != "" && ((EmployeeGridFilterModal)Session["FilterModal"]).Department != "" && ((EmployeeGridFilterModal)Session["FilterModal"]).Role != "" && ((EmployeeGridFilterModal)Session["FilterModal"]).Name != "")
            {
                result = result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower()) && x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower()) && x.Department.ToLower().Contains(txtCDepartment.ToLower()) && x.role.ToLower().Contains(txtRole.ToLower()) && (x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower()))).ToList();
            }
            if (((EmployeeGridFilterModal)Session["FilterModal"]).Ucode != "")
            {
                result = result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower())).ToList();
            }
            if (((EmployeeGridFilterModal)Session["FilterModal"]).Department != "")
            {
                result = result.Where(x => x.Department.ToLower().Contains(txtCDepartment.ToLower())).ToList();
            }
            if (((EmployeeGridFilterModal)Session["FilterModal"]).Role != "")
            {
                result = result.Where(x => x.role.ToLower().Contains(txtRole.ToLower())).ToList();
            }
            if (((EmployeeGridFilterModal)Session["FilterModal"]).EmployeeId != "")
            {
                result = Convert.ToBoolean(Session["ISEDITING"]) ? result.Where(x => x.EmployeeId.ToLower() == txtEmpNo.ToLower()).ToList() : result.Where(x => x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower())).ToList();
            }
            if (((EmployeeGridFilterModal)Session["FilterModal"]).Name != "")
            {
                result = result.Where(x => x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower())).ToList();
            }
            if (Convert.ToBoolean(Session["IsEmergency"]))
            {
                result = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).ToList();
            }
            return PartialView("_EmployeeGridViewPartial", result);
        }

        public List<string> GetAutocompleteVal(string keyword = "")
        {
            List<string> data = new List<string>();
            if (((List<SalesOrderLineViewModel>)Session["EmployeeModel"]).Count > 0)
            {
                var result = (List<SalesOrderLineViewModel>)Session["EmployeeModel"];
                data = result.Where(x => x.EmployeeId.Contains(keyword)).Select(x => x.EmployeeId).ToList();
                return data;
            }
            return data;
        }

        #endregion

        #region cardRedirection
        public string GotoCard(string EmployeeId, string EmpName, string Ucodes1)
        {
            string Ucodes = ""; var busine = Session["BuisnessId"].ToString();



            if (Convert.ToBoolean(Session["IsEmergency"]))
            {
                if (Session["emergencyUcode"] != null)
                {
                    Ucodes = Session["emergencyUcode"].ToString().Contains(",") ? Session["emergencyUcode"].ToString().Contains(Ucodes1) ? Ucodes1 : Session["emergencyUcode"].ToString() : Session["emergencyUcode"].ToString();
                }
                else
                {
                    Ucodes = Ucodes1;
                }

            }
            else
            {
                if (Session["Access"].ToString().ToLower() != "user")
                {
                    List<string> emrLst = new List<string>();
                    emrLst = _ucodeEmployees.GetAll(s => s.EmployeeID == EmployeeId && s.UCodeID.ToLower() != Ucodes1.ToLower()).Select(s => s.UCodeID).ToList();
                    foreach (var ucodeEMR in emrLst)
                    {
                        if (_pointsByUcode.Exists(s => s.UcodeID == ucodeEMR) == false)
                        {
                            Session["emergencyUcode"] = ucodeEMR;
                        }
                    }
                }
                Ucodes = Ucodes1 != null && Ucodes1.Contains(",") ? Session["normUcode"].ToString() : Ucodes1;
            }
            Session["EmpName"] = EmpName;
            Session["SelectedEmp"] = EmployeeId;
            Session["selectedUcodes"] = Ucodes;

            //var UCODESTYLES = _stylePoints.Exists(s => s.UcodeID.ToLower().Trim() == Ucodes.ToLower().Trim() && s.BusinessID.ToLower().Trim() == busine.ToLower().Trim()) ? _stylePoints.GetAll(s => s.UcodeID.ToLower().Trim() == Ucodes.ToLower().Trim() && s.BusinessID.ToLower().Trim() == busine.ToLower().Trim()).Select(s => s.StyleID).ToList() : new List<string>();
            ///added by sasi(30-12-20) barclays wanted points for maternity too 
            // _dp.UcodeStyles(ucode, busId) = _stylePoints.Exists(s => s.UcodeID.ToLower().Trim() == Ucodes.ToLower().Trim() && s.BusinessID.ToLower().Trim() == busine.ToLower().Trim()) ? _stylePoints.GetAll(s => s.UcodeID.ToLower().Trim() == Ucodes.ToLower().Trim() && s.BusinessID.ToLower().Trim() == busine.ToLower().Trim()).Select(s => s.StyleID).ToList() : new List<string>();
            ///
            Session["REQSTKLEVEL"] = _dp.GetRestockValue(Ucodes, busine);
            if ((bool)Session["IsBulkOrder1"] == false && (bool)Session["IsManPack"] == true)
            {
                Session["EmpName"] = EmpName;
                Session["SelectedEmp"] = EmployeeId;
                string ucodeHtml = "<p style=\"padding:0px;\">";
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
                {
                    var s = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
                    var EMP = Session["SelectedEmp"].ToString();
                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null))
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == EMP))
                        {
                            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null)
                            {
                                Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Where(ss => ss.IsDleted == false).Sum(x => x.OrdQty);
                            }
                        }
                        else
                        {
                            Session["qty"] = 0;
                        }
                    }
                }
                else
                {
                    Session["qty"] = 0;
                }
                var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                var SalesOrderHeaderLoc = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"];
                var emp = Session["SelectedEmp"].ToString();


                var address1 = _dataConnection.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };
                var addresArr = address1.Contains(",-,") ? System.Text.RegularExpressions.Regex.Split(address1, ",-,") : addArr;
                Session["cboDelAddress"] = address1 != "" ? addresArr[0] : "";
                string businessId = Session["BuisnessId"].ToString();

                string nomcode3 = _empRollout.Exists(s => s.BusinessID == businessId && s.EmployeeID == emp) ? _empRollout.GetAll(s => s.BusinessID == businessId && s.EmployeeID == emp).First().RolloutName : "";
                nomcode3 = Convert.ToBoolean(Session["IsEmergency"]) | _dp.CheckEmergency(businessId, Ucodes) ? "" : nomcode3;
                Session["RolloutName"] = nomcode3;
                Session["RolloutOrderEst"] = Convert.ToBoolean(Session["IsEmergency"]) | _dp.CheckEmergency(businessId, Ucodes) ? false : nomcode3 != "" && nomcode3 != null ? true : Convert.ToBoolean(Session["RolloutOrderEst"]);
                int reasonCodeHeader = Convert.ToBoolean(Session["IsEmergency"]) | _dp.CheckEmergency(businessId, Ucodes) ? _ucodeReason.Exists(s => s.BusinessID == busine && s.UcodeId.ToLower() == Ucodes.ToLower()) ? _ucodeReason.GetAll(s => s.BusinessID == busine && s.UcodeId.ToLower() == Ucodes.ToLower()).First().ReasonCodeID : 0 : 0;
                string email = _user.Exists(s => s.UserName == emp && s.Email_ID != null) ? _user.GetAll(s => s.UserName == emp).First().Email_ID : "";
                if (!salesOrderHeader.Any(x => x.EmployeeID == emp))
                {
                    var ds = addresArr.Count();
                    salesOrderHeader.Add(new SalesOrderHeaderViewModel
                    {
                        CustomerName = _busBusiness.Exists(s => s.BusinessID == businessId) ? _busBusiness.GetAll(s => s.BusinessID == businessId).First().Name : "",
                        AddressId = ds > 0 ? Convert.ToInt32(addresArr[0]) : 0,
                        DelDesc = ds > 0 ? addresArr[1] : "",
                        DelAddress1 = ds > 0 ? addresArr[2] : "",
                        DelAddress2 = ds > 0 ? addresArr[3] : "",
                        DelAddress3 = ds > 0 ? addresArr[4] : "",
                        DelTown = ds > 0 ? addresArr[5] : "",
                        DelCity = ds > 0 ? addresArr[6] : "",
                        DelPostCode = ds > 0 ? addresArr[7] : "",
                        DelCountry = ds > 0 ? addresArr[8] : "",
                        CustRef = ds > 0 ? GetCustRef(addresArr[9]) : "",
                        EmployeeName = Session["EmpName"].ToString(),
                        EmployeeID = Session["SelectedEmp"].ToString(),
                        UCodeId = Ucodes,
                        CustID = Session["BuisnessId"].ToString(),
                        IsUcode = true,
                        IsTemplate = false,
                        NomCode3 = nomcode3,
                        UserID = Session["UserName"].ToString(),
                        WarehouseID = Session["WareHouseID"].ToString(),
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        ReasonCode = reasonCodeHeader,
                        EmailID = Convert.ToBoolean(Session["PRIVATEORDER"]) ? email : "",
                        SalesOrderLine = new List<SalesOrderLineViewModel>()
                    });
                    SalesOrderHeaderLoc.Add(new SalesOrderHeaderViewModel
                    {
                        CustomerName = _busBusiness.Exists(s => s.BusinessID == businessId) ? _busBusiness.GetAll(s => s.BusinessID == businessId).First().Name : "",
                        DelDesc = ds > 0 ? addresArr[1] : "",
                        DelAddress1 = ds > 0 ? addresArr[2] : "",
                        DelAddress2 = ds > 0 ? addresArr[3] : "",
                        DelAddress3 = ds > 0 ? addresArr[4] : "",
                        DelTown = ds > 0 ? addresArr[5] : "",
                        DelCity = ds > 0 ? addresArr[6] : "",
                        DelPostCode = ds > 0 ? addresArr[7] : "",
                        DelCountry = ds > 0 ? addresArr[8] : "",
                        EmployeeName = "",
                        EmployeeID = "",
                        UCodeId = Ucodes,
                        UserID = Session["UserName"].ToString(),
                        CustID = Session["BuisnessId"].ToString(),
                        IsUcode = true,
                        IsTemplate = false,
                        WarehouseID = Session["WareHouseID"].ToString(),
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        EmailID = Convert.ToBoolean(Session["PRIVATEORDER"]) ? email : "",
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        SalesOrderLine = new List<SalesOrderLineViewModel>()
                    });
                }
                else if (salesOrderHeader.Count() == 1 && salesOrderHeader.Any(x => x.EmployeeID == emp && x.UCodeId != Ucodes))
                {
                    salesOrderHeader.First().ReasonCode = reasonCodeHeader;
                    SalesOrderHeaderLoc.First().ReasonCode = reasonCodeHeader;
                    salesOrderHeader.First().UCodeId = Ucodes;
                    SalesOrderHeaderLoc.First().UCodeId = Ucodes;
                }

                List<string> ucodeLst = new List<string>();
                List<UcodeModel> ucodeLst1 = new List<UcodeModel>();
                if (Ucodes.Contains(';'))
                {
                    foreach (var str in Ucodes.Split(';'))
                    {
                        ucodeLst.Add(str);

                    }

                }
                Session["SelectedUcode"] = Ucodes;

                if (ucodeLst.Count > 0)
                {
                    foreach (string ucode in ucodeLst)
                    {
                        string ucodeDesc = _ucode_Description.Exists(x => x.UCodeID == ucode) ? _ucode_Description.GetAll(x => x.UCodeID == Ucodes).First().Description : ucode;
                        ucodeHtml = ucodeHtml + " <span>" + ucode + "</span>-<span>" + ucodeDesc + "</span> ";
                        ucodeLst1.AddRange(_dataConnection.GetAllUcodeLst(ucode));
                    }
                }
                else
                {
                    try
                    {
                        var IsHiddenUcode = _ucodeOperationsTbl.Exists(s => s.UcodeId == Ucodes && s.FreeStkChk && s.IsEmergency) ? _ucodeOperationsTbl.GetAll(s => s.UcodeId == Ucodes && s.FreeStkChk && s.IsEmergency).First().HasAltStyles : false;
                        string ucodeDesc = _ucode_Description.Exists(x => x.UCodeID == Ucodes) ? _ucode_Description.GetAll(x => x.UCodeID == Ucodes).First().Description : Ucodes;
                        ucodeHtml = ucodeHtml + " <span>" + Ucodes + "</span>-<span>" + ucodeDesc + "</span> ";
                        //       var SSS = _ucodeByFreeText.ExecWithStoreProcedure("Call GetAllUcodeByFreeTextProcedure (@uCode)",
                        //new MySqlParameter("uCode", MySqlDbType.VarChar) { Value = Ucodes }).ToList();
                        if (IsHiddenUcode &&  Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["REQSTKLEVEL"]))
                        {
                            ucodeLst1 = _ucodeByFreeText.GetAll(x => x.UCodeID == Ucodes && x.IsHidden==0).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                        }
                        else
                        {
                            ucodeLst1 = _ucodeByFreeText.GetAll(x => x.UCodeID == Ucodes).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                        }
                    }
                    catch (Exception e)
                    {

                    }

                }
                ucodeHtml = ucodeHtml + "</p>";
                Session["UcodeDesc"] = ucodeHtml.ToString();
                var lst = new List<string>();
                foreach (var data in ucodeLst1)
                {
                    if (data.FreeText == null | data.FreeText == "")
                    {
                        lst.Add(data.StyleId);
                    }
                    else
                    {
                        lst.Add(data.FreeText);
                    }
                }
                Session["UcodeStyle"] = ucodeLst1;
                Session["UcFreeTxt"] = lst.Distinct().ToList();
            }
            else
            {
                string ucodeHtml = "<p style=\"padding:0px;\">";
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
                {
                    var s = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null))
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsUcode && x.SalesOrderLine != null))
                        {

                            var saleLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsUcode && x.SalesOrderLine != null).First().SalesOrderLine.Where(ss => ss.IsDleted == false);
                            Session["qty"] = saleLines.Sum(x => x.OrdQty);
                        }
                        else
                        {
                            Session["qty"] = 0;
                        }
                    }
                    else
                    {
                        Session["qty"] = 0;
                    }
                }
                else
                {
                    Session["qty"] = 0;
                }
                var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];

                var address1 = _dataConnection.getEmployeeAddress(Session["UserName"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };

                var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
                Session["cboDelAddress"] = address1 != "" ? addresArr[0] : "";
                string businessId = Session["BuisnessId"].ToString();
                if (!salesOrderHeader.Any(x => x.IsUcode))
                {
                    salesOrderHeader.Add(new SalesOrderHeaderViewModel
                    {
                        DelDesc = addresArr.Count() > 0 ? addresArr[1] : "",
                        DelAddress1 = addresArr.Count() > 0 ? addresArr[2] : "",
                        DelAddress2 = addresArr.Count() > 0 ? addresArr[3] : "",
                        DelAddress3 = addresArr.Count() > 0 ? addresArr[4] : "",
                        DelTown = addresArr.Count() > 0 ? addresArr[5] : "",
                        DelCity = addresArr.Count() > 0 ? addresArr[6] : "",
                        DelPostCode = addresArr.Count() > 0 ? addresArr[7] : "",
                        DelCountry = addresArr.Count() > 0 ? addresArr[8] : "",
                        EmployeeName = "",
                        EmployeeID = "",
                        UCodeId = (bool)Session["IsBulkOrder1"] ? "" : Ucodes,
                        CustID = Session["BuisnessId"].ToString(),
                        IsUcode = true,
                        IsTemplate = false,
                        WarehouseID = Session["WareHouseID"].ToString(),
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        SalesOrderLine = new List<SalesOrderLineViewModel>()
                    });

                }
                List<string> ucodeLst = new List<string>();
                List<UcodeModel> ucodeLst1 = new List<UcodeModel>();
                if (Ucodes.Contains(';'))
                {
                    foreach (var str in Ucodes.Split(';'))
                    {
                        ucodeLst.Add(str);

                    }

                }
                Session["SelectedUcode"] = Ucodes;

                if (ucodeLst.Count > 0)
                {
                    foreach (string ucode in ucodeLst)
                    {
                        string ucodeDesc = _ucode_Description.Exists(x => x.UCodeID == ucode) ? _ucode_Description.GetAll(x => x.UCodeID == Ucodes).First().Description : ucode;
                        ucodeHtml = ucodeHtml + " <span>" + ucode + "</span>-<span>" + ucodeDesc + "</span> ";
                        ucodeLst1.AddRange(_dataConnection.GetAllUcodeLst(ucode));

                    }
                }
                else
                {
                    try
                    {
                        string ucodeDesc = _ucode_Description.Exists(x => x.UCodeID == Ucodes) ? _ucode_Description.GetAll(x => x.UCodeID == Ucodes).First().Description : Ucodes;
                        ucodeHtml = ucodeHtml + " <span>" + Ucodes + "</span>-<span>" + ucodeDesc + "</span> ";
                        //       var SSS = _ucodeByFreeText.ExecWithStoreProcedure("Call GetAllUcodeByFreeTextProcedure (@uCode)",
                        //new MySqlParameter("uCode", MySqlDbType.VarChar) { Value = Ucodes }).ToList();
                        ucodeLst1 = _ucodeByFreeText.GetAll(x => x.UCodeID == Ucodes).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                    }
                    catch (Exception e)
                    {

                    }
                }
                ucodeHtml = ucodeHtml + "</p>";
                Session["UcodeDesc"] = ucodeHtml.ToString();
                var lst = new List<string>();
                foreach (var data in ucodeLst1)
                {
                    if (data.FreeText == null | data.FreeText == "")
                    {
                        lst.Add(data.StyleId);
                    }
                    else
                    {
                        lst.Add(data.FreeText);
                    }
                }
                Session["UcodeStyle"] = ucodeLst1;
                Session["UcFreeTxt"] = lst.Distinct().ToList();
            }

            if (Convert.ToBoolean(Session["PRIVATEORDER"]))
            {
                return Url.Content("~/Private/Index");
            }
            else
            {
                return Url.Content("~/Home/Index");
            }
        }
        #endregion

        #region GetCustRef 
        public string GetCustRef(string cntId)
        {
            var cntRef = "";
            if (cntId != "")
            {
                cntRef = _employee.GetContactRef(Convert.ToInt32(cntId));
            }
            return cntRef;
        }
        #endregion

        #region TemplateRedirection
        public string GotoCardTemplate(string EmployeeId, string EmpName, string Template)
        {
            Session["EmpName"] = EmpName;
            Session["SelectedEmp"] = EmployeeId;
            if ((bool)Session["IsBulkOrder1"] == false && (bool)Session["IsManPack"] == true)
            {
                string result = "";
                Session["EmpName"] = EmpName;
                Session["SelectedEmp"] = EmployeeId;
                string templateHtml = "<ol style=\"padding:0px;\">";
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
                {
                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null))
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()))
                        {
                            var jvj = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Where(s => s.IsDleted == false).ToList();
                            var jvj1 = jvj.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).ToList();
                            var jvj12 = jvj1.Sum(x => x.OrdQty);
                            Session["qty"] = jvj12;
                        }
                        else
                        {
                            Session["qty"] = 0;
                        }
                    }
                    else
                    {
                        Session["qty"] = 0;
                    }
                }
                else
                {
                    Session["qty"] = 0;
                }
                var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                var emp = Session["SelectedEmp"].ToString();
                var busine = Session["BuisnessId"].ToString();
                var address1 = _dataConnection.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };
                var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
                Session["cboDelAddress"] = address1 != "" ? addresArr[0] : "";
                string businessId = Session["BuisnessId"].ToString();
                string nomcode3 = _empRollout.Exists(s => s.BusinessID == businessId && s.EmployeeID == emp) ? _empRollout.GetAll(s => s.BusinessID == businessId && s.EmployeeID == emp).First().RolloutName : "";
                if (!salesOrderHeader.Any(x => x.EmployeeID == emp))
                {
                    salesOrderHeader.Add(new SalesOrderHeaderViewModel
                    {
                        CustomerName = _busBusiness.Exists(s => s.BusinessID == businessId) ? _busBusiness.GetAll(s => s.BusinessID == businessId).First().Name : "",
                        DelDesc = addresArr.Count() > 0 ? addresArr[0] : "",
                        DelAddress1 = addresArr.Count() > 0 ? addresArr[1] : "",
                        DelAddress2 = addresArr.Count() > 0 ? addresArr[2] : "",
                        DelAddress3 = addresArr.Count() > 0 ? addresArr[3] : "",
                        DelTown = addresArr.Count() > 0 ? addresArr[4] : "",
                        DelCity = addresArr.Count() > 0 ? addresArr[5] : "",
                        DelPostCode = addresArr.Count() > 0 ? addresArr[6] : "",
                        DelCountry = addresArr.Count() > 0 ? addresArr[7] : "",
                        EmployeeName = Session["EmpName"].ToString(),
                        EmployeeID = Session["SelectedEmp"].ToString(),
                        WarehouseID = Session["WareHouseID"].ToString(),
                        NomCode3 = nomcode3,
                        IsTemplate = true,
                        CustID = Session["BuisnessId"].ToString(),
                        IsUcode = false,
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        SalesOrderLine = new List<SalesOrderLineViewModel>()
                    });
                }
                List<string> templateLst = new List<string>();
                if (Template.Contains(';'))
                {
                    foreach (var str in Template.Split(';'))
                    { templateLst.Add(str); }

                }
                else
                {
                    templateLst.Add(Template);
                }
                Session["SelectedTemplates"] = templateLst;
                if (templateLst.Count > 0)
                {
                    foreach (string temp in templateLst)
                    {
                        templateHtml = templateHtml + "<li><span>" + temp + "</span></li>";
                    }
                }
                else
                {
                    try
                    {
                        templateHtml = templateHtml + "<li><span>" + Template + "</span> ></li>";
                    }
                    catch (Exception e)
                    {

                    }

                }
                templateHtml = templateHtml + "</ol>";
                Session["UcodeDesc"] = templateHtml.ToString();
            }
            else
            {
                string templateHtml = "<p style=\"padding:0px;\">";
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
                {
                    var s = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null))
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsTemplate && x.SalesOrderLine != null))
                        {
                            var saleLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsTemplate && x.SalesOrderLine != null).First().SalesOrderLine.Where(ss => ss.IsDleted == false);
                            Session["qty"] = saleLines.Sum(x => x.OrdQty);
                        }
                        else
                        {
                            Session["qty"] = 0;
                        }
                    }
                    else
                    {
                        Session["qty"] = 0;
                    }
                }
                else
                {
                    Session["qty"] = 0;
                }
                var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                var address1 = _dataConnection.getEmployeeAddress(Session["UserName"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };
                var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
                Session["cboDelAddress"] = address1 != "" ? addresArr[0] : "";
                string businessId = Session["BuisnessId"].ToString();
                if (!salesOrderHeader.Any(x => x.IsTemplate))
                {
                    salesOrderHeader.Add(new SalesOrderHeaderViewModel
                    {
                        DelDesc = addresArr.Count() > 0 ? addresArr[1] : "",
                        DelAddress1 = addresArr.Count() > 0 ? addresArr[2] : "",
                        DelAddress2 = addresArr.Count() > 0 ? addresArr[3] : "",
                        DelAddress3 = addresArr.Count() > 0 ? addresArr[4] : "",
                        DelTown = addresArr.Count() > 0 ? addresArr[5] : "",
                        DelCity = addresArr.Count() > 0 ? addresArr[6] : "",
                        DelPostCode = addresArr.Count() > 0 ? addresArr[7] : "",
                        DelCountry = addresArr.Count() > 0 ? addresArr[8] : "",
                        EmployeeName = "",
                        EmployeeID = "",
                        Template = Template,
                        IsTemplate = true,
                        IsUcode = false,
                        CustID = Session["BuisnessId"].ToString(),
                        WarehouseID = Session["WareHouseID"].ToString(),
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        SalesOrderLine = new List<SalesOrderLineViewModel>(),
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd")
                    });
                }
                List<string> templateLst = new List<string>();

                if (Template.Contains(';'))
                {
                    foreach (var str in Template.Split(';'))
                    { templateLst.Add(str); }
                }
                else
                {
                    templateLst.Add(Template);
                }
                Session["SelectedTemplate"] = Template;
                Session["SelectedTemplates"] = templateLst;
                if (templateLst.Count > 0)
                {
                    foreach (string temp in templateLst)
                    {
                        templateHtml = templateHtml + "<li><span>" + temp + "</span></li>";
                    }
                }
                else
                {
                    try
                    {
                        templateHtml = templateHtml + "<li><span>" + Template + "</span> ></li>";
                    }
                    catch (Exception e)
                    {

                    }

                }
                templateHtml = templateHtml + "</ol>";
                Session["UcodeDesc"] = templateHtml.ToString();
            }
            return Url.Content("~/Home/Index");
        }
        #endregion

        #region Edit Employee
        public ActionResult EditEmployee(string empId)
        {
            var templates = Session["Templates"] == null ? new List<string>() : (List<string>)Session["Templates"];
            var result = new EmployeeViewModel();
            string busId = Session["BuisnessId"].ToString();
            ViewBag.empId = empId;
            if (templates.Count > 0)
            {
                Session["Templates"] = templates;
                result = _employee.GetEmployeeDetailsTemplatesById(busId, empId);
            }
            else
            {
                result = _employee.GetEmployeeById(Session["BuisnessId"].ToString(), empId);
            }
            var isclosed = _employee1.GetAll(x => x.EmployeeID == empId && x.BusinessID == busId).First().EmployeeClosed;
            result.EmployeeId = result.EmployeeId == null ? _employee1.GetAll(x => x.EmployeeID == empId && x.BusinessID == busId).First().EmployeeID : empId;
            result.EmpFirstName = result.EmpFirstName == null ? _employee1.GetAll(x => x.EmployeeID == empId && x.BusinessID == busId).First().Forename : result.EmpFirstName;
            result.EmpLastName = result.EmpLastName == null ? _employee1.GetAll(x => x.EmployeeID == empId && x.BusinessID == busId).First().Surname : result.EmpLastName;
            var dept = _employee1.GetAll(x => x.EmployeeID == empId && x.BusinessID == busId).First().DepartmentID;
            result.EmpIsActive = result.EmpIsActive == false ? isclosed == Convert.ToSByte(false) ? true : false : result.EmpIsActive;
            result.Department = result.Department == null ? dept > 0 ? _departments.GetAll(x => x.DepartmentID == dept).First().Department : result.Department : result.Department;
            result.DepartmentLst = _departments.GetAll(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            result.ucodeLst = _dataConnection.GetUcodeList(empId, busId);
            result.EmpUcodes = _ucodeEmployees.Exists(s => s.EmployeeID == empId && s.BusinessID == busId) ? String.Join(",", (_ucodeEmployees.GetAll(s => s.EmployeeID == empId && s.BusinessID == busId).Select(s => s.UCodeID).ToList())) : "";
            int addId = _dataConnection.GetAddressId(busId, empId);
            result.Address = addId > 0 ? _busAddress.GetAll(x => x.AddressID == addId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).FirstOrDefault() : new BusAddress1();
            result.AddressLst = _busAddress.GetAll(x => x.BusinessID == busId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
            result.UserActive = _user.Exists(s => s.UserName.Trim() == empId.Trim()) ? _user.GetAll(s => s.UserName.Trim() == empId.Trim()).First().Active == "Y" ? true : false : false;
            return PartialView("_EmployeeEdit", result);
        }
        [HttpPost]
        public string EditEmployee1(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", string hrsCmb = "", string hoursNo = "", string hoursDept = "", bool isActive = false, bool updOrder = false, bool mapUserEmp = false, string emailUsr = "", string roleUsr = "", string reissueUsr = "", bool chkMapAddr = false, DateTime? lstOrddat = null, DateTime? nextOrddat = null, bool usrActive = true)
        {
            string result = "";
            try
            {
                if (Session["Access"].ToString().ToLower() != "user")
                {
                    if (emailUsr != "")
                    {
                        if (IsValid(emailUsr))
                        {
                            if (roleUsr != "" && reissueUsr != "")
                            {
                                if (Address != "")
                                {
                                    result = _employee.EditEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, Department, hrsCmb, hoursNo, hoursDept, isActive, Session["BuisnessId"].ToString(), (List<string>)Session["Templates"], Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), updOrder, mapUserEmp, emailUsr, roleUsr, reissueUsr, chkMapAddr, lstOrddat, nextOrddat, usrActive);
                                }
                                else
                                {
                                    result = "Validation";
                                }
                            }
                            else
                            {
                                result = "Validation";
                            }
                        }
                        else
                        {
                            result = "Validation";
                        }
                    }
                    else
                    {
                        if (roleUsr != "" && reissueUsr != "")
                        {
                            if (Address != "")
                            {
                                result = _employee.EditEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, Department, hrsCmb, hoursNo, hoursDept, isActive, Session["BuisnessId"].ToString(), (List<string>)Session["Templates"], Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), updOrder, mapUserEmp, emailUsr, roleUsr, reissueUsr, chkMapAddr, lstOrddat, nextOrddat, usrActive);
                            }
                            else
                            {
                                result = "Validation";
                            }
                        }
                        else
                        {
                            result = "Validation";
                        }
                    }
                }
                else
                {
                    result = _employee.EditEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, Department, hrsCmb, hoursNo, hoursDept, isActive, Session["BuisnessId"].ToString(), (List<string>)Session["Templates"], Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), updOrder, mapUserEmp, emailUsr, roleUsr, reissueUsr, chkMapAddr, lstOrddat, nextOrddat, usrActive);
                }

            }
            catch
            {
                result = "";
            }


            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(s => s.EmployeeID == EmployeeId))
            {
                int a = 0;
                var busAddsId = int.TryParse(Address, out a) ? _busAddress.GetAll(x => x.AddressID.ToString() == Address).First().ContactID : _busAddress.GetAll(x => x.Description == Address).First().ContactID;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).First().CustRef = GetCustRef(busAddsId.ToString());

            }
            return result;
        }
        #endregion

        #region SetAddressChange
        public void SetAddressChange()
        {
            Session["AddressChanged"] = false;
        }
        #endregion

        #region HasPreviousOrders
        public JsonResult HasPreviousOrders(string empId)
        {
            HasPreviousOrders prevOrder = new HasPreviousOrders();

            var sbt = Convert.ToSByte(false);
            if (_salesOrderHeader.Exists(s => s.PinNo == empId && s.OnlineConfirm == sbt))
            {
                prevOrder.Access = Session["Access"].ToString();
                prevOrder.PrevOrder = true;
                prevOrder.AddressChanged = Convert.ToBoolean(Session["AddressChanged"]);
            }

            return Json(prevOrder, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FillAddress
        public JsonResult FillAllAddress(int descAddId)
        {

            var FillAddressModel = new FillAddressModel();
            var result = _busAddress.GetAll(x => x.AddressID == descAddId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
            Session["AddressChanged"] = true;
            foreach (var dtat in result)
            {
                dtat.Country = _countryCodes.GetAll(x => x.CountryID == dtat.CountryCode).First().Country;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region createEmployee
        public ActionResult CreateNewEmployee()
        {

            var result = new EmployeeViewModel();
            string busId = Session["BuisnessId"].ToString();
            result.ucodeLst = _dataConnection.GetUcodeList("", busId);
            result.Roles = (List<string>)Session["Roles"];

            result.DepartmentLst = _departments.GetAll(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            result.Address = new BusAddress1();
            result.chkMapEmp = _employee.LimitEmpUsers(Session["Access"].ToString(), busId);
            result.chkMapAddr = Convert.ToBoolean(_dataConnection.BusinessParam("LimitUsrAddr", busId)) == true | !(_dataConnection.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "EMPLOYEE" ? true : false);
            result.AddressLst = _busAddress.GetAll(x => x.BusinessID == busId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
            Session["Mapemptome"] = !(Session["Access"].ToString().ToUpper().Trim() == "ADMIN" | Session["Access"].ToString().ToUpper().Trim() == "MANAGER");
            Session["datestart"] = _employee.ShowHourse(busId);
            Session["leavedate"] = _employee.ShowHourse(busId);
            Session["roleid"] = _employee.ShowHourse(busId);
            ViewBag.create = true;
            return PartialView("_EmployeeEdit", result);
        }


        [HttpPost]
        public string CreateNewEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string hrsCmb = "", string Department = "", bool isActive = false, bool isMapped = false, string hoursDept = "", string hoursNo = "", bool createUsr = false, string emailUsr = "", bool mapUserEmp = false, string roleUsr = "", string reissueUsr = "", bool chkMapAddr = false, DateTime? lstOrddat = null, DateTime? nextOrddat = null)
        {

            string result = "";
            string busId = Session["BuisnessId"].ToString();
            try
            {
                if (createUsr)
                {
                    MembershipUser mu = Membership.GetUser(EmployeeId);
                    string rndPwd = _dp.BusinessParam("RNDPASSWORD", busId);
                    if (emailUsr != "")
                    {
                        if (IsValid(emailUsr))
                        {
                            if (roleUsr != "" && reissueUsr != "")
                            {
                                if (Address != "")
                                {


                                    if (mu != null)
                                    {
                                        result = _employee.CreateNewEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, hrsCmb, Department, isActive, isMapped, hoursDept, hoursNo, (List<string>)Session["Templates"], busId, Session["UserName"].ToString().Trim(), Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), chkMapAddr, createUsr, emailUsr, mapUserEmp, roleUsr, reissueUsr, lstOrddat, nextOrddat, mu);
                                    }
                                    else
                                    {
                                        mu = Membership.CreateUser(EmployeeId, rndPwd);
                                        result = _employee.CreateNewEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, hrsCmb, Department, isActive, isMapped, hoursDept, hoursNo, (List<string>)Session["Templates"], busId, Session["UserName"].ToString().Trim(), Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), chkMapAddr, createUsr, emailUsr, mapUserEmp, roleUsr, reissueUsr, lstOrddat, nextOrddat, mu);
                                    }
                                }
                                else
                                {
                                    result = "Validation";
                                }
                            }
                            else
                            {
                                result = "Validation";
                            }
                        }
                        else
                        {
                            result = "Validation";
                        }
                    }
                    else
                    {
                        if (roleUsr != "" && reissueUsr != "")
                        {
                            if (Address != "")
                            {
                                if (mu != null)
                                {
                                    result = _employee.CreateNewEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, hrsCmb, Department, isActive, isMapped, hoursDept, hoursNo, (List<string>)Session["Templates"], busId, Session["UserName"].ToString().Trim(), Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), chkMapAddr, createUsr, emailUsr, mapUserEmp, roleUsr, reissueUsr, lstOrddat, nextOrddat, mu);
                                }
                                else
                                {
                                    mu = Membership.CreateUser(EmployeeId, rndPwd);
                                    result = _employee.CreateNewEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, hrsCmb, Department, isActive, isMapped, hoursDept, hoursNo, (List<string>)Session["Templates"], busId, Session["UserName"].ToString().Trim(), Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), chkMapAddr, createUsr, emailUsr, mapUserEmp, roleUsr, reissueUsr, lstOrddat, nextOrddat, mu);
                                }
                            }
                            else
                            {
                                result = "Validation";
                            }
                        }
                        else
                        {
                            result = "Validation";
                        }
                    }
                }
                else
                {
                    if (Address != "")
                    {
                        result = _employee.CreateNewEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, hrsCmb, Department, isActive, isMapped, hoursDept, hoursNo, (List<string>)Session["Templates"], busId, Session["UserName"].ToString().Trim(), Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString(), chkMapAddr);
                    }
                    else
                    {
                        result = "Validation";
                    }
                }

            }
            catch
            {
                result = "";
            }
            return result;
        }
        #endregion

        #region IsValid
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion

        #region EmployeeIdValidation
        public string EmployeeIdValidation(string empId)
        {
            string result = "";
            string busId = Session["BuisnessId"].ToString();
            if (empId != "")
            {
                if (empId.ToCharArray().Count() > 10)
                {
                    return "Employee Id length must be upto 10 characters";
                }
                else
                {
                    result = _employee1.Exists(x => x.EmployeeID == empId && x.BusinessID == busId) ? "" : "Success";
                    return result;
                }
            }
            return result;
        }
        #endregion

        #region ChangeOrderType
        public ActionResult ChangeOrderType(string orderType = "")
        {
            Session["OrderType"] = "SO";
            Session["Maternity"] = false; ;
            Session["qty"] = 0;
            Session["REQSTKLEVEL"] = false;
            Session["PRIVATEORDER"] = false;
            Session["IsEmergency"] = false;
            Session["PrivateMessage"] = false;
            Session["EmergencyMsg"] = false;
            Session["requireemergencyreason"] = false;
            Session["OVERRIDE_ENT_WITH_REASON"] = ((List<PermissionList>)Session["permissionLst"]).Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? ((List<PermissionList>)Session["permissionLst"]).Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
            var permissionLst = _dataConnection.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapEmp", Session["Access"].ToString());
            Session["Price"] = permissionLst.Any(x => x.ControlId.Trim() == "Price") ? permissionLst.Where(x => x.ControlId.Trim() == "Price").First().Permission.ToLower() : "hide";
            string busId = Session["BuisnessId"].ToString();
            if (orderType.ToLower().Contains("bulk"))
            {

                Session["isrtntype"] = "";
                Session["requireemergencyreason"] = false;
                Session["IsManPack"] = false;
                Session["returnorder"] = false;
                Session["IsEmergency"] = false;
                if (Convert.ToBoolean(Session["ISEDITING"]) || Convert.ToBoolean(Session["IsBulkOrder1"]) == false)
                {
                    Session["SalesOrderHeader"] = null;
                    Session["ReturnOrderHeader"] = null;
                }
                Session["IsBulkOrder1"] = true;
                Session["POINTSREQ"] = false;
                Session["OVERRIDE_ENT_WITH_REASON"] = ((List<PermissionList>)Session["permissionLst"]).Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? ((List<PermissionList>)Session["permissionLst"]).Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                Session["OrderType"] = "SO";
            }
            else if (orderType.ToLower().Contains("manpack"))
            {
                Session["isrtntype"] = "";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["StyleMinPoints"] = new List<StyleAndMinPoints>();
                Session["OrderType"] = "SO";
                var sss = Convert.ToBoolean(Session["IsManPack"]);
                if (Convert.ToBoolean(Session["ISEDITING"]) || Convert.ToBoolean(Session["IsManPack"]) == false || Convert.ToBoolean(Session["IsEmergency"]) == true)
                {
                    Session["SalesOrderHeader"] = null;
                    Session["ReturnOrderHeader"] = null;
                }
                Session["requireemergencyreason"] = false;
                Session["OVERRIDE_ENT_WITH_REASON"] = ((List<PermissionList>)Session["permissionLst"]).Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? ((List<PermissionList>)Session["permissionLst"]).Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                Session["EmployeeViewModel"] = null;
                Session["RolloutOrderEst"] = true;
                Session["IsEmergency"] = false;
                Session["IsManPack"] = true;
                Session["IsBulkOrder1"] = false;
                Session["returnorder"] = false;
                Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId);  

            }
            else if (orderType.ToLower().Contains("matern"))
            {
                Session["isrtntype"] = "";

                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["StyleMinPoints"] = new List<StyleAndMinPoints>();
                Session["OrderType"] = "SO";
                var sss = Convert.ToBoolean(Session["IsManPack"]);
                if (Convert.ToBoolean(Session["ISEDITING"]) || Convert.ToBoolean(Session["IsManPack"]) == false || Convert.ToBoolean(Session["IsEmergency"]) == true)
                {
                    Session["SalesOrderHeader"] = null;
                    Session["ReturnOrderHeader"] = null;
                }
                Session["requireemergencyreason"] = false;
                Session["OVERRIDE_ENT_WITH_REASON"] = ((List<PermissionList>)Session["permissionLst"]).Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? ((List<PermissionList>)Session["permissionLst"]).Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                Session["EmployeeViewModel"] = null;
                Session["RolloutOrderEst"] = true;
                Session["IsEmergency"] = false;
                Session["IsManPack"] = true;
                Session["IsBulkOrder1"] = false;
                Session["returnorder"] = false;
                Session["Maternity"] = true;
                Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId); Session["OrderType"] = "SO";

            }
            else if (orderType.ToLower().Contains("emerg"))
            {
                Session["OrderType"] = "SO";
                Session["EmergencyMsg"] = false;
                Session["isrtntype"] = "";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();

                if (Session["emergencyUcode"] != null)
                {

                    if (Session["Access"].ToString().ToLower() != "user")
                    {
                        Session["requireemergencyreason"] = true;
                        Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                        Session["IsManPack"] = true;
                        Session["POINTSREQ"] = false;
                        Session["IsEmergency"] = true;
                        Session["IsBulkOrder1"] = false;
                        Session["RolloutOrderEst"] = false;
                        Session["returnorder"] = false;
                        //commented by sasi(17-12-20)
                        //var EmpName = Session["EmpName"].ToString();
                        //var empId = Session["SelectedEmp"].ToString();
                        //var emerUcode = Session["emergencyUcode"].ToString();
                        //GotoCard(empId, EmpName, emerUcode);
                        //return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["requireemergencyreason"] = true;
                        Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                        Session["EmployeeViewModel"] = null;

                        Session["RolloutOrderEst"] = false;
                        Session["IsManPack"] = true;
                        Session["POINTSREQ"] = false;
                        Session["IsEmergency"] = true;
                        Session["IsBulkOrder1"] = false;
                        Session["returnorder"] = false;
                    }
                }
                else
                {
                    if (Session["Access"].ToString().ToLower() != "user")
                    {
                        Session["requireemergencyreason"] = true;
                        Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                        Session["EmployeeViewModel"] = null;
                        Session["IsManPack"] = true;
                        Session["POINTSREQ"] = false;
                        Session["RolloutOrderEst"] = false;
                        Session["IsEmergency"] = true;
                        Session["IsBulkOrder1"] = false;
                        Session["returnorder"] = false;
                    }
                    else
                    {
                        Session["requireemergencyreason"] = true;
                        Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                        Session["EmployeeViewModel"] = null;

                        Session["IsManPack"] = true;
                        Session["POINTSREQ"] = false;
                        Session["RolloutOrderEst"] = false;
                        Session["IsEmergency"] = true;
                        Session["IsBulkOrder1"] = false;
                        Session["returnorder"] = false;
                    }
                }
            }
            else if (orderType.ToLower().Contains("return"))
            {
                Session["requireemergencyreason"] = false;
                Session["EmployeeViewModel"] = null;
                Session["OrderType"] = "RT";
                Session["OVERRIDE_ENT_WITH_REASON"] = "hide";
                Session["IsManPack"] = true;
                Session["rtnempid"] = ""; Session["rtnempname"] = "";
                Session["rtnLines"] = new List<ReturnOrderModel>();
                Session["returnModellst"] = new List<ReturnOrderModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["POINTSREQ"] = true;
                Session["isrtntype"] = ReturnTypes.RETURNS.ToString();
                Session["RolloutOrderEst"] = false;
                Session["IsEmergency"] = false;
                Session["IsBulkOrder1"] = false;
                Session["returnorder"] = true;
                return RedirectToAction("GetReturnOrderGrid");
            }
            else if (orderType.ToLower().Contains("retemer"))
            {
                Session["requireemergencyreason"] = false;
                Session["EmployeeViewModel"] = null;
                Session["OVERRIDE_ENT_WITH_REASON"] = "hide";
                Session["OrderType"] = "RT";
                Session["IsManPack"] = true;
                Session["rtnempid"] = ""; Session["rtnempname"] = "";
                Session["rtnLines"] = new List<ReturnOrderModel>();
                Session["returnModellst"] = new List<ReturnOrderModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["POINTSREQ"] = false;
                Session["RolloutOrderEst"] = false;
                Session["isrtntype"] = ReturnTypes.EMERGENCY.ToString();
                Session["IsEmergency"] = true;
                Session["IsBulkOrder1"] = false;
                Session["returnorder"] = true;
                return RedirectToAction("GetReturnOrderGrid");
            }
            else if (orderType.ToLower().Contains("retmat"))
            {
                Session["requireemergencyreason"] = false;
                Session["EmployeeViewModel"] = null;
                Session["OrderType"] = "RT";
                Session["OVERRIDE_ENT_WITH_REASON"] = "hide";
                Session["IsManPack"] = true;
                Session["rtnempid"] = ""; Session["rtnempname"] = "";
                Session["rtnLines"] = new List<ReturnOrderModel>();
                Session["returnModellst"] = new List<ReturnOrderModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["POINTSREQ"] = true;
                Session["RolloutOrderEst"] = false;
                Session["IsEmergency"] = false;

                Session["isrtntype"] = ReturnTypes.MATERNITY.ToString();
                Session["IsBulkOrder1"] = false;
                Session["returnorder"] = true;
                return RedirectToAction("GetReturnOrderGrid");
            }
            else if (orderType.ToLower().Contains("private"))
            {
                Session["Price"] = "ReadOnly";
                Session["PRIVATEORDER"] = true;
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["StyleMinPoints"] = new List<StyleAndMinPoints>();
                // Session["REQSTKLEVEL"] = true;
            }
            var BusinessID = Session["BuisnessId"].ToString();
            return RedirectToAction("Index", "Employee", new { BusinessID = BusinessID });
        }
        #endregion

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = new object[0];
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Maximus.Data.Models.EmployeeViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Maximus.Data.Models.EmployeeViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.String EmployeeId)
        {
            var model = new object[0];
            if (EmployeeId != null)
            {
                try
                {

                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model);
        }
        public ActionResult exporter()
        {
            var sett = CreateExportGridViewSettings();
            return GridViewExtension.ExportToXls(sett, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]));
            //var result = (List<EmployeeViewModel>)Session["EmployeeModel"];
            //string htmlData = "", name = "";
            //htmlData = getHtmlData(result);
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=Employee_detail.xls");
            //Response.ContentType = "application/ms-excel";
            //Response.Charset = "";
            //Response.Output.Write(htmlData);
            //Response.Flush();
            //return null;
        }
        #region getHtmlData
        public string getHtmlData(List<EmployeeViewModel> data)
        {
            string htmlString = "<center><h1>  Employees  </h1></center><br/><br/><br/>";
            var businessId = Session["BuisnessId"].ToString();

            var result = new List<EmployeeViewModel>();
            htmlString = htmlString + "<table class='table-responsive'><tr><th>Employee Id</th><th>Department</th><th>First name</th><th>Last name</th><th>Uniforms</th><th>Total points</th><th>Used points</th><th>Last order</th><th>Next order</th></tr>";
            foreach (var values in data)
            {
                var nexDate = _empRollout.Exists(s => s.BusinessID == businessId && s.EmployeeID == values.EmployeeId) ? _empRollout.GetAll(s => s.BusinessID == businessId && s.EmployeeID == values.EmployeeId).First().NextOrder.Value.ToString("dd-MM-yyyy") : "";

                string finUcode = "", totPts = "";
                foreach (var ucode in values.EmpUcodes.Split(','))
                {
                    if (_pointsByUcode.Exists(s => s.UcodeID == ucode) == false)
                    {
                        finUcode = values.EmpUcodes.Replace(ucode, "");
                        finUcode = finUcode.TrimEnd(',');
                    }

                }
                if (finUcode.Contains(',') == false)
                {
                    totPts = _pointsByUcode.GetAll(s => s.UcodeID == finUcode && s.BusinessID == businessId).First().TotalPoints.ToString();
                }
                var pts = _dp.GetTotalSoPoints(businessId, values.EmployeeId, 0, _dp.UcodeStyles(finUcode, businessId));
                htmlString = htmlString + "<tr><td>" + values.EmployeeId + "</td><td>" + values.Department + "</td><td>" + values.EmpFirstName + "</td><td>" + values.EmpLastName + "</td><td>" + values.EmpUcodes + "</td><td>" + totPts + "</td><td>" + pts + "</td><td>" + values.LastOrderDate + "</td><td>" + nexDate + "</td></tr>";
            }

            return htmlString;
        }
        #endregion


        #region Change password

        public ActionResult ChangePassword()
        {
            return PartialView("_changePassword");
        }
        #endregion

        #region ChangePassWord1

        public string ChangePassWord1(string extPwd, string newPwd, string ConfPwd)
        {
            string result = "";
            MatchCollection ConfPwdMc = System.Text.RegularExpressions.Regex.Matches(newPwd, @"^\S*(?=\S{8,14})(?=\S*[0-9])(?=\S*[a-z])(?=\S*[A-Z])(?=\S*[-+.'@$*!}{':;)\/(])\S*$");
            if (ConfPwdMc.Count == 1)
            {
                if (extPwd != "" && newPwd != "" && ConfPwd != "")
                {
                    if (newPwd == ConfPwd)
                    {
                        string empId = Session["UserName"].ToString();
                        //if (Membership.ValidateUser(empId, extPwd))
                        //{

                        result = _employee.ChangeEmpPwd(extPwd, newPwd, ConfPwd, empId);
                        try
                        {
                            MembershipUser user;
                            user = Membership.GetUser(empId, false);
                            user.ChangePassword(user.ResetPassword(), newPwd);
                        }
                        catch (Exception e)
                        {

                        }
                        //}
                        //else
                        //{
                        //    result = "The Existing password you entered is incorrect";
                        //}
                    }
                    else
                    {
                        result = "The new password and confirm password does not match";
                    }
                }
                else
                {
                    if (extPwd == "")
                    {
                        result = "The existing password field is mandatory";
                    }
                    else if (newPwd == "")
                    {
                        result = "The new password field is mandatory";
                    }
                    else if (ConfPwd == "")
                    {
                        result = "The confirm password field is mandatory";
                    }
                }
            }
            else
            {
                result = "The password does not match the required cretaria";
            }
            return result;
        }
        #endregion

        #region getUserCreate
        public ActionResult getUserCreate(string employeeid = "")
        {
            string busId = Session["BuisnessId"].ToString();
            if (employeeid != "")
            {
                EmpUserCreate creatUsr = new EmpUserCreate();
                var rolloutInfo = _empRollout.Exists(s => s.EmployeeID == employeeid.Trim() && s.BusinessID == busId) ? _empRollout.GetAll(s => s.EmployeeID == employeeid.Trim() && s.BusinessID == busId).First() : new tblaccemp_employee_rollout();
                creatUsr.rollout = rolloutInfo.RolloutName != null ? rolloutInfo.RolloutName : "";
                creatUsr.lastOrdDate = rolloutInfo.LastOrder != null ? rolloutInfo.LastOrder.Value : DateTime.Now;
                creatUsr.nextOrdDate = rolloutInfo.NextOrder != null ? rolloutInfo.NextOrder.Value : DateTime.Now; ;
                var userInfo = _user.Exists(s => s.UserName == employeeid.Trim() && s.BusinessID == busId) ? _user.GetAll(s => s.UserName == employeeid.Trim() && s.BusinessID == busId).First() : new tbluser();
                creatUsr.Email = userInfo.Email_ID != null ? userInfo.Email_ID : "";
                creatUsr.role = userInfo.AccessID != null ? userInfo.AccessID : "";
                ViewData["creatUsr"] = creatUsr;
            }
            else
            {
                ViewBag.Create = true;
            }

            return PartialView("_usercreatePartial");
        }
        #endregion
        public GridViewSettings CreateExportGridViewSettings()
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "EmployeeGridView1";
            settings.KeyFieldName = "EmployeeId";

            settings.Columns.Add("EmployeeId");
            settings.Columns.Add("Department");
            //settings.Columns.Add("EmpFirstName").Caption = "First name";
            if (((List<string>)Session["Templates"]).Count() > 0)
            {
                settings.Columns.Add(col =>
                {
                    col.FieldName = "EmpFirstName";
                    col.Caption = "Firstname";

                });
                settings.Columns.Add(col =>
                {
                    col.FieldName = "EmpLastName";
                    col.Caption = "Lastname";

                });
            }
            else
            {
                settings.Columns.Add("EmpFirstName").Caption = "Firstname";
                settings.Columns.Add("EmpLastName").Caption = "Lastname";
            }
            //settings.Columns.Add("StartDate").PropertiesEdit.DisplayFormatString = "dd.MM.yyyy"; ;
            //settings.Columns.Add("EndDate").PropertiesEdit.DisplayFormatString = "dd.MM.yyyy"; ;
            if (((List<string>)Session["Templates"]).Count > 0)
            {
                settings.Columns.Add(col =>
                {
                    col.FieldName = "EmpUcodes";
                    col.Caption = "Templates";

                });
            }
            else
            {
                settings.Columns.Add(col =>
                {
                    col.FieldName = "EmpUcodes";
                    col.Caption = "Uniforms";

                });
            }
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {

                settings.Columns.Add(col =>
                {
                    col.FieldName = "TotalPoints";
                    col.Caption = "Total points";
                });
                settings.Columns.Add(col =>
                {
                    col.FieldName = "PointsUsed";
                    col.Caption = "Points used";
                });
            }

            settings.Columns.Add(col =>
            {
                //Maximus.Data.Models.e4kmaximusdbEntities enty = new Maximus.Data.Models.e4kmaximusdbEntities();
                col.FieldName = "LastOrderNo";
                col.Caption = "Last order info";
            });
            settings.Columns.Add(col =>
            {
                //Maximus.Data.Models.e4kmaximusdbEntities enty = new Maximus.Data.Models.e4kmaximusdbEntities();
                col.FieldName = "LastOrderDate1";
                col.Caption = "Last order date";
            });
            settings.Columns.Add(col =>
            {
                //Maximus.Data.Models.e4kmaximusdbEntities enty = new Maximus.Data.Models.e4kmaximusdbEntities();
                col.FieldName = "NextOrderDate";
                col.Caption = "Next order date";
            });

            return settings;
        }

        #region GetReturnOrderGrid
        public ActionResult GetReturnOrderGrid()
        {

            Session["ISRTNEDITING"] = false;
            string busId = Session["BuisnessId"].ToString();
            var result = Welcome(busId);
            if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 1)
            {
                return RedirectToAction("GetAllOrders", "Return", new { employeeId = ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId });
            }
            else
            {
                return View("ReturnOrder");
            }

        }
        #endregion
        [ValidateInput(false)]
        public ActionResult ReturnOrderGridviewPartial()
        {
            var rtnType = Session["isrtntype"] != null ? Session["isrtntype"].ToString() : "";
            var model = _employee.GetReturnOrders(Convert.ToBoolean(Session["POINTSREQ"].ToString()), Session["Access"].ToString(), Session["BuisnessId"].ToString(), Session["UserName"].ToString(), Session["OrderPermit"].ToString(), Convert.ToBoolean(Session["IsEmergency"].ToString()), rtnType);
            return PartialView("_ReturnOrderGridviewPartial", model);
        }



        public ActionResult UserModule()
        {
            return View();
        }


        [ValidateInput(false)]
        public ActionResult UserGridviewPartial()
        {
            var model = _employee.GatAllUser();
            return PartialView("_UserGridviewPartial", model);
        }
        public string ResetToGeneric(string user)
        {
            string result = "";
            if (user != null && user != "")
            {
                try
                {
                    var rndPassword = _dataConnection.BusinessParam("RNDPASSWORD", Session["BuisnessId"].ToString());
                    MembershipUser userer;
                    userer = Membership.GetUser(user, false);
                    userer.ChangePassword(userer.ResetPassword(), rndPassword);
                    var userToUpd = _user.Exists(s => s.UserName == user) ? _user.GetAll(s => s.UserName == user).First() : new tbluser();
                    userToUpd.Password = rndPassword;
                    _user.Update(userToUpd);
                    result = "success";
                }
                catch (Exception e)
                {

                }
            }
            return result;
        }

        #region ChangePointsByEmp
        public JsonResult ChangePointsByEmp(string emp = "", string ucode = "")
        {
            PointsModel pm = new PointsModel();

            if (emp != "" && ucode != "")
            {
                string busid = Session["BuisnessId"].ToString();
                var pointsStyle = _stylePoints.Exists(s => s.UcodeID == ucode && s.BusinessID == busid) ? _stylePoints.GetAll(s => s.UcodeID == ucode && s.BusinessID == busid).Select(s => s.StyleID).ToList() : new List<string>();
                pm.TotalPoints = _pointsByUcode.Exists(s => s.BusinessID == busid && s.UcodeID == ucode) ? _pointsByUcode.GetAll(s => s.BusinessID == busid && s.UcodeID == ucode).First().TotalPoints.Value : 0;
                pm.UsedPoints = _dp.GetTotalSoPoints(busid, emp, 0, pointsStyle);

            }

            return Json(pm, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}





