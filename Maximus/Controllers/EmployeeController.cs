using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Models;
using Maximus.Filter;
using System.Data;

namespace Maximus.Controllers
{

    [CustomFilter]
    public class EmployeeController : Controller
    {
        // GET: Employee
        #region declarations
        DataProcessing dp = new DataProcessing();
        e4kmaximusdbEntities entity = new e4kmaximusdbEntities();
        #endregion

        #region Index and EmpGrid
        public ActionResult Index(string BusinessID)
        {
            Session["cardRows"] = 10;
            Session["cardColumns"] = 1;
            Session["ColorSizestyle"] = Session["ColorSizestyle"] == null ? "SWATCHES" : Session["ColorSizestyle"].ToString();
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
            else
            {
                if (Session["SalesOrderHeader"] == null)
                {
                    Session["qty"] = "0";
                    Session["SalesOrderHeader"] = new List<SalesOrderHeaderViewModel>();
                    Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
                }
            }
            if (Session["EmployeeViewModel"] == null)
            {
                Session["EmployeeViewModel"] = (List<EmployeeViewModel>)dp.GetEmployeeByProcedure(Session["BuisnessId"].ToString(), Session["UserName"].ToString()); 
                if(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).Count==1)
                {
                    if(!((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes.Contains(','))
                    {
                        //((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().em.Contains(',')
                        //GotoCard(((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmployeeId, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpFirstName + " " + ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpLastName, ((List<EmployeeViewModel>)Session["EmployeeViewModel"]).First().EmpUcodes);
                    }
                }
            }
            return View("Employee");
        }

        public JsonResult GetEmployeeResultValue()
        {
            var arr = (List<EmployeeViewModel>)Session["EmployeeViewModel"];
            var jsonResult = Json(new { arr }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


        public ActionResult EmployeeGridViewPartial(string txtUcode = "", string ddlAddress = "", string txtUcodeDesc = "", string txtCDepartment = "", string txtRole = "", string txtEmpNo = "", string txtName = "", string txtStDate = "")
        {
            var templates = new List<string>();
            var businessId = Session["BuisnessId"].ToString();
            templates = entity.tblsop_customerorder_template.Any(x => x.BusinessID == businessId) ? entity.tblsop_customerorder_template.Where(x => x.BusinessID == businessId).OrderBy(x => x.SeqNo).Select(x => x.Template).Distinct().ToList() : new List<string>();

            Session["SalesOrderLines"] = new List<SalesOrderLineViewModel>();
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count > 0)
            {
                var modelq = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
                Session["SalesOrderLine"] = new List<SalesOrderLineViewModel>();
            }
            var result = new List<EmployeeViewModel>();

            if (templates.Count > 0)
            {
                Session["Templates"] = templates;
                result = dp.getEmployeeDetailsTemplates(Session["BuisnessId"].ToString());
            }
            else
            {
                Session["Templates"] = new List<string>();
                result = dp.GetEmployee(businessId, Session["UserName"].ToString(), Session["OrderPermit"].ToString(), txtUcode, ddlAddress, txtUcodeDesc, txtCDepartment, txtRole, txtEmpNo, txtName, txtStDate);
                Session["EmployeeModel"] = result;
            }
            if (txtUcode != "" && txtEmpNo != "" && txtCDepartment != "" && txtRole != "" && txtName != "")
            {
                result = result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower()) && x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower()) && x.Department.ToLower().Contains(txtCDepartment.ToLower()) && x.role.ToLower().Contains(txtRole.ToLower()) && (x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower()))).ToList();
            }
            if (txtUcode != "")
            {
                result = result.Where(x => x.EmpUcodes.ToLower().Contains(txtUcode.ToLower())).ToList();
            }
            if (txtCDepartment != "")
            {
                result = result.Where(x => x.Department.ToLower().Contains(txtCDepartment.ToLower())).ToList();
            }
            if (txtRole != "")
            {
                result = result.Where(x => x.role.ToLower().Contains(txtRole.ToLower())).ToList();
            }
            if (txtEmpNo != "")
            {
                result = result.Where(x => x.EmployeeId.ToLower().Contains(txtEmpNo.ToLower())).ToList();
            }
            if (txtName != "")
            {
                result = result.Where(x => x.EmpFirstName.ToLower().Contains(txtName.ToLower()) || x.EmpLastName.ToLower().Contains(txtName.ToLower())).ToList();
            }

