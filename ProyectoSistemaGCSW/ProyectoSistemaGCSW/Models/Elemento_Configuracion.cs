namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elemento_Configuracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento_Configuracion()
        {
            Elemento_Solicitud_Cambio = new HashSet<Elemento_Solicitud_Cambio>();
            Elemento_Tarea = new HashSet<Elemento_Tarea>();
            Version_Elemento = new HashSet<Version_Elemento>();
        }

        [Key]
        public int id_elemento_configuracion { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string codigo_elemento { get; set; }

        [StringLength(50)]
        public string nomenclatura { get; set; }

        public int id_proyecto { get; set; }

        public int? id_fase { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(255)]
        public string url_recurso_asociado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Solicitud_Cambio> Elemento_Solicitud_Cambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Tarea> Elemento_Tarea { get; set; }

        public virtual Fase Fase { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Version_Elemento> Version_Elemento { get; set; }
    }
}
