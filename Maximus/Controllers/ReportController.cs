using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maximus.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {

        private readonly IReportService _reportService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDisplay _orderDisp;
        private readonly PointStyle _stylePoints;
        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            ReportService reportService = new ReportService(_unitOfWork);
            PointStyle stylePoints = new PointStyle(_unitOfWork);
            OrderDisplayService orderDisp = new OrderDisplayService(_unitOfWork);
            _reportService = reportService;
            _orderDisp = orderDisp;
            _stylePoints = stylePoints;
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
        public ActionResult GetRolloutReport(List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false)
        {
            ////string busId, List< string > selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool pointsREq = false)
            var result = _reportService.GetRolloutReport(Session["BuisnessId"].ToString(), selRollout, reportName, reportTypes, embro, uncnf, Convert.ToBoolean(Session["POINTSREQ"]));
            return View("", result);
        }

        [ValidateInput(false)]
        public ActionResult RolloutGridViewPartial(List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false, bool iscallback = false)
        {
            if (iscallback)
            {
                reportTypes = Session["reportTypes"].ToString();
                reportName = Session["reportName"].ToString();
                uncnf = Convert.ToBoolean(Session["uncnf"].ToString());
                embro = Convert.ToBoolean(Session["embro"].ToString());
                selRollout = (List<string>)Session["selRollout"];
                var model = _reportService.GetRolloutReport(Session["BuisnessId"].ToString(), selRollout, reportName, reportTypes, embro, uncnf, Convert.ToBoolean(Session["POINTSREQ"]));
                Session["includerollout"] = model.Any(s => s.RolloutName != "" && s.RolloutName != null) ? true : false;
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

        public ActionResult GetCardReports(string cardmenu = "")
        {
            Session["cardmenu"] = cardmenu;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult CardReportGridViewPartial()
        {
            var model = _reportService.GetCardReport(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), Session["Access"].ToString());
            return PartialView("_CardReportGridViewPartial", model);
        }
        [ValidateInput(false)]
        public ActionResult DetailCardPartial(string empId)
        {
            TempData["rptemployeeid"] = empId;
            var model = _reportService.GetdetailCard(empId, Session["BuisnessId"].ToString(), Session["cardmenu"].ToString(), Convert.ToBoolean(Session["POINTSREQ"]));
            return PartialView("_DetailCardPartial", model);
        }

        public ActionResult GetAllOrderRPT(string empId)
        {
            TempData["rptemployeeid"] = empId;
            var model = _reportService.GetAllOrderRPT(empId, Session["BuisnessId"].ToString(), Session["cardmenu"].ToString(), Convert.ToBoolean(Session["POINTSREQ"]));
            return PartialView("_ShowOrderGridViewRPTPartial", model);
        }


        public ActionResult OrderDetailGridView1Partial(int ordno)
        {
            var model = _orderDisp.GetOrderDetail(ordno);
            model.ForEach(s => s.Points = _stylePoints.Exists(a => a.StyleID == s.StyleID) ? _stylePoints.GetAll(a => a.StyleID == s.StyleID).First().Points.Value : 0);
            TempData["OrderNo"] = ordno;
            return PartialView("_OrderDetailGridView1Partial", model);
        }

        [ValidateInput(false)]
        public ActionResult StyleDetailGridViewPartial(string style, string empId)
        {

            var model = _reportService.GetOrderLinesBystyle(style, empId, Session["cardmenu"].ToString());
            return PartialView("_StyleDetailGridViewPartial", model);
        }
        public ActionResult CardExporter()
        {
            var sett = CardExportGridviewSettings();
            return GridViewExtension.ExportToXls(sett,_reportService.GetExporterData(Session["cardmenu"].ToString(), Session["Access"].ToString(), Session["UserName"].ToString()));
        }
        public GridViewSettings CardExportGridviewSettings()
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "CardGridExport";
            settings.KeyFieldName = "employeeid;styleid;colour;year";
            settings.Columns.Add("employeeid").Caption = "Employee id";
            settings.Columns.Add("employeename").Caption = "Employee Name";
            settings.Columns.Add("startdate").Caption = "Employee start date";
            settings.Columns.Add("enddate").Caption = "Employee end date";
            settings.Columns.Add("styleid").Caption = "Style";
            settings.Columns.Add("colour").Caption = "Color";
            settings.Columns.Add("year").Caption = "Year";
            if (Session["cardmenu"].ToString().ToLower().Trim() != "points")
            {
                settings.Columns.Add("soqty").Caption = "SO quantity";
                settings.Columns.Add("pickqty").Caption = "Pick quantity";
                settings.Columns.Add("invoiceqty").Caption = "Invoice quantity";
            }
            else
            {
                settings.Columns.Add("sopoints").Caption = "SO points";
                settings.Columns.Add("pickpoints").Caption = "Pick points";
                settings.Columns.Add("invoicepoints").Caption = "Invoice points";
            }
            settings.Columns.Add("total").Caption = "Total";
            settings.Columns.Add("firstissuedate").Caption = "First issue date";
            settings.Columns.Add("lastissuedate").Caption = "Last issue date";
            settings.Columns.Add("startissuedate").Caption = "Start issue date";

            return settings;
        }
       

    }
}