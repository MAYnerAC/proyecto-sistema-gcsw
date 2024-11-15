namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Miembro_Tarea
    {
        [Key]
        public int id_miembro_tarea { get; set; }

        public int id_miembro_proyecto { get; set; }

        public int id_tarea { get; set; }

        [StringLength(1)]
        public string es_principal { get; set; }

        public DateTime? fecha_asignacion { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        public virtual Tarea Tarea { get; set; }
    }
}
