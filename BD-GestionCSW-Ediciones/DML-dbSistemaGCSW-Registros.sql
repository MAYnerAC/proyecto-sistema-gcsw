
-- Tablas Independientes (sin dependencias):

INSERT INTO Metodologia (nombre, estado) VALUES ('RUP', 'A');
INSERT INTO Metodologia (nombre, estado) VALUES ('Scrum', 'A');
INSERT INTO Metodologia (nombre, estado) VALUES ('Kanban', 'A');
INSERT INTO Metodologia (nombre, estado) VALUES ('Waterfall', 'A');

INSERT INTO Estado_Proyecto (nombre) VALUES ('Planificado');
INSERT INTO Estado_Proyecto (nombre) VALUES ('Pendiente');
INSERT INTO Estado_Proyecto (nombre) VALUES ('En progreso');
INSERT INTO Estado_Proyecto (nombre) VALUES ('En espera');
INSERT INTO Estado_Proyecto (nombre) VALUES ('Completado');
INSERT INTO Estado_Proyecto (nombre) VALUES ('Cancelado');
INSERT INTO Estado_Proyecto (nombre) VALUES ('Cerrado');

INSERT INTO Estado_Solicitud (nombre) VALUES ('Pendiente');
INSERT INTO Estado_Solicitud (nombre) VALUES ('En revision');
INSERT INTO Estado_Solicitud (nombre) VALUES ('Aprobado');
INSERT INTO Estado_Solicitud (nombre) VALUES ('Rechazado');

INSERT INTO Estado_Tarea (nombre) VALUES ('To Do');
INSERT INTO Estado_Tarea (nombre) VALUES ('In Progress');
INSERT INTO Estado_Tarea (nombre) VALUES ('Done');

INSERT INTO Prioridad (nombre) VALUES ('Critica');
INSERT INTO Prioridad (nombre) VALUES ('Urgente');
INSERT INTO Prioridad (nombre) VALUES ('Alta');
INSERT INTO Prioridad (nombre) VALUES ('Media');
INSERT INTO Prioridad (nombre) VALUES ('Baja');
INSERT INTO Prioridad (nombre) VALUES ('Opcional');


INSERT INTO Rol (nombre, estado) VALUES ('Gerente de Proyecto', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Analista de Negocios', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Dise�ador de Software', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Arquitecto de Software', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Desarrollador', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Tester', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Administrador de Configuraci�n', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('L�der T�cnico', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Product Owner', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Scrum Master', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Desarrollador Back-End', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Desarrollador Front-End', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('UX/UI Designer', 'A');
INSERT INTO Rol (nombre, estado) VALUES ('Ingeniero de DevOps', 'A');


INSERT INTO Tipo_Usuario (nombre, estado) VALUES ('Administrador', 'A');
INSERT INTO Tipo_Usuario (nombre, estado) VALUES ('Supervisor', 'A');
INSERT INTO Tipo_Usuario (nombre, estado) VALUES ('Usuario', 'A');



-- Tablas con Dependencias Moderadas (dependen de las anteriores):

INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Admin', 'Istrador', 'admin@example.com', '123456', 'A', 1);
INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Sup', 'Ervisor', 'sup@example.com', '123456', 'A', 2);
INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Usua', 'Rio', 'user@example.com', '123456', 'A', 3);

INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Carlos', 'Gomez', 'cgomez@example.com', '123456', 'A', 3);
INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Pedro', 'Hernandez', 'phernandez@example.com', '123456', 'A', 3);
INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Carmen', 'Fernandez', 'cfernandez@example.com', '123456', 'A', 3);
INSERT INTO Usuario (nombre, apellido, correo, contrasena, estado, id_tipo_usuario)
VALUES ('Jose', 'Sanchez', 'jsanchez@example.com', '123456', 'A', 3);



INSERT INTO Proyecto (codigo_proyecto, nombre, descripcion, fecha_inicio, fecha_fin, estado, id_metodologia, id_estado_proyecto, id_usuario_creador, url_repositorio)
VALUES ('PROJ001', 'Implementaci�n de RUP', 'Proyecto para aplicar la metodolog�a RUP en la organizaci�n', '2024-01-01', '2024-06-01', 'A', 1, 1, 3, 'https://github.com/empresa/rup-project');
INSERT INTO Proyecto (codigo_proyecto, nombre, descripcion, fecha_inicio, fecha_fin, estado, id_metodologia, id_estado_proyecto, id_usuario_creador, url_repositorio)
VALUES ('PROJ002', 'Desarrollo �gil con Scrum', 'Proyecto piloto para implementar Scrum en el equipo de desarrollo', '2024-02-01', '2024-07-01', 'A', 2, 3, 3, 'https://github.com/empresa/scrum-project');
INSERT INTO Proyecto (codigo_proyecto, nombre, descripcion, fecha_inicio, fecha_fin, estado, id_metodologia, id_estado_proyecto, id_usuario_creador, url_repositorio)
VALUES ('PROJ003', 'Gesti�n de tareas con Kanban', 'Proyecto de mejora continua usando la metodolog�a Kanban', '2024-03-01', '2024-08-01', 'A', 3, 4, 3, 'https://github.com/empresa/kanban-project');



INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Inicio', 1, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Elaboraci�n', 1, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Construcci�n', 1, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Transici�n', 1, 'A');

INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Planificaci�n del Sprint', 2, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Ejecuci�n del Sprint', 2, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Revisi�n del Sprint', 2, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Retrospectiva del Sprint', 2, 'A');

INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Por Hacer', 3, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('En Progreso', 3, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('En Revisi�n', 3, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Hecho', 3, 'A');

INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Requerimientos', 4, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Dise�o', 4, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Implementaci�n', 4, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Verificaci�n', 4, 'A');
INSERT INTO Fase (nombre, id_metodologia, estado) VALUES ('Mantenimiento', 4, 'A');


-- Tablas con Dependencias Altas (dependen de las anteriores):

INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DOC001', 'Informe de Factibilidad de Proyecto', 'FD01-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/FD01-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DOC002', 'Informe Visi�n del Proyecto', 'FD02-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/FD02-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DOC003', 'Informe SRS del Proyecto', 'FD03-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/FD03-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DOC004', 'Informe SAD del Proyecto', 'FD04-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/FD04-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DOC005', 'Informe Proyecto Final', 'FD05-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/FD05-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DOC006', 'Propuesta del Proyecto', 'FD06-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/FD06-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('STD001', 'Est�ndar de Programaci�n', 'STD-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/STD-EPIS');
INSERT INTO Elemento_Configuracion (codigo_elemento, nombre, nomenclatura, id_proyecto, id_fase, estado, url_recurso_asociado)
VALUES ('DD001', 'Diccionario de Datos', 'DD-EPIS', 1, NULL, 'A', 'https://ruta.del.proyecto/DD-EPIS');



INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (1, 1, 1, 1);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (2, 1, 2, 2);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (3, 1, 5, 3);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (4, 1, 4, 2);

INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (5, 2, 9, 1);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (6, 2, 10, 2);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (7, 2, 6, 3);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (3, 2, 13, 3);

INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (1, 3, 7, 1);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (4, 3, 3, 2);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (5, 3, 12, 3);
INSERT INTO Miembro_Proyecto (id_usuario, id_proyecto, id_rol, nivel) VALUES (7, 3, 8, 3);



INSERT INTO Solicitud_Cambio (id_proyecto, id_miembro_solicitante, id_miembro_responsable, id_estado_solicitud, descripcion, descripcion_impacto, fecha_aprobacion, fecha_inicio, fecha_fin)
VALUES (1, 1, 2, 1, 'Cambio en los requisitos iniciales', 'Impacto en el alcance del proyecto', NULL, NULL, NULL);

INSERT INTO Solicitud_Cambio (id_proyecto, id_miembro_solicitante, id_miembro_responsable, id_estado_solicitud, descripcion, descripcion_impacto, fecha_aprobacion, fecha_inicio, fecha_fin)
VALUES (1, 3, 4, 2, 'Actualizaci�n de las especificaciones', 'Afecta los recursos asignados', '2024-02-15', NULL, NULL);

INSERT INTO Solicitud_Cambio (id_proyecto, id_miembro_solicitante, id_miembro_responsable, id_estado_solicitud, descripcion, descripcion_impacto, fecha_aprobacion, fecha_inicio, fecha_fin)
VALUES (2, 5, 6, 3, 'Revisi�n de dise�o de software', 'Impacto en el tiempo de desarrollo', '2024-03-10', '2024-03-15', '2024-03-30');

