namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Elemento_Solicitud_Cambio
    {
        [Key]
        public int id_elemento_solicitud_cambio { get; set; }

        public int id_solicitud_cambio { get; set; }

        public int id_elemento_configuracion { get; set; }

        [StringLength(1)]
        public string es_principal { get; set; }

        public DateTime? fecha_asignacion { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Solicitud_Cambio Solicitud_Cambio { get; set; }
    }
}
