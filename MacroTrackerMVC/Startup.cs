using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MacroTrackerMVC.Startup))]
namespace MacroTrackerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
