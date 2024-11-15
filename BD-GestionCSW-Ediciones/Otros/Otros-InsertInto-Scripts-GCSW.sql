SELECT 
    ep.nombre AS Estado,
    COUNT(p.id_proyecto) AS TotalProyectos
FROM 
    Proyecto p
JOIN 
    Estado_Proyecto ep ON p.id_estado_proyecto = ep.id_estado_proyecto
GROUP BY 
    ep.nombre;


SELECT 
    u.nombre + ' ' + u.apellido AS Usuario,
    SUM(CASE WHEN et.nombre = 'To Do' THEN 1 ELSE 0 END) AS TotalTareasToDo,
    SUM(CASE WHEN et.nombre = 'In Progress' THEN 1 ELSE 0 END) AS TotalTareasInProgress,
    SUM(CASE WHEN et.nombre = 'Done' THEN 1 ELSE 0 END) AS TotalTareasDone
FROM 
    Usuario u
INNER JOIN 
    Miembro_Proyecto mp ON u.id_usuario = mp.id_usuario
INNER JOIN 
    Miembro_Tarea mt ON mp.id_miembro_proyecto = mt.id_miembro_proyecto
INNER JOIN 
    Tarea t ON mt.id_tarea = t.id_tarea
INNER JOIN 
    Estado_Tarea et ON t.id_estado_tarea = et.id_estado_tarea
GROUP BY 
    u.nombre, u.apellido;


	/*
	-- Asignar tareas al miembro del proyecto con id_miembro_proyecto = 1
INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 1, 'N'); -- Tarea 1: Definir alcance del proyecto

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 2, 'N'); -- Tarea 2: Analizar requerimientos del cliente

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 3, 'N'); -- Tarea 3: Diseñar arquitectura del sistema

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 4, 'N'); -- Tarea 4: Desarrollar módulo de autenticación

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 5, 'N'); -- Tarea 5: Configurar entorno de desarrollo

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 6, 'N'); -- Tarea 6: Desarrollar módulo de reportes

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 7, 'N'); -- Tarea 7: Realizar pruebas unitarias

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 8, 'N'); -- Tarea 8: Revisión de código

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 9, 'N'); -- Tarea 9: Implementar diseño de interfaz

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 10, 'N'); -- Tarea 10: Integración con base de datos

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 11, 'N'); -- Tarea 11: Implementar API para servicios externos

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 12, 'N'); -- Tarea 12: Documentación técnica

INSERT INTO Miembro_Tarea (id_miembro_proyecto, id_tarea, es_principal)
VALUES (1, 13, 'N'); -- Tarea 13: Desplegar sistema en entorno de producción
*/




SELECT 
    p.nombre AS Proyecto,
    pr.nombre AS Prioridad,
    COUNT(t.id_tarea) AS TotalTareas
FROM 
    Tarea t
INNER JOIN 
    Proyecto p ON t.id_proyecto = p.id_proyecto
INNER JOIN 
    Prioridad pr ON t.id_prioridad = pr.id_prioridad
GROUP BY 
    p.nombre, pr.nombre
ORDER BY 
    p.nombre, pr.nombre;












SELECT 
    es.nombre AS Estado,
    COUNT(sc.id_solicitud_cambio) AS TotalSolicitudes
FROM 
    Solicitud_Cambio sc
INNER JOIN 
    Estado_Solicitud es ON sc.id_estado_solicitud = es.id_estado_solicitud
GROUP BY 
    es.nombre;


	SELECT 
    p.nombre AS Proyecto,
    ec.nombre AS ElementoConfiguracion,
    ve.numero_version AS NumeroVersion,
    ve.descripcion AS DescripcionVersion,
    ve.fecha_creacion AS FechaCreacion
FROM 
    Version_Elemento ve
INNER JOIN 
    Elemento_Configuracion ec ON ve.id_elemento_configuracion = ec.id_elemento_configuracion
INNER JOIN 
    Proyecto p ON ec.id_proyecto = p.id_proyecto
