-- Tabla de Metodología
CREATE TABLE Metodologia (
    id_metodologia INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    estado CHAR(1) DEFAULT 'A'
);

-- Nueva tabla para estados de proyecto
CREATE TABLE Estado_Proyecto (
    id_estado_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL -- Ejemplo: Pendiente, En progreso, Finalizado
);

-- Tabla de Estado de Solicitudes
CREATE TABLE Estado_Solicitud (
    id_estado_solicitud INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL -- Nombre del estado de la solicitud (Ej: Pendiente, Aprobado, Rechazado)
);

-- Tabla de Estados de Tarea (para tablero)
CREATE TABLE Estado_Tarea (
    id_estado_tarea INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL -- Nombre del estado de la tarea (Ej: To Do, In Progress, Done)
);

-- Tabla de Prioridad
CREATE TABLE Prioridad (
    id_prioridad INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(10) NOT NULL -- Nivel de prioridad (Ej: Alta, Media, Baja)
);

-- Tabla de Roles
CREATE TABLE Rol (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    estado CHAR(1) DEFAULT 'A'
);

-- Tabla de Tipo de Usuario
CREATE TABLE Tipo_Usuario (
    id_tipo_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL, -- Nombre del tipo de usuario (Ej: Administrador, Colaborador)
    estado CHAR(1) DEFAULT 'A' -- Estado del tipo de usuario (Activo/Inactivo)
);

-- Tabla de Usuarios con relación a Tipo_Usuario
CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    correo VARCHAR(100) UNIQUE,
    contrasena VARCHAR(50),
    estado CHAR(1) DEFAULT 'A',
    id_tipo_usuario INT NOT NULL, -- Tipo de usuario, clasifica según roles o permisos
    FOREIGN KEY (id_tipo_usuario) REFERENCES Tipo_Usuario(id_tipo_usuario)
);

-- Tabla de Proyectos con el campo id_estado_proyecto y url_repositorio agregados
CREATE TABLE Proyecto (
    id_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50), -- Código único o alfanumérico para identificar el proyecto
    nombre VARCHAR(100),
    descripcion TEXT NULL, -- Descripción del proyecto para contexto adicional
    fecha_inicio DATETIME,
    fecha_fin DATETIME,
    estado CHAR(1) DEFAULT 'A',
    id_metodologia INT NOT NULL, -- Metodología aplicada en el proyecto
    id_estado_proyecto INT NOT NULL DEFAULT (1), -- Estado inicial por defecto, referencia a Estado_Proyecto
    id_usuario_creador INT NOT NULL,  -- Nuevo campo para identificar al creador del proyecto
    url_repositorio VARCHAR(255) NULL, -- URL del repositorio (por ejemplo, GitHub)
    FOREIGN KEY (id_metodologia) REFERENCES Metodologia(id_metodologia),
    FOREIGN KEY (id_estado_proyecto) REFERENCES Estado_Proyecto(id_estado_proyecto),
    FOREIGN KEY (id_usuario_creador) REFERENCES Usuario(id_usuario)  -- Relación con la tabla de usuarios
);


-- Tabla de Fases (Opcional, para referencia informativa)
CREATE TABLE Fase (
    id_fase INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    id_metodologia INT NOT NULL, -- Metodología asociada a esta fase
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_metodologia) REFERENCES Metodologia(id_metodologia)
);

-- Tabla de Elementos de Configuración asociados a un Proyecto
CREATE TABLE Elemento_Configuracion (
    id_elemento_configuracion INT IDENTITY(1,1) PRIMARY KEY,
    codigo VARCHAR(50),
    nombre VARCHAR(100),
    nomenclatura VARCHAR(50),
    id_proyecto INT NOT NULL, -- Proyecto al que pertenece el elemento de configuración
    id_fase INT NULL, -- Fase del proyecto (Si en caso sea opcional, seria algo como: "No Aplica", "General" o "Sin Fase")
    estado CHAR(1) DEFAULT 'A',
    url_recurso_asociado VARCHAR(255) NULL, -- URL para un recurso externo - Artefacto_ECS?
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_fase) REFERENCES Fase(id_fase)
);


-- Tabla de Miembros del Proyecto con campo nivel
CREATE TABLE Miembro_Proyecto (
    id_miembro_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL, -- Usuario asignado al proyecto como miembro
    id_rol INT NOT NULL, -- Rol del miembro en el proyecto
    id_proyecto INT NOT NULL, -- Proyecto al que está asignado el miembro
    nivel INT NOT NULL, -- Nivel de acceso en el proyecto (1: Propietario, 2: Configuración y Solicitudes, 3: Asignación de Tareas)
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla de Solicitud de Cambios
CREATE TABLE Solicitud_Cambio (
    id_solicitud_cambio INT IDENTITY(1,1) PRIMARY KEY,
    descripcion TEXT NULL,
    estado CHAR(1) DEFAULT 'A',
    id_estado_solicitud INT NOT NULL, -- Estado específico de la solicitud
    id_miembro_solicitante INT NOT NULL, -- Cambiado de id_usuario_solicitante a id_miembro_solicitante
    id_miembro_responsable INT NULL, -- Cambiado de id_usuario_responsable a id_miembro_responsable
    id_proyecto INT NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    fecha_aprobacion DATETIME NULL,
    fecha_inicio DATETIME NULL,
    fecha_fin DATETIME NULL,
    descripcion_impacto TEXT NULL,
    FOREIGN KEY (id_estado_solicitud) REFERENCES Estado_Solicitud(id_estado_solicitud),
    FOREIGN KEY (id_miembro_solicitante) REFERENCES Miembro_Proyecto(id_miembro_proyecto),
    FOREIGN KEY (id_miembro_responsable) REFERENCES Miembro_Proyecto(id_miembro_proyecto),
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto)
);


