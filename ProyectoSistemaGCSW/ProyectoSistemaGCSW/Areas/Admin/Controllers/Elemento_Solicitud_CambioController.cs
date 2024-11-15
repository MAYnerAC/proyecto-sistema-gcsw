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
    public class Elemento_Solicitud_CambioController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Elemento_Solicitud_Cambio
        public ActionResult Index()
        {
            var elemento_Solicitud_Cambio = db.Elemento_Solicitud_Cambio.Include(e => e.Elemento_Configuracion).Include(e => e.Solicitud_Cambio);
            return View(elemento_Solicitud_Cambio.ToList());
        }

        // GET: Admin/Elemento_Solicitud_Cambio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Solicitud_Cambio elemento_Solicitud_Cambio = db.Elemento_Solicitud_Cambio.Find(id);
            if (elemento_Solicitud_Cambio == null)
            {
                return HttpNotFound();
            }
            return View(elemento_Solicitud_Cambio);
        }

        // GET: Admin/Elemento_Solicitud_Cambio/Create
        public ActionResult Create()
        {
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre");
            ViewBag.id_solicitud_cambio = new SelectList(db.Solicitud_Cambio, "id_solicitud_cambio", "descripcion");
            return View();
        }

        // POST: Admin/Elemento_Solicitud_Cambio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_elemento_solicitud_cambio,id_solicitud_cambio,id_elemento_configuracion,es_principal,fecha_asignacion")] Elemento_Solicitud_Cambio elemento_Solicitud_Cambio)
        {
            if (ModelState.IsValid)
            {
                db.Elemento_Solicitud_Cambio.Add(elemento_Solicitud_Cambio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", elemento_Solicitud_Cambio.id_elemento_configuracion);
            ViewBag.id_solicitud_cambio = new SelectList(db.Solicitud_Cambio, "id_solicitud_cambio", "descripcion", elemento_Solicitud_Cambio.id_solicitud_cambio);
            return View(elemento_Solicitud_Cambio);
        }

        // GET: Admin/Elemento_Solicitud_Cambio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Solicitud_Cambio elemento_Solicitud_Cambio = db.Elemento_Solicitud_Cambio.Find(id);
            if (elemento_Solicitud_Cambio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", elemento_Solicitud_Cambio.id_elemento_configuracion);
            ViewBag.id_solicitud_cambio = new SelectList(db.Solicitud_Cambio, "id_solicitud_cambio", "descripcion", elemento_Solicitud_Cambio.id_solicitud_cambio);
            return View(elemento_Solicitud_Cambio);
        }

        // POST: Admin/Elemento_Solicitud_Cambio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_elemento_solicitud_cambio,id_solicitud_cambio,id_elemento_configuracion,es_principal,fecha_asignacion")] Elemento_Solicitud_Cambio elemento_Solicitud_Cambio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elemento_Solicitud_Cambio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", elemento_Solicitud_Cambio.id_elemento_configuracion);
            ViewBag.id_solicitud_cambio = new SelectList(db.Solicitud_Cambio, "id_solicitud_cambio", "descripcion", elemento_Solicitud_Cambio.id_solicitud_cambio);
            return View(elemento_Solicitud_Cambio);
        }

        // GET: Admin/Elemento_Solicitud_Cambio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Solicitud_Cambio elemento_Solicitud_Cambio = db.Elemento_Solicitud_Cambio.Find(id);
            if (elemento_Solicitud_Cambio == null)
            {
                return HttpNotFound();
            }
            return View(elemento_Solicitud_Cambio);
        }

        // POST: Admin/Elemento_Solicitud_Cambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elemento_Solicitud_Cambio elemento_Solicitud_Cambio = db.Elemento_Solicitud_Cambio.Find(id);
            db.Elemento_Solicitud_Cambio.Remove(elemento_Solicitud_Cambio);
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
