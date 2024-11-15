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
    public class Estado_SolicitudController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Estado_Solicitud
        public ActionResult Index()
        {
            return View(db.Estado_Solicitud.ToList());
        }

        // GET: Admin/Estado_Solicitud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Solicitud estado_Solicitud = db.Estado_Solicitud.Find(id);
            if (estado_Solicitud == null)
            {
                return HttpNotFound();
            }
            return View(estado_Solicitud);
        }

        // GET: Admin/Estado_Solicitud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Estado_Solicitud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado_solicitud,nombre")] Estado_Solicitud estado_Solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Solicitud.Add(estado_Solicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Solicitud);
        }

        // GET: Admin/Estado_Solicitud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Solicitud estado_Solicitud = db.Estado_Solicitud.Find(id);
            if (estado_Solicitud == null)
            {
                return HttpNotFound();
            }
            return View(estado_Solicitud);
        }

        // POST: Admin/Estado_Solicitud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado_solicitud,nombre")] Estado_Solicitud estado_Solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Solicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Solicitud);
        }

        // GET: Admin/Estado_Solicitud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Solicitud estado_Solicitud = db.Estado_Solicitud.Find(id);
            if (estado_Solicitud == null)
            {
                return HttpNotFound();
            }
            return View(estado_Solicitud);
        }

        // POST: Admin/Estado_Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Solicitud estado_Solicitud = db.Estado_Solicitud.Find(id);
            db.Estado_Solicitud.Remove(estado_Solicitud);
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
