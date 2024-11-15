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
    public class Estado_ProyectoController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Estado_Proyecto
        public ActionResult Index()
        {
            return View(db.Estado_Proyecto.ToList());
        }

        // GET: Admin/Estado_Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Proyecto estado_Proyecto = db.Estado_Proyecto.Find(id);
            if (estado_Proyecto == null)
            {
                return HttpNotFound();
            }
            return View(estado_Proyecto);
        }

        // GET: Admin/Estado_Proyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Estado_Proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_proyecto,nombre")] Estado_Proyecto estado_Proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Proyecto.Add(estado_Proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Proyecto);
        }

        // GET: Admin/Estado_Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Proyecto estado_Proyecto = db.Estado_Proyecto.Find(id);
            if (estado_Proyecto == null)
            {
                return HttpNotFound();
            }
            return View(estado_Proyecto);
        }

        // POST: Admin/Estado_Proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_proyecto,nombre")] Estado_Proyecto estado_Proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Proyecto);
        }

        // GET: Admin/Estado_Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Proyecto estado_Proyecto = db.Estado_Proyecto.Find(id);
            if (estado_Proyecto == null)
            {
                return HttpNotFound();
            }
            return View(estado_Proyecto);
        }

        // POST: Admin/Estado_Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Proyecto estado_Proyecto = db.Estado_Proyecto.Find(id);
            db.Estado_Proyecto.Remove(estado_Proyecto);
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
