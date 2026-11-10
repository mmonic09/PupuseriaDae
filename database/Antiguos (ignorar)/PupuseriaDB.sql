/* ==========================================================================
   BASE DE DATOS : PupuseriaDB
   MOTOR         : Microsoft SQL Server
   ENTIDADES     : Rol, Usuario, Categoria, Producto, MetodoPago, Venta, DetalleVenta

   REGLAS QUE APLICA EL SCRIPT
   - Sin duplicados ......... UNIQUE en los nombres (Rol, Usuario, Categoria, Producto,
                              MetodoPago) y en (IdVenta, IdProducto) dentro del detalle.
   - Estado de usuario ...... Usuario.Activo (1 = activo, 0 = inactivo).
   - Estado de venta ........ Venta.Estado ('Completada' o 'Anulada').
   - Historial intacto ...... Las llaves foráneas impiden borrar datos que ya se usaron;
                              los catálogos se "eliminan" con Activo = 0 (borrado lógico);
                              Venta y DetalleVenta no se pueden borrar (trigger): una venta
                              incorrecta se pasa a 'Anulada'.
   - Precio histórico ....... DetalleVenta.PrecioUnitario guarda el precio al vender.

   CÓMO EJECUTARLO
   1. Abra este archivo en SSMS (o en el SQL Server Object Explorer de Visual Studio).
   2. Conéctese a su servidor y ejecute TODO el script (F5).
   3. Para empezar de cero, ejecute antes el bloque comentado "REINICIAR" de abajo.
   ========================================================================== */

-- --- REINICIAR (opcional): para borrar TODA la base y empezar de cero,
-- --- quite los dos guiones de cada línea siguiente y ejecute ese bloque solo:
-- USE master;
-- ALTER DATABASE PupuseriaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- DROP DATABASE PupuseriaDB;

IF DB_ID(N'PupuseriaDB') IS NULL
    CREATE DATABASE PupuseriaDB;
GO

USE PupuseriaDB;
GO

/* ==========================================================================
   1. TABLAS DE CATÁLOGO (no dependen de otras)
   ========================================================================== */

-- Módulo: Roles y usuarios
CREATE TABLE Rol (
    IdRol       INT IDENTITY(1,1) NOT NULL,
    Nombre      NVARCHAR(30)  NOT NULL,
    Descripcion NVARCHAR(100) NULL,
    Activo      BIT           NOT NULL CONSTRAINT DF_Rol_Activo DEFAULT 1,
    CONSTRAINT PK_Rol PRIMARY KEY (IdRol),
    CONSTRAINT UQ_Rol_Nombre UNIQUE (Nombre),
    CONSTRAINT CK_Rol_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
);
GO

-- Módulo: Categorías y productos
CREATE TABLE Categoria (
    IdCategoria INT IDENTITY(1,1) NOT NULL,
    Nombre      NVARCHAR(50)  NOT NULL,
    Descripcion NVARCHAR(100) NULL,
    Activo      BIT           NOT NULL CONSTRAINT DF_Categoria_Activo DEFAULT 1,
    CONSTRAINT PK_Categoria PRIMARY KEY (IdCategoria),
    CONSTRAINT UQ_Categoria_Nombre UNIQUE (Nombre),
    CONSTRAINT CK_Categoria_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
);
GO

-- Módulo: Métodos de pago
CREATE TABLE MetodoPago (
    IdMetodoPago INT IDENTITY(1,1) NOT NULL,
    Nombre       NVARCHAR(30) NOT NULL,
    Activo       BIT          NOT NULL CONSTRAINT DF_MetodoPago_Activo DEFAULT 1,
    CONSTRAINT PK_MetodoPago PRIMARY KEY (IdMetodoPago),
    CONSTRAINT UQ_MetodoPago_Nombre UNIQUE (Nombre),
    CONSTRAINT CK_MetodoPago_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
);
GO

/* ==========================================================================
   2. TABLAS QUE DEPENDEN DE LOS CATÁLOGOS
   ========================================================================== */

