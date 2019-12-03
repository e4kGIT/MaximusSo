using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;
using Maximus.Filter;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Maximus.Controllers
{

    [Authorize]
    public class BasketController : Controller
    {
        #region declarations
        DataProcessing dp = new DataProcessing();
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        public string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        #endregion

        #region ShowBasket
        public ActionResult ShowBasket()
        {
            Session["DeliveryAddress"] = dp.FillCombo_CustomerDelivery(true, Session["SelectedEmp"].ToString());
            Session["clickedEmp"] = null;
            var model1 = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            double carriage = 0.0;
            string busId = Session["BuisnessId"].ToString();
            string emp = Session["SelectedEmp"].ToString();
            var contactType = 0;
            var resultq = new BusAddress();
            var contactId = 0;
            List<double> varpercents = new List<double>();
            var data = "";
            var result = dp.GetDeliveryAddressId(emp, busId);
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            Session["cboDelAddressDesc"] = "";
            Session["CustRef"] = "";

            if (result > 0)
            {
                if ((mod.Where(x => x.EmployeeID == emp).First().CustRef == "" || mod.Where(x => x.EmployeeID == emp).First().CustRef == null))
                {
                    Session["cboDelAddress"] = result;
                    var sa = entity.tblbus_address.Any(x => x.AddressID == result && x.BusinessID == busId) ? entity.tblbus_address.Where(x => x.AddressID == result && x.BusinessID == busId).First().Description : "";
                    Session["cboDelAddressDesc"] = entity.tblbus_address.Any(x => x.AddressID == result && x.BusinessID == busId) ? entity.tblbus_address.Where(x => x.AddressID == result && x.BusinessID == busId).First().Description : "";
                    contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                    if (Session["cboDelAddressDesc"].ToString() == "")
                    {
                        var s = Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]);
                        if (!Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]))
                        {
                            var res = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().AddressId : 0;
                            if (res != 0)
                            {
                                Session["cboDelAddress"] = res;
                                Session["cboDelAddressDesc"] = entity.tblbus_address.Any(x => x.AddressID == res && x.BusinessID == busId) ? entity.tblbus_address.Where(x => x.AddressID == res && x.BusinessID == busId).First().Description : "";

                                contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                                resultq = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == res).First();
                                contactId = Convert.ToInt32(resultq.contactId);
                                data = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CustRef : entity.tblbus_contact.Any(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? entity.tblbus_contact.Where(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                                Session["CustRef"] = data;
                                ViewData["comment"] = mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().CommentsExternal;
                            }
                        }
                    }
                    else
                    {
                        contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                        var sss = (List<BusAddress>)Session["DeliveryAddress"];
                        resultq = ((List<BusAddress>)Session["DeliveryAddress"]).Any(x => x.AddressId == result) ? ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == result).First() : new BusAddress();
                        if (resultq.AddressId > 0)
                        {
                            mod.Last().DelDesc = resultq.AddressDescription;
                            mod.Last().AddressId = resultq.AddressId;
                            mod.Last().DelAddress1 = resultq.Address1;
                            mod.Last().DelAddress3 = resultq.Address3;
                            mod.Last().DelAddress2 = resultq.Address2;
                            mod.Last().DelCity = resultq.City;
                            mod.Last().DelCountry = resultq.Country;
                            mod.Last().DelPostCode = resultq.PostCode;
                            contactId = Convert.ToInt32(resultq.contactId);
                            data = entity.tblbus_contact.Any(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? entity.tblbus_contact.Where(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                            Session["CustRef"] = data;
                            ViewData["comment"] = mod.Last().CommentsExternal;
                            mod.Last().CustRef = data;
                        }
                    }
                }
                else
                {
                    Session["cboDelAddress"] = mod.Where(x => x.EmployeeID == emp).First().AddressId;
                    Session["cboDelAddressDesc"] = mod.Where(x => x.EmployeeID == emp).First().DelDesc;
                    Session["CustRef"] = mod.Where(x => x.EmployeeID == emp).First().CustRef;
                    ViewData["comment"] = mod.Where(x => x.EmployeeID == emp).First().CommentsExternal;
                }
            }
            else
            {
                var res = mod.Any(x => x.SalesOrderLine != null) ? mod.Where(x => x.SalesOrderLine != null).Last().AddressId : 0;
                if (res != 0)
                {
                    Session["cboDelAddress"] = res;
                    Session["cboDelAddressDesc"] = entity.tblbus_address.Any(x => x.AddressID == res && x.BusinessID == busId) ? entity.tblbus_address.Where(x => x.AddressID == res && x.BusinessID == busId).First().Description : "";

                    contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                    resultq = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == res).First();
                    contactId = Convert.ToInt32(resultq.contactId);
                    data = entity.tblbus_contact.Any(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? entity.tblbus_contact.Where(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
                    Session["CustRef"] = data;
                }
            }
            ViewData["SiteCodes"] = FillSiteCode();
            var carr = FillCarrierDropdown();

            List<SalesOrderHeaderViewModel> totLst = new List<SalesOrderHeaderViewModel>();
            totLst.Add(mod.Where(x => x.SalesOrderLine != null).Last());

            TotalModel tot = new TotalModel();
            tot = dp.GetAlltotals(totLst, carriage);
            ViewBag.VatPercent = tot.vatSpan;
            ViewBag.carriage = tot.carriage;
            ViewBag.ordeTotal = tot.ordeTotal;
            ViewBag.totalVat = tot.totalVat;
            ViewBag.Total = tot.Total;
            ViewBag.GrossTotal = tot.gross;
            if (carr.Count > 0)
            {
                ViewData["carrierFill"] = carr;
                foreach (var item in carr)
                {
                    if (item.Contains(Session["Carrier"].ToString()))
                    {

                        Session["selectedcar"] = item.Trim();
                    }
                }
            }
            ViewData["carrierStyleFill"] = FillCarrierStyle();
            ViewData["ddlCustRef"] = dp.GetCustRefVisiblity(busId);
            return View();
        }
        #endregion

        #region cartview
        [ValidateInput(false)]
        public ActionResult CartView(string empid = "")
        {
            var newSalesHeader = new List<SalesOrderHeaderViewModel>();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            // var salesOrder = (List<SalesOrderViewModel>)Session["SalesOrder"];
            if (mod.Count > 0)
            {
                var modq = mod.Where(x => x.SalesOrderLine == null).FirstOrDefault();
                mod.Remove(modq);
            }
            if (mod.Count == 1)
            {

                return PartialView("_CartView", mod);
            }
            else
            {
                if (Session["clickedEmp"] != null)
                {
                    if (empid != "" || Session["clickedEmp"].ToString() != "")
                    {
                        empid = empid == "" ? Session["clickedEmp"].ToString() : empid;
                        return PartialView("_CartView", mod.Where(x => x.EmployeeID.Trim() == empid).ToList());
                    }
                    else
                    {
                        newSalesHeader.Add(mod.FirstOrDefault());
                        return PartialView("_CartView", newSalesHeader);
                    }
                }
                else
                {
                    if (empid != "")
                    {
                        return PartialView("_CartView", mod.Where(x => x.EmployeeID.Trim() == empid).ToList());
                    }
                    else
                    {
                        newSalesHeader.Add(mod.Last());
                        return PartialView("_CartView", newSalesHeader);
                    }
                }
            }
        }
        #endregion

        #region delivery address
        public ActionResult GetEmployeeDeliveryAddress()
        {
            ViewData["booAddrDef"] = Convert.ToBoolean(dp.BusinessParam("DEFEMPDELADDR", Session["BuisnessId"].ToString()));
            ViewData["booAddrEdit"] = Convert.ToBoolean(dp.BusinessParam("DEFEMPDELADDR_EDIT", Session["BuisnessId"].ToString()));
            ViewData["booAddrView"] = Convert.ToBoolean(dp.BusinessParam("DEFEMPDELADDR_VIEW", Session["BuisnessId"].ToString()));
            var result = dp.FillCombo_CustomerDelivery();
            Session["DeliveryAddress"] = result;
            return PartialView("_Deliveryaddress", result);
        }

        #endregion

        #region detail grid

        [ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartial(string empId = "")
        {
            var appPath = System.Web.HttpContext.Current.Request.MapPath(@"~\");
            if (empId != "")
            {
                Session["thisEmp"] = empId;
            }
            var buss = Session["BuisnessId"].ToString();
            var salesHeaders = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var emp = Session["clickedEmp"] == null ? salesHeaders.First().EmployeeID : Session["clickedEmp"].ToString();
            var model = empId != "" ? salesHeaders.Where(s => s.EmployeeID == empId).FirstOrDefault().SalesOrderLine.ToList() : salesHeaders.Where(s => s.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            Session["CurrLineNo"] = model.First().LineNo;
            foreach (var data1 in model)
            {
                data1.VAT = dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                data1.Total = dp.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                if (data1.StyleImage.Contains(":"))
                {

                    var data = data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1);
                    if (System.IO.File.Exists(appPath + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1)) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage.Substring(data1.StyleImage.IndexOf(":") + 1, data1.StyleImage.Length - data1.StyleImage.IndexOf(":") - 1));
                    }
                }
                else
                {
                    if (System.IO.File.Exists(appPath + data1.StyleImage) != true)
                    {
                        data1.StyleImage = Url.Content("~/StyleImages/notfound.png");
                    }
                    else
                    {
                        data1.StyleImage = Url.Content("~/" + data1.StyleImage);
                    }
                }
            }
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

        #region GetCarriernReasons
        public ActionResult GetCarrierandreason()
        {
            ViewData["carrierFill"] = FillCarrierDropdown();
            ViewData["carrierStyleFill"] = FillCarrierStyle();
            return PartialView("model/_CarriageView");
        }
        #endregion

        #region cart Update

        [HttpPost, ValidateInput(false)]
        public ActionResult CartViewUpdate(Maximus.Models.SalesOrderHeaderViewModel item)
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
        public ActionResult CartViewDelete(Maximus.Models.SalesOrderHeaderViewModel item, string empId = "")
        {
            var model = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);

            if (item.EmployeeID != "" | empId != "")
            {
                try
                {
                    var dataColl = model.Where(x => x.EmployeeID == item.EmployeeID | x.EmployeeID.Trim() == empId.Trim()).ToList();
                    foreach (var data in dataColl)
                    {
                        model.Remove(data);
                    }
                    ViewData["headerCount"] = model.Count();
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
        public ActionResult CartviewDetailGridViewGridViewPartialUpdate(Maximus.Models.SalesOrderLineViewModel item)
        {
            var entQty = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault();
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            var model = result.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();
            string businessId = Session["BuisnessId"].ToString();

            if (ModelState.IsValid)
            {
                if (item.OrdQty.ToString().Trim() == "0")
                {
                    ViewData["EditError"] = "Quantity must be grater than 0";
                }
                else
                {
                    if (GetEntitlement(model.Where(x => x.OriginalLineNo == null).First().EntQty, model.Where(x => x.OriginalLineNo == null).First().ColourID, model.Where(x => x.OriginalLineNo == null).First().StyleID, item.OrdQty.ToString(), model.Where(x => x.OriginalLineNo == null).First().orgStyleId, item.LineNo))
                    {
                        try
                        {
                            foreach (var data in model)
                            {
                                var parentStyle = model.Where(s => s.LineNo == item.LineNo).First().StyleID;
                                var assemblyID = entity.tblasm_assemblyheader.Any(x => x.StyleID == parentStyle && x.CustID == businessId) ? entity.tblasm_assemblyheader.Where(x => x.StyleID == parentStyle && x.CustID == businessId).First().AssemblyID : 0;
                                var qty = assemblyID != 0 ? entity.tblasm_assemblydetail.Any(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID) ? entity.tblasm_assemblydetail.Where(x => x.StyleID == data.StyleID && x.AssemblyID == assemblyID).First().Qty.Value : 1 : 1;
                                data.OrdQty = qty * item.OrdQty;
                            }
                            foreach (var data1 in result.Where(x => x.LineNo == item.LineNo).ToList())
                            {
                                if(Session["Price"].ToString().ToLower()=="readwrite")
                                {
                                    data1.Price = item.Price == 0 ? data1.Price : item.Price;
                                    data1.VAT = dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                    data1.Total = dp.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                }
                                else
                                {
                                    data1.VAT = dp.GetlineVat(data1.OrdQty, data1.Price, data1.VatPercent);
                                    data1.Total = dp.GetlineTotals(data1.OrdQty, data1.Price, data1.VatPercent);
                                }
                                

                            }
                        }
                        catch (Exception e)
                        {
                            ViewData["EditError"] = e.Message;
                        }
                    }
                    else
                    {
                        ViewData["EditError"] = "Entitlement exceeded";
                    }
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_CartviewDetailGridViewGridViewPartial", result);
        }
        #endregion

        #region CartviewDetailGridViewGridViewPartialDelete
        [HttpPost, ValidateInput(false)]
        public ActionResult CartviewDetailGridViewGridViewPartialDelete(Maximus.Models.SalesOrderLineViewModel item)
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
        public ActionResult GridViewPartialAddNew(Maximus.Models.SalesOrderLineViewModel item)
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
        public ActionResult GridViewPartialUpdate(Maximus.Models.SalesOrderLineViewModel item)
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
            var FillAddressModel = new FillAddressModel();
            var result = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var data = Session["CUSTREFDEF"].ToString();
            var nomCode = Session["ONLINEDEFNOM"].ToString();
            FillAddressModel.BusAdd = result;
            FillAddressModel.custRef = data;
            FillAddressModel.nomCode = nomCode;
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FillAllAddress
        public JsonResult FillAllAddresswidCustRef(string custRef, int descAddId = 0, string adddesc = "", string comment = "", string nomCode = "", string nomCode1 = "", string nomCode2 = "", string nomCode3 = "", string nomCode4 = "")
        {
            string emp = "";
            var FillAddressModel = new FillAddressModel();
            var contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
            var result = descAddId == 0 ? adddesc == "" ? new BusAddress() : ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressDescription == adddesc).First() : ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var contactId = Convert.ToInt32(result.contactId);
            var data = entity.tblbus_contact.Any(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? entity.tblbus_contact.Where(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
            //Session["SelectedEmp"]

            var nomCoder = Session["ONLINEDEFNOM"].ToString();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            if (Session["clickedEmp"] == null || Session["clickedEmp"].ToString() == "")
            {
                mod.Last().AddressId = descAddId;
                mod.Last().DelAddress1 = result.Address1;
                mod.Last().DelAddress2 = result.Address2;
                mod.Last().DelAddress3 = result.Address3;
                mod.Last().DelCity = result.City;
                mod.Last().DelCountry = result.Country;
                mod.Last().DelDesc = result.AddressDescription;
                mod.Last().DelPostCode = result.PostCode;
                mod.Last().CustRef = data == "" ? custRef : data;
                mod.Last().CommentsExternal = comment;
                mod.Last().NomCode = nomCode;
                mod.Last().NomCode1 = nomCode1;
                mod.Last().NomCode2 = nomCode2;
                mod.Last().NomCode3 = nomCode3;
                mod.Last().NomCode4 = nomCode4;
                FillAddressModel.BusAdd = result;
                FillAddressModel.custRef = mod.Last().CustRef;
                FillAddressModel.nomCode = nomCoder;
                FillAddressModel.CommentExternal = mod.Last().CommentsExternal;
            }
            else
            {
                emp = Session["clickedEmp"].ToString();
                mod.Where(x => x.EmployeeID == emp.Trim()).First().AddressId = descAddId;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress1 = result.Address1;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress2 = result.Address2;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress3 = result.Address3;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCity = result.City;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCountry = result.Country;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelDesc = result.AddressDescription;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelPostCode = result.PostCode;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CustRef = data;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CommentsExternal = comment;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode = nomCode;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode1 = nomCode1;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode2 = nomCode2;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode3 = nomCode3;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().NomCode4 = nomCode4;
                FillAddressModel.BusAdd = result;
                FillAddressModel.custRef = mod.Where(x => x.EmployeeID == emp.Trim()).First().CustRef;
                FillAddressModel.nomCode = nomCoder;
                FillAddressModel.CommentExternal = mod.Where(x => x.EmployeeID == emp.Trim()).First().CommentsExternal;
            }
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SaveRefnAddress
        public void SaveRefnAddress(string custRef, int descAddId = 0, string adddesc = "", string comment = "")
        {
            string emp = "";
            var contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
            var result = descAddId == 0 ? adddesc == "" ? new BusAddress() : ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressDescription == adddesc).First() : ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var contactId = Convert.ToInt32(result.contactId);
            var data = entity.tblbus_contact.Any(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? entity.tblbus_contact.Where(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            if (Session["clickedEmp"] == null || Session["clickedEmp"].ToString() == "")
            {

                mod.Last().AddressId = descAddId;
                mod.Last().DelAddress1 = result.Address1;
                mod.Last().DelAddress2 = result.Address2;
                mod.Last().DelAddress3 = result.Address3;
                mod.Last().DelCity = result.City;
                mod.Last().DelCountry = result.Country;
                mod.Last().DelDesc = result.AddressDescription;
                mod.Last().DelPostCode = result.PostCode;
                mod.Last().CustRef = custRef;
                mod.Last().CommentsExternal = comment;

            }
            else
            {
                emp = Session["clickedEmp"].ToString();
                mod.Where(x => x.EmployeeID == emp.Trim()).First().AddressId = descAddId;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress1 = result.Address1;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress2 = result.Address2;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelAddress3 = result.Address3;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCity = result.City;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelCountry = result.Country;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelDesc = result.AddressDescription;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().DelPostCode = result.PostCode;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CustRef = custRef;
                mod.Where(x => x.EmployeeID == emp.Trim()).First().CommentsExternal = comment;
            }
        }
        #endregion

        #region AcceptOrders
        public JsonResult AcceptOrder(string addDesc)
        {
            int addressId = 0;
            bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            bool booCheck = true; bool booAutoConfirm = false; long mStackManPack = 0;
            bool optNew = false;
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
            string txtOrderNo = "0";
            BusAddress invAddress = new BusAddress();
            bool booEmpPointEntitleCheck = true;
            bool booPE = true;
            bool busBudgetReq = false;
            var ResultSet = new List<SaveOrderResultSet>();
            var AcceptResultSet = new AcceptResultSet();
            bool isPersonalOrder = false;
            double carriage = 0.0;
            List<SalesOrderHeaderViewModel> salesHeaderLst = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
            var header = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            TotalModel tot = new TotalModel();
            tot = tot = dp.GetAlltotals(salesHeaderLst, carriage);
            bool isRollOutOrder = Convert.ToBoolean(Session["RolloutOrder"]);
            bool booExistInManpack = false;
            Session["EditOrdContent"] = "";
            bool booStackOrder;
            bool overrideEntitlement = false;
            overrideEntitlement = Session["OverrideEnt"].ToString().ToUpper().Trim() == "SHOW" ? true : false;
            var lastObj = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();
            booStackOrder = Convert.ToBoolean(dp.BusinessParam("STACKORDERS", busId));
            if ((bool)Session["CusRefMan"])
            {
                if (salesHeaderLst.Any(x => x.CustRef == null || x.CustRef == ""))
                {
                    AcceptResultSet.results = ResultSet;
                    AcceptResultSet.type = "Po rference is Mandatory";
                    return Json(AcceptResultSet, JsonRequestBehavior.AllowGet);
                }
            }

            if (IsManpack)
            {
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count == 0)
                {

                }
            }
            if (booCheck)
            {
                if (isRollOutOrder == false)
                {
                    if (dp.CheckBudgetOrPoints(busId) == false)
                    {

                    }
                }
            }
            if (Convert.ToBoolean(Session["POINTSREQD"]) && Convert.ToBoolean(Session["RolloutOrder"]))
            {
                if (IsManpack == false)
                {

                }
                else
                {
                    foreach (var order in ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]))
                    {
                        foreach (var lines in order.SalesOrderLine)
                        {
                            if (lines.OrdQty == 0)
                            {
                                continue;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            var list = (List<BusAddress>)Session["DeliveryAddress"];
            long addid = 0;
            try
            {
                addid = Convert.ToInt64(addDesc);
            }
            catch
            {

            }
            addressId = list.Any(x => x.AddressDescription == addDesc) ? list.Where(x => x.AddressDescription == addDesc).First().AddressId : list.Any(x => x.AddressId == addid) ? list.Where(x => x.AddressId == addid).First().AddressId : 0;
            var sss = list.Any(x => x.AddressId == addressId);
            int myAddressID = 0, myContactID = 0, myCountryID = 0;
            myAddressID = addressId;
            myContactID = Convert.ToInt32(((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == addressId).First().contactId);
            myCountryID = Convert.ToInt32(((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == addressId).First().CountryCode);
            if (!isPersonalOrder)
            {
                string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID = '" + cmpId + "' Order By tblbus_address.Description";
                invAddress = dp.GetAddressDetails(SQL);
            }
            if (!CheckCarriage(tot))
            {
                //SetTempData()
                if (IsManpack)
                {
                    if (booStackOrder == false)
                    {
                        //dp.InsertManpackCarriage(lastObj, Session["CARRPRICE"].ToString());
                    }
                }
                else
                {
                    if (booStackOrder == false)
                    {
                        if (Convert.ToBoolean(dp.BusinessParam("CarrierPrompt", busId)))
                        {
                            //    Collaps_pnlCarriageReason.Collapsed = False
                            //    Collaps_pnlCarriageReason.ClientState = "false"
                            //    validateCarrStyle.Visible = True
                            //    lbl_crtxt.Visible = True
                            //    divData2.Style("display") = "block"
                            //    ClientScript.RegisterStartupScript(Me.GetType(), "hash", "location.hash = '#CElnk_finalusertitl';", True)
                        }
                        else
                        {
                            //    validateCarrStyle.Visible = False
                            //    divData2.Style("display") = "block"
                            //    Collaps_pnlCarriageReason.Collapsed = True
                            //    Collaps_pnlCarriageReason.ClientState = "true"
                            //    lbl_crtxt.Visible = False
                            if (Convert.ToInt32(txtOrderNo) > 0)
                            {
                                string sSqry = "SELECT * FROM tblsop_manpackorders WHERE OrderNo=" + txtOrderNo;
                                booExistInManpack = dp.GetBooValue(sSqry);
                            }
                            if (booExistInManpack == false)
                            {
                                //dp.InsertManpackCarriage(((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last());
                            }
                        }
                    }
                }
            }
            else
            {
                //    validateCarrStyle.Visible = False
                //divData2.Style("display") = "block"
            }

            if (Convert.ToInt32(txtOrderNo) == 0)
            {
                EditFlag = false;
            }
            else
            {
                EditFlag = true;
            }
            double currentBudget;
            if (IsManpack == false)
            {
                if (false == false)
                {
                    dp.displayOrderListGrid();
                }
            }
            else
            {
                if (salesHeaderLst.Count == 0)
                {
                    return Json(ResultSet, JsonRequestBehavior.AllowGet);
                }
                bool booOrderInfo = Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]);
                foreach (var salesHead in salesHeaderLst)
                {

                    if (Convert.ToBoolean(Session["CusRefMan"]))
                    {
                        if (salesHead.CustRef == "" || salesHead.CustRef == null)
                        {

                        }
                    }
                    if (Convert.ToBoolean(Session["NOMCODEMAN"]))
                    {
                        if (Convert.ToBoolean(Session["ONLNEREQNOM1"]))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(Session["ONLNEREQNOM2"]))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(Session["ONLNEREQNOM3"]))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(Session["ONLNEREQNOM4"]))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                        if (Convert.ToBoolean(Session["ONLNEREQNOM5"]))
                        {
                            if (salesHead.NomCode == "" || salesHead.NomCode == null)
                            {

                            }
                        }
                    }
                }
                if (booStackOrder == false)
                {

                }
                if (booStackOrder == false)
                {
                    intManPackNext = entity.tblgen_nextno.Where(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                }
                foreach (var salesHead in salesHeaderLst)
                {
                    string sSql = "";
                    booEmpPointEntitleCheck = overrideEntitlement ? overrideEntitlement : dp.EmpEntilementCheck(salesHead, busId, 0, IsManpack, false);
                    tblgen_nextno nextNo = new tblgen_nextno();
                    nextNo = entity.tblgen_nextno.Where(x => x.CompanyID == cmpId && x.ItemName == "SALE ORDER").First();
                    intSalesOrderNo = nextNo.AutoNumber.Value;
                    if (intSalesOrderNo > 0)
                    {
                        nextNo.AutoNumber = nextNo.AutoNumber.Value + 1;
                        entity.Entry(nextNo).State = System.Data.Entity.EntityState.Modified;
                        entity.SaveChanges();
                    }
                    if (salesHead.SalesOrderLine.Count > 0)
                    {
                        salesHead.InvDesc = invAddress.AddressDescription;
                        salesHead.InvAddress1 = invAddress.Address1;
                        salesHead.InvAddress2 = invAddress.Address2;
                        salesHead.InvAddress3 = invAddress.Address3;
                        salesHead.InvCity = invAddress.City;
                        salesHead.InvCountry = invAddress.Country;
                        salesHead.InvPostCode = invAddress.PostCode;
                        salesHead.InvTown = invAddress.Town;
                        if (Convert.ToBoolean(dp.BusinessParam("DEFEMPDELADDR", Session["BuisnessId"].ToString())) && booOrderInfo == false)
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelCountry;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelPostCode;
                            salesHead.CustRef = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                        }
                        else if (optNew && booOrderInfo == false)
                        {
                            salesHead.DelDesc = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelDesc;
                            salesHead.DelAddress1 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelAddress1;
                            salesHead.DelAddress2 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelAddress2;
                            salesHead.DelAddress3 = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelAddress3;
                            salesHead.DelCity = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelCity;
                            salesHead.DelCountry = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().DelCountry;
                            salesHead.DelPostCode = salesHeaderLst.Where(x => x.SalesOrderLine != null && x.SalesOrderLine.Count > 0).Last().CustRef;
                        }
                        if (isRollOutOrder)
                        {
                            if (salesHead.NomCode3 == null)
                            {
                                salesHead.NomCode3 = Session["RolloutName"].ToString();
                            }
                        }
                        salesHead.Carrier = Session["selectedcar"].ToString().Trim().Substring(0, Session["selectedcar"].ToString().Trim().IndexOf('|'));
                        salesHead.CarrierCharge = carriage;
                        salesHead.ReasonCode = 0;
                        if (dp.SaveSalesOrder(salesHead, intSalesOrderNo, busId, Session["UserName"].ToString(), EditFlag))
                        {

                            if (EditFlag == false)
                            {

                            }
                            else
                            {

                            }
                            if (isRollOutOrder)
                            {

                                var s = Session["RolloutName"].ToString();
                                if (!Convert.ToBoolean(dp.BusinessParam("ROLLOUT_CFM_ORDER", busId)))
                                {
                                    goto skip;
                                }
                            }

                            if (busBudgetReq == true)
                            {
                                if (booStackOrder == false)
                                {
                                    if (Convert.ToBoolean(dp.BusinessParam("AUTOCONFIRM", busId)))
                                    {

                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo });
                                    }
                                }
                            }
                            else if (Convert.ToBoolean(dp.BusinessParam("ONLEntExceed", busId)) && Convert.ToBoolean(dp.BusinessParam("REQALLOCEMAIL", busId)))
                            {
                                if (booStackOrder == false)
                                {
                                    if (Convert.ToBoolean(dp.BusinessParam("AUTOCONFIRM", busId)))
                                    {
                                        if (booEmpPointEntitleCheck)
                                        {
                                            sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + Session["UserName"] + "'  WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                            int res = dp.ExecuteQuerywidTrans(sSql);
                                            if (Convert.ToBoolean(Session["DELADDR_USER_CREATE"]))
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                            if (Convert.ToBoolean(Session["DELADDR_USER_CREATE"]))
                                            {
                                                sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + Session["UserName"] + "' WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                                dp.ExecuteQuerywidTrans(sSql);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                    }
                                }
                                else
                                {
                                    if (Convert.ToBoolean(dp.BusinessParam("AUTOCONFIRM", busId)))
                                    {

                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                                    }
                                }
                            }
                            else if (Convert.ToBoolean(dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm)
                            {

                                if (booStackOrder == false)
                                {
                                    if (booEmpPointEntitleCheck)
                                    {
                                        sSql = "UPDATE tblsop_salesorder_header SET OnlineConfirm=1, OnlineConfirmDate='" + salesHead.OrderDate + "', OnlineConfirmedBy='" + Session["UserName"] + "'  WHERE OrderNo=" + intSalesOrderNo + " AND CompanyID='" + cmpId + "'";
                                        int res = dp.ExecuteQuerywidTrans(sSql);
                                        if (Convert.ToBoolean(Session["DELADDR_USER_CREATE"]) == false)
                                        {
                                            ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "and also confirmed" });
                                        }


                                    }
                                    else
                                    {
                                        ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "\nOrder has not been Confirmed.\nEntitlement Exceed\n\n" });
                                    }
                                }
                                else
                                {

                                    ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });

                                }
                            }
                            else
                            {
                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "Order has not been confirmed" });
                            }
                            if (booStackOrder)
                            {
                                if (mStackManPack == -1)
                                {
                                    //intManPackNext=
                                }
                                else if (mStackManPack == -2)
                                {
                                    intManPackNext = entity.tblgen_nextno.Where(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                                }
                                else
                                {
                                    long checkManPack = dp.FindOpenManPackOrders(salesHead.DelDesc, salesHead.DelAddress1, salesHead.DelPostCode);
                                    if (checkManPack == 0)
                                    {
                                        intManPackNext = entity.tblgen_nextno.Where(x => x.CompanyID == cmpId && x.ItemName.ToUpper() == "MANPACK ORDER").First().AutoNumber.Value;
                                    }
                                    else if (checkManPack > 0)
                                    {
                                        intManPackNext = checkManPack;
                                    }
                                }
                            }
                            string sql = "";
                            if (Convert.ToBoolean(dp.BusinessParam("AUTOCONFIRM", busId)) || booAutoConfirm)
                            {
                                if (booStackOrder == false)
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm, OnlineConfirmDate, OnlineConfirmedBy)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + Session["UserName"].ToString() + "',1,'" + salesHead.OrderDate + "','" + Session["UserName"].ToString() + "')";
                                }
                                else
                                {
                                    sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + Session["UserName"].ToString() + "',0)";
                                }
                            }
                            else
                            {
                                sql = "INSERT INTO tblsop_manpackorders (CompanyID, ManPackNo, OrderNo, CustID, ManPackDate, OnlineUserID, OnlineConfirm)  VALUES ('" + cmpId + "'," + intManPackNext + "," + intSalesOrderNo + ",'" + busId + "','" + salesHead.OrderDate + "','" + Session["UserName"].ToString() + "',0)";
                            }
                            dp.ExecuteQuerywidTrans(sql);
                            skip:;
                            if (!ResultSet.Any(x => x.OrderNo == intSalesOrderNo))
                            {
                                ResultSet.Add(new SaveOrderResultSet { EmployeeId = salesHead.EmployeeID, OrderNo = intSalesOrderNo, OrderConfirmation = "" });
                            }

                        }

                    }
                    else
                    {
                        break;
                    }
                }
                if (ResultSet.Count > 0)
                {
                    Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                    Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                }
                AcceptResultSet.results = ResultSet;
                AcceptResultSet.type = "";
            }


            return Json(AcceptResultSet, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region checkCarriage
        public bool CheckCarriage(TotalModel tot)
        {
            bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
            bool checkCarriage = false;
            if (IsManpack == false)
            {
                if ((dp.checkBulkCarriageLine((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"])) == false)
                {
                    if ((int)Session["CARRPERCENT"] > 0)
                    {
                        checkCarriage = false;
                    }
                    else
                    {
                        if (Convert.ToDouble(tot.Total) < Convert.ToDouble(Session["CARRREQAMT"]))
                        {
                            checkCarriage = false;
                        }
                        else
                        {
                            checkCarriage = true;
                        }
                    }
                }
                else
                {
                    checkCarriage = true;
                }
            }
            else
            {
                if (dp.checkCarriageLine((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]) == false)
                {

                    if (Convert.ToDouble(Session["CARRPERCENT"]) > 0)
                    {
                        checkCarriage = false;
                    }
                    else
                    {
                        if (Convert.ToDouble(tot.Total) < Convert.ToDouble(Session["CARRREQAMT"]))
                        {
                            checkCarriage = false;
                        }
                        else
                        {
                            checkCarriage = true;
                        }
                    }
                }
                else
                {
                    checkCarriage = true;
                }
            }
            return checkCarriage;
        }
        #endregion

        #region GetCarriageStatus

        //public bool GetCarriageStatus()
        //{
        //    bool result = false;
        //    string emp = Session["SelectedEmp"].ToString();
        //    var modl = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x=>x.EmployeeID== emp).First();
        //    if (Convert.ToBoolean(Session["CarrierPrompt"]))
        //    {
        //       if(modl.Carrier!="")
        //        {

        //        }
                
        //    }
        //}

        #endregion

        #region GetNavigationUrl
        [HttpPost]
        public string GetNavigationUrl(string data, string addId, string cusrRef, string carr = "", string comment = "", string nomCode = "", string nomCode1 = "", string nomCode2 = "", string nomCode3 = "", string nomCode4 = "")
        {
            string returnUrl = "";
            try
            {
                int address = Convert.ToInt32(addId);
                if ((bool)Session["CusRefMan"])
                {
                    if (addId != "" && cusrRef != "" && data != null)
                    {
                        var salesHead = new SalesOrderHeaderViewModel();

                        salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();

                        var delAdd = ((List<BusAddress>)Session["DeliveryAddress"]).Any(x => x.AddressId == address) ? ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == address).First() : new BusAddress();
                        salesHead.DelAddress1 = delAdd.Address1;
                        salesHead.DelAddress2 = delAdd.Address2;
                        salesHead.DelAddress3 = delAdd.Address3;
                        salesHead.DelCity = delAdd.City;
                        salesHead.DelCountry = entity.tblbus_countrycodes.Where(x => x.Country == delAdd.Country).First().CountryID.ToString();
                        salesHead.DelDesc = delAdd.AddressDescription;
                        salesHead.DelPostCode = delAdd.PostCode;
                        salesHead.CustRef = cusrRef;
                        salesHead.Carrier = carr;
                        salesHead.AddressId = address;
                        salesHead.NomCode = nomCode;
                        salesHead.NomCode1 = nomCode1;
                        salesHead.NomCode2 = nomCode2;
                        salesHead.NomCode3 = nomCode3;
                        salesHead.NomCode4 = nomCode4;
                        salesHead.CommentsExternal = comment;
                        if (data == ">")
                        {
                            returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                        }
                        else if (data == "<")
                        {
                            returnUrl = "/Home/Index";
                        }
                    }
                }
                else
                {
                    if (addId != "" && data != null)
                    {
                        var salesHead = new SalesOrderHeaderViewModel();

                        salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();

                        var delAdd = ((List<BusAddress>)Session["DeliveryAddress"]).Any(x => x.AddressId == address) ? ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == address).First() : new BusAddress();
                        salesHead.DelAddress1 = delAdd.Address1;
                        salesHead.DelAddress2 = delAdd.Address2;
                        salesHead.DelAddress3 = delAdd.Address3;
                        salesHead.DelCity = delAdd.City;
                        salesHead.DelCountry = entity.tblbus_countrycodes.Where(x => x.Country == delAdd.Country).First().CountryID.ToString();
                        salesHead.DelDesc = delAdd.AddressDescription;
                        salesHead.DelPostCode = delAdd.PostCode;
                        salesHead.CustRef = cusrRef;
                        salesHead.Carrier = carr;
                        salesHead.AddressId = address;
                        salesHead.NomCode = nomCode;
                        salesHead.NomCode1 = nomCode1;
                        salesHead.NomCode2 = nomCode2;
                        salesHead.NomCode3 = nomCode3;
                        salesHead.NomCode4 = nomCode4;
                        salesHead.CommentsExternal = comment;
                        if (data == ">")
                        {
                            returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                        }
                        else if (data == "<")
                        {
                            returnUrl = "/Home/Index";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var salesHead = new List<SalesOrderHeaderViewModel>();
                var emp = Session["clickedEmp"].ToString();
                salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
                if (cusrRef != "" && comment != "")
                {
                    salesHead.Where(x => x.EmployeeID == emp).First().NomCode = nomCode;
                    salesHead.Where(x => x.EmployeeID == emp).First().NomCode1 = nomCode1;
                    salesHead.Where(x => x.EmployeeID == emp).First().NomCode2 = nomCode2;
                    salesHead.Where(x => x.EmployeeID == emp).First().NomCode3 = nomCode3;
                    salesHead.Where(x => x.EmployeeID == emp).First().NomCode4 = nomCode4;
                    salesHead.Where(x => x.EmployeeID == emp).First().CustRef = cusrRef;
                    salesHead.Where(x => x.EmployeeID == emp).First().CommentsExternal = comment;
                }
                if (salesHead.Any(x => x.AddressId == 0 || x.CustRef == ""))
                {

                }
                else
                {
                    if (data == ">")
                    {
                        returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                    }
                    else if (data == "<")
                    {
                        returnUrl = "/Home/Index";
                    }
                }
            }
            return returnUrl;
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

        #region FillHeaderDetails
        [HttpPost]
        public JsonResult FillHeaderDetails(string key)
        {
            Session["SelectedRowEmp"] = key.Trim();
            double orgTotal;
            double assemTotal;
            double totalVat = 0.0;
            double Total = 0.0;
            double vat;
            double carriage = 0.0;
            var result = new SalesOrderHeaderViewModel();
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            foreach (var header in mod.Where(x => x.SalesOrderLine != null))
            {
                orgTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Sum(x => x.Price) : 0.0 : 0.0;
                assemTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 && header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Sum(x => x.Price) : 0.0 : 0.0;
                Total = Total + orgTotal + assemTotal;
                foreach (var line in header.SalesOrderLine)
                {
                    double VatPercent = line.VatPercent;
                    ViewBag.VatPercent = VatPercent;
                    double lineVat = line.OrdQty != 0 ? ((line.OrdQty * line.Price) * VatPercent) / 100 : 0.0;
                    totalVat = totalVat + lineVat;
                }

            }
            ViewBag.carriage = Math.Round(carriage, 2);
            ViewBag.ordeTotal = Math.Round(Total + carriage, 2);
            ViewBag.totalVat = Math.Round(totalVat, 2);
            ViewBag.Total = Math.Round(Total, 2);
            ViewBag.GrossTotal = Math.Round(totalVat + Total, 2);
            result = mod.Any(x => x.EmployeeID.Trim() == key.Trim()) ? mod.Where(x => x.EmployeeID.Trim() == key.Trim()).First() : new SalesOrderHeaderViewModel();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region GetEntitlementValue
        public bool GetEntitlement(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "", long lineNo = 0)
        {
            bool result = false;
            if (qty.Trim() != "0")
            {
                string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
                string busId = "";
                string empId = "";
                var issuedDiff = 0;
                var salesOrderLines = ((List<SalesOrderLineViewModel>)Session["SalesOrderLines"]).Where(X => X.orgStyleId != null).ToList();
                var onCartLst = salesOrderLines.Where(x => x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()).ToList();
                var onCartVal = onCartLst.Sum(x => x.OrdQty).ToString();

                if (color != "" & style != "" & qty != "")
                {
                    int difference = 0;
                    //int oQty = Convert.ToInt32(ordQty);
                    var entitlement = entity.tblaccemp_ucodes.Any(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? entity.tblaccemp_ucodes.Where(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                    var issuedLst = entity.tblaccemp_stockcard.Any(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()) ? entity.tblaccemp_stockcard.Where(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
                    var issued = 0;
                    if (Convert.ToInt32(qty) <= entitlement.Value)
                    {
                        if (Convert.ToInt32(onCartVal) <= entitlement)
                        {

                            var lineOrd = salesOrderLines.Where(x => x.LineNo == lineNo).First().OrdQty;
                            var anotherOrd = Convert.ToInt32(onCartVal) - lineOrd;
                            var newCart = anotherOrd + Convert.ToInt32(qty);
                            if (newCart > entitlement)
                            {
                                return false;
                            }
                            else if (newCart <= entitlement)
                            {
                                return true;
                            }
                        }
                        if (issuedLst.Count > 0)
                        {
                            foreach (var data in issuedLst)
                            {
                                issued = issued + data.Invqty + data.Pickqty + data.SOqty;
                            }
                        }
                        else
                        {
                            issued = 0;
                        }
                        if (entitlement != 0)
                        {
                            issuedDiff = entitlement.Value - issued;
                        }
                        if (Convert.ToInt32(onCartVal) != 0)
                        {
                            if (Convert.ToInt32(onCartVal) != Convert.ToInt32(qty))
                            {
                                issuedDiff = (int)issuedDiff - Convert.ToInt32(onCartVal);
                            }
                        }

                        if (issuedDiff > 0)
                        {
                            result = Convert.ToInt32(qty) <= issuedDiff ? true : false;
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region EmployeeView
        public ActionResult EmployeeView()
        {
            var result = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            return PartialView("model/_EmployeeView", result);
        }
        #endregion

        #region CartDetailEdit
        public JsonResult CartDetailEdit(string empId)
        {

            Session["clickedEmp"] = empId;
            string busId = Session["BuisnessId"].ToString();
            var contactType = 0;
            var resultq = new BusAddress();
            var contactId = 0;
            List<double> varpercents = new List<double>();
            var resultAdd = dp.GetDeliveryAddressId(empId, busId);
            double orgTotal = 0.0;
            double assemTotal = 0.0;
            double Total = 0.0;
            double totalVat = 0.0;
            List<double> vatPercents = new List<double>();
            double carriage = 0.0;
            var custRef = "";
            var result1 = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            TotalModel tot = new TotalModel();
            tot = dp.GetAlltotals(result1.Where(x => x.SalesOrderLine != null && x.EmployeeID == empId).ToList(), carriage);
            var salesHead = result1.Any(x => x.EmployeeID == empId) ? result1.Where(x => x.EmployeeID == empId).First() : new SalesOrderHeaderViewModel();
            var FillAddressModel = new FillAddressModel();
            var descAddId = result1.Where(x => x.EmployeeID == empId).First().AddressId;
            var result = new BusAddress();
            if (descAddId == 0)
            {
                if (((List<BusAddress>)Session["DeliveryAddress"]).Any(x => x.AddressId == resultAdd))
                {
                    result = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == resultAdd).First();
                }
                else if (((List<BusAddress>)Session["DeliveryAddress"]).Any(x => x.AddressId == descAddId))
                {
                    result = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
                }
            }
            var busAdd = new BusAddress();
            if (salesHead.AddressId > 0)
            {
                var addRes = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == salesHead.AddressId).First();
                busAdd.AddressId = salesHead.AddressId;
                busAdd.Address1 = salesHead.DelAddress1;
                busAdd.Address2 = salesHead.DelAddress2;
                busAdd.Address3 = salesHead.DelAddress3;
                busAdd.City = salesHead.DelCity;
                busAdd.Country = salesHead.DelCountry;
                busAdd.PostCode = salesHead.DelPostCode;
                busAdd.AddressDescription = salesHead.DelDesc;
                var contact = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
                var res = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == salesHead.AddressId).First();
                var conta = Convert.ToInt32(res.contactId);
                custRef = entity.tblbus_contact.Any(x => x.ContactID == conta && x.ContactType_ID == contact) ? entity.tblbus_contact.Where(x => x.ContactID == conta && x.ContactType_ID == contact).First().Value : "";
            }
            var data = result1.Where(x => x.EmployeeID == empId).First().CustRef;
            var nomCode = Session["ONLINEDEFNOM"].ToString();
            if (Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]))
            {
                FillAddressModel.BusAdd = busAdd.AddressId == 0 ? result : busAdd;
                FillAddressModel.custRef = salesHead.CustRef == "" || salesHead.CustRef == null ? custRef : salesHead.CustRef;
            }
            else
            {
                FillAddressModel.BusAdd = busAdd;
                FillAddressModel.custRef = salesHead.CustRef;
                var s = Convert.ToBoolean(Session["DIFF_MANPACK_INFO"]);
            }
            FillAddressModel.nomCode = salesHead.NomCode == "" | salesHead.NomCode == null ? nomCode : salesHead.NomCode;
            FillAddressModel.nomCode1 = salesHead.NomCode1 == "" | salesHead.NomCode1 == null ? nomCode : salesHead.NomCode1;
            FillAddressModel.nomCode2 = salesHead.NomCode2 == "" | salesHead.NomCode2 == null ? nomCode : salesHead.NomCode2;
            FillAddressModel.nomCode3 = salesHead.NomCode3 == "" | salesHead.NomCode3 == null ? nomCode : salesHead.NomCode3;
            FillAddressModel.nomCode4 = salesHead.NomCode4 == "" | salesHead.NomCode4 == null ? nomCode : salesHead.NomCode4;
            FillAddressModel.VatPercent = tot.vatSpan;
            FillAddressModel.carriage = tot.carriage;
            FillAddressModel.ordeTotal = tot.ordeTotal;
            FillAddressModel.totalVat = tot.totalVat;
            FillAddressModel.Total = tot.Total;
            FillAddressModel.GrossTotal = tot.gross;
            FillAddressModel.CommentExternal = salesHead.CommentsExternal;
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPrice
        public JsonResult GetPrice()
        {
            var result1 = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            string empId = Session["clickedEmp"] == null ? result1.First().EmployeeID : Session["clickedEmp"].ToString();
            string busId = Session["BuisnessId"].ToString();
            var resultq = new BusAddress();
            List<double> varpercents = new List<double>();
            var resultAdd = dp.GetDeliveryAddressId(empId, busId);
            List<double> vatPercents = new List<double>();
            double carriage = 0.0;

            TotalModel tot = new TotalModel();
            var FillAddressModel = new FillAddressModel();
            tot = dp.GetAlltotals(result1.Where(x => x.SalesOrderLine != null && x.EmployeeID == empId).ToList(), carriage);
            FillAddressModel.VatPercent = tot.vatSpan;
            FillAddressModel.carriage = tot.carriage;
            FillAddressModel.ordeTotal = tot.ordeTotal;
            FillAddressModel.totalVat = tot.totalVat;
            FillAddressModel.Total = tot.Total;
            FillAddressModel.GrossTotal = tot.gross;
            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }


}


////calculation part in the basket


//foreach (var header in mod.Where(x => x.SalesOrderLine != null && x.EmployeeID == emp))
//{
//    orgTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Sum(x => x.Price).Value : 0.0 : 0.0;
//   long orgTotalQty = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).First().OrdQty.Value:0;
//    assemTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 && header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Sum(x => x.Price).Value : 0.0 : 0.0;
//    Total = Total +( orgTotal* orgTotalQty) +( assemTotal* orgTotalQty);
//    foreach (var line in header.SalesOrderLine)
//    {
//        double VatPercent = line.VatPercent;
//        varpercents.Add(VatPercent);
//        double lineVat = line.OrdQty.Value != 0 ? ((line.OrdQty.Value * line.Price.Value) * VatPercent) / 100 : 0.0;
//        totalVat = totalVat + lineVat;
//    }
//}
//string vatSpan = "";
//foreach (var vats in varpercents.Distinct())
//{
//    vatSpan = vatSpan + vats + "% \n";
//}