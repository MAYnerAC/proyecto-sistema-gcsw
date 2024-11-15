-- Tabla de Metodología
CREATE TABLE Metodologia (
    id_metodologia INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    estado CHAR(1) DEFAULT 'A'
);

-- Nueva tabla para estados de proyecto
CREATE TABLE Estado_Proyecto (
    id_estado_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

-- Tabla de Estado de Solicitudes
CREATE TABLE Estado_Solicitud (
    id_estado_solicitud INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

-- Tabla de Estados de Tarea (para tablero)
CREATE TABLE Estado_Tarea (
    id_estado_tarea INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

-- Tabla de Prioridad
CREATE TABLE Prioridad (
    id_prioridad INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(10) NOT NULL
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
    nombre VARCHAR(100) NOT NULL,
    estado CHAR(1) DEFAULT 'A'
);

-- Tabla de Usuarios
CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    correo VARCHAR(100) UNIQUE,
    contrasena VARCHAR(50),
    estado CHAR(1) DEFAULT 'A',
    id_tipo_usuario INT NOT NULL,
    FOREIGN KEY (id_tipo_usuario) REFERENCES Tipo_Usuario(id_tipo_usuario)
);

-- Tabla de Proyectos
CREATE TABLE Proyecto (
    id_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    codigo_proyecto VARCHAR(50),
    descripcion TEXT NULL,
    fecha_inicio DATETIME,
    fecha_fin DATETIME,
    estado CHAR(1) DEFAULT 'A',
    id_metodologia INT NOT NULL,
    id_estado_proyecto INT NOT NULL DEFAULT (1),
    id_usuario_creador INT NOT NULL,
    url_repositorio VARCHAR(255) NULL,
    FOREIGN KEY (id_metodologia) REFERENCES Metodologia(id_metodologia),
    FOREIGN KEY (id_estado_proyecto) REFERENCES Estado_Proyecto(id_estado_proyecto),
    FOREIGN KEY (id_usuario_creador) REFERENCES Usuario(id_usuario)
);


-- Tabla de Fases
CREATE TABLE Fase (
    id_fase INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    id_metodologia INT NOT NULL,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_metodologia) REFERENCES Metodologia(id_metodologia)
);

-- Tabla de Elementos de Configuración
CREATE TABLE Elemento_Configuracion (
    id_elemento_configuracion INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    codigo_elemento VARCHAR(50),
    nomenclatura VARCHAR(50),
    id_proyecto INT NOT NULL,
    id_fase INT NULL,
    estado CHAR(1) DEFAULT 'A',
    url_recurso_asociado VARCHAR(255) NULL,
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_fase) REFERENCES Fase(id_fase)
);

-- Tabla de Miembros del Proyecto
CREATE TABLE Miembro_Proyecto (
    id_miembro_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_proyecto INT NOT NULL,
    id_rol INT NOT NULL,
    nivel INT NOT NULL,
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla de Solicitud de Cambios
CREATE TABLE Solicitud_Cambio (
    id_solicitud_cambio INT IDENTITY(1,1) PRIMARY KEY,
    id_proyecto INT NOT NULL,
    id_miembro_solicitante INT NOT NULL,
    id_miembro_responsable INT NULL,
    id_estado_solicitud INT NOT NULL,
    descripcion TEXT NULL,
    descripcion_impacto TEXT NULL,
    estado CHAR(1) DEFAULT 'A',
    fecha_creacion DATETIME DEFAULT GETDATE(),
    fecha_aprobacion DATETIME NULL,
    fecha_inicio DATETIME NULL,
    fecha_fin DATETIME NULL,
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_miembro_solicitante) REFERENCES Miembro_Proyecto(id_miembro_proyecto),
    FOREIGN KEY (id_miembro_responsable) REFERENCES Miembro_Proyecto(id_miembro_proyecto),
    FOREIGN KEY (id_estado_solicitud) REFERENCES Estado_Solicitud(id_estado_solicitud)
);

