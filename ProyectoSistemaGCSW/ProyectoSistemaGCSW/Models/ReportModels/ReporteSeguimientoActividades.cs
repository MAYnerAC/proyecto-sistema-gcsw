using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Models.ReportModels
{
    public class ReporteSeguimientoActividades
    {
        public string Proyecto { get; set; }
        public string Actividad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string Miembro { get; set; }
    }
}