using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;
namespace Maximus.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DataProcessing dp = new DataProcessing();
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        public ActionResult Index(string BusinessID = "TSBBAN01")
        {
            //if (Session["SalesOrder"] == null)
            //{
            //    Session["SalesOrder"] = new List<SalesOrderViewModel>();
            //}
            if (Session["BuisnessId"] == null)
            {
                Session["qty"] = "0";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();

            }
            else if (Session["BuisnessId"].ToString() != BusinessID)
            {
                Session["qty"] = "0";
                Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
            }
            Session["BuisnessId"] = BusinessID;
            return View("Employee");
        }

        [ValidateInput(false)]
        public ActionResult EmployeeGridViewPartial()
        {
            Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                var modelq = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                //var model = (List<SalesOrderViewModel>)Session["SalesOrder"];
                //if (modelq[0].SalesOrderLine != null)
                //{
                //    model.Add(new SalesOrderViewModel { SalesOrders = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"], BusinessId = Session["BuisnessId"].ToString(), EmpId = Session["SelectedEmp"].ToString() });
                //}
                //Session["SalesOrder"] = model;
                //  Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                Session["SalesOrderLine"] = new List<SalesOrderLineViewModel>();
            }
            var result = dp.getEmployeeDetails(Session["BuisnessId"].ToString());
            return PartialView("_EmployeeGridViewPartial", result);
        }

        public string GotoCard(string EmployeeId, string EmpName, string Ucodes)
        {
            Session["EmpName"] = EmpName;
            Session["SelectedEmp"] = EmployeeId;
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
            {
                Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == Session["SelectedEmp"].ToString()) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Sum(s=>s.OrdQty) : null;
            }
            else
            {
                Session["qty"] = 0;
            }

            //if (((List<SalesOrderViewModel>)Session["SalesOrder"]).Count > 0)
            //{
            //    var modelq = ((List<SalesOrderViewModel>)Session["SalesOrder"]).Where(x => x.BusinessId == Session["BuisnessId"].ToString()).ToList();
            //    var model =modelq.Any(x=>x.EmpId== Session["SelectedEmp"].ToString())? modelq.Where(x => x.EmpId == Session["SelectedEmp"].ToString()).First().SalesOrders:null;
            //    Session["qty"] =model==null?0: model.Any(x => x.EmployeeID == EmployeeId) ? model.Where(x => x.EmployeeID == EmployeeId).First().SalesOrderLine.Where(w=>w.EmployeeId== Session["SelectedEmp"].ToString()).Sum(w=>w.OrdQty) : 0;
            //}
            //else
            //{
            //    Session["qty"] = 0;
            //}
            //  Session["qty"] = Session["SalesOrder"] != null ? ((List<SalesOrderViewModel>)Session["SalesOrder"]).Where(x => x.BusinessId == Session["BuisnessId"].ToString()).First().SalesOrders.Where(x => x.EmployeeID == EmployeeId).First().SalesOrderLine.Select(x => x.LineNo).Count() : 0;

            var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var address1 = dp.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
            var addArr = new string[]{};
            var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
            salesOrderHeader.Add(new SalesOrderHeaderViewModel
            {
                DelDesc=addresArr[0],
                DelAddress1 = addresArr[1],
                DelAddress2 = addresArr[2],
                DelAddress3 = addresArr[3],
                DelTown = addresArr[4],
                DelCity = addresArr[5],
                DelPostCode = addresArr[6],
                DelCountry = addresArr[7], 
                EmployeeName = Session["EmpName"].ToString(),
                EmployeeID = Session["SelectedEmp"].ToString(),
                CustRef = entity.tblsop_salesorder_header.AsEnumerable().Where(x => x.CustID == Session["BuisnessId"].ToString()).First().CustRef,
                Comments = entity.tblsop_salesorder_header.AsEnumerable().Where(x => x.CustID == Session["BuisnessId"].ToString()).First().Comments,
            });

            List<string> ucodeLst = new List<string>();
            if (Ucodes.Contains(';'))
            {
                foreach (var str in Ucodes.Split(';'))
                { ucodeLst.Add(str); }

            }
            Session["SelectedUcode"] = Ucodes;
            List<UcodeModel> ucodeLst1 = new List<UcodeModel>();
            if (ucodeLst.Count > 0)
            {
                foreach (string ucode in ucodeLst)
                {
                    ucodeLst1.AddRange(entity.ucodeby_freetextview.Where(x => x.UCodeID == ucode).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList());
                }
            }
            else
            {
                ucodeLst1 = entity.ucodeby_freetextview.Where(x => x.UCodeID == Ucodes).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
            }
            //var ucodeLst1 = ucodeLst.Count > 0 ? entity.tblaccemp_ucodes.Where(x => ucodeLst.Contains(x.UCodeID)).Select(x => x.StyleID).ToList() : entity.tblaccemp_ucodes.Where(x => x.UCodeID == Ucodes).Select(x => x.StyleID).ToList();
            //var freLst = new List<FreetxtStyle>();
            //foreach (string mod in ucodeLst1)
            //{
            //    freLst.Add(entity.ucodeby_freetextview.Where(x => x.StyleID.Contains(mod)).Select(x => new FreetxtStyle { freetext = x.FreeText, style = x.StyleID }).FirstOrDefault());
            //}
            //freLst = freLst.Distinct().ToList();
            var lst = new List<string>();
            foreach (var data in ucodeLst1)
            {
                if (data.FreeText == null | data.FreeText == "")
                {
                    lst.Add(data.StyleId);
                }
                else
                {
                    lst.Add(data.FreeText);
                }
            }
            Session["UcodeStyle"] = ucodeLst1;
            Session["UcFreeTxt"] = lst.Distinct().ToList();
            return Url.Content("~/Home/Index");
        }

        //[HttpPost, ValidateInput(false)]
        //public ActionResult EmployeeGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.EmployeeViewModel item)
        //{
        //    var model = new object[0];
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to insert the new item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_EmployeeGridViewPartial", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult EmployeeGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.EmployeeViewModel item)
        //{
        //    var model = new object[0];
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to update the item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_EmployeeGridViewPartial", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult EmployeeGridViewPartialDelete(System.String EmployeeId)
        //{
        //    var model = new object[0];
        //    if (EmployeeId != null)
        //    {
        //        try
        //        {
        //            // Insert here a code to delete the item from your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    return PartialView("_EmployeeGridViewPartial", model);
        //}
    }
}