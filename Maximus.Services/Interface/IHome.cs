using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.Services.Interface
{
    public interface IHome
    {
        PointsModel GetPointsModel(string uCode, string busId);
     List<tblsop_customerorder_template_costcentre> GetCostCenterTemplate(List<string>templateLst, string busId);
        List<tblsop_customerorder_template_costcentre> GetCostCenterUcode(List<string> ucodeLst, string busId);
        List<tblfsk_style_groups> GetAllGroups(List<UcodeModel> UcodeStyle = null, List<string> SelectedTemplate = null);
        decimal GetPrice(string StyleID = "", string SizeId = "", string busId = "",string priceId="");
        decimal GetBulkPrice(int qty, string style = "", string size = "", string busId = "");
        List<string> GetAllcolours(string style);
        bool SaveEmailData(string email, string userName, string busId);
        List<AssemblyModel> GetAssemblyInfo(string styleId, string appPath, string custId);
        List<SalesOrderLineViewModel> GetChargableAssembly(string intNoOfday, string IncWendsDel, string mainStyle, string CurrencyExchangeRate, string Currency_Name, string Rep_Id, string style = "", long lineNo = 0, long qty = 0, string empId = "", string empName = "", string busId = "", string selTemplates = "", string selUcode = "");
 List<SalesOrderLineViewModel> GetOptionalAssembly(string intNoOfday, string mainStyle, string IncWendsDel, string CurrencyExchangeRate, string Currency_Name, string Rep_Id, List<string> assemList = null, string style = "", long lineNo = 0, List<SalesOrderLineViewModel> lines = null, long qty = 0, string empId = "", string empName = "", int lastLino = 0, string busId = "", string selTemplates = "", string selUcode = "");
    }
}
