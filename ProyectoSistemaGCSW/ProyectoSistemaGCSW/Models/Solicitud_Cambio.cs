namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_Cambio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud_Cambio()
        {
            Elemento_Solicitud_Cambio = new HashSet<Elemento_Solicitud_Cambio>();
        }

        [Key]
        public int id_solicitud_cambio { get; set; }

        public int id_proyecto { get; set; }

        public int id_miembro_solicitante { get; set; }

        public int? id_miembro_responsable { get; set; }

        public int id_estado_solicitud { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Column(TypeName = "text")]
        public string descripcion_impacto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public DateTime? fecha_creacion { get; set; }

        public DateTime? fecha_aprobacion { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Solicitud_Cambio> Elemento_Solicitud_Cambio { get; set; }

        public virtual Estado_Solicitud Estado_Solicitud { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto1 { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
