-- Tabla de roles
CREATE TABLE Roles (
    RolId INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(50) NOT NULL UNIQUE,
    FechaCreacion DATETIME DEFAULT GETDATE() not null,
	Fecha_Modificacion datetime null,
	Fecha_Baja datetime null
);

-- Tabla de Vista
Create table Vistas(
	VistaId int primary key identity(1,1),
	NombreVista nvarchar(max)null,
	Icono nvarchar(max) null,
	Ruta nvarchar(max)null,
	Fecha_Alta datetime default getdate() not null,
	Fecha_Modificacion datetime null,
	Fecha_Baja datetime null
);

create table Permisos (
	PermisoId int primary key identity(1,1),
	Accion nvarchar(max) null,
	Controlador nvarchar(max) null,
	Fecha_Alta datetime default getdate() not null,
	Fecha_Modificacion datetime null,
	Fecha_Baja datetime null
);

create table RolesVistas(
	RolVistaId int primary key identity(1,1),
	RolId int not null,
	VistaId int not null,
	constraint FK_RolesVistas_Rol Foreign Key (RolId) REFERENCES Roles(RolId) ON DELETE CASCADE,
	constraint FK_RolesVistas_Vista Foreign Key (VistaId) REFERENCES Vistas(VistaId) ON DELETE CASCADE,
	constraint UQ_RolVista Unique (RolId, VistaId)
);

create table RolesPermisos (
	RolPermisoId int primary key identity(1,1),
	RolId int not null,
	PermisoId int not null,
	constraint FK_RolesPermisos_Rol Foreign Key (RolId) REFERENCES Roles(RolId) ON DELETE CASCADE,
	constraint FK_RolesPermisos_Permiso Foreign Key (PermisoId) REFERENCES Permisos(PermisoId) ON DELETE CASCADE,
	constraint UQ_RolPermiso Unique (RolId, PermisoId)
);

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioId INT PRIMARY KEY IDENTITY(1,1),
    RolId INT NOT NULL DEFAULT 2, -- Por defecto Usuario
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Telefono NVARCHAR(20),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FechaBaja DATETIME NULL,
    Activo BIT DEFAULT 1,
    UsuarioBajaID INT NULL, -- Usuario admin que dio de baja
    CONSTRAINT FK_Usuarios_Rol FOREIGN KEY (RolId) REFERENCES Roles(RolId),
    CONSTRAINT FK_Usuarios_UsuarioBaja FOREIGN KEY (UsuarioBajaId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT CK_Email CHECK (Email LIKE '%@%.%')
);

