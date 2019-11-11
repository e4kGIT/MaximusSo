using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Maximus
{
    public partial class Startup
    {
        //This class will be automatically located and initialized by the OWIN host
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}