-- Tabla de Tareas
CREATE TABLE Tarea (
    id_tarea INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    id_proyecto INT NOT NULL,
    id_estado_tarea INT NOT NULL,
    id_prioridad INT NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    fecha_limite DATETIME NULL,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_estado_tarea) REFERENCES Estado_Tarea(id_estado_tarea),
    FOREIGN KEY (id_prioridad) REFERENCES Prioridad(id_prioridad)
);

-- Tabla intermedia para solicitudes que afectan a múltiples ECS
CREATE TABLE Elemento_Solicitud_Cambio (
    id_elemento_solicitud_cambio INT IDENTITY(1,1) PRIMARY KEY,
    id_solicitud_cambio INT NOT NULL,
    id_elemento_configuracion INT NOT NULL,
    es_principal CHAR(1) DEFAULT 'N',
    fecha_asignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_elemento_configuracion) REFERENCES Elemento_Configuracion(id_elemento_configuracion),
    FOREIGN KEY (id_solicitud_cambio) REFERENCES Solicitud_Cambio(id_solicitud_cambio)
);

-- Tabla de Miembros en Tareas
CREATE TABLE Miembro_Tarea (
    id_miembro_tarea INT IDENTITY(1,1) PRIMARY KEY,
    id_miembro_proyecto INT NOT NULL,
    id_tarea INT NOT NULL,
    es_principal CHAR(1) DEFAULT 'N',
    fecha_asignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_tarea) REFERENCES Tarea(id_tarea),
    FOREIGN KEY (id_miembro_proyecto) REFERENCES Miembro_Proyecto(id_miembro_proyecto)
);

-- Tabla de Elemento en Tareas
CREATE TABLE Elemento_Tarea (
    id_elemento_tarea INT IDENTITY(1,1) PRIMARY KEY,
    id_tarea INT NOT NULL,
    id_elemento_configuracion INT NOT NULL,
    es_principal CHAR(1) DEFAULT 'N',
    fecha_asignacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_elemento_configuracion) REFERENCES Elemento_Configuracion(id_elemento_configuracion),
    FOREIGN KEY (id_tarea) REFERENCES Tarea(id_tarea)
);

-- Tabla de Historial de Cambios
CREATE TABLE Historial_Cambios (
    id_historial INT IDENTITY(1,1) PRIMARY KEY,
    tabla VARCHAR(50) NOT NULL,
    id_registro INT NOT NULL,
    tipo_cambio VARCHAR(50) NOT NULL,
    valor_anterior TEXT NULL,
    valor_nuevo TEXT NULL,
    fecha_cambio DATETIME DEFAULT GETDATE(),
    id_usuario INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla de Actividades
CREATE TABLE Actividad (
    id_actividad INT IDENTITY(1,1) PRIMARY KEY,
    nombre_actividad VARCHAR(100) NOT NULL,
    descripcion TEXT NULL,
    fecha_inicio DATETIME NOT NULL,
    fecha_fin DATETIME NOT NULL,
    estado CHAR(1) DEFAULT 'A',
    id_proyecto INT NOT NULL,
    id_miembro_proyecto INT NOT NULL,
    FOREIGN KEY (id_proyecto) REFERENCES Proyecto(id_proyecto),
    FOREIGN KEY (id_miembro_proyecto) REFERENCES Miembro_Proyecto(id_miembro_proyecto)
);

-- Tabla de Notificaciones
CREATE TABLE Notificacion (
    id_notificacion INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    mensaje TEXT NOT NULL,
    fecha_envio DATETIME DEFAULT GETDATE(),
    leido CHAR(1) DEFAULT 'N',
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla de Versiones de Elementos
CREATE TABLE Version_Elemento (
    id_version INT IDENTITY(1,1) PRIMARY KEY,
    id_elemento_configuracion INT NOT NULL,
    numero_version VARCHAR(50) NOT NULL,
    descripcion TEXT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_elemento_configuracion) REFERENCES Elemento_Configuracion(id_elemento_configuracion)
);

