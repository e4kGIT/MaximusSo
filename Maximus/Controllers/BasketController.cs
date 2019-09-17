using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;
using Maximus.Filter;

namespace Maximus.Controllers
{

    [CustomFilter]
    public class BasketController : Controller
    {
        #region declarations
        DataProcessing dp = new DataProcessing();
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        #endregion

        #region ShowBasket
        public ActionResult ShowBasket()
        {
            //dp.FillCombo_CustomerDelivery();
            ViewData["SiteCodes"] =    FillSiteCode();
             ViewData["carrierFill"] = FillCarrierDropdown();
            ViewData["carrierStyleFill"] = FillCarrierStyle();
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

        public ActionResult GetEmployeeDeliveryAddress()
        {
            var result = dp.FillCombo_CustomerDelivery();
            Session["DeliveryAddress"] = result;
            return PartialView("_Deliveryaddress", result);
        }

        #endregion

        #region detail grid

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
            return PartialView("_CartviewDetailGridViewGridViewPartial", model);
        }

        #endregion

        #region GetCarriers
        public ActionResult GetCarriers()
        {
            ViewData["carrierFill"] = FillCarrierDropdown();
            ViewData["carrierStyleFill"] = FillCarrierStyle();
            return View("_CarriageandResons");
        }
        #endregion
        #region GetCarriers
        public ActionResult GetCarrierandreason()
        {
            ViewData["carrierFill"] = FillCarrierDropdown();
            ViewData["carrierStyleFill"] = FillCarrierStyle();
            return PartialView("model/_CarriageView");
        }
        #endregion

        #region cart Update

        [HttpPost, ValidateInput(false)]
        public ActionResult CartViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderHeaderViewModel item)
        {
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

        #endregion

        #region CartViewDelete
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

        #endregion

        #region CartviewDetailGridViewGridViewPartialUpdate

        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderLineViewModel item)
        {
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            var model = result.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();
            string businessId = Session["BuisnessId"].ToString();

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var data in model)
                    {
                        var parentStyle = model.Where(s => s.LineNo == item.LineNo).First().StyleID;
                        var assemblyID = entity.tblasm_assemblyheader.Any(x => x.StyleID == parentStyle && x.CustID == businessId) ? entity.tblasm_assemblyheader.Where(x => x.StyleID == parentStyle && x.CustID == businessId).First().AssemblyID : 0;
                        var qty = assemblyID != 0 ? entity.tblasm_assemblydetail.Any(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID) ? entity.tblasm_assemblydetail.Where(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID).First().Qty : 1 : 1;
                        data.OrdQty = qty * item.OrdQty;
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
        #endregion

        #region CartviewDetailGridViewGridViewPartialDelete
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
        #endregion

        #region CardDetailAssembly

        [ValidateInput(false)]
        public ActionResult CardDetailAssembly(int LineNo)
        {
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            var model = result.Where(x => x.OriginalLineNo == LineNo).ToList();
            //string businessId = Session["BuisnessId"].ToString();
            return PartialView("_CardDetailAssembly", model);
        }
        #endregion

        #region  GridViewPartialAddNew
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderLineViewModel item)
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

        #endregion

