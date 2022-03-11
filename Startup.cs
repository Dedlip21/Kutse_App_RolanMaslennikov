using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kutse_App_RolanMaslennikov.Startup))]
namespace Kutse_App_RolanMaslennikov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
