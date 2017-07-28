using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Finanse_aspnet_mvc.Models;

namespace Finanse_aspnet_mvc {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            //WebSecurity.
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }
    }
}
