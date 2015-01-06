using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace aspnet_mvc4_angular_boilerplate
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "root",
                url: "",
                defaults: new { controller = "StaticPages", action = "Index" }
            );

            routes.MapRoute(
                name: "root_wildcard",
                url: "{anything}",
                defaults: new { controller = "StaticPages", action = "Index" }
            );

        }
    }
}