namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tarea")]
    public partial class Tarea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarea()
        {
            Elemento_Tarea = new HashSet<Elemento_Tarea>();
            Miembro_Tarea = new HashSet<Miembro_Tarea>();
        }

        [Key]
        public int id_tarea { get; set; }

        [Required]
        [StringLength(100)]
        public string titulo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public int id_proyecto { get; set; }

        public int id_estado_tarea { get; set; }

        public int id_prioridad { get; set; }

        public DateTime? fecha_creacion { get; set; }

        public DateTime? fecha_limite { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Tarea> Elemento_Tarea { get; set; }

        public virtual Estado_Tarea Estado_Tarea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro_Tarea> Miembro_Tarea { get; set; }

        public virtual Prioridad Prioridad { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