-- Módulo: Roles y usuarios
CREATE TABLE Usuario (
    IdUsuario      INT IDENTITY(1,1) NOT NULL,
    IdRol          INT           NOT NULL,
    NombreUsuario  NVARCHAR(50)  NOT NULL,
    ClaveHash      NVARCHAR(256) NOT NULL, -- nunca la contraseña en texto plano
    DebeCambiarClave BIT NOT NULL, 
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Activo         BIT           NOT NULL CONSTRAINT DF_Usuario_Activo DEFAULT 1,
    CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuario_NombreUsuario UNIQUE (NombreUsuario),
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES Rol (IdRol),
    CONSTRAINT DF_Usuario_DebeCambiarClave DEFAULT 1,
    CONSTRAINT CK_Usuario_NombreUsuario CHECK (LEN(LTRIM(RTRIM(NombreUsuario))) > 0)
);
GO

-- Módulo: Categorías y productos
CREATE TABLE Producto (
    IdProducto  INT IDENTITY(1,1) NOT NULL,
    IdCategoria INT           NOT NULL,
    Nombre      NVARCHAR(80)  NOT NULL,
    TipoMasa    NVARCHAR(10)  NULL,        -- 'Maíz' o 'Arroz'; vacío si no es pupusa
    Descripcion NVARCHAR(150) NULL,
    Precio      DECIMAL(10,2) NOT NULL,
    Activo      BIT           NOT NULL CONSTRAINT DF_Producto_Activo DEFAULT 1,
    CONSTRAINT PK_Producto PRIMARY KEY (IdProducto),
    CONSTRAINT UQ_Producto_Nombre_Masa UNIQUE (Nombre, TipoMasa),   -- reemplaza a UQ_Producto_Nombre
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (IdCategoria) REFERENCES Categoria (IdCategoria),
    CONSTRAINT CK_Producto_TipoMasa CHECK (TipoMasa IN (N'Maíz', N'Arroz')),
    CONSTRAINT CK_Producto_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0),
    CONSTRAINT CK_Producto_Precio CHECK (Precio > 0)
);
GO

/* ==========================================================================
   3. VENTAS (encabezado y detalle)
   ========================================================================== */

-- Módulo: Ventas y consulta de ventas
CREATE TABLE Venta (
    IdVenta      INT IDENTITY(1001,1) NOT NULL,   -- también es el número de venta
    Fecha        DATETIME2     NOT NULL CONSTRAINT DF_Venta_Fecha DEFAULT SYSDATETIME(),
    IdUsuario    INT           NOT NULL,          -- quién registró la venta
    IdMetodoPago INT           NOT NULL,
    Total        DECIMAL(10,2) NOT NULL CONSTRAINT DF_Venta_Total DEFAULT 0,
    Estado       NVARCHAR(10)  NOT NULL CONSTRAINT DF_Venta_Estado DEFAULT N'Completada',
    CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
    CONSTRAINT FK_Venta_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario (IdUsuario),
    CONSTRAINT FK_Venta_MetodoPago FOREIGN KEY (IdMetodoPago) REFERENCES MetodoPago (IdMetodoPago),
    CONSTRAINT CK_Venta_Total CHECK (Total >= 0),
    CONSTRAINT CK_Venta_Estado CHECK (Estado IN (N'Completada', N'Anulada'))
);
GO

CREATE TABLE DetalleVenta (
    IdDetalleVenta INT IDENTITY(1,1) NOT NULL,
    IdVenta        INT           NOT NULL,
    IdProducto     INT           NOT NULL,
    Cantidad       INT           NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,        -- precio al momento de la venta
    Subtotal       AS CAST(Cantidad * PrecioUnitario AS DECIMAL(12,2)) PERSISTED,
    CONSTRAINT PK_DetalleVenta PRIMARY KEY (IdDetalleVenta),
    CONSTRAINT FK_DetalleVenta_Venta FOREIGN KEY (IdVenta) REFERENCES Venta (IdVenta),
    CONSTRAINT FK_DetalleVenta_Producto FOREIGN KEY (IdProducto) REFERENCES Producto (IdProducto),
    CONSTRAINT UQ_DetalleVenta_Venta_Producto UNIQUE (IdVenta, IdProducto),
    CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_DetalleVenta_Precio CHECK (PrecioUnitario >= 0)
);
GO

/* ==========================================================================
   4. ÍNDICES (aceleran la consulta de ventas y los reportes)
   ========================================================================== */
CREATE INDEX IX_Usuario_IdRol           ON Usuario (IdRol);
CREATE INDEX IX_Producto_IdCategoria    ON Producto (IdCategoria);
CREATE INDEX IX_Venta_Fecha             ON Venta (Fecha);
CREATE INDEX IX_Venta_IdUsuario         ON Venta (IdUsuario);
CREATE INDEX IX_Venta_IdMetodoPago      ON Venta (IdMetodoPago);
CREATE INDEX IX_DetalleVenta_IdProducto ON DetalleVenta (IdProducto);
GO

