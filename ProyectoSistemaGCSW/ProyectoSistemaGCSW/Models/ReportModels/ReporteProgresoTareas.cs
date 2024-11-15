using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Models.ReportModels
{
    public class ReporteProgresoTareas
    {
        public string Estado { get; set; }
        public List<TareaInfo> Tareas { get; set; }
    }

    public class TareaInfo
    {
        public string NombreTarea { get; set; }
        public string Prioridad { get; set; }
        public int IdTarea { get; set; }
    }
}