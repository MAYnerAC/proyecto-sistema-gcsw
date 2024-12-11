using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaGCSW.Filters;
using ProyectoSistemaGCSW.Models;
using ProyectoSistemaGCSW.Models.ViewModels;

namespace ProyectoSistemaGCSW.Areas.Workspace.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(3)]
    [ProyectoSeleccionado]
    public class TareaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Workspace/Tarea
        public ActionResult Index()
        {
            int proyectoId = (int)Session["ProyectoId"];

            var tareas = db.Tarea
                .Include(m => m.Proyecto)
                .Include(m => m.Estado_Tarea)
                .Include(m => m.Prioridad)
                .Where(m => m.id_proyecto == proyectoId)
                .ToList();

            // Organizar las tareas por estado
            ViewBag.ToDo = tareas.Where(t => t.Estado_Tarea.id_estado_tarea == 1).ToList();
            ViewBag.InProgress = tareas.Where(t => t.Estado_Tarea.id_estado_tarea == 2).ToList();
            ViewBag.Done = tareas.Where(t => t.Estado_Tarea.id_estado_tarea == 3).ToList();

            return View(tareas);

        }

        // GET: Workspace/Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tarea tarea = db.Tarea
                .Include(t => t.Proyecto)
                .Include(t => t.Estado_Tarea)
                .Include(t => t.Prioridad)
                .FirstOrDefault(t => t.id_tarea == id);

            if (tarea == null)
            {
                return HttpNotFound();
            }


            // Miembros asignados a la tarea
            var miembrosTarea = db.Miembro_Tarea
                .Include(mt => mt.Miembro_Proyecto.Usuario)
                .Where(mt => mt.id_tarea == id)
                .Select(mt => new MiembroTareaViewModel
                {
                    IdMiembroTarea = mt.id_miembro_tarea,
                    Nombre = mt.Miembro_Proyecto.Usuario.nombre,
                    Apellido = mt.Miembro_Proyecto.Usuario.apellido,
                    EsPrincipal = mt.es_principal == "S"
                })
                .OrderByDescending(mt => mt.EsPrincipal)
                .ToList();

            // Elementos relacionados con la tarea
            var elementosTarea = db.Elemento_Tarea
                .Include(et => et.Elemento_Configuracion)
                .Where(et => et.id_tarea == id)
                .Select(et => new ElementoTareaViewModel
                {
                    IdElementoTarea = et.id_elemento_tarea,
                    NombreElemento = et.Elemento_Configuracion.nombre,
                    CodigoElemento = et.Elemento_Configuracion.codigo_elemento,
                    EsPrincipal = et.es_principal == "S"
                })
                .OrderByDescending(mt => mt.EsPrincipal)
                .ToList();

            // Pasar datos a la vista
            ViewBag.MiembrosTarea = miembrosTarea;
            ViewBag.ElementosTarea = elementosTarea;


            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre", tarea.id_estado_tarea);
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre", tarea.id_prioridad);

            return View(tarea);
        }





        // GET: Workspace/Tarea/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre");
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre");
            return View();
        }

        // POST: Workspace/Tarea/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.id_proyecto = (int)Session["ProyectoId"];
                tarea.fecha_creacion = DateTime.Now;
                tarea.estado = "A";

                db.Tarea.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre", tarea.id_estado_tarea);
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre", tarea.id_prioridad);
            return View(tarea);
        }




        // POST: Workspace/Tarea/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                var tareaExistente = db.Tarea.Find(tarea.id_tarea);
                if (tareaExistente == null)
                {
                    return HttpNotFound();
                }

                // Actualizar solo los campos editables
                tareaExistente.titulo = tarea.titulo;
                tareaExistente.descripcion = tarea.descripcion;
                tareaExistente.id_estado_tarea = tarea.id_estado_tarea;
                tareaExistente.id_prioridad = tarea.id_prioridad;
                tareaExistente.fecha_limite = tarea.fecha_limite;

                db.Entry(tareaExistente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Enviar nuevamente los datos necesarios en caso de error
            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre", tarea.id_estado_tarea);
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre", tarea.id_prioridad);

            return View(tarea);
        }



        // POST: Workspace/Tarea/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            // Eliminar las dependencias en Miembro_Tarea
            var miembrosT = db.Miembro_Tarea.Where(mt => mt.id_tarea == id).ToList();
            db.Miembro_Tarea.RemoveRange(miembrosT);

            // Eliminar las dependencias en Miembro_Tarea
            var elementosT = db.Elemento_Tarea.Where(mt => mt.id_tarea == id).ToList();
            db.Elemento_Tarea.RemoveRange(elementosT);

            db.Tarea.Remove(tarea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        /*--------------------------------------------------------------------------------------------*/


        // GET: Tarea/AddMember/5
        public ActionResult AddMember(int id)
        {
            int proyectoId = (int)Session["ProyectoId"]; // Obtener el proyecto actual de la sesión

            ViewBag.id_miembro_proyecto = new SelectList(
                db.Miembro_Proyecto
                  .Where(mp => mp.id_proyecto == proyectoId)
                  .Select(mp => new
                  {
                      mp.id_miembro_proyecto,
                      Nombre = mp.Usuario.nombre + " " + mp.Usuario.apellido
                  }),
                "id_miembro_proyecto",
                "Nombre"
            );

            return View(new Miembro_Tarea { id_tarea = id });
        }


        // POST: Tarea/AddMember
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMember(Miembro_Tarea miembroTarea)
        {
            if (ModelState.IsValid)
            {
                miembroTarea.fecha_asignacion = DateTime.Now;
                miembroTarea.es_principal = string.IsNullOrEmpty(miembroTarea.es_principal) ? "N" : miembroTarea.es_principal;

                db.Miembro_Tarea.Add(miembroTarea);
                db.SaveChanges();

                TempData["Mensaje"] = "Se asigno el miembro correctamente";

                return RedirectToAction("Details", new { id = miembroTarea.id_tarea });
            }

            TempData["Error"] = "Ocurrio un error, no se pudo asignar el miembro";

            return RedirectToAction("Details", new { id = miembroTarea.id_tarea });
        }



        // GET: Tarea/AddElement/5
        public ActionResult AddElement(int id)
        {
            int proyectoId = (int)Session["ProyectoId"]; // Obtener el proyecto actual de la sesión

            ViewBag.id_elemento_configuracion = new SelectList(
                db.Elemento_Configuracion
                  .Where(ec => ec.id_proyecto == proyectoId),
                "id_elemento_configuracion",
                "nombre"
            );

            return View(new Elemento_Tarea { id_tarea = id });
        }


        // POST: Tarea/AddElement
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddElement(Elemento_Tarea elementoTarea)
        {
            if (ModelState.IsValid)
            {
                elementoTarea.fecha_asignacion = DateTime.Now;
                elementoTarea.es_principal = string.IsNullOrEmpty(elementoTarea.es_principal) ? "N" : elementoTarea.es_principal;

                db.Elemento_Tarea.Add(elementoTarea);
                db.SaveChanges();

                TempData["Mensaje"] = "Se asigno el elemento correctamente.";

                return RedirectToAction("Details", new { id = elementoTarea.id_tarea });
            }

            TempData["Error"] = "Ocurrio un error, no se pudo asignar el elemento.";

            return RedirectToAction("Details", new { id = elementoTarea.id_tarea });

        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveMember(int idMiembroTarea)
        {
            var miembroTarea = db.Miembro_Tarea.Find(idMiembroTarea);
            if (miembroTarea == null)
            {
                return HttpNotFound();
            }

            db.Miembro_Tarea.Remove(miembroTarea);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = miembroTarea.id_tarea });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveElement(int idElementoTarea)
        {
            var elementoTarea = db.Elemento_Tarea.Find(idElementoTarea);
            if (elementoTarea == null)
            {
                return HttpNotFound();
            }

            db.Elemento_Tarea.Remove(elementoTarea);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = elementoTarea.id_tarea });
        }











        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //
    }
}
