﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Finanse_aspnet_mvc {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Categories",
            //    url: "categories/{type}",
            //    defaults: new { controller = "Categories", action = "Index", type = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
