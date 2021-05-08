using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services;
using Maximus.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Maximus.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        // GET: Private
        #region declarations
        //ControllerHelperMethods ctrlHelp = new ControllerHelperMethods();

        AllEnums enus = new AllEnums();
        public string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        private readonly IBasket _basket;
        private readonly GatewayTbl _gateWay;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPrivateOrder _private;
        private readonly IHome _home;
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
        private readonly TransactionTbl _txntbl;
        private string busId;
        private string access;
        private string orderPermit;
        private string userName;
        private string budgetReq;
        //private bool live;
        //public bool islive { get { return live; } set { live = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["islive"].ToString()); } }
        public PrivateController(IUnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            StyleColorSize styleColorSize = new StyleColorSize(_unitOfWork);
            tblSalesLines salesOrderLines = new tblSalesLines(_unitOfWork);
            BasketService basket = new BasketService(_unitOfWork);
            DimFitCaption dimFitCap = new DimFitCaption(_unitOfWork);
            GatewayTbl gateWay = new GatewayTbl(_unitOfWork);
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
            TransactionTbl txntbl = new TransactionTbl(_unitOfWork);
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
            PrivateOrderService privateO = new PrivateOrderService(_unitOfWork);
            ReturnReasonCodes returnReasonCodes = new ReturnReasonCodes(_unitOfWork);
            StyleByFreetextView_Emergency styleFreetxtEmer = new StyleByFreetextView_Emergency(_unitOfWork);
            HomeService home = new HomeService(_unitOfWork);
            _home = home;
            _pointsByUcode = pointsByUcode;
            _private = privateO;
            _styleFreetxtEmer = styleFreetxtEmer;
            _pointsAdjustment = pointsAdjustment;
            _pointStyle = pointStyle;
            _pointsCard = pointsCard;
            _ucodeByFreetext = ucodeByFreetext;
            _txntbl = txntbl;
            _fskSetValues = fskSetValues;
            _styleColorSize = styleColorSize;
            _dimFitCap = dimFitCap;
            _dimension1 = dimension;
            _gateWay = gateWay;
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
            _basket = basket;
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
            userName = System.Web.HttpContext.Current.Session["UserName"].ToString();
            busId = System.Web.HttpContext.Current.Session["BuisnessId"].ToString();
            budgetReq = System.Web.HttpContext.Current.Session["BUDGETREQ"].ToString();
            access = System.Web.HttpContext.Current.Session["Access"].ToString();
            orderPermit = System.Web.HttpContext.Current.Session["OrderPermit"].ToString();
        }
        #endregion

        #region index
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
                        // Session["costCenter"] = _home.GetCostCenterTemplate((List<string>)Session["SelectedTemplates"], busId);
                    }
                    else if (Session["selectedUcodes"] != null)
                    {
                        List<string> selUcode = new List<string>();
                        selUcode.Add(Session["selectedUcodes"].ToString());
                        // Session["costCenter"] = _home.GetCostCenterUcode(selUcode, busId);
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
            return View();
        }
        #endregion

        #region getting all groups for checkboxlist
        public ActionResult GetAllCatagory()
        {
            string busId = Session["BuisnessId"].ToString();
            try
            {
                var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
                var grp = _dp.GetPrivateStyles(busId);
                var grPCnt = grp.GroupBy(s => s.ProductGroup).Select(s => new styleViewmodel { ProductGroup = s.First().ProductGroup, count = s.Count() });
                var grpLst = grp.Select(s => s.ProductGroup).ToList();
                var result = _styleGroups.GetAll(x => x.Description != "" && grpLst.Contains(x.GroupID)).Select(s => new StyleCatagoryModel { groupid = s.GroupID, groupname = s.Description, groupImage = s.ImagePath }).ToList();
                result.ForEach(s => s.groupImage = grp.Where(sa => sa.ProductGroup == s.groupid).First().StyleImage);
                result.ForEach(s => s.count = grPCnt.Where(sa => sa.ProductGroup == s.groupid).First().count);
                //var result = _styleGroups.GetAll(x => x.Description != "" && grpLst.Contains(x.GroupID)).ToList();
                result.ForEach(s => s.groupImage = System.IO.File.Exists(appPath + s.groupImage) ? s.groupImage : Url.Content("~/StyleImages/notfound.png"));
                return PartialView("_PrivateCatagoryPartial", result);
            }
            catch
            {

            }
            return null;
        }
        #endregion

        #region Cardview
        [ValidateInput(false)]

        //public ActionResult CardViewPartial(string ColorId = "", string StyleID = "", string SizeId = "", decimal Price = 0, string Description = "", List<int> selectedItem = null, bool pages = false, bool BringImages = false, bool BringDimension = false, List<string> dataObj = null)
        public ActionResult PrivateCardViewPartial(List<int> selectedItem = null, string filterText = "")
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var model = new List<styleViewmodel>();
            var svm = new styleViewmodel();
            string businessId = Session["BuisnessId"].ToString();

            //model = _dp.GetPrivateStyles(businessId);
            var freeTextLst = (List<string>)Session["UcFreeTxt"];
            var ucode = Session["SelectedUcode"].ToString();
            model = _ucodeByFreeText.GetAll(x => freeTextLst.Contains(x.FreeText) && x.UCodeID == ucode).ToList().Select(x => new styleViewmodel
            {
                StyleID = x.StyleID,
                ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                SeqNO = x.SeqNo.Value,
                Freetext = x.FreeText,
                OriginalStyleid = x.StyleID.Contains(',') ? x.StyleID.Split(',')[0] : x.StyleID
            }).ToList();
            model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
            foreach (var data1 in model)
            {
                data1.Assembly = _customAssembly.Exists(d => d.ParentStyleID == data1.StyleID & d.isChargeable == false & d.CustID == businessId) |
                        _allAssemblies.Exists(d => d.ParentStyleID == data1.StyleID & d.isChargeable == false) ? 1 : 0;

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

            foreach (var data1 in model)
            {
                data1.StyleID = data1.StyleID == data1.Freetext ? data1.StyleID : _dataConnection.GetFitAllocString(data1.Freetext);
            }
            if (selectedItem != null)
            {
                model = model.Where(x => selectedItem.Contains(x.ProductGroup)).ToList();
            }
            if (filterText != null && filterText != "")
            {
                model = model.Where(x => x.StyleID.ToLower().Contains(filterText.ToLower()) || x.Description.ToLower().Contains(filterText.ToLower())).ToList();
            }

            return PartialView("_PrivateCardViewPartial", model.Distinct());
        }
        #endregion

        #region Addtocart
        public JsonResult AddToCart(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "", string orgStyl = "", string entQty = "", string reqData1 = "", string reason = "", string QtySizePriceArr = "", string selectedSitecode = "")
        {
            string result = "";
            string busId = Session["BuisnessId"].ToString();
            string selUcode = Session["SelectedUcode"] == null ? "" : Session["SelectedUcode"].ToString();


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

                }
            }
            if (salesOrderLines.Count > 0)
            {
                if ((bool)Session["IsBulkOrder1"] == false)
                {

                    lineNo = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).OrderByDescending(x => x.LineNo).FirstOrDefault().LineNo + 1;

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

                    salesOrderLines.Add(new SalesOrderLineViewModel { ColourID = color, LineNo = lineNo, Description = description, OrdQty = Convert.ToInt64(qty), Price = Convert.ToDouble(price) == 0 ? Convert.ToDouble(GetPrice(style, size)) : Convert.ToDouble(price), SizeID = size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString(), StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(style)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(style)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"), orgStyleId = orgStyl, VatPercent = _dataConnection.GetVatPercent(style, size), Total = _dataConnection.GetlineTotals(Convert.ToDouble(qty), Convert.ToDouble(price), _dataConnection.GetVatPercent(style, size)), EntQty = entQty, FreeText1 = reqData1, DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"])), VatCode1 = _dataConnection.GetVatCode(), RepId = Convert.ToInt32(Session["Rep_Id"].ToString()), Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]), Cost1 = _dataConnection.GetCostPrice(style, size, color, Session["Currency_Name"].ToString(), 1, 0), IssueUOM1 = 1, IssueQty1 = Convert.ToInt32(qty), StockingUOM1 = 1, SOPDetail4 = reason, SOPDetail5 = selectedSitecode != "" ? selectedSitecode.Split('|')[0].Trim() : "", Points = points.Value, TotalPoints = points.Value * Convert.ToInt32(qty), CatagoryCaption = Session["CatagoryCaption"] != null ? Session["CatagoryCaption"].ToString() : "" });
                }
                catch (Exception e)
                {
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
                result = "<button class=\"btn\" onclick=\"GetCart(1)\" style=\"background-color:#009885;color:white\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:white;font-size:25px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button>";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPrice based on styleid and colorid
        public decimal GetPrice(string StyleID = "", string SizeId = "")
        {
            if (Session["PriceList"] != null)
            {
                return _dp.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString(), Session["PriceList"].ToString());
            }
            else
            {
                return _dp.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString(), "");
            }
        }

        #endregion

        #region GetPrice based on styleid and colorid
        public JsonResult GetPrivatePrices(string StyleID = "", string SizeId = "")
        {
            SizePrice sp = new SizePrice();
            if (Session["PriceList"] != null)
            {
                sp.Price = _dp.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString(), Session["PriceList"].ToString()).ToString("0.00");
            }
            else
            {
                sp.Price = _dp.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString(), "").ToString("0.00");
            }
            sp.PriceVAT = _dp.GetPriceWithVat(StyleID, SizeId, Session["BuisnessId"].ToString(), "");
            sp.showVat = Convert.ToBoolean(Session["SHOWVAT"]);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ShowBasketPrivate
        public ActionResult ShowBasketPrivate(int orderno = 0)
        {
            double carriage = 0.0;
            //if (orderno > 0 || Convert.ToBoolean(Session["ISEDITING"]))
            //{
            //    if (EditOrder(orderno) || Convert.ToBoolean(Session["ISEDITING"]))
            //    {
            //        Session["ISEDITING"] = true;
            //        //var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).ToList();
            //    }

            //}
            //else
            //{

            //}
            Session["DeliveryAddress"] = _basket.FillCombo_CustomerDelivery(busId, access, orderPermit, userName, true, Session["SelectedEmp"].ToString());
            Session["clickedEmp"] = null;
            var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

            if (model1.Count == 0)
            {
                return RedirectToAction("Index", "Employee");
            }

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
                    if (result > 0)
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
                                resultq = ((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == res) ? ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == res).First() : new BusAddress1();
                                contactId = Convert.ToInt32(resultq.contactId);
                                data = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CustRef : _busContact.Exists(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? _busContact.GetAll(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                                Session["CustRef"] = data;
                                ViewData["comment"] = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CommentsExternal : "";
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
                    if (mod.Any(x => x.EmployeeID == emp))
                    {
                        Session["cboDelAddress"] = mod.Where(x => x.EmployeeID == emp).First().AddressId;
                        Session["cboDelAddressDesc"] = mod.Where(x => x.EmployeeID == emp).First().DelDesc;
                        Session["CustRef"] = mod.Where(x => x.EmployeeID == emp).First().CustRef;
                        ViewData["comment"] = mod.Where(x => x.EmployeeID == emp).First().CommentsExternal;
                    }
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
                    resultq = ((List<BusAddress1>)Session["DeliveryAddress"]).Any(x => x.AddressId == res) ? ((List<BusAddress1>)Session["DeliveryAddress"]).Where(x => x.AddressId == res).First() : new BusAddress1();
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
            var carrier = FillCarrierStyle();
            Session["carrStyle"] = carrier;
            if (carrier.Count == 1 && model1.First().SalesOrderLine.Any(s => s.isCarrline) == false && Convert.ToBoolean(_dp.BusinessParam("CarrierPromptPvt", busId)))
            {
                InsertCarriageLine(carrier[0]);
            }
            carriage = mod.Where(s => s.EmployeeID == emp).First().SalesOrderLine.Any(s => s.isCarrline) ? mod.Where(s => s.EmployeeID == emp).First().SalesOrderLine.Where(s => s.isCarrline).Sum(s => s.Price) : 0.0;
            tot = _dataConnection.GetAlltotals(totLst, carriage, false);

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


            ViewBag.VatPercent = tot.vatSpan;
            ViewBag.carriage = carriage;
            ViewBag.ordeTotal = tot.ordeTotal;
            ViewBag.totalVat = tot.totalVat;
            ViewBag.Total = tot.Total;
            ViewBag.GrossTotal = tot.gross;
            ViewData["carrierStyleFill"] = carrier;
            ViewData["ddlCustRef"] = _dataConnection.GetCustRefVisiblity(busId);
            return View();
        }
        #endregion

        #region GetSitecodes
        public List<SiteCodeModel> FillSiteCode()
        {
            var result = _dataConnection.GetSitecodes(Session["BuisnessId"].ToString());
            return result;
        }
        #endregion

        public string GetPriceDiv()
        {
            string emp = Session["SelectedEmp"].ToString();
            string selUcode = Session["SelectedUcode"].ToString();
            if (Session["SalesOrderHeader"] != null)
            {
                var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
                if (model1.Any(s => s.EmployeeID == emp && s.UCodeId == selUcode))
                {
                    if (model1.Where(s => s.EmployeeID == emp && s.UCodeId == selUcode).Any(s => s.SalesOrderLine.Count > 0))
                    {
                        var model12 = model1.Where(s => s.EmployeeID == emp && s.UCodeId == selUcode).First().SalesOrderLine;
                        var totVal = model12.Sum(s => s.Total) + model12.Sum(s => s.VAT);
                        return Session["CurrencySymbol"].ToString() + " " + totVal.ToString("0.00") + " (inc. VAt)";
                    }
                }
            }

            return "";
        }
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

        #region EmployeeView
        public ActionResult EmployeeView()
        {
            var result = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.IsEditing).ToList() : (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            return PartialView("model/_EmployeeView", result);
        }
        #endregion

        #region CartView
        [ValidateInput(false)]
        public ActionResult CartView(string empid = "")
        {
            var newSalesHeader = new List<SalesOrderHeaderViewModel>();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            // var salesOrder = (List<SalesOrderViewModel>)Session["SalesOrder"];
            if (mod.Count > 0)
            {
                var modq = mod.Where(x => x.SalesOrderLine == null || x.SalesOrderLine.Where(s => s.IsDleted == false).Count() == 0).FirstOrDefault();
                mod.Remove(modq);
            }
            if (mod.Count == 1)
            {

                return PartialView("_CartViewPrivate", mod);
            }
            else if (mod.Count > 1)
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
            return PartialView("_CartView", mod);
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
            return PartialView("_DeliveryaddressPrivate", result);
        }

        #endregion

        #region Getlast Seleceted Size based on style
        public JsonResult GetLastSizePrivate(string style = "")
        {
            var result = default(object);
            string businessId = Session["BuisnessId"].ToString();
            if (style != "")
            {
                var prevHistory = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), style);
                if (prevHistory.Size != "")
                {
                    prevHistory.priceVAT = _dp.GetPriceWithVat(style, prevHistory.Size, Session["BuisnessId"].ToString(), "");
                    prevHistory.price = _dp.GetPrice(style, prevHistory.Size, Session["BuisnessId"].ToString(), "").ToString();
                }
                result = prevHistory;
                return Json(result);
            }
            return Json(result);
        }
        #endregion

        #region get Description
        public JsonResult DrpResultModelPrivate(string styleId, string color)
        {
            var priceLst = new List<SizePrice>();
            var result = new DrpResultModel();
            //var selUcode = Session["SelectedUcode"].ToString();
            result.showVat = Convert.ToBoolean(Session["SHOWVAT"]);
            result.Description = _tblFskStyle.GetAll(x => x.StyleID == styleId).First().Description;
            if (_styleColorSizeObsolete.Exists(x => x.StyleID == styleId && x.ColourID.ToLower() == color.ToLower()) != true)
            {
                result.SizeList = (List<string>)_style_Sizes.GetAll(s => s.StyleID == styleId).Distinct().OrderBy(s => s.SeqNo).Select(s => s.SizeID).ToList();
                result.Price = result.SizeList.Count > 1 ? 0 : GetPrice(styleId, result.SizeList[0]);
                result.PriceVAT = result.SizeList.Count > 1 ? "0.00" : _dp.GetPriceWithVat(styleId, result.SizeList[0], Session["BuisnessId"].ToString(), "");
                result.isBulk = Convert.ToBoolean(Session["IsBulkOrder"].ToString());
                result.isManpack = Convert.ToBoolean(Session["IsManPack"].ToString());
                try
                {
                    foreach (var size in result.SizeList)
                    {
                        priceLst.Add(new SizePrice { Price = _dp.GetPrice(styleId, size, Session["BuisnessId"].ToString(), "").ToString("0.00"), Size = size, PriceVAT = _dp.GetPriceWithVat(styleId, size, Session["BuisnessId"].ToString(), ""), Currency = Session["CurrencySymbol"].ToString() });
                    }
                }
                catch (Exception e)
                {

                }
                result.PriceList = priceLst;
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
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        public ActionResult CartviewDetailGridViewGridViewPartial(string empId = "")
        {
            List<SalesOrderHeaderViewModel> saleH = new List<SalesOrderHeaderViewModel>();
            var model = new List<SalesOrderLineViewModel>();

            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var buss = Session["BuisnessId"].ToString();
            var salesHeaders = Convert.ToBoolean(Session["ISEDITING"]) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.IsEditing) : (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var emp = Session["clickedEmp"] == null ? salesHeaders.First().EmployeeID : Session["clickedEmp"].ToString();
            if (((List<string>)Session["Templates"]).Count > 0)
            {
                string selTemp = Session["SelectedTemplate"].ToString();
                //model = selTemp != "" ? salesHeaders.Where(s => s.Template.ToLower() == selTemp.ToLower()).FirstOrDefault().SalesOrderLine.ToList() : new List<SalesOrderLineViewModel>();
                model = salesHeaders.Where(s => s.IsTemplate).FirstOrDefault().SalesOrderLine.Where(s => s.IsDleted == false).ToList();
                Session["CurrLineNo"] = model.First().LineNo;
            }
            else if (Session["SelectedUcode"].ToString() != "")
            {
                string selUcode = Session["SelectedUcode"].ToString();
                model = Convert.ToBoolean(Session["ISEDITING"]) ? salesHeaders.Where(s => s.IsUcode && s.IsEditing).FirstOrDefault().SalesOrderLine.Where(s => s.IsDleted == false).ToList() : salesHeaders.Where(s => s.IsUcode).FirstOrDefault().SalesOrderLine.Where(s => s.IsDleted == false).ToList();
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

        #region CartviewDetailGridViewGridViewPartialUpdate

        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialUpdate(Maximus.Data.Models.SalesOrderLineViewModel item)
        {
            var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First();
            var entQty = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault();
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(s => s.isCarrline == false && s.IsDleted == false).ToList();
            var salesLineDelted = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(s => s.isCarrline == false && s.IsDleted == true).ToList();
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
            }
            else
            {
                ViewData["EditError"] = "Please, correct all errors.";
            }

            return PartialView("_CartviewDetailGridViewGridViewPartial", result);
        }
        #endregion

        #region CartviewDetailGridViewGridViewPartialDelete
        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialDelete(SalesOrderLineViewModel item)
        {
            var thisEmp = Session["SelectedEmp"].ToString();
            string ucode = Session["SelectedUcode"].ToString();
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault();
            var model = result.SalesOrderLine.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo && x.IsDleted == false).ToList();
            // var model = model1
            if (item.LineNo >= 0)
            {
                try
                {
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.RemoveAll(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo);
                    ReOrderSalesLines();

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_CartviewDetailGridViewGridViewPartial", result.SalesOrderLine.Where(s => s.IsDleted == false).ToList());
        }

        #endregion

        public void ReOrderSalesLines()
        {
            var salesLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(s => s.IsDleted == false);
            var lineNos = salesLines.Select(x => x.LineNo).ToList();
            int count = 1;
            foreach (var sales in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(s => s.IsDleted == false))
            {
                if (count == sales.LineNo)
                {

                }
                else
                {

                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Any(x => x.OriginalLineNo == sales.LineNo & x.IsDleted == false))
                    {
                        foreach (var salOrgLi in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(x => x.OriginalLineNo == sales.LineNo & x.IsDleted == false))
                        {
                            salOrgLi.OriginalLineNo = count;
                        }
                    }
                    sales.LineNo = count;
                }
                count++;
            }

        }


        public void SetVatStatus(bool value)
        {
            Session["SHOWVAT"] = value;
        }

        public ActionResult BillingPrivate(bool isEdit = false)
        {
            ViewData["billEdit"] = isEdit;
            return PartialView("_BillingPrivate");
        }
        public ActionResult SetDeliveryAddress(bool value)
        {
            Session["setdeladdr"] = value;
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["SelectedEmp"].ToString();
            if (value)
            {
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
                {

                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelAddress1;
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelAddress2;
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress3 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelAddress3;
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelTown;
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCity = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelCity;
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCountry = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelCountry;
                    ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelPostCode;
                }
            }
            else
            {

                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1 = "";
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress2 = "";
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress3 = "";
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown = "";
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCity = "";
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCountry = "";
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode = "";
            }
            return PartialView("_BillingPrivate");
        }
        public ActionResult BillingPrivateSave(string tbxAddr1, string tbxTown, string tbxPhone, string tbxEmail, string tbxPostcode, string tbxCity, string tbxAddr2, string tbxAddr3, string tbxCountry, string tbxDELAddr1, string tbxDELTown, string tbxDELPhone, string tbxDELEmail, string tbxDELPostcode, string tbxDELCity, string tbxDELAddr2, string tbxDELAddr3, string tbxDELCountry)
        {
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["SelectedEmp"].ToString();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                var sss = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First();
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1 = tbxAddr1;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress2 = tbxAddr2;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress3 = tbxAddr3;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown = tbxTown;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCity = tbxCity;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCountry = tbxCountry;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode = tbxPostcode;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().Mobile = tbxPhone;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().EmailID = tbxEmail;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelAddress1 = tbxDELAddr1;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelAddress2 = tbxDELAddr2;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelAddress3 = tbxDELAddr3;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelTown = tbxDELTown;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelCity = tbxDELCity;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelCountry = tbxDELCountry;
                ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().DelPostCode = tbxDELPostcode;
            }
            ViewData["billEdit"] = false;
            return PartialView("_BillingPrivate");
        }
        public string GetResult()
        {
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["SelectedEmp"].ToString();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1 == null || ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1 == "")
            {
                return "2";
            }
            else if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown == null || ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown == "")
            {
                return "3";
            }
            else if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode == null || ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode == "")
            {
                return "4";
            }
            else if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().EmailID == null || ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().EmailID == "")
            {
                return "5";
            }
            else
            {
                return "6";
            }
        }
        public JsonResult GetRetReordTotals()
        {
            List<TotalModel> result = new List<TotalModel>();
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["SelectedEmp"].ToString();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                var carriage = 0.0;
                var Model = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.UCodeId == ucode && s.EmployeeID == empId).ToList();
                TotalModel total = new TotalModel();
                total = _dataConnection.GetAlltotals(new List<SalesOrderHeaderViewModel>(), carriage, false, null);
                carriage = Model.Where(s => s.EmployeeID == empId).First().SalesOrderLine.Any(s => s.isCarrline) ? Model.Where(s => s.EmployeeID == empId).First().SalesOrderLine.Where(s => s.isCarrline).Sum(s => s.Price) : 0.0;
                total.carriage = carriage;
                total.Total = total.Total + carriage;
                total.gross = total.gross + carriage;
                result.Add(total);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #region GetPrivateMessage
        public string GetPrivateMessagePop()
        {

            if (Convert.ToBoolean(Session["PRIVATEORDER"]) && Convert.ToBoolean(Session["PrivateMessage"]) == false)
            {
                var result = _dp.GetPrivateMessage();
                Session["PrivateMessage"] = true;
                return result;
            }
            else
            {
                return "";
            }
        }

        #endregion
        #region SaveAddresses
        public void SaveAddresses(BillingAddrPrivate bp)
        {

        }
        #endregion

        #region GetcartStatus()
        public string GetcartStatus()
        {
            string result = "";
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["SelectedEmp"].ToString();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(s => s.EmployeeID == empId && s.UCodeId == ucode))
                {
                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().SalesOrderLine.Count > 0)
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().SalesOrderLine.Where(s => s.isCarrline == false).Count() > 0)
                        {
                            result = "";
                        }
                        else
                        {
                            result = "1";
                        }
                    }
                    else
                    {
                        result = "1";
                    }
                }
                else
                {
                    result = "1";
                }
            }
            return result;
        }
        #endregion
        public string GetBasketStatus()
        {
            string result = "";
            string ucode = Session["SelectedUcode"].ToString();
            string empId = Session["SelectedEmp"].ToString();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(s => s.EmployeeID == empId && s.UCodeId == ucode))
                {
                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1 != null && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown != null && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCountry != null && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode != null && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().Mobile != null && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().EmailID != null)
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvAddress1.Trim() != "" && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvTown.Trim() != "" && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvCountry.Trim() != "" && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().InvPostCode.Trim() != "" && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().Mobile.Trim() != "" && ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().EmailID != "")
                        {
                            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().SalesOrderLine.Count > 0)
                            {
                                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(s => s.EmployeeID == empId && s.UCodeId == ucode).First().SalesOrderLine.Where(s => s.isCarrline == false).Count() > 0)
                                {
                                    return result;

                                }
                                else
                                {
                                    result = "1";
                                }
                            }
                            else
                            {
                                result = "1";
                            }

                        }
                        else
                        {
                            result = GetResult();
                        }
                    }
                    else
                    {
                        result = GetResult();
                    }
                }
                else
                {
                    result = "1";
                }
            }
            else
            {
                result = "1";
            }
            return result;
        }


        public string InsertCarriageLine(string carrStyle)
        {
            string result = "";
            var carrierStyle = ((List<string>)Session["carrStyle"]);
            string thisEmp = Session["clickedEmp"] != null ? Session["clickedEmp"].ToString() : Session["SelectedEmp"].ToString();
            int newLineNO = Convert.ToInt32(((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => s.IsDleted == false).Last().LineNo + 1);
            var salesLines = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == thisEmp).First().SalesOrderLine.Where(s => s.IsDleted == false);
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.IsTemplate == false))
            {
                if (salesLines.Any(x => carrierStyle.Contains(x.StyleID)) == false)
                {
                    SalesOrderLineViewModel saleLinevumodel = new SalesOrderLineViewModel();
                    saleLinevumodel = _basket.GetCarrStyleLine(carrStyle, busId, Convert.ToDouble(Session["CurrencyExchangeRate"]), newLineNO);
                    if (saleLinevumodel != null)
                    {
                        saleLinevumodel.EmployeeId = thisEmp;
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
        public JsonResult AcceptOrderPrivate()
        {
            string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
            string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
            string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
            string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
            string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();
            string ueMailEMail = System.Configuration.ConfigurationManager.AppSettings["uemail/email"].ToString();
            bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            bool booAutoConfirm = Convert.ToBoolean(Session["AUTOCONFIRM"].ToString());
            bool boolDeleteConfirm = Convert.ToBoolean(Session["boolDeleteConfirm"].ToString());
            string busId = Session["BuisnessId"].ToString();
            BusAddress1 invAddress = new BusAddress1();
            var ResultSet = new List<SaveOrderResultSet>();
            var AcceptResultSet = new AcceptResultSet();
            double carriage = 0.0;
            List<SalesOrderHeaderViewModel> salesHeaderLst = new List<SalesOrderHeaderViewModel>();

            salesHeaderLst = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

            var header = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];

            bool isRollOutOrder = Convert.ToBoolean(Session["RolloutOrder"]);
            bool isRollOutOrderEst = Convert.ToBoolean(Session["ISEDITING"]) ? salesHeaderLst.Any(s => s.OrderAnalysisCode4 != null && s.OrderType == "SO" && (s.ReasonCode == 0 | s.ReasonCode == null)) ? true : false : Convert.ToBoolean(Session["RolloutOrderEst"]);
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
            string permissionPrice = Session["Price"].ToString();
            string custLogo = Session["LOGO"].ToString();
            var appPath = Request.ApplicationPath;
            string cmpLogo = ConfigurationManager.AppSettings["cmpLogo"].ToString();
            try
            {
                if (Convert.ToBoolean(Session["ISEDITING"]))
                {
                    // AcceptResultSet = _private.AcceptOrder( );
                }
                else
                {

                    AcceptResultSet = _private.AcceptOrder(cmpId, IsManpack, busId, header, (List<BusAddress1>)Session["DeliveryAddress"], Session["selectedcar"].ToString(), Session["UserName"].ToString(), Convert.ToDouble(Session["CARRPERCENT"].ToString()), Convert.ToDouble(Session["CARRREQAMT"].ToString()), Browser, REMOTE_ADDR, cmpLogo, Session["LOGO"].ToString(), adminMail, mailUsername, mailPassword, mailPort, mailServer, ueMailEMail, HTTP_X_FORWARDED_FOR, Convert.ToBoolean(Session["ISEDITING"]), boolDeleteConfirm, Session["pnlCarriageReason"].ToString(), permissionPrice, null);
                }

            }
            catch (Exception e)
            {

            }
            if (AcceptResultSet.type == "")
            {
                ResetSessions();
            }
            return Json(AcceptResultSet, JsonRequestBehavior.AllowGet);
        }

        #region Payments
        public ActionResult Payments(long orderno)
        {
            var model = new tblsop_salesorder_header();
            if (orderno > 0)
            {
                string refno = orderno.ToString();
                model = _salesOrderHeader.Exists(s => s.OrderNo == orderno) ? _salesOrderHeader.GetAll(s => s.OrderNo == orderno).First() : new tblsop_salesorder_header();
                ViewBag.HidePayments = _txntbl.Exists(s => s.RefNo == refno && (s.txn_status.ToUpper().Trim() == "AUTHORISED" || s.txn_status.ToUpper().Trim() == "COMPLETED")) ? true : false;
                Session["paypaltoken"] = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
            }
            Session["PaymentsPVT"] = model;
            return View("Payments", model);
        }
        #endregion
        public ActionResult PaymentsPartial(long orderno)
        {
            TempData["orderno"] = orderno;
            var model = new tblsop_salesorder_header();
            if (orderno > 0)
            {
                string refno = orderno.ToString();
                model = _salesOrderHeader.Exists(s => s.OrderNo == orderno) ? _salesOrderHeader.GetAll(s => s.OrderNo == orderno).First() : new tblsop_salesorder_header();
                ViewBag.HidePayments = _txntbl.Exists(s => s.RefNo == refno && (s.txn_status.ToUpper().Trim() == "AUTHORISED" || s.txn_status.ToUpper().Trim() == "COMPLETED")) ? true : false;
                Session["paypaltoken"] = System.Configuration.ConfigurationManager.AppSettings["Token"].ToString();
            }
            Session["PaymentsPVT"] = model;
            return PartialView("_Paymentspartial", model);
        }


        [ValidateInput(false)]
        public ActionResult OrderDetailGridView1Partial()
        {
            var ordno = Convert.ToInt32(TempData["orderno"]);
            var model = _dp.GetOrderDetail(ordno);
            TempData["OrderNo"] = ordno;
            return PartialView("_OrderDetailGridView1PrivatePartial", model);
        }
        #region GetPayemetDetails
        public JsonResult GetPayemetDetails(long OrderNo, string gateway)
        {
            //System.Web.HttpContext.Current.Response.Headers.Append("set-cookie", $"{key}={value}; path=/; SameSite=Strict; Secure");
            var SS = System.Web.HttpContext.Current.Response.Headers;
            HttpCookieCollection COLL = System.Web.HttpContext.Current.Request.Cookies;
            var model = new PaymentDetails();
            if (OrderNo > 0)
            {
                var emp = _salesOrderHeader.GetAll(s => s.OrderNo == OrderNo).First().PinNo;
                model = _salesOrderHeader.Exists(s => s.OrderNo == OrderNo) ? _salesOrderHeader.GetAll(s => s.OrderNo == OrderNo).Select(s => new PaymentDetails { deladdr1 = s.DelAddress1, deladdr2 = s.DelAddress2, delcity = s.DelCity, deltown = s.DelTown, delcountry = s.DelCountry, invaddr1 = s.InvAddress1, invaddr2 = s.InvAddress2, invaddrcity = s.InvCity, invaddrtown = s.InvTown, invcountry = s.InvCountry, delpostcode = s.DelPostCode, invpostcode = s.InvPostCode, emailid = s.EmailID, phone = s.ContactName, ordtotal = s.OrderGoods.Value.ToString("0.00") }).First() : new PaymentDetails();
                if (_employee.Exists(s => s.EmployeeID == emp))
                {
                    model.firstname = _employee.GetAll(s => s.EmployeeID == emp).First().Forename;
                    model.surname = _employee.GetAll(s => s.EmployeeID == emp).First().Surname;
                }
                if (_gateWay.Exists(s => s.GatewayName.ToLower().Trim() == "paypal"))
                {
                    model.gateway = _gateWay.GetAll(s => s.GatewayName.ToLower().Trim() == gateway.ToLower().Trim()).First().GatewayID.ToString();
                }
            }
            Session["PaymentsPVT"] = model;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SaveTxn
        public string UpdateTxn(string TxnID, DateTime txnDate, long refNo, string txnStatus, string txnAmt, int gatewayid)
        {
            string result = "";
            string refNo1 = refNo.ToString();
            try
            {
                var refnosp1 = "";
                if (_txntbl.Exists(s => s.RefNo == refNo1 && s.RefNoSP == refnosp1))
                {
                    refnosp1 = Session["refnosp"].ToString();
                    var tblTxn = _txntbl.GetAll(s => s.RefNo == refNo1 && s.RefNoSP == refnosp1).First();
                    tblTxn.GatewayID = gatewayid;
                    tblTxn.txn_id = TxnID;
                    tblTxn.RefNo = refNo.ToString();
                    tblTxn.txn_status = txnStatus;
                    tblTxn.txn_amt = Convert.ToDecimal(txnAmt);
                    tblTxn.txn_date = txnDate;
                    tblTxn.txn_Ip = GetIP();
                    tblTxn.RefNoSP = refnosp1;
                    tblTxn.rsp_date = txnDate;
                    tblTxn.rsp_status = txnStatus;
                    tblTxn.IsPackOrder = 0;
                    tblTxn.OrderNos = "Payment For Orders";
                    _txntbl.Update(tblTxn);
                }
                else
                {
                    string refnosp = "";
                    refnosp = refNo + "-" + DateTime.Now.ToString("ddMMyyHHmmss");
                    tblpayment_trans tblTxn = new tblpayment_trans();
                    tblTxn.GatewayID = gatewayid;
                    tblTxn.txn_id = TxnID;
                    tblTxn.RefNo = refNo.ToString();
                    tblTxn.txn_status = txnStatus;
                    tblTxn.txn_amt = Convert.ToDecimal(txnAmt);
                    tblTxn.txn_date = txnDate;
                    tblTxn.txn_Ip = GetIP();
                    tblTxn.RefNoSP = refnosp;
                    tblTxn.rsp_date = txnDate;
                    tblTxn.rsp_status = txnStatus;
                    tblTxn.IsPackOrder = 0;
                    tblTxn.OrderNos = "Payment For Orders";
                    _txntbl.Insert(tblTxn);
                }


                if (_salesOrderHeader.Exists(s => s.OrderNo == refNo))
                {
                    var saleHead = _salesOrderHeader.GetAll(s => s.OrderNo == refNo).First();
                    saleHead.OnlineConfirm = 1;
                    saleHead.OnlineConfirmedBy = Session["UserName"].ToString();
                    _salesOrderHeader.Update(saleHead);
                }
                try
                {
                    if (gatewayid == _gateWay.GetAll(s => s.GatewayName.ToLower() == "worldpay").First().GatewayID)
                    {
                        var model = Session["PaymentsPVT"] == null ? (tblsop_salesorder_header)Session["PaymentsPVT"] : _salesOrderHeader.Exists(s => s.OrderNo == refNo) ? _salesOrderHeader.GetAll(s => s.OrderNo == refNo).First() : new tblsop_salesorder_header();
                        if (model.OrderNo > 0)
                        {
                            _dp.SaveWorldPayTrans(TxnID, refnosp1, refNo.ToString(), model.PinNo, txnAmt, model.EmailID, model.InvAddress1 + "," + model.InvAddress2, model.ContactName, model.DelCountry, model.DelPostCode);
                        }
                    }
                }
                catch (Exception e)
                {

                }
                try
                {
                    var saleHead = _salesOrderHeader.GetAll(s => s.OrderNo == refNo).First();
                    var emp = _employee.GetAll(s => s.EmployeeID == saleHead.PinNo).First();
                    var gateImg = _gateWay.Exists(s => s.GatewayID == gatewayid) ? _gateWay.GetAll(s => s.GatewayID == gatewayid).First().GatewayImg : "";
                    var userEmail = _user.Exists(s => s.UserName == saleHead.PinNo) ? _user.GetAll(s => s.UserName == saleHead.PinNo).First().Email_ID : "";
                    string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
                    string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
                    string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
                    string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
                    string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();
                    string toEmail = saleHead.EmailID == "" ? userEmail : saleHead.EmailID;
                    _dp.SendConfirmPrivateOrderMail(refNo, DateTime.Now.ToString("dd-MM-yyyy"), emp.Forename + " " + emp.Surname, TxnID, gateImg, mailUsername, adminMail, mailPassword, mailPort, mailServer, toEmail, Session["UserName"].ToString());
                }
                catch (Exception e)
                {

                }

                result = "success";
            }
            catch (Exception e)
            {
                result = "";
            }
            return result;
        }
        #endregion
        #region savetxn
        public void SaveTxn(long refNO, string ordernos, string gateway, string refnosp)
        {
            var gatewayid = _gateWay.Exists(s => s.GatewayName.ToLower().Trim() == gateway.ToLower().Trim()) ? _gateWay.GetAll(s => s.GatewayName.ToLower().Trim() == gateway.ToLower().Trim()).First().GatewayID : 0;
            string refNo1 = refNO.ToString();
            if (_txntbl.Exists(s => s.RefNo == refNo1) == false)
            {
                tblpayment_trans tblTxn = new tblpayment_trans();
                tblTxn.RefNo = refNO.ToString();
                tblTxn.OrderNos = ordernos;
                tblTxn.GatewayID = gatewayid;
                tblTxn.RefNoSP = refnosp;
            }
        }
        #endregion
        #region 
        public string CancelPaypalTxn(long orderno)
        {
            string refnosp = "";
            refnosp = orderno + "-" + DateTime.Now.ToString("ddMMyyHHmmss");
            SaveTxn(orderno, "Payment for orders", "paypal", refnosp);
            return "success";

        }
        #endregion
        #region WorldpaySuccess
        public ActionResult WorldpaySuccess(string orderKey)
        {
            string result = "";
            string GateWay = "";
            int gateway = 0;
            Worldpaysuccess succ = new Worldpaysuccess();
            try
            {
                succ.OrderKey = System.Web.HttpContext.Current.Request["orderkey"];
                succ.Status = System.Web.HttpContext.Current.Request["paymentStatus"];
                succ.Currency = System.Web.HttpContext.Current.Request["paymentCurrency"];
                succ.Amount = System.Web.HttpContext.Current.Request["paymentAmount"];
                succ.Amount = succ.Amount.Insert(succ.Amount.Length - 2, ".");
                succ.TransactionID = orderKey.Split('^')[2];
                GateWay = Session["gateway"].ToString();
                gateway = _gateWay.Exists(s => s.GatewayName.ToLower().Trim() == GateWay) ? _gateWay.GetAll(s => s.GatewayName.ToLower().Trim() == GateWay).First().GatewayID : 0;
                if (UpdateTxn(succ.TransactionID, DateTime.Now, Convert.ToInt32(Session["orderno"]), succ.Status, succ.Amount, gateway) != "")
                {
                    return RedirectToAction("ShowPrivateOrders");
                }
            }
            catch (Exception e)
            {
                result = "";
            }
            return null;
        }
        #endregion

        public ActionResult ShowAddressForm()
        {
            return PartialView("_AddressPrivateForm");
        }

        #region WorldpayFailure
        // public ActionResult WorldpayFailure
        #endregion

        //#region WorldpaySuccess
        //public ActionResult PayPalSuccess()
        //{
        //    string result = "";
        //    string GateWay = "";
        //    int gateway = 0;
        //    Worldpaysuccess succ = new Worldpaysuccess();
        //    try
        //    {
        //        var kj = Request.QueryString.Get("tx");
        //        WebRequest wbreq = WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr?");
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //        wbreq.Method = "POST";
        //        wbreq.ContentType = "application/x-www-form-urlencoded";
        //        string strNewValue = "&cmd=_notify-synch&tx=" + Request["tx"] + "&at=amodNG5dgYmnO5tVgzsLBxu9uzlu6eCaUBk9fzoGQ01PUl9AD33i3fUqjr0";
        //        wbreq.ContentLength = strNewValue.Length;
        //        StreamWriter sw = new StreamWriter(wbreq.GetRequestStream(), Encoding.ASCII);
        //        sw.Write(strNewValue);
        //        sw.Close();
        //        StreamReader sr = new StreamReader(wbreq.GetResponse().GetResponseStream());
        //        string ssr = sr.ReadToEnd();
        //        var sss = System.Web.HttpContext.Current.Request["txn_id"];
        //        var sss1 = System.Web.HttpContext.Current.Request["tx"];
        //        succ.OrderKey = System.Web.HttpContext.Current.Request["orderkey"];
        //        succ.Status = System.Web.HttpContext.Current.Request["paymentStatus"];
        //        succ.Currency = System.Web.HttpContext.Current.Request["paymentCurrency"];
        //        succ.Amount = System.Web.HttpContext.Current.Request["paymentAmount"];
        //        succ.Amount = succ.Amount.Insert(succ.Amount.Length - 2, ".");
        //        //succ.TransactionID = orderKey.Split('^')[2];
        //        GateWay = Session["gateway"].ToString();
        //        gateway = _gateWay.Exists(s => s.GatewayName.ToLower().Trim() == GateWay) ? _gateWay.GetAll(s => s.GatewayName.ToLower().Trim() == GateWay).First().GatewayID : 0;
        //        if (SaveTxn(succ.TransactionID, DateTime.Now, Convert.ToInt32(Session["orderno"]), succ.Status, succ.Amount, gateway) != "")
        //        {
        //            return RedirectToAction("ChangeOrderType", "Employee", new { orderType = "private" });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        result = "";
        //    }
        //    return null;
        //}
        //#endregion
        #region GetIP
        public string GetIP()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }
        #endregion

        #region ResetSessions
        public void ResetSessions()
        {
            Session["qty"] = "0";
            Session["PRIVATEORDER"] = false;
            Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
            Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
            Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
        }
        #endregion
        #region GetWorldPayUrl
        public string GetPaymentUrl(int orderno, string gateway)
        {
            //System.Web.HttpContext.Current.Response.Headers.Append("set-cookie", $"{key}={value}; path=/; SameSite=Strict; Secure");
            var SS = System.Web.HttpContext.Current.Response.Headers;
            string postUrl = "";
            string instId = System.Configuration.ConfigurationManager.AppSettings["instId"].ToString();
            string refnosp = "";
            refnosp = orderno + "-" + DateTime.Now.ToString("ddMMyyHHmmss");
            if (orderno > 0)
            {
                var result = GetPayemetDetails(orderno, gateway);
                var model = new PaymentDetails();
                model = (PaymentDetails)result.Data;
                Session["orderno"] = orderno;
                Session["gateway"] = gateway;
                Session["refnosp"] = refnosp;
                var live = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["islive"].ToString());
                string site = "";
                string ordernos = "Payment for orders";
                if (gateway == "worldpay")
                {
                    string worldPayURl = live ? System.Configuration.ConfigurationManager.AppSettings["LiveBaseUrl"].ToString() : System.Configuration.ConfigurationManager.AppSettings["TestBaseUrl"].ToString();
                    site = "http://" + Request.Url.Authority + Request.ApplicationPath;
                    postUrl = worldPayURl;
                    postUrl += "&instId=" + instId;
                    postUrl += "&cartId=" + refnosp;
                    postUrl += live ? "" : "&testMode=100";
                    postUrl += "&currency=GBP";
                    postUrl += "&desc=" + ordernos;
                    postUrl += "&amount=" + model.ordtotal;
                    postUrl += "&MC_mycustomvar=Uniform Express Ltd";
                    postUrl += "&successURL=" + site + System.Configuration.ConfigurationManager.AppSettings["WorldPaySuccessURL"].ToString();
                    postUrl += "&failureURL=" + site + System.Configuration.ConfigurationManager.AppSettings["WorldPayFailureURL"].ToString();
                    postUrl += "&cancelURL=" + site + "Private/WorldpayCancel";
                    postUrl += "&name=" + model.firstname + " " + model.surname;
                    postUrl += "&address1=" + model.invaddr1;
                    postUrl += "&address2=" + model.invaddr2;
                    postUrl += "&town=" + model.invaddrtown;
                    postUrl += "&postCode=" + model.invpostcode;
                    postUrl += "&country=" + model.invcountry;
                    postUrl += "&tel=" + model.phone;
                    postUrl += "&email=" + model.emailid;
                    postUrl += "&fixContact&hideCurrency";
                    SaveTxn(orderno, ordernos, gateway, refnosp);
                }
                else if (gateway == "paypal")
                {
                    site = "http://" + Request.Url.Authority + Request.ApplicationPath;
                    postUrl = System.Configuration.ConfigurationManager.AppSettings["SandBoxPayPalUrl"].ToString();
                    postUrl += "&cmd=_notify-synch";
                    postUrl += "&business=" + "sasidharan@e4k.co";
                    postUrl += "&currency_code=" + "GBP"; ;
                    postUrl += "&item_name=" + "dress"; ;
                    postUrl += "&item_number=" + orderno; ;
                    postUrl += "&amount=" + model.ordtotal;
                    postUrl += "&return=" + site + "Private/PayPalSuccess?tx="; ;
                    postUrl += "&notify_url=" + site + "Private/PayPalSuccess?tx=";
                    postUrl += "&cancel_return=" + site + "Private/PayPalSuccess?tx="; ;
                    postUrl += "&invoice=" + refnosp;
                    postUrl += "&custom=" + model.ordtotal + " " + "GBP";
                    postUrl += "&first_name=" + model.firstname;
                    postUrl += "&last_name=" + model.surname;
                    postUrl += "&address1=" + model.invaddr1;
                    postUrl += "&address2=" + model.invaddr2;
                    postUrl += "&city=" + model.invaddrcity;
                    postUrl += "&state=" + model.invaddrtown;
                    postUrl += "&country=GB";
                    postUrl += "&zip=" + model.invpostcode;
                    postUrl += "&night_phone_a=" + model.phone;
                    postUrl += "&night_phone_b=" + model.phone;
                    postUrl += "&night_phone_c=" + model.phone;
                    postUrl += "&email=" + model.emailid;
                    postUrl += "&no_shipping=1";
                    postUrl += "&address_override=1";
                    postUrl += "&cbt=Return to " + "newuni";
                }
            }
            return postUrl;
        }
        #endregion

        #region
        public ActionResult ShowPrivateOrders()
        {
            Session["IsEmergency"] = false;
            return View();
        }
        #endregion

        #region printPrivateOrders
        public string PrintPrivateOrders(int orderNO)
        {
            string ResultChk = "";
            var slsHead = new SalesOrderHeaderViewModel();
            var carrier = FillCarrierStyle();
            if (_salesOrderHeader.Exists(x => x.OrderNo == orderNO))
            {
                slsHead = _salesOrderHeader.GetAll(x => x.OrderNo == orderNO).Select(x => new SalesOrderHeaderViewModel { OrderNo = x.OrderNo, CompanyID = x.CompanyID, WarehouseID = x.WarehouseID, CustID = x.CustID, OrderDate = x.OrderDate.Value.ToString("yyyy-MM-dd"), InvAddress1 = x.InvAddress1, InvAddress2 = x.InvAddress2, InvAddress3 = x.InvAddress3, InvCity = x.InvCity, InvTown = x.InvTown, InvPostCode = x.InvPostCode, InvCountry = x.InvCountry, DelDesc = x.DelDesc, DelAddress1 = x.DelAddress1, DelAddress2 = x.DelAddress2, DelAddress3 = x.DelAddress3, DelCity = x.DelCity, DelTown = x.DelTown, DelPostCode = x.DelPostCode, DelCountry = x.DelCountry, CustRef = x.CustRef, Carrier = x.Carrier, CarrierCharge = Convert.ToDouble(x.CarrierCharge.Value), Comments = x.Comments, CommentsExternal = x.CommentsExternal, TotalGoods = x.TotalGoods.Value, OrderGoods = x.OrderGoods.Value, Currency_Exchange_Rate = x.Currency_Exchange_Rate, UserID = x.UserID, PinNo = x.PinNo, UCodeId = x.UCodeId, Currency_Exchange_Code = x.Currency_Exchange_Code, TIMEOFENTRY = x.TIMEOFENTRY, RepID = x.RepID, ReasonCode = x.ReasonCode, OnlineUserID = x.OnlineUserID, OrderAnalysisCode1 = x.OrderAnalysisCode1, OrderAnalysisCode2 = x.OrderAnalysisCode2, OrderAnalysisCode3 = x.OrderAnalysisCode3, OrderAnalysisCode4 = x.OrderAnalysisCode4, OrderAnalysisCode5 = x.OrderAnalysisCode5, AllowPartShipment = x.AllowPartShipment, OrderType = x.OrderType, ContractRef = x.ContractRef, EmailID = x.EmailID, ContactName = x.ContactName, IsUcode = true }).First();
                if (slsHead.PinNo != "" && slsHead.PinNo != null)
                {
                    var empDetail = _employee.GetAll(x => x.EmployeeID == slsHead.PinNo).First();
                    slsHead.EmployeeID = empDetail.EmployeeID;
                    slsHead.EmployeeName = empDetail.Forename + " " + empDetail.Surname;
                }
                slsHead.SalesOrderLine = _salesOrderLines.GetAll(x => x.OrderNo == orderNO).Select(x => new SalesOrderLineViewModel
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
                    DeliveryDate = x.Deliverydate.Value.ToString(),
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
                    OriginalOrderNo = x.OriginalOrderNo.Value,
                    OriginalLineNo = x.OriginalLineNo,
                    AssemblyID = x.AssemblyID.Value,
                    AsmLineNo = x.AsmLineNo.Value,
                    ReasonCodeLine = Convert.ToInt64(x.ReasonCode),
                    ReturnOrderNo = x.ReturnOrderNo.Value,
                    ReturnLineNo = x.ReturnLineNo.Value,
                    SOPDetail5 = x.SOPDETAIL5,
                    SOPDetail4 = x.SOPDETAIL4,
                    SoqtyForempSO = x.OrdQty.Value,
                    VAT = _dataConnection.GetlineVat(Convert.ToDouble(x.OrdQty), Convert.ToDouble(x.Price), _dataConnection.GetVatPercent(x.StyleID, x.SizeID)),
                    isCarrline = carrier.Contains(x.StyleID) ? true : false,
                    Total = _dataConnection.GetlineTotals(Convert.ToDouble(x.OrdQty), Convert.ToDouble(x.Price), _dataConnection.GetVatPercent(x.StyleID, x.SizeID)),
                    VatPercent = _dataConnection.GetVatPercent(x.StyleID, x.SizeID)
                }).ToList();
                string custLogo = Session["LOGO"].ToString();
                string cmpLogo = ConfigurationManager.AppSettings["cmpLogo"].ToString();
                ResultChk = _dp.GetPrivateOrderMailMessage(slsHead, custLogo, cmpLogo, orderNO, true);
            }
            return ResultChk;
        }
        // _dp.GetPrivateOrderMailMessage(salesHead, custLogo, cmpLogo, intSalesOrderNo)
        #endregion


        [ValidateInput(false)]
        public ActionResult ShowPrivateOrdersGridViewPartial()
        {
            string busId = Session["BuisnessId"].ToString();
            string access = Session["Access"].ToString();
            string onlineusr = Session["UserName"].ToString();
            var model = _private.ShowPrivateOrders(access, onlineusr, busId);
            foreach (var orders in model)
            {
                if (_salesOrderLines.Exists(s => s.OrderNo == orders.orderno && s.ReturnOrderNo > 0))
                {
                    orders.retnorderno = _salesOrderLines.GetAll(s => s.OrderNo == orders.orderno).First().ReturnOrderNo.Value;
                }
            }
            Session["PrivateExportModel"] = model;
            return PartialView("_ShowPrivateOrdersGridViewPartial", model);
        }
        public ActionResult exporter()
        {
            var sett = CreateExportGridViewSettings();
            return GridViewExtension.ExportToXls(sett, ((List<PrivateOrderResultModel>)Session["PrivateExportModel"]));
        }
        public GridViewSettings CreateExportGridViewSettings()
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "ShowPrivateOrderGridView";
            settings.KeyFieldName = "OrderNo";
            settings.Columns.Add("orderno").Caption = "Order No";
            settings.Columns.Add("employeeid").Caption = "Employee id";
            settings.Columns.Add("employeename").Caption = "Employee name";
            settings.Columns.Add("orderdate").Caption = "Date";
            settings.Columns.Add("totalgoods").Caption = "Goods Total";
            settings.Columns.Add("vat").Caption = "VAT";
            settings.Columns.Add("ordergoods").Caption = "Grand Total";
            settings.Columns.Add("deliveryto").Caption = "Del Address";
            settings.Columns.Add("txnid").Caption = "Transaction Id";
            settings.Columns.Add("txnip").Caption = "IP Address";
            settings.Columns.Add("paymentdate").Caption = "Payment Date";
            settings.Columns.Add("responsestatus").Caption = "Payment Status";
            return settings;
        }
    }
}
















 