-- Tabla de Turnos
CREATE TABLE Turnos (
    TurnoId INT PRIMARY KEY IDENTITY(1,1),
    NombreTurno NVARCHAR(50) NOT NULL UNIQUE,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Descripcion NVARCHAR(200),
    Activo BIT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL,
    UsuarioModificadorId INT NULL,
    CONSTRAINT FK_Turnos_Usuario FOREIGN KEY (UsuarioModificadorId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT CK_Turno_Horario CHECK (HoraFin > HoraInicio)
);

-- Tabla de Historial de Cambios en Turnos
CREATE TABLE HistorialTurnos (
    HistorialTurnoId INT PRIMARY KEY IDENTITY(1,1),
    TurnoId INT NOT NULL,
    HoraInicioAnterior TIME,
    HoraFinAnterior TIME,
    HoraInicioNueva TIME NOT NULL,
    HoraFinNueva TIME NOT NULL,
    UsuarioModificadorId INT NOT NULL,
    FechaCambio DATETIME null,
    Motivo NVARCHAR(500),
    CONSTRAINT FK_HistorialTurnos_Turno FOREIGN KEY (TurnoId) REFERENCES Turnos(TurnoId),
    CONSTRAINT FK_HistorialTurnos_Usuario FOREIGN KEY (UsuarioModificadorId) REFERENCES Usuarios(UsuarioId)
);

-- Tabla del Salón
CREATE TABLE Salones (
    SalonId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Capacidad INT NOT NULL,
    Descripcion NVARCHAR(500),
    Activo BIT DEFAULT 1,
    CONSTRAINT CK_Capacidad CHECK (Capacidad > 0)
);

-- Tabla de Estados de Reserva
CREATE TABLE EstadosReserva (
    EstadoId INT PRIMARY KEY IDENTITY(1,1),
    NombreEstado NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(200)
);

-- Tabla de Reservas
CREATE TABLE Reservas (
    ReservaId INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT NOT NULL,
    SalonId INT NOT NULL,
    TurnoId INT NOT NULL,
    FechaReserva DATE NOT NULL,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    EstadoId INT NOT NULL,
    CantidadPersonas INT,
    Observaciones NVARCHAR(500),
    CONSTRAINT FK_Reservas_Usuario FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_Reservas_Salon FOREIGN KEY (SalonId) REFERENCES Salones(SalonId),
    CONSTRAINT FK_Reservas_Turno FOREIGN KEY (TurnoId) REFERENCES Turnos(TurnoId),
    CONSTRAINT FK_Reservas_Estado FOREIGN KEY (EstadoId) REFERENCES EstadosReserva(EstadoId),
    -- Constraint para evitar reservas duplicadas (mismo salón, fecha y turno)
    CONSTRAINT UQ_Reserva_Unica UNIQUE (SalonId, FechaReserva, TurnoId),
    CONSTRAINT CK_Fecha_Reserva CHECK (FechaReserva >= CAST(GETDATE() AS DATE))
);

-- Tabla de Historial de Cambios de Estado
CREATE TABLE HistorialEstadoReserva (
    HistorialId INT PRIMARY KEY IDENTITY(1,1),
    ReservaId INT NOT NULL,
    EstadoAnterior INT,
    EstadoNuevo INT NOT NULL,
    FechaCambio DATETIME DEFAULT GETDATE(),
    UsuarioModificador INT,
    Comentario NVARCHAR(500),
    CONSTRAINT FK_Historial_Reserva FOREIGN KEY (ReservaId) REFERENCES Reservas(ReservaId),
    CONSTRAINT FK_Historial_EstadoAnterior FOREIGN KEY (EstadoAnterior) REFERENCES EstadosReserva(EstadoId),
    CONSTRAINT FK_Historial_EstadoNuevo FOREIGN KEY (EstadoNuevo) REFERENCES EstadosReserva(EstadoId)
);

-- =============================================
-- ÍNDICES PARA OPTIMIZACIÓN
-- =============================================

CREATE INDEX IX_Reservas_Usuario ON Reservas(UsuarioId);
CREATE INDEX IX_Reservas_Fecha ON Reservas(FechaReserva);
CREATE INDEX IX_Reservas_Estado ON Reservas(EstadoId);
CREATE INDEX IX_Usuarios_Email ON Usuarios(Email);
CREATE INDEX IX_Usuarios_Activo ON Usuarios(Activo);
CREATE INDEX IX_Usuarios_Rol ON Usuarios(RolId);

-- =============================================
-- Insercción de Roles
-- =============================================
insert into Roles (NombreRol,FechaCreacion) values ('Admin', getdate())
insert into Roles (NombreRol,FechaCreacion) values ('Usuario', getdate())

-- =============================================
-- Insercción de Estados
-- =============================================
INSERT into EstadosReserva (NombreEstado,Descripcion) VALUES ('Disponible', 'Fecha y Salón disponible con todos los turnos habilitados'),
('Poco Disponible', 'Fecha y Salón con al menos 1 turno disponible'),
('Cancelada', 'Fecha y Salón Cancelada'),
('No Disponible', 'Fecha y Salón con todos los turnos agotados'),
('Confirmada', 'Reserva confirmada');


-- =============================================
-- Insercción de Turnos
-- =============================================
INSERT into Turnos (NombreTurno,HoraInicio,HoraFin,Descripcion,Activo,FechaCreacion) values 
('Mañana', '00:00:00', '11:00:59', 'Turno Mañana hasta las 11:00',1,GETDATE()),
('Mediodía', '11:01:00', '16:00:59', 'Turno Mediodía de 11:01 a 16:00',1,getdate()),
('Tarde', '16:01:00', '20:00:59', 'Turno Tarde de 16:01 a 20:00',1,GETDATE()),
('Noche', '20:01:00', '23:59:59', 'Turno Noche desde las 20:01',1,getdate());

-- =============================================
-- Insercción de Salón
-- =============================================
INSERT INTO Salones (Nombre, Capacidad, Descripcion, Activo) VALUES
('Salón Cubit', 50, 'Salón ubicado en FANNY JACOVSKY 3539', 1);

-- =============================================
-- Insercción de Vistas
-- =============================================
INSERT into Vistas (NombreVista,Icono,Ruta,Fecha_Alta) values ('home',null,'record-list',getdate())

-- =============================================
-- Insercción de Roles_Vistas
-- =============================================
--Insert Roles_Vistas
INSERT INTO RolesVistas (RolId, VistaId)
SELECT 1, VistaId
FROM Vistas;


-- =============================================
-- Insercción de Permisos
-- =============================================
insert into Permisos (Accion,Controlador,Fecha_Alta) VALUES ('GetList','Roles',GETDATE()),
('Get','Roles',GETDATE()),
('GetViewList', 'Roles',GETDATE()),
('GetPermissionList','Roles',GETDATE()),
('Create','Roles',GETDATE()),
('CreateRoleView','Roles',getdate()),
('CreateRolePermission','Roles',GETDATE()),
('Update','Roles',getdate()),
('Recover','Roles',GETDATE()),
('Update','Roles',getdate()),
('DeleteRoleView','Roles',getdate()),
('DeleteRolePermission','Roles',GETDATE())

-- =============================================
-- Insercción de Roles_Permisos
-- =============================================
INSERT INTO RolesPermisos (RolId, PermisoId)
SELECT 1, PermisoId
FROM Permisos;


