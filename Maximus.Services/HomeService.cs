using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maximus.Data.models;
using Maximus.Data.Models;
using Maximus.Services.Interface;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;

namespace Maximus.Services
{
    public class HomeService : IHome
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
        public readonly DataProcessing _dp;
        public readonly CUstomerOrderTemplateCostcenters _costcenters;
        public readonly PointsByUcode _pointsByUcode;
        public readonly PointsCard _pointsCard;
        public readonly PointStyle _pointStyle; 
        #endregion

        #region constructor
        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CUstomerOrderTemplateCostcenters costcenters = new CUstomerOrderTemplateCostcenters(_unitOfWork);
            AllAssemblies allAssemblies = new AllAssemblies(_unitOfWork);
            AssemblyDetail assemblyDetail = new AssemblyDetail(_unitOfWork);
            AssemblyHeader assemblyHeader = new AssemblyHeader(_unitOfWork);
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
            PointsByUcode pointsByUcode = new PointsByUcode(_unitOfWork);
            PointsCard pointsCard = new PointsCard(_unitOfWork);
            PointStyle pointStyle = new PointStyle(_unitOfWork);
            _dp = dp;
            _pointsByUcode = pointsByUcode;
            _pointsCard = pointsCard;
            _pointStyle = pointStyle;
            _costcenters = costcenters;
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
        }

        #endregion 

        #region GetAllcolours
        public List<string> GetAllcolours(string style)
        {
            List<string> selectedListqqq = new List<string>();
            selectedListqqq = _stylesView.GetAll(x => x.StyleID == style).Select(x => x.ColourID).Distinct().ToList();
            return (selectedListqqq);
        }
        #endregion

        #region GetPrice based on styleid and colorid
        public decimal GetPrice(string StyleID = "", string SizeId = "", string BusiD = "")
        {
            return _dp.GetPrice(StyleID, SizeId, BusiD);
        }

        public decimal GetBulkPrice(int qty, string style = "", string size = "", string busId = "")
        {
            return _dp.GetBulkPrice1(qty, style, size, busId);
        }

        #endregion

        #region GetAllGroups
        public List<tblfsk_style_groups> GetAllGroups(List<UcodeModel> UcodeStyle = null, List<string> SelectedTemplate = null)
        {
            try
            {
                if (UcodeStyle != null)
                {

                    List<string> UcodeStyle1 = new List<string>();
                    UcodeStyle1 = UcodeStyle.Select(x => x.StyleId).ToList();
                    var groups = _tblFskStyle.GetAll(x => UcodeStyle1.Contains(x.StyleID)).Select(x => x.Product_Group.Value).ToList();
                    var result = _styleGroups.GetAll(x => x.Description != "" && groups.Contains(x.GroupID)).ToList();
                    return result;
                }
                else if (SelectedTemplate.Count > 0)
                {
                    var result1 = SelectedTemplate;
                    var model = new List<int>();
                    foreach (var item in result1)
                    {
                        model.AddRange(_dp.GetProductGroup(item));
                    }
                    var result = _styleGroups.GetAll(x => x.Description != "" && model.Contains(x.GroupID)).ToList();
                    return result;
                }
                else
                {
                    var result = _styleGroups.GetAll(x => x.Description != "").ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

        #region GetAssemblyInfo
        public List<AssemblyModel> GetAssemblyInfo(string styleId, string appPath, string custId)
        {

            try
            {

                var result = _customAssembly.Exists(x => x.ParentStyleID == styleId & x.CustID == custId) ? _customAssembly.GetAll(x => x.ParentStyleID == styleId & x.CustID == custId).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable ? 1 : 0, SeqNo = x.seqno.Value }).OrderBy(x => x.SeqNo).ToList() : _customAssembly.GetAll(x => x.ParentStyleID == styleId & x.isChargeable == false).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = x.isChargeable ? 1 : 0, SeqNo = x.seqno.Value }).OrderBy(x => x.SeqNo).ToList();
                foreach (var data in result)
                {
                    data.StyleImage = _tblFskStyle.GetAll(d => d.StyleID == data.StyleID).FirstOrDefault().StyleImage;
                    if (System.IO.File.Exists(appPath + data.StyleImage) != true)
                    {
                        data.StyleImage = "~/StyleImages/notfound.png";
                    }
                    else
                    {
                        data.StyleImage = "~/" + data.StyleImage;
                    }
                }
                return result;
            }
            catch (Exception e)
            {

            }
            return null;
        }
        #endregion
        public List<SalesOrderLineViewModel> GetChargableAssembly(string intNoOfday, string IncWendsDel, string CurrencyExchangeRate, string Currency_Name, string Rep_Id, string style = "", long lineNo = 0, long qty = 0, string empId = "", string empName = "", string busId = "",string selTemplates="",string selUcode="")
        {
            var chargableAsm = new List<SalesOrderLineViewModel>();
            var result = new List<AssemblyModel>();
            var result1 = new List<AssemblyModel>();
            result = _customAssembly.GetAll(x => x.ParentStyleID == style & x.isChargeable == true & x.CustID == busId).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = Convert.ToInt32(x.isChargeable) }).ToList();
            result1 = _customAssembly.Exists(x => x.ParentStyleID == style & x.isChargeable == true & x.CustID.ToLower()=="all") ? _customAssembly.GetAll(x => x.ParentStyleID == style & x.isChargeable == false & x.CustID.ToLower() == "all").Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = Convert.ToInt32(x.isChargeable) }).ToList() : new List<AssemblyModel>();
            result.AddRange(result1);
            if (result.Count == 0)
            {
                result = _allAssemblies.GetAll(x => x.ParentStyleID == style & x.isChargeable == true).Select(x => new AssemblyModel { StyleID = x.StyleID, Instruction = x.Instruction, IsChargeable = Convert.ToInt32(x.isChargeable) }).ToList();
            }
            long curLine = lineNo;
            foreach (var res in result)
            {
                var size = _style_Sizes.Exists(x => x.StyleID == res.StyleID) ? _style_Sizes.GetAll(x => x.StyleID == res.StyleID).FirstOrDefault().SizeID : "";
                var color = _style_Colour.Exists(x => x.StyleID == res.StyleID) ? _style_Colour.GetAll(x => x.StyleID == res.StyleID).FirstOrDefault().ColourID : "";
                chargableAsm.Add(new SalesOrderLineViewModel
                {
                    ColourID = _style_Colour.Exists(x => x.StyleID == res.StyleID) ? _style_Colour.GetAll(x => x.StyleID == res.StyleID).FirstOrDefault().ColourID : "",
                    OriginalLineNo = lineNo,
                    LineNo = curLine + 1,
                    Description = res.Instruction,
                    OrdQty = _dp.Getqty(busId, style, res.StyleID, qty) * qty,
                    Price = Convert.ToDouble(_dp.GetPrice(res.StyleID, size, busId)),
                    SizeID = _style_Sizes.Exists(x => x.StyleID == res.StyleID) ? _style_Sizes.GetAll(x => x.StyleID == res.StyleID).FirstOrDefault().SizeID : "",
                    StyleID = res.StyleID,
                    EmployeeId = empId,
                    EmployeeName = empName,
                    Assembly = true,
                    Ischargable = true,
                    StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(res.StyleID)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(res.StyleID)).FirstOrDefault().StyleImage : "~/StyleImages/notfound.png",
                    DeliveryDate = _dp.GetDeliveryDate(Convert.ToInt32(intNoOfday) - 1, Convert.ToBoolean(IncWendsDel)),
                    VatCode1 = _dp.GetVatCode(),
                    RepId = Convert.ToInt32(Rep_Id),
                    Currency_Exchange_Rate = Convert.ToDouble(CurrencyExchangeRate),
                    Cost1 = _dp.GetCostPrice(res.StyleID, size, color, Currency_Name, 1, 0),
                    IssueUOM1 = 1,
                    StockingUOM1 = 1,
                    IssueQty1 = Convert.ToInt32(qty),
                    VatPercent = _dp.GetVatPercent(res.StyleID, size),
                    SelectedTemplate=selTemplates,
                    SelectedUcode=selUcode
                });
                curLine = curLine + 1;
            }
            return chargableAsm;
        }

        public List<SalesOrderLineViewModel> GetOptionalAssembly(string intNoOfday, string IncWendsDel, string CurrencyExchangeRate, string Currency_Name, string Rep_Id, List<string> assemList = null, string style = "", long lineNo = 0, List<SalesOrderLineViewModel> lines = null, long qty = 0, string empId = "", string empName = "", int lastLino = 0, string busId = "", string selTemplates = "", string selUcode = "")
        {
            var optionalAsm = new List<SalesOrderLineViewModel>();
            long curLine = lines != null ? lines.Last().LineNo : lineNo;
            try
            {
                foreach (var res in assemList)
                {
                    var size = _style_Sizes.Exists(x => x.StyleID == res) ? _style_Sizes.GetAll(x => x.StyleID == res).FirstOrDefault().SizeID : "";
                    var color = _style_Colour.Exists(x => x.StyleID == res) ? _style_Colour.GetAll(x => x.StyleID == res).FirstOrDefault().ColourID : "";
                    optionalAsm.Add(new SalesOrderLineViewModel
                    {
                        ColourID = _style_Colour.Exists(x => x.StyleID == res) ? _style_Colour.GetAll(x => x.StyleID == res).FirstOrDefault().ColourID : "",
                        OriginalLineNo = lineNo,
                        LineNo = curLine + 1,
                        Description = _customAssembly.Exists(x => x.ParentStyleID == style && x.StyleID == res) ? _customAssembly.GetAll(x => x.ParentStyleID == style && x.StyleID == res).FirstOrDefault().Instruction == "" |
                         _customAssembly.GetAll(x => x.ParentStyleID == style && x.StyleID == res).FirstOrDefault().Instruction == null ? "" : _customAssembly.GetAll(x => x.ParentStyleID == style && x.StyleID == res).FirstOrDefault().Instruction : "",
                        OrdQty = _dp.Getqty(busId, style, res, qty) * qty,
                        Price = Convert.ToDouble(_dp.GetPrice(res, size, busId)),
                        SizeID = _style_Sizes.Exists(x => x.StyleID == res) ? _style_Sizes.GetAll(x => x.StyleID == res).FirstOrDefault().SizeID : "",
                        StyleID = res,
                        EmployeeId = empId,
                        EmployeeName = empName,
                        Assembly = true,
                        Ischargable = false,
                        StyleImage = _tblFskStyle.Exists(x => x.StyleID.Contains(res)) ? _tblFskStyle.GetAll(x => x.StyleID.Contains(res)).FirstOrDefault().StyleImage : "~/StyleImages/notfound.png",
                        DeliveryDate = _dp.GetDeliveryDate(Convert.ToInt32(intNoOfday) - 1, Convert.ToBoolean(IncWendsDel)),
                        VatCode1 = _dp.GetVatCode(),
                        RepId = Convert.ToInt32(Rep_Id),
                        Currency_Exchange_Rate = Convert.ToDouble(CurrencyExchangeRate),
                        Cost1 = _dp.GetCostPrice(res, size, color, Currency_Name, 1, 0),
                        IssueUOM1 = 1,
                        StockingUOM1 = 1,
                        IssueQty1 = Convert.ToInt32(qty),
                        VatPercent = _dp.GetVatPercent(res, size),
                        SelectedTemplate = selTemplates,
                        SelectedUcode = selUcode
                    });
                    curLine = curLine + 1;
                }

            }
            catch (Exception E)
            {

            }
            return optionalAsm;
        }

        public List<tblsop_customerorder_template_costcentre> GetCostCenterTemplate(List<string>  template, string busId)
        {
            List<tblsop_customerorder_template_costcentre> result = new List<tblsop_customerorder_template_costcentre>();
            List<tblsop_customerorder_template_costcentre> cst = new List<tblsop_customerorder_template_costcentre>();
            foreach (var temp in template)
            {
                cst = _costcenters.Exists(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.TemplateCode.ToLower().Trim()== temp.ToLower().Trim()) ? _costcenters.GetAll(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.TemplateCode.ToLower().Trim() == temp.ToLower().Trim()).ToList() : cst;
                result.AddRange(cst);
            }
            return cst;
        }
        public List<tblsop_customerorder_template_costcentre> GetCostCenterUcode(List<string> ucodeLst, string busId)
        {
            List<tblsop_customerorder_template_costcentre> result = new List<tblsop_customerorder_template_costcentre>();
            List<tblsop_customerorder_template_costcentre> cst = new List<tblsop_customerorder_template_costcentre>();
            foreach (var ucode in ucodeLst)
            {
                cst = _costcenters.Exists(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim() && x.Uniformcode.ToLower().Trim() == ucode.ToLower().Trim()) ? _costcenters.GetAll(x => x.BusinessID.ToLower().Trim() ==busId && x.Uniformcode.ToLower().Trim() == ucode.ToLower().Trim()).ToList() : cst;
                result.AddRange(cst);
            }
            return cst;
        }

        public PointsModel GetPointsModel(string uCode ,string busId)
        {
            PointsModel ptsModel = new PointsModel();
            var result = _pointsByUcode.GetAll(x => x.BusinessID == busId && x.UcodeID == uCode).FirstOrDefault();
            if (result != null)
            {
                ptsModel.BusinessID = result.BusinessID;
                ptsModel.CompanyID = result.CompanyID;
                ptsModel.UcodeID = result.UcodeID;
                ptsModel.TotalPoints = result.TotalPoints.Value;
                ptsModel.FromDate = result.FromDate;
                ptsModel.ToDate = result.ToDate;
                ptsModel.LstStyles = _pointStyle.GetAll(x => x.UcodeID == uCode && x.BusinessID == busId).Select(x => new PointsStyle { Points = x.Points.Value, Style = x.StyleID }).ToList();
            }
            
            return ptsModel;
        }
    }
}
