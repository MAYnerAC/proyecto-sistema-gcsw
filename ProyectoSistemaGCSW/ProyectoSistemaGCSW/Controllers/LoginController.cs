using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//
using ProyectoSistemaGCSW.Models;

namespace ProyectoSistemaGCSW.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuarios)
        {
            if (IsValid(usuarios))
            {
                // Obtener datos completos del usuario autenticado
                Usuario usuarioAutenticado = usuarios.ObtenerDatos(usuarios.correo);

                // Verifica si el usuario autenticado es válido
                if (usuarioAutenticado != null)
                {
                    // Almacenar información en la sesión
                    Session["id_usuario"] = usuarioAutenticado.id_usuario;
                    Session["nombre_usuario"] = usuarioAutenticado.nombre;
                    Session["correo_usuario"] = usuarioAutenticado.correo;
                    Session["tipo_usuario"] = usuarioAutenticado.Tipo_Usuario.nombre;
                    Session["id_tipo_usuario"] = usuarioAutenticado.id_tipo_usuario; // 1 = Admin, 2 = Supervisor, 3 = Usuario

                    // Redirige según el tipo de usuario
                    int tipoUsuario = usuarioAutenticado.id_tipo_usuario;
                    if (tipoUsuario == 1) // Admin
                    {
                        TempData["Mensaje"] = "Bienvenido " + usuarioAutenticado.nombre + " " + usuarioAutenticado.apellido;
                        return RedirectToAction("Index", "Panel", new { area = "Admin" });
                    }
                    else if (tipoUsuario == 2) // Supervisor
                    {
                        TempData["Mensaje"] = "Bienvenido " + usuarioAutenticado.nombre + " " + usuarioAutenticado.apellido;
                        return RedirectToAction("Index", "Panel", new { area = "Admin" });
                    }
                    else // Usuario
                    {
                        TempData["Mensaje"] = "Bienvenido " + usuarioAutenticado.nombre + " " + usuarioAutenticado.apellido;
                        return RedirectToAction("Index", "Panel", new { area = "Workspace" });
                    }
                }
                else
                {
                    TempData["mensaje"] = "Error al obtener los datos del usuario autenticado.";
                    return View(usuarios);
                }
            }

            TempData["mensaje"] = "Correo o contraseña incorrectos";
            return View(usuarios);
        }








        // Método para validar el usuario
        private bool IsValid(Usuario usuarios)
        {
            return usuarios.Autenticar();
        }




        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Registro()
        {
            return View();
        }



        // Registro de Usuario
        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                bool usuarioRegistrado = usuario.RegistrarUsuario();

                if (usuarioRegistrado)
                {
                    TempData["mensaje"] = "Usuario registrado exitosamente.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["mensaje"] = "Hubo un problema al registrar el usuario.";
                }
            }

            return RedirectToAction("Index", "Login");
        }









        //Version 3
        /*
        [HttpPost]
        public ActionResult Index(Usuario usuarios)
        {
            if (IsValid(usuarios))
            {
                // Obtener datos completos del usuario autenticado
                Usuario usuarioAutenticado = usuarios.ObtenerDatos(usuarios.correo);

                // Almacenar información en la sesión
                Session["id_usuario"] = usuarioAutenticado.id_usuario;
                Session["nombre_usuario"] = usuarioAutenticado.nombre;
                Session["correo_usuario"] = usuarioAutenticado.correo;
                Session["tipo_usuario"] = usuarioAutenticado.Tipo_Usuario.nombre;
                Session["id_tipo_usuario"] = usuarioAutenticado.id_tipo_usuario; // Ejemplo: 1 = Admin, 2 = Usuario

                // Redirige según el tipo de usuario
                if ((int)Session["id_tipo_usuario"] == 1) // Admin
                {
                    return RedirectToAction("Index", "Panel", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Workspace" });
                }
            }

            TempData["mensaje"] = "El correo o contraseña incorrecto";
            return View(usuarios);
        }
        */



        //Version 2
        /*
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuarios, string ReturnUrl)
        {
            if (IsValid(usuarios))
            {
                Session["Usuarios"] = usuarios.id_usuario;

                FormsAuthentication.SetAuthCookie(usuarios.correo, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Panel", new { area = "Admin" });
            }
            TempData["mensaje"] = "El correo o contraseña incorrecto";

            return View(usuarios);
        }
        private bool IsValid(Usuario usuarios)
        {

            return usuarios.Autenticar();
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        */



        //Version 1
        //[HttpPost]
        //public ActionResult Index(Usuario usuarios)
        //{
        //    // Instancia del modelo Usuario para autenticación
        //    if (IsValid(usuarios))
        //    {
        //        // Redirige al área "Admin" del controlador "Panel" si la autenticación es exitosa
        //        return RedirectToAction("Index", "Panel", new { area = "Admin" });
        //    }
        //    // Mensaje de error si la autenticación falla
        //    TempData["mensaje"] = "El correo o contraseña incorrecto";
        //    return View(usuarios);
        //}


        //
    }
}