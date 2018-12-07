﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductsByCategory",
                url: "{controller}/Categories/{id}/Products",
                defaults: new { controller = "Product", action = "Products" }
            );

            routes.MapRoute(
                name: "FreeBird",
                url: "Free/Bird/{name}/{age}/{color}",
                defaults: new { controller = "Free", action = "Bird", name = "Unknown", age = 1, color = "N/A" }
            );

            routes.MapRoute(
                name: "SpecificProduct",
                url: "products/{id}",
                defaults: new { controller = "Product", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
