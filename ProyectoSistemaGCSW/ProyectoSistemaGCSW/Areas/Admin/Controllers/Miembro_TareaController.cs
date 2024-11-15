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
    public class Miembro_TareaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Miembro_Tarea
        public ActionResult Index()
        {
            var miembro_Tarea = db.Miembro_Tarea.Include(m => m.Miembro_Proyecto).Include(m => m.Tarea);
            return View(miembro_Tarea.ToList());
        }

        // GET: Admin/Miembro_Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro_Tarea miembro_Tarea = db.Miembro_Tarea.Find(id);
            if (miembro_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(miembro_Tarea);
        }

        // GET: Admin/Miembro_Tarea/Create
        public ActionResult Create()
        {
            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto");
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo");
            return View();
        }

        // POST: Admin/Miembro_Tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_miembro_tarea,id_miembro_proyecto,id_tarea,es_principal,fecha_asignacion")] Miembro_Tarea miembro_Tarea)
        {
            if (ModelState.IsValid)
            {
                db.Miembro_Tarea.Add(miembro_Tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", miembro_Tarea.id_miembro_proyecto);
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo", miembro_Tarea.id_tarea);
            return View(miembro_Tarea);
        }

        // GET: Admin/Miembro_Tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro_Tarea miembro_Tarea = db.Miembro_Tarea.Find(id);
            if (miembro_Tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", miembro_Tarea.id_miembro_proyecto);
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo", miembro_Tarea.id_tarea);
            return View(miembro_Tarea);
        }

        // POST: Admin/Miembro_Tarea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_miembro_tarea,id_miembro_proyecto,id_tarea,es_principal,fecha_asignacion")] Miembro_Tarea miembro_Tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembro_Tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", miembro_Tarea.id_miembro_proyecto);
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo", miembro_Tarea.id_tarea);
            return View(miembro_Tarea);
        }

        // GET: Admin/Miembro_Tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro_Tarea miembro_Tarea = db.Miembro_Tarea.Find(id);
            if (miembro_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(miembro_Tarea);
        }

        // POST: Admin/Miembro_Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembro_Tarea miembro_Tarea = db.Miembro_Tarea.Find(id);
            db.Miembro_Tarea.Remove(miembro_Tarea);
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