ORDER BY 
    p.nombre, ec.nombre, ve.fecha_creacion;


/*
-- Insertar registros en la tabla Version_Elemento
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (1, 'Versión 1', 'Primera versión del informe de factibilidad');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (1, 'Versión 2', 'Revisión del informe de factibilidad');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (2, 'Versión 1', 'Primera versión del informe de visión del proyecto');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (3, 'Versión 1', 'Primera versión del informe SRS del proyecto');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (4, 'Versión 1', 'Primera versión del informe SAD del proyecto');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (5, 'Versión 1', 'Primera versión del informe de proyecto final');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (6, 'Versión 1', 'Primera versión de la propuesta del proyecto');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (7, 'Versión 1', 'Primera versión del estándar de programación');
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion)
VALUES (8, 'Versión 1', 'Primera versión del diccionario de datos');
*/


SELECT 
    CONVERT(varchar, ve.fecha_creacion, 103) AS Fecha,
    COUNT(ve.id_version) AS TotalVersiones
FROM 
    Version_Elemento ve
GROUP BY 
    CONVERT(varchar, ve.fecha_creacion, 103)
ORDER BY 
    Fecha;

/*
	INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (1, 'Versión 1', 'Primera versión', '2024-11-01'),
       (1, 'Versión 2', 'Segunda versión', '2024-11-03'),
       (1, 'Versión 3', 'Tercera versión', '2024-11-05'),
       (1, 'Versión 4', 'Cuarta versión', '2024-11-07'),
       (1, 'Versión 5', 'Quinta versión', '2024-11-10');
*/


/*

-- Elementos de configuración para el Proyecto 2
INSERT INTO Elemento_Configuracion (nombre, codigo_elemento, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('Backlog de Producto', 'SCRUM001', 'BP', 2, NULL, 'A', 'http://example.com/backlog');

INSERT INTO Elemento_Configuracion (nombre, codigo_elemento, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('Sprint Planificación', 'SCRUM002', 'SP', 2, NULL, 'A', 'http://example.com/sprint-planning');

-- Elementos de configuración para el Proyecto 3
INSERT INTO Elemento_Configuracion (nombre, codigo_elemento, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('Tablero Kanban', 'KANBAN001', 'TK', 3, NULL, 'A', 'http://example.com/kanban-board');

INSERT INTO Elemento_Configuracion (nombre, codigo_elemento, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('Reporte de Avances', 'KANBAN002', 'RA', 3, NULL, 'A', 'http://example.com/progress-report');




-- Versiones de elementos de configuración para el Proyecto 2
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (3, 'V1.0', 'Primera versión del backlog de producto', '2024-08-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (3, 'V1.1', 'Actualización de requerimientos en backlog', '2024-09-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (4, 'V1.0', 'Primera versión de la planificación de sprint', '2024-07-05');

-- Versiones de elementos de configuración para el Proyecto 3
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (5, 'V1.0', 'Configuración inicial del tablero Kanban', '2024-06-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (5, 'V1.1', 'Reestructuración de columnas en tablero Kanban', '2024-07-20');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (6, 'V1.0', 'Primera versión del reporte de avances', '2024-05-25');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (6, 'V1.2', 'Actualización con nuevos criterios de análisis', '2024-08-18');

/**/


-- Versiones de elementos de configuración para el Proyecto 1
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (1, 'V1.0', 'Primera versión del informe de factibilidad de proyecto', '2024-01-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (2, 'V1.1', 'Revisión del informe de visión del proyecto', '2024-02-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (3, 'V1.0', 'Primera versión del informe SRS del proyecto', '2024-03-05');

-- Versiones de elementos de configuración para el Proyecto 2
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.0', 'Primera versión del backlog de producto', '2024-08-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.1', 'Actualización de requerimientos en backlog', '2024-09-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.0', 'Primera versión de la planificación de sprint', '2024-07-05');

-- Versiones de elementos de configuración para el Proyecto 3
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.0', 'Primera versión del reporte de avances', '2024-05-25');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.2', 'Actualización con nuevos criterios de análisis', '2024-08-18');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.0', 'Configuración inicial del tablero Kanban', '2024-06-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.1', 'Reestructuración de columnas en tablero Kanban', '2024-07-20');













