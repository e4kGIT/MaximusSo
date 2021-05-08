using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Helpers;
using Maximus.Services;
using Maximus.Services.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public readonly RolloutNames _empRolloutName;
        private readonly IUser _user;
        private readonly DataProcessing _dp;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UserService user = new UserService(_unitOfWork);
            RolloutNames empRolloutName = new RolloutNames(_unitOfWork);
            DataConnectionService dataConnection = new DataConnectionService(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            User user1 = new User(_unitOfWork);
            _user = user;
            _user1 = user1;
            _empRolloutName = empRolloutName;
            _dp = dp;
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
                   
                    // var mcount = _user.GetUserCount(logDetails.UserName);
                    List<EmployeeLoginModel> data = _user.GetLoginDetails(logDetails.UserName, logDetails.Password);
                    if (data.Count > 0)
                    {

                        //if (data.Any(x => x.UserName.ToLower() == logDetails.UserName.ToLower() && x.Password == logDetails.Password && x.Active.ToLower() == "y"))
                        //if(Membership.ValidateUser(logDetails.UserName,logDetails.Password))
                        if (data.Any(x => x.UserName.ToLower() == logDetails.UserName.ToLower() && x.Password == logDetails.Password && x.Active.ToLower() == "y") && Membership.ValidateUser(logDetails.UserName, logDetails.Password))
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
                            Session["PrivateExportModel"] = new List<PrivateOrderResultModel>();
                            busId = data.First().BusinessID;
                            Session["BuisnessId"] = data.First().BusinessID;
                            Session["Buisness"] = _dataConnection.GetAllBusBusinness().Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).First().Name;
                            var s = _dataConnection.GetAllBusBusinness().Where(x => x.BusinessID.ToLower().Trim() == busId.ToLower().Trim()).First().Name; Session["Proceedrollout"] = false;
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
                            Session["CustRef"] = "";
                            Session["returnModellst"] = new List<ReturnOrderModel>();
                            Session["UseMatrix"] = _dataConnection.CompanyParam("UseMatrix", cmpId);
                            Session["CC_PREFIXLETTERS"] = _dataConnection.BusinessParam("CC_PREFIXLETTERS", busId);
                            Session["POINTSREQ"] = _dataConnection.BusinessParam("POINTSREQ", busId);
                            Session["Templates"] = new List<string>();
                            Session["POINTSLNEREQ"] = _dataConnection.BusinessParam("POINTSLNEREQ", busId);
                            Session["BudgetReq"] = _dataConnection.CompanyParam("BUDGETREQ", cmpId);
                            Session["Collection"] = 0;
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
                            Session["Maternity"] = false;
                           Session["Roles"] = _dp.GetRoles(busId);
                            Session["Emprolloutnames"] = _empRolloutName.GetAll(sa => sa.Businessid == busId && sa.IsClosed == 0).Select(sa => sa.Rollname).Distinct().OrderBy(sa => sa).ToList();
                            Session["AddressChanged"] = false;
                            Session["BUDGETREQ"] = Convert.ToBoolean(_dataConnection.BusinessParam("BUDGETREQ", busId));
                            Session["RolloutOrderEst"] = false;
                            Session["SHOWVAT"] =_dataConnection.BusinessParam("SHOW_PRICE_VAT", busId);
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
                            Session["returnorder"] = false;
                            Session["PRIVATEORDER"] = false;
                            Session["PrivateMessage"] = false;
                            booDefDelAddr = _dataConnection.BusinessParam("DEFINVADDR", data.First().BusinessID.Trim().ToUpper());
                            Session["DEFINVADDR"] = booDefDelAddr == "" ? false : booDefDelAddr.ToLower() == "true" ? true : false;
                            booDefDelRef = _dataConnection.BusinessParam("DELREFREQ", data.First().BusinessID.Trim().ToUpper());
                            Session["DELREFREQ"] = booDefDelRef == "" ? false : booDefDelRef.ToLower() == "true" ? true : false;
                            onlineDefNom = _dataConnection.BusinessParam("ONLINEDEFNOM", data.First().BusinessID.Trim().ToUpper());
                            Session["CUSTREFDEF"] = _dataConnection.BusinessParam("CUSTREFDEF", data.First().BusinessID.Trim().ToUpper());
                            Session["ONLINEDEFNOM"] = onlineDefNom;
                            Session["WAREHOUSE_RTN"] = _dataConnection.BusinessParam("WAREHOUSE_RTN", data.First().BusinessID.Trim().ToUpper());
                            Session["boolDeleteConfirm"] = false;
                            Session["PrivatePriceid"] = _dataConnection.BusinessParam("PrivatePriceid", data.First().BusinessID.Trim().ToUpper());
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
                            Session["ISRTNEDITING"] = false;
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
                            Session["REQSTKLEVEL"] = false;
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
                            Session["isrtntype"] = "";
                            Session["Currency_Name"] = busInfo.Currency_Name;
                            Session["REQSTKLEVEL"] =_dataConnection.BusinessParam("REQSTKLEVEL",busId);
                            Session["CurrencyExchangeRate"] = busInfo.CurrencyExchangeRate;
                            Session["intNoOfday"] = _dataConnection.BusinessParam("NoDaysToDel", busId);
                            Session["IncWendsDel"] = _dataConnection.BusinessParam("IncWendsDel", busId);
                            Session["Rep_Id"] = busInfo.Rep_Id;
                            Session["OrderType"] = "SO";
                            Session["AUTOCONFIRM"] = _dataConnection.BusinessParam("AUTOCONFIRM", busId).ToUpper().Trim() == "TRUE" ? true : false;
                            Session["REQ_REASONPAGE"] = _dataConnection.IsReasonUcodes(busId);
                            Session["IsVisitPrivate"] = false;
                            Session["DELADDR_USER_CREATE"] = Convert.ToBoolean(_dataConnection.BusinessParam("DELADDR_USER_CREATE", busId).ToUpper().Trim());
                            Session["IsAddressToEmployee"] = _dataConnection.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "EMPLOYEE" ? true : false;
                            Session["IsAddressToAll"] = _dataConnection.BusinessParam("DELADDRMAPTO", busId).ToUpper().Trim() == "ALL" ? true : false;
                            Session["pandeliverypanelid"] = (bool)Session["IsAddressToEmployee"] | (bool)Session["IsAddressToAll"];
                            var permissionLst = _dataConnection.PermissionSettings(Session["BuisnessId"].ToString(), Session["UserName"].ToString(), "chkMapEmp", Session["Access"].ToString());
                            Session["permissionLst"] = permissionLst;
                            
                            Session["menuBulkNew"] = permissionLst.Any(x => x.ControlId.Trim() == "menuBulkNew") ? permissionLst.Where(x => x.ControlId.Trim() == "menuBulkNew").First().Permission.ToLower() : "hide";
                            Session["menuBulkNew"] = permissionLst.Any(x => x.ControlId.Trim() == "menuBulkNew") ? permissionLst.Where(x => x.ControlId.Trim() == "menuBulkNew").First().Permission.ToLower() : "hide";
                            ///created by sasi(16-12-20)
                            Session["RequirePermissionUSR"] = permissionLst.Any(x => x.ControlId.Trim() == "RequirePermissionUSR") ? permissionLst.Where(x => x.ControlId.Trim() == "RequirePermissionUSR").First().Permission.ToLower() : "hide";
                            Session["PermissionLst"] = permissionLst;
                            Session["chkMapEmp"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapEmp") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapEmp").First().Permission.ToLower() : "hide";
                            Session["ShowRtnCredBtn"] = permissionLst.Any(x => x.ControlId.Trim() == "ShowRtnCredBtn") ? permissionLst.Where(x => x.ControlId.Trim() == "ShowRtnCredBtn").First().Permission.ToLower() : "hide";
                            Session["Price"] = permissionLst.Any(x => x.ControlId.Trim() == "Price") ? permissionLst.Where(x => x.ControlId.Trim() == "Price").First().Permission.ToLower() : "hide";
                            Session["pnlCommentsNominal"] = permissionLst.Any(x => x.ControlId.Trim() == "pnlCommentsNominal") ? permissionLst.Where(x => x.ControlId.Trim() == "pnlCommentsNominal").First().Permission.ToLower() : "hide";
                            Session["pnlCarriageReason"] = permissionLst.Any(x => x.ControlId.Trim() == "pnlCarriageReason") ? permissionLst.Where(x => x.ControlId.Trim() == "pnlCarriageReason").First().Permission.ToLower() : "hide";
                            Session["chkMapAddr"] = permissionLst.Any(x => x.ControlId.Trim() == "chkMapAddr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkMapAddr").First().Permission.ToLower() : "";
                            Session["ALLOW_OVERRIDE_ENT"] = permissionLst.Any(x => x.ControlId.Trim() == "ALLOW_OVERRIDE_ENT") ? permissionLst.Where(x => x.ControlId.Trim() == "ALLOW_OVERRIDE_ENT").First().Permission.ToLower() : "";
                            Session["cmdAcceptConfirm"] = permissionLst.Any(x => x.ControlId.Trim() == "cmdAcceptConfirm") ? permissionLst.Where(x => x.ControlId.Trim() == "cmdAcceptConfirm").First().Permission.ToLower() : "hide";
                            var ass1 = Session["ALLOW_OVERRIDE_ENT"].ToString();
                            var da1 = !(Session["chkMapAddr"].ToString().ToLower().Trim() == "hide");
                            Session["chkMapAddrVisiblity"] = da1;
                            Session["OVERRIDE_ENT_WITH_REASON"] = permissionLst.Any(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON") ? permissionLst.Where(x => x.ControlId.Trim() == "OVERRIDE_ENT_WITH_REASON").First().Permission.ToLower() : "hide";
                            Session["SHOWSITEADDR"] = permissionLst.Any(x => x.ControlId.Trim().ToUpper() == "SHOWSITEADDR") ? permissionLst.Where(x => x.ControlId.Trim() == "SHOWSITEADDR").First().Permission.ToLower() : "hide";
                            Session["SiteAddress"] = _user.GetUserAddress(logDetails.UserName, busId);
                            Session["requireemergencyreason"] = false;
                            if (Session["OVERRIDE_ENT_WITH_REASON"].ToString().ToLower() == "show")
                            {
                                Session["requireemergencyreason"] = true;
                            }
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
                            //added by sasi(16-12-20)
                            Session["orderfiltermodel"] = new OrdersFilterModel();
                            Session["updateEmailTemplate"] = new UpdateMailModel();
                            Session["IsBulkOrder"] = false;
                            Session["IsBulkOrder1"] = false;
                            ///added by sasi (14-12-20)
                            Session["EmergencyMsg"] = false;
                            //Session["IsBulkOrder"] = true;
                            SalesOrderHeaderViewModel saleHeads = new SalesOrderHeaderViewModel();
                            Session["objCurrentOrder"] = saleHeads;
                            var sddd = permissionLst.Any(x => x.ControlId == "pnlRolloutName");
                            Session["pnlRolloutName"] = permissionLst.Any(x => x.ControlId == "pnlRolloutName") ? permissionLst.Where(x => x.ControlId == "pnlRolloutName").First().Permission.ToLower() == "show" ? true : false : false;
                            Session["OT"] = "SO";
                            Session["ProductBy"] = "Style";
                            Session["chkCreateUsr"] = permissionLst.Any(x => x.ControlId.Trim() == "chkCreateUsr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkCreateUsr").First().Permission.ToLower() : "hide";
                            Session["chkCreateEmpUsr"] = permissionLst.Any(x => x.ControlId.Trim() == "chkCreateEmpUsr") ? permissionLst.Where(x => x.ControlId.Trim() == "chkCreateEmpUsr").First().Permission.ToLower() : "hide";
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
                            Session["LOGO"] = _dataConnection.BusinessParam("LOGO", busId);
                            Session["RO_PER_FIRSTORDER"] = _dataConnection.BusinessParam("RO_PER_FIRSTORDER", busId);
                            var businessData = _dataConnection.GetAllBusBusinness().Where(x => x.BusinessID == busId).First().Country_Currency;
                            Session["CountryCurrency"] = _dataConnection.GetAllCountryCodes().Where(x => x.CountryID == businessData).First().Currency_Name;
                            Session["CountryCurrency"] = _dataConnection.GetAllCountryCodes().Where(x => x.CountryID == businessData).First().Currency_Name;
                            Session["RTN_Collection_Style"] = _dataConnection.CompanyParam("RTN_Collection_Style",cmpId);
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
                            string welcomeContent = _user.GetWelcome(busId);
                            Session["welcomeContent"] = welcomeContent;
                            if (welcomeContent != "" && Session["Access"].ToString().ToLower() == "user")
                            {
                                return RedirectToAction("Welcome", "Employee", new { BusinessID = data.First().BusinessID });
                            }
                            else
                            {
                                return RedirectToAction("Index", "Employee", new { BusinessID = data.First().BusinessID });
                            }
                            skip:;
                            return RedirectToAction("LogOff", "User", new { BusinessID = data.First().BusinessID });

                        }
                    }

                }
            }
            // In case user authentication fails.
            ModelState.AddModelError("", "Invalid username or password");
            return View(logDetails);
        }

        //public void createUser()
        //{
        //    foreach (var data in _user1.GetAll(s => s.AspUserID == null).ToList())
        //    {
        //        MembershipUser mu = Membership.GetUser(data.UserName);
        //        if (mu == null)
        //        {
        //            mu = Membership.CreateUser(data.UserName, data.Password);
        //            data.AspUserID = data.UserName;
        //            _user1.Update(data);
        //        }
        //    }
        //}
        ////     string connectionstring = ConfigurationManager.ConnectionStrings["maximus"].ToString();
        //MySqlConnection CONN = new MySqlConnection(connectionstring);
        //    string SQL = " SELECT name FROM `my_aspnet_users` WHERE NAME IN ('E01920608','G01181080','G01182406','G01192986','G01193739','G01194777','G01214347','G01219584','G01254677','G01292862','G04509560','G42655357','H00569321','H01593854','H02040182','H02060043','H02640988','H02687178','H03264483','H03313034','H03533239','H04170172','H06135013','H06165214','H06201113','H06333109','H07386346','H08205396','H08305951','H08334382','H08343012')";
        //    CONN.Open();
        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand(SQL, CONN);
        //        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        if(dt.Rows.Count>0)
        //        {
        //           foreach(DataRow dr in dt.Rows)
        //            {
        //            string  usr=  dr[0].ToString();
        //                try
        //                {
        //                    MembershipUser mu1 = Membership.GetUser(usr);
        //                    if (mu1 != null)
        //                    {
        //                        mu1.ChangePassword(mu1.ResetPassword(), "BAR1234?");
        //                    }
        //                }
        //                catch (Exception E)
        //                {


        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        CONN.Close();
        //    }
        //    //int cnt = 0;
        //    //var count = _user1.GetAll(s => s.Password != "Bar1234?").ToList().Count();
        //    //string value = "";
        //    //    foreach (var USRlST in _user1.GetAll(s => s.Password != "Bar1234?").ToList())
        //    //{
        //    //    try
        //    //    {
        //    //        MembershipUser mu1 = Membership.GetUser(USRlST.AspUserID);
        //    //        if (mu1 != null)
        //    //        {
        //    //            mu1.ChangePassword(mu1.ResetPassword(), USRlST.Password);
        //    //            cnt = cnt + 1;
        //    //        }
        //    //    }

        //    //    catch (Exception E)
        //    //    {
        //    //        value = value + USRlST.UserName + ",";
        //    //        cnt = cnt + 1;
        //    //    }
        //    //}
        //    //return cnt;

        //}
        public ActionResult Logoff()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        public ActionResult ResetPassword1()
        {
            return PartialView("_forgetPassword");
        }
        public string ResetPassword(string userId = "", string foreName = "", string surName = "")
        {
            string result = "";
            string adminMail = System.Configuration.ConfigurationManager.AppSettings["adminmail"].ToString();
            string mailUsername = System.Configuration.ConfigurationManager.AppSettings["username"].ToString();
            string mailPassword = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
            string mailPort = System.Configuration.ConfigurationManager.AppSettings["mailPort"].ToString();
            string mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"].ToString();

            string cmpId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"].ToString();
            if (userId != "" && foreName != "" && surName != "")
            {
                var user = _user1.Exists(s => s.UserName.Trim() == userId.Trim() && s.ForeName.Trim().ToLower() == foreName.Trim().ToLower() && s.SurName.Trim().ToLower() == surName.Trim().ToLower()) ? _user1.GetAll(s => s.UserName.Trim() == userId.Trim() && s.ForeName.Trim().ToLower() == foreName.Trim().ToLower() && s.SurName.Trim().ToLower() == surName.Trim().ToLower()).First() : new tbluser();
                if (user.UserName != null && user.UserName != "")
                {
                    if (user.Email_ID != null && user.Email_ID != "")
                    {
                        MembershipUser mu = Membership.GetUser(user.UserName);
                        string rndPassword = "";
                        bool REQRNDPWD_RESET= _dataConnection.BusinessParam("REQRNDPWD_RESET", user.BusinessID)==""?false:Convert.ToBoolean(_dataConnection.BusinessParam("REQRNDPWD_RESET", user.BusinessID));
                        if (REQRNDPWD_RESET)
                        {
                            rndPassword = CraeteRndPwd();
                        }
                        else
                        {
                            rndPassword = _dataConnection.BusinessParam("RNDPASSWORD", user.BusinessID);
                        }
                       
                        if (rndPassword != "" && rndPassword != null)
                        {
                            try
                            {
                                mu.ChangePassword(mu.ResetPassword(), rndPassword);
                                user.Password = rndPassword;
                                _user1.Update(user);
                                _user.ResetPassword(user, adminMail, mailUsername, mailPassword, mailPort, mailServer);
                                result = "success";
                            }
                            catch (Exception e)
                            {

                            }
                        }
                    }
                    else
                    {
                        result = "You does not have a valid emailid please contact administrator";
                    }
                }
                else
                {
                    bool validuser = _user1.Exists(s => s.UserName.Trim() == userId.Trim());
                    if (validuser)
                    {
                        result = "The firstname or surname you entered is incorrect";
                    }
                    else
                    {
                        result = "Please enter a valid user id";
                    }

                }
            }
            else
            {
                result = "Please enter a valid user id";
            }
            return result;
        }
        public string CraeteRndPwd()
        {
            string regex = Membership.GeneratePassword(8, 1);

            return regex;
        }
    }
}
