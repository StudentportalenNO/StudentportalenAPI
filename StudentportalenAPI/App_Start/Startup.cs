using Microsoft.Owin;
using Owin;
using StudentportalenAPI.App_Start;

[assembly: OwinStartup(typeof(Startup))]

namespace StudentportalenAPI.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}