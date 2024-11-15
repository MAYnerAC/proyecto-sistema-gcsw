using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaGCSW.Filters
{
    public class AutenticadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Verifica si el usuario está autenticado (tiene una sesión activa)
            if (filterContext.HttpContext.Session["id_usuario"] == null)
            {
                // Si no está autenticado, redirige a la página de login
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}