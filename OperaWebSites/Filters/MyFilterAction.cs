using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;//agregar
using System.Diagnostics;//agregar - para imprimir en la consola y q se registren

namespace OperaWebSites.Filters
{
    public class MyFilterAction:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var operaController = filterContext.RouteData.Values["Controller"];
            var operaAction = filterContext.RouteData.Values["Values"];
            Debug.WriteLine("Controller" + operaController + "Action: " + operaAction + " Paso por OnActionExecuting");

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var operaController = filterContext.RouteData.Values["Controller"];
            var operaAction = filterContext.RouteData.Values["Values"];
            Debug.WriteLine("Controller" + operaController + "Action: " + operaAction + " Paso por OnActionExecuted");
        }
    }
}