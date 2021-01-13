using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Maximus.Controllers
{
    public class ReturnController : Controller
    {
        #region declarations
        //ControllerHelperMethods ctrlHelp = new ControllerHelperMethods();
        AllEnums enus = new AllEnums();
        public string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        private string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Maximus"].ConnectionString;
        [Dependency]
        private readonly IReturn _returns;
        private readonly IBasket _basket;
        private readonly IHome _home;
        [Dependency]
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataConnection _dataConnection;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly BusContact _busContact;
        public readonly CountryCodes _countryCodes;
        public readonly CustomAssembly _customAssembly;
        public readonly Departments _departments;
        public readonly Employee _employee;
        public readonly FskStyleFreetext _fskStyleFreetext;
        public readonly FskStyle _fskStyle;
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
        public readonly tblSalesLines _salesOrderLines;
        public readonly BusBusiness _busBusiness;
        public readonly FskSetValues _fskSetValues;
        public readonly Dimension1 _dimension1;
        public readonly DimFitCaption _dimFitCap;
        public readonly Reasoncodes _reason;
        public readonly FskColour _fskColor;
        public readonly UcodeByFreeTextView _ucodeByFreetext;
        public readonly StyleColorSize _styleColorSize;
        public readonly CUstomerOrderTemplateCostcenters _costCenter;
        public readonly PointStyle _pointStyle;
        public readonly PointsCard _pointsCard;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointsAdjustment _pointsAdjustment;
        public readonly ViewPointsCard _vuPointsCard;
        public readonly StyleByFreetextAndUcode _styleByFreetextAndUcode;
        private readonly tblManPackOrders _manPckOrders;
        private readonly tblManpackReturns _manPckRtnOrders;
        public readonly User _user;
        public readonly PickingSlipHeader _pickHeader;
        public readonly EmployeeRollout _empRollout;
        public readonly ReturnReasonCodes _returnReasonCodes;
        public string ordCnferr = "This line is already confirmed.";
        public ReturnController(IUnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
            HomeService home = new HomeService(_unitOfWork);

            BasketService basket = new BasketService(_unitOfWork);
            ReturnService returns = new ReturnService(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            _basket = basket;
            _returns = returns;
            _home = home;
            StyleColorSize styleColorSize = new StyleColorSize(_unitOfWork);
            tblManPackOrders manPckOrders = new tblManPackOrders(_unitOfWork);
            tblManpackReturns manPckRtnOrders = new tblManpackReturns(_unitOfWork); ;
            tblSalesLines salesOrderLines = new tblSalesLines(_unitOfWork);
            DimFitCaption dimFitCap = new DimFitCaption(_unitOfWork);
            PickingSlipHeader pickHeader = new PickingSlipHeader(_unitOfWork);
            FskColour fskColor = new FskColour(_unitOfWork);
            Reasoncodes reason = new Reasoncodes(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            BusBusiness busBusiness = new BusBusiness(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            BusContact busContact = new BusContact(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            User user = new Data.models.RepositoryModels.User(_unitOfWork);
            CustomAssembly customAssembly = new CustomAssembly(_unitOfWork);
            Departments departments = new Departments(_unitOfWork);
            ViewPointsCard vuPointsCard = new ViewPointsCard(_unitOfWork);
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
            FskStyle fskStyle = new FskStyle(_unitOfWork);
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
            UcodeByFreeTextView ucodeByFreetext = new UcodeByFreeTextView(_unitOfWork);
            CUstomerOrderTemplateCostcenters costCenter = new CUstomerOrderTemplateCostcenters(_unitOfWork);
            PointStyle pointStyle = new PointStyle(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointsAdjustment pointsAdjustment = new PointsAdjustment(_unitOfWork);
            StyleByFreetextAndUcode styleByFreetextAndUcode = new StyleByFreetextAndUcode(_unitOfWork);
            EmployeeRollout empRollout = new EmployeeRollout(_unitOfWork);
            ReturnReasonCodes returnReasonCodes = new ReturnReasonCodes(_unitOfWork);
            _pointsByUcode = pointsByUcode;
            _pointsAdjustment = pointsAdjustment;
            _pointStyle = pointStyle;
            _pointsCard = pointsCard;
            _ucodeByFreetext = ucodeByFreetext;
            _fskSetValues = fskSetValues;
            _fskStyle = fskStyle;
            _styleColorSize = styleColorSize;
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
            _salesOrderLines = salesOrderLines;
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
            _pickHeader = pickHeader;
            _returnReasonCodes = returnReasonCodes;
            _ucode_Description = ucode_Description;
            _ucodeByFreeText = ucodeByFreeText;
            _ucodeEmployees = ucodeEmployees;
            _ucodes = ucodes;
            _vuPointsCard = vuPointsCard;
            _styleByFreetextAndUcode = styleByFreetextAndUcode;
            _busAddress = busAddress;
            _styleSizePrice = styleSizePrice;
            _dp = dp;
            _busBusiness = busBusiness;
            _reason = reason;
            _fskColor = fskColor;
            _user = user;
            _empRollout = empRollout;
            _manPckOrders = manPckOrders;
            _manPckRtnOrders = manPckRtnOrders;
        }
        #endregion

        #region ReturnOrders

        public ActionResult GetAllOrders(string employeeId = "")
        {
            if (Session["PermissionLst"] != null)
            {
                var prmsn = (List<PermissionList>)Session["PermissionLst"];
                Session["pnlCarriageReason"] = prmsn.Where(s => s.ControlId == "pnlCarriageReason").First().Permission;
            }
            string busId = Session["BuisnessId"].ToString();
            if (employeeId != "")
            {
                if (Session["ReturnOrderHeader"] != null)
                {
                    //if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count() == 0)
                    //{
                    //    SetSalesOrderHeader(employeeId, busId);
                    //}
                    if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count() > 0)
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Any(s => s.EmployeeID == employeeId) == false)
                        {
                            Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                            Session["returnModellst"] = new List<ReturnOrderModel>();
                            if ((bool)Session["ISRTNEDITING"] == false)
                            {
                                Session["rtnLines"] = new List<ReturnOrderModel>();
                            }

                            SetSalesOrderHeader(employeeId, busId);



                        }
                    }
                    else if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count() == 0)
                    {
                        SetSalesOrderHeader(employeeId, busId);
                    }
                }
            }
            ViewData["pointsDiv"] = GetPointsDivReturns();
            return View("EditReturnOrder");
        }

        #region SetReturnOrderHeader
        public void SetSalesOrderHeader(string employeeId, string busId)
        {
            var salesHeadLst = new List<SalesOrderHeaderViewModel>();
            if (_salesOrderHeader.Exists(s => s.PinNo == employeeId))
            {
                var rtnHead = _salesOrderHeader.GetAll(s => s.PinNo == employeeId && s.OrderType == "SO" && s.ReasonCode==0).ToList().Select(ss => new SalesOrderHeaderViewModel
                {
                    CompanyID = ss.CompanyID,
                    CustomerName = _busBusiness.Exists(s => s.BusinessID == busId) ? _busBusiness.GetAll(s => s.BusinessID == busId).First().Name : "",
                    AddressId = _busAddress.Exists(s => s.Description == ss.DelDesc) ? _busAddress.GetAll(s => s.Description == ss.DelDesc).First().AddressID : 0,
                    DelDesc = ss.DelDesc,
                    OrderNo = ss.OrderNo,
                    DelAddress1 = ss.DelAddress1,
                    DelAddress2 = ss.DelAddress2,
                    DelAddress3 = ss.DelAddress3,
                    DelTown = ss.DelTown,
                    DelCity = ss.DelCity,
                    DelPostCode = ss.DelPostCode,
                    DelCountry = ss.DelCountry,
                    CustRef = ss.CustRef,
                    EmployeeID = ss.PinNo,
                    UCodeId = ss.UCodeId,
                    CustID = busId,
                    IsEditing = Session["ISRTNEDITING"] != null ? Convert.ToBoolean(Session["ISRTNEDITING"]) : false,
                    IsUcode = true,
                    IsTemplate = false,
                    NomCode3 = "",
                    UserID = Session["UserName"].ToString(),
                    WarehouseID = Session["WareHouseID"].ToString(),
                    Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                    Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                    RepID = Convert.ToInt32(Session["Rep_Id"]),
                    OrderType = Session["OrderType"].ToString(),
                    OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    Returnlines = new List<ReturnOrderModel>(),
                    Returnheader = true
                }).First();
                var reOrdHead = _salesOrderHeader.GetAll(s => s.PinNo == employeeId && s.OrderType == "SO").ToList().Select(ss => new SalesOrderHeaderViewModel
                {
                    CustomerName = _busBusiness.Exists(s => s.BusinessID == busId) ? _busBusiness.GetAll(s => s.BusinessID == busId).First().Name : "",
                    AddressId = _busAddress.Exists(s => s.Description == ss.DelDesc) ? _busAddress.GetAll(s => s.Description == ss.DelDesc).First().AddressID : 0,
                    DelDesc = ss.DelDesc,
                    OrderNo = ss.OrderNo,
                    CompanyID = ss.CompanyID,
                    DelAddress1 = ss.DelAddress1,
                    DelAddress2 = ss.DelAddress2,
                    DelAddress3 = ss.DelAddress3,
                    DelTown = ss.DelTown,
                    DelCity = ss.DelCity,
                    DelPostCode = ss.DelPostCode,
                    DelCountry = ss.DelCountry,
                    CustRef = ss.CustRef,
                    EmployeeID = ss.PinNo,
                    IsEditing = Session["ISRTNEDITING"] != null ? Convert.ToBoolean(Session["ISRTNEDITING"]) : false,
                    UCodeId = ss.UCodeId,
                    CustID = busId,
                    IsUcode = true,
                    IsTemplate = false,
                    NomCode3 = "",
                    UserID = Session["UserName"].ToString(),
                    WarehouseID = Session["WareHouseID"].ToString(),
                    Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                    Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                    RepID = Convert.ToInt32(Session["Rep_Id"]),
                    OrderType = Session["OrderType"].ToString(),
                    OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    Returnlines = new List<ReturnOrderModel>(),
                    Reorderheader = true
                }).First();

                var custref = _salesOrderHeader.Exists(s => s.PinNo == employeeId) ? _salesOrderHeader.GetAll(s => s.PinNo == employeeId).First().CustRef : "";
                var empName = _employee.Exists(s => s.EmployeeID == employeeId) ? _employee.GetAll(s => s.EmployeeID == employeeId).First().Forename + "  " + _employee.GetAll(s => s.EmployeeID == employeeId).First().Surname : "";
                Session["rtnempid"] = employeeId;
                Session["rtnempname"] = empName;
                Session["CustRef"] = custref;
                salesHeadLst.Add(rtnHead);
                salesHeadLst.Add(reOrdHead);
                if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                {
                    var frshReord = _salesOrderHeader.GetAll(s => s.PinNo == employeeId && s.OrderType == "SO").ToList().Select(ss => new SalesOrderHeaderViewModel
                    {
                        CustomerName = _busBusiness.Exists(s => s.BusinessID == busId) ? _busBusiness.GetAll(s => s.BusinessID == busId).First().Name : "",
                        AddressId = _busAddress.Exists(s => s.Description == ss.DelDesc) ? _busAddress.GetAll(s => s.Description == ss.DelDesc).First().AddressID : 0,
                        DelDesc = ss.DelDesc,
                        OrderNo = ss.OrderNo,
                        CompanyID = ss.CompanyID,
                        DelAddress1 = ss.DelAddress1,
                        DelAddress2 = ss.DelAddress2,
                        DelAddress3 = ss.DelAddress3,
                        DelTown = ss.DelTown,
                        DelCity = ss.DelCity,
                        DelPostCode = ss.DelPostCode,
                        DelCountry = ss.DelCountry,
                        CustRef = ss.CustRef,
                        EmployeeID = ss.PinNo,
                        IsEditing = false,
                        UCodeId = ss.UCodeId,
                        CustID = busId,
                        IsUcode = true,
                        IsTemplate = false,
                        NomCode3 = "",
                        UserID = Session["UserName"].ToString(),
                        WarehouseID = Session["WareHouseID"].ToString(),
                        Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                        Currency_Exchange_Code = Session["Currency_Name"].ToString(),
                        RepID = Convert.ToInt32(Session["Rep_Id"]),
                        OrderType = Session["OrderType"].ToString(),
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        Returnlines = new List<ReturnOrderModel>(),
                        Reorderheader = true
                    }).First();
                    salesHeadLst.Add(frshReord);
                }
                salesHeadLst.ForEach(s => s.EmployeeName = empName);
                Session["ReturnOrderHeader"] = salesHeadLst;
            }
        }
        #endregion
        public bool ChangeCollectionSts()
        {
            Session["Collection"] = 2;
            return true;
        }

        [ValidateInput(false)]
        public ActionResult EditReturnOrderGridviewPartial(string empid, List<string> catogry, int orderno = 0, string custRef = "", string courierRef = "", int pickingSlipNo = 0, bool iscallback = false)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = new List<ReturnOrderModel>();
            var existingRtn = new List<ReturnOrderModel>();

            if (iscallback == false)
            {
                Session["rtnempid"] = empid;
            }
            else if (Session["rtnempid"] != null)
            {
                empid = Session["rtnempid"].ToString();
            }
            existingRtn = GetExistingRtns(empid);
            if (Session["returnModellst"] != null)
            {
                if (((List<ReturnOrderModel>)Session["returnModellst"]).Count > 0)
                {
                    model = ((List<ReturnOrderModel>)Session["returnModellst"]);
                }
                else
                {
                    string empName = Session["rtnempname"] != null ? Session["rtnempname"].ToString() : "";
                    model = getreturnordermodel(empid, catogry, orderno, custRef, courierRef, pickingSlipNo, empName);
                }
            }
            else
            {
                var empName = _employee.Exists(s => s.EmployeeID == empid) ? _employee.GetAll(s => s.EmployeeID == empid).First().Forename + "  " + _employee.GetAll(s => s.EmployeeID == empid).First().Surname : "";
                model = getreturnordermodel(empid, catogry, orderno, custRef, courierRef, pickingSlipNo, empName);
            }
            if (Convert.ToBoolean(Session["ISRTNEDITING"]))
            {
                foreach (var lines in existingRtn)
                {
                    if (model.Any(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo))
                    {
                        var testM = model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList();
                        var returnValue = existingRtn.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).Sum(s => s.OrgRetOrdQty);
                        model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.Reason = lines.Reason);
                        model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.IsRetEdit = lines.IsRetEdit);
                        model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.IsDleted = lines.IsDleted);
                        // model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.OrgRetOrdQty = lines.OrgRetOrdQty);
                        //model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.OrgRetOrdQty = returnValue);
                        // model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.OtherReturnQty = lines.OtherReturnQty);
                        bool value = model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).Any(s => s.OrgOrdQty == s.OrgRetOrdQty && s.IsDleted == 0) == false ? false
                            : true;
                        model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.IsSelect = value);

                    }
                }
                //  model.Where(s => s.OrgOrdQty != s.OrgRetOrdQty).ToList().ForEach(s => s.IsSelect = false);
            }
            else
            {
                var rtnsLst = Session["rtnLines"] != null ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList() : new List<ReturnOrderModel>();
                foreach (var lines in existingRtn)
                {
                    if (model.Any(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo))
                    {
                        var testM = model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList();
                        var val1 = rtnsLst.Any(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo) ? rtnsLst.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).First().OrdQty : 0;
                        var val2 = rtnsLst.Any(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo) ? rtnsLst.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).First().OrgRetOrdQty : 0;
                        var cartValue = rtnsLst.Any(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo) ? (rtnsLst.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).First().OrdQty + rtnsLst.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).First().OrgRetOrdQty) == rtnsLst.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).First().OrgOrdQty ? true : false : false;
                        bool value = model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).Any(s => s.OrgOrdQty == s.OrgRetOrdQty && s.IsDleted == 0) == false & cartValue == false ? false
                            : true;
                        model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.IsSelect = value);
                        model.Where(s => s.OrderNo == lines.OrderNo && s.LineNo == lines.LineNo).ToList().ForEach(st => st.Reason = lines.Reason);

                    }
                }

            }
            var rtnLst = Session["rtnLines"] != null ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList() : new List<ReturnOrderModel>();
            if (rtnLst.Count > 0)
            {
                foreach (var items in rtnLst.Where(s => s.IsReturn && s.IsDleted == 0))
                {
                    if (model.Any(s => s.LineNo == items.LineNo && s.OrderNo == items.OrderNo))
                    {
                        var Val1 = model.Where(s => s.LineNo == items.LineNo && s.OrderNo == items.OrderNo).First().OrgOrdQty;
                        var Val2 = model.Where(s => s.LineNo == items.LineNo && s.OrderNo == items.OrderNo).First().OrgRetOrdQty;
                        var Val3 = items.IsRetEdit ? 0 : items.OrdQty;
                        var Val4 = Val3 + Val2;
                        if (Val4 < Val1)
                        {
                            model.Where(s => s.LineNo == items.LineNo && s.OrderNo == items.OrderNo).First().IsSelect = false;
                        }
                        else
                        {
                            model.Where(s => s.LineNo == items.LineNo && s.OrderNo == items.OrderNo).First().IsSelect = true;
                        }
                    }
                }
            }
            foreach (var data1 in model)
            {
                //GetlineVat(dat.OrdQty, dat.Price, dat.VatPercent)
                if (data1.StyleImage != null)
                {
                    if (data1.StyleImage.Contains(":"))
                    {

                        var data = data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1);
                        if (System.IO.File.Exists(appPath + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1)) != true)
                        {
                            data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                        }
                        else
                        {
                            data1.StyleImage = Url.Content("~/" + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1));
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                        {
                            data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                        }
                        else
                        {
                            data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                        }
                    }
                }
                else
                {
                    data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                }

            }
            //else
            //{
            //    model.Where(s => s.OrgRetOrdQty == s.OrgOrdQty).ToList().ForEach(s => s.IsSelect = true);
            //}
            Session["returnModellst"] = model;
            ViewData["gridPageSize"] = model.Count();

            return PartialView("_EditReturnOrderGridviewPartial", model);
        }

        #endregion

        #region getreturnordermodel

        public List<ReturnOrderModel> getreturnordermodel(string empid, List<string> catogry, int orderno, string custRef, string courierRef, int pickingSlipNo, string empName)
        {
            var result = new List<ReturnOrderModel>();
            result = _returns.GetOrderToReturn(empid, Session["BuisnessId"].ToString(), Session["UserName"].ToString(), Session["OrderPermit"].ToString(), Session["Access"].ToString(), Convert.ToBoolean(Session["POINTSREQ"]), catogry, orderno, custRef, courierRef, pickingSlipNo);
            result.ForEach(s => s.Employeename = empName);

            result.ForEach(s => s.VAT = _dataConnection.GetlineVat(s.OrdQty, s.Price, _dataConnection.GetVatPercent(s.StyleId, s.SizeId)));
            result.ForEach(s => s.StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(s.StyleId)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(s.StyleId)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"));
            return result;
        }


        #endregion

        #region GetExistingRtns()
        public List<ReturnOrderModel> GetExistingRtns(string empId)
        {
            List<ReturnOrderModel> lst = new List<ReturnOrderModel>();
            string busId = Session["BuisnessId"].ToString();
            var rtnLst = Session["rtnLines"] != null ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList() : new List<ReturnOrderModel>();

            if (empId != "")
            {
                if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                {
                    if (_salesOrderHeader.Exists(s => s.PinNo == empId && s.CustID == busId && s.OrderType.ToLower() == "rt"))
                    {

                        foreach (var ordNo in _salesOrderHeader.GetAll(s => s.PinNo == empId && s.CustID == busId && s.OrderType.ToLower() == "rt").Select(s => s.OrderNo).ToList())
                        {
                            var sss = _salesOrderLines.GetAll(s => s.OrderNo == ordNo && s.OriginalOrderNo > 0).ToList();
                            lst.AddRange(_salesOrderLines.GetAll(s => s.OrderNo == ordNo && s.OriginalOrderNo > 0).ToList().Select(s => new ReturnOrderModel
                            {
                                OrderNo = Convert.ToInt32(s.OriginalOrderNo),
                                LineNo = Convert.ToInt32(s.OriginalLineNo),
                                Reason = _returnReasonCodes.GetAll(sa => sa.ReasonCode == s.ReasonCode).Distinct().First().Description,
                                OrgRetOrdQty = rtnLst.Count() > 0 ? rtnLst.Any(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID && sa.RtnOrderno == s.OrderNo && sa.ReturnLineNo == s.LineNo) ? rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID && sa.RtnOrderno == s.OrderNo && sa.ReturnLineNo == s.LineNo).Count() > 1 ? rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID && sa.RtnOrderno == s.OrderNo && sa.ReturnLineNo == s.LineNo).Last().OrgRetOrdQty : rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID && sa.RtnOrderno == s.OrderNo && sa.ReturnLineNo == s.LineNo).First().OrgRetOrdQty : Convert.ToInt32(s.OrdQty) : Convert.ToInt32(s.OrdQty),
                                IsSelect = rtnLst.Count() > 0 ? rtnLst.Any(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID) ? rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID).Count() > 1 ? rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID).Last().IsSelect : true : false : false,
                                IsRetEdit = rtnLst.Count() > 0 ? rtnLst.Any(sa => sa.IsRetEdit && sa.StyleId == s.StyleID && sa.ReturnLineNo == s.LineNo && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID) ? true : false : false,
                                IsDleted = rtnLst.Count() > 0 ? rtnLst.Any(sa => sa.StyleId == s.StyleID && sa.RtnOrderno == s.OrderNo && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID) ? rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.RtnOrderno == s.OrderNo && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID).Count() > 1 ? rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID && sa.RtnOrderno == s.OrderNo).Last().IsDleted : rtnLst.Where(sa => sa.StyleId == s.StyleID && sa.SizeId == s.SizeID && sa.ColourId == s.ColourID && sa.RtnOrderno == s.OrderNo).First().IsDleted : 0 : 0,
                            }).ToList());
                        }
                    }

                }
                else if (_salesOrderHeader.Exists(s => s.PinNo == empId && s.CustID == busId && s.OrderType.ToLower() == "rt"))
                {
                    foreach (var ordNo in _salesOrderHeader.GetAll(s => s.PinNo == empId && s.CustID == busId && s.OrderType.ToLower() == "rt").Select(s => s.OrderNo).ToList())
                    {
                        lst.AddRange(_salesOrderLines.GetAll(s => s.OrderNo == ordNo && s.OriginalOrderNo > 0).ToList().Select(s => new ReturnOrderModel
                        {
                            OrderNo = Convert.ToInt32(s.OriginalOrderNo),
                            LineNo = Convert.ToInt32(s.OriginalLineNo),
                            Reason = _returnReasonCodes.GetAll(sa => sa.ReasonCode == s.ReasonCode).Distinct().First().Description,
                            OrgRetOrdQty = Convert.ToInt32(s.OrdQty)

                        }).ToList());
                    }
                }
            }

            if (Convert.ToBoolean(Session["ISRTNEDITING"]))
            {

            }
            return lst;
        }
        #endregion

        #region SelectedReturnOrderLines

        public string SelectedReturnOrderLines(List<ReturnOrderModel> rtnLines)
        {
            string result = "";
            string busId = Session["BuisnessId"].ToString();
            var thisReturn = (List<ReturnOrderModel>)Session["returnModellst"];
            int lineno = Session["rtnLines"] == null ? 1 : ((List<ReturnOrderModel>)Session["rtnLines"]).Count() == 0 ? 1 : ((List<ReturnOrderModel>)Session["rtnLines"]).Max(s => s.ReturnLineNo) + 1;


            if (rtnLines.Count > 0)
            {
                foreach (var line in rtnLines)
                {
                    //if (((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.IsReturn && s.IsDleted == 1 && s.LineNo == line.LineNo))
                    //{
                    //    var test = ((List<ReturnOrderModel>)Session["rtnLines"]);
                    //    ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn && s.LineNo == line.LineNo).First().IsDleted = 0;
                    //    ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn && s.LineNo == line.LineNo).First().OrdQty = ((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.IsReturn && s.LineNo == line.LineNo) ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn && s.LineNo == line.LineNo).Sum(s => s.OrdQty) + line.OrdQty : line.OrdQty;
                    //}

                    if (thisReturn.Any(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo))
                    {
                        var sss = thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).First();
                        thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).First().IsSelect = true;
                        thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).First().Reason = line.Reason;
                        //  thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).First().RtnQty = line.RtnQty;
                        thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).First().RtnQty = thisReturn.Any(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo) ? thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).Sum(s => s.RtnQty) + line.RtnQty : line.RtnQty;
                        if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                        {
                            thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).First().OrgRetOrdQty = thisReturn.Any(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo) ? thisReturn.Where(s => s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.LineNo == line.LineNo).Sum(s => s.OrgRetOrdQty) + line.RtnQty : line.RtnQty;
                        }
                    }
                    var reason = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Reason : "";
                    line.IsReturn = true;
                    if ((bool)Session["ISRTNEDITING"])
                    {
                        line.RtnOrderno = ((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.IsReturn) ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).First().RtnOrderno : 0;

                    }
                    line.InvFlag = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().InvFlag : "";
                    line.ReturnLineNo = lineno;
                    line.CustRef = Session["CustRef"].ToString();
                    line.OrderNo = line.OrderNo;
                    line.Description = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Description : "";
                    line.Employeename = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Employeename : "";
                    line.ReasonCode = _returnReasonCodes.Exists(s => s.CompanyID == cmpId && s.Description.Contains(reason)) ? Convert.ToInt32(_returnReasonCodes.GetAll(s => s.CompanyID == cmpId && s.Description.Contains(reason)).First().ReasonCode) : 0;
                    line.RepId = Convert.ToInt32(Session["Rep_Id"].ToString());
                    line.IsSelect = true;
                    line.StockingUOM1 = 1;
                    line.Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]);
                    line.IssueQty1 = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().RtnQty : 0;
                    line.Cost1 = _dataConnection.GetCostPrice(line.StyleId, line.SizeId, line.ColourId, Session["Currency_Name"].ToString(), 1, 0);
                    line.Description = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Description : "";
                    line.Points = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Points : 0;
                    line.TotalPoints = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Points * line.RtnQty : 0;

                    line.OrgRetOrdQty = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().OrgRetOrdQty : 0;
                    line.Emp = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Emp : "";
                    line.DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]), Convert.ToBoolean(Session["IncWendsDel"]));
                    line.IssueUOM1 = 1;
                    line.OrdQty = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().RtnQty : 0;
                    line.OrgOrdQty = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().OrgOrdQty : 0;
                    line.Price = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Price : 0;
                    line.VatPercent = _dataConnection.GetVatPercent(line.StyleId, line.SizeId);
                    line.VAT = _dataConnection.GetlineVat(Convert.ToInt32(line.OrdQty), Convert.ToDouble(line.Price), _dataConnection.GetVatPercent(line.StyleId, line.SizeId));
                    line.VatCode1 = _dataConnection.GetVatCode();
                    line.Total = _dataConnection.GetlineTotals(Convert.ToDouble(line.OrdQty), Convert.ToDouble(line.Price), _dataConnection.GetVatPercent(line.StyleId, line.SizeId));
                    line.Ucode = thisReturn.Any(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId) ? thisReturn.Where(s => s.LineNo == line.LineNo && s.OrderNo == line.OrderNo && s.StyleId == line.StyleId && s.ColourId == line.ColourId && s.SizeId == line.SizeId).First().Ucode : "";
                    line.StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(line.StyleId)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(line.StyleId)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png");
                    lineno = lineno + 1;
                }
                if (Session["rtnLines"] == null)
                {
                    Session["rtnLines"] = rtnLines;
                }
                else
                {
                    foreach (var line in rtnLines)
                    {
                        if (((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0))
                        {
                            var qty = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().OrdQty + line.RtnQty;
                            ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().VatPercent = _dataConnection.GetVatPercent(line.StyleId, line.SizeId);
                            ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().VAT = _dataConnection.GetlineVat(Convert.ToInt32(qty), Convert.ToDouble(line.Price), _dataConnection.GetVatPercent(line.StyleId, line.SizeId));
                            ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().VatCode1 = _dataConnection.GetVatCode();
                            ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().Total = _dataConnection.GetlineTotals(Convert.ToDouble(qty), Convert.ToDouble(line.Price), _dataConnection.GetVatPercent(line.StyleId, line.SizeId));
                            ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().TotalPoints = qty * line.Points;

                            ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().OrdQty = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == line.OrderNo && s.LineNo == line.LineNo && s.ColourId == line.ColourId && s.SizeId == line.SizeId && s.IsDleted == 0).First().OrdQty + line.RtnQty;


                        }
                        else
                        {
                            ((List<ReturnOrderModel>)Session["rtnLines"]).Add(line);
                        }
                    }
                }
                Session["returnModellst"] = thisReturn;
                result = "/Return/ReturnReorder/";
            }
            return result;
        }
        #endregion

        #region ReturnReorder
        public ActionResult ReturnReorder(int ordeNo = 0)
        {
            Session["returnorder"] = true;
            var userName = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var busId = System.Web.HttpContext.Current.Session["BuisnessId"].ToString();
            var budgetReq = System.Web.HttpContext.Current.Session["BUDGETREQ"].ToString();
            var carrier = FillCarrierStyle();
            var access = System.Web.HttpContext.Current.Session["Access"].ToString();
            var orderPermit = System.Web.HttpContext.Current.Session["OrderPermit"].ToString();

            if (ordeNo > 0)
            {
                SetReturnOrderlines(ordeNo);
                ViewData["carrierStyleFill"] = carrier;
                var model = Session["rtnLines"] == null ? new List<ReturnOrderModel>() : ((List<ReturnOrderModel>)Session["rtnLines"]).Count > 0 ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList() : new List<ReturnOrderModel>();

                var model1 = Session["rtnLines"] == null ? new List<ReturnOrderModel>() : ((List<ReturnOrderModel>)Session["rtnLines"]).Count > 0 ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).ToList() : new List<ReturnOrderModel>();
                double carriage = 0.0;
                var tot = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, true, model);
                var Rrttot = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, true, model1);
                ViewBag.VatPercent = tot.vatSpan;
                ViewBag.carriage = tot.carriage;
                ViewBag.ordeTotal = tot.ordeTotal;
                ViewBag.totalVat = tot.totalVat;
                ViewBag.Total = tot.Total;
                ViewBag.GrossTotal = tot.gross;
                ViewBag.ReOrdVatPercent = Rrttot.vatSpan;
                ViewBag.ReOrdcarriage = Rrttot.carriage;
                ViewBag.ReOrdordeTotal = Rrttot.ordeTotal;
                ViewBag.ReOrdtotalVat = Rrttot.totalVat;
                ViewBag.ReOrdTotal = Rrttot.Total;
                ViewBag.ReOrdGrossTotal = Rrttot.gross;
                TempData["PointsDivRtn"] = GetPointsDivReturns();
            }
            else
            {
                Session["carrStyle"] = carrier;
                ViewData["carrierStyleFill"] = carrier;

                var model = Session["rtnLines"] == null ? new List<ReturnOrderModel>() : ((List<ReturnOrderModel>)Session["rtnLines"]).Count > 0 ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList() : new List<ReturnOrderModel>();

                var model1 = Session["rtnLines"] == null ? new List<ReturnOrderModel>() : ((List<ReturnOrderModel>)Session["rtnLines"]).Count > 0 ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).ToList() : new List<ReturnOrderModel>();
                TempData["PointsDivRtn"] = GetPointsDivReturns();
                double carriage = 0.0;
                var tot = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, false, model);
                var Rrttot = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, false, model1);

                ViewBag.VatPercent = tot.vatSpan;
                ViewBag.carriage = tot.carriage;
                ViewBag.ordeTotal = tot.ordeTotal;
                ViewBag.totalVat = tot.totalVat;
                ViewBag.Total = tot.Total;
                ViewBag.GrossTotal = tot.gross;
                ViewBag.ReOrdVatPercent = Rrttot.vatSpan;
                ViewBag.ReOrdcarriage = Rrttot.carriage;
                ViewBag.ReOrdordeTotal = Rrttot.ordeTotal;
                ViewBag.ReOrdtotalVat = Rrttot.totalVat;
                ViewBag.ReOrdTotal = Rrttot.Total;
                ViewBag.ReOrdGrossTotal = Rrttot.gross;
            }
            var modele = Session["ReturnOrderHeader"] != null ? ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count > 0 ? ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(s => s.Reorderheader).First() : new SalesOrderHeaderViewModel() : new SalesOrderHeaderViewModel();
            Session["DeliveryAddress"] = _dp.FillCombo_CustomerDelivery(busId, access, orderPermit, userName, true, Session["rtnempid"].ToString());

            Session["cboDelAddress"] = modele.DelDesc != null && modele.DelDesc != "" ? ((List<Maximus.Data.Models.BusAddress1>)Session["DeliveryAddress"]).Any(s => s.AddressDescription == modele.DelDesc) ? ((List<Maximus.Data.Models.BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressDescription == modele.DelDesc).First().AddressId : 0 : 0;
            return View();
        }
        #endregion



        [ValidateInput(false)]
        public ActionResult ReturnReorderGridviewPartial()
        {
            var model = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder == false && s.IsDleted == 0).ToList();
            return PartialView("_ReturnReorderGridviewPartial", model);
        }

        public ActionResult GetReOrderProducts(string style, string[] styleNameArr)
        {
           
            int orderNO = styleNameArr[1] != "" ? Convert.ToInt32(styleNameArr[1]) : 0;
            int LineNo = styleNameArr[2] != "" ? Convert.ToInt32(styleNameArr[2]) : 0;
            var model = Session["rtnLines"] != null ? ((List<ReturnOrderModel>)Session["rtnLines"]) : new List<ReturnOrderModel>();
            string busId = Session["BuisnessId"].ToString();
            Session["SelectedEmp"] = model.First().Emp;
            Session["SelectedUcode"] = model.First().Ucode;
            Session["selectedUcodes"] = model.First().Ucode;
            Session["selectedRetLine"] = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.OrderNo == orderNO && s.LineNo == LineNo).First();
            var ucodStylesLst =   _dp.UcodeStyles(model.First().Ucode, Session["BuisnessId"].ToString())  ;
            string ucode = model.First().Ucode;
            string emp = model.First().Emp;
            if (((List<string>)Session["SelectedTemplates"]).Count == 0)
            {
                Session["StyleFreeText"] = _fskStyleFreetext.GetAll().ToList();
                Session["StyleByFreetext"] = _styleByFreetext.GetAll().ToList();
                Session["Pointsmodel"] = _home.GetPointsModel(ucode, busId);
                Session["PointsAdjustment"] = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).ToList();
                Session["PointsCard"] = _vuPointsCard.GetAll(s => s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)).ToList();
                Session["PointsStyle"] = _pointStyle.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).ToList();
                Session["PointsUcode"] = _pointsByUcode.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).ToList();
            }

            var freeText = "";
            var fitFreeText = _fskStyleFreetext.Exists(s => s.StyleId == style & s.FreeTextType.ToLower() == "fitalloc") ? _fskStyleFreetext.GetAll(s => s.StyleId == style & s.FreeTextType.ToLower() == "fitalloc").First().FreeText : "";
            var fitStyles = _fskStyleFreetext.Exists(s => s.FreeText == fitFreeText & s.FreeTextType.ToLower() == "fitalloc") ? _fskStyleFreetext.GetAll(s => s.FreeText == fitFreeText & s.FreeTextType.ToLower() == "fitalloc").Select(s => s.StyleId).ToList() : new List<string>();
            if (fitStyles.Count > 0)
            {
                freeText = _fskStyleFreetext.Exists(s => fitStyles.Contains(s.StyleId) & s.FreeTextType.ToLower() == "dimalloc") ? _fskStyleFreetext.GetAll(s => fitStyles.Contains(s.StyleId) & s.FreeTextType.ToLower() == "dimalloc").First().FreeText : "";
            }
            else
            {
                freeText = _fskStyleFreetext.Exists(s => s.StyleId == style & s.FreeTextType.ToLower() == "dimalloc") ? _fskStyleFreetext.GetAll(s => s.StyleId == style & s.FreeTextType.ToLower() == "dimalloc").First().FreeText : "";
            }
            var model1 = _ucodeByFreetext.GetAll(s => s.UCodeID == ucode).ToList().Where(x => (x.DimFreeText == freeText || x.FreeText == freeText) & x.UCodeID == ucode).Select(x => new styleViewmodel
            {
                StyleID = x.StyleID,
                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false & d.CustID == busId) | _allAssemblies.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false) ? 1 : 0,
                isAllocated = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                Dimensions = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                SeqNO = x.SeqNo.Value,
                Freetext = x.FreeText,
                OriginalStyleid = x.StyleID
            }).ToList();
            return PartialView("_PopReorderPartial", model1.Distinct());
        }
        #region 

        public bool checksizeexists(string style,string size)
        {
            if (Session["rtnLines"] != null)
            {
                if (((List<ReturnOrderModel>)Session["rtnLines"]).Count() > 0)
                {
                    var sss = ((List<ReturnOrderModel>)Session["rtnLines"]);
                    var lineNo = ((ReturnOrderModel)Session["selectedRetLine"]).ReturnLineNo;
                    if (((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.StyleId == style && s.SizeId == size && s.IsReturn))
                    {
                        if (((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.StyleId == style && s.SizeId == size && s.IsReturn).First().LineNo == lineNo)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        public JsonResult AddToCardReturnLines(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "", string orgStyl = "", string entQty = "", string reqData1 = "", string reason = "", string QtySizePriceArr = "", string selectedSitecode = "")
        {
            var result = "";
            if (description != "" && price != "" && size != "" && color != "" && qty != "" && style != "" && orgStyl != "")
            {
                if (checksizeexists(style,size))
                {
                    result = "size validation";
                }
                else
                {
                    string busId = Session["BuisnessId"].ToString();
                    var lineNo = ((ReturnOrderModel)Session["selectedRetLine"]).LineNo;

                    var emp = ((ReturnOrderModel)Session["selectedRetLine"]).Emp;
                    var empName = ((ReturnOrderModel)Session["selectedRetLine"]).Employeename;
                    var ucode = ((ReturnOrderModel)Session["selectedRetLine"]).Ucode;
                    var stylPoints = _pointStyle.Exists(s => s.StyleID.Trim().ToLower() == style.Trim().ToLower() && s.UcodeID.Trim() == ucode.Trim()) ? _pointStyle.GetAll(s => s.StyleID.Trim().ToLower() == style.Trim().ToLower() && s.UcodeID.Trim() == ucode.Trim()).First().Points.Value : 0;
                    var totalPts = (stylPoints) * Convert.ToInt32(qty);
                    int reLineNo = ((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.IsReorder) ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).Max(s => s.ReOrderLineNo) + 1 : 1;
                    var returnOrderLines = new ReturnOrderModel();
                    try
                    {
                        returnOrderLines.ReOrderLineNo = reLineNo;
                        returnOrderLines.Employeename = empName;
                        returnOrderLines.OrderNo = ((ReturnOrderModel)Session["selectedRetLine"]).OrderNo;
                        //if ((bool)Session["ISRTNEDITING"])
                        //{
                        //    returnOrderLines.ReOrderno = ((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.IsReorder) ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).First().ReOrderno : 0;
                        //}
                        returnOrderLines.IsReorder = true;
                        returnOrderLines.ColourId = color;
                        returnOrderLines.Points = stylPoints;
                        returnOrderLines.LineNo = lineNo;
                        returnOrderLines.ReturnLineNo = ((ReturnOrderModel)Session["selectedRetLine"]).ReturnLineNo;
                        returnOrderLines.Description = description.Trim();
                        returnOrderLines.OrdQty = Convert.ToInt32(qty);
                        returnOrderLines.Price = Convert.ToDouble(price) == 0 ? Convert.ToDouble(GetPrice(style, size)) : Convert.ToDouble(price);
                        returnOrderLines.SizeId = size;
                        returnOrderLines.StyleId = style;
                        returnOrderLines.Emp = emp;
                        returnOrderLines.CustRef = Session["CustRef"].ToString();
                        returnOrderLines.VAT = _dataConnection.GetlineVat(Convert.ToInt32(qty), Convert.ToDouble(price), _dataConnection.GetVatPercent(style, size));
                        returnOrderLines.TotalPoints = totalPts;
                        returnOrderLines.RepId = Convert.ToInt32(Session["Rep_Id"].ToString());
                        returnOrderLines.StockingUOM1 = 1;
                        returnOrderLines.Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]);
                        returnOrderLines.IssueQty1 = Convert.ToInt32(qty);
                        returnOrderLines.StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png");
                        returnOrderLines.OrgStyle = orgStyl;
                        returnOrderLines.VatPercent = _dataConnection.GetVatPercent(style, size);
                        returnOrderLines.Total = _dataConnection.GetlineTotals(Convert.ToDouble(qty), Convert.ToDouble(price), _dataConnection.GetVatPercent(style, size));
                        returnOrderLines.FreeText1 = reqData1;
                        returnOrderLines.DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"]));
                        returnOrderLines.VatCode1 = _dataConnection.GetVatCode();
                        returnOrderLines.RepId = Convert.ToInt32(Session["Rep_Id"].ToString());
                        returnOrderLines.Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]);
                        returnOrderLines.Cost1 = _dataConnection.GetCostPrice(style, size, color, Session["Currency_Name"].ToString(), 1, 0);
                        returnOrderLines.DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]), Convert.ToBoolean(Session["IncWendsDel"]));
                        returnOrderLines.IssueUOM1 = 1;
                        returnOrderLines.IssueQty1 = Convert.ToInt32(qty);
                        returnOrderLines.StockingUOM1 = 1;
                        returnOrderLines.SOPDetail4 = reason;
                        returnOrderLines.SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "";
                        returnOrderLines.ReasonCode = 0;
                        ((List<ReturnOrderModel>)Session["rtnLines"]).Add(returnOrderLines);
                        result = "Success";
                    }
                    catch (Exception e)
                    {

                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #region GetPrice based on styleid and colorid
        public decimal GetPrice(string StyleID = "", string SizeId = "")
        {
            if (Session["PriceList"] != null)
            {
                return _home.GetPrice(StyleID, SizeId.Trim(), Session["BuisnessId"].ToString(), Session["PriceList"].ToString());
            }
            else
            {
                return _home.GetPrice(StyleID, SizeId.Trim(), Session["BuisnessId"].ToString(), "");
            }
        }
        #endregion

        public ActionResult ReorderGridviewPartial()
        {
            var model = ((List<ReturnOrderModel>)Session["rtnLines"]).Any(s => s.IsReorder) ? ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder && s.IsDleted == 0).ToList() : new List<ReturnOrderModel>();
            return PartialView("_ReorderGridviewPartial", model);
        }

        public string GetBtnStatusReturns(string style, string qty, int lineno = 0, bool isReordEdt = false)
        {
          
            var result = "";
            if (style != "" && qty != "")
            {
                if (Session["OverrideEnt"].ToString().ToLower().Trim() != "show")
                {
                    if (Convert.ToBoolean(Session["POINTSREQ"]))
                    {
                        int availPts = 0;
                        var emp = (((List<ReturnOrderModel>)Session["rtnLines"])).First().Emp;
                        var ucode = (((List<ReturnOrderModel>)Session["rtnLines"])).First().Ucode;
                        var ucodStylesLst =  _dp.UcodeStyles(ucode, Session["BuisnessId"].ToString())  ;
                        string busId = Session["BuisnessId"].ToString();
                        int totalPts = _pointsByUcode.Exists(s => s.BusinessID == busId && s.UcodeID == ucode) ? _pointsByUcode.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).First().TotalPoints.Value : 0;
                        int cardPts = _vuPointsCard.Exists(s => s.BusinessID == busId && s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)).Sum(s => s.TOTSOPOINTS).Value) : 0;
                        int thisPts = _pointStyle.Exists(s => s.BusinessID == busId && s.UcodeID == ucode.Trim() && s.StyleID.Trim() == style.Trim()) ? _pointStyle.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode.Trim() && s.StyleID.Trim() == style.Trim()).First().Points.Value : 0;
                        int rtnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0).Sum(s => s.TotalPoints);
                        int reOrdPtsEd= isReordEdt ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderLineNo != lineno).Sum(s => s.TotalPoints) : (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderno == 0).Sum(s => s.TotalPoints);
                        int reOrdPts = isReordEdt ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderLineNo != lineno).Sum(s => s.TotalPoints) : (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderno != 0).Sum(s => s.TotalPoints);
                        int thisTotPts = Convert.ToInt32(qty) * thisPts;
                        if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                        {
                            int thisRTnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReturn && s.IsDleted == 0 && s.IsRetEdit == false) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0 && s.IsRetEdit == false).Sum(s => s.TotalPoints) : 0;
                            availPts = totalPts - ((cardPts + reOrdPtsEd) - thisRTnPts);
                        }
                        else
                        {
                            availPts = totalPts - ((cardPts + reOrdPtsEd+ reOrdPts) - rtnPts);
                        }

                        var ss = (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0).ToList();
                        if (availPts >= thisTotPts)
                        {
                            result = "enabled";
                        }
                    }
                }
                else
                {
                    result = "enabled";
                }
            }
            return result;
        }

        public ActionResult ReturnReorderGridviewPartialDelete(ReturnOrderModel line)
        {
            var model = (((List<ReturnOrderModel>)Session["rtnLines"]));
            var frstRetModel = model.Any(s => s.ReturnLineNo == line.ReturnLineNo) ? model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First() : new ReturnOrderModel();
            if (frstRetModel.OrderNo > 0)
            {
                if (Convert.ToBoolean(Session["ISRTNEDITING"]) && frstRetModel.IsRetEdit)
                {

                    var thisReturn = (List<ReturnOrderModel>)Session["returnModellst"];
                    thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().IsDleted = 1;
                    thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().IsSelect = false;
                    thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().OrgRetOrdQty = thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().OrgRetOrdQty - frstRetModel.OrgRetOrdQty;
                    model.Where(s => s.ReturnLineNo == line.ReturnLineNo && s.IsReturn).First().IsDleted = 1;
                    model.Where(s => s.ReturnLineNo == line.ReturnLineNo && s.IsReturn).First().OrgRetOrdQty = 0;
                    model.Where(s => s.ReturnLineNo == line.ReturnLineNo && s.IsReturn).First().OrgOrdQty = 0;
                    model.Where(s => s.ReturnLineNo == line.ReturnLineNo && s.IsReturn).First().IsSelect = false;
                    if (model.Any(s => s.ReturnLineNo == frstRetModel.ReturnLineNo && s.IsReorder))
                    {
                        model.Where(s => s.ReturnLineNo == frstRetModel.ReturnLineNo && s.IsReorder).ToList().ForEach(sa => sa.IsDleted = 1);
                        model.Where(s => s.ReturnLineNo == frstRetModel.ReturnLineNo && s.IsReorder).ToList().ForEach(sa => sa.IsSelect = false);
                    }
                }
                else
                {
                    var frstReordModel = model.Any(s => s.ReturnLineNo == frstRetModel.ReturnLineNo && s.OrderNo == frstRetModel.OrderNo && s.LineNo == frstRetModel.LineNo && s.IsReorder) ? model.Where(s => s.ReturnLineNo == frstRetModel.ReturnLineNo && s.OrderNo == frstRetModel.OrderNo && s.LineNo == frstRetModel.LineNo && s.IsReorder).ToList() : new List<ReturnOrderModel>();
                    var thisReturn = (List<ReturnOrderModel>)Session["returnModellst"];
                    thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().Reason = "";
                    thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().IsSelect = false;
                    thisReturn.Where(s => s.StyleId == frstRetModel.StyleId && s.ColourId == frstRetModel.ColourId && s.SizeId == frstRetModel.SizeId && s.LineNo == frstRetModel.LineNo && s.OrderNo == frstRetModel.OrderNo).First().RtnQty = 0;
                    foreach (var mod in frstReordModel)
                    {
                        model.Remove(mod);
                    }
                    model.Remove(frstRetModel);
                }
            }
            Session["rtnLines"] = model;
            return PartialView("_ReturnReorderGridviewPartial", model.Where(s => s.IsReturn && s.IsDleted == 0).ToList());
        }
        public ActionResult ReturnReorderGridviewPartialUpdate(ReturnOrderModel line)
        {
            var model = (((List<ReturnOrderModel>)Session["rtnLines"]));
            if (model.Any(s => s.ReturnLineNo == line.ReturnLineNo))
            {
                model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().OrdQty = line.OrdQty;
                model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().OrgRetOrdQty = line.OrdQty;
                model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().IssueQty1 = line.OrdQty;
                model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().Reason = line.Reason;
                model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().TotalPoints = line.OrdQty * model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().Points;
                model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().Total = _dataConnection.GetlineTotals(Convert.ToDouble(line.OrdQty), Convert.ToDouble(model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().Price), _dataConnection.GetVatPercent(model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().StyleId, model.Where(s => s.ReturnLineNo == line.ReturnLineNo).First().SizeId));
            }
            return PartialView("_ReturnReorderGridviewPartial", model.Where(s => s.IsReturn && s.IsDleted == 0).ToList());
        }
        public ActionResult ReorderGridviewPartialUpdate(ReturnOrderModel line)
        {
            var model = (((List<ReturnOrderModel>)Session["rtnLines"]));
            if (model.Any(s => s.ReOrderLineNo == line.ReOrderLineNo))
            {
                string styleId = model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().StyleId;
                if (GetBtnStatusReturns(styleId, line.OrdQty.ToString(), line.ReOrderLineNo, true) != "")
                {
                    model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().OrdQty = line.OrdQty;
                    model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().IssueQty1 = line.OrdQty;
                    model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().TotalPoints = line.OrdQty * model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().Points;
                    model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().Total = _dataConnection.GetlineTotals(Convert.ToDouble(line.OrdQty), Convert.ToDouble(model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().Price), _dataConnection.GetVatPercent(model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().StyleId, model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().SizeId));
                }
                else
                {
                    ViewData["EditError1"] = "Ordered points values exceeds total points";
                }
            }
            return PartialView("_ReorderGridviewPartial", model.Where(s => s.IsReorder && s.IsDleted == 0).ToList());
        }
        public ActionResult ReorderGridviewPartialDelete(ReturnOrderModel line)
        {
            var model = (((List<ReturnOrderModel>)Session["rtnLines"]));
            var frstReOrdModel = model.Any(s => s.ReOrderLineNo == line.ReOrderLineNo) ? model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First() : new ReturnOrderModel();

            if (Convert.ToBoolean(Session["ISRTNEDITING"]) && frstReOrdModel.IsRetEdit)
            {

                if (frstReOrdModel.StyleId != "")
                {
                    if (model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().IsCnf == false)
                    {
                        model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().IsSelect = false;
                        model.Where(s => s.ReOrderLineNo == line.ReOrderLineNo).First().IsDleted = 1;
                    }
                    else
                    {
                        ViewData["EditError1"] = ordCnferr;
                    }
                }
            }
            else
            {
                if (frstReOrdModel.StyleId != "")
                {
                    model.Remove(frstReOrdModel);
                }
            }
            return PartialView("_ReorderGridviewPartial", model.Where(s => s.IsReorder && s.IsDleted == 0).ToList());
        }


        public bool ConvertRtnSalesHead()
        {
            if (Session["ReturnOrderHeader"] != null)
            {
                //if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count == 0 || (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Any(s => s.SalesOrderLine == null)))
                //{
                string empId = Session["rtnempid"] != null ? Session["rtnempid"].ToString() : "";
                var salesHead = (List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"];
                var salesRtnLines = getsalesLines(((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList(), true, salesHead.First().OrderNo);
                var salesReOrdnLines = getsalesLines(((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).ToList(), false, 0);
                salesHead.Where(s => s.EmployeeID == empId && s.Returnheader).First().SalesOrderLine = salesRtnLines;
                salesHead.Where(s => s.EmployeeID == empId && s.Returnheader).First().OrderNo = salesRtnLines.First().OrderNo;
                if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                {
                    if (salesReOrdnLines.Count > 0)
                    {

                        if (salesReOrdnLines.Any(s => s.OrderNo == 0 && s.Isedit == false))
                        {
                            salesHead.Where(s => s.EmployeeID == empId && s.Reorderheader && s.IsEditing == false).First().SalesOrderLine = salesReOrdnLines.Where(s => s.OrderNo == 0 && s.Isedit == false).ToList();
                        }
                        salesHead.Where(s => s.EmployeeID == empId && s.Reorderheader && s.IsEditing).First().SalesOrderLine = salesReOrdnLines.Where(s => s.OrderNo > 0 && s.Isedit).ToList();
                        salesHead.Where(s => s.EmployeeID == empId && s.Reorderheader && s.IsEditing).First().OrderNo = salesReOrdnLines.Any(s => s.OrderNo > 0 && s.Isedit) ? salesReOrdnLines.Where(s => s.OrderNo > 0 && s.Isedit).First().OrderNo : 0;
                    }
                }
                else
                {

                    salesHead.Where(s => s.EmployeeID == empId && s.Reorderheader).First().SalesOrderLine = salesReOrdnLines;
                    //salesHead.Where(s => s.EmployeeID == empId && s.Reorderheader).First().OrderNo = salesReOrdnLines.First().OrderNo;
                }
                //}
                return true;
            }
            return false;
        }


        #region CreateReturnOrder
        public JsonResult AcceptReturn()
        {
            AcceptResultSet result = new AcceptResultSet();
            if (((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsDleted == 0).Count() == 0)
            {
                result.type = "noelements";

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            ConvertRtnSalesHead();
            try
            {
                string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
                string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
                string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();
                string ueMailEMail = System.Configuration.ConfigurationManager.AppSettings["uemail/email"].ToString();
                bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
                var salesHead = ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(s => s.SalesOrderLine != null).ToList();
                var HTTP_X_FORWARDED_FOR = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                var REMOTE_ADDR = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                string Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
                bool isrollout = Convert.ToBoolean(Session["RolloutOrderEst"]);
                string RTN_Collection_Style = Session["RTN_Collection_Style"] != null ? Session["RTN_Collection_Style"].ToString() : "";
                string WAREHOUSE_RTN = Session["WAREHOUSE_RTN"].ToString();
                string custLogo = Session["LOGO"].ToString();
                string cmpLogo = System.Configuration.ConfigurationManager.AppSettings["cmpLogo"].ToString();
                string permissionPrice = Session["Price"].ToString();
                if (Session["selectedcar"] == null)
                {
                    Session["selectedcar"] = Session["Carrier"].ToString();
                }
                int empResetMnths = Session["EmployeeRenew"] != null ? Convert.ToInt32(Session["EmployeeRenew"].ToString()) : 0;
                result = _returns.AcceptReturns(ConnectionString, salesHead, cmpId, Convert.ToDouble(Session["CARRPERCENT"]), Session["CARRPRICE_RTN"].ToString(), Convert.ToBoolean(Session["DELADDR_USER_CREATE"]), Session["OverrideEnt"].ToString(), Session["CARRPRICE_XCHG"].ToString(), RTN_Collection_Style, Session["PriceList"].ToString(), Session["FITALLOC"].ToString(), Session["DIMALLOC"].ToString(), "", WAREHOUSE_RTN, Session["pnlCarriageReason"].ToString(), Session["selectedcar"].ToString(), IsManpack, empResetMnths, Browser, HTTP_X_FORWARDED_FOR, REMOTE_ADDR, isrollout, Session["UserName"].ToString(), false, Session["POINTSREQ"].ToString(), Session["ONLCUSREFLBL"].ToString(), cmpLogo, custLogo, adminMail, mailUsername, mailPassword, mailPort, mailServer, ueMailEMail, permissionPrice, Convert.ToInt32(Session["Collection"]));
                if (result.type == "CarrierPrompt")
                {
                    Session["pnlCarriageReason"] = "show";
                }
                if (result.type.ToLower() == "success")
                {
                    ResetSessions();
                }

            }
            catch (Exception e)
            {
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #region ResetSessions
        public void ResetSessions()
        {
            Session["qty"] = "0";
            Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
            Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
            Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
            Session["returnModellst"] = new List<ReturnOrderModel>();
            Session["rtnLines"] = new List<ReturnOrderModel>();
            //Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
        }
        #endregion

        public List<string> FillCarrierStyle()
        {
            var result = new List<string>();
            string busId = Session["BuisnessId"].ToString();
            result = _dataConnection.GetCarrierStyleCmbValue(busId);
            return result;
        }

        public string DeleteReturnOrders(int orderNo)
        {
            string result = "";
            if (orderNo > 0)
            {
                if (_salesOrderHeader.Exists(s => s.OrderNo == orderNo && s.OrderType == "RT"))
                {
                    result = _returns.DeleteReturnOrders(orderNo, Session["UserName"].ToString()) ? "Success" : "";
                }
            }
            return result;
        }

        public string InsertCarriageLine(string carrStyle)
        {
            string result = "";
            var carrierStyle = ((List<string>)Session["carrStyle"]);
            string thisEmp = Session["rtnempid"] != null ? Session["rtnempid"].ToString() : "";
            var testVal = ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]);
            int newLineNO = Convert.ToInt32(((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(x => x.EmployeeID == thisEmp && x.Returnheader).First().SalesOrderLine.Where(s => s.IsDleted == false).Last().LineNo + 1);
            var salesLines = ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(x => x.EmployeeID == thisEmp && x.Returnheader).First().SalesOrderLine.Where(s => s.IsDleted == false);
            if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Any(x => x.IsTemplate == false))
            {
                if (salesLines.Any(x => carrierStyle.Contains(x.StyleID)) == false)
                {
                    SalesOrderLineViewModel saleLinevumodel = new SalesOrderLineViewModel();
                    saleLinevumodel = _basket.GetCarrStyleLine(carrStyle, ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().CustID, Convert.ToDouble(Session["CurrencyExchangeRate"]), newLineNO);
                    if (saleLinevumodel != null)
                    {
                        ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(x => x.EmployeeID == thisEmp && x.Returnheader).First().SalesOrderLine.Add(saleLinevumodel);

                        ((List<ReturnOrderModel>)Session["rtnLines"]).Add(new ReturnOrderModel
                        {
                            IsReturn = true,
                            Iscarr = saleLinevumodel.isCarrline,
                            ColourId = saleLinevumodel.ColourID,
                            ReturnLineNo = newLineNO,
                            Description = saleLinevumodel.Description,
                            OrdQty = Convert.ToInt32(saleLinevumodel.OrdQty),
                            Price = Convert.ToDouble(saleLinevumodel.Price),
                            SizeId = saleLinevumodel.SizeID,
                            StyleId = saleLinevumodel.StyleID,
                            CustRef = Session["CustRef"].ToString(),
                            VAT = saleLinevumodel.VAT,
                            //TotalPoints = totalPts,
                            RepId = Convert.ToInt32(Session["Rep_Id"].ToString()),
                            StockingUOM1 = 1,
                            isCarrline = true,
                            Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                            IssueQty1 = saleLinevumodel.IssueQty1,
                            VatPercent = saleLinevumodel.VatPercent,
                            Total = saleLinevumodel.Total,
                            DeliveryDate = saleLinevumodel.DeliveryDate,
                            VatCode1 = saleLinevumodel.VatCode1,
                            //RepId = saleLinevumodel.RepId,
                            //Currency_Exchange_Rate = saleLinevumodel.Currency_Exchange_Rate,
                            Cost1 = saleLinevumodel.Cost1,
                            //DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]), Convert.ToBoolean(Session["IncWendsDel"])),
                            IssueUOM1 = 1,
                            //IssueQty1 = saleLinevumodel.IssueQty1,
                            //StockingUOM1 = 1,
                            //SOPDetail4 = reason,
                            //SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "",
                            ReasonCode = 0,
                        });
                        var ss = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList();
                    }
                    result = "added";
                }
            }
            else
            {
                if (salesLines.Any(x => carrierStyle.Contains(x.StyleID)) == false)
                {
                    SalesOrderLineViewModel saleLinevumodel = new SalesOrderLineViewModel();
                    var styl = carrStyle.Contains("|") ? carrStyle.Split('|')[0] : carrStyle;
                    saleLinevumodel = _basket.GetCarrStyleLine(styl, ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().CustID, Convert.ToDouble(Session["CurrencyExchangeRate"]), newLineNO);
                    if (saleLinevumodel != null)
                    {
                        ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(x => x.EmployeeID == thisEmp && x.Returnheader).First().SalesOrderLine.Add(saleLinevumodel);
                        ((List<ReturnOrderModel>)Session["rtnLines"]).Add(new ReturnOrderModel
                        {
                            IsReorder = false,
                            ColourId = saleLinevumodel.ColourID,
                            ReturnLineNo = newLineNO,
                            Description = saleLinevumodel.Description,
                            OrdQty = Convert.ToInt32(saleLinevumodel.OrdQty),
                            Price = Convert.ToDouble(saleLinevumodel.Price),
                            SizeId = saleLinevumodel.SizeID,
                            StyleId = saleLinevumodel.StyleID,
                            CustRef = Session["CustRef"].ToString(),
                            VAT = saleLinevumodel.VAT,
                            //TotalPoints = totalPts,
                            RepId = Convert.ToInt32(Session["Rep_Id"].ToString()),
                            StockingUOM1 = 1,
                            Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                            IssueQty1 = saleLinevumodel.IssueQty1,
                            //StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"),
                            //OrgStyle = orgStyl,
                            VatPercent = saleLinevumodel.VatPercent,
                            Total = saleLinevumodel.Total,
                            //FreeText1 = reqData1,
                            DeliveryDate = saleLinevumodel.DeliveryDate,
                            VatCode1 = saleLinevumodel.VatCode1,
                            //RepId = saleLinevumodel.RepId,
                            //Currency_Exchange_Rate = saleLinevumodel.Currency_Exchange_Rate,
                            Cost1 = saleLinevumodel.Cost1,
                            //DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]), Convert.ToBoolean(Session["IncWendsDel"])),
                            IssueUOM1 = 1,
                            //IssueQty1 = saleLinevumodel.IssueQty1,
                            //StockingUOM1 = 1,
                            //SOPDetail4 = reason,
                            //SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "",
                            ReasonCode = 0,
                        });
                    }
                    result = "added";
                }
            }
            return result;
        }
        #endregion
        //[HttpPost]
        //#region SaveRtnCollectionInfo
        //public ActionResult SaveRtnCollectionInfo(RtnCollectionModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        return RedirectToAction("Index", "Return");
        //    }
        //    ModelState.AddModelError("", "Please correct all the errors");
        //    return PartialView("_PopReorderPartial", model);
        //}
        //#endregion

        #region GetCollectionPop

        public PartialViewResult GetCollectionPop()
        {
            return PartialView("_ReturnCollectionPop");
        }
        #endregion

        #region getsalesLines()

        public List<SalesOrderLineViewModel> getsalesLines(List<ReturnOrderModel> returns, bool isReturn, long orderNo)
        {
            var result = returns.Select(returnOrderLines => new SalesOrderLineViewModel
            {
                EmployeeId = returnOrderLines.Emp,
                Isedit = returnOrderLines.IsRetEdit,
                isCarrline = returnOrderLines.isCarrline,
                OrderNo = isReturn ? returnOrderLines.RtnOrderno : returnOrderLines.ReOrderno,
                IsDleted = returnOrderLines.IsDleted == 1 ? true : false,
                OriginalOrderNo = returnOrderLines.OrderNo,
                OriginalLineNo = isReturn ? returnOrderLines.LineNo : 0,
                SoqtyForempSO = isReturn ? returnOrderLines.OrgRetOrdQtyDel : returnOrderLines.OrdQty,
                SoqtyForempSOPoints = isReturn ? (returnOrderLines.OrgRetOrdQtyDel * returnOrderLines.Points) : (returnOrderLines.OrdQty * returnOrderLines.Points),
                ColourID = returnOrderLines.ColourId,
                LineNo = isReturn ? returnOrderLines.ReturnLineNo : returnOrderLines.ReOrderLineNo,
                ReturnLineNo = isReturn ? 0 : returnOrderLines.ReturnLineNo,
                Description = returnOrderLines.Description,
                OrdQty = returnOrderLines.OrdQty,
                Price = returnOrderLines.Price,
                SizeID = returnOrderLines.SizeId,
                StyleID = returnOrderLines.StyleId,
                VAT = returnOrderLines.VAT,
                InvFlag = returnOrderLines.InvFlag,
                VatPercent = returnOrderLines.VatPercent,
                Total = returnOrderLines.Total,
                FreeText1 = returnOrderLines.FreeText1,
                DeliveryDate = returnOrderLines.DeliveryDate,
                VatCode1 = returnOrderLines.VatCode1,
                RepId = returnOrderLines.RepId,
                Currency_Exchange_Rate = returnOrderLines.Currency_Exchange_Rate,
                Cost1 = returnOrderLines.Cost1,
                IssueUOM1 = returnOrderLines.IssueUOM1,
                IssueQty1 = returnOrderLines.IssueQty1,
                StockingUOM1 = returnOrderLines.StockingUOM1,
                SOPDetail4 = returnOrderLines.SOPDetail4,
                SOPDetail5 = returnOrderLines.SOPDetail5,
                ReasonCodeLine = returnOrderLines.ReasonCode,
                Points = returnOrderLines.Points,
                TotalPoints = returnOrderLines.TotalPoints
            }).ToList();
            return result;
        }

        #endregion


        #region delivery address
        public ActionResult GetEmployeeDeliveryAddress()
        {
            ViewData["booAddrDef"] = Convert.ToBoolean(_dataConnection.BusinessParam("DEFEMPDELADDR", Session["BuisnessId"].ToString()));
            ViewData["booAddrEdit"] = Convert.ToBoolean(_dataConnection.BusinessParam("DEFEMPDELADDR_EDIT", Session["BuisnessId"].ToString()));
            ViewData["booAddrView"] = Convert.ToBoolean(_dataConnection.BusinessParam("DEFEMPDELADDR_VIEW", Session["BuisnessId"].ToString()));
            var result = /*_basket.FillCombo_CustomerDelivery(busId, access, orderPermit, userName, false, "")*/(List<BusAddress1>)Session["DeliveryAddress"];
            Session["DeliveryAddress"] = result;
            return PartialView("_Deliveryaddress", result);
        }

        #endregion

        public JsonResult GetRetReordTotals()
        {
            List<TotalModel> result = new List<TotalModel>();
            if (Session["rtnLines"] != null)
            {
                if (((List<ReturnOrderModel>)Session["rtnLines"]).Count > 0)
                {
                    double carriage = 0.0;
                    if (((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).Count() > 0)
                    {
                        var retModel = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReturn).ToList();
                        TotalModel total = new TotalModel();
                        total = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, false, retModel);
                        total.isreturn = true;
                        result.Add(total);
                    }
                    if (((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).Count() > 0)
                    {
                        var reOrdModel = ((List<ReturnOrderModel>)Session["rtnLines"]).Where(s => s.IsReorder).ToList();
                        TotalModel total = new TotalModel();
                        total = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, false, reOrdModel);
                        total.isreord = true;
                        result.Add(total);
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public string SaveCntInfo(string cntName, string cntNo, string cntEmail)
        {
            string result = "";
            long sa = 0;
            bool isNo = System.Int64.TryParse(cntNo, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture.NumberFormat, out sa);
            if (isNo)
            {
                if (cntName != "" && cntNo != "" && cntEmail != "")
                {
                    if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count > 0 && ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Any(s => s.Returnheader))
                    {
                        ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(s => s.Returnheader).First().ContactName = cntName;
                        ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(s => s.Returnheader).First().Mobile = cntNo;
                        ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(s => s.Returnheader).First().EmailID = cntEmail;
                        ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Where(s => s.Returnheader).First().HasContactDetail = true;
                        result = "success";
                    }
                }
            }
            return result;
        }

        #region SetReturnOrderlines
        public void SetReturnOrderlines(int orderNo)
        {
            Session["RTNORDNO"] = orderNo;
            Session["ISRTNEDITING"] = true;
            var mod = new List<ReturnOrderModel>();
            var mod1 = new List<ReturnOrderModel>();

            if (mod.Count == 0 | mod1.Count == 0)
                if (_salesOrderHeader.Exists(s => s.OrderNo == orderNo) && _salesOrderLines.Exists(s => s.OrderNo == s.OrderNo))
                {
                    var rntO = _salesOrderHeader.GetAll(s => s.OrderNo == orderNo).ToList().Select(s => new
                    {
                        Emp = s.PinNo,
                        CustId = s.CustID,
                        IsSelect = true,
                        OrderDate = s.OrderDate.Value.ToString(),
                        OrderNo = orderNo,
                        CustRef = s.CustRef,
                        IsReturn = true,
                        Ucode = s.UCodeId,
                        Total = s.TotalGoods.Value,
                        EmpName = _employee.GetAll(sa => sa.EmployeeID == s.PinNo).First().Forename + " " + _employee.GetAll(sa => sa.EmployeeID == s.PinNo).First().Surname,
                    }).First();
                    if (((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count() == 0)
                    {
                        SetSalesOrderHeader(rntO.Emp, rntO.CustId);
                    }
                    Session["CustRef"] = rntO.CustRef;
                    Session["rtnempname"] = rntO.EmpName;
                    Session["rtnempid"] = rntO.Emp;
                    var otherOrders = _salesOrderHeader.Exists(s => s.PinNo == rntO.Emp && s.OrderNo != orderNo && s.OrderType.ToLower() == "rt") ? _salesOrderHeader.GetAll(s => s.PinNo == rntO.Emp && s.OrderNo != orderNo && s.OrderType.ToLower() == "rt").Select(s => s.OrderNo).ToList() : new List<long>();
                    var ss = _salesOrderLines.GetAll(s => s.OrderNo == orderNo).ToList();
                    var rtnLines = _salesOrderLines.GetAll(s => s.OrderNo == orderNo).ToList().Select(s => new ReturnOrderModel
                    {
                        ColourId = s.ColourID,
                        Cost1 = Convert.ToDouble(s.Cost.Value),
                        Currency_Exchange_Rate = s.Currency_Exchange_Rate.Value,
                        CustRef = rntO.CustRef,
                        DeliveryDate = s.Deliverydate.Value.ToString(),
                        Emp = rntO.Emp,
                        Description = s.Description,
                        Employeename = rntO.EmpName,
                        IsReturn = true,
                        Ucode = rntO.Ucode,
                        ReturnManPack = _manPckRtnOrders.Exists(sas => sas.OrderNo == orderNo) ? Convert.ToInt32(_manPckRtnOrders.GetAll(sas => sas.OrderNo == orderNo).First().ManPackNo) : 0,
                        IsSelect = true,
                        InvFlag = _pickHeader.Exists(sa => sa.OrderNo == s.OriginalOrderNo) ? _pickHeader.GetAll(sa => sa.OrderNo == s.OriginalOrderNo).First().FlagInvoice == 1 ? "inv" : "pick" : "so",
                        IsRetEdit = true,
                        IsReorder = false,
                        IssueQty1 = Convert.ToInt32(s.IssueQty.Value),
                        IssueUOM1 = Convert.ToInt32(s.IssueUOM.Value),
                        ReturnLineNo = Convert.ToInt32(s.LineNo),
                        OriginalLineNo = Convert.ToInt32(s.OriginalLineNo),
                        LineNo = Convert.ToInt32(s.OriginalLineNo),
                        OrderDate = rntO.OrderDate,
                        OrderNo = Convert.ToInt32(s.OriginalOrderNo),
                        OrgRetOrdQty = Convert.ToInt32(s.OrdQty),
                        OrgRetOrdQtyDel = Convert.ToInt32(s.OrdQty),
                        //OtherretOrdqTY
                        OrdQty = Convert.ToInt32(s.OrdQty),
                        OrgOrdQty = _salesOrderLines.Exists(sa => sa.OrderNo == s.OriginalOrderNo && sa.LineNo == s.OriginalLineNo) ? Convert.ToInt32(_salesOrderLines.GetAll(sa => sa.OrderNo == s.OriginalOrderNo && sa.LineNo == s.OriginalLineNo).First().OrdQty) : 0,
                        OtherReturnQty = otherOrders.Count > 0 ? _salesOrderLines.Exists(sa => otherOrders.Contains(sa.OrderNo) && sa.StyleID == s.StyleID && sa.ColourID == s.ColourID) ? Convert.ToInt32(_salesOrderLines.GetAll(sa => otherOrders.Contains(sa.OrderNo) && sa.StyleID == s.StyleID && sa.ColourID == s.ColourID).Sum(sa => sa.OrdQty).Value) : 0 : 0,
                        Points = _pointStyle.GetAll(sa => sa.UcodeID == rntO.Ucode && sa.StyleID == s.StyleID).First().Points.Value,
                        Price = Convert.ToDouble(s.Price.Value),
                        RtnOrderno = Convert.ToInt32(s.OrderNo),
                        ReasonCode = s.ReasonCode.Value,
                        RepId = Convert.ToInt32(s.RepID),
                        Reason = _returnReasonCodes.Exists(sa => sa.ReasonCode == s.ReasonCode) ? _returnReasonCodes.GetAll(sa => sa.ReasonCode == s.ReasonCode).First().Description : "",
                        StyleId = s.StyleID,
                        StyleImage = _fskStyle.Exists(sa => sa.StyleID == s.StyleID) ? _fskStyle.GetAll(sa => sa.StyleID == s.StyleID).First().StyleImage : "",
                        SizeId = s.SizeID,
                        TotalPoints = Convert.ToInt32(s.OrdQty.Value) * _pointStyle.GetAll(sa => sa.UcodeID == rntO.Ucode && sa.StyleID == s.StyleID).First().Points.Value,
                    }).ToList();
                    if (_salesOrderLines.Exists(s => s.ReturnOrderNo == orderNo))
                    {
                        var test = _salesOrderLines.GetAll(s => s.ReturnOrderNo == orderNo).First();
                        rtnLines.AddRange(_salesOrderLines.GetAll(s => s.ReturnOrderNo == orderNo).ToList().Select(s => new ReturnOrderModel
                        {
                            ColourId = s.ColourID,
                            Cost1 = Convert.ToDouble(s.Cost.Value),
                            Currency_Exchange_Rate = s.Currency_Exchange_Rate.Value,
                            CustRef = rntO.CustRef,
                            DeliveryDate = s.Deliverydate.Value.ToString(),
                            Emp = rntO.Emp,
                            Description = s.Description,
                            Employeename = rntO.EmpName,
                            IsReturn = false,
                            IsCnf = _salesOrderHeader.Exists(sa => sa.OrderNo == test.OrderNo) ? _salesOrderHeader.GetAll(sa => sa.OrderNo == test.OrderNo).First().OnlineConfirm == 1 ? true : false : false,
                            ReOrderno = Convert.ToInt32(s.OrderNo),
                            Ucode = rntO.Ucode,
                            IsSelect = true,
                            IsRetEdit = true,
                            IsReorder = true,
                            IssueQty1 = Convert.ToInt32(s.IssueQty.Value),
                            IssueUOM1 = Convert.ToInt32(s.IssueUOM.Value),
                            ReturnLineNo = Convert.ToInt32(s.ReturnLineNo),
                            OriginalLineNo = Convert.ToInt32(s.OriginalLineNo),
                            LineNo = Convert.ToInt32(s.OriginalLineNo),
                            ReOrderLineNo = Convert.ToInt32(s.ReturnLineNo),
                            ReOrdManPack = _manPckOrders.Exists(sas => sas.OrderNo == orderNo) ? Convert.ToInt32(_manPckOrders.GetAll(sas => sas.OrderNo == orderNo).First().ManPackNo) : 0,
                            OrderDate = rntO.OrderDate,
                            OrderNo = Convert.ToInt32(s.OriginalOrderNo),
                            OrdQty = Convert.ToInt32(s.OrdQty),
                            OrgOrdQty = Convert.ToInt32(s.OrdQty),
                            Points = _pointStyle.GetAll(sa => sa.UcodeID == rntO.Ucode && sa.StyleID == s.StyleID).First().Points.Value,
                            Price = Convert.ToDouble(s.Price.Value),
                            ReasonCode = s.ReasonCode.Value,
                            RepId = Convert.ToInt32(s.RepID),
                            StyleId = s.StyleID,
                            StyleImage = _fskStyle.GetAll(sa => sa.StyleID == s.StyleID).First().StyleImage,
                            SizeId = s.SizeID,
                            TotalPoints = Convert.ToInt32(s.OrdQty.Value) * _pointStyle.GetAll(sa => sa.UcodeID == rntO.Ucode && sa.StyleID == s.StyleID).First().Points.Value,
                        }).ToList());
                    }
                    var cnfLines = rtnLines.Where(s => s.IsReorder).Any(s => s.IsCnf) ? rtnLines.Where(s => s.IsReorder && s.IsCnf).Select(s => s.ReturnLineNo).ToList() : new List<int>();
                    rtnLines.Where(s => cnfLines.Contains(s.ReturnLineNo) && s.IsReturn).ToList().ForEach(s => s.HasCnfReorders = true);
                    var model = getreturnordermodel(rntO.Emp, new List<string>(), 0, "", "", 0, rntO.EmpName);
                    foreach (var lines in rtnLines.Where(s => s.IsReturn))
                    {
                        model.Where(s => s.LineNo == lines.LineNo).ToList().ForEach(s => s.OtherReturnQty = lines.OtherReturnQty);
                        //  model.Where(s => s.LineNo == lines.LineNo).ToList().ForEach(s => s.OrgRetOrdQtyDel = lines.OrgRetOrdQtyDel);
                    }
                    Session["returnModellst"] = model;
                    Session["rtnLines"] = rtnLines;
                }
        }
        #endregion

        public string GetReOrderProductsDesc(string Style)
        {
            string desc = "";
            if (Style != "")
            {
                desc = _fskStyle.Exists(s => s.StyleID == Style) ? _fskStyle.GetAll(s => s.StyleID == Style).First().Description : "";
            }
            return desc;
        }

        public string GetPointsDivReturns()
        {
            string result = "";
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                int totalPts = 0, cardPts = 0, rtnPts = 0, reOrdPts = 0, reOrdPtsED = 0, availPts = 0, OtherPoints = 0;
                var emp = Session["rtnempid"] != null ? Session["rtnempid"].ToString() != "" ? Session["rtnempid"].ToString() : "" : "";
                string busId = Session["BuisnessId"].ToString();
                var ss = ((List<ReturnOrderModel>)Session["rtnLines"]);
                var ucode = (bool)Session["ISRTNEDITING"] ? ((List<ReturnOrderModel>)Session["rtnLines"]).First().Ucode : Session["ReturnOrderHeader"] != null ? ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).Count > 0 ? ((List<SalesOrderHeaderViewModel>)Session["ReturnOrderHeader"]).First().UCodeId : "" : "";
                var ucodStylesLst = _dp.UcodeStyles(ucode, busId) == null ? _dp.UcodeStyles(ucode,busId): (List<string>)_dp.UcodeStyles(ucode, busId);
                totalPts = _pointsByUcode.Exists(s => s.BusinessID == busId && s.UcodeID == ucode) ? _pointsByUcode.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).First().TotalPoints.Value : 0;
                cardPts = _vuPointsCard.Exists(s => s.BusinessID == busId && s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)).Sum(s => s.TOTSOPOINTS).Value) : 0;

                //if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                //{

                //}
                //else
                //{
                rtnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReturn && s.IsDleted == 0) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0).Sum(s => s.TotalPoints) : 0;
                reOrdPts= (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReorder && s.IsDleted == 0) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderno != 0).Sum(s => s.TotalPoints) : 0;
                reOrdPtsED = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReorder && s.IsDleted == 0) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderno==0).Sum(s => s.TotalPoints) : 0;
              
                if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                {
                    int thisRTnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReturn && s.IsDleted == 0 && s.IsRetEdit == false) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0 && s.IsRetEdit == false).Sum(s => s.TotalPoints) : 0;
                    availPts = totalPts - ((cardPts + reOrdPtsED)- thisRTnPts);
                }
                else
                {
                    availPts = totalPts - ((cardPts + reOrdPts+ reOrdPtsED) - rtnPts);
                }
                //}
                result = "<div class='row'><div class='col-md-2'>Total Points:&nbsp;&nbsp;<b>" + totalPts + "</b></div><div class='col-md-2'>Used Points:<b>&nbsp;&nbsp;" + cardPts + "</b></div><div class='col-md-3'>Available Points:<b>&nbsp;&nbsp;" + availPts + "</b></div><div class='col-md-2'>Return Points:<b>&nbsp;&nbsp;" + rtnPts + "</b></div><div class='col-md-2'>Reorder Points:<b>&nbsp;&nbsp;" +( reOrdPts+ reOrdPtsED) + "</b></div></div>";
            }
            return result;
        }

    }
}