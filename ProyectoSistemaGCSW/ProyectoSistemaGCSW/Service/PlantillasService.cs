using ProyectoSistemaGCSW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaGCSW.Service
{
    public class PlantillasService
    {

        public static List<Elemento_Configuracion> ObtenerECSRUP(int idProyecto)
        {
            // Definir los IDs fijos de las fases asociadas a RUP
            int idFaseInicio = 1; // Inicio
            int idFaseElaboracion = 2; // Elaboración
            int idFaseConstruccion = 3; // Construcción
            int idFaseTransicion = 4; // Transición

            // Retornar los elementos de configuración específicos para RUP
            return new List<Elemento_Configuracion>
            {
                // Fase de Inicio
                new Elemento_Configuracion { codigo_elemento = "DOC001", nombre = "Informe de Factibilidad de Proyecto", nomenclatura = "FD01", id_proyecto = idProyecto, id_fase = idFaseInicio, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "DOC006", nombre = "Propuesta del Proyecto", nomenclatura = "FD06", id_proyecto = idProyecto, id_fase = idFaseInicio, estado = "A", url_recurso_asociado = null },

                // Fase de Elaboración
                new Elemento_Configuracion { codigo_elemento = "DOC002", nombre = "Informe Visión del Proyecto", nomenclatura = "FD02", id_proyecto = idProyecto, id_fase = idFaseElaboracion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "PROTO001", nombre = "Prototipos de Interfaz de Usuario", nomenclatura = "PIU", id_proyecto = idProyecto, id_fase = idFaseElaboracion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "STD001", nombre = "Estándar de Programación", nomenclatura = "STD", id_proyecto = idProyecto, id_fase = idFaseElaboracion, estado = "A", url_recurso_asociado = null },

                // Fase de Construcción
                new Elemento_Configuracion { codigo_elemento = "DOC003", nombre = "Informe SRS del Proyecto", nomenclatura = "FD03", id_proyecto = idProyecto, id_fase = idFaseConstruccion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "DOC004", nombre = "Informe SAD del Proyecto", nomenclatura = "FD04", id_proyecto = idProyecto, id_fase = idFaseConstruccion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "PLAN001", nombre = "Plan de Pruebas", nomenclatura = "PP", id_proyecto = idProyecto, id_fase = idFaseConstruccion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "CASE001", nombre = "Casos de Prueba", nomenclatura = "CP", id_proyecto = idProyecto, id_fase = idFaseConstruccion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "CAT001", nombre = "Catálogo de Pruebas", nomenclatura = "CATP", id_proyecto = idProyecto, id_fase = idFaseConstruccion, estado = "A", url_recurso_asociado = null },

                // Fase de Transición
                new Elemento_Configuracion { codigo_elemento = "DOC005", nombre = "Informe Proyecto Final", nomenclatura = "FD05", id_proyecto = idProyecto, id_fase = idFaseTransicion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "MAN001", nombre = "Manuales de Usuario", nomenclatura = "MU", id_proyecto = idProyecto, id_fase = idFaseTransicion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "DOC0010", nombre = "Documentación Técnica", nomenclatura = "DT", id_proyecto = idProyecto, id_fase = idFaseTransicion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "INF001", nombre = "Informes de Pruebas", nomenclatura = "IP", id_proyecto = idProyecto, id_fase = idFaseTransicion, estado = "A", url_recurso_asociado = null }
            };
        }

        // Métodos similares pueden ser implementados para otras metodologías
        public static List<Elemento_Configuracion> ObtenerECSScrum(int idProyecto)
        {
            // Definir los IDs fijos de las fases asociadas a Scrum
            int idFasePlanificacion = 5; // Planificación del Sprint
            int idFaseEjecucion = 6;    // Ejecución del Sprint
            int idFaseRevision = 7;     // Revisión del Sprint
            int idFaseRetrospectiva = 8; // Retrospectiva del Sprint

            // Retornar los elementos de configuración específicos para Scrum
            return new List<Elemento_Configuracion>
            {
                // Fase de Planificación del Sprint
                new Elemento_Configuracion { codigo_elemento = "SPR001", nombre = "Backlog del Producto", nomenclatura = "BPROD", id_proyecto = idProyecto, id_fase = idFasePlanificacion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR002", nombre = "Backlog del Sprint", nomenclatura = "BSPR", id_proyecto = idProyecto, id_fase = idFasePlanificacion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR003", nombre = "Plan de Sprint", nomenclatura = "PSPR", id_proyecto = idProyecto, id_fase = idFasePlanificacion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR004", nombre = "Historias de Usuario", nomenclatura = "HUSER", id_proyecto = idProyecto, id_fase = idFasePlanificacion, estado = "A", url_recurso_asociado = null },

                // Fase de Ejecución del Sprint
                new Elemento_Configuracion { codigo_elemento = "SPR005", nombre = "Tablero Kanban del Sprint", nomenclatura = "TKSPR", id_proyecto = idProyecto, id_fase = idFaseEjecucion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR006", nombre = "Tareas del Sprint", nomenclatura = "TSPR", id_proyecto = idProyecto, id_fase = idFaseEjecucion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR007", nombre = "Registro de Tiempo del Sprint", nomenclatura = "RTSPR", id_proyecto = idProyecto, id_fase = idFaseEjecucion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR008", nombre = "Registro de Obstáculos", nomenclatura = "OBSPR", id_proyecto = idProyecto, id_fase = idFaseEjecucion, estado = "A", url_recurso_asociado = null },

                // Fase de Revisión del Sprint
                new Elemento_Configuracion { codigo_elemento = "SPR009", nombre = "Informe de Revisión del Sprint", nomenclatura = "IRSPR", id_proyecto = idProyecto, id_fase = idFaseRevision, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR010", nombre = "Resultados del Sprint", nomenclatura = "RSPR", id_proyecto = idProyecto, id_fase = idFaseRevision, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR011", nombre = "Retroalimentación del Producto", nomenclatura = "FBPROD", id_proyecto = idProyecto, id_fase = idFaseRevision, estado = "A", url_recurso_asociado = null },

                // Fase de Retrospectiva del Sprint
                new Elemento_Configuracion { codigo_elemento = "SPR012", nombre = "Informe de Retrospectiva", nomenclatura = "IRSPR", id_proyecto = idProyecto, id_fase = idFaseRetrospectiva, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR013", nombre = "Acciones de Mejora", nomenclatura = "AMSPR", id_proyecto = idProyecto, id_fase = idFaseRetrospectiva, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "SPR014", nombre = "Resumen de la Retrospectiva", nomenclatura = "RSPR", id_proyecto = idProyecto, id_fase = idFaseRetrospectiva, estado = "A", url_recurso_asociado = null }
            };
        }



        public static List<Elemento_Configuracion> ObtenerECSKanban(int idProyecto)
        {
            // Definir los IDs fijos de las fases asociadas a Kanban
            int idFasePorHacer = 9;      // Por Hacer
            int idFaseEnProgreso = 10;   // En Progreso
            int idFaseEnRevision = 11;   // En Revisión
            int idFaseHecho = 12;        // Hecho

            // Retornar los elementos de configuración específicos para Kanban
            return new List<Elemento_Configuracion>
            {
                // Fase de Por Hacer
                new Elemento_Configuracion { codigo_elemento = "KAN001", nombre = "Listado de Tareas Pendientes", nomenclatura = "TPEND", id_proyecto = idProyecto, id_fase = idFasePorHacer, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "KAN002", nombre = "Backlog de Tareas", nomenclatura = "BKTASK", id_proyecto = idProyecto, id_fase = idFasePorHacer, estado = "A", url_recurso_asociado = null },

                // Fase de En Progreso
                new Elemento_Configuracion { codigo_elemento = "KAN003", nombre = "Tareas en Ejecución", nomenclatura = "TEXEC", id_proyecto = idProyecto, id_fase = idFaseEnProgreso, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "KAN004", nombre = "Registro de Obstáculos", nomenclatura = "OBKAN", id_proyecto = idProyecto, id_fase = idFaseEnProgreso, estado = "A", url_recurso_asociado = null },

                // Fase de En Revisión
                new Elemento_Configuracion { codigo_elemento = "KAN005", nombre = "Checklist de Revisión", nomenclatura = "CHKREV", id_proyecto = idProyecto, id_fase = idFaseEnRevision, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "KAN006", nombre = "Informe de Validación", nomenclatura = "INVAL", id_proyecto = idProyecto, id_fase = idFaseEnRevision, estado = "A", url_recurso_asociado = null },

                // Fase de Hecho
                new Elemento_Configuracion { codigo_elemento = "KAN007", nombre = "Listado de Tareas Completadas", nomenclatura = "TCOMP", id_proyecto = idProyecto, id_fase = idFaseHecho, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "KAN008", nombre = "Informe de Entregables", nomenclatura = "INFENT", id_proyecto = idProyecto, id_fase = idFaseHecho, estado = "A", url_recurso_asociado = null }
            };
        }


        public static List<Elemento_Configuracion> ObtenerECSWaterfall(int idProyecto)
        {
            // Definir los IDs fijos de las fases asociadas a Waterfall
            int idFaseRequerimientos = 13; // Requerimientos
            int idFaseDiseno = 14;         // Diseño
            int idFaseImplementacion = 15; // Implementación
            int idFaseVerificacion = 16;   // Verificación
            int idFaseMantenimiento = 17;  // Mantenimiento

            // Retornar los elementos de configuración específicos para Waterfall
            return new List<Elemento_Configuracion>
            {
                // Fase de Requerimientos
                new Elemento_Configuracion { codigo_elemento = "WAT001", nombre = "Especificación de Requerimientos", nomenclatura = "REQSPC", id_proyecto = idProyecto, id_fase = idFaseRequerimientos, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT002", nombre = "Diagrama de Casos de Uso", nomenclatura = "UCD", id_proyecto = idProyecto, id_fase = idFaseRequerimientos, estado = "A", url_recurso_asociado = null },

                // Fase de Diseño
                new Elemento_Configuracion { codigo_elemento = "WAT003", nombre = "Diseño Arquitectónico", nomenclatura = "ARCHD", id_proyecto = idProyecto, id_fase = idFaseDiseno, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT004", nombre = "Diagrama de Clases", nomenclatura = "CLSD", id_proyecto = idProyecto, id_fase = idFaseDiseno, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT005", nombre = "Diagrama de Secuencia", nomenclatura = "SEQD", id_proyecto = idProyecto, id_fase = idFaseDiseno, estado = "A", url_recurso_asociado = null },

                // Fase de Implementación
                new Elemento_Configuracion { codigo_elemento = "WAT006", nombre = "Código Fuente", nomenclatura = "CODE", id_proyecto = idProyecto, id_fase = idFaseImplementacion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT007", nombre = "Registro de Cambios", nomenclatura = "CHLOG", id_proyecto = idProyecto, id_fase = idFaseImplementacion, estado = "A", url_recurso_asociado = null },

                // Fase de Verificación
                new Elemento_Configuracion { codigo_elemento = "WAT008", nombre = "Plan de Pruebas", nomenclatura = "TESTPLAN", id_proyecto = idProyecto, id_fase = idFaseVerificacion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT009", nombre = "Resultados de Pruebas", nomenclatura = "TRESULT", id_proyecto = idProyecto, id_fase = idFaseVerificacion, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT010", nombre = "Informe de Validación", nomenclatura = "VALREP", id_proyecto = idProyecto, id_fase = idFaseVerificacion, estado = "A", url_recurso_asociado = null },

                // Fase de Mantenimiento
                new Elemento_Configuracion { codigo_elemento = "WAT011", nombre = "Plan de Soporte", nomenclatura = "SUPPLAN", id_proyecto = idProyecto, id_fase = idFaseMantenimiento, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT012", nombre = "Registro de Incidentes", nomenclatura = "INCLOG", id_proyecto = idProyecto, id_fase = idFaseMantenimiento, estado = "A", url_recurso_asociado = null },
                new Elemento_Configuracion { codigo_elemento = "WAT013", nombre = "Informe de Mantenimiento", nomenclatura = "MAINREP", id_proyecto = idProyecto, id_fase = idFaseMantenimiento, estado = "A", url_recurso_asociado = null }
            };
        }



        //

    }
}