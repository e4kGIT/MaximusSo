using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Data.models;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maximus.Helpers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Maximus.Data.Interface.Concrete;
using Maximus.Services.Interface;
using Maximus.Services;
using Maximus.Data.Models;
using Unity;
using Maximus.Data.models.RepositoryModels;

namespace Maximus.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        #region declarations
        //ControllerHelperMethods ctrlHelp = new ControllerHelperMethods();
        AllEnums enus = new AllEnums();
        public string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        [Dependency]
        private readonly IHome _home;
        [Dependency]
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataConnection _dataConnection;
        public readonly AllAssemblies _allAssemblies;
        public readonly AssemblyDetail _assemblyDetail;
        public readonly AssemblyHeader _assemblyHeader;
        public readonly StyleByFreetextView_Emergency _styleFreetxtEmer;
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
        public readonly UcodeOperationsTbl _ucodeOperationsTbl;
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
        public readonly User _user;
        public readonly EmployeeRollout _empRollout;
        public readonly ReturnReasonCodes _returnReasonCodes;
        public readonly TblAlternateTable _tblAlternates;
        public HomeController(IUnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
            HomeService home = new HomeService(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            _home = home;
            StyleColorSize styleColorSize = new StyleColorSize(_unitOfWork);
            tblSalesLines salesOrderLines = new tblSalesLines(_unitOfWork);
            UcodeOperationsTbl ucodeOperationsTbl = new UcodeOperationsTbl(_unitOfWork);
            TblAlternateTable tblAlternates = new TblAlternateTable(_unitOfWork);
            _ucodeOperationsTbl = ucodeOperationsTbl;
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
            StyleByFreetextView_Emergency styleFreetxtEmer = new StyleByFreetextView_Emergency(_unitOfWork);
            _pointsByUcode = pointsByUcode;
            _styleFreetxtEmer = styleFreetxtEmer;
            _pointsAdjustment = pointsAdjustment;
            _pointStyle = pointStyle;
            _pointsCard = pointsCard;
            _ucodeByFreetext = ucodeByFreetext;
            _tblAlternates = tblAlternates;
            _fskSetValues = fskSetValues;
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
        }
        #endregion

        #region Index
        [Authorize]
        public ActionResult Index()
        {
            Session["BulkQtyModel"] = new List<BulkOrderModel>();

            string busId = Session["BuisnessId"].ToString();
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["EmpName"].ToString();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
            {
                if ((bool)Session["IsBulkOrder1"] == false)
                {
                    if (((List<string>)Session["SelectedTemplates"]).Count > 0)
                    {
                        Session["costCenter"] = _home.GetCostCenterTemplate((List<string>)Session["SelectedTemplates"], busId);
                    }
                    else if (Session["selectedUcodes"] != null)
                    {
                        List<string> selUcode = new List<string>();
                        selUcode.Add(Session["selectedUcodes"].ToString());
                        Session["costCenter"] = _home.GetCostCenterUcode(selUcode, busId);
                    }
                    Session["qty"] = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First().SalesOrderLine.Where(s => s.IsDleted == false).Sum(x => x.OrdQty) : ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Where(s => (s.OriginalLineNo == null || s.OriginalLineNo == 0) && s.IsDleted == false).Sum(x => x.OrdQty) : 0 : 0;
                }
                else if ((bool)Session["IsManPack"] == false)
                {
                    if (((List<string>)Session["SelectedTemplates"]).Count > 0)
                    {

                        var salesLine = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.Template != null) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsTemplate) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsTemplate).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsTemplate).First().SalesOrderLine.Where(s => s.IsDleted == false) : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
                        if (salesLine.Count() > 0)
                        {
                            Session["qty"] = salesLine.Where(x => x.OrdQty != 0 && x.IsDleted == false).Sum(x => x.OrdQty);
                        }
                        else
                        {
                            Session["qty"] = 0;
                        }
                    }
                    else
                    {
                        var salesLine = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing && x.UCodeId != null).First().SalesOrderLine.Where(s => s.IsDleted == false) : ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.UCodeId != null) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsUcode) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsUcode).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsUcode).First().SalesOrderLine.Where(s => s.IsDleted == false) : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
                        if (salesLine.Count() > 0)
                        {
                            Session["qty"] = salesLine.Where(x => x.OrdQty != 0 && x.IsDleted == false).Sum(x => x.OrdQty);
                        }
                        else
                        {
                            Session["qty"] = 0;

                        }
                    }

                }

            }
            else
            {
                Session["qty"] = 0;
            }


            if (Convert.ToBoolean(Session["POINTSREQ"]) && Convert.ToBoolean(Session["IsEmergency"]) == false)
            {

                var salesHead = new SalesOrderHeaderViewModel();
                var salesLine = new List<SalesOrderLineViewModel>();
                var salesLineDelted = new List<SalesOrderLineViewModel>();
                int totPoints = 0;
                int inCartPoints = 0;
                int totDelPts = 0;
                int totCardPts = 0;
                int availabelPoints = 0;
                int usedPoints = 0, editPoints = 0, ptsNanCard = 0;
                int previousPoints = 0;
                int totalOtherPoints = 0;
                List<string> lst = new List<string>();
                if (Convert.ToBoolean(Session["ISEDITING"]) == false)
                {

                    ucode = Session["SelectedUcode"].ToString();
                    empId = Session["SelectedEmp"].ToString();
                    salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == empId) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
                    salesLine = salesHead.SalesOrderLine.Where(s => s.IsDleted == false).ToList();
                    Session["Pointsmodel"] = _home.GetPointsModel(Session["selectedUcodes"].ToString(), busId);
                    totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    inCartPoints = salesLine.Count > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                    totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                    availabelPoints = totPoints - inCartPoints - totCardPts;
                    usedPoints = totPoints - availabelPoints;
                }
                else
                {

                    salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First();
                    ucode = salesHead.UCodeId;
                    empId = salesHead.EmployeeID;
                    //foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != salesHead.OrderNo && s.OrderType.ToLower() == "so").ToList())
                    //{
                    //    foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                    //    {
                    //        totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                    //    }
                    //}

                    salesLine = salesHead.SalesOrderLine.Where(sw => sw.IsDleted == false).ToList();
                    salesLineDelted = salesHead.SalesOrderLine.Where(sw => sw.IsDleted == true).ToList();
                    string ucodeDesc = _ucode_Description.Exists(x => x.UCodeID == salesHead.UCodeId) ? _ucode_Description.GetAll(x => x.UCodeID == salesHead.UCodeId).First().Description : salesHead.UCodeId;
                    string ucodeHtml = "<p style=\"padding:0px;\">";
                    ucodeHtml = ucodeHtml + " <span>" + ucode + "</span>-<span>" + ucodeDesc + "</span> ";
                    var lst1 = _ucodeByFreeText.GetAll(x => x.UCodeID == salesHead.UCodeId).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                    Session["UcodeDesc"] = ucodeHtml.ToString();
                    Session["Pointsmodel"] = _home.GetPointsModel(ucode, busId);
                    Session["SelectedEmp"] = salesHead.EmployeeID;
                    Session["EmpName"] = salesHead.EmployeeName;
                    foreach (var data in lst1)
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
                    Session["UcFreeTxt"] = lst.Distinct().ToList();
                    Session["UcodeStyle"] = lst1;
                    Session["SelectedUcode"] = salesHead.UCodeId;
                    totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    inCartPoints = salesLine.Count > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                    totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));

                    foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != salesHead.OrderNo && s.OrderType.ToLower() == "so").ToList())
                    {
                        foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                        {
                            if (_pointStyle.Exists(s => s.StyleID == lien.StyleID && s.UcodeID == ucode))
                            {
                                totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                            }
                        }
                    }

                    totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    inCartPoints = salesLine.Count() > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                    totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                    totDelPts = salesLineDelted.Count > 0 ? salesLineDelted.Sum(x => x.TotalPoints) : 0;
                    ptsNanCard = totPoints - totCardPts;
                    usedPoints = inCartPoints + totalOtherPoints;
                    previousPoints = totCardPts - usedPoints;
                    availabelPoints = ((totPoints - usedPoints) - previousPoints) + totDelPts;
                }

                ViewBag.TotalPoints = totPoints;
                ViewBag.inCartPoints = inCartPoints;
                ViewBag.availabelPoints = availabelPoints;
                ViewBag.usedPoints = totPoints - availabelPoints;
            }
            else if (Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["ISEDITING"]))
            {
                Session["requireemergencyreason"] = true;
                Session["OVERRIDE_ENT_WITH_REASON"] = "show";
                List<string> lst = new List<string>();
                var salesHead = new SalesOrderHeaderViewModel();
                var salesLine = new List<SalesOrderLineViewModel>();
                var salesLineDelted = new List<SalesOrderLineViewModel>();
                salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First();
                ucode = salesHead.UCodeId;
                empId = salesHead.EmployeeID;
                salesLine = salesHead.SalesOrderLine.Where(sw => sw.IsDleted == false).ToList();
                salesLineDelted = salesHead.SalesOrderLine.Where(sw => sw.IsDleted == true).ToList();
                string ucodeDesc = _ucode_Description.Exists(x => x.UCodeID == salesHead.UCodeId) ? _ucode_Description.GetAll(x => x.UCodeID == salesHead.UCodeId).First().Description : salesHead.UCodeId;
                string ucodeHtml = "<p style=\"padding:0px;\">";
                ucodeHtml = ucodeHtml + " <span>" + ucode + "</span>-<span>" + ucodeDesc + "</span> ";
                Session["UcodeDesc"] = ucodeHtml.ToString();
                var lst1 = new List<UcodeModel>();
                var IsHiddenUcode = _ucodeOperationsTbl.Exists(s => s.UcodeId == ucode && s.FreeStkChk && s.IsEmergency) ? _ucodeOperationsTbl.GetAll(s => s.UcodeId == ucode && s.FreeStkChk && s.IsEmergency).First().HasAltStyles : false;
                if (IsHiddenUcode && Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["REQSTKLEVEL"]))
                {
                    lst1= _ucodeByFreeText.GetAll(x => x.UCodeID == salesHead.UCodeId && x.IsHidden==0).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                }
                else
                {
                    lst1= _ucodeByFreeText.GetAll(x => x.UCodeID == salesHead.UCodeId).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                }
               
                Session["UcodeDesc"] = ucodeHtml.ToString();
                Session["Pointsmodel"] = _home.GetPointsModel(ucode, busId);
                Session["SelectedEmp"] = salesHead.EmployeeID;
                Session["EmpName"] = salesHead.EmployeeName;
                foreach (var data in lst1)
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
                Session["UcFreeTxt"] = lst.Distinct().ToList();
                Session["UcodeStyle"] = lst1;
                Session["SelectedUcode"] = salesHead.UCodeId;
            }
            Session["StyleFreeText"] = _fskStyleFreetext.GetAll().ToList();

            Session["StyleByFreetext"] = _styleByFreetext.GetAll().ToList();

            var ucodStylesLst = _dp.UcodeStyles(ucode, busId) == null ? _dp.UcodeStyles(ucode, busId) : (List<string>)_dp.UcodeStyles(ucode, busId);
            if (((List<string>)Session["SelectedTemplates"]).Count == 0)
            {

                Session["PointsAdjustment"] = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).ToList();
                Session["PointsCard"] = _vuPointsCard.GetAll(s => s.EmployeeID == empId && ucodStylesLst.Contains(s.StyleID)).ToList();
                Session["PointsStyle"] = _pointStyle.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).ToList();
                Session["PointsUcode"] = _pointsByUcode.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).ToList();
            }
            return View();
        }
        #endregion

        #region emergencyOrder
        #endregion

        #region  
        #endregion

        #region getting all groups for checkboxlist
        public ActionResult GetAllGroups()
        {
            string busId = Session["BuisnessId"].ToString();

            try
            {
                if (Session["UcodeStyle"] != null)
                {
                    List<UcodeModel> UcodeStyle = (List<UcodeModel>)Session["UcodeStyle"];
                    List<string> UcodeStyle1 = new List<string>();
                    UcodeStyle1 = UcodeStyle.Select(x => x.StyleId).ToList();
                    var groups = _tblFskStyle.GetAll(x => UcodeStyle1.Contains(x.StyleID)).Select(x => x.Product_Group.Value).ToList();
                    var result = _styleGroups.GetAll(x => x.Description != "" && groups.Contains(x.GroupID)).ToList();
                    return PartialView("_getAllGroups", result);
                }
                else if (((List<string>)Session["SelectedTemplates"]).Count > 0)
                {
                    var result1 = (List<string>)Session["SelectedTemplates"];
                    var model = new List<int>();
                    if (result1.Count > 0)
                    {
                        foreach (var item in result1)
                        {
                            model.AddRange(_dataConnection.GetProductGroup(item));
                        }
                        var result = _styleGroups.GetAll(x => x.Description != "" && model.Contains(x.GroupID)).ToList();
                        return PartialView("_getAllGroups", result);
                    }
                    else
                    {
                        return PartialView("_getAllGroups", new List<int>());
                    }
                }
                else
                {


                    var result = Convert.ToBoolean(Session["ISEDITING"]) ? new List<tblfsk_style_groups>() : _styleGroups.GetAll(x => x.Description != "").ToList();
                    return PartialView("_getAllGroups", result);
                }


            }
            catch (Exception e)
            {
                logger .Warn(e.Message);logger.Warn(e.StackTrace);; logger.Warn(e.StackTrace);
                return null;
            }


        }
        #endregion

        #region Cardview
        [ValidateInput(false)]

        //public ActionResult CardViewPartial(string ColorId = "", string StyleID = "", string SizeId = "", decimal Price = 0, string Description = "", List<int> selectedItem = null, bool pages = false, bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        public ActionResult CardViewPartial(List<int> selectedItem = null, bool pages = false, string filterText = "", bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = new List<styleViewmodel>();
            var svm = new styleViewmodel();
            string businessId = Session["BuisnessId"].ToString();
            if (((List<string>)Session["Templates"]).Count > 0)
            {
                List<string> result = (List<string>)Session["SelectedTemplates"];
                foreach (var item in result)
                {
                    model.AddRange(_dataConnection.GetStyleViewModel(item, businessId));
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                foreach (var data1 in model)
                {
                    data1.Assembly = _customAssembly.Exists(d => d.ParentStyleID == data1.StyleID & d.isChargeable == false & d.CustID == businessId) |
                            _allAssemblies.Exists(d => d.ParentStyleID == data1.StyleID & d.isChargeable == false) ? 1 : 0;
                    data1.Description = _tblFskStyle.GetAll(x => data1.OriginalStyleid.Contains(x.StyleID)).First().Description;
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                }

                foreach (var data1 in model)
                {

                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
                if (filterText != "")
                {
                    model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower())) ? model.Where(x => x.StyleID.ToLower().Contains(filterText.ToLower())).ToList() : null;
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                if (BringImages | Session["ImageFilter"] != null)
                {
                    if (BringImages | (bool)Session["ImageFilter"] != null)
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                if (selectedItem != null)
                {
                    model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.ProductGroup,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = x.Assembly,
                        ColourId = x.ColourId,
                        SizeId = x.SizeId,
                        isAllocated = x.isAllocated,
                        Dimensions = x.Dimensions,
                        Freetext = x.Freetext,
                        SeqNO = x.SeqNO,
                        OriginalStyleid = x.StyleID,
                        HasPreviousSize = x.HasPreviousSize,
                        Description = x.Description,
                        Caption = x.Caption,
                        Price = x.Price
                    }).ToList();
                }
            }
            else
            {
                try
                {
                    var freetext = Allocation.DIMALLOC.ToString();

                    string custId = Session["BuisnessId"].ToString();
                    int tempCount = ((List<UcodeModel>)Session["UcodeStyle"]) != null ? ((List<UcodeModel>)Session["UcodeStyle"]).Count : 0;
                    Session["Selected"] = selectedItem;
                    ViewBag.page = pages;
                    if (tempCount > 0)
                    {
                        string ucode = "";
                        List<string> freeTextLst = new List<string>();
                        freeTextLst = (List<string>)Session["UcFreeTxt"];
                        ucode = Session["SelectedUcode"].ToString();
                        model = _ucodeByFreeText.GetAll(x => freeTextLst.Contains(x.FreeText) && x.UCodeID == ucode).ToList().Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                            Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false & d.CustID == custId) |
                              _allAssemblies.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false) ? 1 : 0,
                            //Assembly = _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                            isAllocated = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                            // Dimensions = x.FreeText
                            Dimensions = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                            SeqNO = x.SeqNo.Value,
                            Freetext = x.FreeText,
                            OriginalStyleid = x.StyleID.Contains(',') ? x.StyleID.Split(',')[0] : x.StyleID
                        }).ToList();
                        if (Convert.ToBoolean(Session["ISEDITING"]))
                        {
                            foreach (var line in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First().SalesOrderLine.Where(s => s.IsDleted == false))
                            {
                                foreach (var dataval in model)
                                {
                                    if (_dimension1.Exists(s => s.FreeText.ToLower() == dataval.Dimensions.ToLower() && s.freetexttype.ToLower().Contains("dim") && s.StyleId == line.StyleID))
                                    {
                                        line.orgStyleId = dataval.OriginalStyleid;
                                    }

                                }
                            }
                        }


                        model = _ucodeByFreeText.GetAll(x => freeTextLst.Contains(x.FreeText) && x.UCodeID == ucode).ToList().Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                            Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false & d.CustID == custId) |
                               _allAssemblies.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false) ? 1 : 0,
                            //Assembly = _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                            isAllocated = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                            // Dimensions = x.FreeText
                            Dimensions = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                            SeqNO = x.SeqNo.Value,
                            Freetext = x.FreeText,
                            OriginalStyleid = x.StyleID.Contains(',') ? x.StyleID.Split(',')[0] : x.StyleID
                        }).ToList();
                        if (Convert.ToBoolean(Session["ISEDITING"]))
                        {
                            foreach (var line in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).First().SalesOrderLine.Where(s => s.IsDleted == false))
                            {
                                foreach (var dataval in model)
                                {
                                    if (_dimension1.Exists(s => s.FreeText.ToLower() == dataval.Dimensions.ToLower() && s.freetexttype.ToLower().Contains("dim") && s.StyleId == line.StyleID))
                                    {
                                        line.orgStyleId = dataval.OriginalStyleid;
                                    }

                                }
                            }
                        }

                        if (selectedItem != null)
                        {
                            model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                            {
                                StyleID = x.StyleID,
                                ProductGroup = x.ProductGroup,
                                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                                Assembly = x.Assembly,
                                ColourId = x.ColourId,
                                SizeId = x.SizeId,
                                isAllocated = x.isAllocated,
                                Dimensions = x.Dimensions,
                                Freetext = x.Freetext,
                                SeqNO = x.SeqNO,
                                OriginalStyleid = x.StyleID,
                                HasPreviousSize = x.HasPreviousSize,
                                Description = x.Description,
                                Caption = x.Caption,
                                Price = x.Price
                            }).ToList();
                        }
                        foreach (var data1 in model)
                        {
                            data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : _dataConnection.GetFitAllocString(data1.Freetext);
                        }

                        foreach (var data1 in model)
                        {
                            data1.Reqdata = _dataConnection.GetReqData(data1.OriginalStyleid);
                            data1.Description = _tblFskStyle.GetAll(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                            if (!data1.StyleID.Contains(","))
                            {
                                data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                            }
                            else
                            {
                                data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                            }
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
                        if (filterText != "")
                        {

                            model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())) ? model.Where(x => x.StyleID.ToLower().Trim().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())).ToList() : new List<styleViewmodel>();
                        }
                        model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                        if (BringImages)
                        {
                            model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                        }
                    }
                }
                catch (Exception e)
                {
                    logger .Warn(e.Message);logger.Warn(e.StackTrace); logger.Warn("inner exception:"+e.InnerException);  
                }
            }
            return PartialView("_CardViewPartial", model.Distinct());
        }
        #endregion

        #region assembly
        public ActionResult AssemblyInfo(string styleId)
        {
            Session["assemList"] = new List<string>();
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            try
            {
                var custId = Session["BuisnessId"].ToString();
                var result = _home.GetAssemblyInfo(styleId, appPath, custId);
                return PartialView("_AssemblyInfo", result);
            }
            catch (Exception e)
            {
                logger .Warn(e.Message);logger.Warn(e.StackTrace);;
            }
            return null;
        }
        #endregion

        #region GetPrice based on styleid and colorid
        public decimal GetPrice(string StyleID = "", string SizeId = "")
        {
            if (Session["PriceList"] != null)
            {
                return _home.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString(), Session["PriceList"].ToString());
            }
            else
            {
                return _home.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString(), "");
            }
        }

        public decimal GetBulkPrice(int qty, string style = "", string size = "")
        {
            return _home.GetBulkPrice(qty, style, size, Session["BuisnessId"].ToString());
        }

        #endregion

        #region GetPriceStats
        public string GetPriceStats()
        {
            var s = Session["Price"].ToString().ToLower();
            return Session["Price"].ToString().ToLower();
        }
        #endregion

        #region GetAllColors
        public List<string> getAllcolours(string style)
        {
            return _home.GetAllcolours(style);
        }

        #endregion

        #region get Description
        public JsonResult DrpResultModel(string styleId, string color)
        {
            var priceLst = new List<SizePrice>();
            var result = new DrpResultModel();
            //var selUcode = Session["SelectedUcode"].ToString();
            result.Description = _tblFskStyle.GetAll(x => x.StyleID == styleId).First().Description;
            if (_styleColorSizeObsolete.Exists(x => x.StyleID == styleId && x.ColourID.ToLower() == color.ToLower()) != true)
            {

                if ((bool)Session["IsManPack"] == true)
                {
                    result.SizeList = (List<string>)_style_Sizes.GetAll(s => s.StyleID == styleId).Distinct().OrderBy(s => s.SeqNo).Select(s => s.SizeID).ToList();
                    result.Price = result.SizeList.Count > 1 ? 0 : GetPrice(styleId, result.SizeList[0]);
                    result.isBulk = Convert.ToBoolean(Session["IsBulkOrder"].ToString());
                    result.isManpack = Convert.ToBoolean(Session["IsManPack"].ToString());
                }
                else
                {
                    result.HasReqData = _dataConnection.GetReqData(styleId) == "" ? false : true;
                    result.ReqData = _dataConnection.GetReqData(styleId);
                    result.isBulk = Convert.ToBoolean(Session["IsBulkOrder"].ToString());
                    result.isManpack = Convert.ToBoolean(Session["IsManPack"].ToString());
                    result.SizeList = (List<string>)_style_Sizes.GetAll(s => s.StyleID == styleId).Distinct().OrderBy(s => s.SeqNo).Select(s => s.SizeID).ToList();
                    try
                    {
                        foreach (var size in result.SizeList)
                        {
                            priceLst.Add(new SizePrice { Size = size, Price = _dataConnection.GetPrice(styleId, size, Session["BuisnessId"].ToString()).ToString("0.00"), Currency = Session["CurrencySymbol"].ToString() });
                        }
                    }
                    catch (Exception e)
                    {
                        logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                    }
                    result.PriceList = priceLst;
                }
            }
            else
            {

                if ((bool)Session["IsBulkOrder"] == true || (bool)Session["IsBulkOrder1"] == true)
                {
                    result.isBulk = Convert.ToBoolean(Session["IsBulkOrder"].ToString());
                    result.isManpack = Convert.ToBoolean(Session["IsManPack"].ToString());
                    result.HasReqData = _dataConnection.GetReqData(styleId) == "" ? false : true;
                    result.ReqData = _dataConnection.GetReqData(styleId);
                    result.SizeList = (List<string>)_styleColorSizeObsolete.GetAll(s => s.StyleID == styleId && s.Obsolete_Class == 0 && s.ColourID.ToLower() == color.ToLower()).Distinct().Select(s => s.SizeID).ToList();
                    var data1 = _style_Sizes.GetAll(x => x.StyleID == styleId).OrderBy(x => x.SeqNo).Select(x => x.SizeID).ToList();
                    if (result.SizeList.Count != data1.Count)
                    {
                        List<string> datar = (data1.Except(result.SizeList)).ToList();
                        foreach (string s in datar)
                        {
                            data1.Remove(s);
                        }
                        result.SizeList = data1;
                        foreach (var size in result.SizeList)
                        {
                            priceLst.Add(new SizePrice { Size = size, Price = _dataConnection.GetPrice(styleId, size, Session["BuisnessId"].ToString()).ToString("0.00"), Currency = Session["CurrencySymbol"].ToString() });
                        }
                        result.PriceList = priceLst;
                    }
                    else
                    {
                        result.SizeList = data1;
                        foreach (var size in result.SizeList)
                        {
                            priceLst.Add(new SizePrice { Size = size, Price = _dataConnection.GetPrice(styleId, size, Session["BuisnessId"].ToString()).ToString("0.00"), Currency = Session["CurrencySymbol"].ToString() });
                        }
                        result.PriceList = priceLst;
                    }

                }
                else
                {
                    result.isBulk = Convert.ToBoolean(Session["IsBulkOrder"].ToString());
                    result.isManpack = Convert.ToBoolean(Session["IsManPack"].ToString());
                    result.SizeList = (List<string>)_styleColorSizeObsolete.GetAll(s => s.StyleID == styleId && s.Obsolete_Class == 0 && s.ColourID.ToLower() == color.ToLower()).Distinct().Select(s => s.SizeID).ToList();
                    var data = _style_Sizes.GetAll(x => x.StyleID == styleId).OrderBy(x => x.SeqNo).Select(x => x.SizeID).ToList();
                    if (result.SizeList.Count != data.Count)
                    {
                        List<string> datar = (data.Except(result.SizeList)).ToList();
                        foreach (string s in datar)
                        {
                            data.Remove(s);
                        }
                        result.SizeList = data;
                    }
                    else
                    {
                        result.SizeList = data;
                    }
                    result.Price = result.SizeList.Count > 1 ? GetPrice(styleId, result.SizeList[0]) : 0;
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetModel
        public ActionResult GetFilter()
        {
            List<int> selectedList = (List<int>)Session["Selected"];
            var data = new FilterModel();
            List<UcodeModel> UcodeStyle = (List<UcodeModel>)Session["UcodeStyle"];
            List<string> UcodeStyle1 = new List<string>();
            UcodeStyle1 = UcodeStyle != null ? UcodeStyle.Select(x => x.StyleId).ToList() : new List<string>();
            List<int> groups = new List<int>();
            if (UcodeStyle != null)
            {
                groups = _tblFskStyle.GetAll(x => UcodeStyle1.Contains(x.StyleID)).Select(x => x.Product_Group.Value).ToList();
            }
            if (selectedList == null && (groups == null | groups.Count == 0))
            {
                data.ColorIdList = _stylesView.GetAll(x => x.Description != "").Select(x => x.ColourID).Distinct().ToList();
                data.SizeIdList = _stylesView.GetAll(x => x.Description != "").Select(x => x.SizeID).Distinct().ToList();
                data.StyleIDList = _stylesView.GetAll(x => x.Description != "").Select(x => x.StyleID).Distinct().ToList();
            }
            else
            {
                if (selectedList != null && (groups == null | groups.Count == 0))
                {
                    data.ColorIdList = _stylesView.GetAll(x => x.Description != "" & selectedList.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.ColourID).Distinct().ToList();
                    data.SizeIdList = _stylesView.GetAll(x => x.Description != "" & selectedList.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.SizeID).Distinct().ToList();
                    data.StyleIDList = _stylesView.GetAll(x => x.Description != "" & selectedList.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.StyleID).Distinct().ToList();
                }
                else if (selectedList == null && (groups != null | groups.Count > 0))
                {
                    data.ColorIdList = _stylesView.GetAll(x => x.Description != "" & groups.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.ColourID).Distinct().ToList();
                    data.SizeIdList = _stylesView.GetAll(x => x.Description != "" & groups.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.SizeID).Distinct().ToList();
                    data.StyleIDList = _stylesView.GetAll(x => x.Description != "" & groups.Contains(x.Product_Group.Value) & UcodeStyle1.Contains(x.StyleID)).Select(x => x.StyleID).Distinct().ToList();
                }
                else
                {
                    data.ColorIdList = _stylesView.GetAll(x => x.Description != "" & (groups.Contains(x.Product_Group.Value) | selectedList.Contains(x.Product_Group.Value))).Select(x => x.ColourID).Distinct().ToList();
                    data.SizeIdList = _stylesView.GetAll(x => x.Description != "" & (groups.Contains(x.Product_Group.Value) | selectedList.Contains(x.Product_Group.Value))).Select(x => x.SizeID).Distinct().ToList();
                    data.StyleIDList = _stylesView.GetAll(x => x.Description != "" & (groups.Contains(x.Product_Group.Value) | selectedList.Contains(x.Product_Group.Value))).Select(x => x.StyleID).Distinct().ToList();

                }

            }
            return PartialView("_FilterModel", data);
        }

        #endregion

        #region GetDimAlloc
        public ActionResult GetDimAlloc(string freeText)
        {
            ViewBag.page = false;
            //freeText = "ADC BOOT";
            var sv1 = new styleViewmodel();
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var result = new List<styleViewmodel>();
            var freeTxtType = Allocation.DIMALLOC.ToString();
            List<string> freeTxtLst2 = new List<string>();
            var freeTxtLst = _ucodeByFreetext.GetAll(x => x.DimFreeText == freeText).Select(x => x.FreeText).Distinct().ToList();
            var styleLst = new List<string>();
            if (freeTxtLst.Count < 2)
            {
                styleLst.AddRange(_fskStyleFreetext.GetAll(x => x.FreeText == freeText && x.FreeTextType == freeTxtType).Select(x => x.StyleId).ToList());
            }
            else
            {
                foreach (var fretxt in freeTxtLst)
                {
                    styleLst.Add(_dataConnection.getStyleFromFretxt(fretxt));
                }
            }

            if (Session["onDemand"] != null && (bool)Session["onDemand"] == true)
            {
                var result1 = _fskStyleFreetext.GetAll(x => x.FreeText == freeText & x.FreeTextType == freeTxtType).Select(x => x.StyleId).ToList();
                //var s = (bool)Session["onDemand"];_StyleByCardPop
                return PartialView("_DimAllocDemandPartial", result1);
                //return PartialView("_StyleByCardPop", result1);
            }
            else
            {
                try
                {
                    foreach (var styles in styleLst)
                    {
                        styleViewmodel svm = new styleViewmodel();
                        svm = _dataConnection.GetDimallocStyles(styles);
                        if (styles.Contains(","))
                        {
                            svm.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), styles);
                        }
                        else
                        {
                            svm.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), styles.Split(',')[0]);
                        }
                        if (svm != null)
                        {
                            result.Add(svm);
                        }
                    }
                }
                catch (Exception e)
                {
                    logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                }
                foreach (var data1 in result)
                {
                    //data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : _dataConnection.GetFitAllocString(data1.Freetext);
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
                return PartialView("_DimAllocPartial", result);
            }
        }
        #endregion

        #region getCardAlternate
        public ActionResult GetCardAlternateStyle(string StyleID, string BannerStyle)
        {
            List<styleViewmodel> model = new List<styleViewmodel>();
            try
            {
                styleViewmodel svm = new styleViewmodel();
                if (_tblFskStyle.Exists(x => x.StyleID == StyleID))
                {
                    svm = _tblFskStyle.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID) ? _customAssembly.Exists(d => d.ParentStyleID == x.StyleID && d.isChargeable == false) ? 1 : 0 : 0,
                        OriginalStyleid = BannerStyle,
                    }).FirstOrDefault();
                }
                model.Add(svm);
                foreach (var data1 in model)
                {
                    data1.Reqdata = _dataConnection.GetReqData(data1.StyleID);
                    data1.HasPreviousSize = new PreviousQty();
                }
            }
            catch(Exception e)
            {
                logger .Warn(e.Message);logger.Warn(e.StackTrace);;
            }
            return PartialView("_StyleByCardPop", model);

        }
        #endregion

        #region getBannerStyles
        public List<BannerStyleClrSiz> GetBannerSizes(string StyleID)
        {
            List<BannerStyleClrSiz> result = new List<BannerStyleClrSiz>();
            if (_tblAlternates.Exists(s => s.StyleId == StyleID))
            {
                result = _tblAlternates.GetAll(s => s.StyleId == StyleID).Select(s => new BannerStyleClrSiz { BannerStyle = s.StyleId, BannerColour = s.ColourId, BannerSize = s.SizeId, UeColor = s.AltColourId, UeStyle = s.AltStyleId, UeSize = s.AltSizeId }).ToList();
                result.ForEach(s => s.IsBannerObsolete = _styleColorSizeObsolete.Exists(a => a.ColourID == s.BannerColour && a.SizeID == s.BannerSize && a.StyleID == s.BannerStyle) ? _styleColorSizeObsolete.GetAll(a => a.ColourID == s.BannerColour && a.SizeID == s.BannerSize && a.StyleID == s.BannerStyle).First().Obsolete_Class == 0 ? false : true : false);
            }
            return result;
        }
        #endregion

        #region  getCard
        public ActionResult GetCard(string StyleID, string Orgstyle, string caption = "",string Privatesize="",string PrivateColour="",int PrivateOrdQty=1)
        {
            //StyleID = "TSB LJ1/L";
            Session["CatagoryCaption"] = caption;
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            string ucode = Session["SelectedUcode"].ToString();

            var hasFit = _fskStyleFreetext.GetAll(x => x.StyleId == StyleID).Any(x => x.FreeTextType == "FITALLOC") ? _fskStyleFreetext.GetAll(x => x.StyleId == StyleID & x.FreeTextType == "FITALLOC").First().FreeText : "";
            List<styleViewmodel> model = new List<styleViewmodel>();
            if (Session["isrtntype"].ToString() != "PRIVATE")
            {
                if (hasFit == "")
                {
                    try
                    {
                        styleViewmodel svm = new styleViewmodel();
                        svm = _ucodeByFreetext.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                            Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID) ? _customAssembly.Exists(d => d.ParentStyleID == x.StyleID && d.isChargeable == false) ? 1 : 0 : 0,
                            OriginalStyleid = Orgstyle
                        }).FirstOrDefault();
                        if (svm == null && Convert.ToBoolean(Session["IsEmergency"]) == false)
                        {
                            svm = _styleByFreetext.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                            {
                                StyleID = x.StyleID,
                                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                                Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID) ? _customAssembly.Exists(d => d.ParentStyleID == x.StyleID && d.isChargeable == false) ? 1 : 0 : 0,
                                OriginalStyleid = Orgstyle
                            }).FirstOrDefault();
                        }
                        if (svm == null)
                        {
                            svm = _styleFreetxtEmer.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                            {
                                StyleID = x.StyleID,
                                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                                Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID) ? _customAssembly.Exists(d => d.ParentStyleID == x.StyleID && d.isChargeable == false) ? 1 : 0 : 0,
                                OriginalStyleid = Orgstyle
                            }).FirstOrDefault();
                        }

                        if (svm != null)
                        {
                            model.Add(svm);
                        }
                    }
                    catch (Exception e)
                    { logger.Warn(e.Message); logger.Warn(e.StackTrace); ; }
                    foreach (var data1 in model)
                    {
                        data1.Reqdata = _dataConnection.GetReqData(data1.StyleID);
                        if (!data1.StyleID.Contains(","))
                        {
                            if (Convert.ToBoolean(Session["IsBulkOrder1"]) == false)
                            {
                                data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                            }
                            else
                            {
                                data1.HasPreviousSize = new PreviousQty();
                            }
                        }
                        else
                        {
                            if (Convert.ToBoolean(Session["IsBulkOrder1"]) == false)
                            {
                                data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                            }
                            else
                            {
                                data1.HasPreviousSize = new PreviousQty();
                            }

                        }
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
                }
                else
                {
                    string style = "";
                    var curStyle = _styleByFreetext.GetAll(x => x.FreeText == hasFit).Select(x => x.StyleID).FirstOrDefault();

                    var s11 = _styleByFreetext.GetAll(x => x.FreeText == hasFit).FirstOrDefault();

                    var S1 = _ucodeByFreetext.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                    {
                        StyleID = curStyle,
                        ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID && d.isChargeable == false).Any() ? 1 : 0 : 0,
                        OriginalStyleid = Orgstyle
                    }).FirstOrDefault();
                    if (S1 != null)
                    {
                        model.Add(new styleViewmodel
                        {
                            StyleID = curStyle,
                            ProductGroup = S1.ProductGroup,
                            StyleImage = S1.StyleImage,
                            Assembly = S1.Assembly,
                            OriginalStyleid = Orgstyle
                        });
                    }
                    else
                    {
                        model.Add(new styleViewmodel
                        {
                            StyleID = curStyle,
                            ProductGroup = s11.Product_Group != null ? s11.Product_Group.Value : 0,
                            StyleImage = s11.StyleImage == "" | s11.StyleImage == null ? "/StyleImages/notfound.png" : s11.StyleImage,
                            Assembly = _customAssembly.GetAll(d => d.ParentStyleID == s11.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == s11.StyleID && d.isChargeable == false).Any() ? 1 : 0 : 0,
                            OriginalStyleid = Orgstyle
                        });

                    }
                    foreach (var data1 in model)
                    {
                        data1.Reqdata = _dataConnection.GetReqData(data1.StyleID);
                        if (!data1.StyleID.Contains(","))
                        {
                            if (Convert.ToBoolean(Session["IsBulkOrder1"]) == false)
                            {
                                data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.OriginalStyleid);
                            }
                            else
                            {
                                data1.HasPreviousSize = new PreviousQty();
                            }
                        }
                        else
                        {
                            if (Convert.ToBoolean(Session["IsBulkOrder1"]) == false)
                            {
                                data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                            }
                            else
                            {
                                data1.HasPreviousSize = new PreviousQty();
                            }
                        }
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
            }
            else if(Session["isrtntype"].ToString()=="PRIVATE")
            {
                try
                {
                    styleViewmodel svm = new styleViewmodel();
                    if (_tblFskStyle.Exists(x => x.StyleID == StyleID))
                    {
                        svm = _tblFskStyle.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                            Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID) ? _customAssembly.Exists(d => d.ParentStyleID == x.StyleID && d.isChargeable == false) ? 1 : 0 : 0,
                            OriginalStyleid = x.StyleID,
                        }).FirstOrDefault();
                       
                    }
                    model.Add(svm);
                    foreach (var data1 in model)
                    {
                        data1.Reqdata = _dataConnection.GetReqData(data1.StyleID);
                        data1.HasPreviousSize = new PreviousQty();
                    }
                    ViewBag.PRIVATESIZE = Privatesize;
                    ViewBag.PRIIVATEORDQTY = PrivateOrdQty;
                    ViewBag.PRIIVATECOLOUR = PrivateColour;
                }
                catch (Exception e)
                {
                    logger.Warn(e.Message); logger.Warn(e.StackTrace); ;
                }
               
            }
            return PartialView("_StyleByCardPop", model);
        }

        #endregion

        #region ondemandCards
        public ActionResult GetcardOnDemand(string StyleID)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            string ucode = Session["SelectedUcode"].ToString();
            List<styleViewmodel> model = new List<styleViewmodel>();
            model.Add(_ucodeByFreetext.GetAll(x => x.StyleID == StyleID).Select(x => new styleViewmodel
            {
                StyleID = x.StyleID,
                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                Assembly = _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID && d.isChargeable == false).Any() ? 1 : 0 : 0
            }).FirstOrDefault());
            foreach (var data1 in model)
            {
                if (!data1.StyleID.Contains(","))
                {
                    data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                }
                else
                {

                    data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);

                }
                if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                {
                    data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                }
                else
                {
                    data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                }
            }
            return PartialView("_StyleByCardPop", model);
        }
        #endregion

        #region GetSelectedColourSizes
        public JsonResult GetSelectedColourSizes(string Style, string Color)
        {

            var result = _styleColorSizeObsolete.GetAll(x => x.StyleID == Style & x.ColourID == Color && (x.Obsolete_Class == 4)).Distinct().Select(x => x.SizeID).ToList();
            var data1 = _style_Sizes.GetAll(x => x.StyleID == Style).OrderBy(x => x.SeqNo).Select(x => x.SizeID).ToList();
            foreach (var res in result)
            {
                data1.Remove(res);
            }
            return Json(data1, JsonRequestBehavior.AllowGet);
            //}
        }
        #endregion

        #region AddClientCode
        public string SetClientcode(string SetClientcode)
        {
            string result = "";
            if (SetClientcode != "")
            {
                result = "success";
                Session["selectedClientcode"] = SetClientcode;
            }
            return result;
        }
        #endregion

        #region AddItemsToCart
        public JsonResult AddToCart(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "", string orgStyl = "", string entQty = "", string reqData1 = "", string reason = "", string QtySizePriceArr = "", string selectedSitecode = "")
        {
            string result = "";
            string busId = Session["BuisnessId"].ToString();
            string selUcode = Session["SelectedUcode"] == null ? "" : Session["SelectedUcode"].ToString();
            if (Convert.ToBoolean(Session["requireemergencyreason"]) && Convert.ToBoolean(Session["IsEmergency"]) && _pointStyle.Exists(s => s.UcodeID == selUcode && s.BusinessID == busId) == false)
            {
                if (reason == "")
                {

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }

            string selTemplate = Session["SelectedTemplate"] == null ? "" : Session["SelectedTemplate"].ToString();
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var salesOrderLines = new List<SalesOrderLineViewModel>();
            var salesOrderHeader = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.IsEditing).ToList() : (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            long lineNo = 0;

            var points = _pointStyle.Exists(x => x.BusinessID == busId && x.StyleID == style && x.UcodeID == selUcode) ? _pointStyle.GetAll(x => x.BusinessID == busId && x.StyleID == style && x.UcodeID == selUcode).First().Points : 0;


            if (salesOrderHeader.Count != 0)
            {
                if ((bool)Session["IsBulkOrder1"] == false)
                {
                    salesOrderLines = Convert.ToBoolean(Session["ISEDITING"]) ? salesOrderHeader.Where(x => x.IsEditing && x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine : salesOrderHeader.Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine != null ?
                      salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
                }
                else if ((bool)Session["IsBulkOrder1"] == true)
                {
                    if (((List<string>)Session["SelectedTemplates"]).Count() > 0)
                    {
                        salesOrderLines = salesOrderHeader.Any(x => x.IsTemplate) ? salesOrderHeader.Where(x => x.IsTemplate).FirstOrDefault().SalesOrderLine != null ?
                        salesOrderHeader.Where(x => x.IsTemplate).FirstOrDefault().SalesOrderLine : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();

                    }
                    else
                    {
                        salesOrderLines = Convert.ToBoolean(Session["ISEDITING"]) ? salesOrderHeader.Where(x => x.IsUcode && x.IsEditing).FirstOrDefault().SalesOrderLine : salesOrderHeader.Any(x => x.IsUcode) ? salesOrderHeader.Where(x => x.IsUcode).FirstOrDefault().SalesOrderLine != null ?
                     salesOrderHeader.Where(x => x.IsUcode).FirstOrDefault().SalesOrderLine : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
                    }
                }
            }
            else
            {
                var address1 = _dataConnection.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
                var addArr = new string[] { };
                var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
                try
                {
                    salesOrderHeader.Add(new SalesOrderHeaderViewModel
                    {
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
                        //CustRef = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                        //Comments = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
                    });
                }
                catch (Exception e)
                {
                    logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                }
            }
            if (salesOrderLines.Count > 0)
            {
                if ((bool)Session["IsBulkOrder1"] == false)
                {
                    try
                    {
                        lineNo = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).OrderByDescending(x => x.LineNo).FirstOrDefault().LineNo + 1;
                    }catch(Exception E)
                    {
                        logger .Warn(E.Message);logger.Warn(E.StackTrace);;
                    }
                }
                else if ((bool)Session["IsBulkOrder1"] == true)
                {
                    if (((List<string>)Session["SelectedTemplates"]).Count() > 0)
                    {
                        lineNo = salesOrderLines.OrderByDescending(x => x.LineNo).FirstOrDefault().LineNo + 1;

                    }
                    else
                    {
                        lineNo = salesOrderLines.OrderByDescending(x => x.LineNo).FirstOrDefault().LineNo + 1;
                    }
                }
            }
            else
            {

                if ((bool)Session["IsBulkOrder1"] == false)
                {
                    lineNo = salesOrderLines.Any(x => x.EmployeeId == Session["SelectedEmp"].ToString()) ? salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).Count() + 1 : 1;
                }
                else if ((bool)Session["IsBulkOrder1"] == true)
                {
                    if (((List<string>)Session["SelectedTemplates"]).Count() > 0)
                    {
                        lineNo = salesOrderLines.Any(x => x.SelectedTemplate == Session["SelectedTemplate"].ToString()) ? salesOrderLines.Where(x => x.SelectedTemplate == Session["SelectedTemplate"].ToString()).Count() + 1 : 1;
                    }
                    else
                    {
                        lineNo = salesOrderLines.Any(x => x.SelectedUcode == Session["SelectedUcode"].ToString()) ? salesOrderLines.Where(x => x.SelectedUcode == Session["SelectedUcode"].ToString()).Count() + 1 : 1;
                    }
                }
            }
            var chargableAssembs = new List<SalesOrderLineViewModel>();
            var OptionalAssembs = new List<SalesOrderLineViewModel>();
            if (QtySizePriceArr != "")
            {
                var lst = JsonConvert.DeserializeObject<List<QtySizePriceArr>>(QtySizePriceArr);
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        lineNo = salesOrderLines.Count > 0 ? salesOrderLines.Last().LineNo + 1 : 1;
                        try
                        {
                            var Pricenull = Convert.ToDouble(item.Price) == 0 ? Convert.ToDouble(GetPrice(style, item.Size)) : Convert.ToDouble(item.Price);
                            if ((bool)Session["IsBulkOrder1"] == false)
                            {

                                salesOrderLines.Add(new SalesOrderLineViewModel
                                {
                                    IsAlternateStyle = _tblAlternates.Exists(s => s.AltStyleId == style) ? true : false,
                                    ColourID = color,
                                    LineNo = lineNo,
                                    Description = description,
                                    OrdQty = item.Qty,
                                    Price = Pricenull,
                                    SizeID = item.Size,
                                    StyleID = style,
                                    EmployeeId = Session["SelectedEmp"].ToString(),
                                    EmployeeName = Session["EmpName"].ToString(),
                                    StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"),
                                    orgStyleId = orgStyl,
                                    VatPercent = _dataConnection.GetVatPercent(style, item.Size),
                                    Total = _dataConnection.GetlineTotals(Convert.ToDouble(qty), Convert.ToDouble(price), _dataConnection.GetVatPercent(style, item.Size)),
                                    EntQty = entQty,
                                    FreeText1 = item.ReqData,
                                    DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"])),
                                    VatCode1 = _dataConnection.GetVatCode(),
                                    RepId = Convert.ToInt32(Session["Rep_Id"].ToString()),
                                    Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]),
                                    Cost1 = _dataConnection.GetCostPrice(style, item.Size, color, Session["Currency_Name"].ToString(), 1, 0),
                                    IssueUOM1 = 1,
                                    IssueQty1 = Convert.ToInt32(item.Qty),
                                    StockingUOM1 = 1,
                                    SOPDetail4 = reason,
                                    SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "",
                                    CatagoryCaption = Session["CatagoryCaption"].ToString()
                                });
                            }
                            else if ((bool)Session["IsBulkOrder1"] == true)
                            {
                                if (((List<string>)Session["SelectedTemplates"]).Count() > 0)
                                {
                                    salesOrderLines.Add(new SalesOrderLineViewModel { IsAlternateStyle = _tblAlternates.Exists(s => s.AltStyleId == style) ? true : false, ColourID = color, LineNo = lineNo, Description = description, OrdQty = item.Qty, Price = Pricenull, SizeID = item.Size, StyleID = style, SelectedTemplate = Session["SelectedTemplate"].ToString(), StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"), orgStyleId = orgStyl, VatPercent = _dataConnection.GetVatPercent(style, item.Size), Total = _dataConnection.GetlineTotals(Convert.ToDouble(item.Qty), Convert.ToDouble(price), _dataConnection.GetVatPercent(style, item.Size)), EntQty = entQty, FreeText1 = item.ReqData, DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"])), VatCode1 = _dataConnection.GetVatCode(), RepId = Convert.ToInt32(Session["Rep_Id"].ToString()), Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]), Cost1 = _dataConnection.GetCostPrice(style, item.Size, color, Session["Currency_Name"].ToString(), 1, 0), IssueUOM1 = 1, IssueQty1 = Convert.ToInt32(item.Qty), StockingUOM1 = 1, SOPDetail4 = reason, SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "", CatagoryCaption = Session["CatagoryCaption"] != null ? Session["CatagoryCaption"].ToString() : "" });
                                }
                                else
                                {
                                    var dtd = new SalesOrderLineViewModel();
                                    dtd.ColourID = color;
                                    dtd.LineNo = lineNo;
                                    dtd.Description = description;
                                    dtd.OrdQty = item.Qty;
                                    dtd.Price = Pricenull;
                                    dtd.SizeID = item.Size;
                                    dtd.StyleID = style;
                                    dtd.SelectedUcode = Session["SelectedUcode"].ToString();
                                    dtd.StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png");
                                    dtd.orgStyleId = orgStyl;
                                    dtd.Total = _dataConnection.GetlineTotals(Convert.ToDouble(item.Qty), Convert.ToDouble(item.Price), _dataConnection.GetVatPercent(style, item.Size));
                                    dtd.VatPercent = _dataConnection.GetVatPercent(style, item.Size);
                                    dtd.EntQty = entQty;
                                    dtd.FreeText1 = item.ReqData;
                                    dtd.DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"]));
                                    dtd.VatCode1 = _dataConnection.GetVatCode();
                                    dtd.RepId = Convert.ToInt32(Session["Rep_Id"].ToString());
                                    dtd.Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]);
                                    dtd.Cost1 = _dataConnection.GetCostPrice(style, item.Size, color, Session["Currency_Name"].ToString(), 1, 0); dtd.IssueUOM1 = 1;
                                    dtd.IssueQty1 = Convert.ToInt32(item.Qty);
                                    dtd.StockingUOM1 = 1;
                                    dtd.SOPDetail4 = reason;
                                    dtd.SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "";
                                    dtd.CatagoryCaption = Session["CatagoryCaption"] != null ? Session["CatagoryCaption"].ToString() : "";

                                    salesOrderLines.Add(dtd);
                                }

                            }

                        }
                        catch (Exception e)
                        {
                            logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                            var EmployeeId = Session["SelectedEmp"].ToString();
                            var EmployeeName = Session["EmpName"].ToString();
                        }
                        if ((bool)Session["IsBulkOrder1"] == true)
                        {
                            chargableAssembs = _home.GetChargableAssembly(Session["intNoOfday"].ToString(), style, Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), style, lineNo, Convert.ToInt64(item.Qty), "", "", Session["BuisnessId"].ToString(), selTemplate, selUcode);
                        }
                        else
                        {
                            chargableAssembs = _home.GetChargableAssembly(Session["intNoOfday"].ToString(), style, Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), style, lineNo, Convert.ToInt64(item.Qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), Session["BuisnessId"].ToString(), selTemplate, selUcode);
                        }
                        if (chargableAssembs.Count > 0)
                        {
                            salesOrderLines.AddRange(chargableAssembs);
                            chargableAssembs = new List<SalesOrderLineViewModel>();
                        }

                        OptionalAssembs = new List<SalesOrderLineViewModel>();

                        if ((List<string>)Session["assemList"] != null)
                        {
                            if (((List<string>)Session["assemList"]).Count > 0)
                            {
                                if ((bool)Session["IsBulkOrder1"] == true)
                                {
                                    OptionalAssembs = _home.GetOptionalAssembly(Session["intNoOfday"].ToString(), style, Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), (List<string>)Session["assemList"], style, lineNo, salesOrderLines, Convert.ToInt64(item.Qty), "", "", salesOrderLines.Count, Session["BuisnessId"].ToString(), selTemplate, selUcode);
                                }
                                else
                                {
                                    OptionalAssembs = _home.GetOptionalAssembly(Session["intNoOfday"].ToString(), style, Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), (List<string>)Session["assemList"], style, lineNo, salesOrderLines, Convert.ToInt64(item.Qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), salesOrderLines.Count, Session["BuisnessId"].ToString(), selTemplate, selUcode);
                                }
                            }
                        }
                        if (OptionalAssembs.Count > 0)
                        {
                            salesOrderLines.AddRange(OptionalAssembs);
                            OptionalAssembs = new List<SalesOrderLineViewModel>();
                        }
                        foreach (var data1 in salesOrderLines)
                        {
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
                    }
                    if ((((List<string>)Session["Templates"]).Count() > 0))
                    {
                        try
                        {
                            var sjcvjv = Session["SelectedTemplate"].ToString();
                            var jvjv = salesOrderHeader.Where(x => x.IsTemplate).FirstOrDefault();
                            salesOrderHeader.Where(x => x.IsTemplate).FirstOrDefault().SalesOrderLine = salesOrderLines;
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    else
                    {
                        var ucodeId = Session["SelectedUcode"].ToString();
                        try
                        {
                            if (Convert.ToBoolean(Session["ISEDITING"]))
                            {
                                salesOrderHeader.Where(x => x.IsUcode && x.IsEditing).FirstOrDefault().SalesOrderLine = salesOrderLines;
                            }
                            else
                            {
                                salesOrderHeader.Where(x => x.IsUcode).FirstOrDefault().SalesOrderLine = salesOrderLines;
                            }
                        }
                        catch (Exception e)
                        {
                            logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                        }
                    }
                    Session["SalesOrderHeader"] = salesOrderHeader;
                    Session["assemList"] = null;
                    if (((List<string>)Session["SelectedTemplates"]).Count() > 0)
                    {
                        Session["SalesOrderLines"] = salesOrderLines.Where(x => x.SelectedTemplate == Session["SelectedTemplate"].ToString()).ToList();
                        Session["qty"] = salesOrderLines.Where(x => x.SelectedTemplate == Session["SelectedTemplate"].ToString() && x.IsDleted == false && (x.OriginalLineNo == null || x.OriginalLineNo == 0)).Sum(x => x.OrdQty);
                    }
                    else
                    {
                        Session["SalesOrderLines"] = salesOrderLines.Where(x => x.SelectedUcode == Session["SelectedUcode"].ToString().ToString()).ToList();
                        Session["qty"] = salesOrderLines.Where(x => x.SelectedUcode == Session["SelectedUcode"].ToString().ToString() && x.IsDleted == false && x.OriginalLineNo == null || x.OriginalLineNo == 0).Sum(x => x.OrdQty);

                    }

                    lineNo = lineNo + 1;

                    result = "<button class=\"btn\" onclick=\"GetCart()\" style=\"background-color:#009885;color:white\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:white;font-size:25px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button>";

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (salesOrderHeader.Count != 0)
                {
                    salesOrderLines = salesOrderHeader.Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine != null ?
                      salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
                }
                else
                {
                    var address1 = _dataConnection.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
                    var addArr = new string[] { };
                    var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
                    try
                    {
                        salesOrderHeader.Add(new SalesOrderHeaderViewModel
                        {
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
                            //CustRef = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                            //Comments = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
                        });
                    }
                    catch (Exception e)
                    {
                        logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                    }
                }
                if (salesOrderLines.Count > 0)
                {
                    lineNo = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).OrderByDescending(x => x.LineNo).FirstOrDefault().LineNo + 1;
                }
                else
                {
                    lineNo = salesOrderLines.Any(x => x.EmployeeId == Session["SelectedEmp"].ToString()) ? salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).Count() + 1 : 1;
                }
                if (description != "" && price != "" && size != "" && color != "" && qty != "")
                {
                    try
                    {
                        //Total = _dataConnection.GetVatPercent(x.StyleID, x.SizeID) + Convert.ToDouble(x.Price.Value),

                        salesOrderLines.Add(new SalesOrderLineViewModel { IsAlternateStyle = _tblAlternates.Exists(s => s.AltStyleId == style) ? true : false, ColourID = color, LineNo = lineNo, Description = description, OrdQty = Convert.ToInt64(qty), Price = Convert.ToDouble(price) == 0 ? Convert.ToDouble(GetPrice(style, size)) : Convert.ToDouble(price), SizeID = size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString(), StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"), orgStyleId = orgStyl, VatPercent = _dataConnection.GetVatPercent(style, size), Total = _dataConnection.GetlineTotals(Convert.ToDouble(qty), Convert.ToDouble(price), _dataConnection.GetVatPercent(style, size)), EntQty = entQty, FreeText1 = reqData1, DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"])), VatCode1 = _dataConnection.GetVatCode(), RepId = Convert.ToInt32(Session["Rep_Id"].ToString()), Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]), Cost1 = _dataConnection.GetCostPrice(style, size, color, Session["Currency_Name"].ToString(), 1, 0), IssueUOM1 = 1, IssueQty1 = Convert.ToInt32(qty), StockingUOM1 = 1, SOPDetail4 = reason, SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "", Points = points.Value, TotalPoints = points.Value * Convert.ToInt32(qty), CatagoryCaption = Session["CatagoryCaption"] != null ? Session["CatagoryCaption"].ToString() : "" });
                    }
                    catch (Exception e)
                    {
                        logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                        var EmployeeId = Session["SelectedEmp"].ToString();
                        var EmployeeName = Session["EmpName"].ToString();
                    }

                    chargableAssembs = _home.GetChargableAssembly(Session["intNoOfday"].ToString(), style, Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), style, lineNo, Convert.ToInt64(qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), Session["BuisnessId"].ToString());
                    if (chargableAssembs.Count > 0)
                    {
                        salesOrderLines.AddRange(chargableAssembs);
                    }
                    OptionalAssembs = new List<SalesOrderLineViewModel>();

                    if ((List<string>)Session["assemList"] != null)
                    {
                        if (((List<string>)Session["assemList"]).Count > 0)
                        {
                            OptionalAssembs = _home.GetOptionalAssembly(Session["intNoOfday"].ToString(), style, Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), (List<string>)Session["assemList"], style, lineNo, salesOrderLines, Convert.ToInt64(qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), salesOrderLines.Count, Session["BuisnessId"].ToString());
                        }
                    }
                    if (OptionalAssembs.Count > 0)
                    {
                        salesOrderLines.AddRange(OptionalAssembs);
                    }
                    foreach (var data1 in salesOrderLines)
                    {
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
                    salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine = salesOrderLines;
                    Session["SalesOrderHeader"] = salesOrderHeader;
                    Session["assemList"] = null;
                    Session["SalesOrderLines"] = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).ToList();
                    Session["qty"] = Convert.ToBoolean(Session["ISEDITING"]) ? salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString() && x.IsDleted == false && (x.OriginalLineNo == null || x.OriginalLineNo == 0)).Sum(x => x.OrdQty) : salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString() && x.OriginalLineNo == null).Sum(x => x.OrdQty);
                    result = "<button class=\"btn\" onclick=\"GetCart()\" style=\"background-color:#009885;color:white\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:white;font-size:25px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button>";

                    if (Convert.ToBoolean(Session["POINTSREQ"]))
                    {
                        string thisEmp = Session["SelectedEmp"].ToString();

                        string ucode = Session["SelectedUcode"].ToString();
                        var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
                        var salesLine = salesHead.Any(s => s.SalesOrderLine.Count > 0 && s.UCodeId == ucode) ? salesHead.Where(s => s.SalesOrderLine.Count > 0 && s.UCodeId == ucode).First().SalesOrderLine : new List<SalesOrderLineViewModel>();
                        int totCardPts = 0, totalPoints = 0, availablePoints = 0;
                        totCardPts = _dp.GetTotalSoPoints(busId, thisEmp, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                        totalPoints = ((PointsModel)Session["Pointsmodel"]).TotalPoints;
                        availablePoints = totalPoints - salesLine.Sum(x => x.TotalPoints) - totCardPts;
                        ((PointsModel)Session["Pointsmodel"]).AvailablePoints = availablePoints;
                        ((PointsModel)Session["Pointsmodel"]).UsedPoints = salesLine.Sum(x => x.TotalPoints);

                    }
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AddAssemblyList
        public string AddAssemblyList(string style = "")
        {
            if (style != "")
            {
                if (Session["assemList"] != null)
                {
                    var assemList = (List<string>)Session["assemList"];
                    assemList.Add(style);
                    Session["assemList"] = assemList;
                }
                else
                {
                    Session["assemList"] = new List<string>();
                    var assemList = (List<string>)Session["assemList"];
                    assemList.Add(style);
                    Session["assemList"] = assemList;
                }
                return "1";
            }
            return "";
        }
        #endregion

        #region remove assembly from list
        public string RemoveAssemblyList(string style = "")
        {
            if (style != "" & ((List<string>)Session["assemList"]).Count != 0)
            {
                if (Session["assemList"] != null)
                {
                    var assemList = (List<string>)Session["assemList"];
                    assemList.Remove(style);
                    Session["assemList"] = assemList;
                }
                return "1";
            }
            return "";
        }
        #endregion

        #region GetFreeStockValue
        public int GetFreeStockValue(string StyleId, string ColorId, string size,bool isAlternateStyle=false)
        {
            int value = 0;
            var emp = System.Web.HttpContext.Current.Session["SelectedEmp"].ToString();
            var salesHead = ((List<SalesOrderHeaderViewModel>)System.Web.HttpContext.Current.Session["SalesOrderHeader"]).Any(x => x.EmployeeID == emp) ? ((List<SalesOrderHeaderViewModel>)System.Web.HttpContext.Current.Session["SalesOrderHeader"]).Where(x => x.EmployeeID == emp).First() : new SalesOrderHeaderViewModel();
            long cartValue = 0;
            salesHead.SalesOrderLine = salesHead.SalesOrderLine != null ? salesHead.SalesOrderLine : new List<SalesOrderLineViewModel>();
            var salesOrderLines = salesHead.SalesOrderLine;
            if (salesOrderLines.Count() > 0)
            {
                cartValue = salesOrderLines.Any(s => s.StyleID == StyleId && s.ColourID == ColorId && s.SizeID == size && s.IsDleted == false) ? salesOrderLines.Where(s => s.StyleID == StyleId && s.ColourID == ColorId && s.SizeID == size && s.IsDleted == false).Sum(s => s.OrdQty) : 0;
            }
            int freestock = _dp.GetFreeStock(StyleId, ColorId, size, System.Web.HttpContext.Current.Session["WareHouseID"].ToString(), salesOrderLines, Convert.ToBoolean(System.Web.HttpContext.Current.Session["ISEDITING"]), false);
            value = isAlternateStyle==false? freestock - Convert.ToInt32(cartValue):freestock;
            value = value > 0 ? value : 0;
            return value;
        }
        #endregion

        #region GetEntitlement

        public JsonResult GetEntitlement(string StyleId = "", string ColorId = "", string orgStyl = "", string size = "")
        {
            string Ucodes = Session["SelectedUcode"] == null ? "" : Session["SelectedUcode"].ToString();
            var ucodStylesLst = _dp.UcodeStyles(Ucodes, Session["BuisnessId"].ToString());
            EntitlementModel em = new EntitlementModel();
            //if(orgStyl.Contains(','))
            //{
            var emp = Session["SelectedEmp"].ToString();

            var saleHead = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var salesLine = saleHead.Any(x => x.EmployeeID == emp && x.UCodeId == Ucodes) ? saleHead.Where(x => x.EmployeeID == emp && x.UCodeId == Ucodes).First().SalesOrderLine.Where(s => s.IsDleted == false) : new List<SalesOrderLineViewModel>();
            var salesLineDelted = saleHead.Any(x => x.EmployeeID == emp && x.UCodeId == Ucodes) ? saleHead.Where(x => x.EmployeeID == emp && x.UCodeId == Ucodes).First().SalesOrderLine.Where(s => s.IsDleted == true) : new List<SalesOrderLineViewModel>();
            long basketCount = 0;
            if (salesLine != null)
            {
                if (salesLine.Count() > 0)
                {
                    basketCount = salesLine.Any(x => x.orgStyleId == orgStyl | x.StyleID == StyleId) ? salesLine.Where(x => x.orgStyleId == orgStyl | x.StyleID == StyleId).Sum(x => x.OrdQty) : 0;
                }
            }
            int minMandatoryPts = 0;
            List<int> missValues = new List<int>();
            var orgStyleNPoints = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);

            foreach (var sale in salesLine.Where(x => x.OriginalLineNo == null || x.OriginalLineNo == 0))
            {
                if (orgStyleNPoints.Any(x => x.OrgStyle == sale.orgStyleId))
                {
                    int minThispts = orgStyleNPoints.Where(x => x.OrgStyle == sale.orgStyleId).First().MinPoints;
                    int thisQty = Convert.ToInt32(salesLine.Where(x => (x.OriginalLineNo == null || x.OriginalLineNo == 0) && x.orgStyleId == sale.orgStyleId).Sum(x => x.OrdQty));
                    if (thisQty < minThispts)
                    {
                        missValues.Add(orgStyleNPoints.Where(x => x.OrgStyle == sale.orgStyleId).OrderBy(x => x.Points).First().Points * (minThispts - thisQty));
                    }
                }
            }
            //minMandatoryPts = missValues.Sum();
            em.EmpId = "<b>" + Session["SelectedEmp"].ToString() + "</b> to style: <b>" + StyleId + "</b>";

            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles != null)
                {
                    string result = "";
                    string ucode = Session["SelectedUcode"].ToString();
                    string empId = Session["SelectedEmp"].ToString();
                    string busId = Session["BuisnessId"].ToString();
                    int totCardPts = 0;
                    int totPoints = 0;
                    int inCartPoints = 0;
                    int availabelPoints = 0;
                    int totalOtherPoints = 0;
                    int previousPoints = 0;
                    int usedPoints = 0, ptsNanCard = 0, totDelPts;
                    var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == empId) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
                    if (Convert.ToBoolean(Session["returnorder"]))
                    {
                        int totalPts = _pointsByUcode.Exists(s => s.BusinessID == busId && s.UcodeID == ucode) ? _pointsByUcode.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).First().TotalPoints.Value : 0;
                        int cardPts = _vuPointsCard.Exists(s => s.BusinessID == busId && s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == emp && ucodStylesLst.Contains(s.StyleID)).Sum(s => s.TOTSOPOINTS).Value) : 0;
                        int thisPts = _pointStyle.Exists(s => s.BusinessID == busId && s.UcodeID == ucode.Trim() && s.StyleID.Trim() == StyleId.Trim()) ? _pointStyle.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode.Trim() && s.StyleID.Trim() == StyleId.Trim()).First().Points.Value : 0;
                        int rtnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0).Sum(s => s.TotalPoints);
                        int reOrdPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0).Sum(s => s.TotalPoints);
                        rtnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReturn && s.IsDleted == 0) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0).Sum(s => s.TotalPoints) : 0;
                        reOrdPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReorder && s.IsDleted == 0) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderno != 0).Sum(s => s.TotalPoints) : 0;
                        int reOrdPtsED = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReorder && s.IsDleted == 0) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReorder && s.IsDleted == 0 && s.ReOrderno == 0).Sum(s => s.TotalPoints) : 0;
                        int availPts = 0;

                        if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                        {
                            int thisRTnPts = (((List<ReturnOrderModel>)Session["rtnLines"])).Any(s => s.IsReturn && s.IsDleted == 0 && s.IsRetEdit == false) ? (((List<ReturnOrderModel>)Session["rtnLines"])).Where(s => s.IsReturn && s.IsDleted == 0 && s.IsRetEdit == false).Sum(s => s.TotalPoints) : 0;
                            availPts = totalPts - ((cardPts + reOrdPtsED) - thisRTnPts);
                        }
                        else
                        {
                            availPts = totalPts - ((cardPts + reOrdPts + reOrdPtsED) - rtnPts);
                        }

                        //if (Convert.ToBoolean(Session["ISRTNEDITING"]))
                        //{
                        //    availPts = totalPts - (cardPts + reOrdPts);
                        //}
                        //else
                        //{
                        //    availPts = totalPts - ((cardPts + reOrdPts) - rtnPts);
                        //}
                        result = "<table class=\"table\"><tr><td>Total points: " + totalPts + "</td></tr><tr><td>Used points: " + cardPts + "</td></tr><tr><td>Return points: " + rtnPts + "</td></tr><tr><td>Reordered points: " + reOrdPts + "</td></tr><tr><td>Available points: " + availPts + "</td></tr></table>";
                        em.Result = result;
                        em.minMandatoryPts = minMandatoryPts;
                        return Json(em);
                    }
                    else
                    {
                        if (Convert.ToBoolean(Session["ISEDITING"]) == false)
                        {
                            Session["Pointsmodel"] = Convert.ToBoolean(Session["ISEDITING"]) ? _home.GetPointsModel(salesHead.UCodeId, busId) : _home.GetPointsModel(Session["selectedUcodes"].ToString(), busId);
                            totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                            inCartPoints = salesLine.Count() > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                            totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                            //commented by sasi(21-12-20)
                            //usedPoints = totCardPts == totPoints ? totPoints - inCartPoints : totPoints - totCardPts - inCartPoints;
                            usedPoints = totCardPts + inCartPoints;
                            availabelPoints = totPoints - usedPoints;
                        }
                        else
                        {
                            foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != salesHead.OrderNo && s.OrderType.ToLower() == "so").ToList())
                            {
                                foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                                {
                                    if (_pointStyle.Exists(s => s.StyleID == lien.StyleID && s.UcodeID == ucode))
                                    {
                                        totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                                    }
                                }
                            }
                            totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                            inCartPoints = salesLine.Count() > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                            totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                            totDelPts = salesLineDelted.Count() > 0 ? salesLineDelted.Sum(x => x.TotalPoints) : 0;
                            ptsNanCard = totPoints - totCardPts;
                            usedPoints = inCartPoints + totalOtherPoints;
                            previousPoints = totCardPts - usedPoints;
                            availabelPoints = (totPoints - usedPoints) - previousPoints;
                        }
                    }
                    var minManLst = orgStyleNPoints.Where(s => s.MinPoints > 0).Select(s => s.OrgStyle).Distinct().ToList();
                    List<string> mandatorySty = new List<string>();
                    foreach (var styl in minManLst)
                    {
                        if ((salesLine.Where(s => s.orgStyleId == styl).Sum(s => s.OrdQty) >= orgStyleNPoints.Where(s => s.OrgStyle == styl).First().MinPoints) == false)
                        {
                            mandatorySty.Add(styl);
                        }
                    }
                    foreach (var dat in mandatorySty)
                    {
                        int totCartPts = salesLine.Any(s => s.orgStyleId == dat) ? salesLine.Where(s => s.orgStyleId == dat).Sum(s => s.TotalPoints) : 0;
                        minMandatoryPts = minMandatoryPts + ((orgStyleNPoints.Where(s => s.OrgStyle == dat).Min(s => s.Points) * orgStyleNPoints.Where(s => s.OrgStyle == dat).First().MinPoints) - totCartPts);
                    }
                    result = "<table class=\"table\"><tr><td>Total points: " + totPoints + "</td></tr><tr><td>Used points: " + usedPoints + "</td></tr><tr><td>Available points: " + availabelPoints + "</td></tr></table>";
                    em.Result = result;
                    em.minMandatoryPts = minMandatoryPts;
                    em.availPts = GetValuesData(orgStyl) && minMandatoryPts == 0 ? -1 : 1;
                    return Json(em);
                }
                else if (ColorId != "" && orgStyl != "")
                {
                    string result = "";
                    var entitlement = _ucodes.Exists(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                    entitlement = entitlement == 0 ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : entitlement;
                    string PreviousOrder = _dataConnection.GetAllPreviousData(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), StyleId, basketCount);
                    PreviousOrder = PreviousOrder == "" ? "<tr><td>Issued: 0</td></tr><tr><td>In Basket: " + basketCount + "</td></tr><tr><td>Previous History: N/A</td></tr></table>" : PreviousOrder;
                    result = "<table class=\"table\"><tr><td>Entitlement: " + entitlement + "</td></tr>" + PreviousOrder;

                    em.Result = result;

                    return Json(em);
                }
                else if (ColorId == "" && orgStyl != "")
                {
                    string result = "";
                    var entitlement = _ucodes.Exists(x => x.StyleID == orgStyl && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                    entitlement = entitlement == 0 ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : entitlement;
                    string PreviousOrder = _dataConnection.GetAllPreviousData(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), orgStyl, basketCount);
                    PreviousOrder = PreviousOrder == "" ? "<tr><td>Issued: 0</td></tr><tr><td>In Basket: " + basketCount + "</td></tr><tr><td>Previous History: N/A</td></tr></table>" : PreviousOrder;
                    result = "<table class=\"table\"><tr><td>Entitlement: " + entitlement + "</td></tr>" + PreviousOrder;
                    em.Result = result;
                    return Json(em);
                }
            }
            else if(Session["isrtntype"].ToString() == "PRIVATE")
            {
                var model1 = ((List<ReturnOrderModel>)Session["rtnLines"]);
                var selected = Session["selectedRetLine"] != null ? (ReturnOrderModel)Session["selectedRetLine"] : new ReturnOrderModel();
                var reOrdQty = Convert.ToBoolean(Session["ISRTNEDITING"]) ? model1.Where(s => s.IsReorder && s.ReturnLineNo == selected.ReturnLineNo && s.StyleId == selected.StyleId && s.ColourId == selected.ColourId && s.SizeId == selected.SizeId && s.IsDleted==0).Sum(s => s.OrdQty) : model1.Where(s => s.IsReorder && s.LineNo == selected.LineNo && s.ReturnLineNo == selected.ReturnLineNo && s.StyleId == selected.StyleId && s.ColourId == selected.ColourId && s.SizeId == selected.SizeId && s.IsDleted == 0).Sum(s => s.OrdQty);
                em.isPrivate = true;
                em.Result = Convert.ToBoolean(Session["ISRTNEDITING"]) ? selected.LineNo > 0 ? "<table class=\"table\"><tr><td>Return qty: " + selected.OrdQty + "</td></tr><tr><td>Cart qty: " + reOrdQty + "</td></tr></table>" : "" :   selected.LineNo>0? "<table class=\"table\"><tr><td>Return qty: " + selected.RtnQty + "</td></tr><tr><td>Cart qty: " + reOrdQty + "</td></tr></table>" : "" ;
                return Json(em);
            }
            else if (Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["REQSTKLEVEL"]))
            {
                var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == emp) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == emp).First() : new SalesOrderHeaderViewModel();
                long cartValue = 0;
                var salesOrderLines = salesHead.SalesOrderLine;
                if (salesOrderLines.Count > 0)
                {
                    cartValue = salesOrderLines.Any(s => s.StyleID == StyleId && s.ColourID == ColorId && s.SizeID == size && s.IsDleted == false) ? salesOrderLines.Where(s => s.StyleID == StyleId && s.ColourID == ColorId && s.SizeID == size && s.IsDleted == false).Sum(s => s.OrdQty) : 0;
                }
                em.isfreestk = true;
                em.Result = "<table class=\"table\"><tr><td>Free Stock:  " + _dp.GetFreeStock(StyleId, ColorId, size, Session["WareHouseID"].ToString(), null, Convert.ToBoolean(Session["ISEDITING"])) + "</td></tr><tr><td>Issued: 0</td></tr><tr><td>In Cart: " + cartValue + "</td></tr><tr><td>Previous History: N/A</td></tr></table>";
                return Json(em);
            }
            else
            {
                if (ColorId != "" && orgStyl != "")
                {
                    string result = "";
                    var entitlement = _ucodes.Exists(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.ColourID == ColorId && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                    entitlement = entitlement == 0 ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : entitlement;
                    string PreviousOrder = _dataConnection.GetAllPreviousData(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), orgStyl, basketCount);
                    PreviousOrder = PreviousOrder == "" ? "<tr><td>Issued: 0</td></tr><tr><td>In Basket: " + basketCount + "</td></tr><tr><td>Previous History: N/A</td></tr></table>" : PreviousOrder;
                    result = "<table class=\"table\"><tr><td>Entitlement: " + entitlement + "</td></tr>" + PreviousOrder;

                    em.Result = result;

                    return Json(em);
                }
                else if (ColorId == "" && orgStyl != "")
                {
                    string result = "";
                    var entitlement = _ucodes.Exists(x => x.StyleID == orgStyl && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                    entitlement = entitlement == 0 ? _ucodes.GetAll(x => x.StyleID == orgStyl && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : entitlement;
                    string PreviousOrder = _dataConnection.GetAllPreviousData(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), orgStyl, basketCount);
                    PreviousOrder = PreviousOrder == "" ? "<tr><td>Issued: 0</td></tr><tr><td>In Basket: " + basketCount + "</td></tr><tr><td>Previous History: N/A</td></tr></table>" : PreviousOrder;
                    result = "<table class=\"table\"><tr><td>Entitlement: " + entitlement + "</td></tr>" + PreviousOrder;
                    em.Result = result;
                    return Json(em);
                }
            }
            ////if (Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["REQSTKLEVEL"]))
            ////{
            ////    em.Result = "<table class=\"table\"><tr><td>Free Stock:  "+_dp.GetFreeStock(StyleId,ColorId,size, Session["WareHouseID"].ToString()) +"</td></tr><tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>";
            ////}
            ////else
            ////{
            em.Result = "<table class=\"table\"><tr><td>Entitlement:  0</td></tr><tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>";
            //}

            return Json(em, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region GetBtnStatus
        [HttpPost]
        public string GetBtnStatus(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "", string size = "")
        {
            var orgStyleNPoints = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);
            string result = "";
            string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
            string busId = Session["BuisnessId"].ToString();
            string empId = (Session["SelectedEmp"].ToString());
            var issuedDiff = 0;
            var salesOrder = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            var salesOrderLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.UCodeId == Ucodes && x.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == false).ToList();

            var onCartLst = salesOrderLines.Any(x => x.orgStyleId != null && x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()) ? salesOrderLines.Where(x => x.orgStyleId != null && x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()).ToList() : new List<SalesOrderLineViewModel>();
            var onCartVal = onCartLst.Sum(x => x.OrdQty);
            int minMandatoryPts = 0;
            int minOrdQty = 0;
            long qtny = 0;
            string ucode = Session["SelectedUcode"].ToString();
            // var sassas = Session["OverrideEnt"].ToString().ToLower().Trim();
            int totPtsSo = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
            int ucodePts = _pointStyle.Exists(x => x.BusinessID == busId & x.UcodeID == Ucodes & x.StyleID == style) ? _pointStyle.GetAll(x => x.BusinessID == busId & x.UcodeID == Ucodes & x.StyleID == style).First().Points.Value : 0;
            minOrdQty = _pointStyle.Exists(x => x.StyleID == orgStyl && x.UcodeID == ucode && x.BusinessID == busId) ? _pointStyle.GetAll(x => x.StyleID == orgStyl && x.UcodeID == ucode && x.BusinessID == busId).First().MinPts.Value : 0;
            bool minPtsSatsfd = (ucodePts * minOrdQty) >= totPtsSo ? false : true;
            if (Session["OverrideEnt"].ToString().ToLower().Trim() != "show")
            {
                if (Convert.ToBoolean(Session["POINTSREQ"].ToString()))
                {
                    if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]) != null)
                    {
                        if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles != null)
                        {

                            result = GetBtnStatusforPoints(empId, ucode, orgStyleNPoints, qtny, minOrdQty, orgStyl, Ucodes, busId, style, salesOrderLines, qty);


                        }
                        else
                        {
                            if (ordQty != "" & color != "" & style != "" & qty != "")
                            {
                                int difference = 0;
                                int oQty = Convert.ToInt32(ordQty);
                                var entitlement = _ucodes.Exists(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                                var issuedLst = _stockCard.Exists(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == style.Trim().ToLower()) ? _stockCard.GetAll(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == style.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
                                var issued = 0;
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
                                if (onCartVal != 0)
                                {
                                    issuedDiff = (int)issuedDiff - (int)onCartVal;
                                }

                                if (issuedDiff > 0)
                                {
                                    result = Convert.ToInt32(qty) <= issuedDiff ? "enabled" : "";
                                }
                            }
                        }

                    }
                }
                else if (Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["REQSTKLEVEL"]))
                {
                    long cartValue = 0;
                    int oQty = Convert.ToInt32(qty);
                    int freeStck = 0;
                    var salesOrderLines1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.UCodeId == Ucodes && x.EmployeeID == empId).First().SalesOrderLine.ToList();
                    if (salesOrderLines1.Count > 0)
                    {
                        cartValue = salesOrderLines1.Any(s => s.StyleID == style && s.ColourID == color && s.SizeID == size && s.IsDleted == false) ? salesOrderLines.Where(s => s.StyleID == style && s.ColourID == color && s.SizeID == size && s.IsDleted == false).Sum(s => s.OrdQty) : 0;
                    }
                    freeStck = _dp.GetFreeStock(style, color, size, Session["WareHouseID"].ToString(), salesOrderLines1, Convert.ToBoolean(Session["ISEDITING"]), false);
                    var ordedSum = cartValue + oQty;
                    result = freeStck - ordedSum >= 0 ? "enabled" : "";
                }
                else
                {
                    if (ordQty != "" & color != "" & style != "" & qty != "")
                    {
                        int difference = 0;
                        int oQty = Convert.ToInt32(ordQty);
                        var entitlement = _ucodes.Exists(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                        var issuedLst = _dp.GetIssuedList(busId, color, empId, style);
                        if (issuedLst.Count == 0)
                        {
                            try
                            {

                                issuedLst = _dp.GetIssuedList(busId, color, empId, style);
                                //_stockCard.Exists(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()) ? _stockCard.GetAll(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
                            }
                            catch (Exception e)
                            {
                                logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                            }

                        }

                        var issued = 0;
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
                        if (onCartVal != 0)
                        {
                            issuedDiff = (int)issuedDiff - (int)onCartVal;
                        }

                        if (issuedDiff > 0)
                        {
                            result = Convert.ToInt32(qty) <= issuedDiff ? "enabled" : "";
                        }
                    }
                }
                //var s = Session["ALLOW_OVERRIDE_ENT"].ToString().ToLower();
            }
            else
            {
                result = "enabled";
            }
            return result;
        }
        #endregion

        #region GetBtnStatusforPoints
        public string GetBtnStatusforPoints(string empId, string ucode, List<Maximus.Data.models.StyleAndMinPoints> orgStyleNPoints, long qtny, int minOrdQty, string orgStyl, string Ucodes, string busId, string style, List<SalesOrderLineViewModel> salesOrderLines, string qty)
        {
            var pointsModel = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]);
            var salesHeader = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            var salesHead = salesHeader.Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First();
            var salesLines = salesHeader.Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().SalesOrderLine.Where(s => s.IsDleted == false).ToList();
            var salesLineDelted = salesHeader.Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().SalesOrderLine.Where(s => s.IsDleted == true).ToList();
            var inCartPoints = salesLines.Count > 0 ? salesLines.Sum(x => x.TotalPoints) : 0;
            var totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
            int availabelPoints = 0;
            int totPoints = pointsModel.TotalPoints;
            int totalOtherPoints = 0, totDelPts = 0, ptsNanCard = 0, usedPoints = 0, previousPoints = 0;

            if (inCartPoints == totCardPts)
            {
                availabelPoints = totPoints - totCardPts;
            }
            else
            {
                if (Convert.ToBoolean(Session["ISEDITING"]))
                {
                    var oNO = salesHeader.Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().OrderNo;
                    foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != salesHead.OrderNo && s.OrderType.ToLower() == "so").ToList())
                    {
                        foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                        {
                            if (_pointStyle.Exists(s => s.StyleID == lien.StyleID && s.UcodeID == ucode))
                            {
                                totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                            }
                        }
                    }
                    totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                    inCartPoints = salesLines.Count() > 0 ? salesLines.Sum(x => x.TotalPoints) : 0;
                    totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                    totDelPts = salesLineDelted.Count > 0 ? salesLineDelted.Sum(x => x.TotalPoints) : 0;
                    ptsNanCard = totPoints - totCardPts;
                    usedPoints = inCartPoints + totalOtherPoints;
                    previousPoints = totCardPts - usedPoints;
                    availabelPoints = ((totPoints - usedPoints) - previousPoints) + totDelPts;
                }
                //foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != oNO && s.OrderType.ToLower() == "so").ToList())
                //{
                //    foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                //    {
                //        totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                //    }
                //}
                //    if (totalOtherPoints == 0)
                //    {
                //        totalOtherPoints = totCardPts - inCartPoints;
                //    }
                //    totCardPts = totCardPts - totalOtherPoints;
                //    if (inCartPoints == totCardPts)
                //    {
                //        availabelPoints = totalOtherPoints > 0 ? (totPoints - totCardPts) - totalOtherPoints : totPoints - totCardPts;

                //    }
                //    else
                //    {
                //        availabelPoints = totalOtherPoints > 0 ? ((totPoints + (totCardPts - inCartPoints)) - totCardPts) - totalOtherPoints : (totPoints + (totCardPts - inCartPoints)) - totCardPts;
                //    }

                //}
                else
                {
                    availabelPoints = totCardPts > 0 ? (totPoints - (totCardPts + inCartPoints)) : totPoints - inCartPoints;
                }
            }
            var orgStylPoints = (List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"];
            var minOrgPts = orgStylPoints.Where(s => s.MinPoints > 0).ToList();
            var orgStyPts = orgStylPoints.Where(s => s.MinPoints > 0).Select(s => s.OrgStyle).Distinct().ToList();
            var thisStylTotpt = (_pointStyle.GetAll(s => s.StyleID == style && s.UcodeID == ucode).First().Points * Convert.ToInt32(qty));
            var mandatorySty = new List<string>();
            if (salesLines.Count() > 0)
            {
                int totAvailablePts = availabelPoints;
                int total = totAvailablePts - thisStylTotpt.Value;
                foreach (var styl in orgStyPts)
                {
                    if ((salesLines.Where(s => s.orgStyleId == styl).Sum(s => s.OrdQty) >= orgStylPoints.Where(s => s.OrgStyle == styl).First().MinPoints) == false)
                    {
                        mandatorySty.Add(styl);
                    }
                }
                var count = 0;
                foreach (var lsts in mandatorySty)
                {
                    var thisQty = salesLines.Any(s => s.orgStyleId == lsts) ? salesLines.Where(s => s.orgStyleId == lsts).Sum(s => s.OrdQty) : 0;
                    var str = orgStylPoints.Where(s => s.OrgStyle == lsts).First().MinPoints - thisQty;
                    count = count + (orgStylPoints.Where(s => s.OrgStyle == lsts).Min(s => s.Points) * Convert.ToInt32(str));
                }
                if ((total >= count) == false && (total >= 0))
                {
                    if (mandatorySty.Contains(orgStyl))
                    {
                        var thisQty = salesLines.Any(s => s.orgStyleId == orgStyl) ? salesLines.Where(s => s.orgStyleId == orgStyl).Sum(s => s.OrdQty) : 0;
                        if ((thisQty + Convert.ToInt32(qty)) > orgStylPoints.Where(s => s.OrgStyle == orgStyl).First().MinPoints)
                        {
                            mandatorySty.Remove(orgStyl);
                            if (mandatorySty.Count > 0)
                            {
                                int cnt1 = 0;
                                foreach (var lsts in mandatorySty)
                                {
                                    var thisQty1 = salesLines.Any(s => s.orgStyleId == lsts) ? salesLines.Where(s => s.orgStyleId == lsts).Sum(s => s.OrdQty) : 0;
                                    var incartLstPts = salesLines.Any(s => s.orgStyleId == lsts) ? salesLines.Where(s => s.orgStyleId == lsts).Sum(s => s.OrdQty) : 0;
                                    var str = (orgStylPoints.Where(s => s.OrgStyle == lsts).First().MinPoints - incartLstPts) * orgStylPoints.Where(s => s.OrgStyle == lsts).Min(s => s.Points);
                                    if (total >= str)
                                    {
                                        return "enabled";
                                    }
                                }
                            }
                            else
                            {
                                return "enabled";
                            }
                            return "";
                        }
                        else
                        {
                            return "enabled";
                        }
                    }
                    else
                    {
                        if (thisStylTotpt == 0)
                        {
                            return "enabled";
                        }
                        else
                        {
                            return "";
                        }

                    }
                }
                else
                {
                    if ((total >= 0))
                    {
                        return "enabled";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else
            {
                if (availabelPoints > 0)
                {
                    int count = 0;
                    foreach (var res in orgStyPts)
                    {
                        count = count + orgStylPoints.Where(s => s.OrgStyle == res).First().MinPoints * orgStylPoints.Where(s => s.OrgStyle == res).Min(s => s.Points);
                    }
                    if ((availabelPoints - thisStylTotpt.Value) >= count)
                    {
                        return "enabled";
                    }
                    else if (orgStyPts.Contains(orgStylPoints.Where(s => s.Style == style).First().OrgStyle))
                    {
                        return "enabled";
                    }
                    else if (thisStylTotpt.Value == 0)
                    {
                        return "enabled";
                    }
                }
                else
                {
                    return "";
                }

                return "";
            }
            return "";
            //int prevPoints = 0;
            //string result = "";
            //var salesHeader = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            //List<int> values = new List<int>();
            //if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles != null)
            //{
            //    if (salesHeader.Any(x => x.SalesOrderLine.Count > 0))
            //    {
            //        var thisHeader = salesHeader.Where(x => x.EmployeeID == empId && x.UCodeId == ucode).First();

            //        foreach (var saleLines in thisHeader.SalesOrderLine.Where(x => x.orgStyleId != null))
            //        {
            //            var thisOrgStyle = saleLines.orgStyleId;
            //            if (orgStyleNPoints.Any(x => x.OrgStyle == thisOrgStyle))
            //            {
            //                foreach (var styl in orgStyleNPoints.Where(x => x.OrgStyle == saleLines.orgStyleId).Select(x => x.Style).ToList())
            //                {
            //                    if (_vuPointsCard.Exists(x => x.EmployeeID == empId && x.StyleID == styl && x.BusinessID == busId))
            //                    {
            //                        int soPts = _vuPointsCard.GetAll(x => x.EmployeeID == empId && x.StyleID == styl && x.BusinessID == busId).First().SOPoints.Value;
            //                        int thisPt = _pointStyle.GetAll(x => x.StyleID == styl && x.BusinessID == busId && x.UcodeID == ucode).First().Points.Value;
            //                        prevPoints = prevPoints + (soPts / thisPt);
            //                    }
            //                }
            //                qtny = thisHeader.SalesOrderLine.Where(x => x.orgStyleId == thisOrgStyle && x.orgStyleId != null).Sum(x => x.OrdQty);
            //                var lst = thisHeader.SalesOrderLine.Where(x => x.orgStyleId == thisOrgStyle && x.orgStyleId != null).Select(s=>s.StyleID).ToList();
            //                var dataOnCart = orgStyleNPoints.Where(x => x.OrgStyle == thisOrgStyle && lst.Contains(x.Style)).OrderBy(x => x.Points).ToList();
            //                if (qtny >= minOrdQty | prevPoints >= minOrdQty)
            //                {
            //                    values.Add(0);
            //                }
            //                else
            //                {
            //                    if (thisOrgStyle != orgStyl)
            //                    {
            //                        values.Add(dataOnCart.Sum(s=>s.Points));
            //                    }
            //                }
            //            }
            //        }
            //    }

            //}
            //var salesHead = Session["SalesOrderHeader"] != null ? (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"] : new List<SalesOrderHeaderViewModel>();

            //var salesLines = salesHead.Any(x => x.UCodeId == Ucodes && x.SalesOrderLine.Count > 0) ? salesHead.Where(x => x.UCodeId == Ucodes && x.SalesOrderLine.Count > 0).Select(x => x.SalesOrderLine).First() : new List<SalesOrderLineViewModel>();
            //busId = Session["BuisnessId"].ToString();
            //var points = _pointStyle.Exists(x => x.BusinessID == busId && x.StyleID == style && x.UcodeID == Ucodes) ? _pointStyle.GetAll(x => x.BusinessID == busId && x.StyleID == style && x.UcodeID == Ucodes).First().Points : 0;
            //int totCardPts = _vuPointsCard.Exists(x => x.BusinessID == busId & x.EmployeeID == empId & x.Year == 0) ? _vuPointsCard.GetAll(x => x.BusinessID == busId & x.EmployeeID == empId & x.Year == 0).ToList().Sum(x => x.SOPoints).Value : 0;
            //int totalPoints = ((PointsModel)Session["Pointsmodel"]).TotalPoints;
            //totalPoints = totCardPts == totalPoints ? totalPoints : totalPoints - totCardPts;
            //int totBaskPoints = salesOrderLines.Count > 0 ? salesOrderLines.Sum(x => x.TotalPoints) : 0;
            //int valuePts = values.Count > 0 ? values.Sum() : 0;
            //if (orgStyleNPoints.Any(x => x.OrgStyle == orgStyl))
            //{
            //    if (orgStyleNPoints.Where(x => x.OrgStyle == orgStyl).First().MinPoints > 1 && Convert.ToInt32(qty) < orgStyleNPoints.Where(x => x.OrgStyle == orgStyl).First().MinPoints)
            //    {
            //        valuePts = salesLines.Any(x => x.orgStyleId == orgStyl) | prevPoints > minOrdQty ? valuePts : valuePts + orgStyleNPoints.Where(x => x.OrgStyle == orgStyl).OrderBy(x => x.Points).First().Points;
            //    }
            //}
            //int availablePoints = totBaskPoints > 0 ? totalPoints - totBaskPoints - valuePts : totalPoints;
            //int pointsUsed = points.Value * Convert.ToInt32(qty);
            //availablePoints = availablePoints - pointsUsed;

            //return result = availablePoints >= 0 ? "enabled" : "";
        }

        #endregion

        #region Getlast Seleceted Size based on style
        public JsonResult GetLastSize(string style = "")
        {
            var result = default(object);
            string businessId = Session["BuisnessId"].ToString();
            if (style != "")
            {
                var prevHistory = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), style);

                if (prevHistory.Size != "")
                {
                    prevHistory.price = _styleSizePrice.Exists(x => x.StyleID == style && x.SizeID == prevHistory.Size && x.PriceID == 2) ? Math.Round(_styleSizePrice.GetAll(x => x.StyleID == style && x.SizeID == prevHistory.Size && x.PriceID == 2 && x.BusinessId == businessId).First().Price.Value, 2).ToString() : "";
                }
                result = prevHistory;
                return Json(result);
            }
            return Json(result);
        }
        #endregion

        #region Cardviewnew
        public ActionResult CardViewPartialnew(List<int> selectedItem = null, bool pages = false, string filterText = "", bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = new List<styleViewmodel>();
            var svm = new styleViewmodel();
            string businessId = Session["BuisnessId"].ToString();
            if (((List<string>)Session["Templates"]).Count > 0)
            {
                List<string> result = (List<string>)Session["SelectedTemplates"];
                foreach (var item in result)
                {
                    model.AddRange(_dataConnection.GetStyleViewModel(item, businessId));
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                foreach (var data1 in model)
                {
                    data1.Assembly = _customAssembly.Exists(d => d.ParentStyleID == data1.StyleID & d.isChargeable == false & d.CustID == businessId) |
                            _allAssemblies.Exists(d => d.ParentStyleID == data1.StyleID & d.isChargeable == false) ? 1 : 0;
                    data1.Description = _tblFskStyle.GetAll(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                }
                foreach (var data1 in model)
                {

                    if (!data1.StyleID.Contains(","))
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                    }
                    else
                    {
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                    }
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
                if (filterText != "")
                {
                    model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower())) ? model.Where(x => x.StyleID.ToLower().Contains(filterText.ToLower())).ToList() : null;
                }
                model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                if (BringImages | Session["ImageFilter"] != null)
                {
                    if (BringImages | (bool)Session["ImageFilter"] != null)
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                if (selectedItem != null)
                {
                    model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.ProductGroup,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = x.Assembly,
                        ColourId = x.ColourId,
                        SizeId = x.SizeId,
                        isAllocated = x.isAllocated,
                        Dimensions = x.Dimensions,
                        Freetext = x.Freetext,
                        SeqNO = x.SeqNO,
                        OriginalStyleid = x.StyleID,
                        HasPreviousSize = x.HasPreviousSize,
                        Description = x.Description,
                        Caption = x.Caption,
                        Price = x.Price
                    }).ToList();
                }

            }
            else
            {
                try
                {
                    var freetext = Allocation.DIMALLOC.ToString();

                    string custId = Session["BuisnessId"].ToString();
                    int tempCount = ((List<UcodeModel>)Session["UcodeStyle"]) != null ? ((List<UcodeModel>)Session["UcodeStyle"]).Count : 0;
                    Session["Selected"] = selectedItem;
                    ViewBag.page = pages;
                    if (tempCount > 0)
                    {
                        string ucode = Session["SelectedUcode"].ToString();
                        List<string> freeTextLst = (List<string>)Session["UcFreeTxt"];
                        model = _ucodeByFreetext.GetAll(x => freeTextLst.Contains(x.FreeText) & x.UCodeID == ucode).Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                            Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false & d.CustID == custId) |
                            _allAssemblies.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false) ? 1 : 0,
                            isAllocated = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                            Dimensions = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                            SeqNO = x.SeqNo.Value,
                            Freetext = x.FreeText,
                            OriginalStyleid = x.StyleID
                        }).ToList();
                    }
                    else
                    {
                        model = new List<styleViewmodel>();
                    }
                    if (selectedItem != null)
                    {
                        model = model.Where(x => selectedItem.Contains(x.ProductGroup)).Select(x => new styleViewmodel
                        {
                            StyleID = x.StyleID,
                            ProductGroup = x.ProductGroup,
                            StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                            Assembly = x.Assembly,
                            ColourId = x.ColourId,
                            SizeId = x.SizeId,
                            isAllocated = x.isAllocated,
                            Dimensions = x.Dimensions,
                            Freetext = x.Freetext,
                            SeqNO = x.SeqNO,
                            OriginalStyleid = x.StyleID,
                            HasPreviousSize = x.HasPreviousSize,
                            Description = x.Description,
                            Caption = x.Caption,
                            Price = x.Price
                        }).ToList();
                    }


                    foreach (var data1 in model)
                    {
                        data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : _dataConnection.GetFitAllocString(data1.Freetext);
                    }
                    foreach (var data1 in model)
                    {
                        data1.Description = _tblFskStyle.GetAll(x => data1.StyleID.Contains(x.StyleID)).First().Description;
                        if (!data1.StyleID.Contains(","))
                        {
                            data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID);
                        }
                        else
                        {
                            data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.StyleID.Split(',')[0]);
                        }
                        if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                        {
                            data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                        }
                        else
                        {
                            data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                        }
                    }
                    if (filterText != "")
                    {
                        model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())) ? model.Where(x => x.StyleID.ToLower().Trim().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())).ToList() : null;
                    }
                    model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                    if (BringImages | (bool)Session["ImageFilter"])
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                catch (Exception e)
                {
                    logger .Warn(e.Message);logger.Warn(e.StackTrace);;

                }
            }
            return PartialView("_CardViewPartial", model.Distinct());
        }
        #endregion

        #region  GetClrImg
        public string GetClrImg(string style = "")
        {
            string result = "";
            if (style != "")
            {
                var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
                var stylClr = style.Split('-');
                var styl = stylClr[0];
                var clr = stylClr[1];
                try
                {
                    var dat = _style_Colour.Exists(x => x.StyleID.ToLower() == styl && x.ColourID.Contains(clr)) ? _style_Colour.GetAll(x => x.StyleID.ToLower() == styl && x.ColourID.Contains(clr)).First().StyleImage : "";

                    if (System.IO.File.Exists(appPath + dat) != true)
                    {
                        dat = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        dat = Url.Content("~/" + dat);
                    }

                    result = "<img src='" + dat + "' height='70%' width='70%' onclick=\"Getimage('" + dat + "')\" />";
                }
                catch (Exception e)
                {
                    logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                }
            }
            return result;
        }
        #endregion

        #region GetValuesData
        public bool GetValuesData(string orgStyl)
        {

            var orgStyleNPoints = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);
            string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
            var ucodStylesLst = _dp.UcodeStyles(Ucodes, Session["BuisnessId"].ToString());
            string busId = Session["BuisnessId"].ToString();
            string empId = (Session["SelectedEmp"].ToString());
            var salesHeader = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            string ucode = Session["SelectedUcode"].ToString();
            var thisHeader = salesHeader.Where(x => x.EmployeeID == empId && x.UCodeId == ucode).First();
            int prevPoints = 0;
            long qtny = 0;
            int minOrdQty = 0;
            List<int> values = new List<int>();
            minOrdQty = _pointStyle.Exists(x => x.StyleID == orgStyl && x.UcodeID == ucode && x.BusinessID == busId) ? _pointStyle.GetAll(x => x.StyleID == orgStyl && x.UcodeID == ucode && x.BusinessID == busId).First().MinPts.Value : 0;
            if (_vuPointsCard.Exists(x => x.EmployeeID == empId && ucodStylesLst.Contains(x.StyleID)))
            {
                var orgStyleIdLst = thisHeader.SalesOrderLine.Where(x => x.orgStyleId != null && x.IsDleted == false).Select(s => s.orgStyleId).ToList();



                if (orgStyleNPoints.Any(x => orgStyleIdLst.Contains(x.OrgStyle)))
                {
                    var sss = orgStyleNPoints.Where(x => orgStyleIdLst.Contains(x.OrgStyle)).Select(x => x.Style).ToList();

                    foreach (var styl in _vuPointsCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == empId && sss.Contains(s.StyleID) && ucodStylesLst.Contains(s.StyleID)).Select(s => s.StyleID).ToList())
                    {
                        int soPts = _dp.GetTotalSOPointsByStyle(busId, empId, 0, styl);
                        int thisPt = _pointStyle.GetAll(x => x.StyleID == styl && x.BusinessID == busId && x.UcodeID == ucode).First().Points.Value;
                        prevPoints = prevPoints + (soPts / thisPt);
                    }
                    qtny = thisHeader.SalesOrderLine.Where(x => orgStyleIdLst.Contains(x.orgStyleId) && x.orgStyleId != null).Sum(x => x.OrdQty);
                    var lst = thisHeader.SalesOrderLine.Where(x => orgStyleIdLst.Contains(x.orgStyleId) && x.orgStyleId != null).Select(s => s.StyleID).ToList();
                    var dataOnCart = orgStyleNPoints.AsEnumerable().Where(x => orgStyleIdLst.Contains(x.OrgStyle) && lst.Contains(x.Style)).OrderBy(x => x.Points).ToList();
                    if (qtny >= minOrdQty | prevPoints >= minOrdQty)
                    {
                        values.Add(0);
                    }
                    else
                    {
                        if (orgStyleIdLst.Contains(orgStyl))
                        {
                            values.Add(dataOnCart.Sum(s => s.Points));
                        }
                    }

                }
            }

            return values.Sum() > 0 ? false : true;
        }
        #endregion

        #region GetBasketStatus
        [HttpPost]
        public string GetBasketStatus()
        {
            List<string> CatCaptions = new List<string>();
            string result = "fail";
            List<string> adjmapStyl = new List<string>();
            List<string> adjStyl = new List<string>();
            string busId = Session["BuisnessId"].ToString();
            string ucode = Session["SelectedUcode"].ToString();
            var salesHeader = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            string empId = (Session["SelectedEmp"].ToString());
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                if (Convert.ToBoolean(Session["IsBulkOrder1"]))
                {
                    return "";
                }
                else if (Convert.ToBoolean(Session["IsEmergency"]) && Convert.ToBoolean(Session["REQSTKLEVEL"]))
                {

                    if (salesHeader.Any(x => x.SalesOrderLine != null) && salesHeader.Any(x => x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0))
                    {
                        string retunCnt = "";
                        var thisHeader1 = salesHeader.Where(x => x.EmployeeID == empId && x.UCodeId == ucode).First();
                        var model = thisHeader1.SalesOrderLine;
                         
                        var newResult = model.GroupBy(s => new { s.StyleID, s.ColourID, s.SizeID, s.IsDleted, s.IsAlternateStyle }).
                            Select(sa => new SalesOrderLineViewModel
                            {
                                IsAlternateStyle = sa.First().IsAlternateStyle,
                                StyleID = sa.First().StyleID.Trim(),
                                ColourID = sa.First().ColourID.Trim(),
                                SizeID = sa.First().SizeID.Trim(),
                                OrdQty = sa.Sum(s => s.OrdQty),
                                Description = sa.First().Description,
                                Price = sa.First().Price,
                                Cost1 = sa.First().Cost1,
                                IssueUOM1 = sa.First().IssueUOM1,
                                IssueQty1 = sa.First().IssueQty1,
                                Currency_Exchange_Rate = sa.First().Currency_Exchange_Rate,
                                StyleIDref = sa.First().StyleIDref,
                                VatCode1 = sa.First().VatCode1,
                                RepId = sa.First().RepId,
                                KAMID = sa.First().KAMID,
                                RepRate1 = sa.First().RepRate1,
                                KAMRate1 = sa.First().KAMRate1,
                                OriginalOrderNo = sa.First().OriginalOrderNo,
                                AssemblyID = sa.First().AssemblyID,
                                AsmLineNo = sa.First().AsmLineNo,
                                ReturnOrderNo = sa.First().ReturnOrderNo,
                                ReturnLineNo = sa.First().ReturnLineNo,
                                SOPDetail5 = sa.First().SOPDetail5,
                                SOPDetail4 = sa.First().SOPDetail4,
                                IsDleted = sa.First().IsDleted
                            }).ToList();
                        if (Convert.ToBoolean(Session["ISEDITING"]) == false)
                        {
                            if (newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle).Count() > 0 && newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle == false).Count() == 0)
                            {
                                result = retunCnt;
                            }
                            else
                            {
                                foreach (var line in newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle == false))
                                {
                                    var freeStock = _dp.GetFreeStock(line.StyleID, line.ColourID, line.SizeID, Session["WareHouseID"].ToString(), null, Convert.ToBoolean(Session["ISEDITING"]));
                                    if (line.OrdQty > freeStock)
                                    {
                                        retunCnt = retunCnt + "{%FREESTOCKERROR%}The ordered quantity(" + line.OrdQty + ") for product " + line.Description + "(" + line.StyleID + ") " + line.ColourID + " " + line.SizeID + " is grater than the available freestock quantity (" + freeStock + ")\n";
                                        return retunCnt;
                                    }
                                    else
                                    {
                                        retunCnt = "";
                                    }
                                    result = retunCnt;
                                }
                            }
                        }
                        else
                        {
                            if (newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle).Count() > 0 && newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle == false).Count() == 0)
                            {
                                result = retunCnt;
                            }
                            else
                            {
                                foreach (var line in newResult.Where(s => s.IsDleted == false && s.IsAlternateStyle == false))
                                {

                                    var freeStock = _dp.GetFreeStock(line.StyleID, line.ColourID, line.SizeID, Session["WareHouseID"].ToString(), model, true, false);
                                    //freeStock = freeStock +Convert.ToInt32 (line.OrdQty);
                                    if (line.OrdQty > freeStock)
                                    {
                                        var freeStock1 = freeStock - line.OrdQty > 0 ? freeStock - line.OrdQty : 0;
                                        retunCnt = retunCnt + "{%FREESTOCKERROR%}The ordered quantity(" + line.OrdQty + ") for product " + line.Description + "(" + line.StyleID + ") " + line.ColourID + " " + line.SizeID + " is grater than the available freestock quantity (" + freeStock + ")\n";
                                        return retunCnt;
                                    }
                                    else
                                    {
                                        retunCnt = "";
                                    }
                                    result = retunCnt;
                                }
                            }
                        }


                    }
                }
                else
                {
                    if (((List<string>)Session["Templates"]).Count > 0)
                    {
                        return "";
                    }
                    else
                    {

                        var orgStyleNPoints = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);

                        if (_pointsAdjustment.Exists(s => s.BusinessID == busId && s.UcodeID == ucode))
                        {
                            adjmapStyl = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.MapStyleID).Distinct().ToList();
                            adjStyl = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucode).Select(s => s.StyleID).Distinct().ToList();
                        }
                        List<ResultChk> values = new List<ResultChk>();
                        if (salesHeader.Any(x => x.SalesOrderLine != null) && salesHeader.Any(x => x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0))
                        {
                            if (Convert.ToBoolean(Session["POINTSREQ"]) && Convert.ToBoolean(Session["IsEmergency"]) == false && _dp.CheckEmergency(busId, ucode) == false)
                            {
                                if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles != null)
                                {
                                    var stylst = orgStyleNPoints.Where(x => x.MinPoints > 0).Select(x => new { x.OrgStyle, x.CatCaption, x.MinPoints });
                                    var thisHeader1 = salesHeader.Where(x => x.EmployeeID == empId && x.UCodeId == ucode).First();
                                    string Content = "";
                                    int prevPoiunt = 0;
                                    var orgnlPoints = orgStyleNPoints.Select(x => x.OrgStyle).Distinct().ToList();
                                    foreach (var orstyl in orgnlPoints)
                                    {
                                        try
                                        {
                                            var pts = 0;
                                            var lst = orgStyleNPoints.Where(x => x.OrgStyle == orstyl).Distinct().ToList();
                                            foreach (var sinl in lst)
                                            {
                                                var hasFit = _fskStyleFreetext.Exists(ss => ss.StyleId == sinl.Style && ss.FreeTextType == "FITALLOC") ? _fskStyleFreetext.GetAll(ss => ss.StyleId == sinl.Style && ss.FreeTextType == "FITALLOC").First().FreeText : sinl.Style;
                                                var fitStyles = "";
                                                if (hasFit != "")
                                                {
                                                    fitStyles = _styleByFreetext.Exists(ss => ss.FreeText == hasFit) ? _styleByFreetext.GetAll(ss => ss.FreeText == hasFit).First().StyleID : "";

                                                }
                                                if (fitStyles.Contains(','))
                                                {
                                                    foreach (var stylo in fitStyles.Split(','))
                                                    {
                                                        if (_pointsCard.Exists(x => x.BusinessID == busId & x.EmployeeID == empId & x.StyleID == stylo))
                                                        {

                                                            int ovrAlPts = 0;
                                                            if (adjmapStyl.Count > 0)
                                                            {
                                                                if (adjStyl.Contains(stylo))
                                                                {
                                                                    if (salesHeader.Where(s => s.UCodeId == ucode && s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == true).Any(s => s.StyleID == stylo))
                                                                    {
                                                                        continue;
                                                                    }
                                                                    pts = pts + _dp.GetTotalSOPointsByStyle(busId, empId, 0, stylo);
                                                                    pts = pts + _dp.GetTotalSOPointsByStyleMap(busId, empId, 0, adjmapStyl) / orgStyleNPoints.Where(x => adjmapStyl.Contains(x.Style)).First().Points;
                                                                    ovrAlPts = (orgStyleNPoints.Where(x => x.Style == orstyl).First().TruePoints);

                                                                }
                                                                else
                                                                {
                                                                    if (salesHeader.Where(s => s.UCodeId == ucode && s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == true).Any(s => s.StyleID == stylo))
                                                                    {
                                                                        continue;
                                                                    }
                                                                    pts = pts + _dp.GetTotalSOPointsByStyle(busId, empId, 0, stylo);
                                                                    ovrAlPts = (orgStyleNPoints.Where(x => x.Style == orstyl).OrderBy(x => x.Points).First().Points) * (orgStyleNPoints.Where(x => x.Style == orstyl).First().TruePoints);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (salesHeader.Where(s => s.UCodeId == ucode && s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == true).Any(s => s.StyleID == stylo))
                                                                {
                                                                    continue;
                                                                }
                                                                pts = pts + _dp.GetTotalSOPointsByStyle(busId, empId, 0, stylo);
                                                                ovrAlPts = (orgStyleNPoints.Where(x => x.Style == orstyl).OrderBy(x => x.Points).First().Points) * (orgStyleNPoints.Where(x => x.Style == orstyl).First().TruePoints);
                                                            }

                                                            if (pts >= ovrAlPts)
                                                            {
                                                                CatCaptions.Add(sinl.CatCaption);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (_pointsCard.Exists(x => x.BusinessID == busId & x.EmployeeID == empId & x.StyleID == sinl.Style))
                                                    {
                                                        int ovrAlPts = 0;
                                                        if (adjmapStyl.Count > 0)
                                                        {

                                                            if (adjStyl.Contains(sinl.Style))
                                                            {
                                                                if (salesHeader.Where(s => s.UCodeId == ucode && s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == true).Any(s => s.StyleID == sinl.Style))
                                                                {
                                                                    continue;
                                                                }
                                                                pts = pts + _dp.GetTotalSOPointsByStyle(busId, empId, 0, sinl.Style);
                                                                pts = pts + _dp.GetTotalSOPointsByStyleMap(busId, empId, 0, adjmapStyl) / orgStyleNPoints.Where(x => adjmapStyl.Contains(x.Style)).First().Points;
                                                                ovrAlPts = (orgStyleNPoints.Where(x => x.Style == orstyl).OrderBy(x => x.Points).First().Points) * (orgStyleNPoints.Where(x => x.Style == orstyl).First().TruePoints);

                                                            }
                                                            else
                                                            {
                                                                if (salesHeader.Where(s => s.UCodeId == ucode && s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == true).Any(s => s.StyleID == sinl.Style))
                                                                {
                                                                    continue;
                                                                }
                                                                pts = pts + _dp.GetTotalSOPointsByStyle(busId, empId, 0, sinl.Style);
                                                                ovrAlPts = (orgStyleNPoints.Where(x => x.Style == orstyl).OrderBy(x => x.Points).First().Points) * (orgStyleNPoints.Where(x => x.Style == orstyl).First().TruePoints);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (salesHeader.Where(s => s.UCodeId == ucode && s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.IsDleted == true).Any(s => s.StyleID == sinl.Style))
                                                            {
                                                                continue;
                                                            }
                                                            pts = pts + _dp.GetTotalSOPointsByStyle(busId, empId, 0, sinl.Style);
                                                            ovrAlPts = (orgStyleNPoints.Where(x => x.Style == orstyl).OrderBy(x => x.Points).First().Points) * (orgStyleNPoints.Where(x => x.Style == orstyl).First().TruePoints);
                                                        }

                                                        if (pts >= ovrAlPts)
                                                        {
                                                            CatCaptions.Add(sinl.CatCaption);
                                                            break;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            logger .Warn(e.Message);logger.Warn(e.StackTrace);;
                                        }

                                    }
                                    var ss1 = stylst.Distinct().ToList();
                                    foreach (var str in stylst.Distinct())
                                    {
                                        if (CatCaptions.Contains(str.CatCaption) != true)
                                        {
                                            if (thisHeader1.SalesOrderLine.Any(x => x.orgStyleId == str.OrgStyle && x.IsDleted == false))
                                            {
                                                var adjPoint = 0;
                                                if (adjStyl.Contains(str.OrgStyle))
                                                {
                                                    if (thisHeader1.SalesOrderLine.Any(s => adjmapStyl.Contains(s.StyleID) && s.IsDleted == false))
                                                    {
                                                        adjPoint = Convert.ToInt32(thisHeader1.SalesOrderLine.Where(s => adjmapStyl.Contains(s.StyleID) && s.IsDleted == false).Sum(s => s.OrdQty));
                                                    }
                                                }
                                                if (Content.Contains(str.CatCaption) == false)
                                                {
                                                    Content = thisHeader1.SalesOrderLine.Where(x => x.orgStyleId == str.OrgStyle && x.IsDleted == false).Sum(x => x.OrdQty) >= str.MinPoints - adjPoint ? Content : Content + "The mandatory quantity not ordered for catagory " + str.CatCaption + " \n";
                                                }

                                            }
                                            else
                                            {
                                                if (Content.Contains(str.CatCaption) == false)
                                                {
                                                    Content = Content + "The mandatory quantity not ordered for catagory " + str.CatCaption + " \n";
                                                }
                                            }
                                        }
                                    }
                                    return Content != "" ? Content + "///" : Content + "";
                                }
                                else
                                {
                                    if (salesHeader.Any(x => x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0))
                                    {
                                        result = "";
                                    }
                                }
                            }
                            else
                            {
                                if (salesHeader.Any(x => x.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0))
                                {
                                    result = "";
                                }
                            }
                        }
                        //else if (Convert.ToBoolean(Session["ISEDITING"]))
                        //{
                        //    //foreach (var saleHead in salesHeader)
                        //    //{
                        //    //    if (saleHead.SalesOrderLine == null || saleHead.SalesOrderLine.Count == 0)
                        //    //    {
                        //    //        _salesOrderHeader.Delete(s => s.OrderNo == saleHead.OrderNo);
                        //    //        _salesOrderLines.Delete(s => s.OrderNo == saleHead.OrderNo);

                        //    //    }
                        //    //}
                        //    var resultDelte = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault();
                        //    if (resultDelte.SalesOrderLine.Any(x => x.IsDleted && x.Isedit))
                        //    {
                        //        foreach (var rest in resultDelte.SalesOrderLine.Where(x => x.IsDleted && x.Isedit))
                        //        {

                        //            if (_salesOrderLines.Exists(s => s.OrderNo == resultDelte.OrderNo && s.LineNo == rest.LineNo && s.StyleID.ToLower().Trim() == rest.StyleID.ToLower().Trim()))
                        //            {
                        //                _salesOrderLines.Delete(s => s.OrderNo == resultDelte.OrderNo && s.LineNo == rest.LineNo && s.StyleID.ToLower().Trim() == rest.StyleID.ToLower().Trim());
                        //            }
                        //            var stockCardQty = resultDelte.SalesOrderLine.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().SoqtyForempSO;
                        //            var pointCardQty = resultDelte.SalesOrderLine.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().SoqtyForempSOPoints;
                        //            var EmpId = resultDelte.SalesOrderLine.Where(x => x.LineNo == rest.LineNo && x.Isedit).First().EmployeeId;
                        //            if (stockCardQty > 0)
                        //            {
                        //                var updStock = _stockCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == rest.StyleID).First();
                        //                updStock.SOQty = updStock.SOQty - Convert.ToInt32(stockCardQty);
                        //                _stockCard.Update(updStock);
                        //            }
                        //            if (pointCardQty > 0)
                        //            {
                        //                var updStock = _pointsCard.GetAll(s => s.EmployeeID == EmpId && s.StyleID == rest.StyleID).First();
                        //                updStock.SOPoints = updStock.SOPoints - Convert.ToInt32(pointCardQty);
                        //                _pointsCard.Update(updStock);
                        //            }
                        //        }
                        //    }

                        //    result = "";
                        //}

                        return result;
                    }

                }
            }
            else
            {
                result = "no items";
            }
            return result;

        }

        #endregion

        #region GetOrderEnforcementStatus
        public string GetOrderEnforcementStatus()
        {
            string result = "";
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                string ucode = Session["SelectedUcode"].ToString();
                var ucodStylesLst = _dp.UcodeStyles(ucode, Session["BuisnessId"].ToString());
                string busId = Session["BuisnessId"].ToString();

                string empId = Session["SelectedEmp"].ToString();
                int enforcemntvalue = Session["RO_PER_FIRSTORDER"] != null ? Convert.ToInt32(Session["RO_PER_FIRSTORDER"]) : 0;
                var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(s => s.UCodeId == s.UCodeId && s.EmployeeID == empId) ?
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.UCodeId == s.UCodeId && s.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
                if (enforcemntvalue > 0 && _pointsByUcode.Exists(s => s.BusinessID == busId && s.UcodeID == ucode) && _dp.CheckEmergency(busId, ucode) == false)
                {
                    if (_pointsCard.Exists(s => s.EmployeeID == empId && s.BusinessID == busId && ucodStylesLst.Contains(s.StyleID)))
                    {

                    }
                    else
                    {
                        int totalPoints = _pointsByUcode.Exists(s => s.UcodeID == ucode) ? _pointsByUcode.GetAll(s => s.UcodeID == ucode).First().TotalPoints.Value : 0;
                        long cartPoints = salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0 ? salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Sum(s => s.TotalPoints) : 0;
                        int cardPoints = 0;
                        long cartQty = salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0 ? salesHead.SalesOrderLine.Where(s => s.IsDleted == false).Sum(s => s.OrdQty) : 0;
                        if (Convert.ToBoolean(Session["ISEDITING"]) == false)
                        {
                            cardPoints = _vuPointsCard.Exists(s => s.BusinessID == busId && s.EmployeeID == empId && ucodStylesLst.Contains(s.StyleID)) ? Convert.ToInt32(_vuPointsCard.GetAll(s => s.BusinessID == busId && s.EmployeeID == empId && ucodStylesLst.Contains(s.StyleID)).Sum(s => s.TOTSOPOINTS).Value) : 0;
                        }
                        if (cartPoints > 0 || cartQty > 0)
                        {
                            int totalvaluetoorder = (totalPoints * enforcemntvalue) / 100;
                            if ((cartPoints + cardPoints) >= totalvaluetoorder)
                            {

                                result = "";
                            }
                            else
                            {
                                result = "Please take " + totalvaluetoorder + " points which is " + enforcemntvalue + "% of your total points (" + totalPoints + "). In the cart you only have " + cartPoints + " points. Please continue shopping.";
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region GetReqData
        [HttpPost]
        public string GetReqData(string StyleID)
        {
            string lblValue = "";
            lblValue = _dataConnection.GetReqData(StyleID);
            return lblValue;
        }
        #endregion

        #region GetMinPointsnBasketPts
        //public string GetMinPointsnBasketPts(string style)
        //{
        //    string result = "";


        //}
        #endregion

        #region GetPointsDiv

        public JsonResult GetPointsDiv(string orgStyle)
        {
            PointsResult1 result = new PointsResult1();
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                if (((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).LstStyles.Count > 0)
                {
                    string busId = Session["BuisnessId"].ToString();
                    string ucode = Session["SelectedUcode"].ToString();
                    string empId = Session["SelectedEmp"].ToString();
                    var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == empId) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
                    var salesLine = salesHead.SalesOrderLine.Where(s => s.IsDleted == false);
                    var salesLineDelted = salesHead.SalesOrderLine.Where(s => s.IsDleted == true);
                    int totCardPts = 0, totPoints = 0, inCartPoints = 0, availabelPoints = 0, usedPoints = 0, totDelPts = 0, totalOtherPoints = 0, ptsNanCard = 0, previousPoints = 0;
                    if (Convert.ToBoolean(Session["ISEDITING"]))
                    {

                        foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != salesHead.OrderNo && s.OrderType.ToLower() == "so").ToList())
                        {
                            foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                            {
                                if (_pointStyle.Exists(s => s.StyleID == lien.StyleID && s.UcodeID == ucode))
                                {
                                    totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                                }
                            }
                        }
                        totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                        inCartPoints = salesLine.Count() > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                        totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                        totDelPts = salesLineDelted.Count() > 0 ? salesLineDelted.Sum(x => x.TotalPoints) : 0;
                        ptsNanCard = totPoints - totCardPts;
                        usedPoints = inCartPoints + totalOtherPoints;
                        previousPoints = totCardPts - usedPoints;
                        availabelPoints = (totPoints - usedPoints) - previousPoints;
                        //foreach (var otherOrders in _salesOrderHeader.GetAll(s => s.UCodeId == ucode && s.PinNo == empId && s.OrderNo != salesHead.OrderNo && s.OrderType.ToLower() == "so").ToList())
                        //{
                        //    foreach (var lien in _salesOrderLines.GetAll(s => s.OrderNo == otherOrders.OrderNo).ToList())
                        //    {
                        //        totalOtherPoints = totalOtherPoints + Convert.ToInt32(lien.OrdQty) * (_pointStyle.GetAll(s => s.StyleID == lien.StyleID && s.UcodeID == ucode).First().Points.Value);
                        //    }
                        //}
                        //totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                        //inCartPoints = salesLine.Count() > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                        //totCardPts = _dp.GetTotalSoPoints(busId, empId);
                        //totDelPts = salesLineDelted.Count() > 0 ? salesLineDelted.Sum(x => x.TotalPoints) : 0;
                        ////totCardPts = totCardPts;
                        //if (totalOtherPoints == 0)
                        //{
                        //    totalOtherPoints = totCardPts - inCartPoints;
                        //}

                        //totCardPts = totCardPts - (totalOtherPoints);
                        //if (inCartPoints == totCardPts)
                        //{
                        //    availabelPoints = totalOtherPoints > 0 ? (totPoints - totCardPts) - totalOtherPoints : totPoints - totCardPts;
                        //    usedPoints = totalOtherPoints > 0 ? (totPoints - availabelPoints) - totalOtherPoints : totPoints - availabelPoints;
                        //}
                        //else
                        //{
                        //    availabelPoints = totalOtherPoints > 0 ? ((totPoints + (totCardPts - inCartPoints)) - totCardPts) - totalOtherPoints : (totPoints + (totCardPts - inCartPoints)) - totCardPts;
                        //    usedPoints = totPoints - availabelPoints;

                        //}
                    }
                    else
                    {
                        totCardPts = _dp.GetTotalSoPoints(busId, empId, 0, (List<string>)_dp.UcodeStyles(ucode, busId));
                        totPoints = ((Maximus.Data.models.PointsModel)Session["Pointsmodel"]).TotalPoints;
                        inCartPoints = salesLine.Count() > 0 ? salesLine.Sum(x => x.TotalPoints) : 0;
                        availabelPoints = totPoints - inCartPoints - totCardPts;
                        usedPoints = totPoints - availabelPoints;
                    }
                    result.PointsDiv = "<div class='col-md-6'> <span><b>Total Points: </b></span>  " + totPoints + " </div> <div class='col-md-6'> <span><b>Available Points: </b></span>" + availabelPoints + " </div> <div class='col-md-6'> <span><b>Used Points: </b></span>" + usedPoints + " </div><div class='col-md-6'> <span><b>Cart Points: </b></span>" + inCartPoints + " </div>";
                    var pointsinCart = salesLine.Any(s => s.orgStyleId == orgStyle) ? salesLine.Where(s => s.orgStyleId == orgStyle).Sum(s => s.OrdQty) : 0;
                    var SSSS = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]);
                    result.PointsTaken = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Any(x => x.OrgStyle == orgStyle) ? "<center class='mandatoryStylecart'><span class='mandatoryStyle'>The mandatory quantity is :<b>" + ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => x.OrgStyle == orgStyle).Min(x => x.MinPoints) + "</b></span>&nbsp;&nbsp;&nbsp;The quantity in cart is :<b>" + pointsinCart + "</b><center>" : "";
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region UpdateMinPoints
        public JsonResult UpdateMinPoints(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "", string orgStyl = "", string entQty = "", string reqData1 = "", string reason = "", string QtySizePriceArr = "", string selectedSitecode = "")
        {
            PointsResult result = new PointsResult();
            result.message = "noVal";
            result.pointsStyle = new List<string>();
            string busId = Session["BuisnessId"].ToString();
            string ucodeId = Session["selectedUcodes"].ToString();
            List<SalesOrderLineViewModel> slsLines = new List<SalesOrderLineViewModel>();
            var orgSaleLine = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.UCodeId == ucodeId).First().SalesOrderLine.Where(s => s.IsDleted == false);
            if (orgSaleLine.Count() > 0)
            {
                slsLines.AddRange(orgSaleLine);
                slsLines.Add(new SalesOrderLineViewModel { StyleID = style, orgStyleId = orgStyl, OrdQty = Convert.ToInt64(qty) });
            }
            else
            {
                slsLines.Add(new SalesOrderLineViewModel { StyleID = style, orgStyleId = orgStyl, OrdQty = Convert.ToInt64(qty) });
            }
            var LSqT12 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]);
            try
            {

                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).First().SalesOrderLine = slsLines.Where(s => s.IsDleted == false).ToList();
            }
            catch (Exception e)
            {
                logger .Warn(e.Message);logger.Warn(e.StackTrace);;
            }

            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).First().SalesOrderLine.Where(s => s.IsDleted == false).Count() > 0)
            {
                var lstPtsAdj = _pointsAdjustment.Exists(s => s.StyleID == style && s.BusinessID == busId && s.UcodeID == ucodeId) ? _pointsAdjustment.GetAll(s => s.StyleID == style && s.BusinessID == busId && s.UcodeID == ucodeId).Select(x => new pointsChange { styl = x.MapStyleID, type = "MapStyleID" }).ToList() : _pointsAdjustment.Exists(s => s.MapStyleID == style && s.BusinessID == busId && s.UcodeID == ucodeId) ? _pointsAdjustment.GetAll(s => s.MapStyleID == style && s.BusinessID == busId && s.UcodeID == ucodeId).Select(x => new pointsChange { styl = x.StyleID, type = "orgStyleID" }).ToList() : new List<pointsChange>();
                var LST12 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]);
                var reslt = lstPtsAdj.Select(s => s.styl).ToList();

                if (lstPtsAdj.Count() > 0)
                {
                    if (lstPtsAdj.Any(s => s.type.Contains("org")))
                    {
                        var mapLst = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucodeId).Select(x => x.MapStyleID).Distinct().ToList();
                        var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID) && s.IsDleted == false).Sum(s => s.OrdQty);
                        var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Where(s => mapLst.Contains(s.StyleID) && s.IsDleted == false).Sum(s => s.OrdQty);
                        var sum3 = sum1 + sum2;
                        var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).Min(x => x.OrgMinPoints);
                        var newMinPt = minPts - sum2;
                        if (newMinPt >= 0)
                        {
                            foreach (var stylevalues in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).ToList())
                            {
                                if (minPts > sum2)
                                {
                                    stylevalues.MinPoints = Convert.ToInt32(minPts - sum2);
                                }
                                else
                                { stylevalues.MinPoints = Convert.ToInt32(0); }
                            }
                            result.message = "<center class='mandatoryStylecart'><span class='mandatoryStyle'>The mandatory quantity is :" + ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).Min(x => x.MinPoints) + "</span>&nbsp;&nbsp;&nbsp;The quantity in cart is :<b>" + orgSaleLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty) + "</b><center>";
                            result.pointsStyle = reslt;
                        }
                        else
                        {
                            foreach (var stylevalues in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).ToList())
                            {
                                if (minPts > sum2)
                                {
                                    stylevalues.MinPoints = Convert.ToInt32(minPts - sum2);
                                }
                                else
                                { stylevalues.MinPoints = Convert.ToInt32(0); }
                            }
                            result.message = "<center class='mandatoryStylecart'><span class='mandatoryStyle'>The mandatory quantity is :" + ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => reslt.Contains(x.Style)).Min(x => x.MinPoints) + "</span>&nbsp;&nbsp;&nbsp;The quantity in cart is :<b>" + orgSaleLine.Where(s => reslt.Contains(s.StyleID)).Sum(s => s.OrdQty) + "</b><center>";
                            result.pointsStyle = reslt;
                        }
                    }
                    else
                    {
                        var orgLst = _pointsAdjustment.GetAll(s => s.BusinessID == busId && s.UcodeID == ucodeId).Select(x => x.StyleID).Distinct().ToList();
                        var sum1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Where(s => reslt.Contains(s.StyleID) && s.IsDleted == false).Sum(s => s.OrdQty);
                        var sum2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Where(s => orgLst.Contains(s.StyleID) && s.IsDleted == false).Sum(s => s.OrdQty);
                        var sum3 = sum1 + sum2;
                        var minPts = ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgLst.Contains(x.Style)).Min(x => x.OrgMinPoints);
                        var newMinPt = minPts - sum3;
                        var lstStyles = lstPtsAdj.Select(s => s.styl).ToList();
                        if (newMinPt >= 0)
                        {
                            //foreach (var stylevalues in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgLst.Contains(x.Style)).ToList())
                            //{
                            //    stylevalues.MinPoints = Convert.ToInt32(newMinPt);
                            //}
                            //result.message = "<center>The mandatory quantity is :" + ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgLst.Contains(x.Style)).Min(x => x.MinPoints) + "<center>";
                            //result.pointsStyle = orgLst;
                        }
                        else
                        {
                            //foreach (var stylevalues in ((List<Maximus.Data.models.StyleAndMinPoints>)Session["StyleMinPoints"]).Where(x => orgLst.Contains(x.Style)).ToList())
                            //{
                            //    stylevalues.MinPoints = 0;
                            //}
                            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeaderLoc"]).Where(s => s.UCodeId == ucodeId).First().SalesOrderLine.Any(s => lstStyles.Contains(s.StyleID) && s.IsDleted == false))
                            {
                                if (minPts > 0)
                                {

                                    result.message = "__ALERT__ If you wish please adjust quantity of dresses and tops as the combination is above the mandatory quantity";
                                    result.pointsStyle = new List<string>();
                                }
                            }
                        }

                    }

                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);


        }

        #endregion

        #region CheckEmpEmail
        public ActionResult CheckEmpEmail()
        {
            string userName = Session["UserName"].ToString();
            string busId = Session["BuisnessId"].ToString();
            if (_user.Exists(s => s.UserName == userName && s.BusinessID == busId && (s.Email_ID == "" || s.Email_ID == null)))
            {
                return PartialView();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region  SaveEmailData 
        public string SaveEmailData(string email)
        {
            string Result = "";
            if (email != "")
            {
                string userName = Session["UserName"].ToString();
                string busId = Session["BuisnessId"].ToString();

                Result = _home.SaveEmailData(email.ToLower(), userName, busId) ? "" : "failed";
            }
            return Result;
        }

        #endregion

        #region SetRolloutTrue
        public void SetRolloutTrue()
        {
            Session["Proceedrollout"] = true;
        }
        #endregion

        #region  GetRolloutCheck 
        public ActionResult GetRolloutCheck()
        {
            string busId = Session["BuisnessId"].ToString();
            string ucode = Session["SelectedUcode"].ToString();
            if (Convert.ToBoolean(Session["Proceedrollout"]) == false)
            {
                if (Convert.ToBoolean(Session["IsEmergency"]) || _dp.CheckEmergency(busId, ucode))
                {
                    return null;
                }

                string empId = Session["SelectedEmp"].ToString();
                if (_empRollout.Exists(s => s.EmployeeID == empId && s.BusinessID == busId))
                {
                    DateTime rollOutdate = _empRollout.GetAll(s => s.EmployeeID == empId && s.BusinessID == busId).First().NextOrder.Value;
                    if (DateTime.Now < rollOutdate)
                    {
                        ViewBag.ROLLOUTTYPE = Session["RO_DATECHECK"] != null ? Convert.ToInt32(Session["RO_DATECHECK"].ToString()) : 0;
                        ViewBag.ROLLOUTDATE = _empRollout.Exists(s => s.EmployeeID == empId && s.BusinessID == busId) ? _empRollout.GetAll(s => s.EmployeeID == empId && s.BusinessID == busId).First().NextOrder.Value.ToString("dd-MM-yyyy") : DateTime.Now.ToString("dd-MM-yyyy");
                        ViewBag.RolloutMessage = ViewBag.ROLLOUTTYPE == 1 ? "You are trying to place an order prior to your next order date (" + ViewBag.ROLLOUTDATE + "). Please try later." : "You are trying to place an order prior to your next order date (" + ViewBag.ROLLOUTDATE + "). Would you like to proceed?.";
                        if (ViewBag.ROLLOUTTYPE == 1 | ViewBag.ROLLOUTTYPE == 2)
                        {
                            return PartialView();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        #endregion

        #region IsEmergencyreasonFailed

        public string IsreasonFailed(string reason)
        {
            string result = "";
            if (Convert.ToBoolean(Session["requireemergencyreason"]) && Session["OVERRIDE_ENT_WITH_REASON"].ToString().ToLower() == "show")
            {
                if (reason == "")
                {
                    result = "Please enter a valid reason";
                }
            }
            return result;
        }
        #endregion

        #region GetStyleImages
        public JsonResult GetStyleImages(string style)
        {
            List<string> result = new List<string>();
            result = _home.GetStyleImages(style);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetRedirectionUrl
        public string GetRedirectionUrl()
        {
            if (Convert.ToBoolean(Session["POINTSREQ"]) && Convert.ToBoolean(Session["IsEmergency"]) == false && Convert.ToBoolean(Session["Maternity"])==false)
            {
                return "/Employee/ChangeOrderType?orderType=manpack";
            }
            else if(Convert.ToBoolean(Session["IsEmergency"]))
            {
                return "/Employee/ChangeOrderType?orderType=emergency";
            }
            else if(Convert.ToBoolean(Session["returnorder"]))
            {
                return "/Employee/ChangeOrderType?orderType=return";
            }
            else if(Convert.ToBoolean(Session["Maternity"]))
            {
                return "/Employee/ChangeOrderType?orderType=maternity";
            }
            return "/Employee/Index";
        }
        #endregion

    }
}














