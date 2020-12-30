using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maximus.Controllers
{
    public class ReportController : Controller
    {

        private readonly IReportService _reportService;
        private readonly IUnitOfWork _unitOfWork;


        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ReportService reportService = new ReportService(_unitOfWork);
            _reportService = reportService;
        }
        public ActionResult Index()
        {
            Session["reportTypes"] = "NAN";
            Session["reportName"] = ""; 
            Session["uncnf"] = false;
            Session["embro"] = false;
            Session["selRollout"] = new List<string>();
            Session["includerollout"] = false;
            return View();
        }
        public ActionResult GetFilter()
        {
            ViewBag.Rolloutnames = _reportService.GetAllRollouts(Session["BuisnessId"].ToString());
            return PartialView("_rolloutReport");
        }
        public ActionResult GetRolloutReport(List<string> selRollout=null, string reportName="",string reportTypes="", bool embro=false,bool uncnf=false)
        {
            ////string busId, List< string > selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool pointsREq = false)
            var result= _reportService.GetRolloutReport(Session["BuisnessId"].ToString(),selRollout,reportName, reportTypes, embro, uncnf, Convert.ToBoolean(Session["POINTSREQ"]));
            return View("", result);
        }

        [ValidateInput(false)]
        public ActionResult RolloutGridViewPartial(List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false,bool iscallback= false)
        {
            if (iscallback)
            {
                reportTypes = Session["reportTypes"].ToString();
                reportName=Session["reportName"].ToString();
                uncnf= Convert.ToBoolean(Session["uncnf"].ToString());
                 embro = Convert.ToBoolean(Session["embro"].ToString());
                selRollout = (List<string>)Session["selRollout"];
                var model = _reportService.GetRolloutReport(Session["BuisnessId"].ToString(), selRollout, reportName, reportTypes, embro, uncnf, Convert.ToBoolean(Session["POINTSREQ"]));
             Session["includerollout"]=   model.Any(s => s.RolloutName != "" && s.RolloutName != null) ? true : false;
                Session["RolloutReport"] = model;
                return PartialView("_RolloutGridViewPartial", model);
            }
            else
            {
                if (reportName != "" && selRollout != null)
                {
                    Session["reportTypes"] = reportTypes;
                    Session["reportName"] = reportName;
                    Session["uncnf"] = uncnf;
                    Session["embro"] = embro;
                    Session["selRollout"] = selRollout;
                    var model = _reportService.GetRolloutReport(Session["BuisnessId"].ToString(), selRollout, reportName, reportTypes, embro, uncnf, Convert.ToBoolean(Session["POINTSREQ"]));
                    Session["includerollout"] = model.Any(s => s.RolloutName != "" && s.RolloutName != null) ? true : false;
                    Session["RolloutReport"] = model;
                    return PartialView("_RolloutGridViewPartial", model);
                }
                else
                {
                    Session["reportTypes"] = "NAN";
                    Session["RolloutReport"] = new List<RolloutReportModel>();
                    Session["includerollout"] = false;
                    return PartialView("_RolloutGridViewPartial");
                }
            }
            
        }

        public ActionResult exporter()
        {
            var sett = CreateExportGridViewSettings();
            return GridViewExtension.ExportToXls(sett, ((List<RolloutReportModel>)Session["RolloutReport"]));
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
        public GridViewSettings CreateExportGridViewSettings()
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "RolloutGridView";
            settings.KeyFieldName = "Custref";


            if (Session["reportTypes"].ToString().ToLower() != "nan")
            {
                if (Session["reportName"].ToString() != "2")
                {
                    if (Session["reportTypes"].ToString() == "1")
                    {
                        if (Convert.ToBoolean(Session["includerollout"]))
                        {
                            settings.Columns.Add("RolloutName").Caption = "Rollout";
                        }
                        settings.Columns.Add("Styleid").Caption = "Style";
                        settings.Columns.Add("Description").Caption = "Description";
                        settings.Columns.Add("BaseStyle").Caption = "Base Style";
                        settings.Columns.Add("BaseStyleDesc").Caption = "Base Style Description";
                        settings.Columns.Add("Color").Caption = "Color";
                        settings.Columns.Add("Size").Caption = "Size";
                        settings.Columns.Add("Freetext").Caption = "Freetext";
                        settings.Columns.Add("TotQty").Caption = "Total Qty";
                        //settings.Columns.Add("TotPts").Caption="Style";
                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }
                    else
                if (Session["reportTypes"].ToString() == "2")
                    {
                        if (Convert.ToBoolean(Session["includerollout"]))
                        {
                            settings.Columns.Add("RolloutName").Caption = "Rollout";
                        }
                        settings.Columns.Add("Styleid").Caption = "Style";
                        settings.Columns.Add("Description");
                        settings.Columns.Add("BaseStyle").Caption = "Base Style";
                        settings.Columns.Add("BaseStyleDesc").Caption = "Base Style Description";
                        settings.Columns.Add("Color").Caption = "Color";
                        settings.Columns.Add("Size").Caption = "Size";

                        settings.Columns.Add("TotQty").Caption = "Total Qty";
                        //settings.Columns.Add("TotPts");
                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }
                    else
                if (Session["reportTypes"].ToString() == "3")
                    {
                        if (Convert.ToBoolean(Session["includerollout"]))
                        {
                            settings.Columns.Add("RolloutName").Caption = "Rollout";
                        }
                        settings.Columns.Add("Custref").Caption = "Customerref";
                        settings.Columns.Add("Styleid").Caption = "Style";
                        settings.Columns.Add("Description").Caption = "Description";
                        settings.Columns.Add("BaseStyle").Caption = "Base Style";
                        settings.Columns.Add("BaseStyleDesc").Caption = "Base Style Description";
                        settings.Columns.Add("Color").Caption = "Color";
                        settings.Columns.Add("Size").Caption = "Size";

                        settings.Columns.Add("TotQty").Caption = "Total Qty";
                        //settings.Columns.Add("TotPts");
                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }
                    else
                if (Session["reportTypes"].ToString() == "4")
                    {
                        if (Convert.ToBoolean(Session["includerollout"]))
                        {
                            settings.Columns.Add("RolloutName").Caption = "Rollout";
                        }
                        settings.Columns.Add("OrderNo").Caption = "Order No";
                        settings.Columns.Add("OrderDate").Caption = "Order date";
                        settings.Columns.Add("Employeeid").Caption = "Employee Id";
                        settings.Columns.Add("EmployeeName").Caption = "Employee Name";


                        settings.Columns.Add("Custref").Caption = "Customer ref";
                        settings.Columns.Add("Styleid").Caption = "Style";
                        settings.Columns.Add("Description");
                        settings.Columns.Add("BaseStyle").Caption = "Base Style";
                        settings.Columns.Add("BaseStyleDesc").Caption = "Base Style Description";
                        settings.Columns.Add("Color");
                        settings.Columns.Add("Size");
                        settings.Columns.Add("Freetext");
                        settings.Columns.Add("TotQty").Caption = "Total Qty";
                        // settings.Columns.Add("TotPts");
                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }
                    else
                if (Session["reportTypes"].ToString() == "5")
                    {
                        if (Convert.ToBoolean(Session["includerollout"]))
                        {
                            settings.Columns.Add("RolloutName").Caption = "Rollout";
                        }
                        settings.Columns.Add("Employeeid").Caption = "Employee Id";
                        settings.Columns.Add("EmployeeName").Caption = "Employee Name";

                        settings.Columns.Add("Custref").Caption = "Customer ref";

                        settings.Columns.Add("TotQty").Caption = "Total Qty";

                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("TotPts").Caption = "Total Points";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }
                    else
                if (Session["reportTypes"].ToString() == "0")
                    {
                        if (Convert.ToBoolean(Session["includerollout"]))
                        {
                            settings.Columns.Add("RolloutName").Caption = "Rollout";
                        }

                        settings.Columns.Add("Custref").Caption = "Customer Ref";
                        settings.Columns.Add("Styleid").Caption = "Style";
                        settings.Columns.Add("Description").Caption = "Description";
                        settings.Columns.Add("BaseStyle").Caption = "Base Style";
                        settings.Columns.Add("BaseStyleDesc").Caption = "Base Style Description";
                        settings.Columns.Add("Color").Caption = "Color";

                        settings.Columns.Add("Size").Caption = "Size";
                        settings.Columns.Add("Freetext").Caption = "Freetext";
                        settings.Columns.Add("TotQty").Caption = "Total Qty";
                        //settings.Columns.Add("TotPts");
                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }
                    else
                    {

                        settings.Columns.Add("Custref").Caption = "Customer ref";
                        settings.Columns.Add("Styleid").Caption = "Style";
                        settings.Columns.Add("Description").Caption = "Description";
                        settings.Columns.Add("BaseStyle").Caption = "Base Style";
                        settings.Columns.Add("BaseStyleDesc").Caption = "Base Style Description";
                        settings.Columns.Add("Color").Caption = "Color";
                        settings.Columns.Add("Size").Caption = "Size";
                        settings.Columns.Add("Freetext").Caption = "Freetext";
                        settings.Columns.Add("TotQty").Caption = "Total Qty";
                        //settings.Columns.Add("TotPts");
                        settings.Columns.Add("TotValue").Caption = "Total Value";
                        settings.Columns.Add("OrdPoints").Caption = "Order Points";
                    }

                }
                else if (Session["reportName"].ToString() != "1")
                {
                    settings.Columns.Add("Employeeid").Caption = "Employee id";
                    settings.Columns.Add("EmployeeName").Caption = "Employee Name";

                    settings.Columns.Add("RolloutName").Caption = "Rollout";
                    settings.Columns.Add("IsActive").Caption = "Active";
                    settings.Columns.Add("TotPts").Caption = "Total Points";
                    settings.Columns.Add("UsedPoints").Caption = "Used Points";
                    settings.Columns.Add("OnlineUserId").Caption = "Online User Id";
                    settings.Columns.Add("Access").Caption = "Access";
                }
            }

            return settings;
        }
    }
}