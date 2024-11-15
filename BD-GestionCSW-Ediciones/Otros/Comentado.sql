


-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*



-- Tabla de asociación entre roles y metodologías
CREATE TABLE Rol_Metodologia (
    id_rol_metodologia INT IDENTITY(1,1) PRIMARY KEY,
    id_rol INT NOT NULL,
    id_metodologia INT NOT NULL,
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
    FOREIGN KEY (id_metodologia) REFERENCES Metodologia(id_metodologia)
);



------------------------------------------------------------------------------------------
# Tablas Independientes (sin dependencias):
------------------------------------------------------------------------------------------
Metodologia
Estado_Proyecto
Estado_Solicitud
Estado_Tarea
Prioridad
Rol
Tipo_Usuario

------------------------------------------------------------------------------------------
## Tablas con Dependencias Moderadas (dependen de las anteriores):
------------------------------------------------------------------------------------------
Usuario (depende de Tipo_Usuario)
Proyecto (depende de Metodologia y Estado_Proyecto)
Fase (depende de Metodologia)


------------------------------------------------------------------------------------------
### Tablas con Dependencias Altas (dependen de las anteriores):
------------------------------------------------------------------------------------------
Elemento_Configuracion (depende de Proyecto y Fase)
Miembro_Proyecto (depende de Proyecto, Rol, y Usuario)
Solicitud_Cambio (depende de Estado_Solicitud, Usuario, y Proyecto)
Tarea (depende de Estado_Tarea, Proyecto, y Prioridad)


------------------------------------------------------------------------------------------
#### Tablas Intermedias y de Asociación (con múltiples dependencias):
------------------------------------------------------------------------------------------
Elemento_Solicitud_Cambio (depende de Elemento_Configuracion y Solicitud_Cambio)
Miembro_Tarea (depende de Tarea y Miembro_Proyecto)
Elemento_Tarea (depende de Elemento_Configuracion y Tarea)


------------------------------------------------------------------------------------------
##### Tablas Complementarias y de Auditoría (con dependencia opcional):
------------------------------------------------------------------------------------------
Historial_Cambios (depende de Usuario)
Actividad (depende de Proyecto y Miembro_Proyecto)
Notificacion (depende de Usuario)
Version (depende de Elemento_Configuracion)



*/