-- Backlog de Producto (Proyecto 2 - Scrum)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.0', 'Versión inicial del backlog', '2023-02-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.1', 'Agregado de historias de usuario', '2023-02-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.2', 'Modificación de prioridades en backlog', '2023-03-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V2.0', 'Revisión completa del backlog para nueva fase', '2024-01-20');

-- Sprint Planificación (Proyecto 2 - Scrum)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.0', 'Primera versión de planificación de sprint', '2023-02-05');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.1', 'Ajuste de tiempos en planificación', '2023-02-25');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V2.0', 'Planificación para siguiente iteración', '2023-06-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V3.0', 'Actualización de la planificación con feedback de sprint', '2024-05-15');










-- Tablero Kanban (Proyecto 3 - Kanban)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.0', 'Creación del tablero con columnas iniciales', '2023-01-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.1', 'Ajuste de columnas en tablero Kanban', '2023-02-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.2', 'Nueva columna para tareas bloqueadas', '2023-03-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V2.0', 'Revisión y simplificación de columnas', '2023-12-20');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V2.1', 'Añadido de etiquetas de prioridad en el tablero', '2024-05-25');

-- Reporte de Avances (Proyecto 3 - Kanban)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.0', 'Primer reporte de avances', '2023-02-20');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.1', 'Revisión de métricas de avance', '2023-03-30');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.2', 'Ajuste en las métricas de desempeño', '2023-06-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V2.0', 'Actualización con métricas de la nueva fase', '2024-07-10');







-- Backlog de Producto (Proyecto 2 - Scrum)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.0', 'Versión inicial del backlog', '2023-01-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.1', 'Modificaciones menores', '2023-01-11');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.2', 'Agregado de historias de usuario', '2023-01-13');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.3', 'Reorganización del backlog', '2023-01-14');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.4', 'Correcciones de prioridad', '2023-01-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.5', 'Actualización de backlog con feedback', '2023-01-20');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V1.6', 'Pequeñas modificaciones', '2023-02-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (10, 'V2.0', 'Revisión completa del backlog', '2023-02-10');

-- Sprint Planificación (Proyecto 2 - Scrum)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.0', 'Primera versión de planificación de sprint', '2023-01-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.1', 'Actualización de tiempos', '2023-01-11');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.2', 'Pequeños ajustes en planificación', '2023-01-12');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.3', 'Feedback aplicado', '2023-01-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V1.4', 'Actualización completa de sprint', '2023-02-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (11, 'V2.0', 'Revisión completa para nueva fase', '2023-02-15');





-- Tablero Kanban (Proyecto 3 - Kanban)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.0', 'Creación del tablero', '2023-01-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.1', 'Añadido de nuevas columnas', '2023-01-15');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.2', 'Optimización del flujo', '2023-01-20');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V1.3', 'Mejoras de visibilidad de tareas', '2023-01-25');

-- Intervalo sin actualizaciones
-- Reactivación en una fecha posterior

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V2.0', 'Revisión de columnas y tareas', '2023-07-10');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V2.1', 'Actualización con nuevas etiquetas', '2023-08-01');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (9, 'V2.2', 'Añadido de roles a las tareas', '2023-10-15');

-- Reporte de Avances (Proyecto 3 - Kanban)
INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.0', 'Primer reporte', '2023-02-20');

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V1.1', 'Modificación en métricas', '2023-03-10');

-- Intervalo sin actualizaciones

INSERT INTO Version_Elemento (id_elemento_configuracion, numero_version, descripcion, fecha_creacion)
VALUES (12, 'V2.0', 'Actualización con métricas nuevas', '2024-01-15');
*/


SELECT 
    p.nombre AS Proyecto,
    a.nombre_actividad AS Actividad,
    a.descripcion AS Descripcion,
    a.fecha_inicio AS FechaInicio,
    a.fecha_fin AS FechaFin,
    a.estado AS Estado,
    u.nombre + ' ' + u.apellido AS Miembro
