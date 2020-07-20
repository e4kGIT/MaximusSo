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
        #endregion

        #region EmployeeController constructor
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            HomeService home = new HomeService(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            DimFitCaption dimFitCap = new DimFitCaption(_unitOfWork);
            FskColour fskColor = new FskColour(_unitOfWork);
            Reasoncodes reason = new Reasoncodes(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            BusBusiness busBusiness = new BusBusiness(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
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
            _pointsByUcode = pointsByUcode;
            _pointsCard = pointsCard;
            _busSetValues = busSetValues;
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

        #region Index and EmpGrid
        public ActionResult Index(string BusinessID)
        {
            ViewBag.HideSearch = true;
            Session["SelectedTemplates"] = new List<string>();
            Session["StyleMinPoints"] = new List<StyleAndMinPoints>();

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
                Session["EmployeeViewModel"] = (List<EmployeeViewModel>)_employee.GetEmployeeByProcedure(Session["BuisnessId"].ToString(), Session["UserName"].ToString());
                if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 1)
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
            else
            {

                if (((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count == 1)
                {
                    ViewBag.HideSearch = false;
                    if (!((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes.Contains(','))
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

        public bool GetEmergencyOrderDetail(string BusinessID)
        {
            bool result = true;
            var arr = new string[] { };
            List<string> normUcode = new List<string>();
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
                    normUcode.Add(ucode);
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
            else
            {
                Session["normUcode"] = normUcode.First();
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
                result = _employee.GetEmployee(businessId, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), ((EmployeeGridFilterModal)Session["FilterModal"]).Ucode, ddlAddress, ((EmployeeGridFilterModal)Session["FilterModal"]).Ucode, ((EmployeeGridFilterModal)Session["FilterModal"]).Department, ((EmployeeGridFilterModal)Session["FilterModal"]).Role, ((EmployeeGridFilterModal)Session["FilterModal"]).EmployeeId, ((EmployeeGridFilterModal)Session["FilterModal"]).Name, txtStDate);
                Session["EmployeeModel"] = result;
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
            string Ucodes = "";
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
                Ucodes = Ucodes1.Contains(",") ? Session["normUcode"].ToString() : Ucodes1;
            }
            Session["EmpName"] = EmpName;
            Session["SelectedEmp"] = EmployeeId;
            Session["selectedUcodes"] = Ucodes;
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
                                Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Sum(x => x.OrdQty);
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
                var busine = Session["BuisnessId"].ToString();
                var address1 = _dataConnection.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };
                var addresArr = address1.Contains(",-,") ? System.Text.RegularExpressions.Regex.Split(address1, ",-,") : addArr;
                Session["cboDelAddress"] = address1 != "" ? addresArr[0] : "";
                string businessId = Session["BuisnessId"].ToString();
                string nomcode3 = _empRollout.Exists(s => s.BusinessID == businessId && s.EmployeeID == emp) ? _empRollout.GetAll(s => s.BusinessID == businessId && s.EmployeeID == emp).First().RolloutName : "";
                nomcode3 = Convert.ToBoolean(Session["IsEmergency"]) ? "": nomcode3;
                if (!salesOrderHeader.Any(x => x.EmployeeID == emp))
                {
                    var ds = addresArr.Count();
                    salesOrderHeader.Add(new SalesOrderHeaderViewModel
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
                        CustRef = ds > 0 ? GetCustRef(addresArr[9]) : "",
                        EmployeeName = Session["EmpName"].ToString(),
                        EmployeeID = Session["SelectedEmp"].ToString(),
                        UCodeId = Ucodes,
                        CustID = Session["BuisnessId"].ToString(),
                        IsUcode = true,
                        IsTemplate = false,
                        NomCode3 = nomcode3,
                        WarehouseID = Session["WareHouseID"].ToString(),
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
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
                else if (salesOrderHeader.Count() == 1 && salesOrderHeader.Any(x => x.EmployeeID == emp && x.UCodeId != Ucodes))
                {
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

                            var saleLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsUcode && x.SalesOrderLine != null).First().SalesOrderLine;
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
                        UCodeId = Ucodes,
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

            return Url.Content("~/Home/Index");
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
                            var jvj = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.ToList();
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
                            var saleLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsTemplate && x.SalesOrderLine != null).First().SalesOrderLine;
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
            var templates = (List<string>)Session["Templates"];
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
            result.EmpIsActive = result.EmpIsActive == false ? isclosed == false ? true : false : result.EmpIsActive;
            result.Department = result.Department == null ? _departments.GetAll(x => x.DepartmentID == dept).First().Department : result.Department;
            result.DepartmentLst = _departments.GetAll(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            result.ucodeLst = _dataConnection.GetUcodeList(empId, busId);
            int addId = _dataConnection.GetAddressId(busId, empId);
            result.Address = addId > 0 ? _busAddress.GetAll(x => x.AddressID == addId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).FirstOrDefault() : new BusAddress1();
            result.AddressLst = _busAddress.GetAll(x => x.BusinessID == busId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
            return PartialView("_EmployeeEdit", result);
        }
        [HttpPost]
        public string EditEmployee1(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", string hrsCmb = "", string hoursNo = "", string hoursDept = "", bool isActive = false)
        {
            var result = _employee.EditEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, Department, hrsCmb, hoursNo, hoursDept, isActive, Session["BuisnessId"].ToString(), (List<string>)Session["Templates"], Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString());
            return result;
        }
        #endregion

        #region FillAddress
        public JsonResult FillAllAddress(int descAddId)
        {

            var FillAddressModel = new FillAddressModel();
            var result = _busAddress.GetAll(x => x.AddressID == descAddId).Select(x => new BusAddress1 { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, CountryCode = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
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
            result.Roles = _employee.GetRoles(busId);

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
        public string CreateNewEmployee(DateTime? StartDate = null, DateTime? EndDate = null, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string hrsCmb = "", string Department = "", bool isActive = false, bool isMapped = false, string hoursDept = "", string hoursNo = "")
        {

            string result = "";
            try
            {
                result = _employee.CreateNewEmployee(StartDate, EndDate, EmpFirstName, EmpLastName, EmployeeId, EmpUcodes, Address, hrsCmb, Department, isActive, isMapped, hoursDept, hoursNo, (List<string>)Session["Templates"], Session["BuisnessId"].ToString(), Session["UserName"].ToString().Trim(), Session["ShowHourse"].ToString(), Session["REQ_REASONPAGE"].ToString());
            }
            catch
            {
                result = "";
            }
            return result;
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
            //bool success = false;
            string busId = Session["BuisnessId"].ToString();
            if (orderType.ToLower().Contains("bulk"))
            {
                Session["requireemergencyreason"] = false;
                Session["IsManPack"] = false;
                Session["IsBulkOrder1"] = true;
                Session["OVERRIDE_ENT_WITH_REASON"] = ((List<PermissionList>)Session["permissionLst"]).Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? ((List<PermissionList>)Session["permissionLst"]).Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
            }
            else if (orderType.ToLower().Contains("manpack"))
            {
                Session["requireemergencyreason"] = false;
                Session["OVERRIDE_ENT_WITH_REASON"] = ((List<PermissionList>)Session["permissionLst"]).Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? ((List<PermissionList>)Session["permissionLst"]).Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                Session["EmployeeViewModel"] = null;
                Session["IsEmergency"] = false;
                Session["IsManPack"] = true;
                Session["IsBulkOrder1"] = false;
                Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId);
            }
            else if (orderType.ToLower().Contains("emerg"))
            {
                 
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
                        var EmpName = Session["EmpName"].ToString();
                        var empId = Session["SelectedEmp"].ToString();
                        var emerUcode = Session["emergencyUcode"].ToString();
                        GotoCard(empId, EmpName, emerUcode);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["requireemergencyreason"] = true;
                        Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                        Session["EmployeeViewModel"] = null;
                        Session["IsManPack"] = true;
                        Session["POINTSREQ"] = false;
                        Session["IsEmergency"] = true;
                        Session["IsBulkOrder1"] = false;
                    }
                }
                else
                {
                    if (Session["Access"].ToString().ToLower() != "user")
                    {
                        Session["requireemergencyreason"] = true;
                        Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                        Session["IsManPack"] = true;
                        Session["POINTSREQ"] = false;
                        Session["IsEmergency"] = true;
                        Session["IsBulkOrder1"] = false;
                    }
                }
            }
            //return Session["BuisnessId"].ToString();
            return RedirectToAction("Index", "Employee");
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
                var pts = _dp.GetTotalSoPoints(businessId, values.EmployeeId, 0);
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
                htmlString = htmlString + "<tr><td>" + values.EmployeeId + "</td><td>" + values.Department + "</td><td>" + values.EmpFirstName + "</td><td>" + values.EmpLastName + "</td><td>" + values.EmpUcodes + "</td><td>" + totPts + "</td><td>" + pts + "</td><td>" + values.LastOrderDate + "</td><td>" + nexDate + "</td></tr>";
            }

            return htmlString;
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

                    col.SetDataItemTemplateContent(x =>
                    {
                        string ucodeId = DataBinder.Eval(x.DataItem, "EmpUcodes").ToString();
                        string empId = DataBinder.Eval(x.DataItem, "EmployeeId").ToString();
                        string busID = Session["BuisnessId"].ToString();
                        var finUcode = "";
                        foreach (var ucode in ucodeId.Split(','))
                        {
                            if (_pointsByUcode.Exists(s => s.UcodeID == ucode) == false)
                            {
                                finUcode = ucodeId.Replace(ucode, "");
                                finUcode = finUcode.TrimEnd(',');
                            }

                        }
                        if (finUcode == "")
                        {
                            Response.Write("0");
                        }
                        else if (finUcode.Contains(","))
                        {
                            Response.Write("0");
                        }
                        else
                        {
                            var pts = _pointsByUcode.GetAll(s => s.UcodeID == finUcode && s.BusinessID == busID).First().TotalPoints.ToString();
                            Response.Write(pts);
                        }
                    });
                });
                settings.Columns.Add(col =>
                {
                    col.FieldName = "PointsUsed";
                    col.Caption = "Points used";
                    col.SetDataItemTemplateContent(x =>
                    {
                        string ucodeId = DataBinder.Eval(x.DataItem, "EmpUcodes").ToString();
                        string empId = DataBinder.Eval(x.DataItem, "EmployeeId").ToString();
                        string busID = Session["BuisnessId"].ToString();
                        if (ucodeId.Contains(","))
                        {
                            Response.Write("0");
                        }
                        else
                        {
                            var pts = _dp.GetTotalSoPoints(busID, empId, 0).ToString();
                            Response.Write(pts);
                        }
                    });
                });
            }

            settings.Columns.Add(col =>
            {
                //Maximus.Data.Models.e4kmaximusdbEntities enty = new Maximus.Data.Models.e4kmaximusdbEntities();
                col.FieldName = "Entitlement";
                col.Caption = "Last order";
                col.SetDataItemTemplateContent(x =>
                {
                    var s = DataBinder.Eval(x.DataItem, "LastOrderDate") != null ? (DataBinder.Eval(x.DataItem, "LastOrderDate")).ToString() : "";
                    DateTime LastDate = DataBinder.Eval(x.DataItem, "LastOrderDate") != null ? (DataBinder.Eval(x.DataItem, "LastOrderDate")).ToString() != "" ? DateTime.Parse((DataBinder.Eval(x.DataItem, "LastOrderDate")).ToString()) : DateTime.Now : DateTime.Now;
                    long ordNo = Convert.ToInt64((DataBinder.Eval(x.DataItem, "LastOrderNo")).ToString());
                    //{
                    //    string EmployeeId = (DataBinder.Eval(x.DataItem, "EmployeeId")).ToString();
                    //    var custId = Session["BuisnessId"].ToString();
                    //    try
                    //    {
                    //        var data = enty.tblsop_salesorder_header.Where(s => s.CustID == custId && s.PinNo == EmployeeId && s.OrderType == "SO").OrderByDescending(s => s.OrderDate).Select(s => new { OrderDate = s.OrderDate, OrderNo = s.OrderNo }).FirstOrDefault();
                    //    }
                    //    catch (Exception e)
                    //    {

                    //    }
                    //if (data != null)
                    //{
                    //    ViewContext.Writer.Write(string.Format("Order no: {0} on {1}", data.OrderNo, data.OrderDate.Value.ToString("dd-MM-yyyy")));
                    //}
                    if (ordNo > 0)
                    {
                        Response.Write(string.Format("Order no: {0} on {1} ", ordNo, LastDate.ToString("dd-MM-yyyy")));
                    }
                });
            });
            settings.Columns.Add(col =>
            {
                //Maximus.Data.Models.e4kmaximusdbEntities enty = new Maximus.Data.Models.e4kmaximusdbEntities();
                col.FieldName = "";
                col.Caption = "Next order date";

                col.SetDataItemTemplateContent(x =>
                {
                    //empRollout
                    string empId = DataBinder.Eval(x.DataItem, "EmployeeId").ToString();
                    string busID = Session["BuisnessId"].ToString();
                    string nextDate = _empRollout.Exists(s => s.BusinessID == busID && s.EmployeeID == empId) ? _empRollout.GetAll(s => s.BusinessID == busID && s.EmployeeID == empId).First().NextOrder.Value.ToString("dd-MM-yyyy") : "";
                    Response.Write(nextDate);
                });
            });

            return settings;
        }

    }





}
