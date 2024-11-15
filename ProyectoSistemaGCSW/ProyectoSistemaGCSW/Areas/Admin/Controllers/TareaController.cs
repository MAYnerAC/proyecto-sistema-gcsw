using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoSistemaGCSW.Models;

namespace ProyectoSistemaGCSW.Areas.Admin.Controllers
{
    public class TareaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Tarea
        public ActionResult Index()
        {
            var tarea = db.Tarea.Include(t => t.Estado_Tarea).Include(t => t.Prioridad).Include(t => t.Proyecto);
            return View(tarea.ToList());
        }

        // GET: Admin/Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // GET: Admin/Tarea/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre");
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre");
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            return View();
        }

        // POST: Admin/Tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarea,titulo,descripcion,id_proyecto,id_estado_tarea,id_prioridad,fecha_creacion,fecha_limite,estado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Tarea.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre", tarea.id_estado_tarea);
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre", tarea.id_prioridad);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", tarea.id_proyecto);
            return View(tarea);
        }

        // GET: Admin/Tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre", tarea.id_estado_tarea);
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre", tarea.id_prioridad);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", tarea.id_proyecto);
            return View(tarea);
        }

        // POST: Admin/Tarea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarea,titulo,descripcion,id_proyecto,id_estado_tarea,id_prioridad,fecha_creacion,fecha_limite,estado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado_tarea = new SelectList(db.Estado_Tarea, "id_estado_tarea", "nombre", tarea.id_estado_tarea);
            ViewBag.id_prioridad = new SelectList(db.Prioridad, "id_prioridad", "nombre", tarea.id_prioridad);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", tarea.id_proyecto);
            return View(tarea);
        }

        // GET: Admin/Tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarea tarea = db.Tarea.Find(id);
            if (tarea == null)
            {
                return HttpNotFound();
            }
            return View(tarea);
        }

        // POST: Admin/Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarea tarea = db.Tarea.Find(id);
            db.Tarea.Remove(tarea);
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
