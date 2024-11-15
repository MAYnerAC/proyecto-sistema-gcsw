namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Actividad")]
    public partial class Actividad
    {
        [Key]
        public int id_actividad { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre_actividad { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_proyecto { get; set; }

        public int id_miembro_proyecto { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
