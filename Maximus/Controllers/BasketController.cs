using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Data.models;
using System.Configuration;
using System.Text.RegularExpressions;
using Maximus.Services.Interface;
using Maximus.Data.Interface.Concrete;
using Maximus.Services;
using Maximus.Data.Models;
using Unity;
using Maximus.Data.models.RepositoryModels;

namespace Maximus.Controllers
{

    [Authorize]
    public class BasketController : Controller
    {
        #region declarations
        public string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        [Dependency]
        private readonly IBasket _basket;
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
        public readonly PointStyle _pointStyle;
        public readonly PointsCard _pointsCard;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointsAdjustment _pointsAdjustment;
        public readonly ViewPointsCard _vuPointsCard;
        private string busId;
        private string access;
        private string orderPermit;
        private string userName;
        private string budgetReq;
        public string error = "If you wish please adjust quantity of dresses and tops as the combination is above the mandatory quantity";

        public BasketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            BasketService basket = new BasketService(_unitOfWork);
            _basket = basket;
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            tblSalesLines salesOrderLines = new tblSalesLines(_unitOfWork);
            _salesOrderLines = salesOrderLines;
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
            Employee employee = new Employee(_unitOfWork);
            ViewPointsCard vuPointsCard = new ViewPointsCard(_unitOfWork);
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
            Ucodes ucodes = new Ucodes(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            StyleSizePrice styleSizePrice = new StyleSizePrice(_unitOfWork);
            CustomerOrderTemplate customerOrderTemplate = new CustomerOrderTemplate(_unitOfWork);
            tblSalesOrderHeader salesOrderHeader = new tblSalesOrderHeader(_unitOfWork);
            Dimension1 dimension = new Dimension1(_unitOfWork);
            FskSetValues fskSetValues = new FskSetValues(_unitOfWork);
            UcodeByFreeTextView ucodeByFreetext = new UcodeByFreeTextView(_unitOfWork);
            PointStyle pointStyle = new PointStyle(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointsAdjustment pointsAdjustment = new PointsAdjustment(_unitOfWork);
            _pointsByUcode = pointsByUcode;
            _pointsAdjustment = pointsAdjustment;
            _pointStyle = pointStyle;
            _pointsCard = pointsCard;
            _ucodeByFreetext = ucodeByFreetext;
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
            _vuPointsCard = vuPointsCard;
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
            _busAddress = busAddress;
            _styleSizePrice = styleSizePrice;
            _dp = dp;
            _busBusiness = busBusiness;
            _reason = reason;
            _fskColor = fskColor;
            userName = System.Web.HttpContext.Current.Session["UserName"].ToString();
            busId = System.Web.HttpContext.Current.Session["BuisnessId"].ToString();
            budgetReq = System.Web.HttpContext.Current.Session["BUDGETREQ"].ToString();
            access = System.Web.HttpContext.Current.Session["Access"].ToString();
            orderPermit = System.Web.HttpContext.Current.Session["OrderPermit"].ToString();
        }
        #endregion

        #region ShowBasket
        public ActionResult ShowBasket(int ordeNo = 0)
        {
            double carriage = 0.0;
            if (ordeNo > 0 || Convert.ToBoolean(Session["ISEDITING"]))
            {
                if (EditOrder(ordeNo) || Convert.ToBoolean(Session["ISEDITING"]))
                {
                    Session["ISEDITING"] = true;
                    var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).ToList();
                    Session["DeliveryAddress"] = _basket.FillCombo_CustomerDelivery(busId, access, orderPermit, userName, true, model1.First().PinNo);
                    TotalModel tot = new TotalModel();
                    if (Convert.ToBoolean(Session["POINTSREQ"]))
                    {
                        Session["Pointsmodel"] = _basket.GetPointsModel(model1.First().UCodeId, busId);
                    }
                    if (ordeNo > 0 & model1.First().IsUcode)
                    {
                        Init(model1.FirstOrDefault());
                    }
                    Session["cboDelAddress"] = ((List<Maximus.Data.Models.BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressDescription == model1.First().DelDesc).First().AddressId;
                    tot = _dataConnection.GetAlltotals(model1, carriage, true);
                    ViewBag.VatPercent = tot.vatSpan;
                    ViewBag.carriage = tot.carriage;
                    ViewBag.ordeTotal = tot.ordeTotal;
                    ViewBag.totalVat = tot.totalVat;
                    ViewBag.Total = tot.Total;
                    ViewBag.GrossTotal = tot.gross;
                    ViewData["SiteCodes"] = FillSiteCode();
                    if (Convert.ToBoolean(Session["IsBulkOrder1"]) == false)
                    {
                        Session["SelectedEmp"] = model1.First().EmployeeID;
                    }
                    else
                    {
                        Session["SelectedEmp"] = "";
                    }
                    Session["SelectedUcode"] = model1.First().UCodeId;
                    if (model1.First().SalesOrderLine.Count > 0)
                    {
                        Session["qty"] = model1.First().SalesOrderLine.Where(x => x.OrdQty != 0).Sum(x => x.OrdQty);
                    }
                    else
                    {
                        Session["qty"] = 0;
                    }
                    var carr = FillCarrierDropdown();
                    if (carr.Count > 0)
                    {
                        ViewData["carrierFill"] = carr;
                        foreach (var item in carr)
                        {
                            if (item.Contains(Session["Carrier"].ToString()))
                            {

                                Session["selectedcar"] = item.Trim();
                            }
                        }
                    }
                    var carrier = FillCarrierStyle();
                    Session["carrStyle"] = carrier;
                    ViewData["carrierStyleFill"] = carrier;
                    GetPointsDiv();
                }
            }
            else
            {
                Session["DeliveryAddress"] = _basket.FillCombo_CustomerDelivery(busId, access, orderPermit, userName, true, Session["SelectedEmp"].ToString());
                
                Session["clickedEmp"] = null;
                var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
               

                string emp = Session["SelectedEmp"].ToString();
                var contactType = 0;
                var resultq = new BusAddress1();
                var contactId = 0;
                List<double> varpercents = new List<double>();
                var data = ""; 
                var result = Session["cboDelAddress"].ToString() == "" ? _dataConnection.GetDeliveryAddressId(emp, busId, Session["UserName"].ToString()) : Convert.ToInt32(Session["cboDelAddress"].ToString());
                result = result > 0 ? result : model1.First().AddressId;
                var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                Session["CustRef"] = "";
                Session["cboDelAddressDesc"] = "";
                if (result > 0)
                {
                    if ((mod.Where(x => x.EmployeeID == emp).First().CustRef == "" || mod.Where(x => x.EmployeeID == emp).First().CustRef == null))
                    {
                        Session["cboDelAddress"] = result;
                        var sa = _busAddress.Exists(x => x.AddressID == result && x.BusinessID == busId) ? _busAddress.GetAll(x => x.AddressID == result && x.BusinessID == busId).First().Description : "";
                        Session["cboDelAddressDesc"] = _busAddress.Exists(x => x.AddressID == result && x.BusinessID == busId) ? _busAddress.GetAll(x => x.AddressID == result && x.BusinessID == busId).First().Description : "";
                        contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                        if(result>0)
                        {
                            contactId = Convert.ToInt32(resultq.contactId);
                            data = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CustRef : _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                            Session["CustRef"] = data;
                        }
                        if (Session["cboDelAddressDesc"].ToString() == "")
                        {
                            var s = Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]);
                            if (!Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]))
                            {
                                var res = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().AddressId : 0;
                                if (res != 0)
                                {
                                    Session["cboDelAddress"] = res;
                                    Session["cboDelAddressDesc"] = _busAddress.Exists(x => x.AddressID == res && x.BusinessID == busId) ? _busAddress.GetAll(x => x.AddressID == res && x.BusinessID == busId).First().Description : "";

                                    contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                                    resultq = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == res).First();
                                    contactId = Convert.ToInt32(resultq.contactId);
                                    data = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CustRef : _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                                    Session["CustRef"] = data;
                                    ViewData["comment"] = mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CommentsExternal;
                                }
                            }
                        }
                        else
                        {
                            contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                             
                            resultq = ((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == result) ? ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == result).First() : new BusAddress1();
                            if (resultq.AddressId > 0)
                            {
                                mod.Last().DelDesc = resultq.AddressDescription;
                                mod.Last().AddressId = resultq.AddressId;
                                mod.Last().DelAddress1 = resultq.Address1;
                                mod.Last().DelAddress3 = resultq.Address3;
                                mod.Last().DelAddress2 = resultq.Address2;
                                mod.Last().DelCity = resultq.City;
                                mod.Last().DelCountry = resultq.Country;
                                mod.Last().DelPostCode = resultq.PostCode;
                                contactId = Convert.ToInt32(resultq.contactId);
                                data = _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                                Session["CustRef"] = data;
                                ViewData["comment"] = mod.Last().CommentsExternal;
                                mod.Last().CustRef = data;
                            }
                        }
                    }
                    else
                    {
                        Session["cboDelAddress"] = mod.Where(x => x.EmployeeID == emp).First().AddressId;
                        Session["cboDelAddressDesc"] = mod.Where(x => x.EmployeeID == emp).First().DelDesc;
                        Session["CustRef"] = mod.Where(x => x.EmployeeID == emp).First().CustRef;
                        ViewData["comment"] = mod.Where(x => x.EmployeeID == emp).First().CommentsExternal;
                    }
                }
                else
                {
                    var res = mod.Any(x => x.SalesOrderLine != null) ? mod.Where(x => x.SalesOrderLine != null).Last().AddressId : 0;
                    if (res != 0)
                    {
                        Session["cboDelAddress"] = res;
                        Session["cboDelAddressDesc"] = _busAddress.Exists(x => x.AddressID == res && x.BusinessID == busId) ? _busAddress.GetAll(x => x.AddressID == res && x.BusinessID == busId).First().Description : "";

                        contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                        resultq = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == res).First();
                        contactId = Convert.ToInt32(resultq.contactId);
                        data = _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                        Session["CustRef"] = data;
                    }
                }
                ViewData["SiteCodes"] = FillSiteCode();
                var carr = FillCarrierDropdown();

                List<SalesOrderHeaderViewModel> totLst = new List<SalesOrderHeaderViewModel>();
                totLst.Add(mod.Where(x => x.SalesOrderLine != null).Last());

                TotalModel tot = new TotalModel();
                tot = _dataConnection.GetAlltotals(totLst, carriage, false);
                ViewBag.VatPercent = tot.vatSpan;
                ViewBag.carriage = tot.carriage;
                ViewBag.ordeTotal = tot.ordeTotal;
                ViewBag.totalVat = tot.totalVat;
                ViewBag.Total = tot.Total;
                ViewBag.GrossTotal = tot.gross;
                if (carr.Count > 0)
                {
                    ViewData["carrierFill"] = carr;
                    foreach (var item in carr)
                    {
                        if (item.Contains(Session["Carrier"].ToString()))
                        {

                            Session["selectedcar"] = item.Trim();
                        }
                    }
                }
               var carrier= FillCarrierStyle();
                Session["carrStyle"] = carrier;
                ViewData["carrierStyleFill"] = carrier;
                ViewData["ddlCustRef"] = _dataConnection.GetCustRefVisiblity(busId);
                if (Convert.ToBoolean(Session["POINTSREQ"]))
                {
                    GetPtsAdjustmenterror();
                    string ucode = Session["SelectedUcode"].ToString();
                    string empId = Session["SelectedEmp"].ToString();
                    var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == empId) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
                    var salesLine = salesHead.SalesOrderLine;
                    Session["Pointsmodel"] = _basket.GetPointsModel(Session["selectedUcodes"].ToString(), busId);
                    int totAvailPts =_dp.GetTotalSoPoints(busId, empId,0) ;
                    int totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    int inCartPoints = salesLine.Count > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                    int availabelPoints = totPoints - inCartPoints - totAvailPts;
                    int usedPoints = totPoints - availabelPoints;
                    ViewData["TotalPoints"] = totPoints;
                    ViewData["inCartPoints"]  = inCartPoints;
                    ViewData["availabelPoints"] = availabelPoints;
                    ViewData["usedPoints"] = totPoints - availabelPoints;
                    //if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints > 0)
                    //{
                    //  //  GetMissingPointsDetail();
                    //}
                }
            }
            return View();
        }
        #endregion

        #region Edit existsing Order

        public bool EditOrder(int OrderNo)
        {
            if (OrderNo > 0)
            {
                try
                {
                    var carrier = FillCarrierStyle();
                    string emp = "";
                    SalesOrderHeaderViewModel slsHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsEditing) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First() : new SalesOrderHeaderViewModel();
                    if (_salesOrderHeader.Exists(x => x.OrderNo == OrderNo))
                    {
                        slsHead = _salesOrderHeader.GetAll(x => x.OrderNo == OrderNo && x.OnlineConfirm == 0 && x.OnlineProcessed == 0).Select(x => new SalesOrderHeaderViewModel { OrderNo = x.OrderNo, CompanyID = x.CompanyID, WarehouseID = x.WarehouseID, CustID = x.CustID, OrderDate = x.OrderDate.Value.ToString("dd-MM-yyyy"), InvAddress1 = x.InvAddress1, InvAddress2 = x.InvAddress2, InvAddress3 = x.InvAddress3, InvCity = x.InvCity, InvTown = x.InvTown, InvPostCode = x.InvPostCode, InvCountry = x.InvCountry, DelDesc = x.DelDesc, DelAddress1 = x.DelAddress1, DelAddress2 = x.DelAddress2, DelAddress3 = x.DelAddress3, DelCity = x.DelCity, DelTown = x.DelTown, DelPostCode = x.DelPostCode, DelCountry = x.DelCountry, CustRef = x.CustRef, Carrier = x.Carrier, CarrierCharge = Convert.ToDouble(x.CarrierCharge.Value), Comments = x.Comments, CommentsExternal = x.CommentsExternal, TotalGoods = x.TotalGoods.Value, OrderGoods = x.OrderGoods.Value, Currency_Exchange_Rate = x.Currency_Exchange_Rate, UserID = x.UserID, PinNo = x.PinNo, UCodeId = x.UCodeId, Currency_Exchange_Code = x.Currency_Exchange_Code, TIMEOFENTRY = x.TIMEOFENTRY, RepID = x.RepID, ReasonCode = x.ReasonCode, OnlineUserID = x.OnlineUserID, OrderAnalysisCode1 = x.OrderAnalysisCode1, OrderAnalysisCode2 = x.OrderAnalysisCode2, OrderAnalysisCode3 = x.OrderAnalysisCode3, OrderAnalysisCode4 = x.OrderAnalysisCode4, OrderAnalysisCode5 = x.OrderAnalysisCode5, AllowPartShipment = x.AllowPartShipment, OrderType = x.OrderType, ContractRef = x.ContractRef, EmailID = x.EmailID, ContactName = x.ContactName, IsUcode = true }).First();
                        if (slsHead.PinNo != "" && slsHead.PinNo != null)
                        {
                            var empDetail = _employee.GetAll(x => x.EmployeeID == slsHead.PinNo).First();
                            slsHead.EmployeeID = empDetail.EmployeeID;
                            slsHead.EmployeeName = empDetail.Forename + " " + empDetail.Surname;
                            emp = empDetail.EmployeeID;
                            Session["SelectedEmp"] = slsHead.EmployeeID;
                            Session["EmpName"] = slsHead.EmployeeName;
                        }
                        else
                        {
                            Session["IsBulkOrder1"] = true;
                            Session["IsManPack"] = false;
                        }
                        if ((slsHead.UCodeId == "" || slsHead.UCodeId == null) & slsHead.PinNo != "")
                        {
                            Session["UcodeDesc"] = "";
                            slsHead.IsTemplate = true;
                            slsHead.IsUcode = false;
                        }
                        else
                        {
                            slsHead.IsTemplate = false;
                            slsHead.IsUcode = true;
                        }
                        slsHead.IsEditing = true;
                        slsHead.SalesOrderLine = _salesOrderLines.GetAll(x => x.OrderNo == OrderNo).Select(x => new SalesOrderLineViewModel
                        {
                            CompanyID = x.CompanyID,
                            Warehouseid = x.Warehouseid,
                            OrderNo = x.OrderNo,
                            LineNo = x.LineNo,
                            StyleID = x.StyleID,
                            ColourID = x.ColourID,
                            Description = x.Description,
                            SizeID = x.SizeID,
                            Price = Convert.ToDouble(x.Price),
                            OrdQty = x.OrdQty.Value,
                            AllQty = x.AllQty.Value,
                            InvQty = x.InvQty.Value,
                            DespQty = x.DespQty.Value,
                            DeliveryDate = x.Deliverydate.Value.ToString("dd-MM-yyyy"),
                            VatCode1 = x.VatCode.Value,
                            RepId = Convert.ToInt32(x.RepID),
                            KAMID = Convert.ToInt32(x.KamID),
                            KAMRate1 = x.KAMRate.Value,
                            RepRate1 = x.RepRate.Value,
                            Currency_Exchange_Rate = x.Currency_Exchange_Rate.Value,
                            StyleIDref = x.StyleIDref,
                            FreeText1 = x.FreeText,
                            Cost1 = Convert.ToDouble(x.Cost),
                            IssueUOM1 = Convert.ToInt32(x.IssueUOM),
                            IssueQty1 = Convert.ToInt32(x.IssueQty),
                            StockingUOM1 = Convert.ToInt32(x.StockingUOM),
                            NomCode1 = x.NomCode.Value,
                            EmployeeId = emp,
                            OriginalOrderNo = x.OriginalOrderNo.Value,
                            OriginalLineNo = x.OriginalLineNo,
                            AssemblyID = x.AssemblyID.Value,
                            AsmLineNo = x.AsmLineNo.Value,
                            ReasonCodeLine = Convert.ToInt64(x.ReasonCode),
                            ReturnOrderNo = x.ReturnOrderNo.Value,
                            ReturnLineNo = x.ReturnLineNo.Value,
                            SOPDetail5 = x.SOPDETAIL5,
                            SOPDetail4 = x.SOPDETAIL4,
                            SoqtyForempSO=x.OrdQty.Value,
                           
                            Isedit = true,
                            Total = _dataConnection.GetlineTotals(Convert.ToDouble(x.OrdQty), Convert.ToDouble(x.Price), _dataConnection.GetVatPercent(x.StyleID, x.SizeID)),
                            VatPercent = _dataConnection.GetVatPercent(x.StyleID, x.SizeID)
                        }).ToList();
                        foreach (var lin in slsHead.SalesOrderLine)
                        {
                            lin.Points = _pointStyle.Exists(s => s.StyleID == lin.StyleID && s.BusinessID == busId) ? _pointStyle.GetAll(s => s.StyleID == lin.StyleID && s.BusinessID == busId).First().Points.Value : 0;
                            lin.TotalPoints = _pointStyle.Exists(s => s.StyleID == lin.StyleID && s.BusinessID == busId) ? _pointStyle.GetAll(s => s.StyleID == lin.StyleID && s.BusinessID == busId).First().Points.Value * Convert.ToInt32(lin.OrdQty) : 0;
                            lin.SoqtyForempSOPoints = (lin.SoqtyForempSO * lin.Points);
                            lin.isCarrline = carrier.Contains(lin.StyleID) ? true : false;
                        }
                        Session["selectedUcodes"] = slsHead.UCodeId;
                        
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).Count() == 0)
                        { ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Add(slsHead); }
                        if(((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing==false).Count() >0)
                        {
                            var saleHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing == false).First();
                                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Remove(saleHead);
                             
                        }
                        SetSalesOrderHeaderLoc();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }
        #endregion
        #region setSalesLoc
        public void SetSalesOrderHeaderLoc()
        {
            var SalesOrderHeaderLoc = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"];
            SalesOrderHeaderLoc.Add(new SalesOrderHeaderViewModel
            {
                UCodeId = Session["selectedUcodes"].ToString(),
                CustID = Session["BuisnessId"].ToString(),
                IsUcode = true,
                IsTemplate = false,
                SalesOrderLine = new List<SalesOrderLineViewModel>()
            });
        }
        #endregion


        #region GetPoibtsDiv
        public void GetPointsDiv()
        {
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                GetPtsAdjustmenterror();
                string ucode = Session["SelectedUcode"].ToString();
                string empId = Session["SelectedEmp"].ToString();
                int totAvailPts = 0;
                int totPoints = 0;
                int inCartPoints = 0;
                int availabelPoints = 0;
                int usedPoints = 0;
                var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == empId) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
                var salesLine = salesHead.SalesOrderLine;
                if (Convert.ToBoolean(Session["ISEDITING"]) == false)
                {
                    Session["Pointsmodel"] = _basket.GetPointsModel(Session["selectedUcodes"].ToString(), busId);
                    totAvailPts = _dp.GetTotalSoPoints(busId, empId, 0);
                    totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    inCartPoints = salesLine.Count > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                    availabelPoints = totPoints - inCartPoints - totAvailPts;
                    usedPoints = totPoints - availabelPoints;
                }
                else
                {
                    totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    inCartPoints = salesLine.Count > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                    totAvailPts = _dp.GetTotalSoPoints(busId, empId, 0);
                    if (inCartPoints == totAvailPts)
                    {
                        availabelPoints = totPoints - totAvailPts;
                        usedPoints = totPoints - availabelPoints;
                    }
                    else
                    {
                        availabelPoints = (totPoints + (totAvailPts - inCartPoints)) - totAvailPts;
                        usedPoints = totPoints - availabelPoints;
                    }
                }
                ViewData["TotalPoints"] = totPoints;
                ViewData["inCartPoints"] = inCartPoints;
                ViewData["availabelPoints"] = availabelPoints;
                ViewData["usedPoints"] = totPoints - availabelPoints; ;
            }
        }
        #endregion

        #region 
        public void Init(SalesOrderHeaderViewModel shs)
        {
            string selEMP = Session["SelectedEmp"].ToString();
            //string selUcode = Session["SelectedUcode"].ToString();
            List<string> lst = new List<string>();
            foreach (var data in _ucodeByFreeText.GetAll(x => x.UCodeID == shs.UCodeId).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList())
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
            lst = lst.Distinct().ToList();
            Session["UcFreeTxt"] = lst;
            var model = _ucodeByFreeText.GetAll(x => lst.Contains(x.FreeText) && x.UCodeID == shs.UCodeId).ToList().Select(x => new styleViewmodel
            {
                StyleID = x.StyleID,
                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false & d.CustID == busId) |
                                       _allAssemblies.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false) ? 1 : 0,
                //Assembly = _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                isAllocated = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                // Dimensions = x.FreeText
                Dimensions = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                SeqNO = x.SeqNo.Value,
                Freetext = x.FreeText,
                OriginalStyleid = x.StyleID.Contains(',') ? x.StyleID.Split(',')[0] : x.StyleID
            }).ToList();
            foreach (var line in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First().SalesOrderLine)
            {
                foreach (var dataval in model)
                {
                    if (_dimension1.Exists(s => s.FreeText.ToLower() == dataval.Dimensions.ToLower() && s.freetexttype.ToLower().Contains("dim") && s.StyleId == line.StyleID))
                    {
                        line.orgStyleId = dataval.OriginalStyleid;
                        line.StyleImage = dataval.StyleImage;
                    }
                    else if(dataval.StyleID==line.StyleID)
                    {
                        line.orgStyleId = dataval.OriginalStyleid;
                        line.StyleImage = dataval.StyleImage;
                    }

                }
            }
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles != null)
                {
                    if (((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Count == 0)
                    {
                        foreach (var dat in model)
                        {
                            int styPoints = _pointStyle.Exists(sq => sq.UcodeID == shs.UCodeId && sq.StyleID == dat.OriginalStyleid && sq.BusinessID == busId) ? _pointStyle.GetAll(sq => sq.UcodeID == shs.UCodeId && sq.StyleID == dat.OriginalStyleid && sq.BusinessID == busId).First().MinPts.Value : 0;
                            
                            var data1 = _fskSetValues.Exists(sas => sas.SettingID.ToUpper().Trim() == "FITDIM_STYLE_DESC" && sas.StyleID.ToLower().Trim() == dat.OriginalStyleid.ToLower().Trim()) ? _fskSetValues.GetAll(sas => sas.SettingID.ToUpper().Trim() == "FITDIM_STYLE_DESC" && sas.StyleID.ToLower().Trim() == dat.OriginalStyleid.ToLower().Trim()).First().Value : "";
                            var svmLst = _dimension1.GetAll(s => s.FreeText.ToLower() == dat.Dimensions && s.freetexttype.ToLower().Contains("dim")).Select(s => new Maximus.Data.Models.styleViewmodel { StyleID = s.StyleId, Description = s.Description, StyleImage = s.StyleImage }).ToList();
                            var svmStyLst = svmLst.Select(s => s.StyleID).ToList();
                            int soPoints = 0;
                            if (_vuPointsCard.Exists(s => svmStyLst.Distinct().Contains(s.StyleID) && s.EmployeeID == selEMP))
                            {
                                foreach (var styl in _vuPointsCard.GetAll(s => svmStyLst.Distinct().Contains(s.StyleID) && s.EmployeeID == selEMP).ToList())
                                {
                                    soPoints = soPoints +  (_dp.GetTotalSOPointsByStyle(busId, selEMP,0,styl.StyleID) / (_pointStyle.GetAll(s => s.UcodeID == shs.UCodeId && s.StyleID == styl.StyleID).First().Points.Value));
                                }
                            }
                            foreach (var svm in svmLst)
                            {
                                foreach (var item in ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles)
                                {
                                    if (item.Style == svm.StyleID)
                                    {
                                        
                                        int minPoints = styPoints > soPoints ? styPoints - soPoints : 0;
                                        if (minPoints > 0)
                                        {
                                            if (((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Count == 0)
                                            {
                                                ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Add(new Maximus.Data.models.StyleAndMinPoints { OrgStyle = dat.OriginalStyleid, MinPoints = minPoints, OrgMinPoints = minPoints, TruePoints = styPoints, Points = item.Points, Style = svm.StyleID, CatCaption = data1 });
                                            }
                                            else if (((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Any(ss => ss.Style == item.Style))
                                            {
                                                ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Remove(((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(ss => ss.Style == item.Style).First());
                                                ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Add(new Maximus.Data.models.StyleAndMinPoints { OrgStyle = dat.OriginalStyleid, MinPoints = minPoints, OrgMinPoints = minPoints, TruePoints = styPoints, Points = item.Points, Style = svm.StyleID, CatCaption = data1 });
                                            }
                                            else
                                            {
                                                ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Add(new Maximus.Data.models.StyleAndMinPoints { OrgStyle = dat.OriginalStyleid, MinPoints = minPoints, OrgMinPoints = minPoints, TruePoints = styPoints, Points = item.Points, Style = svm.StyleID, CatCaption = data1 });
                                            }
                                        }
                                    }
                                }
                            }
                            long cartManPts = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.IsEditing).First().SalesOrderLine.Any(s => s.orgStyleId == dat.OriginalStyleid) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.IsEditing).First().SalesOrderLine.Where(s => s.orgStyleId == dat.OriginalStyleid).Sum(s => s.OrdQty) : 0;
                            if (((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Any(s => s.OrgStyle == dat.OriginalStyleid))
                            {
                                foreach (var daat in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(ss => ss.OrgStyle == dat.OriginalStyleid))
                                {
                                    int sad = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(ss => ss.Style == daat.Style).First().MinPoints + Convert.ToInt32(cartManPts);
                                    ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(ss => ss.Style == daat.Style).First().MinPoints = sad;
                                 }
                            }
                        }
                    }
                }
            }
            //var sss1 = (List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"];
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                PointsAdjustment();
            }
        }

        #endregion

        #region PointsAjustment
        public void PointsAdjustment()
     {
            var sale = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First().SalesOrderLine;
            foreach (var model in sale.Where(s=>s.OriginalLineNo==0))
            {
                string ucode = Session["SelectedUcode"]!=null? Session["SelectedUcode"].ToString(): ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).First().UCodeId;
                var stylUpd = model;
                var thisEmp = stylUpd.EmployeeId;
                var lstPtsAdj = _pointsAdjustment.Exists(s => s.StyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode) ? _pointsAdjustment.GetAll(s => s.StyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode).Select(x => new pointsChange { styl = x.MapStyleID, type = "MapStyleID" }).ToList() : _pointsAdjustment.Exists(s => s.MapStyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode) ? _pointsAdjustment.GetAll(s => s.MapStyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode).Select(x => new pointsChange { styl = x.StyleID, type = "orgStyleID" }).ToList() : new List<pointsChange>();
                if (lstPtsAdj.Count > 0)
                {
                    var reslt = lstPtsAdj.Select(s => s.styl).ToList();
                    if (lstPtsAdj.Any(s => s.type.Contains("org")))
                    {

                        var mapStylLst = _pointsAdjustment.GetAll( s=> s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.MapStyleID).Distinct().ToList();
                        var dd = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.ToList();
                        var kk = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.ToList();
                        var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty);
                        var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => mapStylLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
                        var sum3 = sum1 + sum2;
                        var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).Min(x => x.OrgMinPoints);
                        var adjstmentPts = minPts - sum3;
                        if (adjstmentPts >= 0)
                        {
                            if (adjstmentPts > 0)
                            {
                                foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                {
                                    styleval.MinPoints = Convert.ToInt32(adjstmentPts);
                                }
                            }

                            else
                            {
                                foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                {
                                    styleval.MinPoints = Convert.ToInt32(0);
                                }
                            }
                            break;

                        }
                        else
                        {
                            foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                            {
                                styleval.MinPoints = Convert.ToInt32(0);
                            }
                            break;
                        }
                    }
                    else
                    {
                        var orgStylLst = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.StyleID).Distinct().ToList();
                        var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => orgStylLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
                        var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty);
                        var sum3 = sum1 + sum2;
                        var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)).Min(x => x.OrgMinPoints);
                        var adjstmentPts = minPts - sum3;
                        if (adjstmentPts >= 0)
                        {
                            if (adjstmentPts > 0)
                            {
                                foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                {
                                    styleval.MinPoints = Convert.ToInt32(adjstmentPts);
                                }
                            }
                            else
                            {
                                foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                {
                                    styleval.MinPoints = Convert.ToInt32(0);
                                }
                            }
                            break;
                        }
                        else
                        {
                            foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                            {
                                styleval.MinPoints = Convert.ToInt32(0);
                            }
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region cartview
        [ValidateInput(false)]
        public ActionResult CartView(string empid = "")
        {
            var newSalesHeader = new List<SalesOrderHeaderViewModel>();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            // var salesOrder = (List<SalesOrderViewModel>)Session["SalesOrder"];
            if (mod.Count > 0)
            {
                var modq = mod.Where(x => x.SalesOrderLine == null || x.SalesOrderLine.Count == 0).FirstOrDefault();
                mod.Remove(modq);
            }
            if (mod.Count == 1)
            {

                return PartialView("_CartView", mod);
            }
            else
            {
                if (Session["clickedEmp"] != null)
                {
                    if (empid != "" || Session["clickedEmp"].ToString() != "")
                    {
                        empid = empid == "" ? Session["clickedEmp"].ToString() : empid;
                        return PartialView("_CartView", mod.Where(x => x.EmployeeID.Trim() == empid).ToList());
                    }
                    else
                    {
                        newSalesHeader.Add(mod.FirstOrDefault());
                        return PartialView("_CartView", newSalesHeader);
                    }
                }
                else
                {
                    if (empid != "")
                    {
                        return PartialView("_CartView", mod.Where(x => x.EmployeeID.Trim() == empid).ToList());
                    }
                    else
                    {
                        newSalesHeader.Add(mod.Last());
                        return PartialView("_CartView", newSalesHeader);
                    }
                }
            }
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

        #region detail grid

        [ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartial(string empId = "")
        {
            List<SalesOrderHeaderViewModel> saleH = new List<SalesOrderHeaderViewModel>();
            var model = new List<SalesOrderLineViewModel>();
            if ((bool)Session["IsBulkOrder1"] == false)
            {
                var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
                if (empId != "")
                {
                    Session["thisEmp"] = empId;
                }
                var buss = Session["BuisnessId"].ToString();
                var salesHeaders = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                var emp = Session["clickedEmp"] == null ? salesHeaders.First().EmployeeID : Session["clickedEmp"].ToString();
                model = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.IsEditing).First().SalesOrderLine.Where(x => x.OriginalLineNo == 0 || x.OriginalLineNo == null).ToList() : empId != "" ? salesHeaders.Where(s => s.EmployeeID == empId).FirstOrDefault().SalesOrderLine.ToList() : salesHeaders.Where(s => s.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(x => x.OriginalLineNo == 0 || x.OriginalLineNo == null).ToList();
                Session["CurrLineNo"] = model.First().LineNo;
                foreach (var data1 in model)
                {
                    //GetlineVat(dat.OrdQty, dat.Price, dat.VatPercent)
                    data1.VAT = Convert.ToBoolean(Session["ISEDITING"]) ? _dataConnection.GetlineVat(data1.OrdQty, data1.Price, _dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent)) : _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                    data1.Total = Convert.ToBoolean(Session["ISEDITING"]) ? _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, _dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent)) : _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
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
                return PartialView("_CartviewDetailGridViewGridViewPartial", model);
            }
            else
            {
                var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
                var buss = Session["BuisnessId"].ToString();
                var salesHeaders = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.IsEditing) : (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                var emp = Session["clickedEmp"] == null ? salesHeaders.First().EmployeeID : Session["clickedEmp"].ToString();
                if (((List<string>)Session["Templates"]).Count > 0)
                {
                    string selTemp = Session["SelectedTemplate"].ToString();
                    //model = selTemp != "" ? salesHeaders.Where(s => s.Template.ToLower() == selTemp.ToLower()).FirstOrDefault().SalesOrderLine.ToList() : new List<SalesOrderLineViewModel>();
                    model = salesHeaders.Where(s => s.IsTemplate).FirstOrDefault().SalesOrderLine.ToList();
                    Session["CurrLineNo"] = model.First().LineNo;
                }
                else if (Session["SelectedUcode"].ToString() != "")
                {
                    string selUcode = Session["SelectedUcode"].ToString();
                    model = Convert.ToBoolean(Session["ISEDITING"]) ? salesHeaders.Where(s => s.IsUcode && s.IsEditing).FirstOrDefault().SalesOrderLine.ToList() : salesHeaders.Where(s => s.IsUcode).FirstOrDefault().SalesOrderLine.ToList();
                }
                Session["CurrLineNo"] = model.First().LineNo;
                foreach (var data1 in model)
                {
                    data1.VAT = Convert.ToBoolean(Session["ISEDITING"]) ? _dataConnection.GetlineVat(data1.OrdQty, data1.Price, _dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent)) : _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                    data1.Total = Convert.ToBoolean(Session["ISEDITING"]) ? _dataConnection.GetlineVat(data1.OrdQty, data1.Price, _dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent)) : _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
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
                return PartialView("_CartviewDetailGridViewGridViewPartial", model);
            }
        }
        #endregion

        #region GetCarriers
        public ActionResult GetCarriers()
        {
            ViewData["carrierFill"] = FillCarrierDropdown();
            ViewData["carrierStyleFill"] = FillCarrierStyle();
            return View("_CarriageandResons");
        }
        #endregion

        #region GetCarriernReasons
        public ActionResult GetCarrierandreason()
        {
            ViewData["carrierFill"] = FillCarrierDropdown();
            ViewData["carrierStyleFill"] = FillCarrierStyle();
            return PartialView("model/_CarriageView");
        }
        #endregion

        #region cart Update

        [HttpPost, ValidateInput(false)]
        public ActionResult CartViewUpdate(SalesOrderHeaderViewModel item)
        {
            var model = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    var dataColl = model.Where(x => x.EmployeeID == item.EmployeeID).ToList();
                    foreach (var data in dataColl)
                    {
                        data.DelAddress1 = item.DelAddress1;
                        data.DelAddress2 = item.DelAddress2;
                        data.DelAddress3 = item.DelAddress3;
                        data.DelDesc = item.DelDesc;
                        data.DelPostCode = item.DelPostCode;
                        data.DelCountry = item.DelCountry;
                        data.DelTown = item.DelTown;
                        data.DelCity = item.DelCity;
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CartView", model);
        }

        #endregion

        #region CartViewDelete
        [HttpPost, ValidateInput(false)]
        public ActionResult CartViewDelete(SalesOrderHeaderViewModel item, string empId = "")
        {
            var model = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

            if (item.EmployeeID != "" | empId != "")
            {
                try
                {
                    var dataColl = model.Where(x => x.EmployeeID == item.EmployeeID | x.EmployeeID.Trim() == empId.Trim()).ToList();
                    foreach (var data in dataColl)
                    {
                        model.Remove(data);
                    }
                    ViewData["headerCount"] = model.Count();
                    // Session["SalesOrderLines"] = model;
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            return PartialView("_CartView", model);
        }

        #endregion

        #region GetMissingPointsDetail
        public void GetMissingPointsDetail()
        {
            var orgStyleNPoints = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);
            var salesHeader = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            string empId = (Session["SelectedEmp"].ToString());
            string busId = Session["BuisnessId"].ToString();
            string ucode = Session["SelectedUcode"].ToString();
            var stylst = orgStyleNPoints.Where(x => x.MinPoints > 0).Select(x => new { x.OrgStyle, x.CatCaption, x.MinPoints });
            var thisHeader1 = salesHeader.Where(x => x.EmployeeID == empId && x.UCodeId == ucode).First();
            string Content = "";
            foreach (var str in stylst.Distinct())
            {
                if (thisHeader1.SalesOrderLine.Any(x => x.orgStyleId == str.OrgStyle))
                {
                    Content = thisHeader1.SalesOrderLine.Where(x => x.orgStyleId == str.OrgStyle).Sum(x => x.OrdQty) >= str.MinPoints ? Content : Content + str.CatCaption + ",";
                }
                else
                {
                    Content = Content + str.CatCaption + ",";
                }
            }
            ViewBag.MissingPoints = "Minimum order qty not satisfied for catagories " + Content;
        }
        #endregion

        #region CartviewDetailGridViewGridViewPartialUpdate

        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialUpdate(Maximus.Data.Models.SalesOrderLineViewModel item)
        {
            var entQty = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault();
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(s=>s.isCarrline==false).ToList();
            var model = result.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();
            string businessId = Session["BuisnessId"].ToString();

            if (ModelState.IsValid)
            {
                if (item.OrdQty.ToString().Trim() == "0")
                {
                    ViewData["EditError"] = "Quantity must be grater than 0";
                }
                else
                {
                    if (Convert.ToBoolean(Session["POINTSREQ"]))
                    {
                        if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles != null)
                        {
                            string ucode = Session["SelectedUcode"].ToString();
                            var style = model.Where(x => x.orgStyleId != null).First().orgStyleId;
                            int minPoints = _pointStyle.Exists(x => x.BusinessID == busId && x.UcodeID == ucode && x.StyleID == style) ? _pointStyle.GetAll(x => x.BusinessID == busId && x.UcodeID == ucode && x.StyleID == style).First().MinPts.Value : 0;
                            //if(item.OrdQty<minPoints)
                            //{
                            //    ViewData["EditError"] = "You cannot order lower than minimum order quantity. The minimum required qty is "+minPoints;
                            //}
                            //else
                            //{
                            var styl = model.Where(s => s.LineNo == item.LineNo).First().StyleID;
                            var otherPts = result.Any(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0) && s.StyleID != styl) ? result.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0) && s.StyleID != styl).Sum(s => s.TotalPoints) : 0;
                            var thisPt = _pointStyle.Exists(x => x.StyleID == styl && x.BusinessID == busId && x.UcodeID == ucode) ? _pointStyle.GetAll(x => x.StyleID == styl && x.BusinessID == busId && x.UcodeID == ucode).First().Points : 0;
                            long updatPts = (thisPt.Value * item.OrdQty) + otherPts;
                            var thisEmp = Session["thisEmp"].ToString();
                            int totAvailPts = _dp.GetTotalSoPoints(busId,thisEmp,0);
                            if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints - totAvailPts - updatPts >= 0)
                            {
                                try
                                {
                                    foreach (var data in model)
                                    {
                                        var parentStyle = model.Where(s => s.LineNo == item.LineNo).First().StyleID;
                                        var assemblyID = _assemblyHeader.Exists(x => x.StyleID == parentStyle && x.CustID == businessId) ? _assemblyHeader.GetAll(x => x.StyleID == parentStyle && x.CustID == businessId).First().AssemblyID : 0;
                                        var qty = assemblyID != 0 ? _assemblyDetail.Exists(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID) ? _assemblyDetail.GetAll(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID).First().Qty.Value : 1 : 1;
                                        data.OrdQty = qty * item.OrdQty;
                                        data.FreeText1 = item.FreeText1;
                                        if (data.OriginalLineNo == null || data.OriginalLineNo == 0)
                                        {
                                            data.TotalPoints = Convert.ToInt32(item.OrdQty) * thisPt.Value;
                                        }
                                    }
                                    foreach (var data1 in result.Where(x => x.LineNo == item.LineNo).ToList())
                                    {
                                        if (Session["Price"].ToString().ToLower() == "readwrite")
                                        {
                                            data1.Price = item.Price == 0 ? data1.Price : item.Price;
                                            data1.VAT = _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                            data1.Total = _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                            if (data1.OriginalLineNo == null || data1.OriginalLineNo == 0)
                                            {
                                                data1.TotalPoints = Convert.ToInt32(data1.OrdQty) * thisPt.Value;
                                            }
                                        }
                                        else
                                        {
                                            data1.VAT = _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                            data1.Total = _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                            if (data1.OriginalLineNo != null || data1.OriginalLineNo == 0)
                                            {
                                                data1.TotalPoints = Convert.ToInt32(data1.OrdQty) * thisPt.Value;
                                            }
                                        }
                                        data1.SOPDetail5 = Session["SopDetail5"] != null ? Session["SopDetail5"].ToString().Split('|')[0].Trim() : data1.SOPDetail5;

                                    }
                                    var stylUpd = model.Where(s => s.OriginalLineNo == null || s.OriginalLineNo == 0).First();
                                    var lstPtsAdj = _pointsAdjustment.Exists(s => s.StyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode) ? _pointsAdjustment.GetAll(s => s.StyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode).Select(x => new pointsChange { styl = x.MapStyleID, type = "MapStyleID" }).ToList() : _pointsAdjustment.Exists(s => s.MapStyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode) ? _pointsAdjustment.GetAll(s => s.MapStyleID == stylUpd.StyleID && s.BusinessID == busId && s.UcodeID == ucode).Select(x => new pointsChange { styl = x.StyleID, type = "orgStyleID" }).ToList() : new List<pointsChange>();
                                    if (lstPtsAdj.Count > 0)
                                    {
                                        var reslt = lstPtsAdj.Select(s => s.styl).ToList();
                                        if (lstPtsAdj.Any(s => s.type.Contains("org")))
                                        {

                                            var mapStylLst = _pointsAdjustment.GetAll(s =>  s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.MapStyleID).Distinct().ToList();
                                            var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                            var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => mapStylLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                            var sum3 = sum1 + sum2;
                                            var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).Min(x => x.OrgMinPoints);
                                            var adjstmentPts = minPts - sum3;
                                            if (adjstmentPts >= 0)
                                            {
                                                if (adjstmentPts > 0)
                                                {
                                                    foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                                    {
                                                        if (minPts > sum2)
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(minPts - sum2);
                                                        }
                                                        else
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(0);
                                                        }
                                                    }
                                                }

                                                else
                                                {
                                                    foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                                    {
                                                        if (minPts > sum2)
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(minPts - sum2);
                                                        }
                                                        else
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(0);
                                                        }
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                                {
                                                    if (minPts > sum2)
                                                    {
                                                        styleval.MinPoints = Convert.ToInt32(minPts - sum2);
                                                    }
                                                    else
                                                    {
                                                        styleval.MinPoints = Convert.ToInt32(0);
                                                    }
                                                }
                                                if (sum1 > 0)
                                                {
                                                    ViewData["alertTxt"] = error;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var orgStylLst = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.StyleID).Distinct().ToList();
                                            var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => orgStylLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                            var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                            var sum3 = sum1 + sum2;
                                            var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)).Min(x => x.OrgMinPoints);
                                            var adjstmentPts = minPts - sum3;
                                            if (adjstmentPts >= 0)
                                            {
                                                if (adjstmentPts > 0)
                                                {
                                                    foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                                    {
                                                        if (minPts > sum2)
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(minPts - sum2);
                                                        }
                                                        else
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(0);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                                    {
                                                        if (minPts > sum2)
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(minPts - sum2);
                                                        }
                                                        else
                                                        {
                                                            styleval.MinPoints = Convert.ToInt32(0);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                                {
                                                    if (minPts > sum2)
                                                    {
                                                        styleval.MinPoints = Convert.ToInt32(minPts - sum2);
                                                    }
                                                    else
                                                    {
                                                        styleval.MinPoints = Convert.ToInt32(0);
                                                    }
                                                }
                                                if (sum1 > 0 && minPts > 0)
                                                {
                                                    ViewData["alertTxt"] = error;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    ViewData["EditError"] = e.Message;
                                }
                                Session["SopDetail5"] = null;
                            }
                            else
                            {
                                ViewData["EditError"] = "Ordered points values exceeds total points";
                            }
                            //}
                        }
                        else if (GetEntitlement(model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().EntQty, model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().ColourID, model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().StyleID, item.OrdQty.ToString(), model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().orgStyleId, item.LineNo) && item.FreeText1 != "")
                        {
                            try
                            {
                                foreach (var data in model)
                                {
                                    var parentStyle = model.Where(s => s.LineNo == item.LineNo).First().StyleID;
                                    var assemblyID = _assemblyHeader.Exists(x => x.StyleID == parentStyle && x.CustID == businessId) ? _assemblyHeader.GetAll(x => x.StyleID == parentStyle && x.CustID == businessId).First().AssemblyID : 0;
                                    var qty = assemblyID != 0 ? _assemblyDetail.Exists(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID) ? _assemblyDetail.GetAll(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID).First().Qty.Value : 1 : 1;
                                    data.OrdQty = qty * item.OrdQty;
                                    data.FreeText1 = item.FreeText1;
                                }
                                foreach (var data1 in result.Where(x => x.LineNo == item.LineNo).ToList())
                                {
                                    if (Session["Price"].ToString().ToLower() == "readwrite")
                                    {

                                        data1.Price = item.Price == 0 ? data1.Price : item.Price;
                                        data1.VAT = _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                        data1.Total = _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                    }
                                    else
                                    {
                                        data1.VAT = _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                        data1.Total = _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                    }
                                    data1.SOPDetail5 = Session["SopDetail5"] != null ? Session["SopDetail5"].ToString().Split('|')[0].Trim() : data1.SOPDetail5;

                                }
                            }
                            catch (Exception e)
                            {
                                ViewData["EditError"] = e.Message;
                            }
                            Session["SopDetail5"] = null;
                        }
                        else
                        {
                            if (item.FreeText1 == "")
                            {
                                ViewData["EditError"] = "Please enter require data";
                            }
                            else
                            {
                                ViewData["EditError"] = "Entitlement exceeded";
                            }
                        }
                    }
                    else
                    {
                        if (GetEntitlement(model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().EntQty, model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().ColourID, model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().StyleID, item.OrdQty.ToString(), model.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).First().orgStyleId, item.LineNo) && item.FreeText1 != "")
                        {
                            try
                            {
                                foreach (var data in model)
                                {
                                    var parentStyle = model.Where(s => s.LineNo == item.LineNo).First().StyleID;
                                    var assemblyID = _assemblyHeader.Exists(x => x.StyleID == parentStyle && x.CustID == businessId) ? _assemblyHeader.GetAll(x => x.StyleID == parentStyle && x.CustID == businessId).First().AssemblyID : 0;
                                    var qty = assemblyID != 0 ? _assemblyDetail.Exists(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID) ? _assemblyDetail.GetAll(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID).First().Qty.Value : 1 : 1;
                                    data.OrdQty = qty * item.OrdQty;
                                    data.FreeText1 = item.FreeText1;
                                }
                                foreach (var data1 in result.Where(x => x.LineNo == item.LineNo).ToList())
                                {
                                    if (Session["Price"].ToString().ToLower() == "readwrite")
                                    {

                                        data1.Price = item.Price == 0 ? data1.Price : item.Price;
                                        data1.VAT = _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                        data1.Total = _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                    }
                                    else
                                    {
                                        data1.VAT = _dataConnection.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                        data1.Total = _dataConnection.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                    }
                                    data1.SOPDetail5 = Session["SopDetail5"] != null ? Session["SopDetail5"].ToString().Split('|')[0].Trim() : data1.SOPDetail5;

                                }
                            }
                            catch (Exception e)
                            {
                                ViewData["EditError"] = e.Message;
                            }
                            Session["SopDetail5"] = null;
                        }
                        else
                        {
                            if (item.FreeText1 == "")
                            {
                                ViewData["EditError"] = "Please enter require data";
                            }
                            else
                            {
                                ViewData["EditError"] = "Entitlement exceeded";
                            }
                        }
                    }
                }
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                GetPointsDiv();
            }
            return PartialView("_CartviewDetailGridViewGridViewPartial", result);
        }
        #endregion

        #region CartviewDetailGridViewGridViewPartialDelete
        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialDelete(SalesOrderLineViewModel item)
        {
            var thisEmp = Session["thisEmp"].ToString();
            string ucode = Session["SelectedUcode"].ToString();
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault();
            var model = result.SalesOrderLine.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();
            // var model = model1
            if (item.LineNo >= 0)
            {
                try
                {
                    if (Convert.ToBoolean(Session["POINTSREQ"].ToString()))
                    {
                        if (Session["StyleMinPoints"] != null)
                        {
                            
                            var styl = model.Where(s => s.OriginalLineNo == null || s.OriginalLineNo == 0).First();
                           
                            var lstPtsAdj = _pointsAdjustment.Exists(s => s.StyleID == styl.StyleID && s.BusinessID == busId && s.UcodeID == ucode) ? _pointsAdjustment.GetAll(s => s.StyleID == styl.StyleID && s.BusinessID == busId && s.UcodeID == ucode).Select(x => new pointsChange { styl = x.MapStyleID, type = "MapStyleID" }).ToList() : _pointsAdjustment.Exists(s => s.MapStyleID == styl.StyleID && s.BusinessID == busId && s.UcodeID == ucode) ? _pointsAdjustment.GetAll(s => s.MapStyleID == styl.StyleID && s.BusinessID == busId && s.UcodeID == ucode).Select(x => new pointsChange { styl = x.StyleID, type = "orgStyleID" }).ToList() : new List<pointsChange>();
                            if (lstPtsAdj.Count > 0)
                            {
                                var reslt = lstPtsAdj.Select(s => s.styl).ToList();
                                if (lstPtsAdj.Any(s => s.type.Contains("org")))
                                {
                                    var mapStylLst = _pointsAdjustment.GetAll(s =>  s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.MapStyleID).Distinct().ToList();
                                    var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                    var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => mapStylLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                      
                                    var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).Min(x => x.OrgMinPoints);
                                    //var deleteQty = sum2 - styl.OrdQty;
                                    //var adjstmentPts = minPts - deleteQty;
                                    if (styl.OrdQty >= 0)
                                    {
                                        if (styl.OrdQty > 0)
                                        {
                                            foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                            {
                                                if (styleval.MinPoints + Convert.ToInt32(styl.OrdQty)<=minPts)
                                                {
                                                    styleval.MinPoints = styleval.MinPoints + Convert.ToInt32(styl.OrdQty);
                                                }
                                            }
                                        }

                                        else
                                        {
                                            foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                            {
                                                styleval.MinPoints = Convert.ToInt32(0);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)))
                                        {
                                            styleval.MinPoints = Convert.ToInt32(0);
                                        }
                                        ViewData["alertTxt"] = error;
                                    }
                                }
                                //else
                                //{
                                //    var orgStylLst = _pointsAdjustment.GetAll().Select(s => s.StyleID).Distinct().ToList();
                                //    var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => orgStylLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                //    var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty);
                                //    var sum3 = sum1 + sum2;
                                //    var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)).Min(x => x.OrgMinPoints);
                                //    var deleteQty = sum3 - styl.OrdQty;
                                //    var adjstmentPts = minPts - deleteQty;
                                //    if (adjstmentPts >= 0)
                                //    {
                                //        if (adjstmentPts > 0)
                                //        {
                                //            //foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                //            //{
                                //            //    styleval.MinPoints = Convert.ToInt32(adjstmentPts);
                                //            //}
                                //        }
                                //        else
                                //        {
                                //            //foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                //            //{
                                //            //    styleval.MinPoints = Convert.ToInt32(0);
                                //            //}
                                //        }
                                //    }
                                //    else
                                //    {
                                //        foreach (var styleval in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgStylLst.Contains(x.Style)))
                                //        {
                                //            styleval.MinPoints = Convert.ToInt32(0);
                                //        }
                                //        ViewData["alertTxt"] = error;
                                //    }
                                //}
                            }
                        }
                    }
                    if(result.SalesOrderLine.Any(x=>x.LineNo==item.LineNo && x.Isedit))
                    {
                        var selectedLine = result.SalesOrderLine.Where(s => s.LineNo == item.LineNo && s.Isedit).First();
                       if(_salesOrderLines.Exists(s=>s.OrderNo==result.OrderNo && s.LineNo==item.LineNo && s.StyleID.ToLower().Trim()== selectedLine.StyleID.ToLower().Trim()))
                        {
                            _salesOrderLines.Delete(s => s.OrderNo == result.OrderNo && s.LineNo == item.LineNo && s.StyleID.ToLower().Trim() == selectedLine.StyleID.ToLower().Trim());
                        }
                        var stockCardQty = result.SalesOrderLine.Where(x => x.LineNo == item.LineNo && x.Isedit).First().SoqtyForempSO;
                        var pointCardQty = result.SalesOrderLine.Where(x => x.LineNo == item.LineNo && x.Isedit).First().SoqtyForempSOPoints;
                        var EmpId = result.SalesOrderLine.Where(x => x.LineNo == item.LineNo && x.Isedit).First().EmployeeId;
                        if (stockCardQty > 0)
                        {
                            var updStock = _stockCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == selectedLine.StyleID).First();
                            updStock.SOQty = updStock.SOQty -Convert.ToInt32(stockCardQty);
                            _stockCard.Update(updStock);
                        }
                        if (pointCardQty > 0)
                        {
                            var updStock = _pointsCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == selectedLine.StyleID).First();
                            updStock.SOPoints = updStock.SOPoints - Convert.ToInt32(pointCardQty);
                            _pointsCard.Update(updStock);
                        }
                    }
                    
                     ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.RemoveAll(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo);
                    ReOrderSalesLines();
                   
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                GetPointsDiv();
            }
            return PartialView("_CartviewDetailGridViewGridViewPartial", result.SalesOrderLine.ToList());
        }
        #endregion
        #region ReOrderSalesLines
        public void ReOrderSalesLines()
        {
            var salesLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine;
            var lineNos = salesLines.Select(x => x.LineNo).ToList();
            int count = 1;
            foreach(var sales in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine)
            {
                if(count==sales.LineNo)
                {

                }
                else
                {
                  
                    if(((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.Any(x=>x.OriginalLineNo== sales.LineNo))
                    {
                        foreach(var salOrgLi in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(x => x.OriginalLineNo == sales.LineNo))
                        {
                            salOrgLi.OriginalLineNo = count;
                        }
                    }
                    sales.LineNo = count;
                }
                count++;
            }

        }
        #endregion

        #region CardDetailAssembly

        [ValidateInput(false)]
        public ActionResult CardDetailAssembly(int LineNo)
        {
            var result = new List<SalesOrderLineViewModel>();
            if (Convert.ToBoolean(Session["IsBulkOrder1"].ToString()))
            {
                if (((List<string>)Session["Templates"]).Count > 0)
                {
                    string selTemp = Session["SelectedTemplate"].ToString();
                    result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsTemplate).FirstOrDefault().SalesOrderLine.ToList();

                }
                else if (Session["SelectedUcode"].ToString() != "")
                {
                    string selUcode = Session["SelectedUcode"].ToString();
                    result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsUcode).FirstOrDefault().SalesOrderLine.ToList();
                }
            }
            else
            {
                result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            }

            var model = result.Where(x => x.OriginalLineNo == LineNo).ToList();
            //string businessId = Session["BuisnessId"].ToString();
            return PartialView("_CardDetailAssembly", model);
        }
        #endregion

        #region FillAllAddress
        public JsonResult FillAllAddress(int descAddId)
        {


            var FillAddressModel = new FillAddressModel();
            var result = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var data = Session["CUSTREFDEF"].ToString();
            var nomCode = Session["ONLINEDEFNOM"].ToString();
            FillAddressModel.BusAdd = result;
            FillAddressModel.custRef = data;
            FillAddressModel.nomCode = nomCode;
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            if (Convert.ToBoolean(Session["IsManPack"].ToString()))
            {
                var sss = Session["clickedEmp"].ToString();
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelDesc = result.AddressDescription;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelAddress1 = result.Address1;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelAddress2 = result.Address2;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelAddress3 = result.Address3;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelCity = result.City;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelCountry = result.Country;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelTown = result.Town;
                mod.Where(x => x.EmployeeID.ToLower() == sss.ToLower()).FirstOrDefault().DelPostCode = result.PostCode;
            }
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FillAllAddresswidCustRef
        public JsonResult FillAllAddresswidCustRef(string custRef, int descAddId = 0, string adddesc = "", string comment = "", string nomCode = "", string nomCode1 = "", string nomCode2 = "", string nomCode3 = "", string nomCode4 = "")
        {
            string emp = "";
            var FillAddressModel = new FillAddressModel();
            var contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
            var result = descAddId == 0 ? adddesc == "" ? new BusAddress1() : ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressDescription == adddesc).First() : ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var contactId = Convert.ToInt32(result.contactId);
            var data = _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
            //Session["SelectedEmp"]

            var nomCoder = Session["ONLINEDEFNOM"].ToString();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            if (Session["clickedEmp"] == null || Session["clickedEmp"].ToString() == "")
            {
                mod.Last().AddressId = descAddId;
                mod.Last().DelAddress1 = result.Address1;
                mod.Last().DelAddress2 = result.Address2;
                mod.Last().DelAddress3 = result.Address3;
                mod.Last().DelCity = result.City;
                mod.Last().DelCountry = result.Country;
                mod.Last().DelDesc = result.AddressDescription;
                mod.Last().DelPostCode = result.PostCode;

                mod.Last().CustRef = data == "" ? custRef == "" ? "" : custRef : data;
                mod.Last().CommentsExternal = comment;
                mod.Last().NomCode = nomCode;
                mod.Last().NomCode1 = nomCode1;
                mod.Last().NomCode2 = nomCode2;
                mod.Last().NomCode3 = nomCode3;
                mod.Last().NomCode4 = nomCode4;
                FillAddressModel.BusAdd = result;
                FillAddressModel.custRef = mod.Last().CustRef;
                FillAddressModel.nomCode = mod.Last().NomCode;
                FillAddressModel.nomCode1 = mod.Last().NomCode1;
                FillAddressModel.nomCode2 = mod.Last().NomCode2;
                FillAddressModel.nomCode3 = mod.Last().NomCode3;
                FillAddressModel.nomCode4 = mod.Last().NomCode4;
                FillAddressModel.CommentExternal = mod.Last().CommentsExternal;
            }
            else
            {
                emp = Session["clickedEmp"].ToString();
                mod.Where(x => x.EmployeeID == emp.Trim()).First().AddressId = result.AddressId;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress1 = result.Address1;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress2 = result.Address2;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress3 = result.Address3;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCity = result.City;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCountry = result.Country;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelDesc = result.AddressDescription;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelPostCode = result.PostCode;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CustRef = custRef == "" ? data : custRef;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CommentsExternal = comment;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode = nomCode;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode1 = nomCode1;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode2 = nomCode2;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode3 = nomCode3;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode4 = nomCode4;
                FillAddressModel.BusAdd = result;
                FillAddressModel.custRef = mod.Where(x => x.EmployeeID == emp.Trim()).First().CustRef;
                FillAddressModel.nomCode = mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode;
                FillAddressModel.nomCode1 = mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode1;
                FillAddressModel.nomCode2 = mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode2;
                FillAddressModel.nomCode3 = mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode3;
                FillAddressModel.nomCode4 = mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode4;
                FillAddressModel.CommentExternal = mod.Where(x => x.EmployeeID == emp.Trim()).First().CommentsExternal;
            }
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SaveRefnAddress
        public void SaveRefnAddress(string custRef, int descAddId = 0, string adddesc = "", string comment = "")
        {
            string emp = "";
            var contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
            var result = descAddId == 0 ? adddesc == "" ? new BusAddress1() : ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressDescription == adddesc).First() : ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var contactId = Convert.ToInt32(result.contactId);
            var data = _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            if (Session["clickedEmp"] == null || Session["clickedEmp"].ToString() == "")
            {

                mod.Last().AddressId = descAddId;
                mod.Last().DelAddress1 = result.Address1;
                mod.Last().DelAddress2 = result.Address2;
                mod.Last().DelAddress3 = result.Address3;
                mod.Last().DelCity = result.City;
                mod.Last().DelCountry = result.Country;
                mod.Last().DelDesc = result.AddressDescription;
                mod.Last().DelPostCode = result.PostCode;
                mod.Last().CustRef = custRef;
                mod.Last().CommentsExternal = comment;

            }
            else
            {
                emp = Session["clickedEmp"].ToString();
                mod.Where(x => x.EmployeeID == emp.Trim()).First().AddressId = descAddId;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress1 = result.Address1;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress2 = result.Address2;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress3 = result.Address3;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCity = result.City;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCountry = result.Country;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelDesc = result.AddressDescription;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelPostCode = result.PostCode;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CustRef = custRef;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CommentsExternal = comment;
            }
        }
        #endregion

        #region AcceptOrders
        public JsonResult AcceptOrder(string addDesc)
        {
            string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
            string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
            string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
            string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
            string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();

            int addressId = 0;
            bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            bool booCheck = true; bool booAutoConfirm = Convert.ToBoolean(Session["AUTOCONFIRM"].ToString()); long mStackManPack = 0;
            bool boolDeleteConfirm = Convert.ToBoolean(Session["boolDeleteConfirm"].ToString());
            bool optNew = false;
            string busId = Session["BuisnessId"].ToString();
            long intSalesOrderNo = 0;
            long intnext = 0;
            string tmpMsg = "";
            bool EditFlag = false;
            bool StrSQL = false;
            long i = 0;
            string mCDate;
            bool booNotSAP = true;
            long intManPackNext = 0;
            string mOrdDate = "";
            string mySqlInv = "";
            string txtOrderNo = "0";
            BusAddress1 invAddress = new BusAddress1();
            bool booEmpPointEntitleCheck = true;
            bool booPE = true;
            bool busBudgetReq = false;
            var ResultSet = new List<SaveOrderResultSet>();
            var AcceptResultSet = new AcceptResultSet();
            bool isPersonalOrder = false;
            double carriage = 0.0;
            List<SalesOrderHeaderViewModel> salesHeaderLst = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            var header = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            TotalModel tot = new TotalModel();
            tot = tot = _dataConnection.GetAlltotals(salesHeaderLst, carriage);
            bool isRollOutOrder = Convert.ToBoolean(Session["RolloutOrder"]);
            bool booExistInManpack = false;
            Session["EditOrdContent"] = "";
            bool booStackOrder;
            bool overrideEntitlement = false;
            overrideEntitlement = Session["OverrideEnt"].ToString().ToUpper().Trim() == "SHOW" ? true : false;
            var HTTP_X_FORWARDED_FOR = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            var REMOTE_ADDR = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
            var lastObj = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();
            booStackOrder = Convert.ToBoolean(_dataConnection.BusinessParam("STACKORDERS", busId));
            int empResetMnths = Session["EmployeeRenew"] != null ? Convert.ToInt32(Session["EmployeeRenew"].ToString()) : 0;
         string permissionPrice=  Session["Price"].ToString();
            string custLogo = Session["LOGO"].ToString();
            var appPath = Request.ApplicationPath;
            string cmpLogo= appPath+ ConfigurationManager.AppSettings["cmpLogo"].ToString();
            try
            {
                AcceptResultSet = _basket.AcceptOrder(cmpId, IsManpack, busId, header, addDesc, isRollOutOrder, Session["OverrideEnt"].ToString(), Convert.ToBoolean(Session["CusRefMan"].ToString()), Session["POINTSREQ"].ToString(), (List<BusAddress1>)Session["DeliveryAddress"], Session["DIFF_MANPACK_INFO"].ToString(), "NOMCODEMAN", Session["ONLNEREQNOM1"].ToString(), Session["ONLNEREQNOM2"].ToString(), Session["ONLNEREQNOM3"].ToString(), Session["ONLNEREQNOM4"].ToString(), Session["ONLNEREQNOM5"].ToString(), Session["RolloutName"].ToString(), Session["selectedcar"].ToString(), Session["UserName"].ToString(), Session["DELADDR_USER_CREATE"].ToString(), Convert.ToDouble(Session["CARRPERCENT"].ToString()), Convert.ToDouble(Session["CARRREQAMT"].ToString()), Session["FITALLOC"].ToString(), Session["DIMALLOC"].ToString(), Session["BUDGETREQ"].ToString(), Browser, REMOTE_ADDR, Session["ONLCUSREFLBL"].ToString(), cmpLogo , Session["LOGO"].ToString(),   adminMail,   mailUsername,   mailPassword,   mailPort,   mailServer, HTTP_X_FORWARDED_FOR, Convert.ToBoolean(Session["ISEDITING"]), boolDeleteConfirm, Session["pnlCarriageReason"].ToString(),Convert.ToBoolean(Convert.ToBoolean(Session["POINTSREQ"])), empResetMnths, permissionPrice);
                
            }
            catch (Exception e)
            {

            }
            return Json(AcceptResultSet, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region checkCarriage
        public bool CheckCarriage(TotalModel tot)
        {
            bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
            bool checkCarriage = false;
             
            checkCarriage = _basket.CheckCarriage(tot, IsManpack, Convert.ToInt32(Session["CARRPERCENT"].ToString()), (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"], Convert.ToDouble(Session["CARRREQAMT"].ToString()),busId);
            return checkCarriage;
        }
        #endregion

        #region GetNavigationUrl
        [HttpPost]
        public string GetNavigationUrl(string data, string addId, string cusrRef, string carr = "", string comment = "", string nomCode = "", string nomCode1 = "", string nomCode2 = "", string nomCode3 = "", string nomCode4 = "")
        {
            string returnUrl = "";
            try
            {
                int address = int.TryParse(addId, out address) == false ? ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressDescription.ToLower().Trim() == addId.ToLower().Trim()).First().AddressId : Convert.ToInt32(addId);
                if ((bool)Session["CusRefMan"])
                {
                    if (addId != "" && cusrRef != "" && data != null)
                    {
                        var salesHead = new SalesOrderHeaderViewModel();

                        salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();

                        var delAdd = ((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == address) ? ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == address).First() : new BusAddress1();
                        salesHead.DelAddress1 = delAdd.Address1;
                        salesHead.DelAddress2 = delAdd.Address2;
                        salesHead.DelAddress3 = delAdd.Address3;
                        salesHead.DelCity = delAdd.City;
                        salesHead.DelCountry = _countryCodes.GetAll(x => x.Country == delAdd.Country).First().CountryID.ToString();
                        salesHead.DelDesc = delAdd.AddressDescription;
                        salesHead.DelPostCode = delAdd.PostCode;
                        salesHead.CustRef = cusrRef;
                        salesHead.Carrier = carr;
                        salesHead.AddressId = address;
                        salesHead.NomCode = nomCode;
                        salesHead.NomCode1 = nomCode1;
                        salesHead.NomCode2 = nomCode2;
                        salesHead.NomCode3 = nomCode3;
                        salesHead.NomCode4 = nomCode4;
                        salesHead.CommentsExternal = comment;
                        if (data == ">")
                        {
                            returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                        }
                        else if (data == "<")
                        {
                            returnUrl = "/Home/Index";
                        }
                    }
                }
                else
                {
                    if (addId != "" && data != null)
                    {
                        var salesHead = new SalesOrderHeaderViewModel();

                        salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();

                        var delAdd = ((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == address) ? ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == address).First() : new BusAddress1();
                        salesHead.DelAddress1 = delAdd.Address1;
                        salesHead.DelAddress2 = delAdd.Address2;
                        salesHead.DelAddress3 = delAdd.Address3;
                        salesHead.DelCity = delAdd.City;
                        salesHead.DelCountry = _countryCodes.GetAll(x => x.Country == delAdd.Country).First().CountryID.ToString();
                        salesHead.DelDesc = delAdd.AddressDescription;
                        salesHead.DelPostCode = delAdd.PostCode;
                        salesHead.CustRef = cusrRef;
                        salesHead.Carrier = carr;
                        salesHead.AddressId = address;
                        salesHead.NomCode = nomCode;
                        salesHead.NomCode1 = nomCode1;
                        salesHead.NomCode2 = nomCode2;
                        salesHead.NomCode3 = nomCode3;
                        salesHead.NomCode4 = nomCode4;
                        salesHead.CommentsExternal = comment;
                        if (data == ">")
                        {
                            returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                        }
                        else if (data == "<")
                        {
                            returnUrl = "/Home/Index";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var salesHead = new List<SalesOrderHeaderViewModel>();
                var emp = Session["clickedEmp"].ToString();
                salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

                salesHead.Where(x => x.EmployeeID == emp).First().NomCode = nomCode;
                salesHead.Where(x => x.EmployeeID == emp).First().NomCode1 = nomCode1;
                salesHead.Where(x => x.EmployeeID == emp).First().NomCode2 = nomCode2;
                salesHead.Where(x => x.EmployeeID == emp).First().NomCode3 = nomCode3;
                salesHead.Where(x => x.EmployeeID == emp).First().NomCode4 = nomCode4;
                salesHead.Where(x => x.EmployeeID == emp).First().CustRef = cusrRef;
                salesHead.Where(x => x.EmployeeID == emp).First().CommentsExternal = comment;

                if (salesHead.Any(x => x.AddressId == 0))
                {

                }
                else
                {
                    if ((bool)Session["CusRefMan"])
                    {
                    }
                    else
                    {
                        if (data == ">")
                        {
                            returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                        }
                        else if (data == "<")
                        {
                            returnUrl = "/Home/Index";
                        }
                    }
                }
            }
            return returnUrl;
        }

        #endregion

        #region get carrier cmbo
        public List<string> FillCarrierDropdown()
        {
            var result = new List<string>();
            result = _dataConnection.GetCarrierCmbValue();
            return result;
        }
        #endregion

        #region Carrier style

        public List<string> FillCarrierStyle()
        {
            var result = new List<string>();
            string busId = Session["BuisnessId"].ToString();
            result = _dataConnection.GetCarrierStyleCmbValue(busId);
            return result;
        }
        #endregion

        #region GetSitecodes
        public List<SiteCodeModel> FillSiteCode()
        {
            var result = _dataConnection.GetSitecodes(Session["BuisnessId"].ToString());
            return result;
        }
        #endregion

        #region FillHeaderDetails
        [HttpPost]
        public JsonResult FillHeaderDetails(string key)
        {
            Session["SelectedRowEmp"] = key.Trim();
            double orgTotal;
            double assemTotal;
            double totalVat = 0.0;
            double Total = 0.0;
            double vat;
            double carriage = 0.0;
            var result = new SalesOrderHeaderViewModel();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            foreach (var header in mod.Where(x => x.SalesOrderLine != null))
            {
                orgTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 ? header.SalesOrderLine.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).Any(x => x.Price != 0) ? header.SalesOrderLine.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0)).Sum(x => x.Price) : 0.0 : 0.0;
                assemTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 && header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Sum(x => x.Price) : 0.0 : 0.0;
                Total = Total + orgTotal + assemTotal;
                foreach (var line in header.SalesOrderLine)
                {
                    double VatPercent = line.VatPercent;
                    ViewBag.VatPercent = VatPercent;
                    double lineVat = line.OrdQty != 0 ? ((line.OrdQty * line.Price) * VatPercent) / 100 : 0.0;
                    totalVat = totalVat + lineVat;
                }

            }
            ViewBag.carriage = Math.Round(carriage, 2);
            ViewBag.ordeTotal = Math.Round(Total + carriage, 2);
            ViewBag.totalVat = Math.Round(totalVat, 2);
            ViewBag.Total = Math.Round(Total, 2);
            ViewBag.GrossTotal = Math.Round(totalVat + Total, 2);
            result = mod.Any(x => x.EmployeeID.Trim() == key.Trim()) ? mod.Where(x => x.EmployeeID.Trim() == key.Trim()).First() : new SalesOrderHeaderViewModel();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region GetEntitlementValue
        public bool GetEntitlement(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "", long lineNo = 0)
        {
            bool result = false;

            if (Session["OverrideEnt"].ToString().ToLower().Trim() != "show")
            {
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsUcode == false && x.IsTemplate == true))
                {
                    return true;
                }
                else
                {
                    if (qty.Trim() != "0")
                    {

                        string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
                        string busId = "";
                        string empId = "";
                        var issuedDiff = 0;
                        var salesOrderLines = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First().SalesOrderLine.Where(x => x.orgStyleId != null).ToList() : ((List<SalesOrderLineViewModel>)Session["SalesOrderLines"]).Where(X => X.orgStyleId != null).ToList();
                        var onCartLst = salesOrderLines.Where(x => x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()).ToList();
                        var onCartVal = onCartLst.Sum(x => x.OrdQty).ToString();
                        if (salesOrderLines.Any(x => x.StyleID == style && x.LineNo == lineNo))
                        {
                            if (salesOrderLines.Where(x => x.StyleID == style && x.LineNo == lineNo).Any(x => x.OrdQty.ToString() == qty))
                            {
                                return true;
                            }
                        }
                        if (color != "" & style != "" & qty != "")
                        {
                            int difference = 0;
                            //int oQty = Convert.ToInt32(ordQty);
                            var entitlement = _ucodes.Exists(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                            var issuedLst = _stockCard.Exists(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()) ? _stockCard.GetAll(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
                            var issued = 0;
                            if (Convert.ToInt32(qty) <= entitlement.Value)
                            {
                                if (Convert.ToInt32(onCartVal) <= entitlement)
                                {

                                    var lineOrd = salesOrderLines.Where(x => x.LineNo == lineNo).First().OrdQty;
                                    var anotherOrd = Convert.ToInt32(onCartVal) - lineOrd;
                                    var newCart = anotherOrd + Convert.ToInt32(qty);
                                    if (newCart > entitlement)
                                    {
                                        return false;
                                    }
                                    else if (newCart <= entitlement)
                                    {
                                        return true;
                                    }
                                }
                                if (issuedLst.Count > 0)
                                {
                                    foreach (var data in issuedLst)
                                    {
                                        issued = issued + data.Invqty + data.Pickqty + data.SOqty;
                                    }
                                }
                                else
                                {
                                    issued = 0;
                                }
                                if (entitlement != 0)
                                {
                                    issuedDiff = entitlement.Value - issued;
                                }
                                if (Convert.ToInt32(onCartVal) != 0)
                                {
                                    if (Convert.ToInt32(onCartVal) != Convert.ToInt32(qty))
                                    {
                                        issuedDiff = (int)issuedDiff - Convert.ToInt32(onCartVal);
                                    }
                                }

                                if (issuedDiff > 0)
                                {
                                    result = Convert.ToInt32(qty) <= issuedDiff ? true : false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return true;
            }
            return result;
        }
        #endregion

        #region EmployeeView
        public ActionResult EmployeeView()
        {
            var result = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).ToList() : (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            return PartialView("model/_EmployeeView", result);
        }
        #endregion

        #region CartDetailEdit
        public JsonResult CartDetailEdit(string empId="")
        {

            Session["clickedEmp"] = empId==""?((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).First().EmployeeID:empId;
            string busId = Session["BuisnessId"].ToString();
            var contactType = 0;
            var resultq = new BusAddress1();
            var contactId = 0;
            List<double> varpercents = new List<double>();
            var resultAdd = _dataConnection.GetDeliveryAddressId(empId, busId, Session["UserName"].ToString());
            double orgTotal = 0.0;
            double assemTotal = 0.0;
            double Total = 0.0;
            double totalVat = 0.0;
            List<double> vatPercents = new List<double>();
            double carriage = 0.0;
            var custRef = "";
            var result1 = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            TotalModel tot = new TotalModel();
            tot = _dataConnection.GetAlltotals(result1.Where(x => x.SalesOrderLine != null && x.EmployeeID == empId).ToList(), carriage);
            var salesHead = result1.Any(x => x.EmployeeID == empId) ? result1.Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
            var FillAddressModel = new FillAddressModel();
            var descAddId = result1.Where(x => x.EmployeeID == empId).First().AddressId;
            var result = new BusAddress1();
            if (descAddId == 0)
            {
                if (((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == resultAdd))
                {
                    result = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == resultAdd).First();
                }
                else if (((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == descAddId))
                {
                    result = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
                }
            }
            var busAdd = new BusAddress1();
            if (salesHead.AddressId > 0)
            {
                var addRes = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == salesHead.AddressId).First();
                busAdd.AddressId = salesHead.AddressId;
                busAdd.Address1 = salesHead.DelAddress1;
                busAdd.Address2 = salesHead.DelAddress2;
                busAdd.Address3 = salesHead.DelAddress3;
                busAdd.City = salesHead.DelCity;
                busAdd.Country = salesHead.DelCountry;
                busAdd.PostCode = salesHead.DelPostCode;
                busAdd.AddressDescription = salesHead.DelDesc;
                var contact = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                var res = ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == salesHead.AddressId).First();
                var conta = Convert.ToInt32(res.contactId);
                custRef = _busContact.Exists(x => x.ContactID == conta && x.ContactType_ID == contact) ? _busContact.GetAll(x => x.ContactID == conta && x.ContactType_ID == contact).First().Value : "";
            }
            var data = result1.Where(x => x.EmployeeID == empId).First().CustRef;
            var nomCode = Session["ONLINEDEFNOM"].ToString();
            if (Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]))
            {
                FillAddressModel.BusAdd = busAdd.AddressId == 0 ? result : busAdd;
                FillAddressModel.custRef = salesHead.CustRef == "" || salesHead.CustRef == null ? custRef : salesHead.CustRef;
            }
            else
            {
                FillAddressModel.BusAdd = busAdd;
                FillAddressModel.custRef = salesHead.CustRef;
                var s = Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]);
            }
            FillAddressModel.nomCode = salesHead.NomCode == "" | salesHead.NomCode == null ? nomCode : salesHead.NomCode;
            FillAddressModel.nomCode1 = salesHead.NomCode1 == "" | salesHead.NomCode1 == null ? nomCode : salesHead.NomCode1;
            FillAddressModel.nomCode2 = salesHead.NomCode2 == "" | salesHead.NomCode2 == null ? nomCode : salesHead.NomCode2;
            FillAddressModel.nomCode3 = salesHead.NomCode3 == "" | salesHead.NomCode3 == null ? nomCode : salesHead.NomCode3;
            FillAddressModel.nomCode4 = salesHead.NomCode4 == "" | salesHead.NomCode4 == null ? nomCode : salesHead.NomCode4;
            FillAddressModel.VatPercent = tot.vatSpan;
            FillAddressModel.carriage = tot.carriage;
            FillAddressModel.ordeTotal = tot.ordeTotal;
            FillAddressModel.totalVat = tot.totalVat;
            FillAddressModel.Total = tot.Total;
            FillAddressModel.GrossTotal = tot.gross;
            FillAddressModel.CommentExternal = salesHead.CommentsExternal;
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPrice
        public JsonResult GetPrice()
        {
            var result1 = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            string empId = Session["clickedEmp"] == null ? result1.First().EmployeeID : Session["clickedEmp"].ToString();
            string busId = Session["BuisnessId"].ToString();
            var resultq = new BusAddress1();
            List<double> varpercents = new List<double>();
            var resultAdd = _dataConnection.GetDeliveryAddressId(empId, busId, Session["UserName"].ToString());
            List<double> vatPercents = new List<double>();
            double carriage = 0.0;
            TotalModel tot = new TotalModel();
            var FillAddressModel = new FillAddressModel();
            tot = _dataConnection.GetAlltotals(result1.Where(x => x.SalesOrderLine != null && x.EmployeeID == empId).ToList(), carriage);
            FillAddressModel.VatPercent = tot.vatSpan;
            FillAddressModel.carriage = tot.carriage;
            FillAddressModel.ordeTotal = tot.ordeTotal;
            FillAddressModel.totalVat = tot.totalVat;
            FillAddressModel.Total = tot.Total;
            FillAddressModel.GrossTotal = tot.gross;
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SetSopDetail5

        public string SetSopDetail5(string SetClientcode)
        {
            string result = "";
            if (SetClientcode != "")
            {
                result = "success";
                Session["SopDetail5"] = SetClientcode;
            }
            return result;
        }
        #endregion

        #region getPtsAdjustmenterror
        public void GetPtsAdjustmenterror()
        {
            string ucodeId = Session["selectedUcodes"].ToString();
            var mapLst = _pointsAdjustment.GetAll(s=> s.BusinessID == busId && s.UcodeID == ucodeId).Select(s => s.MapStyleID).ToList();
            var styLst = _pointsAdjustment.GetAll(s =>  s.BusinessID == busId && s.UcodeID == ucodeId).Select(s => s.StyleID).ToList();
           
            var sumMap = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Where(s => mapLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
            var sumSty = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Where(s => styLst.Contains(s.StyleID)).Sum(s => s.OrdQty);
            var Total = sumMap + sumSty;
            if (((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Any(x => styLst.Contains(x.Style)))
            {

                var sss = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);
                var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => styLst.Contains(x.Style)).Min(x => x.OrgMinPoints);
                if (Total > minPts)
                {
                    if (sumSty > 0)
                    {
                        ViewData["adjustment"] =error;
                    }
                }
                else
                {
                    ViewData["adjustment"] = "";
                }
            }
        }

        #endregion

        #region InsertCarriageLine

        public string InsertCarriageLine(string carrStyle)
        {
            string result = "";
            var carrierStyle = ((List<string>)Session["carrStyle"]);
            string thisEmp= Session["clickedEmp"] != null ? Session["clickedEmp"].ToString(): Session["SelectedEmp"].ToString();
            int newLineNO =Convert.ToInt32(((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().SalesOrderLine.Last().LineNo + 1);
            var salesLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().SalesOrderLine;
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsTemplate == false))
            {
                if (salesLines.Any(x => carrierStyle.Contains(x.StyleID)) == false)
                {
                    SalesOrderLineViewModel saleLinevumodel = new SalesOrderLineViewModel();
                    saleLinevumodel = _basket.GetCarrStyleLine(carrStyle, busId, Convert.ToDouble(Session["CurrencyExchangeRate"]), newLineNO);
                    if (saleLinevumodel != null)
                    {
                        ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().SalesOrderLine.Add(saleLinevumodel);
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
                    saleLinevumodel = _basket.GetCarrStyleLine(styl, busId, Convert.ToDouble(Session["CurrencyExchangeRate"]), newLineNO);
                    if (saleLinevumodel != null)
                    {
                        
                            ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().SalesOrderLine.Add(saleLinevumodel);
                    }
                    result = "added";
                }
            }
            return result;
        }
        #endregion

        #region
        public string DeleteOrder(int orderNo,string empId, bool pointsReq, string busId, string adminMail, string mailUsername, string mailPassword, string mailPort, string mailServer)
        {
            string result = "";
            string userId = Session["UserName"].ToString();
              busId = Session["BuisnessId"].ToString();
              adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
              mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
              mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
              mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
              mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();
              pointsReq =Convert.ToBoolean(Session["POINTSREQ"]);
            result = _basket.DeleteOrder(orderNo, empId, userId, pointsReq, busId, adminMail, mailUsername, mailPassword, mailPort, mailServer) ? "Success":"";
            return result;
        }
        #endregion
    }
}

