using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using OperaWebSites.Data;//agregar
using System.Data.Entity;//agregar

namespace OperaWebSites
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Seed the database with sample data for development. This code should be removed for production.

            //--agregar linea!! cuando ya esta inizialisado hay q comentarla
            Database.SetInitializer<OperaDbContext>(new OperasInitializer());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
