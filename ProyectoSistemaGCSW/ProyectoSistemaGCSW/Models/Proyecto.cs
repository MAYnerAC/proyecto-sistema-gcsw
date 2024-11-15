namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proyecto")]
    public partial class Proyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyecto()
        {
            Actividad = new HashSet<Actividad>();
            Elemento_Configuracion = new HashSet<Elemento_Configuracion>();
            Miembro_Proyecto = new HashSet<Miembro_Proyecto>();
            Solicitud_Cambio = new HashSet<Solicitud_Cambio>();
            Tarea = new HashSet<Tarea>();
        }

        [Key]
        public int id_proyecto { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string codigo_proyecto { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_metodologia { get; set; }

        public int id_estado_proyecto { get; set; }

        public int id_usuario_creador { get; set; }

        [StringLength(255)]
        public string url_repositorio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Configuracion> Elemento_Configuracion { get; set; }

        public virtual Estado_Proyecto Estado_Proyecto { get; set; }

        public virtual Metodologia Metodologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro_Proyecto> Miembro_Proyecto { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Cambio> Solicitud_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarea> Tarea { get; set; }
    }
}
