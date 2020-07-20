using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Maximus.Services
{
    public class DataConnectionService : IDataConnection
    {
        #region declarations
        public readonly IUnitOfWork _unitOfWork;
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
        
        #endregion

        #region constructor
        public DataConnectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DimFitCaption dimFitCap=new DimFitCaption(_unitOfWork);
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
            tblSalesOrderHeader salesOrderHeader=new tblSalesOrderHeader(_unitOfWork);
            Dimension1 dimension = new Dimension1(_unitOfWork);
            FskSetValues fskSetValues = new FskSetValues(_unitOfWork);
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

        #region GetAllFskStyle
        public IEnumerable<tblfsk_style> GetAllFskStyle()
        {
            return _tblFskStyle.GetAll();
        }
        #endregion

        #region GetAllStyleGroup
        public IEnumerable<tblfsk_style_groups> GetAllStyleGroups()
        {
            return _styleGroups.GetAll();
        }
        #endregion

        #region GetAllStyleGroup
        public IEnumerable<tblfsk_style_sizes_prices> GetAllStyleSizePrices()
        {
            return _styleSizePrice.GetAll();
        }
        #endregion
        #region GetAllStyleGroup
        public IEnumerable<tblsop_customerorder_template> GetAllCustomerOrder()
        {
            return _customerOrderTemplate.GetAll();
        }
        #endregion
        #region GetAllStyleGroup
        public IEnumerable<tblaccemp_ucodes_desc> GetAllUcodeDesc()
        {
            return _ucode_Description.GetAll();
        }
        #endregion
        #region GetAllStyleGroup
        public IEnumerable<tblaccemp_employee> GetAllEmployee()
        {
            return _employee.GetAll();
        }
        #endregion

        #region GetAllUcodeEmployee
        public IEnumerable<tblaccemp_ucodesemployees> GetAllUcodeEmployess()
        {
            return _ucodeEmployees.GetAll();
        }
        #endregion

        #region GetAllStyleGroup
        public IEnumerable<tblaccemp_departments> GetAllDepts()
        {
            return _departments.GetAll();
        }
        #endregion

        #region GetUcodeList
        public List<string> GetUcodeList(string employeeId = "", string businessId = "")
        {
            return _dp.GetUcodeList(employeeId, businessId);
        }
        #endregion

        public decimal GetStyleSizePrices(string StyleID = "", string SizeId = "", string busId = "",string priceId="")
        {
            return _dp.GetPrice(StyleID, SizeId, busId, priceId);
        }

        #region getAddressID
        public int GetAddressId(string businessId, string empID)
        {
            return _dp.GetAddressId(businessId, empID);
        }
        #endregion

        #region GetAllCustAssembly
        public IEnumerable<getcustassembly> GetAllCustAssembly()
        {
            return _customAssembly.GetAll() ;
        }
        #endregion

        #region GetAllUcodeByFreetextview
        public IEnumerable<ucodeby_freetextview> GetAllUcodeByFreetextview()
        {
            
            return _ucodeByFreeText.GetAll();
        }
        #endregion

        #region 
        public List<ucodeby_freetextview> GetAllUcodeByFreetextviewWhere(List<string> freetextLst, string Ucode)
        {
            return _ucodeByFreeText.GetAll(x=>freetextLst.Contains(x.FreeText) && x.UCodeID== Ucode).ToList();
        }
        #endregion

        #region GetAllStyleByFreetext
        public IEnumerable<tblfsk_style_freetext> GetAllStyleByFreetext()
        {
            return _fskStyleFreetext.GetAll() ;
        }
        #endregion

        #region GetAllStyleView
        public IEnumerable<getstylesview> GetAllStyleView()
        {
            return _stylesView.GetAll();
        }
        #endregion

        #region GetAllStyle_Colour_Size_Obsolete
        public IEnumerable<tblfsk_style_colour_size_obsolete> GetAllStyle_Colour_Size_Obsolete()
        {
            return _styleColorSizeObsolete.GetAll();
        }
        #endregion

        #region GetAllStyleSizes
        public IEnumerable<tblfsk_style_sizes> GetAllStyleSizes()
        {
            return _style_Sizes.GetAll();
        }
        #endregion

        #region GetAllStyleByFreetextView
        public IEnumerable<styleby_freetextview> GetAllStyleByFreetextView()
        {
            return _styleByFreetext.GetAll();
        }
        #endregion

        #region GetAllStyleColour
        public IEnumerable<tblfsk_style_colour> GetAllStyleColour()
        {
            return _style_Colour.GetAll();
        }
        #endregion

        #region GetProductGroup
        public List<int> GetProductGroup(string Template)
        {
            return _dp.GetProductGroup(Template);
        }
        #endregion

        #region GetStyleViewModel
        public IEnumerable<styleViewmodel> GetStyleViewModel(string Template, string busId)
        {
            return _dp.GetStyleViewModel(Template, busId);
        }
        #endregion

        #region GetBulkPrice1
        public decimal GetBulkPrice1(int qty, string StyleID = "", string SizeId = "", string busId = "")
        {
            return _dp.GetBulkPrice1(qty, StyleID, SizeId, busId);
        }
        #endregion

        #region GetPreviousHistory
        public PreviousQty GetPreviousHistory(string EmpId, string BuisnessId, string styleId)
        {
            return _dp.GetPreviousHistory(EmpId, BuisnessId, styleId);
        }
        #endregion

        #region GetReqData
        public string GetReqData(string StyleID)
        {
            return _dp.GetReqData(StyleID);
        }
        #endregion

        #region GetPrice
        public decimal GetPrice(string StyleID = "", string SizeId = "", string busId = "",string priceId="")
        {
            return _dp.GetPrice(StyleID, SizeId, busId, priceId);
        }
        #endregion

        #region getStyleFromFretxt
        public string getStyleFromFretxt(string freetxt)
        {
            return _dp.getStyleFromFretxt(freetxt);
        }
        #endregion

        #region getEmployeeAddress
        public string getEmployeeAddress(string EmpId, string BuisnessId)
        {

            return _dp.getEmployeeAddress(EmpId, BuisnessId);
        }

        #endregion

        #region GetAllPreviousData
        public string GetAllPreviousData(string EmpId, string BuisnessId, string styleId, long inBasket = 0)
        {
            return _dp.GetAllPreviousData(EmpId, BuisnessId, styleId, inBasket);
        }
        #endregion

        #region GetVatPercent
        public double GetVatPercent(string style, string size)
        {
            return _dp.GetVatPercent(style, size);
        }
        #endregion

        #region GetVatCode
        public int GetVatCode()
        {
            return _dp.GetVatCode();
        }
        #endregion

        #region GetDeliveryDate
        public string GetDeliveryDate(int noOfDays, bool isWeekends)
        {
            return _dp.GetDeliveryDate(noOfDays, isWeekends);
        }
        #endregion

        #region GetCostPrice
        public double GetCostPrice(string style, string size, string color, string currency, int mprice, int seqNo)
        {
            return _dp.GetCostPrice(style, size, color, currency, mprice, seqNo);
        }
        #endregion

        #region GetFitAllocString
        public string GetFitAllocString(string freeText)
        {
            return _dp.GetFitAllocString(freeText);
        }
        #endregion

        #region Dimalloc
        public styleViewmodel GetDimallocStyles(string style)
        {
            return _dp.GetDimallocStyles(style);
        }
        #endregion

        #region GetAllStockCard
        public IEnumerable<tblaccemp_stockcard> GetAllStockCard()
        {
            return _stockCard.GetAll();
        }

        #endregion

        #region GetAllNextNo
        public IEnumerable<tblgen_nextno> GetAllNextNo()
        {
            return _nextno.GetAll();
        }
        #endregion

        #region GetAllCountryCodes
        public IEnumerable<tblbus_countrycodes> GetAllCountryCodes()
        {
            return _countryCodes.GetAll();
        }
        #endregion

        #region GetAllBusAddress
        public IEnumerable<Maximus.Data.models.tblbus_address> GetAllBusAddress()
        {
            return _busAddress.GetAll();
        }

        #endregion

        #region GetAllBusContact
        public IEnumerable<tblbus_contact> GetAllBusContact()
        {
            return _busContact.GetAll();
        }

        #endregion

        #region GetAllAssemblyHeader
        public IEnumerable<tblasm_assemblyheader> GetAllAssemblyHeader()
        {
            return _assemblyHeader.GetAll();
        }
        #endregion

        #region GetAllAssemblyDetail
        public IEnumerable<tblasm_assemblydetail> GetAllAssemblyDetail()
        {
            return _assemblyDetail.GetAll();
        }
        #endregion

        #region GetAllUcodes
        public IEnumerable<tblaccemp_ucodes> GetAllUcodes()
        {
            return _ucodes.GetAll();
        }
        #endregion

        #region GetlineVat
        public double GetlineVat(double qty, double price, double vat)
        {
            return _dp.GetlineVat(qty, price, vat);
        }

        #endregion

        #region GetlineTotals
        public double GetlineTotals(double qty, double price, double vat)
        {
            return _dp.GetlineTotals(qty, price, vat);
        }

        #endregion

        #region BusinessParam
        public string BusinessParam(string paramId, string businessId)
        {
            return _dp.BusinessParam(paramId, businessId);
        }
        #endregion

        #region  CheckBudgetOrPoints
        public bool CheckBudgetOrPoints(string BUDGETREQ, string businessId, bool booCheck = true)
        {
            return _dp.CheckBudgetOrPoints(BUDGETREQ,businessId, booCheck);
        }
        #endregion

        #region  GetAddressDetails 
        public BusAddress1 GetAddressDetails(string qry)
        {
            return _dp.GetAddressDetails(qry);
        }
        #endregion

        #region GetBooValue
        public bool GetBooValue(string sSqry)
        {
            return _dp.GetBooValue(sSqry);
        }

        #endregion

        #region displayOrderListGrid

        public void displayOrderListGrid(bool booShowManpack = false)
        {
            _dp.displayOrderListGrid(booShowManpack);
        }

        #endregion

        #region  GetAllTotals
        public TotalModel GetAlltotals(List<SalesOrderHeaderViewModel> mod, double carriage,bool isEdit=false)
        {
            return _dp.GetAlltotals(mod, carriage, isEdit);
        }
        #endregion

        #region GetCustRefVisiblity
        public bool GetCustRefVisiblity(string busId)
        {
            return _dp.GetCustRefVisiblity(busId);
        }
        #endregion

        #region GetDeliveryAddressId
        public int GetDeliveryAddressId(string emp, string busId ,string onlineUserId)
        {
            return _dp.GetDeliveryAddressId(emp, busId,onlineUserId);
        }
        #endregion

        #region GetSitecodes
        public List<SiteCodeModel> GetSitecodes(string businessId)
        {
            return _dp.GetSitecodes(businessId);
           // _dp.GetCarrierStyleCmbValue();
        }
        #endregion

        #region  GetCarrierStyleCmbValue
        public List<string> GetCarrierStyleCmbValue(string busId)
        {
            return _dp.GetCarrierStyleCmbValue(busId);
        }
        #endregion

        #region GetCarrierCmbValue
        public List<string> GetCarrierCmbValue()
        {
            return _dp.GetCarrierCmbValue();
        }
        #endregion

        #region checkCarriageLine
        public bool checkCarriageLine(List<SalesOrderHeaderViewModel> currentOrder)
        {
            return _dp.checkCarriageLine(currentOrder);
        }

        #endregion

        #region GetAllAssembly
        public IEnumerable<getallassembly> GetAllAssembly()
        {
         return   _allAssemblies.GetAll();
        }

#endregion

        #region GetAllSalesOrderHeader
        public IEnumerable<tblsop_salesorder_header> GetAllSalesOrderHeader()
        {
            return _salesOrderHeader.GetAll();
        }

        public string CompanyParam(string paramID, string companyId)
        {
            return _dp.CompanyParam(paramID, companyId);
        }

        public string SetDefaultWarehouse(string userId, string businessId)
        {
            return _dp.SetDefaultWarehouse(userId, businessId);
        }

        public bool IsSuperUser(string cmpId, string custId, string _user)
        {
            return _dp.IsSuperUser(cmpId, custId, _user);
        }

        public BusinessInfo GetbusInfo(string businessId)
        {
            return _dp.GetbusInfo(businessId);
        }

        public bool IsSiteCode(string custId)
        {
            return _dp.IsSiteCode(custId);
        }

        public string getPermission(controls controlId, string AccessID, string BusinessID = "", string usr = "", string userId = "")
        {
            return _dp.getPermission(controlId, AccessID, BusinessID, usr, userId);
        }

        public bool ShowHourse(string busId = "")
        {
            return _dp.ShowHourse(busId);
        }

        public string DefaultEmployee(string companyid, string userid, string custid)
        {
            return _dp.DefaultEmployee( companyid,  userid,  custid);
        }

        public List<PermissionList> PermissionSettings(string busId, string userId, string controlId, string accessId)
        {
            return _dp.PermissionSettings(busId, userId, controlId, accessId);
        }

        public bool IsReasonUcodes(string busId = "")
        {
            return _dp.IsReasonUcodes(busId);
        }

        public IEnumerable<tblbus_business> GetAllBusBusinness()
        {
            return _busBusiness.GetAll();
        }

        public IEnumerable<tblfskstyle_dimension1> GetFskStyleDimension1()
        {
            return _dimension1.GetAll();
        }

        public IEnumerable<tblfsk_setvalues> GetallSetvalues()
        {
            return _fskSetValues.GetAll() ;
        }

        public IEnumerable<style_dimfitalloc_caption> GetallDimFitAllocCaption()
        {
            return _dimFitCap.GetAll() ;
        }

        public IEnumerable<getstylesview> GetAllGetStylesView()
        {
            return _stylesView.GetAll();
        }

        public IEnumerable<tblsop_reasoncodes> GetAllReasonCodes()
        {
            return _reason.GetAll();
        }

        public IEnumerable<tblfsk_colour> GetAllColours()
        {
            return _fskColor.GetAll();
        }

        public List<UcodeModel> GetAllUcodeLst(string ucode)
        {
            return _dp.GetAllUcodeLst(ucode);
        }
        #endregion
        public DataTable GetDatatableByQry(int i, string busId)
        {
            return _dp.GetDatatableByQry(i, busId);
        }
        public DataTable FillshowhoursCmb(string strCustID, string txtEmpID, string strCompanyID)
        {
        return _dp.FillshowhoursCmb(strCustID,  txtEmpID,  strCompanyID);
        }

        public int GetEmpAddress(string EmpId)
        {
            return _dp.GetEmpAddress(EmpId);
        }
        public List<UcodenDescModal> GetAllUcodesAndDesc(string businessId = "")
        {
            return _dp.GetAllUcodesAndDesc(businessId);
        }
        public List<UcodenDescModal> GetAllTemplates(string businessId = "")
        {
            return _dp.GetAllTemplates(businessId);
        }

        #region getemployee

        public List<string> GetEmployeeProvedure(string busId, string usrId)
        {
            List<string> empLst = new List<string>();
            empLst = _dp.GetEmployeeByProcedure(busId, usrId).Select(s=>s.EmployeeId).ToList();
            return empLst; 
        }
        #endregion

    }
}
