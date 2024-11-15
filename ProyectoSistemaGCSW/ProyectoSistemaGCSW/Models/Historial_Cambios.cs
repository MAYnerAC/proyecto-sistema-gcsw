namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Historial_Cambios
    {
        [Key]
        public int id_historial { get; set; }

        [Required]
        [StringLength(50)]
        public string tabla { get; set; }

        public int id_registro { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_cambio { get; set; }

        [Column(TypeName = "text")]
        public string valor_anterior { get; set; }

        [Column(TypeName = "text")]
        public string valor_nuevo { get; set; }

        public DateTime? fecha_cambio { get; set; }

        public int id_usuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
