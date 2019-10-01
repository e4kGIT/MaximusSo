using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maximus.Filter;
namespace Maximus.Controllers
{
    [Authorize]
     
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            //Session["ColorSizestyle"] = null;
            //Session["onDemand"] = null;
            return View();
        }
        public string SetValues(string rowVal, string columnVal,string flag = "",bool imgFilter=false,bool showDim=false,bool ondemand=false)
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
            catch(Exception e)
            {

            }
            return "";
        }
    }
}