FROM 
    Actividad a
INNER JOIN 
    Proyecto p ON a.id_proyecto = p.id_proyecto
INNER JOIN 
    Miembro_Proyecto mp ON a.id_miembro_proyecto = mp.id_miembro_proyecto
INNER JOIN 
    Usuario u ON mp.id_usuario = u.id_usuario
WHERE 
    p.id_proyecto = 1 -- Filtro opcional por proyecto
ORDER BY 
    a.fecha_inicio;





/*
-- Registros de ejemplo para la tabla Actividad

INSERT INTO Actividad (nombre_actividad, descripcion, fecha_inicio, fecha_fin, estado, id_proyecto, id_miembro_proyecto)
VALUES 
('Definición de Alcance', 'Reunión inicial para definir el alcance del proyecto', '2024-01-10', '2024-01-12', 'A', 1, 3),
('Análisis de Requerimientos', 'Recopilación y análisis de los requisitos del cliente', '2024-01-15', '2024-01-20', 'A', 1, 3),
('Diseño del Sistema', 'Creación de la arquitectura y diseño del sistema', '2024-01-22', '2024-02-05', 'A', 1, 4),
('Desarrollo de la Interfaz de Usuario', 'Implementación de la interfaz de usuario', '2024-02-10', '2024-02-25', 'A', 1, 4),
('Implementación del Backend', 'Desarrollo de la lógica de negocio y conexiones a la base de datos', '2024-03-01', '2024-03-15', 'A', 1, 3),
('Pruebas Unitarias', 'Ejecución de pruebas unitarias en los módulos desarrollados', '2024-03-20', '2024-03-25', 'A', 1, 3),
('Integración de Módulos', 'Integración y prueba de módulos en el sistema', '2024-03-28', '2024-04-05', 'A', 1, 4),
('Documentación', 'Creación de la documentación del proyecto', '2024-04-10', '2024-04-15', 'A', 1, 3),
('Despliegue en Producción', 'Implementación del sistema en el entorno de producción', '2024-04-20', '2024-04-25', 'A', 1, 4),
('Capacitación del Usuario Final', 'Capacitación para los usuarios finales del sistema', '2024-04-27', '2024-04-30', 'A', 1, 3);
*/








