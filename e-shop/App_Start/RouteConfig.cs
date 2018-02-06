﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace e_shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "Product",
                url: "Product",
                defaults: new { controller = "Product", action = "Index" }
            );

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "About", action = "About" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Contact", action = "Contact" }
            );

            routes.MapRoute(
                name: "Delivery",
                url: "Delivery",
                defaults: new { controller = "Delivery", action = "Delivery" }
);

            routes.MapRoute(null, "{controller}/{action}/Page{page}", new
            {
                controller = "Product",
                action = "Index",
                category = (string)null
            },
              new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}/{category}", new
            {
                controller = "Product",
                action = "Index",
                page = 1
            });

            routes.MapRoute(null, "{controller}/{action}/{category}/Page{page}", new
            {
                controller = "Product",
                action = "Index",
            },
                new { page = @"\d+" }
            );

            //        routes.MapRoute(
            //name: "",
            //url: "Admin/{action}"
            //);

            //        routes.MapRoute(
            //            name: "AdminOrders",
            //            url: "Admin/{category}",
            //            defaults: new { controller = "Admin", action = "Index", category = UrlParameter.Optional }
            //        );

            //routes.MapRoute(null, "{controller}/{action}");

            //routes.MapRoute(null, "{controller}/{action}/{category}", new
            //{
            //    controller = "Product",
            //    action = "List",
            //    category = (string)null,
            //    page = 1
            //});

            //routes.MapRoute(
            //    name: null,
            //    url: "{controller}/Page{page}",
            //    defaults: new { controller = "Product", action = "List" }
            //);

            //            routes.MapRoute(
            //name: "About",
            //url: "About",
            //defaults: new { controller = "About", action = "About" }
            //);
            routes.MapRoute(
                name: "order",
                url: "{controller}/{action}/Order/{orderId}"
            );

            routes.MapRoute(
                name: "edit",
                url: "{controller}/{action}/Product/{productId}"
                );

            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
