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
    public class Historial_CambiosController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Historial_Cambios
        public ActionResult Index()
        {
            var historial_Cambios = db.Historial_Cambios.Include(h => h.Usuario);
            return View(historial_Cambios.ToList());
        }

        // GET: Admin/Historial_Cambios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial_Cambios historial_Cambios = db.Historial_Cambios.Find(id);
            if (historial_Cambios == null)
            {
                return HttpNotFound();
            }
            return View(historial_Cambios);
        }

        // GET: Admin/Historial_Cambios/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Historial_Cambios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_historial,tabla,id_registro,tipo_cambio,valor_anterior,valor_nuevo,fecha_cambio,id_usuario")] Historial_Cambios historial_Cambios)
        {
            if (ModelState.IsValid)
            {
                db.Historial_Cambios.Add(historial_Cambios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", historial_Cambios.id_usuario);
            return View(historial_Cambios);
        }

        // GET: Admin/Historial_Cambios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial_Cambios historial_Cambios = db.Historial_Cambios.Find(id);
            if (historial_Cambios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", historial_Cambios.id_usuario);
            return View(historial_Cambios);
        }

        // POST: Admin/Historial_Cambios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_historial,tabla,id_registro,tipo_cambio,valor_anterior,valor_nuevo,fecha_cambio,id_usuario")] Historial_Cambios historial_Cambios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial_Cambios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", historial_Cambios.id_usuario);
            return View(historial_Cambios);
        }

        // GET: Admin/Historial_Cambios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historial_Cambios historial_Cambios = db.Historial_Cambios.Find(id);
            if (historial_Cambios == null)
            {
                return HttpNotFound();
            }
            return View(historial_Cambios);
        }

        // POST: Admin/Historial_Cambios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historial_Cambios historial_Cambios = db.Historial_Cambios.Find(id);
            db.Historial_Cambios.Remove(historial_Cambios);
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