        #region GridViewPartialUpdate

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.SalesOrderLineViewModel item)
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
        #endregion

        #region  GridViewPartialDelete

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int64 LineNo)
        {
            var model = new object[0];
            if (LineNo >= 0)
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
        #endregion

        #region FillAllAddress
        public JsonResult FillAllAddress(int descAddId)
        {
            var result = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AcceptOrders
        public ActionResult AcceptOrder(int addressId)
        {
            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            bool booCheck = true; bool booAutoConfirm = false; long mStackManPack = 0;
            string busId = Session["BuisnessId"].ToString();
            long intSalesOrderNo = 0;
            long intnext = 0;
            string tmpMsg = "";
            bool EditFlag = false;
            bool StrSQL = false;
            long i = 0;
            string mCDate;
            bool booNotSAP = true;
            long intManPackNext = 0;
            string mOrdDate = "";
            string mySqlInv = "";
            string myInvDesc = "";
            string myInvAddress1 = "";
            string myInvAddress2 = "";
            string myInvAddress3 = "";
            string myInvTown = "";
            string myInvCity = "";
            string myInvPostCode = "";
            string myInvCountry = "";
            bool isPersonalOrder = false;
            bool booExistInManpack;
            Session["EditOrdContent"] = "";
            bool booStackOrder;
            booStackOrder = Convert.ToBoolean(dp.BusinessParam("STACKORDERS", busId));
            //if(manpac)
            //{
            //}
            //if(booCheck)
            //{
            //}
            //if (Session["POINTSREQD"] && rolledoutorder)
            //{
            //}
            int myAddressID = 0, myContactID = 0, myCountryID = 0;
            myAddressID = addressId;
            myContactID = Convert.ToInt32(((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == addressId).First().contactId);
            myCountryID = Convert.ToInt32(((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == addressId).First().Country);
            if (!isPersonalOrder)
            {

                string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID = '" + cmpId + "' Order By tblbus_address.Description";
                var data = dp.GetAddressDetails(SQL);
            }
            //if(!checkCarriage())
            //{

            //}
            return View();
        }
        #endregion

        #region get carrier cmbo
        public List<string> FillCarrierDropdown()
        {
            var result = new List<string>();
            result = dp.GetCarrierCmbValue();
            return result;
        }
        #endregion

        #region Carrier style

        public List<string> FillCarrierStyle()
        {
            var result = new List<string>();
            result = dp.GetCarrierStyleCmbValue();
            return result;
        }
        #endregion

        #region GetSitecodes
        public List<SiteCodeModel> FillSiteCode()
        {
            var result = dp.GetSitecodes(Session["BuisnessId"].ToString());
            return result;
        }
        #endregion

        #region checkCarriage
        //public bool CheckCarriage()
        //{
        //    bool checkCarriage = false;
        //    if(IsManpack==false)
        //    {
        //        if(( checkBulkCarriageLine()==false)
        //        {
        //            if((int)Session["CARRPERCENT"]>0)
        //            {
        //                checkCarriage = false;
        //            }
        //            else
        //            {
        //                if()
        //            }
        //        }
        //    }

        //        checkCarriage = False
        //    If IsManpack = False Then
        //        If checkBulkCarriageLine() = False Then
        //            If Val(Session.Item("CARRPERCENT")) > 0 Then
        //                checkCarriage = False
        //            Else
        //                If CDbl(Val(txtTotalGoods.Text)) < CDbl(Val(Session.Item("CARRREQAMT"))) Then
        //                    checkCarriage = False
        //                Else
        //                    checkCarriage = True
        //                End If
        //            End If
        //        Else
        //            checkCarriage = True
        //        End If
        //    Else
        //        If checkCarriageLine() = False Then
        //            If Val(Session.Item("CARRPERCENT")) > 0 Then
        //                checkCarriage = False
        //            Else
        //                If CDbl(Val(txtTotalGoods.Text)) < CDbl(Val(Session.Item("CARRREQAMT"))) Then
        //                    checkCarriage = False
        //                Else
        //                    checkCarriage = True
        //                End If
        //            End If
        //        Else
        //            checkCarriage = True
        //        End If
        //    End If
        //End Function
        //}
        #endregion

        #region checkBulkCarriageLine

        //public bool checkBulkCarriageLine()
        //{
        //    string carrstr = "";
        //    long irow = 0;
        //    bool checkBulkCarriageLine = false;

        ////    Dim carrstr As String
        ////Dim irow As Long
        ////Dim rs_carr As New ADODB.Recordset
        ////checkBulkCarriageLine = False
        ////For irow = 1 To Session.Item("objCurrentOrder").SalesOrderLine.Count
        ////    With Session.Item("objCurrentOrder").SalesOrderLine.item(irow)
        ////        carrstr = "SELECT * FROM tblonlinesop_carriage WHERE StyleID='" & .StyleID & "' AND CompanyID='" & strCompanyID & "'"
        ////        rs_carr.Open(LCase(carrstr), Conn)
        ////        If Not rs_carr.EOF Then
        ////            checkBulkCarriageLine = True
        ////            Exit Function
        ////        End If
        ////        rs_carr.Close()
        ////    End With
        ////Next
        //}
        #endregion

    }
}

