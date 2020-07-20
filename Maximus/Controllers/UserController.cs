using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models; 
using Maximus.Helpers;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Unity;
 

namespace Maximus.Controllers
{
    public class UserController : Controller
    {
        public string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
        [Dependency]
        private readonly IDataConnection _dataConnection;
        [Dependency]
        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user1;
        
        private readonly IUser _user;
       
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UserService user = new UserService(_unitOfWork);
          
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            User user1 = new User(_unitOfWork);
            _user = user;
            _user1 = user1;
            _dataConnection = dataConnection;
         
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
      
        [HttpPost]
        public ActionResult Login(LoginModel logDetails)
        {
          
            if (ModelState.IsValid)
            {
                if (logDetails.UserName != "" & logDetails.Password != "")
                {
                   // MembershipUser mu = Membership.GetUser(logDetails.UserName);
                   // var mcount = _user.GetUserCount(logDetails.UserName);
                    List<EmployeeLoginModel> data = _user.GetLoginDetails(logDetails.UserName, logDetails.Password);
                    if (data.Count > 0)
                    {
                        if (data.Any(x => x.UserName.ToLower() == logDetails.UserName.ToLower() && x.Password == logDetails.Password && x.Active.ToLower() == "y"))
                        {
                            FormsAuthentication.SetAuthCookie(logDetails.UserName, false);
                            
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
                            Session["IsEmergency"] = false;
                            busId = data.First().BusinessID;
                            Session["BuisnessId"] = data.First().BusinessID;
                            Session["Buisness"] = _dataConnection.GetAllBusBusinness().Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).First().Name;
                            var s = _dataConnection.GetAllBusBusinness().Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).First().Name; Session["Proceedrollout"]=false;
                            Session["WareHouseID"] = _dataConnection.SetDefaultWarehouse(logDetails.UserName, data.First().BusinessID);
                            if (!_dataConnection.IsSuperUser(cmpId, busId, data.First().UserName))
                            {
                                AllowSite = Convert.ToBoolean(_dataConnection.BusinessParam("ONL_NEWSYSTEM", busId.ToUpper()));
                                if (AllowSite == false)
                                {
                                    goto skip;
                                }
                                else
                                {
                                    AllowSite = Convert.ToBoolean(_dataConnection.BusinessParam("ONL_ENHSYSTEM", busId.ToUpper()));
                                    if (!AllowSite)
                                    {
                                        goto skip;
                                    }
                                }
                            }

                            //Session["AddressUserCreate"] = _dataConnection.BusinessParam("DELADDR_USER_CREATE",busId);
                            Session["UseMatrix"] = _dataConnection.CompanyParam("UseMatrix", cmpId);
                            Session["CC_PREFIXLETTERS"] = _dataConnection.BusinessParam("CC_PREFIXLETTERS", busId);
                            Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId);
                            Session["POINTSLNEREQ"] = _dataConnection.BusinessParam("POINTSLNEREQ", busId);
                            Session["BudgetReq"] = _dataConnection.CompanyParam("BUDGETREQ", cmpId);
                            Session["MANPACK"] = _dataConnection.BusinessParam("MANPACK", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRREQAMT"] = _dataConnection.BusinessParam("CARRREQAMT", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPRICE"] = _dataConnection.BusinessParam("CARRPRICE", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPERCENT"] = _dataConnection.BusinessParam("CARRPERCENT", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPRICE_RTN"] = _dataConnection.BusinessParam("CARRPRICE_RTN", data.First().BusinessID.ToUpper().Trim());
                            Session["CARRPRICE_XCHG"] = _dataConnection.BusinessParam("CARRPRICE_XCHG", data.First().BusinessID.ToUpper().Trim());
                            Session["BusBudgetReq"] = _dataConnection.BusinessParam("BUDGETREQ", data.First().BusinessID.ToUpper().Trim());
                            Session["DEFEMPDELADDR"] = _dataConnection.BusinessParam("DEFEMPDELADDR", data.First().BusinessID.ToUpper().Trim());
                            Session["ABANDON_EMP"] = _dataConnection.BusinessParam("ABANDON_EMP", data.First().BusinessID.ToUpper().Trim());
                            Session["DELADDR_SAVE"] = _dataConnection.BusinessParam("DELADDR_SAVE", data.First().BusinessID.ToUpper().Trim());
                            Session["ONL_REORDER_REQ"] = _dataConnection.BusinessParam("ONL_REORDER_REQ", data.First().BusinessID.ToUpper().Trim());
                            Session["IsSiteCode"] = _dataConnection.IsSiteCode(busId);
                            Session["RolloutName"] = "";
                            Session["hasSiteCode"] = _user.HasCostCenter(busId);
                            Session["SiteCodeNAddress"] = _user.GetSiteCodeAndUserAddress(logDetails.UserName, busId);
                            if (Session["RolloutName"].ToString() != "")
                            {
                                Session["FITALLOC"] = "FITALLOC_RO";
                                Session["DIMALLOC"] = "DIMALLOC_RO";
                            }
                            Session["BUDGETREQ"] = Convert.ToBoolean(_dataConnection.BusinessParam("BUDGETREQ", busId));
                            Session["RolloutOrder"] = Session["RolloutName"] == null | Session["RolloutName"].ToString() == "" ? false : true;
                            Session["SalesOrderHeaderLoc"] = new List<SalesOrderHeaderViewModel>();
                            booNom = _dataConnection.CompanyParam("ONLNEREQNOM1", cmpId);
                            Session["ONLNEREQNOM1"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = _dataConnection.CompanyParam("ONLNEREQNOM2", cmpId);
                            Session["ONLNEREQNOM2"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = _dataConnection.CompanyParam("ONLNEREQNOM3", cmpId);
                            Session["ONLNEREQNOM3"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = _dataConnection.CompanyParam("ONLNEREQNOM4", cmpId);
                            Session["ONLNEREQNOM4"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booNom = _dataConnection.CompanyParam("ONLNEREQNOM5", cmpId);
                            Session["ONLNEREQNOM5"] = booNom == "" ? false : booNom.ToLower() == "true" ? true : false;
                            booDefDelAddr = _dataConnection.BusinessParam("DEFINVADDR", data.First().BusinessID.Trim().ToUpper());
                            Session["DEFINVADDR"] = booDefDelAddr == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booDefDelRef = _dataConnection.BusinessParam("DELREFREQ", data.First().BusinessID.Trim().ToUpper());
                            Session["DELREFREQ"] = booDefDelRef == "" ? false : booDefDelRef.ToLower() == "true" ? true : false;
                            onlineDefNom = _dataConnection.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["CUSTREFDEF"] = _dataConnection.BusinessParam("CUSTREFDEF", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOM"] = onlineDefNom;
                            Session["boolDeleteConfirm"] = false;
                            Session["PriceList"] = _dataConnection.BusinessParam("PriceList", data.First().BusinessID.Trim().ToUpper());
                            booDefNomCode = _dataConnection.BusinessParam("DEFDELREFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["DEFDELREFNOM"] = booDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booDivBudget = _dataConnection.BusinessParam("REQDIVBUDGET", data.First().BusinessID.Trim().ToUpper());
                            Session["REQDIVBUDGET"] = booDivBudget == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            strDefNomCode = _dataConnection.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOMQ"] = strDefNomCode == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booBudgetEmail = _dataConnection.BusinessParam("REQBUDGETEMAIL", data.First().BusinessID.Trim().ToUpper());
                            Session["REQBUDGETEMAIL"] = booBudgetEmail == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booPointsReq = _dataConnection.BusinessParam("POINTSREQ", data.First().BusinessID.Trim().ToUpper());
                            Session["ISEDITING"] = false;
                            booCusRefMan = _dataConnection.BusinessParam("CusRefMan", data.First().BusinessID.Trim().ToUpper());
                            Session["CusRefMan"] = booCusRefMan == "" ? false : booCusRefMan.ToLower() == "true" ? true : false;
                            Session["DIFF_MANPACK_INFO"] = _dataConnection.BusinessParam("DIFF_MANPACK_INFO", busId);
                            var DIFF = _dataConnection.BusinessParam("DIFF_MANPACK_INFO", busId);
                            if (Session["RolloutName"].ToString() != "")
                            {
                                Session["FITALLOC"] = "FITALLOC_RO";
                                Session["DIMALLOC"] = "DIMALLOC_RO";
                            }
                            booRea = _dataConnection.BusinessParam("SOPREAREQ", data.First().BusinessID.Trim().ToUpper());
                            if (booRea != "")
                            {
                                Session["SOPREAREQ"] = booRea == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            }
                            else
                            {
                                booCmpRea = _dataConnection.CompanyParam("SOPREAREQ", cmpId);
                                Session["SOPREAREQ"] = booCmpRea == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            }
                            //booStkLevel = _dataConnection.BusinessParam("REQSTKLEVEL", Session["BuisnessId"].ToString());
                            //Session["REQSTKLEVEL"] = booStkLevel == "" ? false : Convert.ToBoolean(booStkLevel);
                            Session["DEFEMPLOYEE"] = _dataConnection.DefaultEmployee(ConfigurationSettings.AppSettings["CompanyId"].ToString(), Session["UserName"].ToString().Trim().ToUpper(), Session["BuisnessId"].ToString().ToUpper());
                            booDespConfirm = _dataConnection.BusinessParam("CHKDISPCONFIRM", Session["BuisnessId"].ToString().ToUpper());
                            Session["CHKDISPCONFIRM"] = booDespConfirm == "" ? false : Convert.ToBoolean(Session["CHKDISPCONFIRM"]);
                            mMonthsAgo = _dataConnection.BusinessParam("MONTHAGO_RT", Session["BuisnessId"].ToString().ToUpper());
                            Session["MONTHAGO_RT"] = mMonthsAgo == "" ? 1 : Convert.ToInt32(mMonthsAgo);
                            if (_dataConnection.CompanyParam("CUSPRODCODE", ConfigurationSettings.AppSettings["CompanyId"].ToString()) != "")
                            {
                                Session["CusProdCode"] = Convert.ToBoolean(_dataConnection.CompanyParam("CUSPRODCODE", ConfigurationSettings.AppSettings["CompanyId"].ToString()));
                            }
                            else
                            {
                                Session["CusProdCode"] = false;
                            }
                            BusinessInfo busInfo = new BusinessInfo();
                            busInfo = _dataConnection.GetbusInfo(busId);
                            Session["Currency_Name"] = busInfo.Currency_Name;
                            Session["CurrencyExchangeRate"] = busInfo.CurrencyExchangeRate;
                            Session["intNoOfday"] = _dataConnection.BusinessParam("NoDaysToDel", busId);
                            Session["IncWendsDel"] = _dataConnection.BusinessParam("IncWendsDel", busId);
                            Session["Rep_Id"] = busInfo.Rep_Id;
                            Session["OrderType"] = "SO";
                             Session["AUTOCONFIRM"]= _dataConnection.BusinessParam("AUTOCONFIRM", busId).ToUpper().Trim() == "TRUE" ? true : false;
                            Session["REQ_REASONPAGE"] = _dataConnection.IsReasonUcodes(busId);
                            Session["IsVisitPrivate"] = false;
                            Session["DELADDR_USER_CREATE"] = Convert.ToBoolean(_dataConnection.BusinessParam("DELADDR_USER_CREATE", busId).ToUpper().Trim());
                            Session["IsAddressToEmployee"] = _dataConnection.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "EMPLOYEE" ? true : false;
                            Session["IsAddressToAll"] = _dataConnection.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "ALL" ? true : false;
                            Session["pandeliverypanelid"] = (bool)Session["IsAddressToEmployee"] | (bool)Session["IsAddressToAll"];
                            var permissionLst = _dataConnection.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapEmp", Session["Access"].ToString());
                            Session["permissionLst"] = permissionLst;
                             Session["menuBulkNew"] = permissionLst.Any(x => x.ControlId.Trim() == "menuBulkNew") ? permissionLst.Where(x => x.ControlId.Trim() == "menuBulkNew").First().Permission.ToLower() : "hide";
                            Session["PermissionLst"] = permissionLst;
                            Session["chkMapEmp"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapEmp") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapEmp").First().Permission.ToLower() : "hide";
                            Session[""] =
                            Session["Price"] = permissionLst.Any(x => x.ControlId.Trim() == "Price") ? permissionLst.Where(x => x.ControlId.Trim() == "Price").First().Permission.ToLower() : "hide";
                            Session["pnlCommentsNominal"] = permissionLst.Any(x => x.ControlId.Trim() == "pnlCommentsNominal") ? permissionLst.Where(x => x.ControlId.Trim() == "pnlCommentsNominal").First().Permission.ToLower() : "hide";
                            Session["pnlCarriageReason"] = permissionLst.Any(x => x.ControlId.Trim() == "pnlCarriageReason") ? permissionLst.Where(x => x.ControlId.Trim() == "pnlCarriageReason").First().Permission.ToLower() : "hide";
                            Session["chkMapAddr"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapAddr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapAddr").First().Permission.ToLower() : "";
                            Session["ALLOW_OVERRIDE_ENT"] = permissionLst.Any(x => x.ControlId.Trim() == "ALLOW_OVERRIDE_ENT") ? permissionLst.Where(x => x.ControlId.Trim() == "ALLOW_OVERRIDE_ENT").First().Permission.ToLower() : "";
                            var ass1 = Session["ALLOW_OVERRIDE_ENT"].ToString();
                            var da1 = !(Session["chkMapAddr"].ToString().ToLower().Trim() == "hide");
                            Session["chkMapAddrVisiblity"] = da1;
                            Session["OVERRIDE_ENT_WITH_REASON"] = permissionLst.Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? permissionLst.Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                            Session["SHOWSITEADDR"] = permissionLst.Any(x=>x.ControlId.Trim().ToUpper()== "SHOWSITEADDR") ? permissionLst.Where(x => x.ControlId.Trim() == "SHOWSITEADDR").First().Permission.ToLower() : "hide";
                            Session["SiteAddress"] =_user.GetUserAddress(logDetails.UserName,busId);
                            Session["requireemergencyreason"] = false;
                           Session["ctlCarrier"] = permissionLst.Any(x => x.ControlId.Trim() == "ctlCarrier") ? permissionLst.Where(x => x.ControlId.Trim() == "ctlCarrier").First().Permission.ToLower() : "hide";
                            Session["ShowHourse"] = _dataConnection.ShowHourse(busId);
                            Session["ONLCUSREFLBL"] = _dataConnection.BusinessParam("ONLCUSREFLBL", busId);
                            Session["OnStop"] = _dataConnection.BusinessParam("OnStop", busId);
                            Session["Carrier"] = _dataConnection.BusinessParam("Carrier", busId);
                            Session["DEFEMPDELADDR_VIEW"] = Convert.ToBoolean(_dataConnection.BusinessParam("DEFEMPDELADDR_VIEW", Session["BuisnessId"].ToString()));
                            Session["ONLNEREQNOM1"] = _dataConnection.CompanyParam("ONLNEREQNOM1", cmpId);
                            Session["ONLNEREQNOM2"] = _dataConnection.CompanyParam("ONLNEREQNOM2", cmpId);
                            Session["ONLNEREQNOM3"] = _dataConnection.CompanyParam("ONLNEREQNOM3", cmpId);
                            Session["ONLNEREQNOM4"] = _dataConnection.CompanyParam("ONLNEREQNOM4", cmpId);
                            Session["ONLNEREQNOM5"] = _dataConnection.CompanyParam("ONLNEREQNOM5", cmpId);
                            Session["ONLNEDEFNOM1"] = _dataConnection.CompanyParam("ONLNEDEFNOM1", cmpId);
                            Session["ONLNEDEFNOM2"] = _dataConnection.CompanyParam("ONLNEDEFNOM2", cmpId);
                            Session["ONLNEDEFNOM3"] = _dataConnection.CompanyParam("ONLNEDEFNOM3", cmpId);
                            Session["ONLNEDEFNOM4"] = _dataConnection.CompanyParam("ONLNEDEFNOM4", cmpId);
                            Session["ONLNEDEFNOM5"] = _dataConnection.CompanyParam("ONLNEDEFNOM5", cmpId);
                            Session["ROLLOUT_NAME"] = _dataConnection.BusinessParam("ROLLOUT_NAME", busId);
                            Session["ONLNETXTNOM1"] = _dataConnection.CompanyParam("ONLNETXTNOM1", busId);
                            Session["ONLNETXTNOM2"] = _dataConnection.CompanyParam("ONLNETXTNOM2", busId);
                            Session["ONLNETXTNOM3"] = _dataConnection.CompanyParam("ONLNETXTNOM3", busId);
                            Session["ONLNETXTNOM4"] = _dataConnection.CompanyParam("ONLNETXTNOM4", busId);
                            Session["ONLNETXTNOM5"] = _dataConnection.CompanyParam("ONLNETXTNOM5", busId);
                            Session["txtcarriercharge"] = permissionLst.Any(x => x.ControlId.Trim() == "txtcarriercharge") ? permissionLst.Where(x => x.ControlId.Trim() == "txtcarriercharge").First().Permission.ToLower() : "hide";
                            Session["IsManPack"] = true;
                            Session["IsBulkOrder"] = false;
                            Session["IsBulkOrder1"] = false;
                            //Session["IsBulkOrder"] = true;
                            SalesOrderHeaderViewModel saleHeads = new SalesOrderHeaderViewModel();
                            Session["objCurrentOrder"] = saleHeads;
                            var sddd = permissionLst.Any(x => x.ControlId == "pnlRolloutName");
                            Session["pnlRolloutName"] = permissionLst.Any(x => x.ControlId == "pnlRolloutName") ? permissionLst.Where(x => x.ControlId == "pnlRolloutName").First().Permission.ToLower() == "show" ? true : false : false;
                            Session["ProductBy"] = "Style"; 
                            Session["PricePermit"] = _dataConnection.getPermission(controls.Price, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), "", Session["UserName"].ToString());
                            Session["OrderPermit"] = _dataConnection.getPermission(controls.Orders, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), Session["UserName"].ToString());
                            Session["AccessPermit"] = _dataConnection.getPermission(controls.Access, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), Session["UserName"].ToString());
                            Session["OrderDelete"] = _dataConnection.getPermission(controls.OrderDelete, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), Session["UserName"].ToString());
                            Session["NomCode"] = _dataConnection.getPermission(controls.NomCode, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), Session["UserName"].ToString());
                            Session["OverrideEnt"] = _dataConnection.getPermission(controls.AllowOverrideEntitlement, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper(), Session["UserName"].ToString());
                            Session["OverrideEntWithReason"] = _dataConnection.getPermission(controls.OverrideEntitlementWithReason, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["SAPPermit"] = _dataConnection.getPermission(controls.SAP, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OrderConfirm"] = _dataConnection.getPermission(controls.OrderConfirm, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["ShowStockcard"] = _dataConnection.getPermission(controls.OrderConfirm, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["ROLLOUTEMPDELADDR_CHG"] = _dataConnection.getPermission(controls.ROLLOUTEMPDELADDR_CHG, data.First().AccessID, Session["BuisnessId"].ToString().ToUpper());
                            Session["OrderMode"] = "";
                            Session["FITALLOC"] = "FITALLOC";
                            Session["DIMALLOC"] = "DIMALLOC";
                            Session["LOGO"] = _dataConnection.BusinessParam("LOGO",busId);
                            Session["RO_PER_FIRSTORDER"] = _dataConnection.BusinessParam("RO_PER_FIRSTORDER", busId);
                            var businessData = _dataConnection.GetAllBusBusinness().Where(x => x.BusinessID == busId).First().Country_Currency;
                            Session["CountryCurrency"] = _dataConnection.GetAllCountryCodes().Where(x => x.CountryID == businessData).First().Currency_Name;
                            Session["CurrencySymbol"] = _dataConnection.GetAllCountryCodes().Where(x => x.CountryID == businessData).First().Currency_Symbol;
                            Session["goto"] = null;
                            Session["CarrierPrompt"] = _dataConnection.BusinessParam("CarrierPrompt", busId);
                            Session["EmployeeRenew"] = _dataConnection.BusinessParam("EmployeeRenew", busId);
                            VInfo = _dataConnection.BusinessParam("VISITINFOREQ", Session["BuisnessId"].ToString().ToUpper());
                             Session["RO_DATECHECK"] = _dataConnection.BusinessParam("RO_DATECHECK", Session["BuisnessId"].ToString().ToUpper());
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
                            return RedirectToAction("Index", "Employee", new { BusinessID = data.First().BusinessID });
                            skip:;
                            return RedirectToAction("LogOff", "User", new { BusinessID = data.First().BusinessID });

                        }
                    }
                }
            }
            // In case user authentication fails.
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}
