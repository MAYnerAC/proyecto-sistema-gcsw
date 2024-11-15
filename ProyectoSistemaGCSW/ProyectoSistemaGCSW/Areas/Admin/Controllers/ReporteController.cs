using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using ProyectoSistemaGCSW.Models;
using ProyectoSistemaGCSW.Models.ReportModels;

namespace ProyectoSistemaGCSW.Areas.Admin.Controllers
{
    public class ReporteController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        public ActionResult GraficaEstadoProyectos(int? idUsuario)
        {
            var query = db.Proyecto.AsQueryable();

            if (idUsuario.HasValue)
            {
                query = query.Where(p => p.id_usuario_creador == idUsuario.Value);
            }

            var reporte = query
                .GroupBy(p => p.Estado_Proyecto.nombre)
                .Select(g => new ReporteEstadoProyecto
                {
                    Estado = g.Key,
                    TotalProyectos = g.Count()
                })
                .ToList();

            ViewBag.Usuarios = new SelectList(db.Usuario.Select(u => new { u.id_usuario, u.nombre }).ToList(), "id_usuario", "nombre");

            return View(reporte);
        }






        public ActionResult GraficaSolicitudesCambio(int? idProyecto)
        {
            var reporte = db.Solicitud_Cambio
                .Where(s => !idProyecto.HasValue || s.id_proyecto == idProyecto)
                .GroupBy(s => s.Estado_Solicitud.nombre)
                .Select(g => new ReporteSolicitudesCambioEstado
                {
                    Estado = g.Key,
                    TotalSolicitudes = g.Count()
                })
                .ToList();

            if (!reporte.Any())
            {
                ViewBag.Message = "No hay solicitudes de cambio registradas actualmente para el proyecto seleccionado.";
            }

            ViewBag.Proyectos = new SelectList(db.Proyecto.ToList(), "id_proyecto", "nombre");
            return View(reporte);
        }




        public ActionResult TableroProgresoTareas(int? idProyecto)
        {
            ViewBag.Proyectos = new SelectList(db.Proyecto, "id_proyecto", "nombre");

            var tareasConDatos = db.Tarea
                .Include("Estado_Tarea")
                .Include("Prioridad")
                .Where(t => !idProyecto.HasValue || t.id_proyecto == idProyecto.Value)
                .ToList();

            var reporte = tareasConDatos
                .GroupBy(t => t.Estado_Tarea.nombre)
                .Select(g => new ReporteProgresoTareas
                {
                    Estado = g.Key,
                    Tareas = g.Select(t => new TareaInfo
                    {
                        NombreTarea = t.titulo,
                        IdTarea = t.id_tarea,
                        Prioridad = t.Prioridad.nombre
                    }).ToList()
                })
                .ToList();

            if (!reporte.Any())
            {
                ViewBag.Message = "No hay tareas registradas actualmente para el proyecto seleccionado.";
            }

            return View(reporte);
        }



        public ActionResult InformeAvanceUsuario(int? idProyecto)
        {
            var estadoToDo = db.Estado_Tarea.FirstOrDefault(e => e.nombre == "To Do")?.id_estado_tarea;
            var estadoInProgress = db.Estado_Tarea.FirstOrDefault(e => e.nombre == "In Progress")?.id_estado_tarea;
            var estadoDone = db.Estado_Tarea.FirstOrDefault(e => e.nombre == "Done")?.id_estado_tarea;

            if (estadoToDo == null || estadoInProgress == null || estadoDone == null)
            {
                ViewBag.Message = "Uno o más estados de tarea no existen en la base de datos.";
                return View(new List<ReporteAvanceUsuario>());
            }

            var proyectos = db.Proyecto.Select(p => new { p.id_proyecto, p.nombre }).ToList();
            ViewBag.Proyectos = new SelectList(proyectos, "id_proyecto", "nombre");

            var query = db.Miembro_Proyecto.AsQueryable();
            if (idProyecto.HasValue)
            {
                query = query.Where(mp => mp.id_proyecto == idProyecto.Value);
            }

            var reporte = query
                .GroupBy(mp => new
                {
                    NombreUsuario = mp.Usuario.nombre,
                    ApellidoUsuario = mp.Usuario.apellido,
                    NombreProyecto = mp.Proyecto.nombre
                })
                .Select(g => new ReporteAvanceUsuario
                {
                    Proyecto = g.Key.NombreProyecto,
                    Usuario = g.Key.NombreUsuario + " " + g.Key.ApellidoUsuario,
                    TotalTareasToDo = g.Sum(mp => mp.Miembro_Tarea.Count(mt => mt.Tarea.id_estado_tarea == estadoToDo)),
                    TotalTareasInProgress = g.Sum(mp => mp.Miembro_Tarea.Count(mt => mt.Tarea.id_estado_tarea == estadoInProgress)),
                    TotalTareasDone = g.Sum(mp => mp.Miembro_Tarea.Count(mt => mt.Tarea.id_estado_tarea == estadoDone))
                })
                .ToList();


            if (!reporte.Any())
            {
                ViewBag.Message = "No hay usuarios con tareas registradas actualmente para el proyecto seleccionado.";
            }

            return View(reporte);
        }


