using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;

namespace Maximus.Controllers
{
    public class BasketController : Controller
    {
        DataProcessing dp = new DataProcessing();
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        public ActionResult ShowBasket()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CartView()
        {
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            // var salesOrder = (List<SalesOrderViewModel>)Session["SalesOrder"];
            if (mod.Count > 0)
            {
                var modq = mod.Where(x => x.SalesOrderLine == null).FirstOrDefault();
                mod.Remove(modq);
            }

            return PartialView("_CartView", mod);
        }

        [ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartial(string empId = "")
        {
            if (empId != "")
            {
                Session["thisEmp"] = empId;
            }
            var buss = Session["BuisnessId"].ToString();
            var emp = Session["SelectedEmp"].ToString();
            var salesHeaders = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var model = empId != "" ? salesHeaders.Where(s => s.EmployeeID == empId).FirstOrDefault().SalesOrderLine.ToList() : salesHeaders.Where(s => s.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();

            //var model = ((List<SalesOrderViewModel>)Session["SalesOrder"]);
            //if (model.Count > 0)
            //{
            //        var salesOrder = model.Any(x => x.BusinessId == Session["BuisnessId"].ToString() && x.EmpId == Session["SelectedEmp"].ToString())? model.Where(x => x.BusinessId == Session["BuisnessId"].ToString() && x.EmpId== Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrders:null;
            //    if (salesOrder != null)
            //    {
            //        var model1 = salesOrder.Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? salesOrder.Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(w => w.EmployeeId == Session["SelectedEmp"].ToString()).ToList() : null;
            //        if (model1 == null)
            //        {
            //            var s = Session["SelectedEmp"].ToString();
            //            var ss = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            //            var model2 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).FirstOrDefault().SalesOrderLine.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).Count() > 0 ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).FirstOrDefault().SalesOrderLine.Where(x => x.EmployeeId == Session["SelectedEmp"].ToString()).ToList() : null;
            //            return PartialView("_CartviewDetailGridViewGridViewPartial", model2);
            //        }
            //        else
            //        {
            //            return PartialView("_CartviewDetailGridViewGridViewPartial", model1);
            //        }
            //    }else
            //    {
            //        var s=((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).ToList();
            //        var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).FirstOrDefault().SalesOrderLine.Count > 0 ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).FirstOrDefault().SalesOrderLine.Where(w=>w.EmployeeId==Session["SelectedEmp"].ToString()) : null;
            //        return PartialView("_CartviewDetailGridViewGridViewPartial", model1);
            //    }
            //    return null;
            //}
            //else
            //{
            //    var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).FirstOrDefault().SalesOrderLine.Count > 0 ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).FirstOrDefault().SalesOrderLine : null;
            //    return PartialView("_CartviewDetailGridViewGridViewPartial", model1);

            //}
            return PartialView("_CartviewDetailGridViewGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CartViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderHeaderViewModel item)
        {
            //var model = (List<SalesOrderLineViewModel>)Session["SalesOrderHeader"];
            var model = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    var dataColl = model.Where(x => x.EmployeeID == item.EmployeeID).ToList();
                    foreach (var data in dataColl)
                    {
                        data.DelAddress1 = item.DelAddress1;
                        data.DelAddress2 = item.DelAddress2;
                        data.DelAddress3 = item.DelAddress3;
                        data.DelDesc = item.DelDesc;
                        data.DelPostCode = item.DelPostCode;
                        data.DelCountry = item.DelCountry;
                        data.DelTown = item.DelTown;
                        data.DelCity = item.DelCity;
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CartView", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CartViewDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderHeaderViewModel item)
        {
            var model = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            if (item.EmployeeID != "")
            {
                try
                {
                    var dataColl = model.Where(x => x.EmployeeID == item.EmployeeID).ToList();
                    foreach (var data in dataColl)
                    {
                        model.Remove(data);
                    }
                    // Session["SalesOrderLines"] = model;
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_CartView", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderLineViewModel item)
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
            return PartialView("_CartviewDetailGridViewGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderLineViewModel item)
        {
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            var model = result.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var data in model)
                    {
                        data.OrdQty = item.OrdQty;
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CartviewDetailGridViewGridViewPartial", result);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderLineViewModel item)
        {
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault();
            var model = result.SalesOrderLine.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();
            // var model = model1
            if (item.LineNo >= 0)
            {
                try
                {
                    result.SalesOrderLine.RemoveAll(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_CartviewDetailGridViewGridViewPartial", result.SalesOrderLine.ToList());
        }
    }
}