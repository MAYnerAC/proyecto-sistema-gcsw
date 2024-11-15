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
    public class UsuarioController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Tipo_Usuario);
            return View(usuario.ToList());
        }

        // GET: Admin/Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Admin/Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre");
            return View();
        }

        // POST: Admin/Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,nombre,apellido,correo,contrasena,estado,id_tipo_usuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre", usuario.id_tipo_usuario);
            return View(usuario);
        }

        // GET: Admin/Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre", usuario.id_tipo_usuario);
            return View(usuario);
        }

        // POST: Admin/Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,nombre,apellido,correo,contrasena,estado,id_tipo_usuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_usuario = new SelectList(db.Tipo_Usuario, "id_tipo_usuario", "nombre", usuario.id_tipo_usuario);
            return View(usuario);
        }

        // GET: Admin/Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Admin/Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