INSERT INTO Solicitud_Cambio (id_proyecto, id_miembro_solicitante, id_miembro_responsable, id_estado_solicitud, descripcion, descripcion_impacto, fecha_aprobacion, fecha_inicio, fecha_fin)
VALUES (2, 7, NULL, 4, 'Solicitud de ajuste de presupuesto', 'Afecta la asignaci�n de recursos', NULL, NULL, NULL);

INSERT INTO Solicitud_Cambio (id_proyecto, id_miembro_solicitante, id_miembro_responsable, id_estado_solicitud, descripcion, descripcion_impacto, fecha_aprobacion, fecha_inicio, fecha_fin)
VALUES (3, 1, 4, 1, 'Solicitud de nuevos recursos', 'Incremento en los costos del proyecto', NULL, NULL, NULL);

INSERT INTO Solicitud_Cambio (id_proyecto, id_miembro_solicitante, id_miembro_responsable, id_estado_solicitud, descripcion, descripcion_impacto, fecha_aprobacion, fecha_inicio, fecha_fin)
VALUES (3, 5, 7, 3, 'Ajuste en la arquitectura del sistema', 'Impacto en la calidad del producto final', '2024-04-20', '2024-04-25', '2024-05-15');



INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Definir alcance del proyecto', 'Especificaci�n de los l�mites y objetivos del proyecto', 1, 1, 1, '2024-01-15', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Analizar requerimientos del cliente', 'Revisi�n y an�lisis de los requisitos del cliente', 1, 1, 2, '2024-01-20', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Dise�ar arquitectura del sistema', 'Creaci�n de la arquitectura base del sistema', 2, 1, 1, '2024-02-01', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Desarrollar m�dulo de autenticaci�n', 'Implementaci�n del sistema de login y permisos de usuario', 2, 1, 3, '2024-03-01', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Configurar entorno de desarrollo', 'Preparar el entorno para el desarrollo del proyecto', 3, 1, 4, '2024-01-10', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Desarrollar m�dulo de reportes', 'Creaci�n de reportes de seguimiento del proyecto', 1, 1, 2, '2024-04-15', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Realizar pruebas unitarias', 'Ejecutar pruebas para asegurar la calidad de cada componente', 1, 1, 3, '2024-05-01', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Revisi�n de c�digo', 'Revisi�n de calidad y buenas pr�cticas en el c�digo', 2, 1, 4, '2024-04-01', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Implementar dise�o de interfaz', 'Desarrollar la interfaz de usuario seg�n los est�ndares de UX/UI', 1, 1, 2, '2024-03-10', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Integraci�n con base de datos', 'Conectar el sistema con la base de datos del proyecto', 1, 1, 1, '2024-02-15', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Implementar API para servicios externos', 'Crear API para comunicar con servicios externos', 2, 1, 2, '2024-03-20', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Documentaci�n t�cnica', 'Elaboraci�n de la documentaci�n t�cnica del proyecto', 3, 1, 3, '2024-06-01', 'A');
INSERT INTO Tarea (titulo, descripcion, id_estado_tarea, id_proyecto, id_prioridad, fecha_limite, estado)
VALUES ('Desplegar sistema en entorno de producci�n', 'Implementaci�n final del sistema en el entorno de producci�n', 1, 1, 1, '2024-05-15', 'A');




-- Tablas Intermedias y de Asociaci�n (con m�ltiples dependencias):

-- Tablas Complementarias y de Auditor�a (con dependencia opcional):


SELECT * FROM Metodologia;
SELECT * FROM Estado_Proyecto;
SELECT * FROM Estado_Solicitud;
SELECT * FROM Estado_Tarea;
SELECT * FROM Prioridad;
SELECT * FROM Rol;
SELECT * FROM Tipo_Usuario;
SELECT * FROM Usuario;
SELECT * FROM Proyecto;
SELECT * FROM Fase;
SELECT * FROM Elemento_Configuracion;
SELECT * FROM Miembro_Proyecto;
SELECT * FROM Solicitud_Cambio;
SELECT * FROM Tarea;
SELECT * FROM Elemento_Solicitud_Cambio;
SELECT * FROM Miembro_Tarea;
SELECT * FROM Elemento_Tarea;
SELECT * FROM Historial_Cambios;
SELECT * FROM Actividad;
SELECT * FROM Notificacion;
SELECT * FROM Version_Elemento;
