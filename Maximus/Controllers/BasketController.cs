using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;
using Maximus.Filter;
using System.Configuration;

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
            //dp.FillCombo_CustomerDelivery();
            double orgTotal;
            double assemTotal;
            double totalVat = 0.0;
            double Total = 0.0;
            double vat;
            double carriage = 0.0;
            string busId = Session["BuisnessId"].ToString();
            string emp = Session["SelectedEmp"].ToString();
            var contactType = 0;
            var resultq = new BusAddress();
            var contactId = 0;
            var data = "";
            var result = dp.GetDeliveryAddressId(emp, busId);
            var mod = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            Session["cboDelAddressDesc"] = "";
            Session["CustRef"] = "";
            if (result > 0)
            {
                Session["cboDelAddress"] = result;
                Session["cboDelAddressDesc"] = entity.tblbus_address.Any(x => x.AddressID == result && x.BusinessID == busId) ? entity.tblbus_address.Where(x => x.AddressID == result && x.BusinessID == busId).First().Description : "";
                if (Session["cboDelAddressDesc"].ToString() == "")
                {
                    var res = mod.Any(x => x.SalesOrderLine != null && x.AddressId != 0) ? mod.Where(x => x.SalesOrderLine != null && x.AddressId != 0).Last().AddressId : 0;
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
            foreach (var header in mod.Where(x => x.SalesOrderLine != null))
            {
                orgTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Sum(x => x.Price).Value : 0.0 : 0.0;
                assemTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 && header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Sum(x => x.Price).Value : 0.0 : 0.0;
                Total = Total + orgTotal + assemTotal;
                foreach (var line in header.SalesOrderLine)
                {
                    double VatPercent = line.VatPercent;
                    ViewBag.VatPercent = VatPercent;
                    double lineVat = line.OrdQty.Value != 0 ? ((line.OrdQty.Value * line.Price.Value) * VatPercent) / 100 : 0.0;
                    totalVat = totalVat + lineVat;
                }

            }
            ViewBag.carriage = carriage;
            ViewBag.ordeTotal = Total + carriage;
            ViewBag.totalVat = totalVat;
            ViewBag.Total = Total;
            ViewBag.GrossTotal = totalVat + Total;
            if (carr.Count > 0)
            {
                ViewData["carrierFill"] = carr;
                foreach (var item in carr)
                {
                    if (item.Contains(Session["Carrier"].ToString()))
                    {
                        ViewData["selectedcar"] = item;
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
            if (empId != "")
            {
                Session["thisEmp"] = empId;
            }

            var buss = Session["BuisnessId"].ToString();
            var emp = Session["SelectedEmp"].ToString();
            var salesHeaders = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var model = empId != "" ? salesHeaders.Where(s => s.EmployeeID == empId).FirstOrDefault().SalesOrderLine.ToList() : salesHeaders.Where(s => s.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            Session["CurrLineNo"] = model.First().LineNo;
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
        public ActionResult CartViewDelete(Maximus.Models.SalesOrderHeaderViewModel item)
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
        public ActionResult CartviewDetailGridViewGridViewPartialUpdate(Maximus.Models.SalesOrderLineViewModel item)
        {
            var entQty = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault();
            var result = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["thisEmp"].ToString()).FirstOrDefault().SalesOrderLine.ToList();
            var model = result.Where(x => x.LineNo == item.LineNo | x.OriginalLineNo == item.LineNo).ToList();
            string businessId = Session["BuisnessId"].ToString();

            if (ModelState.IsValid)
            {
                if (GetEntitlement(model.Where(x => x.OriginalLineNo == null).First().EntQty, model.Where(x => x.OriginalLineNo == null).First().ColourID,item.OrdQty.ToString(), model.Where(x => x.OriginalLineNo == null).First().orgStyleId))
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
                {
                    ViewData["EditError"] = "Entitlement exceeded";
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
            var nomCode = (bool)Session["DEFDELREFNOM"] == false ? "" : Session["ONLINEDEFNOM"].ToString();
            FillAddressModel.BusAdd = result;
            FillAddressModel.custRef = data;
            FillAddressModel.nomCode = nomCode;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FillAllAddress
        public JsonResult FillAllAddresswidCustRef(int descAddId)
        {
            var FillAddressModel = new FillAddressModel();
            var contactType = Convert.ToInt32(ConfigurationManager.AppSettings["ContactType_Id"].ToString());
            var result = ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == descAddId).First();
            var contactId = Convert.ToInt32(result.contactId);
            var data = entity.tblbus_contact.Any(x => x.ContactID == contactId && x.ContactType_ID == contactType) ? entity.tblbus_contact.Where(x => x.ContactID == contactId && x.ContactType_ID == contactType).First().Value : "";

            FillAddressModel.BusAdd = result;
            FillAddressModel.custRef = data;
            FillAddressModel.nomCode = data;
            //Session["SelectedEmp"]

            return Json(FillAddressModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AcceptOrders
        public ActionResult AcceptOrder(int addressId, string txtTotalGoods, string txtOrderNo)
        {
            bool IsManpack = Convert.ToBoolean(Session["IsManPack"]);
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
            bool booEmpPointEntitleCheck = true;
            bool booPE = true;
            bool isPersonalOrder = false;
            bool isRollOutOrder = Convert.ToBoolean(Session["RolloutOrder"]);
            bool booExistInManpack = false;
            Session["EditOrdContent"] = "";
            bool booStackOrder;
            var lastObj = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();
            booStackOrder = Convert.ToBoolean(dp.BusinessParam("STACKORDERS", busId));
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
            var sss = list.Any(x => x.AddressId == addressId);
            int myAddressID = 0, myContactID = 0, myCountryID = 0;
            myAddressID = addressId;
            myContactID = Convert.ToInt32(((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == addressId).First().contactId);
            myCountryID = Convert.ToInt32(((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == addressId).First().CountryCode);
            if (!isPersonalOrder)
            {

                string SQL = "SELECT tblbus_address.Description, tblbus_address.Address1, tblbus_address.Address2, tblbus_address.Address3, tblbus_address.Town, tblbus_address.City, tblbus_address.Postcode, tblbus_countrycodes.Country, tblbus_address.countrycode  FROM tblbus_countrycodes INNER JOIN (tblbus_addresstype_ref INNER JOIN (tblbus_business INNER JOIN (tblbus_addresstypes INNER JOIN tblbus_address ON tblbus_addresstypes.AddressTypeID = tblbus_address.AddressTypeID) ON tblbus_business.BusinessID = tblbus_address.BusinessID) ON tblbus_addresstype_ref.Actual_TypeID = tblbus_addresstypes.Actual_TypeID) ON tblbus_countrycodes.CountryID = tblbus_address.CountryCode  WHERE tblbus_addresstype_ref.Actual_TypeID=3 AND tblbus_business.BusinessID='" + busId + "' and tblbus_countrycodes.CompanyID = '" + cmpId + "' Order By tblbus_address.Description";
                var data = dp.GetAddressDetails(SQL);
            }
            if (!CheckCarriage(txtTotalGoods))
            {
                //SetTempData()
                if (IsManpack)
                {
                    if (booStackOrder == false)
                    {
                        dp.InsertManpackCarriage(lastObj, Session["CARRPRICE"].ToString());
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
                                dp.InsertManpackCarriage(((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last());
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
                if (dp.SetSalesHeader() == false)
                {
                    dp.displayOrderListGrid();
                }
            }
            return View();
        }

        #endregion

        #region checkCarriage
        public bool CheckCarriage(string txtTotalGoods)
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
                        if (Convert.ToDouble(txtTotalGoods) < Convert.ToDouble(Session["CARRREQAMT"]))
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

                    if ((int)Session["CARRPERCENT"] > 0)
                    {
                        checkCarriage = false;
                    }
                    else
                    {
                        if (Convert.ToDouble(txtTotalGoods) < Convert.ToDouble(Session["CARRREQAMT"]))
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

        #region GetNavigationUrl
        [HttpPost]
        public string GetNavigationUrl(string data, string addId, string cusrRef, string carr = "")
        {
            string returnUrl = "";
            int address = Convert.ToInt32(addId);

            if (addId != "" && cusrRef != "" && data != null)
            {
                var salesHead = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Last();
                var delAdd = ((List<BusAddress>)Session["DeliveryAddress"]).Any(x => x.AddressId == address) ? ((List<BusAddress>)Session["DeliveryAddress"]).Where(x => x.AddressId == address).First() : new BusAddress();
                salesHead.DelAddress1 = delAdd.Address1;
                salesHead.DelAddress2 = delAdd.Address2;
                salesHead.DelAddress3 = delAdd.Address3;
                salesHead.DelCity = delAdd.City;
                salesHead.DelCountry = delAdd.Country;
                salesHead.DelDesc = delAdd.AddressDescription;
                salesHead.DelPostCode = delAdd.PostCode;
                salesHead.CustRef = cusrRef;
                salesHead.Carrier = carr;
                salesHead.AddressId = address;
                if (data == ">")
                {
                    returnUrl = "/Employee/Index?BusinessId=" + Session["BuisnessId"].ToString();
                }
                else if (data == "<")
                {
                    returnUrl = "/Home/Index";
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
                orgTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo == null).Sum(x => x.Price).Value : 0.0 : 0.0;
                assemTotal = header.SalesOrderLine != null && header.SalesOrderLine.Count > 0 && header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Any(x => x.Price != 0 && x.Price != null) ? header.SalesOrderLine.Where(x => x.OriginalLineNo != null).Sum(x => x.Price).Value : 0.0 : 0.0;
                Total = Total + orgTotal + assemTotal;
                foreach (var line in header.SalesOrderLine)
                {
                    double VatPercent = line.VatPercent;
                    ViewBag.VatPercent = VatPercent;
                    double lineVat = line.OrdQty.Value != 0 ? ((line.OrdQty.Value * line.Price.Value) * VatPercent) / 100 : 0.0;
                    totalVat = totalVat + lineVat;
                }

            }
            ViewBag.carriage = carriage;
            ViewBag.ordeTotal = Total + carriage;
            ViewBag.totalVat = totalVat;
            ViewBag.Total = Total;
            ViewBag.GrossTotal = totalVat + Total;
            result = mod.Any(x => x.EmployeeID.Trim() == key.Trim()) ? mod.Where(x => x.EmployeeID.Trim() == key.Trim()).First() : new SalesOrderHeaderViewModel();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region GetEntitlementValue
        public bool GetEntitlement(string ordQty = "", string color = "", string style = "", string qty = "", string orgStyl = "")
        {
            bool result = false;
            string Ucodes = Session["SelectedUcode"] != null ? Session["SelectedUcode"].ToString() : "";
            string busId = "";
            string empId = "";
            var issuedDiff = 0;
            var salesOrderLines = ((List<SalesOrderLineViewModel>)Session["SalesOrderLines"]).Where(X => X.orgStyleId != null).ToList();
            var onCartLst = salesOrderLines.Where(x => x.orgStyleId.Trim().ToLower() == orgStyl.Trim().ToLower()).ToList();
            var onCartVal = onCartLst.Sum(x => x.OrdQty);
            if (ordQty != "" & color != "" & style != "" & qty != "")
            {
                int difference = 0;
                int oQty = Convert.ToInt32(ordQty);
                var entitlement = entity.tblaccemp_ucodes.Any(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes) ? entity.tblaccemp_ucodes.Where(x => x.StyleID.ToLower().Trim() == orgStyl.ToLower().Trim() && x.UCodeID == Ucodes).FirstOrDefault().AnnualIssue : 0;
                var issuedLst = entity.tblaccemp_stockcard.Any(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()) ? entity.tblaccemp_stockcard.Where(x => x.BusinessID == busId && x.ColourID.Trim().ToLower() == color.Trim().ToLower() && x.EmployeeID == empId && x.Year == 0 && x.StyleID.Trim().ToLower() == orgStyl.Trim().ToLower()).Select(x => new IssuedQtyModel { Invqty = x.InvQty.Value, SOqty = x.SOQty.Value, Pickqty = x.PickQty.Value }).ToList() : new List<IssuedQtyModel>();
                var issued = 0;
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
                if (onCartVal != 0)
                {
                    issuedDiff = (int)issuedDiff - (int)onCartVal;
                }

                if (issuedDiff > 0)
                {
                    result = Convert.ToInt32(qty) <= issuedDiff ? true : false;
                }
            }
            return result;
        }
    }
    #endregion
}
