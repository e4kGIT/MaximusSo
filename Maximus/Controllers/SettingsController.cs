using DevExpress.Web.Mvc;
using Maximus.Data.Interface.Concrete;
using Maximus.Services;
using Maximus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Maximus.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
       
        private readonly IUser _user;
        private readonly IUnitOfWork _unitOfWork;
        public SettingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UserService user = new UserService(_unitOfWork);
            _user = user;
        }
        // GET: Settings
        public ActionResult Index()
        {
            //Session["ColorSizestyle"] = null;
            //Session["onDemand"] = null;
            Session["welcomeContent"] = _user.GetWelcome(Session["BuisnessId"].ToString());
            return View("Settings");
        }
        public void SetOrderType(string setOrderType)
        {
            if (setOrderType == "IsManPack")
            {
                Session["IsManPack"] = true;
                Session["IsBulkOrder"] = false;
                Session["IsBulkOrder1"] = false;
            }
            else if (setOrderType == "IsBulkOrder")
            {
                Session["IsManPack"] = false;
                Session["IsBulkOrder"] = true;
                Session["IsBulkOrder1"] = false;
            }
            else
            {
                Session["IsManPack"] = false;
                Session["IsBulkOrder"] = false;
                Session["IsBulkOrder1"] = true;
            }
        }
        public string SetValues(string rowVal, string columnVal, string flag = "", bool imgFilter = false, bool showDim = false, bool ondemand = false)
        {
            try
            {
                if (rowVal != "" || columnVal != "")
                {
                    Session["cardColumns"] = Convert.ToInt16(columnVal);
                    Session["cardRows"] = Convert.ToInt16(rowVal);
                }
                if (flag != "" & flag != null)
                {
                    Session["ColorSizestyle"] = flag;
                }
                Session["ImageFilter"] = imgFilter == true ? imgFilter : false;
                Session["onDemand"] = ondemand == true ? ondemand : false;
                Session["GroupdeFilter"] = showDim == true ? showDim : false;
                return "Success";
            }
            catch (Exception e)
            {

            }
            return "";
        }
        [ValidateInput(false)]
        public string SaveWelcomeText(string htmlText)
        {
            if(htmlText!="")
            {
                var result = _user.SetWelcomeText(htmlText,Session["BuisnessId"].ToString());
                return result ? "Save" : "";
            }
            return "";
        }

        public ActionResult HtmlEditorPartial()
        {
            return PartialView("_HtmlEditorPartial");
        }
        public ActionResult HtmlEditorPartialImageSelectorUpload()
        {
            HtmlEditorExtension.SaveUploadedImage("HtmlEditor", SettingsControllerHtmlEditorSettings.ImageSelectorSettings);
            return null;
        }
        public ActionResult HtmlEditorPartialImageUpload()
        {
            HtmlEditorExtension.SaveUploadedFile("HtmlEditor", SettingsControllerHtmlEditorSettings.ImageUploadValidationSettings, SettingsControllerHtmlEditorSettings.ImageUploadDirectory);
            return null;
        }
    }
    public class SettingsControllerHtmlEditorSettings
    {
        public const string ImageUploadDirectory = "~/Content/UploadImages/";
        public const string ImageSelectorThumbnailDirectory = "~/Content/Thumb/";

        public static DevExpress.Web.UploadControlValidationSettings ImageUploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings ImageSelectorSettings
        {
            get
            {
                if (imageSelectorSettings == null)
                {
                    imageSelectorSettings = new DevExpress.Web.Mvc.MVCxHtmlEditorImageSelectorSettings(null);
                    imageSelectorSettings.Enabled = true;
                    imageSelectorSettings.UploadCallbackRouteValues = new { Controller = "Settings", Action = "HtmlEditorPartialImageSelectorUpload" };
                    imageSelectorSettings.CommonSettings.RootFolder = ImageUploadDirectory;
                    imageSelectorSettings.CommonSettings.ThumbnailFolder = ImageSelectorThumbnailDirectory;
                    imageSelectorSettings.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif" };
                    imageSelectorSettings.UploadSettings.Enabled = true;
                }
                return imageSelectorSettings;
            }
        }
    }

}