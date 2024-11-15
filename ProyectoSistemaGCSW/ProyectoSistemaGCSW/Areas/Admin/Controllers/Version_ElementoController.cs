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
    public class Version_ElementoController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Version_Elemento
        public ActionResult Index()
        {
            var version_Elemento = db.Version_Elemento.Include(v => v.Elemento_Configuracion);
            return View(version_Elemento.ToList());
        }

        // GET: Admin/Version_Elemento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Version_Elemento version_Elemento = db.Version_Elemento.Find(id);
            if (version_Elemento == null)
            {
                return HttpNotFound();
            }
            return View(version_Elemento);
        }

        // GET: Admin/Version_Elemento/Create
        public ActionResult Create()
        {
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre");
            return View();
        }

        // POST: Admin/Version_Elemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_version,id_elemento_configuracion,numero_version,descripcion,fecha_creacion")] Version_Elemento version_Elemento)
        {
            if (ModelState.IsValid)
            {
                db.Version_Elemento.Add(version_Elemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", version_Elemento.id_elemento_configuracion);
            return View(version_Elemento);
        }

        // GET: Admin/Version_Elemento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Version_Elemento version_Elemento = db.Version_Elemento.Find(id);
            if (version_Elemento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", version_Elemento.id_elemento_configuracion);
            return View(version_Elemento);
        }

        // POST: Admin/Version_Elemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_version,id_elemento_configuracion,numero_version,descripcion,fecha_creacion")] Version_Elemento version_Elemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(version_Elemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", version_Elemento.id_elemento_configuracion);
            return View(version_Elemento);
        }

        // GET: Admin/Version_Elemento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Version_Elemento version_Elemento = db.Version_Elemento.Find(id);
            if (version_Elemento == null)
            {
                return HttpNotFound();
            }
            return View(version_Elemento);
        }

        // POST: Admin/Version_Elemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Version_Elemento version_Elemento = db.Version_Elemento.Find(id);
            db.Version_Elemento.Remove(version_Elemento);
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
