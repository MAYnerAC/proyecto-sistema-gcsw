using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSistemaGCSW.Filters
{
    public class TipoUsuarioAutorizadoAttribute : ActionFilterAttribute
    {
        private readonly int _requiredTipoUsuario;

        public TipoUsuarioAutorizadoAttribute(int requiredTipoUsuario)
        {
            _requiredTipoUsuario = requiredTipoUsuario;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionTipoUsuario = filterContext.HttpContext.Session["id_tipo_usuario"];
            if (sessionTipoUsuario == null || (int)sessionTipoUsuario != _requiredTipoUsuario)
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}