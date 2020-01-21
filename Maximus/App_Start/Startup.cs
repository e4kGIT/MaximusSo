using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Maximus 
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/User/Login"),
                ExpireTimeSpan = System.TimeSpan.FromMinutes(560),
                SlidingExpiration = true
            });
        }
    }
}