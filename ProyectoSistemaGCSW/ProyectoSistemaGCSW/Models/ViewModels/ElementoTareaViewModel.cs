using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Models.ViewModels
{
    public class ElementoTareaViewModel
    {
        public int IdElementoTarea { get; set; }
        public string NombreElemento { get; set; }
        public string CodigoElemento { get; set; }
        public bool EsPrincipal { get; set; }

    }
}