/* ==========================================================================
   5. PROTECCIÓN DEL HISTORIAL: las ventas no se pueden borrar
   (si necesita editar líneas de una venta en curso, elimine el trigger
   de DetalleVenta; la venta se corrige anulándola y registrando otra)
   ========================================================================== */
CREATE TRIGGER trg_Venta_NoEliminar
ON Venta
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50001, N'No se pueden eliminar ventas. Cambie su estado a Anulada para conservar el historial.', 1;
END;
GO

CREATE TRIGGER trg_DetalleVenta_NoEliminar
ON DetalleVenta
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50002, N'No se pueden eliminar detalles de venta. Anule la venta para conservar el historial.', 1;
END;
GO

/* ==========================================================================
   6. DATOS INICIALES (necesarios para poder usar el sistema)
   ========================================================================== */
INSERT INTO Rol (Nombre, Descripcion) VALUES
(N'Administrador', N'Acceso total al sistema'),
(N'Cajero',        N'Registra y consulta ventas');
GO

INSERT INTO MetodoPago (Nombre) VALUES
(N'Efectivo'),
(N'Tarjeta'),
(N'Transferencia');
GO

-- Usuario inicial:  admin / Admin123   (cámbiela al entrar al sistema)
-- ClaveHash = SHA-256 en hexadecimal. En C#, para obtener el mismo valor:
--   Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(clave)))
INSERT INTO Usuario (IdRol, NombreUsuario, ClaveHash, NombreCompleto)
SELECT IdRol, N'admin', CONVERT(NVARCHAR(256), HASHBYTES('SHA2_256', 'Admin123'), 2), N'Administrador del sistema'
FROM Rol
WHERE Nombre = N'Administrador';
GO

/* ==========================================================================
   7. DATOS DE PRUEBA (opcionales: puede borrar esta sección)
   ========================================================================== */
INSERT INTO Categoria (Nombre, Descripcion) VALUES
(N'Pupusas', N'Pupusas de maíz o arroz'),
(N'Refrescos naturales', N'Jugos 100% naturales'),
(N'Sodas', N'Refrescos carbonatados'),
(N'Bebidas calientes', N'Chocolate, café, etc');
GO

INSERT INTO Producto (IdCategoria, Nombre, Precio)
SELECT c.IdCategoria, v.Nombre, v.Precio
FROM (VALUES
    (N'Pupusas', N'Pupusa de queso',            0.75),
    (N'Pupusas', N'Pupusa de frijol con queso', 0.85),
    (N'Pupusas', N'Pupusa de ayote con queso',  1.00),
    (N'Pupusas', N'Pupusa revuelta',            1.00),
    (N'Pupusas', N'Pupusa de chicharrón',       0.90),
    (N'Pupusas', N'Pupusa de loroco con queso', 0.90),
    (N'Pupusas', N'Pupusa de ajo',              1.00),
    (N'Pupusas', N'Pupusa de jalapeño',         1.00),
    (N'Pupusas', N'Pupusa loca',                1.50),
    (N'Bebidas calientes', N'Café',             1.00),
    (N'Bebidas calientes', N'Chocolate',        1.00),
    (N'Refrescos naturales', N'Limonada',       1.00),
    (N'Refrescos naturales', N'Jugo de naranja',1.50),
    (N'Refrescos naturales', N'Jugo de fresa',  1.50),
    (N'Sodas', N'Coca-cola',                    1.75),
    (N'Sodas', N'Coca-cola zero',               1.75),
    (N'Sodas', N'Pepsi',                        1.75),
    (N'Sodas', N'Mirinda',                      1.75)
) AS v (Categoria, Nombre, Precio)
JOIN Categoria c ON c.Nombre = v.Categoria;
GO

/* ==========================================================================
   8. VERIFICACIÓN: debe mostrar las 7 tablas con sus filas
   ========================================================================== */
SELECT t.name AS Tabla, SUM(p.rows) AS Filas
FROM sys.tables t
JOIN sys.partitions p ON p.object_id = t.object_id AND p.index_id IN (0, 1)
GROUP BY t.name
ORDER BY t.name;
GO
