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
    public class ActividadController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Actividad
        public ActionResult Index()
        {
            var actividad = db.Actividad.Include(a => a.Miembro_Proyecto).Include(a => a.Proyecto);
            return View(actividad.ToList());
        }

        // GET: Admin/Actividad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // GET: Admin/Actividad/Create
        public ActionResult Create()
        {
            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto");
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            return View();
        }

        // POST: Admin/Actividad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_actividad,nombre_actividad,descripcion,fecha_inicio,fecha_fin,estado,id_proyecto,id_miembro_proyecto")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividad.Add(actividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", actividad.id_miembro_proyecto);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", actividad.id_proyecto);
            return View(actividad);
        }

        // GET: Admin/Actividad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", actividad.id_miembro_proyecto);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", actividad.id_proyecto);
            return View(actividad);
        }

        // POST: Admin/Actividad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_actividad,nombre_actividad,descripcion,fecha_inicio,fecha_fin,estado,id_proyecto,id_miembro_proyecto")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_miembro_proyecto = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", actividad.id_miembro_proyecto);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", actividad.id_proyecto);
            return View(actividad);
        }

        // GET: Admin/Actividad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividad actividad = db.Actividad.Find(id);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        // POST: Admin/Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividad actividad = db.Actividad.Find(id);
            db.Actividad.Remove(actividad);
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
