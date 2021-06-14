using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services;
using Maximus.Services.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Maximus.Controllers
{
    [Authorize]
    public class ImportExportController : Controller
    {
        // GET: ImportExport

        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        public readonly BusAddress _busAddress;
        private readonly EmployeeRollout _empRollout;
        private readonly DataProcessing _dp;
        private readonly IImportExport _importExport;
        public readonly CountryCodes _countryCodes;
        public readonly RolloutNames _rollout;
        public readonly Employee _employee;
        public readonly UcodeEmployees _ucodEmp;
        public string FileName;
        static string connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["Maximus"].ToString();


        List<UserImportModel> passListuser;
        List<UserImportModel> failListuser;
        List<AddressImportModel> passListaddr;
        List<AddressImportModel> failListaddr;
        List<EmployeeImportModel> passListemp;
        List<EmployeeImportModel> failListemp;

        public ImportExportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            User user = new User(_unitOfWork);
            ImportExportService importExport = new ImportExportService(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            RolloutNames rollout = new RolloutNames(_unitOfWork);
            EmployeeRollout empRollout = new EmployeeRollout(_unitOfWork);
            UcodeEmployees ucodEmp = new UcodeEmployees(_unitOfWork);
            BusAddress busAddress = new BusAddress(_unitOfWork);
            Employee employee = new Employee(_unitOfWork);
            CountryCodes countryCodes = new CountryCodes(_unitOfWork);
            _ucodEmp = ucodEmp;
            _countryCodes = countryCodes;
            _rollout = rollout;
            _user = user;
            _dp = dp;
            _employee = employee;
            _busAddress = busAddress;
            _importExport = importExport;
            _empRollout = empRollout;
        }
        public ActionResult ImportExportIndex()
        {
            Session["selectedctrl"] = "user";
            return View();
        }

        //public ActionResult UserGridview()
        //{

        //}
        //public ActionResult EmployeeGridview()
        //{

        //}
        //public ActionResult AddressGridview()
        //{

        //}

        [ValidateInput(false)]
        public ActionResult UserGridViewPartial()
        {
            string busId = Session["BuisnessId"].ToString();
            var model = _importExport.GetAllUsers(busId);
            ViewBag.userlst = _user.GetAll().Select(s => s.UserName).Distinct().ToList();
            if (Session["ImpExptModel"] != null)
            {
                var data = (ImpExptModel)Session["ImpExptModel"];
                data.UserModel = model;
            }
            return PartialView("_UserGridViewPartial", model);
        }

        public ActionResult CreateIMPEXP(string userId = "", string empId = "", string addrId = "")
        {
            string cmp = Session["CmpId"].ToString();
            string busId = Session["BuisnessId"].ToString().Trim();
            TempData["edit"] = false;
            var data = Session["ImpExptModel"] != null ? (ImpExptModel)Session["ImpExptModel"] : new ImpExptModel();
            if (userId != "")
            {
                if (data.UserModel != null && data.UserModel.Count > 0)
                {
                    var user = data.UserModel.Any(s => s.UserName == userId.Trim()) ? data.UserModel.Where(s => s.UserName == userId.Trim()).First() : new ImpExpUsers();
                    ViewData["ImpExpEditModel"] = user;
                    TempData["edit"] = true;
                }
            }
            else if (empId != "")
            {
                if (data.EmpModel != null && data.EmpModel.Count > 0)
                {
                    var user = data.EmpModel.Any(s => s.EMPLOYEEID == empId.Trim()) ? data.EmpModel.Where(s => s.EMPLOYEEID == empId.Trim()).First() : new EmployeeImportModel();
                    ViewData["ImpExpEditModel"] = user;
                    TempData["edit"] = true;
                }
            }
            else if (addrId != "")
            {
                if (data.AddressModel != null && data.AddressModel.Count > 0)
                {
                    int adr = Convert.ToInt32(addrId);
                    var user = data.AddressModel.Any(s => s.ADDRESSID == adr) ? data.AddressModel.Where(s => s.ADDRESSID == adr).First() : new AddressImportModel();
                    ViewData["ImpExpEditModel"] = user;
                    TempData["edit"] = true;
                }
            }
            List<string> title = new List<string>() { ".", "Mr.", "Miss.", "Mrs." };
            ViewBag.countryLst = _countryCodes.Exists(s => s.CompanyID == cmp) ? _countryCodes.GetAll(s => s.CompanyID == cmp).Select(s => s.Country).Distinct().ToList() : new List<string>();
            ViewBag.titleLst = title;
            ViewBag.addrLst = _busAddress.Exists(s => s.BusinessID == busId) ? _busAddress.GetAll(s => s.BusinessID == busId).Select(s => s.Description).ToList() : new List<string>();
            ViewBag.Access = _user.Exists(s => s.BusinessID.ToLower().Trim() == busId && s.Active == "Y") ? _user.GetAll(s => s.BusinessID.ToLower().Trim() == busId && s.Active == "Y").Select(s => s.AccessID).Distinct().ToList() : new List<string>();
            ViewBag.UcodeLst = _ucodEmp.Exists(s => s.BusinessID.ToLower().Trim() == busId) ? _ucodEmp.GetAll(s => s.BusinessID.ToLower().Trim() == busId).Select(s => s.UCodeID).Distinct().ToList() : new List<string>();
            ViewBag.EmpLst = _employee.Exists(s => s.BusinessID.ToLower().Trim() == busId && s.EmployeeClosed == 0) ? _employee.GetAll(s => s.BusinessID.ToLower().Trim() == busId && s.EmployeeClosed == 0).Select(s => s.EmployeeID).Distinct().ToList() : new List<string>();
            ViewBag.RolloutName = _rollout.Exists(s => s.Businessid == busId && s.IsClosed == 0) ? _rollout.GetAll(s => s.Businessid == busId && s.IsClosed == 0).Select(s => s.Rollname).ToList() : new List<string>();
            ViewBag.userlst = busId.ToLower().Trim() == "barban01" ? _user.Exists(s => s.BusinessID.ToLower().Trim() == busId && s.Active == "Y" && s.AccessID.ToLower().Trim() != "supervisor") ? _user.GetAll(s => s.BusinessID.ToLower().Trim() == busId && s.Active == "Y" && s.AccessID.ToLower().Trim() != "supervisor").Select(s => s.UserName+ " | "+s.ForeName+" "+s.SurName  ).Distinct().ToList() : new List<string>() : _user.Exists(s => s.BusinessID.ToLower().Trim() == busId && s.Active == "Y") ? _user.GetAll(s => s.BusinessID.ToLower().Trim() == busId && s.Active == "Y").Select(s =>  s.UserName + " | " + s.ForeName + " " + s.SurName).Distinct().ToList() : new List<string>();
            return PartialView("_Createnew");
        }

        [ValidateInput(false)]
        public ActionResult EmployeeGrdiviewPartial()
        {

            var model = _importExport.GetAllEmployee(Session["BuisnessId"].ToString());
            if (Session["ImpExptModel"] != null)
            {
                var data = (ImpExptModel)Session["ImpExptModel"];
                data.EmpModel = model;
            }
            return PartialView("_EmployeeGrdiviewPartial", model);
        }
        public List<string> RemoveName(List<string> lst)
        {
            List<string> newLst = new List<string>();
            foreach(var ls in lst)
            {
                if(ls.Contains("|"))
                {
                   var Arr= ls.Split('|');
                    newLst.Add(Arr[0]);
                }
                else
                {
                    newLst.Add(ls);
                }
            }
            return newLst;
        }
        public bool UserInser(string username, string forename, string surname, string email, string role, string mapto, string rollOut, bool active)
        {
            List<string> mapTolSt = new List<string>();
            string rndPwd = _dp.BusinessParam("RNDPASSWORD", Session["BuisnessId"].ToString());
            int count = 0;
            bool qryRslt = false;
            passListuser = new List<UserImportModel>();
            failListuser = new List<UserImportModel>();
            UserImportModel model = new UserImportModel();
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                if (username != "" && forename != "" && role != "" && email != "")
                {
                    MembershipUser mu = Membership.GetUser(username);
                    if (mu == null)
                    {
                        Membership.CreateUser(username, rndPwd, email);
                        mu = Membership.GetUser(username);
                    }
                    model.FORENAME = forename.Length > 80 ? forename.Substring(0, 80) : forename;
                    model.SURNAME = surname != null && surname != "" ? surname.Length > 80 ? surname.Substring(0, 80) : surname : "";
                    model.USERNAME = username.Length > 20 ? username.Substring(0, 20) : username;
                    model.AspUserID = mu != null ? username != null && username != "" ? username : username : username;
                    model.Password = rndPwd;
                    model.BusiD = Session["BuisnessId"].ToString();
                    model.ACTIVE = active ? "Y" : "N";
                    model.FORENAME = model.FORENAME.Replace("'", " ");
                    model.SURNAME = model.SURNAME.Replace("'", " ");
                    model.EMAILID = email;
                    model.ROLE = role;
                    if (mapto != "" & mapto.Contains(";"))
                    {
                        model.MAPTOlst =RemoveName( mapto.Split(';').ToList());
                        //model.MAPTOlst.Add(item.USERNAME);
                    }
                    else
                    {
                        mapTolSt.Add(mapto);
                        model.MAPTOlst = RemoveName(mapTolSt);

                    }

                    if (_dp.SaveImportedUser(model, conn))
                    {
                        count++;
                        passListuser.Add(model);
                    }
                    else
                    {
                        failListuser.Add(model);
                    }
                    if (passListuser.Count > 0)
                    {
                        qryRslt = true;
                    }
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                if (qryRslt)
                {
                    trans.Commit();
                }
                else
                {

                    trans.Commit();
                }
                conn.Close();
            }
            return qryRslt;
        }
        public bool AddressInser(string desc, string add1, string add2, string add3, string town, string cityCty, string pstC, string addrEmail, string cntName, string country, string phone, int addrId = 0, string tbxMaptoAddr = "",string costctrVal="")
        {
            bool qryRslt = false;
            bool userCreate = false;
            int count = 0;
            passListaddr = new List<AddressImportModel>();
            failListaddr = new List<AddressImportModel>();
            userCreate = Convert.ToBoolean(_dp.BusinessParam("IGNORE_USER_CREATE", Session["BuisnessId"].ToString()));
            string rndPwd = _dp.BusinessParam("RNDPASSWORD", Session["BuisnessId"].ToString());
            AddressImportModel item = new AddressImportModel();
            List<string> ucodLSt = new List<string>();
            List<string> mapTolSt = new List<string>();
            List<string> addrList = new List<string>();
            UserImportModel model = new UserImportModel();
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                item.ADDRESS1 = add1 != null ? add1.Contains("'") ? add1.Replace("'", " ") : add1 : "";
                item.ADDRESS2 = add2 != null ? add2.Contains("'") ? add2.Replace("'", " ") : add2 : "";
                item.ADDRESS3 = add3 != null ? add3.Contains("'") ? add3.Replace("'", " ") : add3 : "Default";
                item.DESCRIPTION = desc != null ? desc.Contains("'") ? desc.Replace("'", " ") : desc : "";
                item.CITYCOUNTY = cityCty != null ? cityCty.Contains("'") ? cityCty.Replace("'", " ") : cityCty : "";
                item.COUNTRY = country != null ? country.Contains("'") ? country.Replace("'", " ") : country : "";
                item.EMAIL = addrEmail != null ? addrEmail : "";
                item.TOWN = town != null ? town.Contains("'") ? town.Replace("'", " ") : town : "";
                item.POSTCODE = pstC != null ? pstC.Contains("'") ? pstC.Replace("'", " ") : pstC : "";
                item.ADDRESSID = addrId;
                item.CONTACTNAME = cntName != null ? cntName.Contains("'") ? cntName.Replace("'", " ") : cntName : "";
                item.TELEPHONE = phone != null ? phone : "";

                item.MAPTO = tbxMaptoAddr != null ? tbxMaptoAddr : "";
                item.COSTCENTER = costctrVal != null ? costctrVal : "";
                if (item.ADDRESS1 != "" && item.DESCRIPTION != "" && item.COUNTRY != "" && item.POSTCODE != "")
                {
                    item.BUSINESSID = Session["BuisnessId"].ToString();
                    mapTolSt = new List<string>();
                    List<string> telList = new List<string>();
                    List<string> emalList = new List<string>();
                    List<string> cstCtre = new List<string>();
                    List<string> cntList = new List<string>();

                    if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                    {
                        item.MAPTOlst = RemoveName(item.MAPTO.Split(';').ToList());
                    }
                    else
                    {
                        mapTolSt.Add(item.MAPTO);
                        item.MAPTOlst = RemoveName(mapTolSt);
                    }
                    if (item.TELEPHONE != "" && item.TELEPHONE.Contains(","))
                    {
                        item.TELEPHONElst = item.TELEPHONE.Split(';').ToList();
                    }
                    else
                    {
                        telList.Add(item.TELEPHONE);
                        item.TELEPHONElst = telList;
                    }
                    if (item.EMAIL != "" && item.EMAIL.Contains(","))
                    {
                        item.EMAILlst = item.EMAIL.Split(';').ToList();
                    }
                    else
                    {
                        emalList.Add(item.EMAIL);
                        item.EMAILlst = emalList;
                    }
                    if (item.CONTACTNAME != "" && item.CONTACTNAME.Contains(","))
                    {
                        item.CONTACTNAMElst = item.CONTACTNAME.Split(';').ToList();
                    }
                    else
                    {
                        cntList.Add(item.CONTACTNAME);
                        item.CONTACTNAMElst = cntList;
                    }
                    if (item.COSTCENTER != "" && item.COSTCENTER.Contains(","))
                    {
                        item.COSTCENTERlst = item.COSTCENTER.Split(';').ToList();
                    }
                    else
                    {
                        cstCtre.Add(item.COSTCENTER);
                        item.COSTCENTERlst = cstCtre;
                    }
                    if (item.EMAIL != "" && item.EMAIL.Contains(","))
                    {
                        item.EMAILlst = item.EMAIL.Split(';').ToList();
                    }
                    else
                    {
                        emalList.Add(item.EMAIL);
                        item.EMAILlst = emalList;
                    }
                    var resultVal = _dp.SaveImportedAddress(item, conn);
                    if (resultVal.result)
                    {

                        count++;
                        passListaddr.Add(item);
                    }
                    else
                    {
                        failListaddr.Add(item);
                    }
                    resultVal = _dp.SaveImportedAddress(item, conn);
                    if (resultVal.result)
                    {
                        count++;
                        passListaddr.Add(item);
                    }
                    else
                    {
                        passListaddr.Add(item);
                    }
                    if (passListaddr.Count > 0)
                    {
                        qryRslt = true;
                    }
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                if (qryRslt)
                {
                    trans.Commit();
                }
                else
                {

                    trans.Rollback();
                }
                conn.Close();
            }
            return qryRslt;

        }
        public bool EmployeeInsert(string empId, string title, string forEmpName, string surEmpName, string empdept, DateTime stDate, DateTime endDate, string ucd, string mapToEmp, string maptoAddrEmp = "")
        {
            bool qryRslt = false;
            bool userCreate = false;
            int count = 0;
            passListemp = new List<EmployeeImportModel>();
            failListemp = new List<EmployeeImportModel>();
            userCreate = Convert.ToBoolean(_dp.BusinessParam("IGNORE_USER_CREATE", Session["BuisnessId"].ToString()));
            string rndPwd = _dp.BusinessParam("RNDPASSWORD", Session["BuisnessId"].ToString());
            EmployeeImportModel item = new EmployeeImportModel();
            List<string> ucodLSt = new List<string>();
            List<string> mapTolSt = new List<string>();
            List<string> addrList = new List<string>();
            UserImportModel model = new UserImportModel();
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();
            try
            {
                item.EMPLOYEEID = empId != null ? empId : "";
                item.TITLE = title != null ? title : "";
                item.DEPARTMENT = empdept != null ? empId : "Default";
                item.STARTDATE = stDate != null ? stDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
                item.ENDDATE = endDate != null ? endDate.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
                item.MAPTO = mapToEmp != null ? mapToEmp : "";
                item.MAPTOADDR = maptoAddrEmp != null ? maptoAddrEmp : "";
                item.UCODE = ucd != null ? ucd : "";
                item.FORENAME = forEmpName.Length > 80 ? forEmpName.Substring(0, 80) : forEmpName;
                item.SURNAME = surEmpName != null && surEmpName != "" ? surEmpName.Length > 80 ? surEmpName.Substring(0, 80) : surEmpName : "";
                item.FORENAME = item.FORENAME.Replace("'", " ");
                item.SURNAME = item.SURNAME.Replace("'", " ");
                if (empId != "" && item.FORENAME != "")
                {
                    if (item.UCODE != "" & item.UCODE.Contains(";"))
                    {
                        item.UCODEIDlst = item.UCODE.Split(';').ToList();
                    }
                    else
                    {
                        if (item.UCODE != "")
                        {
                            ucodLSt.Add(item.UCODE);
                            item.UCODEIDlst = ucodLSt;
                        }
                        else
                        {
                            ucodLSt.Add(item.UCODE);
                            item.UCODEIDlst = ucodLSt;
                        }
                    }
                    if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                    {
                        item.MAPTOlst = RemoveName(item.MAPTO.Split(';').ToList());
                    }
                    else
                    {
                        if (item.MAPTO != "")
                        {
                            mapTolSt.Add(item.MAPTO);
                            mapTolSt.Add(item.EMPLOYEEID);
                            item.MAPTOlst = RemoveName(mapTolSt);
                        }
                        else
                        {
                            mapTolSt.Add(item.EMPLOYEEID);
                            item.MAPTOlst = mapTolSt;
                        }
                    }

                    if (item.MAPTOADDR != "" & item.MAPTOADDR.Contains(";"))
                    {
                        item.MAPTOADDRLst = item.MAPTOADDR.Split(';').ToList();
                    }
                    else
                    {
                        if (item.MAPTOADDR != "")
                        {
                            addrList.Add(item.MAPTOADDR);

                            item.MAPTOADDRLst = addrList;
                        }
                        else
                        {
                            addrList.Add(item.MAPTOADDR);
                            item.MAPTOADDRLst = addrList;
                        }
                    }
                    item.STARTDATE = item.STARTDATE != "" ? item.STARTDATE : DateTime.Now.ToString("dd-MM-yyyy");
                    item.ENDDATE = item.ENDDATE != "" ? item.ENDDATE : DateTime.Now.ToString("dd-MM-yyyy");
                    item.BusId = Session["BuisnessId"].ToString();
                    MembershipUser mu = Membership.GetUser(item.EMPLOYEEID);
                    if (mu == null && userCreate)
                    {
                        Membership.CreateUser(item.EMPLOYEEID, rndPwd, "");
                        mu = Membership.GetUser(item.EMPLOYEEID);
                    }
                    item.EMPLOYEEID = mu.UserName != null && mu.UserName != "" ? mu.UserName : item.EMPLOYEEID;
                    if (_dp.SaveImportedEmployee(item, conn, userCreate, rndPwd))
                    {
                        count++;
                        passListemp.Add(item);
                    }
                    else
                    {
                        failListemp.Add(item);
                    }
                    if (passListemp.Count > 0)
                    {
                        qryRslt = true;
                    }
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                if (qryRslt)
                {
                    trans.Commit();
                }
                else
                {

                    trans.Rollback();
                }
                conn.Close();
            }
            return qryRslt;
        }
        public ActionResult AddressGridViewPartial()
        {
            var model = _importExport.GetAllAddress(Session["BuisnessId"].ToString());
            if (Session["ImpExptModel"] != null)
            {
                var data = (ImpExptModel)Session["ImpExptModel"];
                data.AddressModel = model;
            }
            return PartialView("_AddressGridViewPartial", model);
        }

        public JsonResult StartImport(bool isNew = false)
        {
            ImportExportResult result = new ImportExportResult();
            bool qryRslt = false;
            var usrResult = false;
            int count = 0;
            List<string> mapTolSt = new List<string>();
            List<string> ucodLSt = new List<string>();
            List<string> telList = new List<string>();
            List<string> addrList = new List<string>();
            List<string> emalList = new List<string>();
            List<string> cstCtre = new List<string>();
            List<string> cntList = new List<string>();
            string rndPwd = _dp.BusinessParam("RNDPASSWORD", Session["BuisnessId"].ToString());
            DataTable dt = new DataTable();
            bool iscreated = false;
            string failTable = "<table id='failListtable' class='table' cellspacing='0' cellpadding='0' border='1'>";
            string file = Session["importfilename"] != null ? Session["importfilename"].ToString() : "";
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlTransaction trans;

            if (file != "")
            {
                InMemoryModel inModel = new InMemoryModel();
                dt = inModel.OpenExcelFile(file);
                if (dt.Rows.Count > 0)
                {
                    if (Session["selectedctrl"].ToString().ToLower().Contains("user"))
                    {
                        if(dt.Columns.Contains("ADDRESS1") || dt.Columns.Contains("EMPLOYEEID"))
                        {
                            result.result = false;
                            result.alertstring = "The file you have selected is not in the required format";
                            return Json(result,JsonRequestBehavior.AllowGet);
                        }

                        failListuser = new List<UserImportModel>();
                        passListuser = new List<UserImportModel>();
                        conn.Open();
                        trans = conn.BeginTransaction();
                        failTable = failTable+"<tr  class='trHead'><th  class='divpadder'>USERNAME</th><th  class='divpadder'>FORENAME</th><th  class='divpadder'>SURNAME</th><th  class='divpadder'>EMAILID</th><th  class='divpadder'>ROLE</th><th  class='divpadder'>ACTIVE</th><th  class='divpadder'>MAPTO</th></tr>";


                       
                        try
                        {
                            if (isNew)
                            {
                                if (_dp.DeleteFromPermUser(Session["BuisnessId"].ToString(), conn))
                                {
                                    foreach (var item in dt.AsEnumerable().Select(s => new UserImportModel { USERNAME = s["USERNAME"].ToString(), FORENAME = s["FORENAME"].ToString(), SURNAME = s["SURNAME"].ToString(), EMAILID = s["EMAILID"].ToString(), ROLE = s["ROLE"].ToString(), ACTIVE = s["ACTIVE"].ToString(), MAPTO = s["MAPTO"].ToString() }))
                                    {
                                        mapTolSt = new List<string>();
                                        if (item.USERNAME != "" && item.FORENAME != "" && item.ROLE != "" && item.EMAILID != "")
                                        {
                                            MembershipUser mu = Membership.GetUser(item.USERNAME);
                                            if (mu == null)
                                            {
                                                Membership.CreateUser(item.USERNAME, rndPwd, item.EMAILID);
                                                mu = Membership.GetUser(item.USERNAME);
                                            }
                                            item.FORENAME = item.FORENAME.Length > 80 ? item.FORENAME.Substring(0, 80) : item.FORENAME;

                                            item.SURNAME = item.SURNAME != null && item.SURNAME != "" ? item.SURNAME.Length > 80 ? item.SURNAME.Substring(0, 80) : item.SURNAME : "";
                                            item.USERNAME = item.USERNAME.Length > 20 ? item.USERNAME.Substring(0, 20) : item.USERNAME;
                                            item.AspUserID = mu != null ? mu.UserName != null && mu.UserName != "" ? mu.UserName : item.USERNAME : item.USERNAME;

                                            item.Password = rndPwd;
                                            item.BusiD = Session["BuisnessId"].ToString();
                                            item.ACTIVE = item.ACTIVE != null ? item.ACTIVE == "" || item.ACTIVE.Length > 1 ? "N" : item.ACTIVE : "N";
                                            item.FORENAME = item.FORENAME.Replace("'", " ");
                                            item.SURNAME = item.SURNAME.Replace("'", " ");
                                            item.USERNAME = item.USERNAME.Replace("'", " ");

                                            if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                                            {
                                                item.MAPTOlst = item.MAPTO.Split(';').ToList();
                                                //item.MAPTOlst.Add(item.USERNAME);
                                            }
                                            else
                                            {
                                                mapTolSt.Add(item.MAPTO);
                                                //mapTolSt.Add(item.USERNAME);
                                                item.MAPTOlst = mapTolSt;
                                            }

                                            if (_dp.SaveImportedUser(item, conn))
                                            {
                                                count++;
                                                passListuser.Add(item);
                                            }
                                            else
                                            {
                                                failTable = failTable + "<tr><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.SURNAME + "</td><td  class='divpadder'>" + item.EMAILID + "</td><td  class='divpadder'>" + item.ROLE + "</td><td  class='divpadder'>" + item.ACTIVE + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                                failListuser.Add(item);
                                            }
                                        }
                                        else
                                        {
                                            failTable = failTable + "<tr><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.SURNAME + "</td><td  class='divpadder'>" + item.EMAILID + "</td><td  class='divpadder'>" + item.ROLE + "</td><td  class='divpadder'>" + item.ACTIVE + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                            failListuser.Add(item);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in dt.AsEnumerable().Select(s => new UserImportModel { USERNAME = s["USERNAME"].ToString(), FORENAME = s["FORENAME"].ToString(), SURNAME = s["SURNAME"].ToString(), EMAILID = s["EMAILID"].ToString(), ROLE = s["ROLE"].ToString(), ACTIVE = s["ACTIVE"].ToString(), MAPTO = s["MAPTO"].ToString() }))
                                {
                                    mapTolSt = new List<string>();
                                    if (item.USERNAME != "" && item.FORENAME != "" && item.ROLE != "" && item.EMAILID != "")
                                    {
                                        MembershipUser mu = Membership.GetUser(item.USERNAME);
                                        if (mu == null)
                                        {
                                            Membership.CreateUser(item.USERNAME, rndPwd, item.EMAILID);
                                            mu = Membership.GetUser(item.USERNAME);
                                        }
                                        item.FORENAME = item.FORENAME.Length > 80 ? item.FORENAME.Substring(0, 80) : item.FORENAME;

                                        item.SURNAME = item.SURNAME != null && item.SURNAME != "" ? item.SURNAME.Length > 80 ? item.SURNAME.Substring(0, 80) : item.SURNAME : "";
                                        item.USERNAME = item.USERNAME.Length > 20 ? item.USERNAME.Substring(0, 20) : item.USERNAME;
                                        item.AspUserID = mu != null ? mu.UserName != null && mu.UserName != "" ? mu.UserName : item.USERNAME : item.USERNAME;
                                        item.FORENAME = item.FORENAME.Replace("'", " ");
                                        item.SURNAME = item.SURNAME.Replace("'", " ");
                                        item.USERNAME = item.USERNAME.Replace("'", " ");
                                        item.Password = rndPwd;
                                        item.BusiD = Session["BuisnessId"].ToString();
                                        item.ACTIVE = item.ACTIVE != null ? item.ACTIVE == "" || item.ACTIVE.Length > 1 ? "N" : item.ACTIVE : "N";
                                        if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                                        {
                                            item.MAPTOlst = item.MAPTO.Split(';').ToList();
                                            // item.MAPTOlst.Add(item.USERNAME);
                                        }
                                        else
                                        {
                                            mapTolSt.Add(item.MAPTO);
                                            //mapTolSt.Add(item.USERNAME);
                                            item.MAPTOlst = mapTolSt;
                                        }

                                        if (_dp.SaveImportedUser(item, conn))
                                        {
                                            count++;
                                            passListuser.Add(item);
                                        }
                                        else
                                        {
                                            failTable = failTable + "<tr><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.SURNAME + "</td><td  class='divpadder'>" + item.EMAILID + "</td><td  class='divpadder'>" + item.ROLE + "</td><td  class='divpadder'>" + item.ACTIVE + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                            failListuser.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        failTable = failTable + "<tr><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.USERNAME + "</td><td  class='divpadder'>" + item.SURNAME + "</td><td  class='divpadder'>" + item.EMAILID + "</td><td  class='divpadder'>" + item.ROLE + "</td><td  class='divpadder'>" + item.ACTIVE + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                        failListuser.Add(item);
                                    }

                                }
                            }
                            if (passListuser.Count > 0 && isNew)
                            {
                                qryRslt = _dp.ExecutePassList(passListuser.Select(s => s.USERNAME).ToList(), Session["BuisnessId"].ToString(), "usr", conn);
                            }
                            else if (passListuser.Count > 0)
                            {
                                qryRslt = true;
                            }
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                        }
                        finally
                        {
                            if (qryRslt)
                            {
                                trans.Commit();
                            }
                            else
                            {
                                trans.Rollback();
                            }
                            conn.Close();
                            result.result = qryRslt;
                            result.failcount = failListuser.Count();
                            result.passcount = passListuser.Count();
                            result.faillisttbl = failTable + "</table>";

                        }
                    }
                    else if (Session["selectedctrl"].ToString().ToLower().Contains("emp"))
                    {
                        if (dt.Columns.Contains("ADDRESS1") || dt.Columns.Contains("USERNAME"))
                        {
                            result.result = false;
                            result.alertstring = "The file you have selected is not in the required format";
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                        failTable = failTable + "<tr  class='trHead'><th  class='divpadder'>EMPLOYEEID</th><th  class='divpadder'>FORENAME</th><th  class='divpadder'>SURNAME</th><th  class='divpadder'>STARthATE</th><th  class='divpadder'>ENDDATE</th><th  class='divpadder'>UCODE</th><th  class='divpadder'>MAPTO</th><th  class='divpadder'>MAPTOADDR</th></tr>";
                        failListemp = new List<EmployeeImportModel>();
                        passListemp = new List<EmployeeImportModel>();
                        bool userCreate = false;
                        userCreate = Convert.ToBoolean(_dp.BusinessParam("IGNORE_USER_CREATE", Session["BuisnessId"].ToString()));
                        conn.Open();
                        trans = conn.BeginTransaction();
                        try
                        {
                            //foreach (var item in dt.AsEnumerable().Select(s => new EmployeeImportModel { EMPLOYEEID = s["EMPLOYEEID"].ToString(), TITLE = s["TITLE"].ToString(), FORENAME = s["FORENAME"].ToString(), SURNAME = s["SURNAME"].ToString(), DEPARTMENT = s["DEPARTMENT"].ToString(), ENDDATE = s["ENDDATE"].ToString(), UCODE = s["UCODE"].ToString(), STARTDATE = s["STARTDATE"].ToString(), MAPTO = s["MAPTO"].ToString(), MAPTOADDR = s["MAPTOADDRESS"].ToString() }))
                            foreach (var item in dt.AsEnumerable().Select(s => new EmployeeImportModel { EMPLOYEEID = s["EMPLOYEEID"].ToString(), TITLE = s["TITLE"].ToString(), FORENAME = s["FORENAME"].ToString(), SURNAME = s["SURNAME"].ToString(), DEPARTMENT = s["DEPARTMENT"].ToString(), ENDDATE = s["ENDDATE"].ToString(), UCODE = s["UCODE"].ToString(), STARTDATE = s["STARTDATE"].ToString(), MAPTO = s["MAPTO"].ToString(), MAPTOADDR = s["MAPTOADDRESS"].ToString() }))
                            {
                                item.FORENAME = item.FORENAME.Replace("'", " ");
                                item.SURNAME = item.SURNAME.Replace("'", " ");
                                item.MAPTO = item.MAPTO.Replace("'", " ");
                                item.DEPARTMENT = item.DEPARTMENT.Replace("'", " ");
                                item.UCODE = item.UCODE.Replace("'", " ");
                                item.MAPTOADDR = item.MAPTOADDR.Replace("'", " ");
                                item.FORENAME = item.FORENAME.Length > 80 ? item.FORENAME.Substring(0, 80) : item.FORENAME;
                                item.SURNAME = item.SURNAME != null && item.SURNAME != "" ? item.SURNAME.Length > 80 ? item.SURNAME.Substring(0, 80) : item.SURNAME : "";
                                mapTolSt = new List<string>();
                                if (item.EMPLOYEEID != "" && item.FORENAME != "")
                                {
                                    if (item.UCODE != "" & item.UCODE.Contains(";"))
                                    {
                                        item.UCODEIDlst = item.UCODE.Split(';').ToList();
                                    }
                                    else
                                    {
                                        if (item.UCODE != "")
                                        {
                                            ucodLSt.Add(item.UCODE);
                                            item.UCODEIDlst = ucodLSt;
                                        }
                                        else
                                        {
                                            ucodLSt.Add(item.UCODE);
                                            item.UCODEIDlst = ucodLSt;
                                        }
                                    }
                                    if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                                    {
                                        item.MAPTOlst = item.MAPTO.Split(';').ToList();
                                    }
                                    else
                                    {
                                        if (item.MAPTO != "")
                                        {
                                            mapTolSt.Add(item.MAPTO);
                                            mapTolSt.Add(item.EMPLOYEEID);
                                            item.MAPTOlst = mapTolSt;
                                        }
                                        else
                                        {
                                            mapTolSt.Add(item.EMPLOYEEID);
                                            item.MAPTOlst = mapTolSt;
                                        }
                                    }
                                    if (item.MAPTOADDR != null && item.MAPTOADDR != "" & item.MAPTOADDR.Contains(";"))
                                    {
                                        item.MAPTOADDRLst = item.MAPTOADDR.Split(';').ToList();
                                    }
                                    else
                                    {
                                        if (item.MAPTOADDR != "")
                                        {
                                            addrList.Add(item.MAPTOADDR);

                                            item.MAPTOADDRLst = addrList;
                                        }
                                        else
                                        {
                                            addrList.Add(item.MAPTOADDR);
                                            item.MAPTOADDRLst = addrList;
                                        }
                                    }
                                    item.STARTDATE = item.STARTDATE != "" ? item.STARTDATE : DateTime.Now.ToString("dd-MM-yyyy");
                                    item.ENDDATE = item.ENDDATE != "" ? item.ENDDATE : DateTime.Now.ToString("dd-MM-yyyy");
                                    item.BusId = Session["BuisnessId"].ToString();
                                    MembershipUser mu = Membership.GetUser(item.EMPLOYEEID);
                                    if (mu == null && userCreate)
                                    {
                                        Membership.CreateUser(item.EMPLOYEEID, rndPwd, "");
                                        mu = Membership.GetUser(item.EMPLOYEEID);
                                    }
                                    item.EMPLOYEEID = mu.UserName != null && mu.UserName != "" ? mu.UserName : item.EMPLOYEEID;
                                    if (_dp.SaveImportedEmployee(item, conn, userCreate, rndPwd, false))
                                    {
                                        count++;
                                        passListemp.Add(item);
                                    }
                                    else
                                    {
                                        failTable = failTable + "<tr><td  class='divpadder'>" + item.EMPLOYEEID + "</td><td  class='divpadder'>" + item.FORENAME + "</td><td  class='divpadder'>" + item.SURNAME + "</td><td  class='divpadder'>" + item.STARTDATE + "</td><td  class='divpadder'>" + item.ENDDATE + "</td><td  class='divpadder'>" + item.UCODE + "</td><td  class='divpadder'>" + item.MAPTO + "</td><td  class='divpadder'>" + item.MAPTOADDR + "</td></tr>";
                                        failListemp.Add(item);
                                    }
                                }
                                else
                                {
                                    failTable = failTable + "<tr><td  class='divpadder'>" + item.EMPLOYEEID + "</td><td  class='divpadder'>" + item.FORENAME + "</td><td  class='divpadder'>" + item.SURNAME + "</td><td  class='divpadder'>" + item.STARTDATE + "</td><td  class='divpadder'>" + item.ENDDATE + "</td><td  class='divpadder'>" + item.UCODE + "</td><td  class='divpadder'>" + item.MAPTO + "</td><td  class='divpadder'>" + item.MAPTOADDR + "</td></tr>";
                                    failListemp.Add(item);
                                }
                            }
                            if (passListemp.Count > 0 && isNew)
                            {
                                qryRslt = _dp.ExecutePassList(passListemp.Select(s => s.EMPLOYEEID).ToList(), Session["BuisnessId"].ToString(), "emp", conn);
                            }
                            else if (passListemp.Count > 0)
                            {
                                qryRslt = true;
                            }
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                        }
                        finally
                        {
                            if (qryRslt)
                            {
                                trans.Commit();
                            }
                            else
                            {
                                trans.Rollback();
                            }
                            conn.Close();
                            result.result = qryRslt;
                            result.failcount = failListemp.Count();
                            result.passcount = passListemp.Count();
                            result.faillisttbl = failTable + "</table>";

                        }
                    }
                    else if (Session["selectedctrl"].ToString().ToLower().Contains("addr"))
                    {
                        if (dt.Columns.Contains("EMPLOYEEID") || dt.Columns.Contains("USERNAME"))
                        {
                            result.result = false;
                            result.alertstring = "The file you have selected is not in the required format";
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                        failTable = failTable + "<tr  class='trHead'><th  class='divpadder'>DESCRIPTION</th><th  class='divpadder'>ADDRESS1</th><th  class='divpadder'>ADDRESS2</th><th  class='divpadder'>ADDRESS3</th><th  class='divpadder'>TOWN</th><th  class='divpadder'>CITYCOUNTY</th><th  class='divpadder'>COUNTRY</th><th  class='divpadder'>POSTCODE</th><th  class='divpadder'>EMAIL</th><th  class='divpadder'>COSTCENTER</th><th  class='divpadder'>MAPTO</th></tr>";
                        failListaddr = new List<AddressImportModel>();
                        passListaddr = new List<AddressImportModel>();
                        conn.Open();
                        trans = conn.BeginTransaction();
                        try
                        {
                            if (dt.Columns.Contains("COSTCENTER"))
                            {
                                foreach (var item in dt.AsEnumerable().Select(s => new AddressImportModel { ADDRESS1 = s["ADDRESS1"].ToString(), ADDRESS2 = s["ADDRESS2"].ToString(), ADDRESS3 = s["ADDRESS3"].ToString(), TOWN = s["TOWN"].ToString(), CITYCOUNTY = s["CITY/COUNTY"].ToString(), POSTCODE = s["POSTCODE"].ToString(), COUNTRY = s["COUNTRY"].ToString(), CONTACTNAME = s["CONTACTNAME"].ToString(), EMAIL = s["EMAIL"].ToString(), TELEPHONE = s["TELEPHONE"].ToString(), COSTCENTER = s["COSTCENTER"].ToString(), DESCRIPTION = s["DESCRIPTION"].ToString(), MAPTO = s["MAPTO"].ToString(), }))
                                {
                                    item.ADDRESS1 = item.ADDRESS1.Replace("'", " ");
                                    item.ADDRESS2 = item.ADDRESS2.Replace("'", " ");
                                    item.DESCRIPTION = item.DESCRIPTION.Replace("'", " ");
                                    item.ADDRESS3 = item.ADDRESS3.Replace("'", " ");
                                    item.POSTCODE = item.POSTCODE.Replace("'", " ");
                                    item.TOWN = item.TOWN.Replace("'", " ");
                                    item.CITYCOUNTY = item.CITYCOUNTY.Replace("'", " ");
                                    item.COUNTRY = item.COUNTRY.Replace("'", " ");
                                    item.CONTACTNAME = item.CONTACTNAME.Replace("'", " ");
                                    item.MAPTO = item.MAPTO.Replace("'", " ");

                                    item.BUSINESSID = Session["BuisnessId"].ToString();
                                    mapTolSt = new List<string>();
                                    telList = new List<string>();
                                    emalList = new List<string>();
                                    cstCtre = new List<string>();
                                    cntList = new List<string>();
                                    if (item.DESCRIPTION != "" && item.ADDRESS1 != "" && item.TOWN != "" && item.POSTCODE != "")
                                    {
                                        if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                                        {
                                            item.MAPTOlst = item.MAPTO.Split(';').ToList();
                                        }
                                        else
                                        {
                                            mapTolSt.Add(item.MAPTO);
                                            item.MAPTOlst = mapTolSt;
                                        }
                                        if (item.TELEPHONE != "" && item.TELEPHONE.Contains(","))
                                        {
                                            item.TELEPHONElst = item.TELEPHONE.Split(';').ToList();
                                        }
                                        else
                                        {
                                            telList.Add(item.TELEPHONE);
                                            item.TELEPHONElst = telList;
                                        }
                                        if (item.EMAIL != "" && item.EMAIL.Contains(","))
                                        {
                                            item.EMAILlst = item.EMAIL.Split(';').ToList();
                                        }
                                        else
                                        {
                                            emalList.Add(item.EMAIL);
                                            item.EMAILlst = emalList;
                                        }
                                        if (item.CONTACTNAME != "" && item.CONTACTNAME.Contains(","))
                                        {
                                            item.CONTACTNAMElst = item.CONTACTNAME.Split(';').ToList();
                                        }
                                        else
                                        {
                                            cntList.Add(item.CONTACTNAME);
                                            item.CONTACTNAMElst = emalList;
                                        }
                                        if (item.COSTCENTER != "" && item.COSTCENTER.Contains(","))
                                        {
                                            item.COSTCENTERlst = item.COSTCENTER.Split(';').ToList();
                                        }
                                        else
                                        {
                                            cstCtre.Add(item.COSTCENTER);
                                            item.COSTCENTERlst = cstCtre;
                                        }
                                        if (item.EMAIL != "" && item.EMAIL.Contains(","))
                                        {
                                            item.EMAILlst = item.EMAIL.Split(';').ToList();
                                        }
                                        else
                                        {
                                            emalList.Add(item.EMAIL);
                                            item.EMAILlst = emalList;
                                        }
                                        var resultVal = _dp.SaveImportedAddress(item, conn);
                                        if (resultVal.result)
                                        {
                                            count++;
                                            passListaddr.Add(item);
                                        }
                                        else
                                        {
                                            failTable = failTable + "<tr><td  class='divpadder'>" + item.DESCRIPTION + "</td><td  class='divpadder'>" + item.ADDRESS1 + "</td><td  class='divpadder'>" + item.ADDRESS2 + "</td><td  class='divpadder'>" + item.ADDRESS3 + "</td><td  class='divpadder'>" + item.TOWN + "</td><td  class='divpadder'>" + item.CITYCOUNTY + "</td><td  class='divpadder'>" + item.COUNTRY + "</td><td  class='divpadder'>" + item.POSTCODE + "</td><td  class='divpadder'>" + item.EMAIL + "</td><td  class='divpadder'>" + item.COSTCENTER + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                            failListaddr.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        failTable = failTable + "<tr><td  class='divpadder'>" + item.DESCRIPTION + "</td><td  class='divpadder'>" + item.ADDRESS1 + "</td><td  class='divpadder'>" + item.ADDRESS2 + "</td><td  class='divpadder'>" + item.ADDRESS3 + "</td><td  class='divpadder'>" + item.TOWN + "</td><td  class='divpadder'>" + item.CITYCOUNTY + "</td><td  class='divpadder'>" + item.COUNTRY + "</td><td  class='divpadder'>" + item.POSTCODE + "</td><td  class='divpadder'>" + item.EMAIL + "</td><td  class='divpadder'>" + item.COSTCENTER + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                        failListaddr.Add(item);
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in dt.AsEnumerable().Select(s => new AddressImportModel { ADDRESS1 = s["ADDRESS1"].ToString(), ADDRESS2 = s["ADDRESS2"].ToString(), ADDRESS3 = s["ADDRESS3"].ToString(), TOWN = s["TOWN"].ToString(), CITYCOUNTY = s["CITY/COUNTY"].ToString(), POSTCODE = s["POSTCODE"].ToString(), COUNTRY = s["COUNTRY"].ToString(), CONTACTNAME = s["CONTACTNAME"].ToString(), EMAIL = s["EMAIL"].ToString(), TELEPHONE = s["TELEPHONE"].ToString(), DESCRIPTION = s["DESCRIPTION"].ToString(), MAPTO = s["MAPTO"].ToString(), }))
                                {
                                    item.ADDRESS1 = item.ADDRESS1.Replace("'", " ");
                                    item.ADDRESS2 = item.ADDRESS2.Replace("'", " ");
                                    item.DESCRIPTION = item.DESCRIPTION.Replace("'", " ");
                                    item.ADDRESS3 = item.ADDRESS3.Replace("'", " ");
                                    item.POSTCODE = item.POSTCODE.Replace("'", " ");
                                    item.TOWN = item.TOWN.Replace("'", " ");
                                    item.CITYCOUNTY = item.CITYCOUNTY.Replace("'", " ");
                                    item.COUNTRY = item.COUNTRY.Replace("'", " ");
                                    item.CONTACTNAME = item.CONTACTNAME.Replace("'", " ");
                                    item.MAPTO = item.MAPTO.Replace("'", " ");
                                    item.BUSINESSID = Session["BuisnessId"].ToString();
                                    mapTolSt = new List<string>();
                                    telList = new List<string>();
                                    emalList = new List<string>();
                                    cstCtre = new List<string>();
                                    cntList = new List<string>();
                                    if (item.DESCRIPTION != "" && item.ADDRESS1 != "" && item.TOWN != "" && item.POSTCODE != "")
                                    {
                                        var addr = _busAddress.Exists(s => s.Description.ToLower().Trim() == item.DESCRIPTION.ToLower().Trim() && s.Postcode.ToLower().Trim() == item.POSTCODE.ToLower().Trim()) ? _busAddress.GetAll(s => s.Description.ToLower().Trim() == item.DESCRIPTION.ToLower().Trim() && s.Postcode.ToLower().Trim() == item.POSTCODE.ToLower().Trim()).First() : new tblbus_address();
                                        if (addr.AddressID > 0 && addr.ContactID > 0)
                                        {
                                            item.ADDRESSID = addr.AddressID;
                                            item.CONTACTID = Convert.ToInt32(addr.ContactID);
                                        }
                                        if (item.MAPTO != "" & item.MAPTO.Contains(";"))
                                        {
                                            item.MAPTOlst = item.MAPTO.Split(';').ToList();
                                        }
                                        else
                                        {
                                            mapTolSt.Add(item.MAPTO);
                                            item.MAPTOlst = mapTolSt;
                                        }
                                        if (item.TELEPHONE != "" && item.TELEPHONE.Contains(";"))
                                        {
                                            item.TELEPHONElst = item.TELEPHONE.Split(';').ToList();
                                        }
                                        else
                                        {
                                            telList.Add(item.TELEPHONE);
                                            item.TELEPHONElst = telList;
                                        }
                                        if (item.EMAIL != "" && item.EMAIL.Contains(";"))
                                        {
                                            item.EMAILlst = item.EMAIL.Split(';').ToList();
                                        }
                                        else
                                        {
                                            emalList.Add(item.EMAIL);
                                            item.EMAILlst = emalList;
                                        }
                                        if (item.CONTACTNAME != "" && item.CONTACTNAME.Contains(";"))
                                        {
                                            item.CONTACTNAMElst = item.CONTACTNAME.Split(';').ToList();
                                        }
                                        else
                                        {
                                            cntList.Add(item.CONTACTNAME);
                                            item.CONTACTNAMElst = cntList;
                                        }
                                        if (item.EMAIL != "" && item.EMAIL.Contains(";"))
                                        {
                                            item.EMAILlst = item.EMAIL.Split(';').ToList();
                                        }
                                        else
                                        {
                                            emalList.Add(item.EMAIL);
                                            item.EMAILlst = emalList;
                                        }
                                        var resultVal = _dp.SaveImportedAddress(item, conn);
                                        if (resultVal.result)
                                        {
                                            count++;
                                            passListaddr.Add(item);
                                        }
                                        else
                                        {
                                            failTable = failTable + "<tr><td  class='divpadder'>" + item.DESCRIPTION + "</td><td  class='divpadder'>" + item.ADDRESS1 + "</td><td  class='divpadder'>" + item.ADDRESS2 + "</td><td  class='divpadder'>" + item.ADDRESS3 + "</td><td  class='divpadder'>" + item.TOWN + "</td><td  class='divpadder'>" + item.CITYCOUNTY + "</td><td  class='divpadder'>" + item.COUNTRY + "</td><td  class='divpadder'>" + item.POSTCODE + "</td><td  class='divpadder'>" + item.EMAIL + "</td><td  class='divpadder'>" + item.COSTCENTER + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                            failListaddr.Add(item);
                                            failListaddr.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        failTable = failTable + "<tr><td  class='divpadder'>" + item.DESCRIPTION + "</td><td  class='divpadder'>" + item.ADDRESS1 + "</td><td  class='divpadder'>" + item.ADDRESS2 + "</td><td  class='divpadder'>" + item.ADDRESS3 + "</td><td  class='divpadder'>" + item.TOWN + "</td><td  class='divpadder'>" + item.CITYCOUNTY + "</td><td  class='divpadder'>" + item.COUNTRY + "</td><td  class='divpadder'>" + item.POSTCODE + "</td><td  class='divpadder'>" + item.EMAIL + "</td><td  class='divpadder'>" + item.COSTCENTER + "</td><td  class='divpadder'>" + item.MAPTO + "</td></tr>";
                                        failListaddr.Add(item);
                                    }
                                }

                            }
                            if (passListaddr.Count > 0 && isNew)
                            {
                                qryRslt = _dp.ExecutePassList(passListaddr.Select(s => s.ADDRESSID.ToString()).ToList(), Session["BuisnessId"].ToString(), "adr", conn);
                            }
                            else if (passListaddr.Count > 0)
                            {
                                qryRslt = true;
                            }
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                        }
                        finally
                        {
                            if (qryRslt)
                            {

                                trans.Commit();
                            }
                            else
                            {
                                trans.Rollback();
                            }
                            conn.Close();
                            result.result = qryRslt;
                            result.failcount = failListaddr.Count();
                            result.passcount = passListaddr.Count();
                            result.faillisttbl = failTable + "</table>";
                        }
                    }
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region SetCtrlSession
        public void SetCtrlSession(string tabName)
        {
            if (tabName != "")
            {
                Session["selectedctrl"] = tabName.Trim().ToLower();
            }
        }
        #endregion


        #region RemoveSelected
        public bool RemoveSelected(List<UserImportModel> selectedValues)
        {
            bool result = false;
            string updString = "";
            string sql = "";
            MySqlConnection conn = new MySqlConnection(connectionStr);
            MySqlTransaction trans;
            conn.Open();
            trans = conn.BeginTransaction();
            if (selectedValues != null && selectedValues.Count() > 0)
            {
                if (Session["selectedctrl"].ToString().ToLower().Trim().Contains("user"))
                {
                    try
                    {
                        updString = "'" + string.Join("','", selectedValues.Where(s => s.USERNAME != "").Select(s => s.USERNAME).ToList()) + "'";
                        //foreach (var data in selectedValues)
                        //{
                        sql = "Update tblusers set Active='N' where username in(" + updString + ") And businessid='" + Session["BuisnessId"].ToString() + "'";
                        if (_dp.ExecuteQuery(conn, sql) >= 0)
                        {
                            result = true;
                        }
                        //}
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        if (result)
                            trans.Commit();
                        else
                            trans.Rollback();
                        conn.Close();
                    }
                }
                else if (Session["selectedctrl"].ToString().ToLower().Trim().Contains("emp"))
                {
                    try
                    {
                        updString = "'" + string.Join(",',", selectedValues.Where(s => s.USERNAME != "").Select(s => s.USERNAME).ToList()) + "'";

                        sql = "Update tblaccemp_employee set Active='N' where employeeid in(" + updString + ") And businessid='" + Session["BuisnessId"].ToString() + "'";
                        if (_dp.ExecuteQuery(conn, sql) >= 0)
                        {
                            result = true;
                        }

                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        if (result)
                            trans.Commit();
                        else
                            trans.Rollback();
                        conn.Close();
                    }
                }
                else if (Session["selectedctrl"].ToString().ToLower().Trim().Contains("addr"))
                {
                    try
                    {
                        foreach (var data in selectedValues)
                            if (_busAddress.Exists(s => s.Description == data.USERNAME && s.Postcode == data.FORENAME))
                            {
                                var addr = _busAddress.GetAll(s => s.Description == data.USERNAME && s.Postcode == data.FORENAME).First();
                                sql = "DELETE FROM tblonline_emp_address WHERE BusinessID='" + addr.BusinessID + "' AND CompanyID='" + Session["CmpId"].ToString() + "' AND AddressID=" + addr.AddressID;
                                if (_dp.ExecuteQuery(conn, sql) >= 0)
                                {
                                    sql = "";
                                    sql = "Delete From tblbus_address WHERE BusinessID='" + addr.BusinessID + "' AND CompanyID='" + Session["CmpId"].ToString() + "' AND AddressTypeID=3 AND AddressID=" + addr.AddressID;
                                    if (_dp.ExecuteQuery(conn, sql) >= 1)
                                    {
                                        sql = "";
                                        sql = "DELETE FROM tblBus_Contact WHERE ContactID=" + addr.ContactID;
                                        if (_dp.ExecuteQuery(conn, sql) >= 1)
                                        {
                                            result = true;
                                        }
                                    }
                                }

                            }
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        if (result)
                            trans.Commit();
                        else
                            trans.Rollback();
                        conn.Close();
                    }
                }
            }
            return result;
        }
        #endregion

        public ActionResult UploadControlUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControl", ImportExportControllerUploadControlSettings.UploadValidationSettings, ImportExportControllerUploadControlSettings.FileUploadComplete);
            return null;
        }
        public ActionResult exporter()
        {
            var sett = ExpGridViewSettings(Session["selectedctrl"].ToString());
            dynamic model;
            if (Session["selectedctrl"].ToString().ToLower().Contains("user"))
            {
                model = ((ImpExptModel)Session["ImpExptModel"]).UserModel;
                return GridViewExtension.ExportToXls(sett, model);
            }
            else if (Session["selectedctrl"].ToString().ToLower().Contains("emp"))
            {
                model = ((ImpExptModel)Session["ImpExptModel"]).EmpModel;
                return GridViewExtension.ExportToXls(sett, model);
            }
            else if (Session["selectedctrl"].ToString().ToLower().Contains("addr"))
            {
                model = ((ImpExptModel)Session["ImpExptModel"]).AddressModel;
                return GridViewExtension.ExportToXls(sett, model);
            }
            return null;

        }

        public GridViewSettings ExpGridViewSettings(string type)
        {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = type.ToLower().Contains("user") ? "UserExport" : type.ToLower().Contains("emp") ? "EmployeeExport" : "AddressExport";
            if (type.ToLower().Contains("user"))
            {
                settings.KeyFieldName = "UserName";
                settings.Columns.Add("UserName").Caption = "USERNAME";
                settings.Columns.Add("ForeName").Caption = "FORENAME";
                settings.Columns.Add("SurName").Caption = "SURNAME";
                settings.Columns.Add("Email").Caption = "EMAILID";
                settings.Columns.Add("AccessRole").Caption = "ROLE";
                settings.Columns.Add("Active1").Caption = "ACTIVE";
                settings.Columns.Add("MapTo").Caption = "MAPTO";
                //settings.Columns.Add("RolloutName");
            }
            else if (type.ToLower().Contains("emp"))
            {
                settings.KeyFieldName = "EMPLOYEEID";
                settings.Columns.Add("EMPLOYEEID");
                settings.Columns.Add("TITLE");
                settings.Columns.Add("FORENAME");
                settings.Columns.Add("SURNAME");
                settings.Columns.Add("DEPARTMENT");
                settings.Columns.Add("STARTDATE");
                settings.Columns.Add("ENDDATE");
                settings.Columns.Add("UCODE");
                settings.Columns.Add("MAPTO");
                settings.Columns.Add("MAPTOADDR").Caption="MAPTOADDRESS";
            }
            else if (type.ToLower().Contains("addr"))
            {
                settings.KeyFieldName = "ADDRESSID";
                settings.Columns.Add("DESCRIPTION");
                settings.Columns.Add("ADDRESS1");
                settings.Columns.Add("ADDRESS2");
                settings.Columns.Add("ADDRESS3");
                settings.Columns.Add("TOWN");
                settings.Columns.Add("CITYCOUNTY").Caption = "CITY/COUNTY";
                settings.Columns.Add("POSTCODE");
                settings.Columns.Add("COUNTRY");
                settings.Columns.Add("CONTACTID");
                settings.Columns.Add("CONTACTNAME");
                settings.Columns.Add("TELEPHONE");
                settings.Columns.Add("EMAIL");
                settings.Columns.Add("COSTCENTER");
                settings.Columns.Add("MAPTO");
            }
            return settings;
        }


    }
    public class ImportExportControllerUploadControlSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".xls", ".xlsx", ".csv" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {

                string path = HttpContext.Current.Request.MapPath(@"~\uploadfiles");
                string foldername = "";
                string orgfileName = "";
                string filename = "";
                foldername = string.Format(@"{0}\{1}", path, "Import");
                orgfileName = string.Format(@"{0}_{1}", DateTime.Now.ToString("ddMMyyyy"), e.UploadedFile.FileName);
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(foldername);
                if (!di.Exists)
                {
                    di.Create();
                }
                filename = string.Format(@"{0}\{1}", foldername, orgfileName);
                e.UploadedFile.SaveAs(filename);
                System.Web.HttpContext.Current.Session["importfilename"] = filename;
            }
        }
    }

    public class InMemoryModel
    {
        public DataTable OpenExcelFile(string fileName)
        {
            DataTable dataTable = new DataTable();
            string connectionString = "";
            try
            {
                connectionString = fileName.ToLower().Contains(".xlsx") == false ? string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName) : string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", fileName);
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                adapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                try
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet$]", connectionString);
                    adapter.Fill(dataTable);
                }
                catch (Exception e1)
                {

                }

            }
            return dataTable;
        }
    }

}
















