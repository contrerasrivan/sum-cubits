-- Tabla de roles
CREATE TABLE Roles (
    RolId INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(50) NOT NULL UNIQUE,
    Descripcion NVARCHAR(200),
    FechaCreacion DATETIME DEFAULT GETDATE() not null
);

-- Tabla de Vista
Create table Vistas(
	VistaId int primary key identity(1,1),
	NombreVista nvarchar(max)null,
	Icono nvarchar(max) null,
	Ruta nvarchar(max)null,
	Fecha_Alta datetime default getdate() not null,
	Fecha_Modificacion datetime default getdate() not null,
	Fecha_Baja datetime default getdate() not null
);

create table Permisos (
	PermisoId int primary key identity(1,1),
	Accion nvarchar(max) null,
	Controlador nvarchar(max) null,
	Fecha_Alta datetime default getdate() not null,
	Fecha_Modificacion datetime default getdate() not null,
	Fecha_Baja datetime default getdate() not null
);

create table RolesVistas(
	RolVistaId int primary key identity(1,1),
	RolId int not null,
	VistaId int not null,
	Fecha_Asignacion datetime default getdate(),
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
    UsuarioId nvarchar(450) not null,
    RolId INT NOT NULL DEFAULT 2, -- Por defecto Usuario
    NombreCompleto NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    FechaBaja DATETIME NULL,
    Activo BIT DEFAULT 1,
    CONSTRAINT FK_Usuarios_Rol FOREIGN KEY (RolId) REFERENCES Roles(RolId),
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
    UsuarioModificadorID nvarchar(450) not NULL,
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
    UsuarioModificadorId nvarchar(450) NULL,
    FechaCambio DATETIME DEFAULT GETDATE(),
    Motivo NVARCHAR(500),
    CONSTRAINT FK_HistorialTurnos_Turno FOREIGN KEY (TurnoId) REFERENCES Turnos(TurnoId),
);

-- Tabla del Salón
CREATE TABLE Salon (
    SalonId INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Capacidad INT NOT NULL,
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
    UsuarioId nvarchar(450) NOT NULL,
    SalonId INT NOT NULL,
    TurnoId INT NOT NULL,
    FechaReserva DATE NOT NULL,
    FechaSolicitud DATETIME DEFAULT GETDATE(),
    EstadoId INT NOT NULL,
    CantidadPersonas INT,
    Observaciones NVARCHAR(500),
    CONSTRAINT FK_Reservas_Salon FOREIGN KEY (SalonId) REFERENCES Salon(SalonId),
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
    CONSTRAINT FK_Historial_EstadoAnterior FOREIGN KEY (EstadoAnterior) REFERENCES EstadosReserva(EstadoID),
    CONSTRAINT FK_Historial_EstadoNuevo FOREIGN KEY (EstadoNuevo) REFERENCES EstadosReserva(EstadoID)
);

CREATE INDEX IX_Reservas_Fecha ON Reservas(FechaReserva);
CREATE INDEX IX_Reservas_Estado ON Reservas(EstadoId);
CREATE INDEX IX_Usuarios_Email ON Usuarios(Email);
CREATE INDEX IX_Usuarios_Activo ON Usuarios(Activo);
CREATE INDEX IX_Usuarios_Rol ON Usuarios(RolId);