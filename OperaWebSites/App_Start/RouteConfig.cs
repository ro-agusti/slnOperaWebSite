using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OperaWebSites
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //RUTA PERSONALIZADA - LOGIN
            routes.MapRoute(
                name:"Login",
                //test/login/nombre/role
                url: "{controller}/{action}/{name}/{role}",
                defaults: new
                {
                    controller = "Test",
                    Action = "Login"
                }
                );

            //RUTA PERSONALIZADA - SearchByTitle
            routes.MapRoute(
                name: "SearchByTitle",

                //test/SearchByTitle/nombre
                //url: "{controller}/{action}/{title}",

                //search/SearchByTitle/nombre
                url: "search/{title}",
                defaults: new
                {
                    controller = "Test",
                    Action = "SearchByTitle"
                }
                );

            //ruta default 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