-- Tabla de Tareas (sin el campo id_miembro_asignado)
CREATE TABLE Tarea (
    id_tarea INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    id_estado_tarea INT NOT NULL, -- Estado actual de la tarea (Ej: En progreso, Completado)
    id_proyecto INT NOT NULL, -- Proyecto al que pertenece la tarea
    id_prioridad INT NOT NULL, -- Nivel de prioridad de la tarea
    fecha_creacion DATETIME DEFAULT GETDATE(),
    fecha_limite DATETIME NULL,
    estado CHAR(1) DEFAULT 'A', -- Activo/Inactivo
    FOREIGN KEY (id_estado_tarea) REFERENCES Estado_Tarea(id_estado_tarea),
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_prioridad) REFERENCES Prioridad(id_prioridad)
);

--YA AGREGAR 
-- Tabla intermedia para solicitudes que afectan a múltiples ECS
CREATE TABLE Elemento_Solicitud_Cambio (
    id_elemento_solicitud_cambio INT IDENTITY(1,1) PRIMARY KEY,
    id_elemento_configuracion INT NOT NULL,
    id_solicitud_cambio INT NOT NULL,
    es_principal CHAR(1) DEFAULT 'N', -- 'S' para principal, 'N' para no principal
    fecha_asignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_elemento_configuracion) REFERENCES Elemento_Configuracion(id_elemento_configuracion),
    FOREIGN KEY (id_solicitud_cambio) REFERENCES Solicitud_Cambio(id_solicitud_cambio)
);

-- YA ESTA o falta?
-- Tabla de Miembros en Tareas (con indicador de miembro principal y fecha de asignación)
CREATE TABLE Miembro_Tarea (
    id_miembro_tarea INT IDENTITY(1,1) PRIMARY KEY,
    id_tarea INT NOT NULL, -- Tarea en la que participa el miembro
    id_miembro_proyecto INT NOT NULL, -- Miembro del proyecto asignado a la tarea
    es_principal CHAR(1) DEFAULT 'N', -- 'S' para principal, 'N' para no principal
    fecha_asignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_tarea) REFERENCES Tarea(id_tarea),
    FOREIGN KEY (id_miembro_proyecto) REFERENCES Miembro_Proyecto(id_miembro_proyecto)
);

-- Tabla de Elemento en Tareas (con indicador de elemento principal y fecha de asignación)
CREATE TABLE Elemento_Tarea (
    id_elemento_tarea INT IDENTITY(1,1) PRIMARY KEY,
    id_elemento_configuracion INT NOT NULL,
    id_tarea INT NOT NULL,
    es_principal CHAR(1) DEFAULT 'N', -- 'S' para principal, 'N' para no principal
    fecha_asignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_elemento_configuracion) REFERENCES Elemento_Configuracion(id_elemento_configuracion),
    FOREIGN KEY (id_tarea) REFERENCES Tarea(id_tarea)
);

-- Tabla de Historial de Cambios para la Auditoria Interna de la BD
CREATE TABLE Historial_Cambios (
    id_historial INT IDENTITY(1,1) PRIMARY KEY,
    tabla VARCHAR(50) NOT NULL, -- Nombre de la tabla afectada (por ejemplo, 'Elemento_Configuracion')
    id_registro INT NOT NULL, -- ID del registro afectado (ID específico del elemento afectado)
    tipo_cambio VARCHAR(50) NOT NULL, -- 'INSERT', 'UPDATE', 'DELETE'
    valor_anterior TEXT NULL, -- Valor previo al cambio (aplicable para UPDATE y DELETE)
    valor_nuevo TEXT NULL, -- Valor después del cambio (aplicable para INSERT y UPDATE)
    fecha_cambio DATETIME DEFAULT GETDATE(), -- Fecha y hora del cambio
    id_usuario INT NOT NULL, -- Usuario que realizó el cambio
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Actividad (
    id_actividad INT IDENTITY(1,1) PRIMARY KEY,
    id_proyecto INT NOT NULL, -- Proyecto asociado a la actividad
    id_miembro_proyecto INT NOT NULL, -- Miembro responsable de la actividad
    nombre_actividad VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_miembro_proyecto) REFERENCES Miembro_Proyecto(id_miembro_proyecto)
);

CREATE TABLE Notificacion (
    id_notificacion INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL, -- Usuario destinatario de la notificación
    mensaje TEXT NOT NULL, -- Contenido de la notificación
    fecha_envio DATETIME DEFAULT GETDATE(), -- Fecha de envío de la notificación
    leido CHAR(1) DEFAULT 'N', -- Estado de lectura ('S' para leído, 'N' para no leído)
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla de Versiones para controlar versiones de elementos de configuración
CREATE TABLE Version_Elemento (
    id_version INT IDENTITY(1,1) PRIMARY KEY,
    id_elemento_configuracion INT NOT NULL, -- Relación al elemento que está versionado
    numero_version VARCHAR(50) NOT NULL, -- Ejemplo: "v1.0.0"
    descripcion TEXT NULL, -- Descripción de los cambios o mejoras en esta versión
    fecha_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_elemento_configuracion) REFERENCES Elemento_Configuracion(id_elemento_configuracion)
);
