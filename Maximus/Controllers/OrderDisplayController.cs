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

namespace Maximus.Controllers
{
    public class OrderDisplayController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDisplay _orderDisp;
        private readonly DataConnectionService _dataConnection;
        private readonly Employee _employee;
        private readonly TblFskStyle _fskStyl;
        private readonly PointStyle _stylePoints;
        public OrderDisplayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderDisplayService orderDisp = new OrderDisplayService(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            TblFskStyle fskStyl = new TblFskStyle(_unitOfWork);
            PointStyle stylePoints = new PointStyle(_unitOfWork);
            _dataConnection = dataConnection;
            _orderDisp = orderDisp;
            _employee = employee;
            _fskStyl = fskStyl;
            _stylePoints = stylePoints;
        }
        public ActionResult ShowOrders()
        {
            Session["ConfirmOrders"] = false;
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            var usr = _dataConnection.GetEmployeeProvedure(busId, userId);
            usr.Add(userId);
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
            var model = _orderDisp.GetAllOrders(busId, userId, (List<string>)Session["userLst"]);
            Session["usrModel"] = model.Select(s => s.EmpID).Distinct().ToList();
            return PartialView("_SearchOrderShowOrders");
        }

        [ValidateInput(false)]
        public ActionResult ShowOrderGridViewPartial(int frmOrderno = 0, int toOrderNo = 0, Nullable<DateTime> frmOrderdate = null, Nullable<DateTime> toOrderDate = null, string custRef = "", string ordStatus = "", string users = "", int recsToDisplay = 0, bool like = false, bool exact = false, string Empid = "", string Empname = "", Nullable<DateTime> StrtDate = null)
        {
            List<string> employees = new List<string>();
            List<OrderDisplayModel> model = new List<OrderDisplayModel>();
            string busId = Session["BuisnessId"].ToString();
            string userId = Session["UserName"].ToString();
            model = _orderDisp.GetAllOrders(busId, userId, (List<string>)Session["userLst"]);
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
                    model = model.Where(s => s.OrderDate >= frmOrderdate && s.OrderDate <= toOrderDate).ToList();
                }
                else
                {
                    if (frmOrderdate != null)
                    {
                        model = model.Where(s => s.OrderDate >= frmOrderdate).ToList();
                    }
                    if (toOrderDate != null)
                    {
                        model = model.Where(s => s.OrderDate <= toOrderDate).ToList();
                    }
                }
            }
            else
            {
                DateTime startDate = DateTime.Now.AddMonths(-3);
                DateTime endDate = DateTime.Now;
                model = model.Where(s => s.OrderDate >= startDate && s.OrderDate <= endDate).ToList();
            }
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
            if (empId != "")
            {
                Session["SelectedEmp"] = empId;
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


        [ValidateInput(false)]
        public ActionResult OrderDetailGridView1Partial(int ordno)
        {
            var model = ((List<OrderDisplayModel>)Session["SelectedSalesOrders"]).Where(s => s.OrderNo == ordno).First().saleDetail;
            foreach (var lines in model)
            {
                lines.Points = _stylePoints.Exists(s => s.StyleID == lines.StyleID) ? _stylePoints.GetAll(s => s.StyleID == lines.StyleID).First().Points.Value : 0;
                lines.Description = _fskStyl.Exists(s => s.StyleID == lines.StyleID) ? _fskStyl.GetAll(s => s.StyleID == lines.StyleID).First().Description : "";
            }
            return PartialView("_OrderDetailGridView1Partial", model);
        }

        public ActionResult ConfrimOrder()
        {
             Session["ConfirmOrders"] = true;
            return View();
        }

    }
}