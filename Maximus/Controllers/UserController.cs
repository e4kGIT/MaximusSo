using Maximus.Filter;
using Maximus.Helpers;
using Maximus.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

            //       FormsAuthentication.SignOut();
            //       System.Web.HttpContext.Current.User =
            //new GenericPrincipal(new GenericIdentity(string.Empty), null);
            //       var sss1 = User.Identity.IsAuthenticated;

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
                            var identity = new ClaimsIdentity(
                  new[] {
                    new Claim(ClaimTypes.Name, logDetails.UserName),
                          },
                  "ApplicationCookie");

                            var ctx = Request.GetOwinContext();
                            var authManager = ctx.Authentication;
                            authManager.SignIn(identity);
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
                            bool AllowSite;
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
                            if (!dp.IsSuperUser(cmpId, busId, data.First().UserName))
                            {
                                AllowSite = Convert.ToBoolean(dp.BusinessParam("ONL_NEWSYSTEM", busId.ToUpper()));
                                if (AllowSite == false)
                                {
                                    goto skip;
                                }
                                else
                                {
                                    AllowSite = Convert.ToBoolean(dp.BusinessParam("ONL_ENHSYSTEM", busId.ToUpper()));
                                    if (!AllowSite)
                                    {
                                        goto skip;
                                    }
                                }
                            }
                            //Session["AddressUserCreate"] = dp.BusinessParam("DELADDR_USER_CREATE",busId);
                            Session["UseMatrix"] = dp.CompanyParam("UseMatrix", cmpId);
                            Session["CC_PREFIXLETTERS"] = dp.BusinessParam("CC_PREFIXLETTERS", busId);
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
                            Session["IsSiteCode"] = dp.IsSiteCode(busId);
                            Session["RolloutName"] = dp.BusinessParam("ROLLOUT_NAME", busId);
                            if (Session["RolloutName"].ToString() != "")
                            {
                                Session["FITALLOC"] = "FITALLOC_RO";
                                Session["DIMALLOC"] = "DIMALLOC_RO";
                            }
                            Session["BUDGETREQ"] = Convert.ToBoolean(dp.BusinessParam("BUDGETREQ", busId));
                            Session["RolloutOrder"] = Session["RolloutName"] == null | Session["RolloutName"].ToString() == "" ? false : true;
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
                            Session["CUSTREFDEF"] = dp.BusinessParam("CUSTREFDEF", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOM"] = onlineDefNom;
                            booDefNomCode = dp.BusinessParam("DEFDELREFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["DEFDELREFNOM"] = booDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booDivBudget = dp.BusinessParam("REQDIVBUDGET", data.First().BusinessID.Trim().ToUpper());
                            Session["REQDIVBUDGET"] = booDivBudget == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            strDefNomCode = dp.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOMQ"] = strDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
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
                            Session["REQ_REASONPAGE"] = dp.IsReasonUcodes(busId);
                            Session["IsVisitPrivate"] = false;
                            Session["DELADDR_USER_CREATE"] = Convert.ToBoolean(dp.BusinessParam("DELADDR_USER_CREATE", busId).ToUpper().Trim());
                            Session["IsAddressToEmployee"] = dp.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "EMPLOYEE" ? true : false;
                            Session["IsAddressToAll"] = dp.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "ALL" ? true : false;
                            Session["pandeliverypanelid"] = (bool)Session["IsAddressToEmployee"] | (bool)Session["IsAddressToAll"];
                            var permissionLst = dp.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapEmp", Session["Access"].ToString());
                            Session["chkMapEmp"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapEmp") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapEmp").First().Permission.ToLower() : "hide";
                            var da = permissionLst.Any(x => x.ControlId.Trim() == "chkMapAddr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapAddr").First().Permission.ToLower() : "";
                            Session["chkMapAddr"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapAddr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapAddr").First().Permission.ToLower() : "";
                            var da1 = !(Session["chkMapAddr"].ToString().ToLower().Trim() == "hide");
                            Session["chkMapAddrVisiblity"] = da1;
                            Session["OVERRIDE_ENT_WITH_REASON"] = permissionLst.Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? permissionLst.Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                            Session["ShowHourse"] = dp.ShowHourse(busId);
                            Session["ONLCUSREFLBL"] = dp.BusinessParam("ONLCUSREFLBL", busId);
                            Session["OnStop"] = dp.BusinessParam("OnStop", busId);
                            Session["Carrier"] = dp.BusinessParam("Carrier", busId);
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
                            Session["ONLNETXTNOM1"] = dp.CompanyParam("ONLNETXTNOM1", busId);
                            Session["ONLNETXTNOM2"] = dp.CompanyParam("ONLNETXTNOM2", busId);
                            Session["ONLNETXTNOM3"] = dp.CompanyParam("ONLNETXTNOM3", busId);
                            Session["ONLNETXTNOM4"] = dp.CompanyParam("ONLNETXTNOM4", busId);
                            Session["ONLNETXTNOM5"] = dp.CompanyParam("ONLNETXTNOM5", busId);
                            Session["txtcarriercharge"]=permissionLst.Any(x=> x.ControlId.Trim()== "txtcarriercharge") ? permissionLst.Where(x => x.ControlId.Trim() == "txtcarriercharge").First().Permission.ToLower() : "hide";
                            Session["IsManPack"] = true;
                            SalesOrderHeaderViewModel saleHeads = new SalesOrderHeaderViewModel();
                            Session["objCurrentOrder"] = saleHeads;
                            var s = permissionLst.Any(x => x.ControlId == "pnlRolloutName");
                            Session["pnlRolloutName"] = permissionLst.Any(x => x.ControlId == "pnlRolloutName") ? permissionLst.Where(x => x.ControlId == "pnlRolloutName").First().Permission.ToLower() == "show" ? true : false : false;
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
                            return RedirectToAction("Index", "Employee", new { BusinessID = data.First().BusinessID });
                            skip:;
                            return RedirectToAction("Login", "User", new { BusinessID = data.First().BusinessID });

                        }
                    }
                }
            }
            // In case user authentication fails.
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }


        //[HttpPost]
        //public ActionResult Login(LoginModel logDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (logDetails.UserName != "" & logDetails.Password != "")
        //        {
        //            List<EmployeeLoginModel> data = dp.GetLoginDetails(logDetails.UserName, logDetails.Password);
        //            if (data.Count > 0)
        //            {
        //                if (data.Any(x => x.UserName.ToLower() == logDetails.UserName.ToLower() && x.Password == logDetails.Password && x.Active.ToLower() == "y"))
        //                {
        //                    FormsAuthentication.SetAuthCookie(logDetails.UserName, false);
        //                    string custrefdef = "";
        //                    string onlineDefNom = "";
        //                    string booNom = "";
        //                    string booDefDelAddr = "";
        //                    string booDefDelRef = "";
        //                    string booDivBudget = "";
        //                    string booDefNomCode = "";
        //                    string booBudgetEmail = "";
        //                    string booCusRefMan = "";
        //                    string booPointsReq = "";
        //                    string booDespConfirm = "";
        //                    string booRea = "";
        //                    string booCmpRea = "";
        //                    string strDefNomCode = "";
        //                    string mMonthsAgo = "";
        //                    string booStkLevel = "";
        //                    string VInfo = "";
        //                    bool booVinfo = false;
        //                    string busId = "";
        //                    string startPage = "";
        //                    string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        //                    bool AllowSite;
        //                    Session["CmpId"] = cmpId;
        //                    Session["UserName"] = data.First().UserName;
        //                    Session["Password"] = data.First().Password;
        //                    Session["Name"] = data.First().ForeName + " " + data.First().SurName;
        //                    Session["Access"] = data.First().AccessID;
        //                    Session["Email"] = data.First().Email_ID;
        //                    busId = data.First().BusinessID;
        //                    Session["BuisnessId"] = data.First().BusinessID;
        //                    Session["Buisness"] = entity.tblbus_business.Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).First().Name;
        //                    Session["WareHouseID"] = dp.SetDefaultWarehouse(logDetails.UserName, data.First().BusinessID);
        //                    if (!dp.IsSuperUser(cmpId, busId, data.First().UserName))
        //                    {
        //                        AllowSite = Convert.ToBoolean(dp.BusinessParam("ONL_NEWSYSTEM", busId.ToUpper()));
        //                        if (AllowSite == false)
        //                        {
        //                            goto skip;
        //                        }
        //                        else
        //                        {
        //                            AllowSite = Convert.ToBoolean(dp.BusinessParam("ONL_ENHSYSTEM", busId.ToUpper()));
        //                            if (!AllowSite)
        //                            {
        //                                goto skip;
        //                            }
        //                        }
        //                    }
        //                    //Session["AddressUserCreate"] = dp.BusinessParam("DELADDR_USER_CREATE",busId);
        //                    Session["UseMatrix"] = dp.CompanyParam("UseMatrix", cmpId);
        //                    Session["CC_PREFIXLETTERS"] = dp.BusinessParam("CC_PREFIXLETTERS",busId);
        //                    Session["BudgetReq"] = dp.CompanyParam("BUDGETREQ", cmpId);
        //                    Session["MANPACK"] = dp.BusinessParam("MANPACK", data.First().BusinessID.ToUpper().Trim());
        //                    Session["CARRREQAMT"] = dp.BusinessParam("CARRREQAMT", data.First().BusinessID.ToUpper().Trim());
        //                    Session["CARRPRICE"] = dp.BusinessParam("CARRPRICE", data.First().BusinessID.ToUpper().Trim());
        //                    Session["CARRPERCENT"] = dp.BusinessParam("CARRPERCENT", data.First().BusinessID.ToUpper().Trim());
        //                    Session["CARRPRICE_RTN"] = dp.BusinessParam("CARRPRICE_RTN", data.First().BusinessID.ToUpper().Trim());
        //                    Session["CARRPRICE_XCHG"] = dp.BusinessParam("CARRPRICE_XCHG", data.First().BusinessID.ToUpper().Trim());
        //                    Session["BusBudgetReq"] = dp.BusinessParam("BUDGETREQ", data.First().BusinessID.ToUpper().Trim());
        //                    Session["DEFEMPDELADDR"] = dp.BusinessParam("DEFEMPDELADDR", data.First().BusinessID.ToUpper().Trim());
        //                    Session["ABANDON_EMP"] = dp.BusinessParam("ABANDON_EMP", data.First().BusinessID.ToUpper().Trim());
        //                    Session["DELADDR_SAVE"] = dp.BusinessParam("DELADDR_SAVE", data.First().BusinessID.ToUpper().Trim());
        //                    Session["ONL_REORDER_REQ"] = dp.BusinessParam("ONL_REORDER_REQ", data.First().BusinessID.ToUpper().Trim());
        //                    Session["IsSiteCode"] = dp.IsSiteCode(busId);
        //                    booNom = dp.CompanyParam("ONLNEREQNOM1", cmpId);
        //                    Session["ONLNEREQNOM1"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
        //                    booNom = dp.CompanyParam("ONLNEREQNOM2", cmpId);
        //                    Session["ONLNEREQNOM2"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
        //                    booNom = dp.CompanyParam("ONLNEREQNOM3", cmpId);
        //                    Session["ONLNEREQNOM3"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
        //                    booNom = dp.CompanyParam("ONLNEREQNOM4", cmpId);
        //                    Session["ONLNEREQNOM4"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
        //                    booNom = dp.CompanyParam("ONLNEREQNOM5", cmpId);
        //                    Session["ONLNEREQNOM5"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
        //                    booDefDelAddr = dp.BusinessParam("DEFINVADDR", data.First().BusinessID.Trim().ToUpper());
        //                    Session["DEFINVADDR"] = booDefDelAddr == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    booDefDelRef = dp.BusinessParam("DELREFREQ", data.First().BusinessID.Trim().ToUpper());
        //                    Session["DELREFREQ"] = booDefDelRef == "" ? false : booDefDelRef.ToLower() == "true" ? true : false;
        //                    onlineDefNom = dp.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
        //                    Session["CUSTREFDEF"] = dp.BusinessParam("CUSTREFDEF", data.First().BusinessID.Trim().ToUpper());
        //                    Session["ONLINEDEFNOM"] = onlineDefNom;
        //                    booDefNomCode = dp.BusinessParam("DEFDELREFNOM", data.First().BusinessID.Trim().ToUpper());
        //                    Session["DEFDELREFNOM"] = booDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    booDivBudget = dp.BusinessParam("REQDIVBUDGET", data.First().BusinessID.Trim().ToUpper());
        //                    Session["REQDIVBUDGET"] = booDivBudget == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    strDefNomCode = dp.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
        //                    Session["ONLINEDEFNOMQ"] = strDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    booBudgetEmail = dp.BusinessParam("REQBUDGETEMAIL", data.First().BusinessID.Trim().ToUpper());
        //                    Session["REQBUDGETEMAIL"] = booBudgetEmail == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    booPointsReq = dp.BusinessParam("POINTSREQ", data.First().BusinessID.Trim().ToUpper());
        //                    Session["POINTSREQD"] = booPointsReq == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    booCusRefMan = dp.BusinessParam("CusRefMan", data.First().BusinessID.Trim().ToUpper());
        //                    Session["CusRefMan"] = booCusRefMan == "" ? false : booCusRefMan.ToLower() == "true" ? true : false;
        //                    booRea = dp.BusinessParam("SOPREAREQ", data.First().BusinessID.Trim().ToUpper());
        //                    if (booRea != "")
        //                    {
        //                        Session["SOPREAREQ"] = booRea == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    }
        //                    else
        //                    {
        //                        booCmpRea = dp.CompanyParam("SOPREAREQ", cmpId);
        //                        Session["SOPREAREQ"] = booCmpRea == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
        //                    }
        //                    //booStkLevel = dp.BusinessParam("REQSTKLEVEL", Session["BuisnessId"].ToString());
        //                    //Session["REQSTKLEVEL"] = booStkLevel == "" ? false : Convert.ToBoolean(booStkLevel);
        //                    Session["DEFEMPLOYEE"] = dp.DefaultEmployee(ConfigurationSettings.AppSettings["CompanyId"].ToString(), Session["UserName"].ToString().Trim().ToUpper(), Session["BuisnessId"].ToString().ToUpper());
        //                    booDespConfirm = dp.BusinessParam("CHKDISPCONFIRM", Session["BuisnessId"].ToString().ToUpper());
        //                    Session["CHKDISPCONFIRM"] = booDespConfirm == "" ? false : Convert.ToBoolean(Session["CHKDISPCONFIRM"]);
        //                    mMonthsAgo = dp.BusinessParam("MONTHAGO_RT", Session["BuisnessId"].ToString().ToUpper());
        //                    Session["MONTHAGO_RT"] = mMonthsAgo == "" ? 1 : Convert.ToInt32(mMonthsAgo);
        //                    if (dp.CompanyParam("CUSPRODCODE", ConfigurationSettings.AppSettings["CompanyId"].ToString()) != "")
        //                    {
        //                        Session["CusProdCode"] = Convert.ToBoolean(dp.CompanyParam("CUSPRODCODE", ConfigurationSettings.AppSettings["CompanyId"].ToString()));
        //                    }
        //                    else
        //                    {
        //                        Session["CusProdCode"] = false;
        //                    }
        //                    // Session["colLines"]=colline
        //                    Session["REQ_REASONPAGE"] = dp.IsReasonUcodes(busId);
        //                    Session["IsVisitPrivate"] = false;
        //                    Session["DELADDR_USER_CREATE"] = Convert.ToBoolean(dp.BusinessParam("DELADDR_USER_CREATE", busId).ToUpper().Trim());
        //                    Session["IsAddressToEmployee"] = dp.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "EMPLOYEE" ? true : false;
        //                    Session["IsAddressToAll"] = dp.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "ALL" ? true : false;
        //                    Session["pandeliverypanelid"] = (bool)Session["IsAddressToEmployee"] | (bool)Session["IsAddressToAll"];
        //                    var permissionLst = dp.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapEmp", Session["Access"].ToString());
        //                    Session["chkMapEmp"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapEmp") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapEmp").First().Permission.ToLower() : "hide";
        //                    var da = permissionLst.Any(x => x.ControlId.Trim() == "chkMapAddr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapAddr").First().Permission.ToLower() : "";
        //                    Session["chkMapAddr"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapAddr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapAddr").First().Permission.ToLower() : "";
        //                    var da1 = !(Session["chkMapAddr"].ToString().ToLower().Trim() == "hide");
        //                    Session["chkMapAddrVisiblity"] = da1;
        //                    Session["OVERRIDE_ENT_WITH_REASON"] =  permissionLst.Any(x=>x.ControlId.Trim()== "OVERRIDE_ENT_WITH_REASON")? permissionLst.Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
        //                    Session["ShowHourse"] = dp.ShowHourse(busId);
        //                    Session["ONLCUSREFLBL"] = dp.BusinessParam("ONLCUSREFLBL", busId);
        //                    Session["OnStop"] = dp.BusinessParam("OnStop", busId);
        //                    Session["Carrier"] = dp.BusinessParam("Carrier", busId);
        //                    Session["ONLNEREQNOM1"] = dp.CompanyParam("ONLNEREQNOM1", cmpId);
        //                    Session["ONLNEREQNOM2"] = dp.CompanyParam("ONLNEREQNOM2", cmpId);
        //                    Session["ONLNEREQNOM3"] = dp.CompanyParam("ONLNEREQNOM3", cmpId);
        //                    Session["ONLNEREQNOM4"] = dp.CompanyParam("ONLNEREQNOM4", cmpId);
        //                    Session["ONLNEREQNOM5"] = dp.CompanyParam("ONLNEREQNOM5", cmpId);
        //                    Session["ONLNEDEFNOM1"] = dp.CompanyParam("ONLNEDEFNOM1", cmpId);
        //                    Session["ONLNEDEFNOM2"] = dp.CompanyParam("ONLNEDEFNOM2", cmpId);
        //                    Session["ONLNEDEFNOM3"] = dp.CompanyParam("ONLNEDEFNOM3", cmpId);
        //                    Session["ONLNEDEFNOM4"] = dp.CompanyParam("ONLNEDEFNOM4", cmpId);
        //                    Session["ONLNEDEFNOM5"] = dp.CompanyParam("ONLNEDEFNOM5", cmpId);
        //                    Session["ONLNETXTNOM1"] = dp.CompanyParam("ONLNETXTNOM1", busId);
        //                    Session["ONLNETXTNOM2"] = dp.CompanyParam("ONLNETXTNOM2", busId);
        //                    Session["ONLNETXTNOM3"] = dp.CompanyParam("ONLNETXTNOM3", busId);
        //                    Session["ONLNETXTNOM4"] = dp.CompanyParam("ONLNETXTNOM4", busId);
        //                    Session["ONLNETXTNOM5"] = dp.CompanyParam("ONLNETXTNOM5", busId);
        //                    Session["IsManPack"] = true;
        //                    SalesOrderHeaderViewModel saleHeads = new SalesOrderHeaderViewModel();
        //                    Session["objCurrentOrder"] = saleHeads;
        //                    var s = permissionLst.Any(x => x.ControlId == "pnlRolloutName");
        //                    Session["pnlRolloutName"] = permissionLst.Any(x => x.ControlId == "pnlRolloutName") ? permissionLst.Where(x => x.ControlId == "pnlRolloutName").First().Permission.ToLower() == "show" ? true : false : false;
        //                    Session["ProductBy"] = "Style";
        //                    Session["PricePermit"] = dp.getPermission(controls.Price, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), "", Session["UserName"].ToString());
        //                    Session["OrderPermit"] = dp.getPermission(controls.Orders, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["AccessPermit"] = dp.getPermission(controls.Access, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["OrderDelete"] = dp.getPermission(controls.OrderDelete, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["NomCode"] = dp.getPermission(controls.NomCode, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["OverrideEnt"] = dp.getPermission(controls.AllowOverrideEntitlement, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["OverrideEntWithReason"] = dp.getPermission(controls.OverrideEntitlementWithReason, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["SAPPermit"] = dp.getPermission(controls.SAP, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["OrderConfirm"] = dp.getPermission(controls.OrderConfirm, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["ShowStockcard"] = dp.getPermission(controls.OrderConfirm, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["ROLLOUTEMPDELADDR_CHG"] = dp.getPermission(controls.ROLLOUTEMPDELADDR_CHG, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
        //                    Session["OrderMode"] = "";
        //                    Session["FITALLOC"] = "FITALLOC";
        //                    Session["DIMALLOC"] = "DIMALLOC";
        //                    Session["goto"] = null;
        //                    VInfo = dp.BusinessParam("VISITINFOREQ", Session["BuisnessId"].ToString().ToUpper());
        //                    if (VInfo == "")
        //                    {
        //                        booVinfo = false;
        //                    }
        //                    else
        //                    {
        //                        booVinfo = Convert.ToBoolean(VInfo);
        //                    }
        //                    if (!booVinfo)
        //                    {

        //                    }
        //                    //Dim startPage As String = ""
        //                    //If booVinfo = False Then
        //                    //    If getWelcomePage(UCase(Trim(BusinessID))) And Not CBoolstr(BusinessParam("IGNOREWELCOME", UCase(Trim(BusinessID)))) Then
        //                    //        startPage = "Welcome.aspx"
        //                    //        'startPage = "Dashboard.aspx"
        //                    //    ElseIf CBoolstr(BusinessParam("REQ_REASONPAGE", UCase(Trim(BusinessID)))) Then
        //                    //        startPage = "CustomerReason.aspx"
        //                    //    Else
        //                    //        Dim defMenu As String = modMain.GetDefaultMenu(UCase(Trim(BusinessID)), AccessID)
        //                    //        If defMenu = "" Then
        //                    //            If CBoolstr(Session.Item("MANPACK")) Then
        //                    //                startPage = "newemp1.aspx?multi=true"
        //                    //            Else
        //                    //                startPage = "newemp1.aspx"
        //                    //            End If
        //                    //        Else
        //                    //            startPage = defMenu
        //                    //        End If
        //                    //    End If
        //                    //Else
        //                    //    startPage = "VisitorInfo.aspx"
        //                    //End If
        //                    //Session.Add("StartPage", startPage)

        //                    //Response.Redirect(startPage)
        //                    //rs.Close()
        //                    //If Conn.State = 1 Then
        //                    //    Conn.Close()
        //                    //End If

        //                    HttpCookie cookie1 = new HttpCookie("Username", logDetails.UserName);
        //                    HttpCookie cookie2 = new HttpCookie("Password", logDetails.Password);
        //                    cookie1.Expires = DateTime.Now.AddMinutes(30);
        //                    cookie2.Expires = DateTime.Now.AddMinutes(30);
        //                    HttpContext.Response.Cookies.Add(cookie1);
        //                    HttpContext.Response.Cookies.Add(cookie2);
        //                    return RedirectToAction("Index", "Employee", new { BusinessID = data.First().BusinessID });
        //                    skip:;
        //                    return RedirectToAction("Login", "User", new { BusinessID = data.First().BusinessID });
        //                }
        //                else
        //                {
        //                    ViewBag.error = "Username or Password is incorrect please try again";
        //                }
        //            }
        //        }

        //    }
        //    return View(logDetails);
        //}

        //public ActionResult Logoff()
        //{
        //    Session.Clear();
        //    FormsAuthentication.SignOut();
        //    //if (HttpContext.Request.Cookies.AllKeys.Contains("Username"))
        //    //{
        //    //    if (HttpContext.Request.Cookies["Username"].Value != "" && HttpContext.Request.Cookies["Username"].Value != null)
        //    //    {
        //    //        Session.Clear();
        //    //        //HttpCookie cookie1 = new HttpCookie("Username", "");
        //    //        //HttpCookie cookie2 = new HttpCookie("Password", "");
        //    //        //cookie1.Expires = DateTime.Now.AddDays(-1);
        //    //        //cookie2.Expires = DateTime.Now.AddDays(-1);
        //    //        //HttpContext.Response.Cookies.Add(cookie1);
        //    //        //HttpContext.Response.Cookies.Add(cookie2);
        //    //    }
        //    //}
        //    return RedirectToAction("Login", "User");
        //}
        public ActionResult Logoff()
        {
            Session.Clear();
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "User");
        }
    }
}
