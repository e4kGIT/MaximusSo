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
using Maximus.Filter;
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
        public readonly BusBusiness _busBusiness;
        public readonly FskSetValues _fskSetValues;
        public readonly Dimension1 _dimension1;
        public readonly DimFitCaption _dimFitCap;
        public readonly Reasoncodes _reason;
        public readonly FskColour _fskColor;
        public readonly UcodeByFreeTextView _ucodeByFreetext;
        public readonly StyleColorSize _styleColorSize;
        public HomeController(IUnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
            HomeService home = new HomeService(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            _dataConnection = dataConnection;
            _home = home;
            StyleColorSize styleColorSize = new StyleColorSize(_unitOfWork);
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
            _ucodeByFreetext = ucodeByFreetext;
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
        }
        #endregion

        #region Index
        [Authorize]
        public ActionResult Index()
        {
            Session["BulkQtyModel"] = new List<BulkOrderModel>();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
            {
                if ((bool)Session["IsBulkOrder1"] == false)
                {
                    Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Where(x => x.OriginalLineNo == null).Sum(x => x.OrdQty) : 0 : 0;
                }
                else if ((bool)Session["IsManPack"] == false)
                {
                    Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.UCodeId != null) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.UCodeId.ToLower() == Session["selectedUcodes"].ToString().ToLower()) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.UCodeId.ToLower() == Session["selectedUcodes"].ToString().ToLower()).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.UCodeId.ToLower() == Session["selectedUcodes"].ToString().ToLower()).Any(x => x.SalesOrderLine != null) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.UCodeId.ToLower() == Session["selectedUcodes"].ToString().ToLower()).Where(x => x.SalesOrderLine != null).Count() : 0 : 0 : 0 : 0;
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
        public ActionResult GetAllGroups()
        {
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
                else if (((List<string>)Session["SelectedTemplate"]).Count > 0)
                {
                    var result1 = (List<string>)Session["SelectedTemplate"];
                    var model = new List<int>();
                    foreach (var item in result1)
                    {
                        model.AddRange(_dataConnection.GetProductGroup(item));
                    }
                    var result = _styleGroups.GetAll(x => x.Description != "" && model.Contains(x.GroupID)).ToList();
                    return PartialView("_getAllGroups", result);
                }
                else
                {


                    var result = _styleGroups.GetAll(x => x.Description != "").ToList();
                    return PartialView("_getAllGroups", result);
                }

            }
            catch (Exception e)
            {
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
                List<string> result = (List<string>)Session["SelectedTemplate"];
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
                        string ucode = Session["SelectedUcode"].ToString();
                        List<string> freeTextLst = (List<string>)Session["UcFreeTxt"];
                        //model = _dataConnection.GetAllUcodeByFreetextview(freeTextLst, ucode).Where(x => freeTextLst.Contains(x.FreeText) & x.UCodeID == ucode).Select(x => new styleViewmodel
                        //{
                        //    StyleID = x.StyleID,
                        //    ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        //    StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : "/" + x.StyleImage,
                        //    Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false & d.CustID == custId) |
                        //  _allAssemblies.Exists(d => d.ParentStyleID == x.StyleID & d.isChargeable == false) ? 1 : 0,
                        //    //Assembly = _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID).Any() ? _customAssembly.GetAll(d => d.ParentStyleID == x.StyleID && d.isChargeable == 0).Any() ? 1 : 0 : 0,
                        //    isAllocated = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? true : false : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? true : false,
                        //    // Dimensions = x.FreeText
                        //    Dimensions = x.StyleID.Contains(",") ? _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID.Substring(0, x.StyleID.IndexOf(",")) & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "" : _fskStyleFreetext.Exists(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC") ? _fskStyleFreetext.GetAll(s => s.StyleId == x.StyleID & s.FreeTextType == "DIMALLOC").FirstOrDefault().FreeText : "",
                        //    SeqNO = x.SeqNo.Value,
                        //    Freetext = x.FreeText,
                        //    OriginalStyleid = x.StyleID
                        //}).ToList();
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
                    var ssss = Session["SelectedEmp"].ToString();
                    foreach (var data1 in model)
                    {
                        data1.Reqdata = _dataConnection.GetReqData(data1.StyleID);
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
                        model = model.Any(x => x.StyleID.ToLower().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())) ? model.Where(x => x.StyleID.ToLower().Trim().Contains(filterText.ToLower().Trim()) | x.Description.ToLower().Trim().Contains(filterText.ToLower().Trim())).ToList() : null;
                    }
                    model = model.GroupBy(x => x.StyleID).Select(y => y.First()).ToList();
                    if (BringImages)
                    {
                        model = model.Where(x => x.StyleImage.Contains("notfound.png") == false).ToList();
                    }
                }
                catch (Exception e)
                {

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
            }
            return null;
        }
        #endregion

        #region GetPrice based on styleid and colorid
        public decimal GetPrice(string StyleID = "", string SizeId = "")
        {
            return _home.GetPrice(StyleID, SizeId, Session["BuisnessId"].ToString());
        }

        public decimal GetBulkPrice(int qty, string style = "", string size = "")
        {
            return _home.GetBulkPrice(qty, style, size, Session["BuisnessId"].ToString());
        }

        #endregion

        #region GetPriceStats
        public string GetPriceStats()
        {
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
                            priceLst.Add(new SizePrice { Size = size, Price = _dataConnection.GetPrice(styleId, size, Session["BuisnessId"].ToString()), Currency = Session["CurrencySymbol"].ToString() });
                        }
                    }
                    catch (Exception e)
                    {

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
                            priceLst.Add(new SizePrice { Size = size, Price = _dataConnection.GetPrice(styleId, size, Session["BuisnessId"].ToString()), Currency = Session["CurrencySymbol"].ToString() });
                        }
                        result.PriceList = priceLst;
                    }
                    else
                    {
                        result.SizeList = data1;
                        foreach (var size in result.SizeList)
                        {
                            priceLst.Add(new SizePrice { Size = size, Price = _dataConnection.GetPrice(styleId, size, Session["BuisnessId"].ToString()), Currency = Session["CurrencySymbol"].ToString() });
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

        #region  getCard
        public ActionResult GetCard(string StyleID, string Orgstyle)
        {
            //StyleID = "TSB LJ1/L";
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            string ucode = Session["SelectedUcode"].ToString();

            var hasFit = _fskStyleFreetext.GetAll(x => x.StyleId == StyleID).Any(x => x.FreeTextType == "FITALLOC") ? _fskStyleFreetext.GetAll(x => x.StyleId == StyleID & x.FreeTextType == "FITALLOC").First().FreeText : "";
            List<styleViewmodel> model = new List<styleViewmodel>();
            if (hasFit == "")
            {
                try
                {
                    model.Add(_ucodeByFreetext.GetAll(x => x.StyleID == StyleID).ToList().Select(x => new styleViewmodel
                    {
                        StyleID = x.StyleID,
                        ProductGroup = x.Product_Group != null ? x.Product_Group.Value : 0,
                        StyleImage = x.StyleImage == "" | x.StyleImage == null ? "/StyleImages/notfound.png" : x.StyleImage,
                        Assembly = _customAssembly.Exists(d => d.ParentStyleID == x.StyleID) ? _customAssembly.Exists(d => d.ParentStyleID == x.StyleID && d.isChargeable == false) ? 1 : 0 : 0,
                        OriginalStyleid = Orgstyle
                    }).FirstOrDefault());
                }
                catch (Exception e)
                { }
                foreach (var data1 in model)
                {
                    data1.Reqdata = _dataConnection.GetReqData(data1.StyleID);
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
                        data1.HasPreviousSize = _dataConnection.GetPreviousHistory(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString(), data1.OriginalStyleid);
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

        #region AddItemsToCart
        public JsonResult AddToCart(string description = "", string price = "", string size = "", string color = "", string qty = "", string style = "", string orgStyl = "", string entQty = "", string reqData1 = "", string reason = "", string QtySizePriceArr = "")
        {
            string result = "";
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            var salesOrderLines = new List<SalesOrderLineViewModel>();
            var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            long lineNo = 0;
            if (salesOrderHeader.Count != 0)
            {
                salesOrderLines = salesOrderHeader.Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine != null ?
                  salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList() : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
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
                        CustRef = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                        Comments = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
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
            var chargableAssembs = new List<SalesOrderLineViewModel>();
            var OptionalAssembs = new List<SalesOrderLineViewModel>();
            if (QtySizePriceArr != "")
            {
                var lst = JsonConvert.DeserializeObject<List<QtySizePriceArr>>(QtySizePriceArr);
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        try
                        {
                            var Pricenull = Convert.ToDouble(item.Price) == 0 ? Convert.ToDouble(GetPrice(style, item.Size)) : Convert.ToDouble(item.Price);


                            salesOrderLines.Add(new SalesOrderLineViewModel { ColourID = color, LineNo = lineNo, Description = description, OrdQty = item.Qty, Price = Pricenull, SizeID = item.Size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString(), StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(orgStyl)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(orgStyl)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"), orgStyleId = orgStyl, VatPercent = _dataConnection.GetVatPercent(style, item.Size), EntQty = entQty, FreeText1 = item.ReqData, DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"])), VatCode1 = _dataConnection.GetVatCode(), RepId = Convert.ToInt32(Session["Rep_Id"].ToString()), Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]), Cost1 = _dataConnection.GetCostPrice(style, item.Size, color, Session["Currency_Name"].ToString(), 1, 0), IssueUOM1 = 1, IssueQty1 = Convert.ToInt32(item.Qty), StockingUOM1 = 1, SOPDetail4 = reason });


                        }
                        catch (Exception e)
                        {
                            var EmployeeId = Session["SelectedEmp"].ToString();
                            var EmployeeName = Session["EmpName"].ToString();
                        }
                        chargableAssembs = _home.GetChargableAssembly(Session["intNoOfday"].ToString(), Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), style, lineNo, Convert.ToInt64(item.Qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), Session["BuisnessId"].ToString());
                        if (chargableAssembs.Count > 0)
                        {
                            salesOrderLines.AddRange(chargableAssembs);
                        }

                        OptionalAssembs = new List<SalesOrderLineViewModel>();

                        if ((List<string>)Session["assemList"] != null)
                        {
                            if (((List<string>)Session["assemList"]).Count > 0)
                            {
                                OptionalAssembs = _home.GetOptionalAssembly(Session["intNoOfday"].ToString(), Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), (List<string>)Session["assemList"], style, lineNo, salesOrderLines, Convert.ToInt64(item.Qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), salesOrderLines.Count, Session["BuisnessId"].ToString());
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
                        Session["qty"] = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString() && x.OriginalLineNo == null).Sum(x => x.OrdQty);
                        lineNo = lineNo + 1;
                    }
                    result = "<button class=\"btn\" onclick=\"GetCart()\" style=\"background-color:#009885;color:white\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:white;font-size:25px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button>";

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (salesOrderHeader.Count != 0)
                {
                    salesOrderLines = salesOrderHeader.Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine != null ?
                      salesOrderHeader.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList() : new List<SalesOrderLineViewModel>() : new List<SalesOrderLineViewModel>();
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
                            CustRef = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                            Comments = _salesOrderHeader.GetAll(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
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
                        salesOrderLines.Add(new SalesOrderLineViewModel { ColourID = color, LineNo = lineNo, Description = description, OrdQty = Convert.ToInt64(qty), Price = Convert.ToDouble(price) == 0 ? Convert.ToDouble(GetPrice(style, size)) : Convert.ToDouble(price), SizeID = size, StyleID = style, EmployeeId = Session["SelectedEmp"].ToString(), EmployeeName = Session["EmpName"].ToString(), StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(orgStyl)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(orgStyl)).FirstOrDefault().StyleImage : Url.Content("~/StyleImages/notfound.png"), orgStyleId = orgStyl, VatPercent = _dataConnection.GetVatPercent(style, size), EntQty = entQty, FreeText1 = reqData1, DeliveryDate = _dataConnection.GetDeliveryDate(Convert.ToInt32(Session["intNoOfday"]) - 1, Convert.ToBoolean(Session["IncWendsDel"])), VatCode1 = _dataConnection.GetVatCode(), RepId = Convert.ToInt32(Session["Rep_Id"].ToString()), Currency_Exchange_Rate = Convert.ToDouble(Session["CurrencyExchangeRate"]), Cost1 = _dataConnection.GetCostPrice(style, size, color, Session["Currency_Name"].ToString(), 1, 0), IssueUOM1 = 1, IssueQty1 = Convert.ToInt32(qty), StockingUOM1 = 1, SOPDetail4 = reason });
                    }
                    catch (Exception e)
                    {
                        var EmployeeId = Session["SelectedEmp"].ToString();
                        var EmployeeName = Session["EmpName"].ToString();
                    }

                    chargableAssembs = _home.GetChargableAssembly(Session["intNoOfday"].ToString(), Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), style, lineNo, Convert.ToInt64(qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), Session["BuisnessId"].ToString());
                    if (chargableAssembs.Count > 0)
                    {
                        salesOrderLines.AddRange(chargableAssembs);
                    }
                    OptionalAssembs = new List<SalesOrderLineViewModel>();

                    if ((List<string>)Session["assemList"] != null)
                    {
                        if (((List<string>)Session["assemList"]).Count > 0)
                        {
                            OptionalAssembs = _home.GetOptionalAssembly(Session["intNoOfday"].ToString(), Session["IncWendsDel"].ToString(), Session["CurrencyExchangeRate"].ToString(), Session["Currency_Name"].ToString(), Session["Rep_Id"].ToString(), (List<string>)Session["assemList"], style, lineNo, salesOrderLines, Convert.ToInt64(qty), Session["SelectedEmp"].ToString(), Session["EmpName"].ToString(), salesOrderLines.Count, Session["BuisnessId"].ToString());
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
                    Session["qty"] = salesOrderLines.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString() && x.OriginalLineNo == null).Sum(x => x.OrdQty);
                    result = "<button class=\"btn\" onclick=\"GetCart()\" style=\"background-color:#009885;color:white\"><b>View Basket &nbsp;&nbsp;&nbsp;<span class=\"glyphicon glyphicon-shopping-cart\" style=\"color:white;font-size:25px\" ></span><sup class=\"badge\" id=\"lblCartCount\">" + Session["qty"].ToString() + "</sup></b></button>";

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

        #region GetEntitlement

        public JsonResult GetEntitlement(string StyleId = "", string ColorId = "", string orgStyl = "")
        {
            EntitlementModel em = new EntitlementModel();
            //if(orgStyl.Contains(','))
            //{
            var emp = Session["SelectedEmp"].ToString();
            string Ucodes = Session["SelectedUcode"] == null ? "" : Session["SelectedUcode"].ToString();
            var saleHead = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var salesLine = saleHead.Any(x => x.EmployeeID == emp && x.UCodeId == Ucodes) ? saleHead.Where(x => x.EmployeeID == emp && x.UCodeId == Ucodes).First().SalesOrderLine : new List<SalesOrderLineViewModel>();
            long basketCount = 0;
            if (salesLine != null)
            {
                if (salesLine.Count > 0)
                {
                    basketCount = salesLine.Any(x => x.orgStyleId == orgStyl | x.StyleID == StyleId) ? salesLine.Where(x => x.orgStyleId == orgStyl | x.StyleID == StyleId).Sum(x => x.OrdQty) : 0;
                }
            }
            em.EmpId = "<b>" + Session["SelectedEmp"].ToString() + "</b> to style: <b>" + StyleId + "</b>";
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
            em.Result = "<table class=\"table\"><tr><td>Entitlement:  0</td></tr><tr><td>Issued: 0</td></tr><tr><td>Previous History: N/A</td></tr></table>";
            return Json(em, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region GetBtnStatus
        [HttpPost]
        public string GetBtnStatus(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "")
        {
            string result = "";
            string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
            string busId = "";
            string empId = "";
            var issuedDiff = 0;
            var salesOrderLines = ((List<SalesOrderLineViewModel>)Session["SalesOrderLines"]).Where(X => X.orgStyleId != null).ToList();
            var onCartLst = salesOrderLines.Where(x => x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()).ToList();
            var onCartVal = onCartLst.Sum(x => x.OrdQty);
            if (Session["OverrideEnt"].ToString().ToLower().Trim() != "show")
            {

                var s = Session["ALLOW_OVERRIDE_ENT"].ToString().ToLower();
                if (ordQty != "" & color != "" & style != "" & qty != "")
                {
                    int difference = 0;
                    int oQty = Convert.ToInt32(ordQty);
                    var entitlement = _ucodes.Exists(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? _ucodes.GetAll(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                    var issuedLst = _stockCard.Exists(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()) ? _stockCard.GetAll(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
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
            else
            {
                result = "enabled";
            }
            return result;
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
                List<string> result = (List<string>)Session["SelectedTemplate"];
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

                }
            }
            return result;
        }
        #endregion

        #region GetBasketStatus
        [HttpPost]
        public string GetBasketStatus()
        {
            string result = "";
            string empId = (Session["SelectedEmp"].ToString());

            var salesHeader = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            if (!salesHeader.Any(x => x.SalesOrderLine != null))
            {
                result = "fail";
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

    }
}