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
    public class Solicitud_CambioController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Solicitud_Cambio
        public ActionResult Index()
        {
            var solicitud_Cambio = db.Solicitud_Cambio.Include(s => s.Estado_Solicitud).Include(s => s.Miembro_Proyecto).Include(s => s.Miembro_Proyecto1).Include(s => s.Proyecto);
            return View(solicitud_Cambio.ToList());
        }

        // GET: Admin/Solicitud_Cambio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Cambio solicitud_Cambio = db.Solicitud_Cambio.Find(id);
            if (solicitud_Cambio == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Cambio);
        }

        // GET: Admin/Solicitud_Cambio/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_solicitud = new SelectList(db.Estado_Solicitud, "id_estado_solicitud", "nombre");
            ViewBag.id_miembro_solicitante = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto");
            ViewBag.id_miembro_responsable = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto");
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            return View();
        }

        // POST: Admin/Solicitud_Cambio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_solicitud_cambio,id_proyecto,id_miembro_solicitante,id_miembro_responsable,id_estado_solicitud,descripcion,descripcion_impacto,estado,fecha_creacion,fecha_aprobacion,fecha_inicio,fecha_fin")] Solicitud_Cambio solicitud_Cambio)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud_Cambio.Add(solicitud_Cambio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado_solicitud = new SelectList(db.Estado_Solicitud, "id_estado_solicitud", "nombre", solicitud_Cambio.id_estado_solicitud);
            ViewBag.id_miembro_solicitante = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", solicitud_Cambio.id_miembro_solicitante);
            ViewBag.id_miembro_responsable = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", solicitud_Cambio.id_miembro_responsable);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", solicitud_Cambio.id_proyecto);
            return View(solicitud_Cambio);
        }

        // GET: Admin/Solicitud_Cambio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Cambio solicitud_Cambio = db.Solicitud_Cambio.Find(id);
            if (solicitud_Cambio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado_solicitud = new SelectList(db.Estado_Solicitud, "id_estado_solicitud", "nombre", solicitud_Cambio.id_estado_solicitud);
            ViewBag.id_miembro_solicitante = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", solicitud_Cambio.id_miembro_solicitante);
            ViewBag.id_miembro_responsable = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", solicitud_Cambio.id_miembro_responsable);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", solicitud_Cambio.id_proyecto);
            return View(solicitud_Cambio);
        }

        // POST: Admin/Solicitud_Cambio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_solicitud_cambio,id_proyecto,id_miembro_solicitante,id_miembro_responsable,id_estado_solicitud,descripcion,descripcion_impacto,estado,fecha_creacion,fecha_aprobacion,fecha_inicio,fecha_fin")] Solicitud_Cambio solicitud_Cambio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_Cambio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado_solicitud = new SelectList(db.Estado_Solicitud, "id_estado_solicitud", "nombre", solicitud_Cambio.id_estado_solicitud);
            ViewBag.id_miembro_solicitante = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", solicitud_Cambio.id_miembro_solicitante);
            ViewBag.id_miembro_responsable = new SelectList(db.Miembro_Proyecto, "id_miembro_proyecto", "id_miembro_proyecto", solicitud_Cambio.id_miembro_responsable);
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", solicitud_Cambio.id_proyecto);
            return View(solicitud_Cambio);
        }

        // GET: Admin/Solicitud_Cambio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Cambio solicitud_Cambio = db.Solicitud_Cambio.Find(id);
            if (solicitud_Cambio == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Cambio);
        }

        // POST: Admin/Solicitud_Cambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud_Cambio solicitud_Cambio = db.Solicitud_Cambio.Find(id);
            db.Solicitud_Cambio.Remove(solicitud_Cambio);
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
