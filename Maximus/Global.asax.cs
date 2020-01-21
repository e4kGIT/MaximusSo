using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

namespace Maximus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();
            UnityConfig.RegisterComponents();
            //var applicationPath= System.Web.HttpContext.Current.Request.MapPath(@"~\");
            log4net.GlobalContext.Properties["LogFileName"] = @"Application log\\LogFile"; //log file path
            log4net.Config.XmlConfigurator.Configure();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            string filePath = System.Web.HttpContext.Current.Request.MapPath(@"~\") + "exception.txt";
            
            if (System.IO.File.Exists(System.Web.HttpContext.Current.Request.MapPath(@"~\") + "exception.txt"))
            {
            
               using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                }
            else
            {
                System.IO.File.Create(filePath);
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
            }
        }
    }
}
