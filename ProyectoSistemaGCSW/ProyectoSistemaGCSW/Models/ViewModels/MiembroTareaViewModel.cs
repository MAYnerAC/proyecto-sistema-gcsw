using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Models.ViewModels
{
    public class MiembroTareaViewModel
    {
        public int IdMiembroTarea { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool EsPrincipal { get; set; }
    }
}