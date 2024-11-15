using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProyectoSistemaGCSW.Models
{
    public partial class ModeloSistema : DbContext
    {
        public ModeloSistema()
            : base("name=ModeloSistema")
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Elemento_Configuracion> Elemento_Configuracion { get; set; }
        public virtual DbSet<Elemento_Solicitud_Cambio> Elemento_Solicitud_Cambio { get; set; }
        public virtual DbSet<Elemento_Tarea> Elemento_Tarea { get; set; }
        public virtual DbSet<Estado_Proyecto> Estado_Proyecto { get; set; }
        public virtual DbSet<Estado_Solicitud> Estado_Solicitud { get; set; }
        public virtual DbSet<Estado_Tarea> Estado_Tarea { get; set; }
        public virtual DbSet<Fase> Fase { get; set; }
        public virtual DbSet<Historial_Cambios> Historial_Cambios { get; set; }
        public virtual DbSet<Metodologia> Metodologia { get; set; }
        public virtual DbSet<Miembro_Proyecto> Miembro_Proyecto { get; set; }
        public virtual DbSet<Miembro_Tarea> Miembro_Tarea { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<Prioridad> Prioridad { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud_Cambio> Solicitud_Cambio { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Version_Elemento> Version_Elemento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .Property(e => e.nombre_actividad)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.codigo_elemento)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.nomenclatura)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.url_recurso_asociado)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .HasMany(e => e.Elemento_Solicitud_Cambio)
                .WithRequired(e => e.Elemento_Configuracion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .HasMany(e => e.Elemento_Tarea)
                .WithRequired(e => e.Elemento_Configuracion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .HasMany(e => e.Version_Elemento)
                .WithRequired(e => e.Elemento_Configuracion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elemento_Solicitud_Cambio>()
                .Property(e => e.es_principal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Tarea>()
                .Property(e => e.es_principal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Proyecto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Proyecto>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Estado_Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado_Solicitud>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Solicitud>()
                .HasMany(e => e.Solicitud_Cambio)
                .WithRequired(e => e.Estado_Solicitud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estado_Tarea>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Tarea>()
                .HasMany(e => e.Tarea)
                .WithRequired(e => e.Estado_Tarea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fase>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Fase>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Historial_Cambios>()
                .Property(e => e.tabla)
                .IsUnicode(false);

            modelBuilder.Entity<Historial_Cambios>()
                .Property(e => e.tipo_cambio)
                .IsUnicode(false);

            modelBuilder.Entity<Historial_Cambios>()
                .Property(e => e.valor_anterior)
                .IsUnicode(false);

            modelBuilder.Entity<Historial_Cambios>()
                .Property(e => e.valor_nuevo)
                .IsUnicode(false);

            modelBuilder.Entity<Metodologia>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Metodologia>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Metodologia>()
                .HasMany(e => e.Fase)
                .WithRequired(e => e.Metodologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Metodologia>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Metodologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Miembro_Proyecto>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Miembro_Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Miembro_Proyecto>()
                .HasMany(e => e.Miembro_Tarea)
                .WithRequired(e => e.Miembro_Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Miembro_Proyecto>()
                .HasMany(e => e.Solicitud_Cambio)
                .WithRequired(e => e.Miembro_Proyecto)
                .HasForeignKey(e => e.id_miembro_solicitante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Miembro_Proyecto>()
                .HasMany(e => e.Solicitud_Cambio1)
                .WithOptional(e => e.Miembro_Proyecto1)
                .HasForeignKey(e => e.id_miembro_responsable);

            modelBuilder.Entity<Miembro_Tarea>()
                .Property(e => e.es_principal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.mensaje)
                .IsUnicode(false);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.leido)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Prioridad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Prioridad>()
                .HasMany(e => e.Tarea)
                .WithRequired(e => e.Prioridad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.codigo_proyecto)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.url_repositorio)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Elemento_Configuracion)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Miembro_Proyecto)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Solicitud_Cambio)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Tarea)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Miembro_Proyecto)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud_Cambio>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambio>()
                .Property(e => e.descripcion_impacto)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambio>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambio>()
                .HasMany(e => e.Elemento_Solicitud_Cambio)
                .WithRequired(e => e.Solicitud_Cambio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarea>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tarea>()
                .HasMany(e => e.Elemento_Tarea)
                .WithRequired(e => e.Tarea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarea>()
                .HasMany(e => e.Miembro_Tarea)
                .WithRequired(e => e.Tarea)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Tipo_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Historial_Cambios)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Miembro_Proyecto)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Notificacion)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.id_usuario_creador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Version_Elemento>()
                .Property(e => e.numero_version)
                .IsUnicode(false);

            modelBuilder.Entity<Version_Elemento>()
                .Property(e => e.descripcion)
                .IsUnicode(false);
        }
    }
}
