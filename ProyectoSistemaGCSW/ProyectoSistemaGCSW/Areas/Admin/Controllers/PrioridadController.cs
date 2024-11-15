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
    public class PrioridadController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Prioridad
        public ActionResult Index()
        {
            return View(db.Prioridad.ToList());
        }

        // GET: Admin/Prioridad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridad prioridad = db.Prioridad.Find(id);
            if (prioridad == null)
            {
                return HttpNotFound();
            }
            return View(prioridad);
        }

        // GET: Admin/Prioridad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Prioridad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prioridad,nombre")] Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                db.Prioridad.Add(prioridad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridad);
        }

        // GET: Admin/Prioridad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridad prioridad = db.Prioridad.Find(id);
            if (prioridad == null)
            {
                return HttpNotFound();
            }
            return View(prioridad);
        }

        // POST: Admin/Prioridad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prioridad,nombre")] Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prioridad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridad);
        }

        // GET: Admin/Prioridad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridad prioridad = db.Prioridad.Find(id);
            if (prioridad == null)
            {
                return HttpNotFound();
            }
            return View(prioridad);
        }

        // POST: Admin/Prioridad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prioridad prioridad = db.Prioridad.Find(id);
            db.Prioridad.Remove(prioridad);
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
