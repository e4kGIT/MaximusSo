using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Data.models.RepositoryModels;
using Maximus.Data.Models;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
        public string FileName;
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

        public string StartImport()
        {
            string file = Session["importfilename"] != null ? Session["importfilename"].ToString() : "";
            if (file != "")
            {
                InMemoryModel inModel = new InMemoryModel();
                //string path = System.Web.HttpContext.Current.Request.MapPath(@"~\uploadfiles");
                //string foldername = "";
                //string orgfileName = "";
                //string filename = "";
                //foldername = string.Format(@"{0}\{1}", path, "Import");
                //orgfileName = string.Format(@"{0}_{1}", DateTime.Now.ToString("dd-MM-yyyy"), file);
                //filename = string.Format(@"{0}\{1}", foldername, orgfileName);
                var ssss = inModel.OpenExcelFile(file);
            }
            return "";
        }
        public ActionResult UploadControlUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControl", ImportExportControllerUploadControlSettings.UploadValidationSettings, ImportExportControllerUploadControlSettings.FileUploadComplete);
            return null;
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
                orgfileName = string.Format(@"{0}_{1}", DateTime.Now.ToString("dd-MM-yyyy"), e.UploadedFile.FileName);
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
            try
            {
                string connectionString = fileName.ToLower().Contains(".xlsx")==false? string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName) : string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", fileName);
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                adapter.Fill(dataTable);
            }
            catch (Exception e)
            {

            }
            return dataTable;
        }
    }

}