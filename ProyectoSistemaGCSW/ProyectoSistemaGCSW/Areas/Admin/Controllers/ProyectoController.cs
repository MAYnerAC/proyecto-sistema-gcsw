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
    public class ProyectoController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Proyecto
        public ActionResult Index()
        {
            var proyecto = db.Proyecto.Include(p => p.Estado_Proyecto).Include(p => p.Metodologia).Include(p => p.Usuario);
            return View(proyecto.ToList());
        }

        // GET: Admin/Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Admin/Proyecto/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre");
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre");
            ViewBag.id_usuario_creador = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Admin/Proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_proyecto,nombre,codigo_proyecto,descripcion,fecha_inicio,fecha_fin,estado,id_metodologia,id_estado_proyecto,id_usuario_creador,url_repositorio")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre", proyecto.id_estado_proyecto);
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", proyecto.id_metodologia);
            ViewBag.id_usuario_creador = new SelectList(db.Usuario, "id_usuario", "nombre", proyecto.id_usuario_creador);
            return View(proyecto);
        }

        // GET: Admin/Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre", proyecto.id_estado_proyecto);
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", proyecto.id_metodologia);
            ViewBag.id_usuario_creador = new SelectList(db.Usuario, "id_usuario", "nombre", proyecto.id_usuario_creador);
            return View(proyecto);
        }

        // POST: Admin/Proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_proyecto,nombre,codigo_proyecto,descripcion,fecha_inicio,fecha_fin,estado,id_metodologia,id_estado_proyecto,id_usuario_creador,url_repositorio")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado_proyecto = new SelectList(db.Estado_Proyecto, "id_estado_proyecto", "nombre", proyecto.id_estado_proyecto);
            ViewBag.id_metodologia = new SelectList(db.Metodologia, "id_metodologia", "nombre", proyecto.id_metodologia);
            ViewBag.id_usuario_creador = new SelectList(db.Usuario, "id_usuario", "nombre", proyecto.id_usuario_creador);
            return View(proyecto);
        }

        // GET: Admin/Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Admin/Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
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
