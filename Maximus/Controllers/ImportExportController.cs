using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maximus.Controllers
{
    public class ImportExportController : Controller
    {
        // GET: ImportExport

        private readonly IUnitOfWork _unitOfWork;
        private readonly User _user;
        private readonly EmployeeRollout _empRollout;
        private readonly DataProcessing _dp;
        private readonly IImportExport _importExport; 
        public ImportExportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            User user = new User(_unitOfWork);
            ImportExportService importExport = new ImportExportService(_unitOfWork);
            DataProcessing dp = new DataProcessing(_unitOfWork);
            EmployeeRollout empRollout = new EmployeeRollout(_unitOfWork);
            _user = user;
            _dp = dp;
           
            _importExport = importExport;
            _empRollout = empRollout;
        }
        public ActionResult ImportExportIndex()
        {
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
            
            return PartialView("_UserGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UserGridViewPartialAddNew(Maximus.Data.models.ImpExpUsers item)
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
            return PartialView("_UserGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserGridViewPartialUpdate(Maximus.Data.models.ImpExpUsers item)
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
            return PartialView("_UserGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserGridViewPartialDelete(System.String UserName)
        {
            var model = new object[0];
            if (UserName != null)
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
            return PartialView("_UserGridViewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult EmployeeGrdiviewPartial()
        {
            var model = new object[0];
            return PartialView("_EmployeeGrdiviewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeeGrdiviewPartialAddNew(Maximus.Data.models.ImpExpEmployee item)
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
            return PartialView("_EmployeeGrdiviewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeeGrdiviewPartialUpdate(Maximus.Data.models.ImpExpEmployee item)
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
            return PartialView("_EmployeeGrdiviewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EmployeeGrdiviewPartialDelete(System.String EmployeeId)
        {
            var model = new object[0];
            if (EmployeeId != null)
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
            return PartialView("_EmployeeGrdiviewPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult AddressGridViewPartial()
        {
            var model = new object[0];
            return PartialView("_AddressGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddressGridViewPartialAddNew(Maximus.Data.models.ImpExpAddress item)
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
            return PartialView("_AddressGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddressGridViewPartialUpdate(Maximus.Data.models.ImpExpAddress item)
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
            return PartialView("_AddressGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddressGridViewPartialDelete(System.String Description)
        {
            var model = new object[0];
            if (Description != null)
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
            return PartialView("_AddressGridViewPartial", model);
        }
    }
}