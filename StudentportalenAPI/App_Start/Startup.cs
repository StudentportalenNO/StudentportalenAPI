using Microsoft.Owin;
using Owin;
using StudentportalenAPI.Web.App_Start;

[assembly: OwinStartup(typeof(Startup))]

namespace StudentportalenAPI.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}