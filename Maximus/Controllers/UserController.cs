using Maximus.Filter;
using Maximus.Helpers;
using Maximus.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maximus.Controllers
{
    public class UserController : Controller
    {
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        DataProcessing dp = new DataProcessing();
        ControllerHelperMethods helper = new ControllerHelperMethods();
        // GET: User
        public ActionResult Login()
        {
            Session.Clear();
            if (Request.Cookies["Username"] != null)
            {
                Response.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel logDetails)
        {
            if (ModelState.IsValid)
            {
                if (logDetails.UserName != "" & logDetails.Password != "")
                {
                    List<EmployeeLoginModel> data = dp.GetLoginDetails(logDetails.UserName, logDetails.Password);
                    if (data.Count > 0)
                    {
                        if (data.Any(x => x.UserName.ToLower() == logDetails.UserName.ToLower() && x.Password == logDetails.Password && x.Active.ToLower() == "y"))
                        {
                            string custrefdef = "";
                            string onlineDefNom = "";
                            string booNom = "";
                            string booDefDelAddr = "";
                            string booDefDelRef = "";
                            string booDivBudget = "";
                            string booDefNomCode = "";
                            string booBudgetEmail = "";
                            string booCusRefMan = "";
                            string booPointsReq = "";
                            string booDespConfirm = "";
                            string booRea = "";
                            string booCmpRea = "";
                            string strDefNomCode = "";
                            string mMonthsAgo = "";
                            string booStkLevel = "";
                            string VInfo = "";
                            bool booVinfo = false;
                            string busId = "";
                            string startPage = "";
                            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
                            Session["CmpId"] = cmpId;
                            Session["UserName"] = data.First().UserName;
                            Session["Password"] = data.First().Password;
                            Session["Name"] = data.First().ForeName + " " + data.First().SurName;
                            Session["Access"] = data.First().AccessID;
                            Session["Email"] = data.First().Email_ID;
                            busId = data.First().BusinessID;
                            Session["BuisnessId"] = data.First().BusinessID;
                            Session["Buisness"] = entity.tblbus_business.Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).First().Name;
                            Session["WareHouseID"] = dp.SetDefaultWarehouse(logDetails.UserName, data.First().BusinessID);
                            Session["UseMatrix"] = dp.CompanyParam("UseMatrix", cmpId);
                            Session["BudgetReq"] = dp.CompanyParam("BUDGETREQ", cmpId);
                            Session["MANPACK"] = dp.BusinessParam("MANPACK", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRREQAMT"] = dp.BusinessParam("CARRREQAMT", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPRICE"] = dp.BusinessParam("CARRPRICE", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPERCENT"] = dp.BusinessParam("CARRPERCENT", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPRICE_RTN"] = dp.BusinessParam("CARRPRICE_RTN", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPRICE_XCHG"] = dp.BusinessParam("CARRPRICE_XCHG", data.First().BusinessID.ToUpper().Trim());
                            Session["BusBudgetReq"] = dp.BusinessParam("BUDGETREQ", data.First().BusinessID.ToUpper().Trim());
                            Session["DEFEMPDELADDR"] = dp.BusinessParam("DEFEMPDELADDR", data.First().BusinessID.ToUpper().Trim());
                            Session["ABANDON_EMP"] = dp.BusinessParam("ABANDON_EMP", data.First().BusinessID.ToUpper().Trim());
                            Session["DELADDR_SAVE"] = dp.BusinessParam("DELADDR_SAVE", data.First().BusinessID.ToUpper().Trim());
                            Session["ONL_REORDER_REQ"] = dp.BusinessParam("ONL_REORDER_REQ", data.First().BusinessID.ToUpper().Trim());
                            booNom = dp.CompanyParam("ONLNEREQNOM1", cmpId);
                            Session["ONLNEREQNOM1"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = dp.CompanyParam("ONLNEREQNOM2", cmpId);
                            Session["ONLNEREQNOM2"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = dp.CompanyParam("ONLNEREQNOM3", cmpId);
                            Session["ONLNEREQNOM3"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = dp.CompanyParam("ONLNEREQNOM4", cmpId);
                            Session["ONLNEREQNOM4"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = dp.CompanyParam("ONLNEREQNOM5", cmpId);
                            Session["ONLNEREQNOM5"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booDefDelAddr = dp.BusinessParam("DEFINVADDR", data.First().BusinessID.Trim().ToUpper());
                            Session["DEFINVADDR"] = booDefDelAddr == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booDefDelRef = dp.BusinessParam("DELREFREQ", data.First().BusinessID.Trim().ToUpper());
                            Session["DELREFREQ"] = booDefDelRef == "" ? false : booDefDelRef.ToLower() == "true" ? true : false;
                            onlineDefNom = dp.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["CUSTREFDEF"] =dp.BusinessParam("CUSTREFDEF", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOM"] = onlineDefNom;
                            booDefNomCode = dp.BusinessParam("DEFDELREFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["DEFDELREFNOM"] = booDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booDivBudget = dp.BusinessParam("REQDIVBUDGET", data.First().BusinessID.Trim().ToUpper());
                            Session["REQDIVBUDGET"] = booDivBudget == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            strDefNomCode = dp.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOM"] = strDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booBudgetEmail = dp.BusinessParam("REQBUDGETEMAIL", data.First().BusinessID.Trim().ToUpper());
                            Session["REQBUDGETEMAIL"] = booBudgetEmail == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booPointsReq = dp.BusinessParam("POINTSREQ", data.First().BusinessID.Trim().ToUpper());
                            Session["POINTSREQD"] = booPointsReq == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booCusRefMan = dp.BusinessParam("CusRefMan", data.First().BusinessID.Trim().ToUpper());
                            Session["CusRefMan"] = booCusRefMan == "" ? false : booCusRefMan.ToLower() == "true" ? true : false;
                            booRea = dp.BusinessParam("SOPREAREQ", data.First().BusinessID.Trim().ToUpper());
                            if (booRea != "")
                            {
                                Session["SOPREAREQ"] = booRea == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            }
                            else
                            {
                                booCmpRea = dp.CompanyParam("SOPREAREQ", cmpId);
                                Session["SOPREAREQ"] = booCmpRea == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            }
                            //booStkLevel = dp.BusinessParam("REQSTKLEVEL", Session["BuisnessId"].ToString());
                            //Session["REQSTKLEVEL"] = booStkLevel == "" ? false : Convert.ToBoolean(booStkLevel);
                            Session["DEFEMPLOYEE"] = dp.DefaultEmployee(ConfigurationSettings.AppSettings["CompanyId"].ToString(), Session["UserName"].ToString().Trim().ToUpper(), Session["BuisnessId"].ToString().ToUpper());
                            booDespConfirm = dp.BusinessParam("CHKDISPCONFIRM", Session["BuisnessId"].ToString().ToUpper());
                            Session["CHKDISPCONFIRM"] = booDespConfirm == "" ? false : Convert.ToBoolean(Session["CHKDISPCONFIRM"]);
                            mMonthsAgo = dp.BusinessParam("MONTHAGO_RT", Session["BuisnessId"].ToString().ToUpper());
                            Session["MONTHAGO_RT"] = mMonthsAgo == "" ? 1 : Convert.ToInt32(mMonthsAgo);
                            if (dp.CompanyParam("CUSPRODCODE", ConfigurationSettings.AppSettings["CompanyId"].ToString()) != "")
                            {
                                Session["CusProdCode"] = Convert.ToBoolean(dp.CompanyParam("CUSPRODCODE", ConfigurationSettings.AppSettings["CompanyId"].ToString()));
                            }
                            else
                            {
                                Session["CusProdCode"] = false;
                            }
                            // Session["colLines"]=colline
                            Session["IsVisitPrivate"] = false;

                            Session["chkMapEmp"] = dp.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapEmp", Session["Access"].ToString());
                            Session["chkMapAddr"] = dp.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapAddr", Session["Access"].ToString());
                            Session["OVERRIDE_ENT_WITH_REASON"] = dp.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "OVERRIDE_ENT_WITH_REASON", Session["Access"].ToString());
                            Session["ONLNEREQNOM1"] = dp.CompanyParam("ONLNEREQNOM1", cmpId);
                            Session["ONLNEREQNOM2"] = dp.CompanyParam("ONLNEREQNOM2", cmpId);
                            Session["ONLNEREQNOM3"] = dp.CompanyParam("ONLNEREQNOM3", cmpId);
                            Session["ONLNEREQNOM4"] = dp.CompanyParam("ONLNEREQNOM4", cmpId);
                            Session["ONLNEREQNOM5"] = dp.CompanyParam("ONLNEREQNOM5", cmpId);
                            Session["ONLNEDEFNOM1"] = dp.CompanyParam("ONLNEDEFNOM1", cmpId);
                            Session["ONLNEDEFNOM2"] = dp.CompanyParam("ONLNEDEFNOM2", cmpId);
                            Session["ONLNEDEFNOM3"] = dp.CompanyParam("ONLNEDEFNOM3", cmpId);
                            Session["ONLNEDEFNOM4"] = dp.CompanyParam("ONLNEDEFNOM4", cmpId);
                            Session["ONLNEDEFNOM5"] = dp.CompanyParam("ONLNEDEFNOM5", cmpId);
                            Session["ONLNETXTNOM1"] = dp.BusinessParam("ONLNETXTNOM1", busId);
                            Session["ONLNETXTNOM2"] = dp.BusinessParam("ONLNETXTNOM2", busId);
                            Session["ONLNETXTNOM3"] = dp.BusinessParam("ONLNETXTNOM3", busId);
                            Session["ONLNETXTNOM4"] = dp.BusinessParam("ONLNETXTNOM4", busId);
                            Session["ONLNETXTNOM5"] = dp.BusinessParam("ONLNETXTNOM5", busId);
                            Session["IsManPack"] = true;
                            SalesOrderHeaderViewModel saleHeads = new SalesOrderHeaderViewModel();
                            Session["objCurrentOrder"] = saleHeads;
                            //'Sales order
                            //Session.Add("objSalesOrder", CType(objSalesOrder, SalesOrderCollection))
                            //Session.Add("objCurrentOrder", CType(objCurrentOrder, SalesOrderHeader))
                            //Session.Add("objCurrentOrderLine", CType(objCurrentOrderLine, OrderLine))
                            //Session.Add("objManPackOrderCollection", CType(objManPackOrderCollection, SalesOrderCollection))

                            //'Return Order
                            //Session.Add("objReturnOrder", CType(objReturnOrder, SalesOrderCollection))
                            //Session.Add("objCurrentReturn", CType(objCurrentReturn, SalesOrderHeader))
                            //Session.Add("objCurrentReturnLine", CType(objCurrentReturnLine, OrderLine))
                            //Session.Add("objManPackReturnCollection", CType(objManPackReturnCollection, SalesOrderCollection))

                            //'Re Order
                            //Session.Add("objReSalesOrder", CType(objReSalesOrder, SalesOrderCollection))
                            //Session.Add("objCurrentReOrder", CType(objCurrentReOrder, SalesOrderHeader))
                            //Session.Add("objCurrentReOrderLine", CType(objCurrentReOrderLine, OrderLine))
                            //Session.Add("objManPackReOrderCollection", CType(objManPackReOrderCollection, SalesOrderCollection))

                            //'Collection Orders
                            //Session.Add("objCollectionSalesOrder", CType(objCollectionSalesOrder, SalesOrderCollection))
                            //Session.Add("objCurrentCollectionOrder", CType(objCurrentCollectionOrder, SalesOrderHeader))
                            //Session.Add("objCurrentCollectionOrderLine", CType(objCurrentCollectionOrderLine, OrderLine))
                            //Session.Add("objManPackCollectionOrderCollection", CType(objManPackCollectionOrderCollection, SalesOrderCollection))
                            Session["ProductBy"] = "Style";
                            Session["PricePermit"] = dp.getPermission(controls.Price, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), "", Session["UserName"].ToString());
                            Session["OrderPermit"] = dp.getPermission(controls.Orders, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["AccessPermit"] = dp.getPermission(controls.Access, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OrderDelete"] = dp.getPermission(controls.OrderDelete, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["NomCode"] = dp.getPermission(controls.NomCode, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OverrideEnt"] = dp.getPermission(controls.AllowOverrideEntitlement, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OverrideEntWithReason"] = dp.getPermission(controls.OverrideEntitlementWithReason, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["SAPPermit"] = dp.getPermission(controls.SAP, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OrderConfirm"] = dp.getPermission(controls.OrderConfirm, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["ShowStockcard"] = dp.getPermission(controls.OrderConfirm, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["ROLLOUTEMPDELADDR_CHG"] = dp.getPermission(controls.ROLLOUTEMPDELADDR_CHG, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OrderMode"] = "";
                            Session["FITALLOC"] = "FITALLOC";
                            Session["DIMALLOC"] = "DIMALLOC";
                            Session["goto"] = null;
                            VInfo = dp.BusinessParam("VISITINFOREQ", Session["BuisnessId"].ToString().ToUpper());
                            if (VInfo == "")
                            {
                                booVinfo = false;
                            }
                            else
                            {
                                booVinfo = Convert.ToBoolean(VInfo);
                            }
                            if (!booVinfo)
                            {

                            }
                            //Dim startPage As String = ""
                            //If booVinfo = False Then
                            //    If getWelcomePage(UCase(Trim(BusinessID))) And Not CBoolstr(BusinessParam("IGNOREWELCOME", UCase(Trim(BusinessID)))) Then
                            //        startPage = "Welcome.aspx"
                            //        'startPage = "Dashboard.aspx"
                            //    ElseIf CBoolstr(BusinessParam("REQ_REASONPAGE", UCase(Trim(BusinessID)))) Then
                            //        startPage = "CustomerReason.aspx"
                            //    Else
                            //        Dim defMenu As String = modMain.GetDefaultMenu(UCase(Trim(BusinessID)), AccessID)
                            //        If defMenu = "" Then
                            //            If CBoolstr(Session.Item("MANPACK")) Then
                            //                startPage = "newemp1.aspx?multi=true"
                            //            Else
                            //                startPage = "newemp1.aspx"
                            //            End If
                            //        Else
                            //            startPage = defMenu
                            //        End If
                            //    End If
                            //Else
                            //    startPage = "VisitorInfo.aspx"
                            //End If
                            //Session.Add("StartPage", startPage)

                            //Response.Redirect(startPage)
                            //rs.Close()
                            //If Conn.State = 1 Then
                            //    Conn.Close()
                            //End If

                            HttpCookie cookie1 = new HttpCookie("Username", logDetails.UserName);
                            HttpCookie cookie2 = new HttpCookie("Password", logDetails.Password);
                            cookie1.Expires = DateTime.Now.AddMinutes(30);
                            cookie2.Expires = DateTime.Now.AddMinutes(30);
                            HttpContext.Response.Cookies.Add(cookie1);
                            HttpContext.Response.Cookies.Add(cookie2);
                            return RedirectToAction("Index", "Employee", new { BusinessID = data.First().BusinessID });
                        }
                        else
                        {
                            ViewBag.error = "Username or Password is incorrect please try again";
                        }
                    }
                }

            }
            return View(logDetails);
        }

        public ActionResult Logoff()
        {
            if (HttpContext.Request.Cookies.AllKeys.Contains("Username"))
            {
                if (HttpContext.Request.Cookies["Username"].Value != "" && HttpContext.Request.Cookies["Username"].Value != null)
                {
                    Session.Clear();
                    HttpCookie cookie1 = new HttpCookie("Username", "");
                    HttpCookie cookie2 = new HttpCookie("Password", "");
                    cookie1.Expires = DateTime.Now.AddDays(-1);
                    cookie2.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie1);
                    HttpContext.Response.Cookies.Add(cookie2);
                }
            }
            return RedirectToAction("Login", "User");
        }
    }
}
