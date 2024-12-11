using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//
using ProyectoSistemaGCSW.Filters;
using ProyectoSistemaGCSW.Models;
using ProyectoSistemaGCSW.Service;

namespace ProyectoSistemaGCSW.Areas.Workspace.Controllers
{
    [Autenticado]
    //[TipoUsuarioAutorizado(3)]
    //No Aplicar el Filtro "ProyectoSeleccionadoAttribute" para evitar generar un bucle de redireccion
    public class ProyectoController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        public ActionResult MisProyectos()
        {
            int idUsuario = (int)Session["id_usuario"];

            var proyectos = db.Proyecto
                              .Where(p => p.id_usuario_creador == idUsuario ||
                                          db.Miembro_Proyecto.Any(m => m.id_usuario == idUsuario && m.id_proyecto == p.id_proyecto))
                              .ToList();
            return View(proyectos);
        }




        public ActionResult Seleccionar(int idProyecto)
        {
            var proyectoSeleccionado = db.Proyecto
                                         .FirstOrDefault(p => p.id_proyecto == idProyecto);

            if (proyectoSeleccionado != null)
            {
                Session["ProyectoId"] = proyectoSeleccionado.id_proyecto;
                Session["ProyectoNombre"] = proyectoSeleccionado.nombre;
                Session["CodigoProyecto"] = proyectoSeleccionado.codigo_proyecto;
                Session["EstadoProyecto"] = proyectoSeleccionado.Estado_Proyecto.nombre;
                Session["UrlRepositorio"] = proyectoSeleccionado.url_repositorio;
                Session["MetodologiaProyecto"] = proyectoSeleccionado.Metodologia.nombre;

                Session["IdUsuarioCreador"] = proyectoSeleccionado.id_usuario_creador;


                int usuarioId = (int)Session["id_usuario"];


                // Buscar el miembro del proyecto correspondiente
                var miembroProyecto = db.Miembro_Proyecto
                                        .Include(mp => mp.Rol)
                                        .FirstOrDefault(mp => mp.id_proyecto == idProyecto && mp.id_usuario == usuarioId);

                if (miembroProyecto != null)
                {
                    // Guardar detalles del miembro en sesión
                    Session["IdMiembroProyecto"] = miembroProyecto.id_miembro_proyecto;
                    Session["RolUsuarioProyecto"] = miembroProyecto.Rol.nombre;
                    Session["NivelAccesoProyecto"] = miembroProyecto.nivel;
                }
                else
                {
                    // Si no es miembro del proyecto, limpiar detalles de miembro
                    Session["IdMiembroProyecto"] = null;
                    Session["RolUsuarioProyecto"] = null;
                    Session["NivelAccesoProyecto"] = null;
                }




                if (Request.UrlReferrer != null)//URL de Referencia
                {
                    return Redirect(Request.UrlReferrer.ToString());
                }

                return RedirectToAction("Index", "Panel", new { area = "Workspace" });

            }
            else
            {
                TempData["mensaje"] = "No se encontró el proyecto seleccionado.";
                return RedirectToAction("MisProyectos");//Redirigir a Advertencia mejor?
            }
        }



        public PartialViewResult ListaProyectosUsuario()
        {
            int idUsuario = (int)Session["id_usuario"];

            var proyectos = db.Proyecto
                              .Where(p => p.id_usuario_creador == idUsuario ||
                                          db.Miembro_Proyecto.Any(m => m.id_usuario == idUsuario && m.id_proyecto == p.id_proyecto))
                              .ToList();

            return PartialView(proyectos); // Retorna una vista parcial con los proyectos
        }







        //Liberar DBContext
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        // GET: Workspace/Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Workspace/Proyecto/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre");
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre");
            return View();
        }

        // POST: Workspace/Proyecto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto proyecto, bool usarPlantilla = false)
        {
            if (ModelState.IsValid)
            {
                // Asignar id_usuario_creador automáticamente desde la sesión
                proyecto.id_usuario_creador = (int)Session["id_usuario"];
                // Asignar la fecha de inicio automáticamente
                proyecto.fecha_inicio = DateTime.Now;
                // Asignar el valor predeterminado para el estado
                proyecto.estado = "A";

                db.Proyecto.Add(proyecto);
                db.SaveChanges();


                // Si el usuario selecciona "usarPlantilla", insertar la plantilla
                if (usarPlantilla)
                {
                    InsertarECS(proyecto.id_proyecto, proyecto.id_metodologia);
                }

                return RedirectToAction("MisProyectos");
            }

            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre", proyecto.id_estado_proyecto);
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", proyecto.id_metodologia);
            return View(proyecto);
        }



        private void InsertarECS(int idProyecto, int idMetodologia)
        {
            using (var context = new ModeloSistema())
            {
                // Validar si existen fases para la metodología seleccionada
                var fases = context.Fase
                    .Where(f => f.id_metodologia == idMetodologia && f.estado == "A")
                    .ToList();

                if (fases == null)
                {
                    throw new Exception("No se encontraron fases para la metodología seleccionada.");
                }

                // Crear lista de elementos de configuración
                var elementosConfiguracion = new List<Elemento_Configuracion>();

                // Obtener ECS segun la metodologia
                switch (idMetodologia)
                {
                    case 1: // RUP
                        elementosConfiguracion.AddRange(PlantillasService.ObtenerECSRUP(idProyecto));
                        break;

                    case 2: // Scrum
                        elementosConfiguracion.AddRange(PlantillasService.ObtenerECSScrum(idProyecto));
                        break;

                    case 3: // Kanban
                        elementosConfiguracion.AddRange(PlantillasService.ObtenerECSKanban(idProyecto));
                        break;

                    case 4: // Waterfall
                        elementosConfiguracion.AddRange(PlantillasService.ObtenerECSWaterfall(idProyecto));
                        break;

                    default:
                        throw new Exception("Metodología no soportada.");
                }

                // Guardar los elementos de configuración en la base de datos
                context.Elemento_Configuracion.AddRange(elementosConfiguracion);
                context.SaveChanges();
            }
        }





        // GET: Workspace/Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }

            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre", proyecto.id_estado_proyecto);
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", proyecto.id_metodologia);
            return View(proyecto);
        }

        // POST: Workspace/Proyecto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                var proyectoExistente = db.Proyecto.Find(id);
                if (proyectoExistente == null)
                {
                    return HttpNotFound();
                }

                // Solo actualizar campos permitidos
                proyectoExistente.nombre = proyecto.nombre;
                proyectoExistente.codigo_proyecto = proyecto.codigo_proyecto;
                proyectoExistente.descripcion = proyecto.descripcion;
                proyectoExistente.fecha_fin = proyecto.fecha_fin;
                proyectoExistente.id_estado_proyecto = proyecto.id_estado_proyecto;
                proyectoExistente.url_repositorio = proyecto.url_repositorio;

                db.Entry(proyectoExistente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MisProyectos");
            }

            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre", proyecto.id_estado_proyecto);
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", proyecto.id_metodologia);
            return View(proyecto);
        }

        // GET: Workspace/Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Workspace/Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
            db.SaveChanges();
            return RedirectToAction("MisProyectos");
        }

        //
    }
}
