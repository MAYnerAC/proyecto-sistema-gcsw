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
    public class NotificacionController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Notificacion
        public ActionResult Index()
        {
            var notificacion = db.Notificacion.Include(n => n.Usuario);
            return View(notificacion.ToList());
        }

        // GET: Admin/Notificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notificacion notificacion = db.Notificacion.Find(id);
            if (notificacion == null)
            {
                return HttpNotFound();
            }
            return View(notificacion);
        }

        // GET: Admin/Notificacion/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Notificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_notificacion,id_usuario,mensaje,fecha_envio,leido")] Notificacion notificacion)
        {
            if (ModelState.IsValid)
            {
                db.Notificacion.Add(notificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", notificacion.id_usuario);
            return View(notificacion);
        }

        // GET: Admin/Notificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notificacion notificacion = db.Notificacion.Find(id);
            if (notificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", notificacion.id_usuario);
            return View(notificacion);
        }

        // POST: Admin/Notificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_notificacion,id_usuario,mensaje,fecha_envio,leido")] Notificacion notificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", notificacion.id_usuario);
            return View(notificacion);
        }

        // GET: Admin/Notificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notificacion notificacion = db.Notificacion.Find(id);
            if (notificacion == null)
            {
                return HttpNotFound();
            }
            return View(notificacion);
        }

        // POST: Admin/Notificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notificacion notificacion = db.Notificacion.Find(id);
            db.Notificacion.Remove(notificacion);
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
