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

namespace ProyectoSistemaGCSW.Areas.Workspace.Controllers
{
    [Autenticado]
    [TipoUsuarioAutorizado(3)]
    [ProyectoSeleccionado]
    public class Miembro_ProyectoController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Workspace/Miembro_Proyecto
        public ActionResult Index()
        {
            int proyectoId = (int)Session["ProyectoId"];

            var miembro_Proyecto = db.Miembro_Proyecto
                .Include(m => m.Proyecto)
                .Include(m => m.Rol)
                .Include(m => m.Usuario)
                .Where(m => m.id_proyecto == proyectoId)
                .ToList();

            return View(miembro_Proyecto);
        }

        // GET: Workspace/Miembro_Proyecto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro_Proyecto miembro_Proyecto = db.Miembro_Proyecto.Find(id);
            if (miembro_Proyecto == null)
            {
                return HttpNotFound();
            }
            return View(miembro_Proyecto);
        }

        // GET: Workspace/Miembro_Proyecto/Create
        public ActionResult Create()
        {
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre");
            ViewBag.id_rol = new SelectList(db.Rol, "id_rol", "nombre");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Workspace/Miembro_Proyecto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_miembro_proyecto,id_usuario,id_proyecto,id_rol,nivel")] Miembro_Proyecto miembro_Proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Miembro_Proyecto.Add(miembro_Proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", miembro_Proyecto.id_proyecto);
            ViewBag.id_rol = new SelectList(db.Rol, "id_rol", "nombre", miembro_Proyecto.id_rol);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", miembro_Proyecto.id_usuario);
            return View(miembro_Proyecto);
        }

        // GET: Workspace/Miembro_Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro_Proyecto miembro_Proyecto = db.Miembro_Proyecto.Find(id);
            if (miembro_Proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", miembro_Proyecto.id_proyecto);
            ViewBag.id_rol = new SelectList(db.Rol, "id_rol", "nombre", miembro_Proyecto.id_rol);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", miembro_Proyecto.id_usuario);
            return View(miembro_Proyecto);
        }

        // POST: Workspace/Miembro_Proyecto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_miembro_proyecto,id_usuario,id_proyecto,id_rol,nivel")] Miembro_Proyecto miembro_Proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miembro_Proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proyecto = new SelectList(db.Proyecto, "id_proyecto", "nombre", miembro_Proyecto.id_proyecto);
            ViewBag.id_rol = new SelectList(db.Rol, "id_rol", "nombre", miembro_Proyecto.id_rol);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombre", miembro_Proyecto.id_usuario);
            return View(miembro_Proyecto);
        }

        // GET: Workspace/Miembro_Proyecto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miembro_Proyecto miembro_Proyecto = db.Miembro_Proyecto.Find(id);
            if (miembro_Proyecto == null)
            {
                return HttpNotFound();
            }
            return View(miembro_Proyecto);
        }

        // POST: Workspace/Miembro_Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miembro_Proyecto miembro_Proyecto = db.Miembro_Proyecto.Find(id);
            db.Miembro_Proyecto.Remove(miembro_Proyecto);
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
