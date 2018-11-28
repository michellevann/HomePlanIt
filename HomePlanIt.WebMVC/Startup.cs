using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomePlanIt.WebMVC.Startup))]
namespace HomePlanIt.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
