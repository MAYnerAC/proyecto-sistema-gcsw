﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using ProyectoSistemaGCSW.Models;
using ProyectoSistemaGCSW.Models.ViewModels;

namespace ProyectoSistemaGCSW.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        private ModeloSistema db = new ModeloSistema();

        // GET: Admin/Panel
        public ActionResult Index()
        {
            var proyectosPorEstado = db.Proyecto
                .GroupBy(p => p.Estado_Proyecto.nombre)
                .Select(g => new
                {
                    Estado = g.Key,
                    Total = g.Count()
                })
                .ToList();

            var solicitudesPorEstado = db.Solicitud_Cambio
                .GroupBy(s => s.Estado_Solicitud.nombre)
                .Select(g => new
                {
                    Estado = g.Key,
                    Total = g.Count()
                })
                .ToList();

            var dashboardModel = new DashboardViewModel
            {
                TotalProyectos = proyectosPorEstado.Sum(p => p.Total),
                ProyectosPlanificados = proyectosPorEstado.FirstOrDefault(p => p.Estado == "Planificado")?.Total ?? 0,
                ProyectosPendientes = proyectosPorEstado.FirstOrDefault(p => p.Estado == "Pendiente")?.Total ?? 0,
                ProyectosEnProgreso = proyectosPorEstado.FirstOrDefault(p => p.Estado == "En progreso")?.Total ?? 0,
                ProyectosEnEspera = proyectosPorEstado.FirstOrDefault(p => p.Estado == "En espera")?.Total ?? 0,
                ProyectosFinalizados = proyectosPorEstado.FirstOrDefault(p => p.Estado == "Completado")?.Total ?? 0,
                ProyectosCancelados = proyectosPorEstado.FirstOrDefault(p => p.Estado == "Cancelado")?.Total ?? 0,
                ProyectosCerrados = proyectosPorEstado.FirstOrDefault(p => p.Estado == "Cerrado")?.Total ?? 0,
                TotalSolicitudes = solicitudesPorEstado.Sum(s => s.Total),
                SolicitudesPendientes = solicitudesPorEstado.FirstOrDefault(s => s.Estado == "Pendiente")?.Total ?? 0,
                SolicitudesEnRevision = solicitudesPorEstado.FirstOrDefault(s => s.Estado == "En revision")?.Total ?? 0,
                SolicitudesAprobadas = solicitudesPorEstado.FirstOrDefault(s => s.Estado == "Aprobado")?.Total ?? 0,
                SolicitudesRechazadas = solicitudesPorEstado.FirstOrDefault(s => s.Estado == "Rechazado")?.Total ?? 0
            };

            return View(dashboardModel);
        }



        //

    }
}