using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//
using ProyectoSistemaGCSW.Filters;
using ProyectoSistemaGCSW.Models;

namespace ProyectoSistemaGCSW.Areas.Admin.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(1)]
    public class MetodologiaController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Metodologia
        public ActionResult Index()
        {
            return View(db.Metodologia.ToList());
        }

        // GET: Admin/Metodologia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodologia metodologia = db.Metodologia.Find(id);
            if (metodologia == null)
            {
                return HttpNotFound();
            }
            return View(metodologia);
        }

        // GET: Admin/Metodologia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Metodologia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_metodologia,nombre,estado")] Metodologia metodologia)
        {
            if (ModelState.IsValid)
            {
                db.Metodologia.Add(metodologia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metodologia);
        }

        // GET: Admin/Metodologia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodologia metodologia = db.Metodologia.Find(id);
            if (metodologia == null)
            {
                return HttpNotFound();
            }
            return View(metodologia);
        }

        // POST: Admin/Metodologia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_metodologia,nombre,estado")] Metodologia metodologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodologia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metodologia);
        }

        // GET: Admin/Metodologia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metodologia metodologia = db.Metodologia.Find(id);
            if (metodologia == null)
            {
                return HttpNotFound();
            }
            return View(metodologia);
        }

        // POST: Admin/Metodologia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Metodologia metodologia = db.Metodologia.Find(id);
            db.Metodologia.Remove(metodologia);
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
