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
    public class FaseController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Fase
        public ActionResult Index()
        {
            var fase = db.Fase.Include(f => f.Metodologia);
            return View(fase.ToList());
        }

        // GET: Admin/Fase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = db.Fase.Find(id);
            if (fase == null)
            {
                return HttpNotFound();
            }
            return View(fase);
        }

        // GET: Admin/Fase/Create
        public ActionResult Create()
        {
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre");
            return View();
        }

        // POST: Admin/Fase/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_fase,nombre,id_metodologia,estado")] Fase fase)
        {
            if (ModelState.IsValid)
            {
                db.Fase.Add(fase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", fase.id_metodologia);
            return View(fase);
        }

        // GET: Admin/Fase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = db.Fase.Find(id);
            if (fase == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", fase.id_metodologia);
            return View(fase);
        }

        // POST: Admin/Fase/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_fase,nombre,id_metodologia,estado")] Fase fase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", fase.id_metodologia);
            return View(fase);
        }

        // GET: Admin/Fase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fase fase = db.Fase.Find(id);
            if (fase == null)
            {
                return HttpNotFound();
            }
            return View(fase);
        }

        // POST: Admin/Fase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fase fase = db.Fase.Find(id);
            db.Fase.Remove(fase);
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
