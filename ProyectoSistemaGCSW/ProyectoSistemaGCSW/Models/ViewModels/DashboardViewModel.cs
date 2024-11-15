using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalProyectos { get; set; }
        public int ProyectosFinalizados { get; set; }
        public int ProyectosCancelados { get; set; }
        public int ProyectosPlanificados { get; set; }
        public int ProyectosPendientes { get; set; }
        public int ProyectosEnProgreso { get; set; }
        public int ProyectosEnEspera { get; set; }
        public int ProyectosCerrados { get; set; }

        public int TotalSolicitudes { get; set; }
        public int SolicitudesPendientes { get; set; }
        public int SolicitudesEnRevision { get; set; }
        public int SolicitudesAprobadas { get; set; }
        public int SolicitudesRechazadas { get; set; }
    }
}