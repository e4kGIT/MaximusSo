using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Maximus.Filter
{
    public class CustomFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                var data = HttpContext.Current.Session.Keys.Count > 0 ? 1 : 2;
            }
            catch
            {
                HttpContext.Current.Session["BuisnessId"] = null;
            }

            if (!filterContext.HttpContext.Request.Cookies.AllKeys.Contains("Username") | HttpContext.Current.Session["BuisnessId"] ==null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
            }
        }
    }
}