            return PartialView("_EmployeeGridViewPartial", result);
        }

        public List<string> GetAutocompleteVal(string keyword = "")
        {
            List<string> data = new List<string>();
            if (((List<SalesOrderLineViewModel>)Session["EmployeeModel"]).Count > 0)
            {
                var result = (List<SalesOrderLineViewModel>)Session["EmployeeModel"];
                data = result.Where(x => x.EmployeeId.Contains(keyword)).Select(x => x.EmployeeId).ToList();
                return data;
            }
            return data;
        }

        #endregion

        #region cardRedirection
        public string GotoCard(string EmployeeId, string EmpName, string Ucodes)
        {
            Session["EmpName"] = EmpName;
            Session["SelectedEmp"] = EmployeeId;
            string ucodeHtml = "<p style=\"padding:0px;\">";
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
            {
                var s = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]);
                var EMP = Session["SelectedEmp"].ToString();
                if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null))
                {
                    if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.EmployeeID == EMP))
                    {
                        if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null)
                        {
                            Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Sum(x => x.OrdQty);
                        }

                    }
                    else
                    {
                        Session["qty"] = 0;
                    }
                }
                //Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Sum(x => x.OrdQty) : 0 : 0;
            }
            else
            {
                Session["qty"] = 0;
            }
            var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var emp = Session["SelectedEmp"].ToString();
            var busine = Session["BuisnessId"].ToString();
            var address1 = dp.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
            var addArr = new string[] { };
            var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
            string businessId = Session["BuisnessId"].ToString();
            salesOrderHeader.Add(new SalesOrderHeaderViewModel
            {
                DelDesc = addresArr.Count() > 0 ? addresArr[0] : "",
                DelAddress1 = addresArr.Count() > 0 ? addresArr[1] : "",
                DelAddress2 = addresArr.Count() > 0 ? addresArr[2] : "",
                DelAddress3 = addresArr.Count() > 0 ? addresArr[3] : "",
                DelTown = addresArr.Count() > 0 ? addresArr[4] : "",
                DelCity = addresArr.Count() > 0 ? addresArr[5] : "",
                DelPostCode = addresArr.Count() > 0 ? addresArr[6] : "",
                DelCountry = addresArr.Count() > 0 ? addresArr[7] : "",
                EmployeeName = Session["EmpName"].ToString(),
                EmployeeID = Session["SelectedEmp"].ToString(),
                //CustRef = entity.tblsop_salesorder_header.Where(x => x.CustID == businessId).First().CustRef,
                //Comments = entity.tblsop_salesorder_header.Where(x => x.CustID == businessId).First().Comments,
            });
            List<string> ucodeLst = new List<string>();
            List<UcodeModel> ucodeLst1 = new List<UcodeModel>();
            if (Ucodes.Contains(';'))
            {
                foreach (var str in Ucodes.Split(';'))
                {
                    ucodeLst.Add(str);

                }

            }
            Session["SelectedUcode"] = Ucodes;

            if (ucodeLst.Count > 0)
            {
                foreach (string ucode in ucodeLst)
                {
                    string ucodeDesc = entity.tblaccemp_ucodes_desc.Any(x => x.UCodeID == ucode) ? entity.tblaccemp_ucodes_desc.Where(x => x.UCodeID == Ucodes).First().Description : ucode;
                    ucodeHtml = ucodeHtml + " <span>" + ucode + "</span>-<span>" + ucodeDesc + "</span> ";
                    ucodeLst1.AddRange(entity.ucodeby_freetextview.Where(x => x.UCodeID == ucode).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList());

                }
            }
            else
            {
                try
                {
                    string ucodeDesc = entity.tblaccemp_ucodes_desc.Any(x => x.UCodeID == Ucodes) ? entity.tblaccemp_ucodes_desc.Where(x => x.UCodeID == Ucodes).First().Description : Ucodes;
                    ucodeHtml = ucodeHtml + " <span>" + Ucodes + "</span>-<span>" + ucodeDesc + "</span> ";
                    ucodeLst1 = entity.ucodeby_freetextview.Where(x => x.UCodeID == Ucodes).Select(x => new UcodeModel { StyleId = x.StyleID, FreeText = x.FreeText }).ToList();
                }
                catch (Exception e)
                {

                }

            }
            ucodeHtml = ucodeHtml + "</p>";
            Session["UcodeDesc"] = ucodeHtml.ToString();
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
        #endregion

        #region TemplateRedirection
        public string GotoCardTemplate(string EmployeeId, string EmpName, string Template)
        {
            string result = "";
            Session["EmpName"] = EmpName;
            Session["SelectedEmp"] = EmployeeId;
            string templateHtml = "<ol style=\"padding:0px;\">";
            if (((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Count() > 0)
            {
                Session["qty"] = ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Any(x => x.SalesOrderLine != null) ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine != null ? ((List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"]).Where(x => x.EmployeeID == Session["SelectedEmp"].ToString()).First().SalesOrderLine.Sum(x => x.OrdQty) : 0 : 0;
            }
            else
            {
                Session["qty"] = 0;
            }
            var salesOrderHeader = (List<SalesOrderHeaderViewModel>)Session["SalesOrderHeader"];
            var emp = Session["SelectedEmp"].ToString();
            var busine = Session["BuisnessId"].ToString();
            var address1 = dp.getEmployeeAddress(Session["SelectedEmp"].ToString(), Session["BuisnessId"].ToString());
            var addArr = new string[] { };
            var addresArr = address1.Contains(',') ? address1.Split(',') : addArr;
            string businessId = Session["BuisnessId"].ToString();
            salesOrderHeader.Add(new SalesOrderHeaderViewModel
            {
                DelDesc = addresArr.Count() > 0 ? addresArr[0] : "",
                DelAddress1 = addresArr.Count() > 0 ? addresArr[1] : "",
                DelAddress2 = addresArr.Count() > 0 ? addresArr[2] : "",
                DelAddress3 = addresArr.Count() > 0 ? addresArr[3] : "",
                DelTown = addresArr.Count() > 0 ? addresArr[4] : "",
                DelCity = addresArr.Count() > 0 ? addresArr[5] : "",
                DelPostCode = addresArr.Count() > 0 ? addresArr[6] : "",
                DelCountry = addresArr.Count() > 0 ? addresArr[7] : "",
                EmployeeName = Session["EmpName"].ToString(),
                EmployeeID = Session["SelectedEmp"].ToString(),
                //CustRef = entity.tblsop_salesorder_header.Where(x => x.CustID == businessId).First().CustRef,
                //Comments = entity.tblsop_salesorder_header.Where(x => x.CustID == businessId).First().Comments,
            });
            List<string> templateLst = new List<string>();

            if (Template.Contains(';'))
            {
                foreach (var str in Template.Split(';'))
                { templateLst.Add(str); }

            }
            else
            {
                templateLst.Add(Template);
            }

            Session["SelectedTemplate"] = templateLst;
            if (templateLst.Count > 0)
            {
                foreach (string temp in templateLst)
                {
                    templateHtml = templateHtml + "<li><span>" + temp + "</span></li>";
                }
            }
            else
            {
                try
                {
                    templateHtml = templateHtml + "<li><span>" + Template + "</span> ></li>";
                }
                catch (Exception e)
                {

                }

            }
            templateHtml = templateHtml + "</ol>";
            Session["UcodeDesc"] = templateHtml.ToString();
            return Url.Content("~/Home/Index");
        }
        #endregion

        #region Edit Employee
        public ActionResult EditEmployee(string empId)
        {
            var templates = (List<string>)Session["Templates"];
            var result = new EmployeeViewModel();
            string busId = Session["BuisnessId"].ToString();
            if (templates.Count > 0)
            {
                Session["Templates"] = templates;
                result = dp.getEmployeeDetailsTemplatesById(busId, empId);
            }
            else
            {

                result = dp.GetEmployeeById(Session["BuisnessId"].ToString(), empId);
            }

            result.DepartmentLst = entity.tblaccemp_departments.Where(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            result.ucodeLst = entity.tblaccemp_ucodesemployees.Where(x => x.BusinessID == busId).Select(x => x.UCodeID).Distinct().ToList();
            int addId = dp.GetAddressId(busId, empId);
            result.Address = addId > 0 ? entity.tblbus_address.Where(x => x.AddressID == addId).Select(x => new BusAddress { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, Country = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).FirstOrDefault() : new BusAddress();
            result.AddressLst = entity.tblbus_address.Where(x => x.BusinessID == busId).Select(x => new BusAddress { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, Country = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
            return PartialView("_EmployeeEdit", result);
        }
        [HttpPost]
        public string EditEmployee(DateTime StartDate, DateTime EndDate, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", bool isActive = false)
        {
            try
            {
                if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "" & Department != "" & Address != "" & StartDate != null & EndDate != null)
                {
                    string busId = Session["BuisnessId"].ToString();
                    var templates = (List<string>)Session["Templates"];
                    var cmpId = entity.tblaccemp_employee.Where(x => x.BusinessID == busId & x.EmployeeID == EmployeeId).Select(x => x.CompanyID).First();
                    var deptData = entity.tblaccemp_departments.Where(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID;
                    var emp = entity.tblaccemp_employee.Where(x => x.EmployeeID == EmployeeId && x.BusinessID == busId).First();
                    emp.Forename = EmpFirstName;
                    emp.Surname = EmpLastName;
                    emp.DepartmentID = deptData;
                    emp.EmployeeClosed = isActive == false ? Convert.ToSByte(true) : Convert.ToSByte(false);
                    emp.StartDate = StartDate;
                    emp.EndDate = EndDate;
                    entity.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    var busAddsId = entity.tblbus_address.Where(x => x.Description == Address).First().AddressID;
                    if (templates.Count == 0)
                    {
                        var ucodes = entity.tblaccemp_ucodesemployees.Where(x => x.BusinessID == busId & x.EmployeeID == EmployeeId).Select(x => x.UCodeID.Trim()).ToList();
                        if (EmpUcodes.Contains(';'))
                        {
                            foreach (string ucode in EmpUcodes.Split(';'))
                            {
                                if (!ucodes.Contains(ucode.Trim()))
                                {
                                    var updateUcode = new tblaccemp_ucodesemployees();
                                    updateUcode.CompanyID = cmpId;
                                    updateUcode.UCodeID = ucode;
                                    updateUcode.EmployeeID = EmployeeId;
                                    updateUcode.BusinessID = busId;
                                    entity.Entry(updateUcode).State = System.Data.Entity.EntityState.Added;

                                }


                            }
                        }
                        else
                        {
                            if (ucodes.Contains(EmpUcodes))
                            {
                                ucodes.Remove(EmpUcodes);
                                var ucode1 = ucodes[0];
                                dp.DeleteEmployee(ucode1, EmployeeId, busId);
                            }
                        }
                    }
                    if (entity.SaveChanges() > 0)
                    {
                        int res = dp.UpdateEmployee(Convert.ToInt32(cmpId), Convert.ToInt32(busAddsId), EmployeeId, busId);
                        if (res > -1)
                        {
                            return "success";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "Validation";
                }
            }
            catch (Exception e)
            {

            }
            return "";
        }
        #endregion

        #region createEmployee
        public ActionResult CreateNewEmployee()
        {
            var result = new EmployeeViewModel();
            string busId = Session["BuisnessId"].ToString();
            result.ucodeLst = entity.tblaccemp_ucodesemployees.Where(x => x.BusinessID == busId).Select(x => x.UCodeID).Distinct().ToList();
            result.DepartmentLst = entity.tblaccemp_departments.Where(x => x.BusinessID == busId).Select(x => x.Department).ToList();
            result.Address = new BusAddress();
            result.EmpMap = true;
            result.AddressLst = entity.tblbus_address.Where(x => x.BusinessID == busId).Select(x => new BusAddress { Address1 = x.Address1, Address2 = x.Address2, Address3 = x.Address3, City = x.City, Country = x.CountryCode.Value, PostCode = x.Postcode, AddressDescription = x.Description, AddressId = x.AddressID }).ToList();
            ViewBag.create = true;
            return PartialView("_EmployeeEdit", result);
        }
        [HttpPost]
        public string CreateNewEmployee(DateTime StartDate, DateTime EndDate, string EmpFirstName = "", string EmpLastName = "", string EmployeeId = "", string EmpUcodes = "", string Address = "", string Department = "", bool isActive = false,bool isMapped=false)
        {
            try
            {
                if (EmpFirstName != "" & EmpLastName != "" & EmployeeId != "" & Department != "" & Address != "" & StartDate != null & EndDate != null)
                {
                    var templates = (List<string>)Session["Templates"];
                    string busId = Session["BuisnessId"].ToString();
                    var deptData = entity.tblaccemp_departments.Where(x => x.BusinessID == busId && x.Department == Department).First().DepartmentID;
                    var cmpId = entity.tblaccemp_employee.Where(x => x.BusinessID == busId).First().CompanyID;
                    var emp = new tblaccemp_employee();
                    emp.CompanyID = cmpId;
                    emp.BusinessID = busId;
                    emp.EmployeeID = EmployeeId;
                    emp.Forename = EmpFirstName;
                    emp.Surname = EmpLastName;
                    emp.DepartmentID = deptData;
                    emp.EmployeeClosed = isActive == false ? Convert.ToSByte(true) : Convert.ToSByte(false);
                    emp.StartDate = StartDate;
                    emp.EndDate = EndDate;
                    entity.Entry(emp).State = System.Data.Entity.EntityState.Added;
                    if (isMapped)
                    {
                        var onlineUser = new tblonline_userid_employee();
                        onlineUser.BusinessID = busId;
                        onlineUser.CompanyID = cmpId;
                        onlineUser.EmployeeID = EmployeeId;
                        onlineUser.OnlineUserID = Session["UserName"].ToString().Trim();
                        entity.Entry(onlineUser).State = System.Data.Entity.EntityState.Added;
                    }
                    entity.SaveChanges();
                    var busAddsId = entity.tblbus_address.Where(x => x.Description == Address).First().AddressID;
                    if (templates.Count == 0)
                    {
                        if (EmpUcodes.Contains(';'))
                        {
                            foreach (string ucode in EmpUcodes.Trim().Split(';'))
                            {
                                var tblEmpUcode = new tblaccemp_ucodesemployees();
                                tblEmpUcode.BusinessID = busId;
                                tblEmpUcode.CompanyID = cmpId;
                                tblEmpUcode.UCodeID = ucode;
                                tblEmpUcode.EmployeeID = EmployeeId;
                                entity.Entry(tblEmpUcode).State = System.Data.Entity.EntityState.Added;
                            }
                        }
                        else
                        {
                            var tblEmpUcode = new tblaccemp_ucodesemployees();
                            tblEmpUcode.BusinessID = busId;
                            tblEmpUcode.CompanyID = cmpId;
                            tblEmpUcode.UCodeID = EmpUcodes;
                            tblEmpUcode.EmployeeID = EmployeeId;
                            entity.Entry(tblEmpUcode).State = System.Data.Entity.EntityState.Added;
                        }
                    }
                    if (templates.Count == 0)
                    {
                        if (entity.SaveChanges() > 0)
                        {
                            int res = dp.UpdateEmployee(Convert.ToInt32(cmpId), Convert.ToInt32(busAddsId), EmployeeId, busId);
                            if (res > -1)
                            {
                                return "success";
                            }
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {


                        int res = dp.UpdateEmployee(Convert.ToInt32(cmpId), Convert.ToInt32(busAddsId), EmployeeId, busId);
                        if (res > -1)
                        {
                            return "success";
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                else
                {
                    return "Validation";
                }

            }
            catch (Exception e)
            {

            }
            return "";
        }

        #region EmployeeIdValidation
        public string EmployeeIdValidation(string empId)
        {
            string result = "";
            string busId = Session["BuisnessId"].ToString();
            if (empId != "")
            {
                if (empId.ToCharArray().Count() > 10)
                {
                    return "Employee Id length must be upto 10 characters";
                }
                else
                {
                    result = entity.tblaccemp_employee.Any(x => x.EmployeeID == empId && x.BusinessID == busId) ? "" : "Success";
                    return result;
                }
            }
            return result;
        }
        #endregion
        #endregion


        [ValidateInput(false)]
        public ActionResult CardViewPartialxccccc()
        {
            var model = new object[0];
            return PartialView("~/Views/Shared/_CardViewPartialxccccc.cshtml", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialxcccccAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.my_aspnet_users item)
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
            return PartialView("~/Views/Shared/_CardViewPartialxccccc.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialxcccccUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Maximus.Models.my_aspnet_users item)
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
            return PartialView("~/Views/Shared/_CardViewPartialxccccc.cshtml", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CardViewPartialxcccccDelete(System.Int32 applicationId)
        {
            var model = new object[0];
            if (applicationId >= 0)
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
            return PartialView("~/Views/Shared/_CardViewPartialxccccc.cshtml", model);
        }
    }
}
