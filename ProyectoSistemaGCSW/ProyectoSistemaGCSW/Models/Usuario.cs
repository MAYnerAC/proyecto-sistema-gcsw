namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    //
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Historial_Cambios = new HashSet<Historial_Cambios>();
            Miembro_Proyecto = new HashSet<Miembro_Proyecto>();
            Notificacion = new HashSet<Notificacion>();
            Proyecto = new HashSet<Proyecto>();
        }

        [Key]
        public int id_usuario { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string apellido { get; set; }

        [StringLength(100)]
        public string correo { get; set; }

        [StringLength(50)]
        public string contrasena { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_tipo_usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial_Cambios> Historial_Cambios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro_Proyecto> Miembro_Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notificacion> Notificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }

        public virtual Tipo_Usuario Tipo_Usuario { get; set; }


        //


        ModeloSistema db = new ModeloSistema();

        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new ModeloSistema())
                {
                    usuarios = db.Usuario.Include("Tipo_Usuario").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;

        }

        public Usuario Obtener(int id)
        {
            var usuarios = new Usuario();
            try
            {
                using (var db = new ModeloSistema())
                {
                    usuarios = db.Usuario.Include("Tipo_Usuario").Where(x => x.id_usuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public List<Usuario> Buscar(string criterio)
        {
            var categorias = new List<Usuario>();

            try
            {
                using (var db = new ModeloSistema())
                {
                    categorias = db.Usuario.Include("Tipo_Usuario").Where(x => x.nombre.Contains(criterio) ||
                                x.apellido.Contains(criterio) || x.correo.Contains(criterio) ||
                                x.Tipo_Usuario.nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return categorias;

        }

        public void Guardar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    if (this.id_usuario > 0)
                    {
                        db.Entry(this).State = EntityState.Modified; //existe
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added; //nuevo registro
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {

                    db.Entry(this).State = EntityState.Deleted;

                    db.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //login
        public bool Autenticar()
        {

            return db.Usuario
                   .Where(x => x.correo == this.correo
                   && x.contrasena == this.contrasena)
                   .FirstOrDefault() != null;
        }
        //obtener datos del login
        public Usuario ObtenerDatos(string Correo)
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new ModeloSistema())
                {
                    usuario = db.Usuario.Include("Tipo_Usuario")
                        .Where(x => x.correo == Correo)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }



        public bool RegistrarUsuario()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    if (db.Usuario.Any(u => u.correo == this.correo))
                    {
                        return false;
                    }

                    this.id_tipo_usuario = 3;
                    //this.fecha_registro = DateTime.Now;
                    this.estado = "A";

                    db.Entry(this).State = EntityState.Added;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el usuario", ex);
            }
        }





        //
    }
}
