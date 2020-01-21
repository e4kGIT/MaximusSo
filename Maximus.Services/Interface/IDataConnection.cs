using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
   public interface IDataConnection
    {
        List<UcodeModel> GetAllUcodeLst(string ucode);
        string CompanyParam(string paramID, string companyId);
        string SetDefaultWarehouse(string userId, string businessId);
        bool IsSuperUser(string cmpId, string custId, string _user);
        BusinessInfo GetbusInfo(string businessId);
        bool IsSiteCode(string custId);
        string getPermission(controls controlId, string AccessID, string BusinessID = "", string usr = "", string userId = "");
        bool ShowHourse(string busId = "");
        string DefaultEmployee(string companyid, string userid, string custid);
        string BusinessParam(string paramId, string businessId);
        List<PermissionList> PermissionSettings(string busId, string userId, string controlId, string accessId);
        bool IsReasonUcodes(string busId = "");
        bool CheckBudgetOrPoints(string BUDGETREQ, string businessId, bool booCheck = true);

        double GetlineVat(double qty, double price, double vat);

        double GetlineTotals(double qty, double price, double vat);
        BusAddress1 GetAddressDetails(string qry);

        bool GetBooValue(string sSqry);
        void displayOrderListGrid(bool booShowManpack = false);

        TotalModel GetAlltotals(List<SalesOrderHeaderViewModel> mod, double carriage);
        bool GetCustRefVisiblity(string busId);
        int GetDeliveryAddressId(string emp, string busId);

        List<SiteCodeModel> GetSitecodes(string businessId);

        List<string> GetCarrierStyleCmbValue();

        bool checkCarriageLine(List<SalesOrderHeaderViewModel> currentOrder);
        List<string> GetCarrierCmbValue();
        IEnumerable<Maximus.Data.models.tblbus_address> GetAllBusAddress();

        IEnumerable<tblbus_contact> GetAllBusContact();

        IEnumerable<tblasm_assemblyheader> GetAllAssemblyHeader();

        IEnumerable<tblasm_assemblydetail> GetAllAssemblyDetail();

        IEnumerable<tblaccemp_ucodes> GetAllUcodes();

        IEnumerable<tblaccemp_stockcard> GetAllStockCard();

        IEnumerable<tblgen_nextno> GetAllNextNo();

        IEnumerable<tblbus_countrycodes> GetAllCountryCodes();
        IEnumerable<tblfsk_style> GetAllFskStyle();

        IEnumerable<tblfsk_style_groups> GetAllStyleGroups();

        IEnumerable<getcustassembly> GetAllCustAssembly();

        IEnumerable<getallassembly> GetAllAssembly();
        IEnumerable<ucodeby_freetextview> GetAllUcodeByFreetextview();
        List<ucodeby_freetextview> GetAllUcodeByFreetextviewWhere(List<string> freetextLst,string Ucode);

        IEnumerable<tblfsk_style_freetext> GetAllStyleByFreetext();

        IEnumerable<getstylesview> GetAllStyleView();

        IEnumerable<tblfsk_style_colour_size_obsolete> GetAllStyle_Colour_Size_Obsolete();

        IEnumerable<tblfsk_style_sizes> GetAllStyleSizes();

        IEnumerable<styleby_freetextview> GetAllStyleByFreetextView();
        IEnumerable<tblsop_salesorder_header> GetAllSalesOrderHeader();
        IEnumerable<tblbus_business> GetAllBusBusinness();

        IEnumerable<tblfsk_style_colour> GetAllStyleColour();
        List<int> GetProductGroup(string Template);
        IEnumerable<styleViewmodel> GetStyleViewModel(string Template, string busId);
        IEnumerable<tblfskstyle_dimension1> GetFskStyleDimension1();
        IEnumerable<tblfsk_setvalues> GetallSetvalues();
        IEnumerable<style_dimfitalloc_caption> GetallDimFitAllocCaption();
        IEnumerable<getstylesview> GetAllGetStylesView();
        IEnumerable<tblsop_reasoncodes> GetAllReasonCodes();
        IEnumerable<tblfsk_colour> GetAllColours();
        PreviousQty GetPreviousHistory(string EmpId, string BuisnessId, string styleId);
        string GetReqData(string StyleID);
        decimal GetPrice(string StyleID = "", string SizeId = "", string busId = "");
        string getStyleFromFretxt(string freetxt);
        string getEmployeeAddress(string EmpId, string BuisnessId);
        double GetVatPercent(string style, string size);
        int GetVatCode();
        string GetDeliveryDate(int noOfDays, bool isWeekends);
        double GetCostPrice(string style, string size, string color, string currency, int mprice, int seqNo);
        string GetFitAllocString(string freeText);
        decimal GetBulkPrice1(int qty, string StyleID = "", string SizeId = "", string busId = "");
        string GetAllPreviousData(string EmpId, string BuisnessId, string styleId, long inBasket = 0);
        IEnumerable<tblfsk_style_sizes_prices> GetAllStyleSizePrices();
        decimal GetStyleSizePrices(string StyleID = "", string SizeId = "", string busId = "");
        styleViewmodel GetDimallocStyles(string style);
        IEnumerable<tblsop_customerorder_template> GetAllCustomerOrder();
        IEnumerable<tblaccemp_ucodes_desc> GetAllUcodeDesc();
        IEnumerable<tblaccemp_departments> GetAllDepts();
        IEnumerable<tblaccemp_employee> GetAllEmployee();
        List<string> GetUcodeList(string employeeId = "", string businessId = "");
        List<UcodenDescModal> GetAllUcodesAndDesc(string businessId = "");
        List<UcodenDescModal> GetAllTemplates(string businessId = "");
        int GetAddressId(string businessId, string empID);
        IEnumerable<tblaccemp_ucodesemployees> GetAllUcodeEmployess();
        DataTable GetDatatableByQry(int i, string busId);
        DataTable FillshowhoursCmb(string strCustID, string txtEmpID, string strCompanyID);
        int GetEmpAddress(string EmpId);
    }
}
