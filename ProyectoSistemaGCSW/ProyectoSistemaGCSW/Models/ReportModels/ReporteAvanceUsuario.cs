using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Models.ReportModels
{
    public class ReporteAvanceUsuario
    {
        public string Proyecto { get; set; }
        public string Usuario { get; set; }
        public int TotalTareasToDo { get; set; }
        public int TotalTareasInProgress { get; set; }
        public int TotalTareasDone { get; set; }
    }
}