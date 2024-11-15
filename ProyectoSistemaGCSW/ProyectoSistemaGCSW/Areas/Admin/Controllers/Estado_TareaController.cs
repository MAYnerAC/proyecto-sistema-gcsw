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
    public class Estado_TareaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Estado_Tarea
        public ActionResult Index()
        {
            return View(db.Estado_Tarea.ToList());
        }

        // GET: Admin/Estado_Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Tarea estado_Tarea = db.Estado_Tarea.Find(id);
            if (estado_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(estado_Tarea);
        }

        // GET: Admin/Estado_Tarea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Estado_Tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_tarea,nombre")] Estado_Tarea estado_Tarea)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Tarea.Add(estado_Tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Tarea);
        }

        // GET: Admin/Estado_Tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Tarea estado_Tarea = db.Estado_Tarea.Find(id);
            if (estado_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(estado_Tarea);
        }

        // POST: Admin/Estado_Tarea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_tarea,nombre")] Estado_Tarea estado_Tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Tarea);
        }

        // GET: Admin/Estado_Tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Tarea estado_Tarea = db.Estado_Tarea.Find(id);
            if (estado_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(estado_Tarea);
        }

        // POST: Admin/Estado_Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Tarea estado_Tarea = db.Estado_Tarea.Find(id);
            db.Estado_Tarea.Remove(estado_Tarea);
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