/*
-- Actividades en el proyecto 1, con diferentes períodos de alta y baja actividad
INSERT INTO Actividad (nombre_actividad, descripcion, fecha_inicio, fecha_fin, estado, id_proyecto, id_miembro_proyecto)
VALUES 
('Planificación inicial', 'Definir objetivos y alcance del proyecto', '2024-01-01', '2024-01-10', 'A', 1, 3),
('Análisis de requisitos', 'Revisión de requisitos con el cliente', '2024-01-05', '2024-01-15', 'A', 1, 4),
('Diseño de arquitectura', 'Definición de la arquitectura del sistema', '2024-01-20', '2024-01-30', 'A', 1, 3),

-- Periodo de alta actividad en febrero
('Implementación del módulo de autenticación', 'Desarrollo del módulo de autenticación de usuarios', '2024-02-01', '2024-02-10', 'A', 1, 3),
('Desarrollo de base de datos', 'Creación y configuración de la base de datos', '2024-02-02', '2024-02-12', 'A', 1, 4),
('Pruebas iniciales', 'Ejecutar pruebas de integración', '2024-02-05', '2024-02-15', 'A', 1, 3),
('Documentación técnica', 'Elaboración de la documentación técnica', '2024-02-10', '2024-02-20', 'A', 1, 4),

-- Baja actividad en marzo
('Capacitación de usuarios', 'Entrenamiento de usuarios finales', '2024-03-01', '2024-03-10', 'A', 1, 3),

-- Nuevo pico de actividades en abril
('Implementación del módulo de reportes', 'Desarrollo del módulo de reportes para análisis', '2024-04-01', '2024-04-10', 'A', 1, 4),
('Pruebas de aceptación', 'Pruebas finales con el cliente', '2024-04-05', '2024-04-15', 'A', 1, 3),
('Optimización de rendimiento', 'Mejoras de rendimiento y optimización', '2024-04-10', '2024-04-20', 'A', 1, 4),
('Configuración de seguridad', 'Implementación de medidas de seguridad', '2024-04-15', '2024-04-25', 'A', 1, 3),

-- Baja actividad en mayo y luego cierre de proyecto en junio
('Revisión final del proyecto', 'Evaluación y revisión del proyecto final', '2024-05-01', '2024-05-10', 'A', 1, 4),
('Entrega del proyecto', 'Entrega oficial del proyecto al cliente', '2024-06-01', '2024-06-05', 'A', 1, 3);


-- Actividades adicionales para el proyecto 2, con un patrón similar
INSERT INTO Actividad (nombre_actividad, descripcion, fecha_inicio, fecha_fin, estado, id_proyecto, id_miembro_proyecto)
VALUES
('Inicio de planificación', 'Revisión de objetivos de Scrum', '2024-01-02', '2024-01-09', 'A', 2, 3),
('Sprint 1 - Desarrollo', 'Primer sprint del proyecto Scrum', '2024-01-10', '2024-01-20', 'A', 2, 4),
('Sprint 1 - Revisión', 'Revisión del primer sprint', '2024-01-21', '2024-01-25', 'A', 2, 3),

-- Alta actividad en marzo con múltiples sprints
('Sprint 2 - Desarrollo', 'Desarrollo del segundo sprint', '2024-03-01', '2024-03-10', 'A', 2, 4),
('Sprint 2 - Revisión', 'Revisión del segundo sprint', '2024-03-11', '2024-03-15', 'A', 2, 3),
('Sprint 3 - Desarrollo', 'Desarrollo del tercer sprint', '2024-03-20', '2024-03-30', 'A', 2, 4),

-- Baja actividad en abril y luego finalización en mayo
('Sprint final - Ajustes', 'Ajustes y optimización finales', '2024-04-10', '2024-04-20', 'A', 2, 3),
('Entrega final de Scrum', 'Cierre del proyecto Scrum', '2024-05-01', '2024-05-05', 'A', 2, 4);

-- Actividades para el proyecto 3 con actividades espaciadas
INSERT INTO Actividad (nombre_actividad, descripcion, fecha_inicio, fecha_fin, estado, id_proyecto, id_miembro_proyecto)
VALUES
('Inicio de configuración de Kanban', 'Organización inicial del tablero Kanban', '2024-01-15', '2024-01-18', 'A', 3, 3),
('Análisis de flujo de trabajo', 'Definir flujo de trabajo en Kanban', '2024-01-25', '2024-01-30', 'A', 3, 4),

-- Actividades en febrero con baja frecuencia
('Revisión de tareas en Kanban', 'Evaluación semanal de progreso', '2024-02-10', '2024-02-12', 'A', 3, 3),
('Actualización de tareas', 'Actualizar estado de las tareas en el tablero', '2024-02-20', '2024-02-22', 'A', 3, 4),

-- Alta actividad en marzo
('Implementación de nuevas tareas', 'Agregar nuevas tareas al tablero Kanban', '2024-03-01', '2024-03-05', 'A', 3, 3),
('Monitoreo de progreso', 'Revisión constante del progreso de tareas', '2024-03-06', '2024-03-10', 'A', 3, 4),
('Optimización del tablero', 'Mejoras en la estructura del tablero Kanban', '2024-03-15', '2024-03-20', 'A', 3, 3),

-- Baja actividad en abril y luego cierre en junio
('Cierre de proyecto Kanban', 'Finalización y archivo del tablero', '2024-06-01', '2024-06-05', 'A', 3, 4);

*/