        /*
        public ActionResult AnalisisPrioridadesTareas()
        {
            var reporte = db.Tarea
                .GroupBy(t => new { NombreProyecto = t.Proyecto.nombre, NombrePrioridad = t.Prioridad.nombre })
                .Select(g => new ReportePrioridadesTareas
                {
                    Proyecto = g.Key.NombreProyecto,
                    Prioridad = g.Key.NombrePrioridad,
                    TotalTareas = g.Count()
                })
                .OrderBy(r => r.Proyecto)
                .ThenBy(r => r.Prioridad)
                .ToList();

            if (!reporte.Any())
            {
                ViewBag.Message = "No hay tareas registradas en el sistema para el análisis de prioridades.";
            }

            return View(reporte);

        }
        */
        public ActionResult AnalisisPrioridadesTareas(int? idProyecto)
        {
            var tareas = db.Tarea.AsQueryable();

            if (idProyecto.HasValue)
            {
                tareas = tareas.Where(t => t.id_proyecto == idProyecto.Value);
            }

            var reporte = tareas
                .GroupBy(t => new { NombreProyecto = t.Proyecto.nombre, NombrePrioridad = t.Prioridad.nombre })
                .Select(g => new ReportePrioridadesTareas
                {
                    Proyecto = g.Key.NombreProyecto,
                    Prioridad = g.Key.NombrePrioridad,
                    TotalTareas = g.Count()
                })
                .OrderBy(r => r.Proyecto)
                .ThenBy(r => r.Prioridad)
                .ToList();

            if (!reporte.Any())
            {
                ViewBag.Message = "No hay tareas registradas para el análisis de prioridades.";
            }

            ViewBag.Proyectos = new SelectList(db.Proyecto, "id_proyecto", "nombre");

            return View(reporte);
        }


        public ActionResult InformeVersionesElementos(int? idProyecto)
        {
            ViewBag.Proyectos = new SelectList(db.Proyecto.ToList(), "id_proyecto", "nombre");

            var reporte = db.Version_Elemento
                .Where(ve => !idProyecto.HasValue || ve.Elemento_Configuracion.id_proyecto == idProyecto)
                .GroupBy(ve => ve.fecha_creacion)
                .Select(g => new ReporteVersionesElementos
                {
                    FechaCreacion = g.Key,
                    TotalVersiones = g.Count()
                })
                .OrderBy(r => r.FechaCreacion)
                .ToList();

            ViewBag.Fechas = reporte.Select(r => r.FechaCreacion?.ToString("dd/MM/yyyy")).ToList();
            ViewBag.TotalVersiones = reporte.Select(r => r.TotalVersiones).ToList();

            return View(reporte);
        }




        public ActionResult SeguimientoActividades(int? idProyecto)
        {
            ViewBag.Proyectos = new SelectList(db.Proyecto, "id_proyecto", "nombre");

            var reporte = db.Actividad
                .Where(a => !idProyecto.HasValue || a.id_proyecto == idProyecto)
                .Select(a => new ReporteSeguimientoActividades
                {
                    Proyecto = a.Proyecto.nombre,
                    Actividad = a.nombre_actividad,
                    Descripcion = a.descripcion,
                    FechaInicio = a.fecha_inicio,
                    FechaFin = a.fecha_fin,
                    Estado = a.estado,
                    Miembro = a.Miembro_Proyecto.Usuario.nombre + " " + a.Miembro_Proyecto.Usuario.apellido
                })
                .ToList();

            if (!reporte.Any())
            {
                ViewBag.Message = "No hay actividades registradas para el seguimiento.";
            }

            return View(reporte);
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
        //
    }
}