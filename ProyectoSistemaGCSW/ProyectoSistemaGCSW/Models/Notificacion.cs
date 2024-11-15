namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notificacion")]
    public partial class Notificacion
    {
        [Key]
        public int id_notificacion { get; set; }

        public int id_usuario { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string mensaje { get; set; }

        public DateTime? fecha_envio { get; set; }

        [StringLength(1)]
        public string leido { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
