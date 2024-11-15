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
    public class Elemento_TareaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Elemento_Tarea
        public ActionResult Index()
        {
            var elemento_Tarea = db.Elemento_Tarea.Include(e => e.Elemento_Configuracion).Include(e => e.Tarea);
            return View(elemento_Tarea.ToList());
        }

        // GET: Admin/Elemento_Tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Tarea elemento_Tarea = db.Elemento_Tarea.Find(id);
            if (elemento_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(elemento_Tarea);
        }

        // GET: Admin/Elemento_Tarea/Create
        public ActionResult Create()
        {
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre");
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo");
            return View();
        }

        // POST: Admin/Elemento_Tarea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_elemento_tarea,id_tarea,id_elemento_configuracion,es_principal,fecha_asignacion")] Elemento_Tarea elemento_Tarea)
        {
            if (ModelState.IsValid)
            {
                db.Elemento_Tarea.Add(elemento_Tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", elemento_Tarea.id_elemento_configuracion);
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo", elemento_Tarea.id_tarea);
            return View(elemento_Tarea);
        }

        // GET: Admin/Elemento_Tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Tarea elemento_Tarea = db.Elemento_Tarea.Find(id);
            if (elemento_Tarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", elemento_Tarea.id_elemento_configuracion);
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo", elemento_Tarea.id_tarea);
            return View(elemento_Tarea);
        }

        // POST: Admin/Elemento_Tarea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_elemento_tarea,id_tarea,id_elemento_configuracion,es_principal,fecha_asignacion")] Elemento_Tarea elemento_Tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elemento_Tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_elemento_configuracion = new SelectList(db.Elemento_Configuracion, "id_elemento_configuracion", "nombre", elemento_Tarea.id_elemento_configuracion);
            ViewBag.id_tarea = new SelectList(db.Tarea, "id_tarea", "titulo", elemento_Tarea.id_tarea);
            return View(elemento_Tarea);
        }

        // GET: Admin/Elemento_Tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento_Tarea elemento_Tarea = db.Elemento_Tarea.Find(id);
            if (elemento_Tarea == null)
            {
                return HttpNotFound();
            }
            return View(elemento_Tarea);
        }

        // POST: Admin/Elemento_Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elemento_Tarea elemento_Tarea = db.Elemento_Tarea.Find(id);
            db.Elemento_Tarea.Remove(elemento_Tarea);
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