/*
-- Actividades para el proyecto Scrum (Proyecto 2) distribuidas en diferentes semanas
INSERT INTO Actividad (nombre_actividad, descripcion, fecha_inicio, fecha_fin, estado, id_proyecto, id_miembro_proyecto)
VALUES 
('Sprint 1 - Planificación', 'Planificación inicial del primer sprint', '2024-01-01', '2024-01-03', 'A', 2, 3),
('Sprint 1 - Desarrollo', 'Desarrollo de funcionalidades para el primer sprint', '2024-01-04', '2024-01-10', 'A', 2, 4),
('Sprint 1 - Revisión', 'Revisión de resultados del primer sprint', '2024-01-11', '2024-01-12', 'A', 2, 3),

('Sprint 2 - Planificación', 'Planificación inicial del segundo sprint', '2024-01-15', '2024-01-16', 'A', 2, 4),
('Sprint 2 - Desarrollo', 'Desarrollo de funcionalidades para el segundo sprint', '2024-01-17', '2024-01-24', 'A', 2, 3),
('Sprint 2 - Revisión', 'Revisión de resultados del segundo sprint', '2024-01-25', '2024-01-26', 'A', 2, 4),

('Sprint 3 - Planificación', 'Planificación del tercer sprint', '2024-02-01', '2024-02-02', 'A', 2, 3),
('Sprint 3 - Desarrollo', 'Desarrollo de funcionalidades del tercer sprint', '2024-02-03', '2024-02-10', 'A', 2, 4),
('Sprint 3 - Revisión', 'Revisión de resultados del tercer sprint', '2024-02-11', '2024-02-12', 'A', 2, 3),

-- Alta actividad en marzo
('Sprint 4 - Planificación', 'Planificación del cuarto sprint', '2024-03-01', '2024-03-02', 'A', 2, 4),
('Sprint 4 - Desarrollo', 'Desarrollo del cuarto sprint', '2024-03-03', '2024-03-10', 'A', 2, 3),
('Sprint 4 - Revisión', 'Revisión de resultados del cuarto sprint', '2024-03-11', '2024-03-12', 'A', 2, 4),

-- Finalización de proyecto en abril
('Sprint Final - Planificación', 'Planificación del sprint final', '2024-04-01', '2024-04-02', 'A', 2, 3),
('Sprint Final - Desarrollo', 'Desarrollo del sprint final', '2024-04-03', '2024-04-10', 'A', 2, 4),
('Entrega Final de Scrum', 'Cierre y entrega del proyecto', '2024-04-11', '2024-04-15', 'A', 2, 3);


*/

/*
-- Actividades para el proyecto Kanban (Proyecto 3)
INSERT INTO Actividad (nombre_actividad, descripcion, fecha_inicio, fecha_fin, estado, id_proyecto, id_miembro_proyecto)
VALUES
('Inicio de Tablero Kanban', 'Configuración inicial del tablero Kanban', '2024-01-05', '2024-01-07', 'A', 3, 3),
('Definición de Tareas', 'Definir tareas en el tablero Kanban', '2024-01-10', '2024-01-12', 'A', 3, 4),

-- Alta actividad en febrero
('Monitoreo Semanal', 'Monitoreo semanal de tareas', '2024-02-01', '2024-02-03', 'A', 3, 3),
('Actualización de Estado', 'Actualizar estado de tareas', '2024-02-05', '2024-02-07', 'A', 3, 4),
('Optimización de Flujo', 'Optimización del flujo de trabajo en Kanban', '2024-02-10', '2024-02-12', 'A', 3, 3),

-- Periodo de inactividad en marzo y abril
('Revisión de Tareas', 'Revisión de tareas pendientes', '2024-04-01', '2024-04-05', 'A', 3, 4),

-- Nuevo pico de actividad en mayo
('Implementación de Nuevas Tareas', 'Agregado de nuevas tareas', '2024-05-10', '2024-05-15', 'A', 3, 3),
('Seguimiento de Tareas', 'Seguimiento semanal de nuevas tareas', '2024-05-20', '2024-05-25', 'A', 3, 4),
('Ajustes Finales en Kanban', 'Ajustes y cierre de tablero', '2024-06-01', '2024-06-05', 'A', 3, 3);
*/