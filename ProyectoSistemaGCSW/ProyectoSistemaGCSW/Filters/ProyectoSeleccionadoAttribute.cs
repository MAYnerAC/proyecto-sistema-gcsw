using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaGCSW.Filters
{
    public class ProyectoSeleccionadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["ProyectoId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                    { "controller", "Proyecto" },
                    { "action", "MisProyectos" },
                    { "area", "Workspace" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}