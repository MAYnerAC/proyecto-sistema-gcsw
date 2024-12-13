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

namespace ProyectoSistemaGCSW.Areas.Workspace.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(3)]
    [ProyectoSeleccionado]
    public class Elemento_ConfiguracionController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Workspace/Elemento_Configuracion
        public ActionResult Index()
        {
            int proyectoId = (int)Session["ProyectoId"];

            var elemento_Configuracion = db.Elemento_Configuracion
                .Include(e => e.Fase)
                .Include(e => e.Proyecto)
                .Where(e => e.id_proyecto == proyectoId);

            return View(elemento_Configuracion.ToList());
        }

        // GET: Workspace/Elemento_Configuracion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Configuracion elemento_Configuracion = db.Elemento_Configuracion.Find(id);
            if (elemento_Configuracion == null)
            {
                return HttpNotFound();
            }
            return View(elemento_Configuracion);
        }

        // GET: Workspace/Elemento_Configuracion/Create
        public ActionResult Create()
        {
            ViewBag.id_fase = new SelectList(db.Fase, "id_fase", "nombre");
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            return View();
        }

        // POST: Workspace/Elemento_Configuracion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_elemento_configuracion,nombre,codigo_elemento,nomenclatura,id_proyecto,id_fase,estado,url_recurso_asociado")] Elemento_Configuracion elemento_Configuracion)
        {
            if (ModelState.IsValid)
            {
                db.Elemento_Configuracion.Add(elemento_Configuracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_fase = new SelectList(db.Fase, "id_fase", "nombre", elemento_Configuracion.id_fase);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", elemento_Configuracion.id_proyecto);
            return View(elemento_Configuracion);
        }

        // GET: Workspace/Elemento_Configuracion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Configuracion elemento_Configuracion = db.Elemento_Configuracion.Find(id);
            if (elemento_Configuracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_fase = new SelectList(db.Fase, "id_fase", "nombre", elemento_Configuracion.id_fase);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", elemento_Configuracion.id_proyecto);
            return View(elemento_Configuracion);
        }

        // POST: Workspace/Elemento_Configuracion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_elemento_configuracion,nombre,codigo_elemento,nomenclatura,id_proyecto,id_fase,estado,url_recurso_asociado")] Elemento_Configuracion elemento_Configuracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elemento_Configuracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_fase = new SelectList(db.Fase, "id_fase", "nombre", elemento_Configuracion.id_fase);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", elemento_Configuracion.id_proyecto);
            return View(elemento_Configuracion);
        }

        // GET: Workspace/Elemento_Configuracion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Configuracion elemento_Configuracion = db.Elemento_Configuracion.Find(id);
            if (elemento_Configuracion == null)
            {
                return HttpNotFound();
            }
            return View(elemento_Configuracion);
        }

        // POST: Workspace/Elemento_Configuracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elemento_Configuracion elemento_Configuracion = db.Elemento_Configuracion.Find(id);
            db.Elemento_Configuracion.Remove(elemento_Configuracion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
