using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using Maximus.Data.models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Services;
using Maximus.Services.Interface;
using System.Configuration;
using Maximus.Data.Models;

namespace Maximus.Controllers
{
    public class OrderDisplayController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDisplay _orderDisp;
        public readonly PointStyle _pointStyle;
        private readonly DataConnectionService _dataConnection;
        private readonly Employee _employee;
        private readonly TblFskStyle _fskStyl;
        private readonly PointStyle _stylePoints;
        public readonly ViewPointsCard _pointscard;
        public readonly tblSalesOrderHeader _salesHead;
        private readonly IBasket _basket;
        public readonly SalesDetail _salesLine;
        public readonly PickingSlipHeader _pickingHead;
        public readonly tblCourierinformation _courierInfo;
        public readonly PickingSlipDetail _pickingdetail;

        private readonly DataProcessing _dp;
        public OrderDisplayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DataProcessing dp = new DataProcessing(_unitOfWork);
            OrderDisplayService orderDisp = new OrderDisplayService(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            TblFskStyle fskStyl = new TblFskStyle(_unitOfWork);
            PointStyle stylePoints = new PointStyle(_unitOfWork);
            ViewPointsCard pointsCard = new ViewPointsCard(_unitOfWork);
            tblSalesOrderHeader salesHead = new tblSalesOrderHeader(_unitOfWork);
            SalesDetail salesLine = new SalesDetail(_unitOfWork);
            BasketService basket = new BasketService(_unitOfWork);
            PointStyle pointStyle = new PointStyle(_unitOfWork);
            PickingSlipHeader pickingHead = new PickingSlipHeader(_unitOfWork);
            PickingSlipDetail pickingdetail = new PickingSlipDetail(_unitOfWork);
            tblCourierinformation courierInfo = new tblCourierinformation(_unitOfWork);
            _pickingHead = pickingHead;
            _pickingdetail = pickingdetail;
            _courierInfo = courierInfo;
            _dataConnection = dataConnection;
            _salesHead = salesHead;
            _salesLine = salesLine;
            _pointscard = pointsCard;
            _orderDisp = orderDisp;
            _employee = employee;
            _fskStyl = fskStyl;
            _pointStyle = pointStyle;
            _dp = dp;
            _basket = basket;
            _stylePoints = stylePoints;
        }
        public ActionResult ShowOrders(string OrderType = "SO", bool EmergencyTicked = false)
        {
            Session["rtnLines"] = new List<ReturnOrderModel>();
            Session["returnModellst"] = new List<ReturnOrderModel>();
            Session["ReturnOrderHeader"] = new List<SalesOrderHeaderViewModel>();
            Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
            Session["ConfirmOrders"] = false;
            Session["qty"] = 0;
            Session["EmergencyTicked"] = EmergencyTicked;
            Session["requireemergencyreason"] = false;
            Session["isrtntype"] = "";
            Session["IsManPack"] = true;
            Session["returnorder"] = false;
            Session["PRIVATEORDER"] = false;
            TempData["OrderType"] = OrderType;
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId);
            //commented by sasi(17-12-20)
            //var usr = _dp.GetEmployee(busId, Session["UserName"].ToString(), Session["OrderPermit"].ToString(),"","","","","","","","", Session["RequirePermissionUSR"].ToString()).Select(s => s.EmployeeId).ToList();
            //usr.Add(userId);
            var usr = new List<string>();
            Session["userLst"] = usr;
            return View("ShowOrder");
        }
        public ActionResult EmpFiltersOrders()
        {
            return PartialView("_EmployeeSearchShowOrders");
        }
        public ActionResult SearchOrders()
        {
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            ///commented  by sasi(15-12-20)  we can do user search on the grid itself so we dont need this
            ////var model = _orderDisp.GetAllOrders(Session["OT"].ToString(), busId, Convert.ToBoolean(Session["POINTSREQ"].ToString()), userId, (List<string>)Session["userLst"], Session["Access"].ToString(), Session["OrderPermit"].ToString());
            //Session["usrModel"] = model.Select(s => s.EmpID).Distinct().ToList();
            return PartialView("_SearchOrderShowOrders");
        }

        [ValidateInput(false)]
        ///commented  by sasi(15-12-20) removed the int emergency = -1
        //public ActionResult ShowOrderGridViewPartial(string OrderType = "SO", int emergency = -1, int frmOrderno = 0, int toOrderNo = 0, Nullable<DateTime> frmOrderdate = null, Nullable<DateTime> toOrderDate = null, string custRef = "", string ordStatus = "", string users = "", int recsToDisplay = 0, bool like = false, bool exact = false, string Empid = "", string Empname = "", Nullable<DateTime> StrtDate = null, bool iscallback = false)
        public ActionResult ShowOrderGridViewPartial(string OrderType = "SO", int frmOrderno = 0, int toOrderNo = 0, Nullable<DateTime> frmOrderdate = null, Nullable<DateTime> toOrderDate = null, string custRef = "", string ordStatus = "", string users = "", int recsToDisplay = 0, bool like = false, bool exact = false, string Empid = "", string Empname = "", Nullable<DateTime> StrtDate = null, bool iscallback = false)
        {
            bool emergenVal = false;

            if (iscallback == true)
            {
                custRef = ((OrdersFilterModel)Session["orderfiltermodel"]).custRef;
                frmOrderno = ((OrdersFilterModel)Session["orderfiltermodel"]).frmOrderno;
                frmOrderdate = ((OrdersFilterModel)Session["orderfiltermodel"]).frmOrderdate;
                toOrderNo = ((OrdersFilterModel)Session["orderfiltermodel"]).toOrderNo;
                toOrderDate = ((OrdersFilterModel)Session["orderfiltermodel"]).toOrderDate;
                users = ((OrdersFilterModel)Session["orderfiltermodel"]).users;
                Empid = ((OrdersFilterModel)Session["orderfiltermodel"]).Empid;
                Empname = ((OrdersFilterModel)Session["orderfiltermodel"]).Empname;
                ordStatus = ((OrdersFilterModel)Session["orderfiltermodel"]).ordStatus;
            }
            else
            {
                ((OrdersFilterModel)Session["orderfiltermodel"]).custRef = custRef;
                ((OrdersFilterModel)Session["orderfiltermodel"]).frmOrderno = frmOrderno;
                ((OrdersFilterModel)Session["orderfiltermodel"]).frmOrderdate = frmOrderdate;
                ((OrdersFilterModel)Session["orderfiltermodel"]).toOrderNo = toOrderNo;
                ((OrdersFilterModel)Session["orderfiltermodel"]).toOrderDate = toOrderDate;
                ((OrdersFilterModel)Session["orderfiltermodel"]).users = users;
                ((OrdersFilterModel)Session["orderfiltermodel"]).Empid = Empid;
                ((OrdersFilterModel)Session["orderfiltermodel"]).Empname = Empname;
                ((OrdersFilterModel)Session["orderfiltermodel"]).ordStatus = ordStatus;
                Session["OT"] = OrderType;

            }
            if (OrderType.ToLower() == "rt")
            {
                Session["returnorder"] = true;
            }
            else
            {
                Session["returnorder"] = false;
            }
            List<string> employees = new List<string>();
            List<OrderDisplayModel> model = new List<OrderDisplayModel>();
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();

            if (Convert.ToBoolean(Session["ConfirmOrders"]))
            {
                model = _orderDisp.GetAllOrders(Session["OT"].ToString(), busId, Convert.ToBoolean(Session["POINTSREQ"].ToString()), userId, (List<string>)Session["userLst"], Session["Access"].ToString(), Session["OrderPermit"].ToString(), Convert.ToBoolean(Session["EmergencyTicked"]), true, false, Session["RequirePermissionUSR"].ToString());
            }
            else
            {
                model = _orderDisp.GetAllOrders(Session["OT"].ToString(), busId, Convert.ToBoolean(Session["POINTSREQ"].ToString()), userId, (List<string>)Session["userLst"], Session["Access"].ToString(), Session["OrderPermit"].ToString(), Convert.ToBoolean(Session["EmergencyTicked"]), false, false, Session["RequirePermissionUSR"].ToString());
            }
            if (StrtDate != null)
            {
                employees = _employee.Exists(s => s.StartDate == StrtDate && s.BusinessID == busId) ? _employee.GetAll(s => s.StartDate == StrtDate && s.BusinessID == busId).Select(s => s.EmployeeID).ToList() : new List<string>();

                if (employees.Count > 0)
                {
                    model = model.Where(s => employees.Contains(s.EmpID)).ToList();
                }
                else
                {
                    model = new List<OrderDisplayModel>();
                }
            }
            if (Empid != "")
            {
                model = model.Where(s => s.EmpID.ToLower() == Empid.ToLower()).ToList();
            }
            if (Empname != "")
            {
                model = model.Where(s => s.EmpName.ToLower().Contains(Empname.ToLower())).ToList();
            }

            if (frmOrderno > 0 | toOrderNo > 0)
            {
                if (frmOrderno > 0 & toOrderNo > 0)
                {
                    model = model.Where(s => s.OrderNo >= frmOrderno && s.OrderNo <= toOrderNo).ToList();
                }
                else
                {
                    if (frmOrderno > 0)
                    {
                        model = model.Where(s => s.OrderNo >= frmOrderno).ToList();
                    }
                    if (toOrderNo > 0)
                    {
                        model = model.Where(s => s.OrderNo <= toOrderNo).ToList();
                    }
                }
            }
            if (frmOrderdate != null | toOrderDate != null)
            {
                if (frmOrderdate != null & toOrderDate != null)
                {
                    model = model.Where(s => s.OrderDate.Date >= frmOrderdate.Value.Date && s.OrderDate.Date <= toOrderDate.Value.Date).ToList();
                }
                else
                {
                    if (frmOrderdate != null)
                    {
                        model = model.Where(s => s.OrderDate.Date >= frmOrderdate.Value.Date).ToList();
                    }
                    if (toOrderDate != null)
                    {
                        model = model.Where(s => s.OrderDate.Date <= toOrderDate.Value.Date).ToList();
                    }
                }
            }
            //else
            //{
            //    DateTime startDate = DateTime.Now.AddMonths(-3);
            //    DateTime endDate = DateTime.Now;
            //    model = model.Where(s => s.OrderDate >= startDate && s.OrderDate <= endDate).ToList();
            //}
            if (custRef != "" && like)
            {
                model = model.Where(s => s.CustomerRef.Contains(custRef)).ToList();
            }
            else if (custRef != "" && exact)
            {
                model = model.Where(s => s.CustomerRef == custRef).ToList();
            }
            if (ordStatus != "")
            {
                if (ordStatus.ToLower().Contains("unconf"))
                {
                    model = model.Where(s => s.IsConfirmed.ToUpper() == "NO").ToList();
                }
                else if (ordStatus.ToLower().Contains("conf"))
                {
                    model = model.Where(s => s.IsConfirmed.ToUpper() == "YES").ToList();
                }
            }
            if (users != "")
            {
                model = model.Where(s => s.UserId == users).ToList();
            }
            if (recsToDisplay > 0)
            {
                model = model.Take(recsToDisplay).ToList();
            }
            if (Convert.ToBoolean(Session["ConfirmOrders"]))
            {
                model = model.Where(s => s.IsConfirmed.ToUpper() == "NO").ToList();
            }


            Session["SelectedSalesOrders"] = model;
            return PartialView("_ShowOrderGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Maximus.Data.models.OrderDisplayModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Maximus.Data.models.OrderDisplayModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int64 OrderNo)
        {
            var model = new object[0];
            if (OrderNo >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model);
        }

        public string SetEmployee(string empId)
        {
            string busId = Session["BuisnessId"].ToString();
            Session["POINTSREQ"] = _dp.BusinessParam("POINTSREQ", busId);
            if (empId != "")
            {
                Session["SelectedEmp"] = empId;

                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                return "success";
            }
            return "Employee Missing";
        }
        public ActionResult GetOrderDetail(int ordno)
        {
            ViewBag.orderNo = ordno;
            return PartialView("_OrderDetail");
        }

        [ValidateInput(false)]
        public ActionResult OrderDetailGridViewPartial(int ordno)
        {
            var model = ((List<OrderDisplayModel>)Session["SelectedSalesOrders"]).Where(s => s.OrderNo == ordno).ToList();
            return PartialView("_OrderDetailGridViewPartial", model);
        }



        public ActionResult OrderDetailGridView1Partial(int ordno)
        {
            var model = _orderDisp.GetOrderDetail(ordno);
            TempData["OrderNo"] = ordno;

            foreach (var lines in model)
            {
                if (_pickingHead.Exists(s => s.OrderNo == ordno))
                {
                    var sss = _pickingHead.GetAll(s => s.OrderNo == ordno).Select(s => s.PickingSlipNo).ToList();

                    if (_pickingdetail.Exists(s => sss.Contains(s.PickingSlipNo) && s.StyleID == lines.StyleID && s.SizeID == lines.SizeID))
                    {
                        foreach (var data1 in _pickingdetail.GetAll(s => sss.Contains(s.PickingSlipNo) && s.StyleID == lines.StyleID && s.SizeID == lines.SizeID).ToList())
                        {
                            if (_courierInfo.Exists(s => s.DeliveryNote == data1.PickingSlipNo))
                            {
                                lines.CourierRef = _courierInfo.GetAll(s => s.DeliveryNote == data1.PickingSlipNo).First().CourierRef;
                            }
                        }
                    }
                }
                lines.ReOrderNo = _salesLine.Exists(s => s.ReturnOrderNo == ordno) ? Convert.ToInt32(_salesLine.GetAll(s => s.ReturnOrderNo == ordno).First().OrderNo) : 0;
                lines.Points = _stylePoints.Exists(s => s.StyleID == lines.StyleID) ? _stylePoints.GetAll(s => s.StyleID == lines.StyleID).First().Points.Value : 0;
            }
            return PartialView("_OrderDetailGridView1Partial", model);
        }

        public ActionResult ConfrimOrder(bool EmergencyTicked = false)
        {
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            //var usr = _dp.GetEmployee(busId, Session["UserName"].ToString(), Session["OrderPermit"].ToString()).Select(s => s.EmployeeId).ToList();
            //usr.Add(userId);
            //Session["userLst"] = usr;
            Session["ConfirmOrders"] = true;
            Session["EmergencyTicked"] = EmergencyTicked;
            Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId);
            return View();
        }

        public string ConfrimOrders(List<SalesConfirmModel> orderLst)
        {
            string result = "";
            bool manPack = Convert.ToBoolean(Session["IsManPack"]);
            string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
            string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
            string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
            string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
            string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            var appPath = Request.ApplicationPath;
            string cmpLogo = ConfigurationManager.AppSettings["cmpLogo"].ToString();
            result = _orderDisp.ConfirmOrders(orderLst, manPack, userId, cmpLogo, adminMail, mailUsername, mailPassword, mailPort, mailServer, busId, Convert.ToBoolean(Session["EmergencyTicked"])) ? "" : "failure";
            return result;
        }

        public ActionResult PrintOrders(string empFilter = "", string empid = "", string empname = "", string ucode = "", string ucodedesc = "", string address = "", Nullable<DateTime> startdate = null, int firstOrdNo = 0, int lastOrdNo = 0, Nullable<DateTime> frsOrdDate = null, Nullable<DateTime> lstOrdDate = null)
        {
            List<OrderDisplayModel> model = new List<OrderDisplayModel>();
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            var usr = _dp.GetEmployee(busId, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), "", "", "", "", "", "", "", "", Session["RequirePermissionUSR"].ToString()).Select(s => s.EmployeeId).ToList();
            usr.Add(userId);
            Session["userLst"] = usr;
            Session["OrderDisplayModel"] = _orderDisp.GetAllOrders(Session["OT"].ToString(), busId, Convert.ToBoolean(Session["POINTSREQ"].ToString()), userId, (List<string>)Session["userLst"], Session["Access"].ToString(), Session["OrderPermit"].ToString(), Convert.ToBoolean(Session["EmergencyTicked"]), true, false, Session["RequirePermissionUSR"].ToString()).OrderBy(s => s.OrderNo).ToList();
            return View();
        }
        public string GetPrintTemplates(string frmOrdno, string toOrdno)
        {
            string response = "";
            if (frmOrdno != "" && toOrdno != "")
            {
                int Out;
                int fromOrderNoint;
                int toOrderNoint;
                string userId = Session["UserName"].ToString();
                string pricePermission = Session["Price"].ToString();
                string custLogo = Session["LOGO"].ToString();
                var appPath = Request.ApplicationPath;
                string ONLCUSREFLBL = Session["ONLCUSREFLBL"].ToString();
                string cmpLogo = ConfigurationManager.AppSettings["cmpLogo"].ToString();
                fromOrderNoint = int.TryParse(frmOrdno, out Out) ? Convert.ToInt32(frmOrdno) : 0;
                toOrderNoint = int.TryParse(toOrdno, out Out) ? Convert.ToInt32(toOrdno) : 0;
                if (fromOrderNoint > 0 && toOrderNoint > 0)
                {
                    if (fromOrderNoint <= toOrderNoint)
                    {
                        response = _orderDisp.GetPrintTemplate(fromOrderNoint, toOrderNoint, cmpLogo, custLogo, userId, pricePermission, ONLCUSREFLBL);
                    }
                }
            }
            return response;
        }
        public ActionResult exporter()
        {
            var sett = CreateExportGridViewSettings();
            return GridViewExtension.ExportToXls(sett, ((List<OrderDisplayModel>)Session["SelectedSalesOrders"]));
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
        public string PrintReturns(int OrderNo)
        {
            string result = "";
            string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
            string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
            string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
            string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
            string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();
            string ueMailEMail = System.Configuration.ConfigurationManager.AppSettings["uemail/email"].ToString();
            string privateReordMsg = "";
            var HTTP_X_FORWARDED_FOR = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            var REMOTE_ADDR = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string Browser = System.Web.HttpContext.Current.Request.Browser.Browser;
            bool isrollout = Convert.ToBoolean(Session["RolloutOrderEst"]);
            string RTN_Collection_Style = Session["RTN_Collection_Style"] != null ? Session["RTN_Collection_Style"].ToString() : "";
            string custLogo = Session["LOGO"].ToString();
            string cmpLogo = System.Configuration.ConfigurationManager.AppSettings["cmpLogo"].ToString();
            string permissionPrice = Session["Price"].ToString();
            var slsHead = new SalesOrderHeaderViewModel();
            if (_salesHead.Exists(x => x.OrderNo == OrderNo))
            {
                slsHead = _salesHead.GetAll(x => x.OrderNo == OrderNo).Select(x => new SalesOrderHeaderViewModel { OrderNo = x.OrderNo, CompanyID = x.CompanyID, WarehouseID = x.WarehouseID, CustID = x.CustID, OrderDate = x.OrderDate.Value.ToString("yyyy-MM-dd"), InvAddress1 = x.InvAddress1, InvAddress2 = x.InvAddress2, InvAddress3 = x.InvAddress3, InvCity = x.InvCity, InvTown = x.InvTown, InvPostCode = x.InvPostCode, InvCountry = x.InvCountry, DelDesc = x.DelDesc, DelAddress1 = x.DelAddress1, DelAddress2 = x.DelAddress2, DelAddress3 = x.DelAddress3, DelCity = x.DelCity, DelTown = x.DelTown, DelPostCode = x.DelPostCode, DelCountry = x.DelCountry, CustRef = x.CustRef, Carrier = x.Carrier, CarrierCharge = Convert.ToDouble(x.CarrierCharge.Value), Comments = x.Comments, CommentsExternal = x.CommentsExternal, TotalGoods = x.TotalGoods.Value, OrderGoods = x.OrderGoods.Value, Currency_Exchange_Rate = x.Currency_Exchange_Rate, UserID = x.UserID, EmployeeID = x.PinNo, UCodeId = x.UCodeId, Currency_Exchange_Code = x.Currency_Exchange_Code, TIMEOFENTRY = x.TIMEOFENTRY, RepID = x.RepID, ReasonCode = x.ReasonCode, OnlineUserID = x.OnlineUserID, OrderAnalysisCode1 = x.OrderAnalysisCode1, OrderAnalysisCode2 = x.OrderAnalysisCode2, OrderAnalysisCode3 = x.OrderAnalysisCode3, OrderAnalysisCode4 = x.OrderAnalysisCode4, OrderAnalysisCode5 = x.OrderAnalysisCode5, AllowPartShipment = x.AllowPartShipment, OrderType = x.OrderType, ContractRef = x.ContractRef, EmailID = x.EmailID, ContactName = x.ContactName, IsUcode = true }).First();

                slsHead.IsEditing = true;
                slsHead.EmployeeName = _employee.Exists(s => s.EmployeeID == slsHead.EmployeeID) ? _employee.GetAll(s => s.EmployeeID == slsHead.EmployeeID).First().Forename + " " + _employee.GetAll(s => s.EmployeeID == slsHead.EmployeeID).First().Surname : "";
                slsHead.SalesOrderLine = _salesLine.GetAll(x => x.OrderNo == OrderNo).Select(x => new SalesOrderLineViewModel
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
                    Isedit = true,
                    Total = _dataConnection.GetlineTotals(Convert.ToDouble(x.OrdQty), Convert.ToDouble(x.Price), _dataConnection.GetVatPercent(x.StyleID, x.SizeID)),
                    VatPercent = _dataConnection.GetVatPercent(x.StyleID, x.SizeID)
                }).ToList();
                foreach (var lin in slsHead.SalesOrderLine.Where(s => s.IsDleted == false))
                {
                    lin.Points = _pointStyle.Exists(s => s.StyleID == lin.StyleID && s.BusinessID == slsHead.CustID) ? _pointStyle.GetAll(s => s.StyleID == lin.StyleID && s.BusinessID == slsHead.CustID).First().Points.Value : 0;
                    lin.TotalPoints = _pointStyle.Exists(s => s.StyleID == lin.StyleID && s.BusinessID == slsHead.CustID) ? _pointStyle.GetAll(s => s.StyleID == lin.StyleID && s.BusinessID == slsHead.CustID).First().Points.Value * Convert.ToInt32(lin.OrdQty) : 0;
                    lin.SoqtyForempSOPoints = (lin.SoqtyForempSO * lin.Points);

                }
                var cnfResult = _basket.GetEmailMessage(slsHead, "", 0, permissionPrice, Session["ONLCUSREFLBL"].ToString(), cmpLogo, custLogo, OrderNo, false, null);
                if (slsHead.CustRef.ToLower().Contains("private"))
                {

                    privateReordMsg = _dp.GetPrivateReturnMail(GetPrivateReorderLines(OrderNo), "", "", "", 0, "readonly", "", 0, false, null);

                }

                if (cnfResult.OrderConfirmationPOP != null && cnfResult.OrderConfirmationPOP != "")
                {
                    cnfResult.OrderConfirmationPOP= cnfResult.OrderConfirmationPOP.Replace("%privateconfirmation%", privateReordMsg);
                    result = cnfResult.OrderConfirmationPOP;
                }
            }
            return result;
        }
        public SalesOrderHeaderViewModel GetPrivateReorderLines(int rtnNo)
        {
            long FrstreOrder = 0;
            var slsHead = new SalesOrderHeaderViewModel();
            var slsLine = new List<SalesOrderLineViewModel>();
            slsLine = _salesLine.GetAll(x => x.ReturnOrderNo == rtnNo).Select(x => new SalesOrderLineViewModel
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
                Isedit = true,
                Total = _dataConnection.GetlineTotals(Convert.ToDouble(x.OrdQty), Convert.ToDouble(x.Price), _dataConnection.GetVatPercent(x.StyleID, x.SizeID)),
                VatPercent = _dataConnection.GetVatPercent(x.StyleID, x.SizeID)
            }).ToList();
            FrstreOrder = slsLine.Count>0?slsLine.First().OrderNo:0;
            if (FrstreOrder > 0)
            {
                slsHead = _salesHead.GetAll(x => x.OrderNo == FrstreOrder).Select(x => new SalesOrderHeaderViewModel { OrderNo = x.OrderNo, CompanyID = x.CompanyID, WarehouseID = x.WarehouseID, CustID = x.CustID, OrderDate = x.OrderDate.Value.ToString("yyyy-MM-dd"), InvAddress1 = x.InvAddress1, InvAddress2 = x.InvAddress2, InvAddress3 = x.InvAddress3, InvCity = x.InvCity, InvTown = x.InvTown, InvPostCode = x.InvPostCode, InvCountry = x.InvCountry, DelDesc = x.DelDesc, DelAddress1 = x.DelAddress1, DelAddress2 = x.DelAddress2, DelAddress3 = x.DelAddress3, DelCity = x.DelCity, DelTown = x.DelTown, DelPostCode = x.DelPostCode, DelCountry = x.DelCountry, CustRef = x.CustRef, Carrier = x.Carrier, CarrierCharge = Convert.ToDouble(x.CarrierCharge.Value), Comments = x.Comments, CommentsExternal = x.CommentsExternal, TotalGoods = x.TotalGoods.Value, OrderGoods = x.OrderGoods.Value, Currency_Exchange_Rate = x.Currency_Exchange_Rate, UserID = x.UserID, EmployeeID = x.PinNo, UCodeId = x.UCodeId, Currency_Exchange_Code = x.Currency_Exchange_Code, TIMEOFENTRY = x.TIMEOFENTRY, RepID = x.RepID, ReasonCode = x.ReasonCode, OnlineUserID = x.OnlineUserID, OrderAnalysisCode1 = x.OrderAnalysisCode1, OrderAnalysisCode2 = x.OrderAnalysisCode2, OrderAnalysisCode3 = x.OrderAnalysisCode3, OrderAnalysisCode4 = x.OrderAnalysisCode4, OrderAnalysisCode5 = x.OrderAnalysisCode5, AllowPartShipment = x.AllowPartShipment, OrderType = x.OrderType, ContractRef = x.ContractRef, EmailID = x.EmailID, ContactName = x.ContactName, IsUcode = true }).First();
                slsHead.SalesOrderLine = slsLine;
            }
            return slsHead;

        }
        public GridViewSettings CreateExportGridViewSettings()
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "ShowOrderGridView";
            settings.KeyFieldName = "OrderNo";

            settings.Columns.Add(set =>
            {
                set.FieldName = "OrderNo";
            });
            settings.Columns.Add("OrderType");
            settings.Columns.Add(set =>
            {
                set.FieldName = "OrderDate";
                set.PropertiesEdit.DisplayFormatString = "dd-MM-yyyy";
            });
            settings.Columns.Add("CustomerRef");
            settings.Columns.Add("NominalCode");
            settings.Columns.Add("Address1");
            settings.Columns.Add("DelDesc");
            if (Session["Price"].ToString().ToLower() != "hide")
            {
                settings.Columns.Add("TotalQty");
                settings.Columns.Add("TotalIncVat");
                settings.Columns.Add("GoodsValue");
            }
            settings.Columns.Add("UserId");
            settings.Columns.Add("EmpID");
            settings.Columns.Add("EmpName");
            if (Convert.ToBoolean(Session["POINTSREQ"]))
            {
                settings.Columns.Add(set =>
                {
                    set.FieldName = "PointsSpent";
                    set.Caption = "Points Spent";
                });
                settings.Columns.Add("TotalPoints");
            }
            settings.Columns.Add("IsConfirmed");
            settings.Columns.Add("IsProcessed");
            settings.Columns.Add("PersonPackNo");
            settings.Columns.Add("FirstDespatch");
            settings.Columns.Add("CourrierRef");
            if (Convert.ToBoolean(Session["ConfirmOrders"]))
            {
                settings.Columns.Add("DeliveryWeek");
                settings.Columns.Add("DeliveryDay");
            }
            return settings;
        }

    }
}