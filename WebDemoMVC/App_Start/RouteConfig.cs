﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDemoMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: Guid.NewGuid().ToString(),
                 url: "{controller}/{action}/{name}",
                 defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional }
             );

            routes.MapRoute(
              name: Guid.NewGuid().ToString(),
              url: "gio-hang",
              defaults: new { controller = "ShoppingCart", action = "Index" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
