namespace ProyectoSistemaGCSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Version_Elemento
    {
        [Key]
        public int id_version { get; set; }

        public int id_elemento_configuracion { get; set; }

        [Required]
        [StringLength(50)]
        public string numero_version { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public DateTime? fecha_creacion { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }
    }
}
