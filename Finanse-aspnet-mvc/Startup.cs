using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Finanse_aspnet_mvc.Startup))]
namespace Finanse_aspnet_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
