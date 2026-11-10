CREATE DATABASE PupuseriaDB;
GO

USE PupuseriaDB;
GO

/* 1. ROLES */
IF OBJECT_ID(N'dbo.Rol', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Rol
    (
        IdRol INT IDENTITY(1,1) NOT NULL,
        Nombre NVARCHAR(30) NOT NULL,
        Descripcion NVARCHAR(100) NULL,
        Activo BIT NOT NULL CONSTRAINT DF_Rol_Activo DEFAULT (1),

        CONSTRAINT PK_Rol PRIMARY KEY (IdRol),
        CONSTRAINT UQ_Rol_Nombre UNIQUE (Nombre),
        CONSTRAINT CK_Rol_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
    );
END;
GO

/* 2. CATEGORIAS */
IF OBJECT_ID(N'dbo.Categoria', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categoria
    (
        IdCategoria INT IDENTITY(1,1) NOT NULL,
        Nombre NVARCHAR(50) NOT NULL,
        Descripcion NVARCHAR(100) NULL,
        Activo BIT NOT NULL CONSTRAINT DF_Categoria_Activo DEFAULT (1),

        CONSTRAINT PK_Categoria PRIMARY KEY (IdCategoria),
        CONSTRAINT UQ_Categoria_Nombre UNIQUE (Nombre),
        CONSTRAINT CK_Categoria_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
    );
END;
GO

/* 3. METODOS DE PAGO */
IF OBJECT_ID(N'dbo.MetodoPago', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MetodoPago
    (
        IdMetodoPago INT IDENTITY(1,1) NOT NULL,
        Nombre NVARCHAR(30) NOT NULL,
        Activo BIT NOT NULL CONSTRAINT DF_MetodoPago_Activo DEFAULT (1),

        CONSTRAINT PK_MetodoPago PRIMARY KEY (IdMetodoPago),
        CONSTRAINT UQ_MetodoPago_Nombre UNIQUE (Nombre),
        CONSTRAINT CK_MetodoPago_Nombre CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0)
    );
END;
GO

/* 4. USUARIOS */
IF OBJECT_ID(N'dbo.Usuario', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Usuario
    (
        IdUsuario INT IDENTITY(1,1) NOT NULL,
        IdRol INT NOT NULL,
        NombreUsuario NVARCHAR(50) NOT NULL,
        ClaveHash NVARCHAR(256) NOT NULL,
        DebeCambiarClave BIT NOT NULL
            CONSTRAINT DF_Usuario_DebeCambiarClave DEFAULT (1),
        Nombre NVARCHAR(100) NOT NULL,
        Apellido NVARCHAR(100) NOT NULL,
        Activo BIT NOT NULL CONSTRAINT DF_Usuario_Activo DEFAULT (1),

        CONSTRAINT PK_Usuario PRIMARY KEY (IdUsuario),
        CONSTRAINT UQ_Usuario_NombreUsuario UNIQUE (NombreUsuario),
        CONSTRAINT FK_Usuario_Rol
            FOREIGN KEY (IdRol) REFERENCES dbo.Rol (IdRol),
        CONSTRAINT CK_Usuario_NombreUsuario
            CHECK (LEN(LTRIM(RTRIM(NombreUsuario))) > 0)
    );
END;
GO

/* 5. PRODUCTOS */
IF OBJECT_ID(N'dbo.Producto', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Producto
    (
        IdProducto INT IDENTITY(1,1) NOT NULL,
        IdCategoria INT NOT NULL,
        Nombre NVARCHAR(80) NOT NULL,
        Precio DECIMAL(10,2) NOT NULL,
        Activo BIT NOT NULL CONSTRAINT DF_Producto_Activo DEFAULT (1),

        CONSTRAINT PK_Producto PRIMARY KEY (IdProducto),
        CONSTRAINT UQ_Producto_Nombre UNIQUE (Nombre),
        CONSTRAINT FK_Producto_Categoria
            FOREIGN KEY (IdCategoria) REFERENCES dbo.Categoria (IdCategoria),
        CONSTRAINT CK_Producto_Nombre
            CHECK (LEN(LTRIM(RTRIM(Nombre))) > 0),
        CONSTRAINT CK_Producto_Precio CHECK (Precio > 0)
    );
END;
GO

/* 6. VENTAS */
IF OBJECT_ID(N'dbo.Venta', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Venta
    (
        IdVenta INT IDENTITY(1001,1) NOT NULL,
        Fecha DATETIME2 NOT NULL
            CONSTRAINT DF_Venta_Fecha DEFAULT (SYSDATETIME()),
        IdUsuario INT NOT NULL,
        IdMetodoPago INT NOT NULL,
        Total DECIMAL(10,2) NOT NULL
            CONSTRAINT DF_Venta_Total DEFAULT (0),
        Estado NVARCHAR(10) NOT NULL
            CONSTRAINT DF_Venta_Estado DEFAULT (N'Completada'),

        CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
        CONSTRAINT FK_Venta_Usuario
            FOREIGN KEY (IdUsuario) REFERENCES dbo.Usuario (IdUsuario),
        CONSTRAINT FK_Venta_MetodoPago
            FOREIGN KEY (IdMetodoPago) REFERENCES dbo.MetodoPago (IdMetodoPago),
        CONSTRAINT CK_Venta_Total CHECK (Total >= 0),
        CONSTRAINT CK_Venta_Estado
            CHECK (Estado IN (N'Completada', N'Anulada'))
    );
END;
GO

/* 7. DETALLE DE VENTA */
IF OBJECT_ID(N'dbo.DetalleVenta', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DetalleVenta
    (
        IdDetalleVenta INT IDENTITY(1,1) NOT NULL,
        IdVenta INT NOT NULL,
        IdProducto INT NOT NULL,
        Cantidad INT NOT NULL,
        PrecioUnitario DECIMAL(10,2) NOT NULL,
        Subtotal AS CAST(Cantidad * PrecioUnitario AS DECIMAL(12,2)) PERSISTED,

        CONSTRAINT PK_DetalleVenta PRIMARY KEY (IdDetalleVenta),
        CONSTRAINT FK_DetalleVenta_Venta
            FOREIGN KEY (IdVenta) REFERENCES dbo.Venta (IdVenta),
        CONSTRAINT FK_DetalleVenta_Producto
            FOREIGN KEY (IdProducto) REFERENCES dbo.Producto (IdProducto),
        CONSTRAINT UQ_DetalleVenta_Venta_Producto UNIQUE (IdVenta, IdProducto),
        CONSTRAINT CK_DetalleVenta_Cantidad CHECK (Cantidad > 0),
        CONSTRAINT CK_DetalleVenta_Precio CHECK (PrecioUnitario >= 0)
    );
END;
GO

/* 8. INDICES */
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Usuario_IdRol' AND object_id = OBJECT_ID(N'dbo.Usuario'))
    CREATE INDEX IX_Usuario_IdRol ON dbo.Usuario (IdRol);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Producto_IdCategoria' AND object_id = OBJECT_ID(N'dbo.Producto'))
    CREATE INDEX IX_Producto_IdCategoria ON dbo.Producto (IdCategoria);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Venta_Fecha' AND object_id = OBJECT_ID(N'dbo.Venta'))
    CREATE INDEX IX_Venta_Fecha ON dbo.Venta (Fecha);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Venta_IdUsuario' AND object_id = OBJECT_ID(N'dbo.Venta'))
    CREATE INDEX IX_Venta_IdUsuario ON dbo.Venta (IdUsuario);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_Venta_IdMetodoPago' AND object_id = OBJECT_ID(N'dbo.Venta'))
    CREATE INDEX IX_Venta_IdMetodoPago ON dbo.Venta (IdMetodoPago);

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_DetalleVenta_IdProducto' AND object_id = OBJECT_ID(N'dbo.DetalleVenta'))
    CREATE INDEX IX_DetalleVenta_IdProducto ON dbo.DetalleVenta (IdProducto);
GO

/* 9. TRIGGERS */
CREATE OR ALTER TRIGGER dbo.trg_Venta_NoEliminar
ON dbo.Venta
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50001, N'No se pueden eliminar ventas. Cambie su estado a Anulada para conservar el historial.', 1;
END;
GO

CREATE OR ALTER TRIGGER dbo.trg_DetalleVenta_NoEliminar
ON dbo.DetalleVenta
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50002, N'No se pueden eliminar detalles de venta. Anule la venta para conservar el historial.', 1;
END;
GO

/* 10. DATOS INICIALES: ROLES */
IF NOT EXISTS (SELECT 1 FROM dbo.Rol WHERE Nombre = N'Administrador')
    INSERT INTO dbo.Rol (Nombre, Descripcion)
    VALUES (N'Administrador', N'Acceso total al sistema');

IF NOT EXISTS (SELECT 1 FROM dbo.Rol WHERE Nombre = N'Cajero')
    INSERT INTO dbo.Rol (Nombre, Descripcion)
    VALUES (N'Cajero', N'Registra y consulta ventas');
GO

/* 11. METODOS DE PAGO */
IF NOT EXISTS (SELECT 1 FROM dbo.MetodoPago WHERE Nombre = N'Efectivo')
    INSERT INTO dbo.MetodoPago (Nombre) VALUES (N'Efectivo');

IF NOT EXISTS (SELECT 1 FROM dbo.MetodoPago WHERE Nombre = N'Tarjeta')
    INSERT INTO dbo.MetodoPago (Nombre) VALUES (N'Tarjeta');

IF NOT EXISTS (SELECT 1 FROM dbo.MetodoPago WHERE Nombre = N'Transferencia')
    INSERT INTO dbo.MetodoPago (Nombre) VALUES (N'Transferencia');
GO

/* 12. USUARIO ADMINISTRADOR */
IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE NombreUsuario = N'admin')
BEGIN
    INSERT INTO dbo.Usuario
        (IdRol, NombreUsuario, ClaveHash, DebeCambiarClave, Nombre, Apellido)
    SELECT
        r.IdRol,
        N'admin',
        CONVERT(NVARCHAR(256), HASHBYTES('SHA2_256', 'Admin123'), 2),
        1,
        N'Administrador',
        N'Sistema'
    FROM dbo.Rol AS r
    WHERE r.Nombre = N'Administrador';
END;
GO

/* 13. CATEGORIAS DE PRUEBA */
IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE Nombre = N'Pupusas')
    INSERT INTO dbo.Categoria (Nombre, Descripcion)
    VALUES (N'Pupusas', N'Pupusas');

IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE Nombre = N'Refrescos naturales')
    INSERT INTO dbo.Categoria (Nombre, Descripcion)
    VALUES (N'Refrescos naturales', N'Jugos naturales');

IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE Nombre = N'Sodas')
    INSERT INTO dbo.Categoria (Nombre, Descripcion)
    VALUES (N'Sodas', N'Bebidas carbonatadas');

IF NOT EXISTS (SELECT 1 FROM dbo.Categoria WHERE Nombre = N'Bebidas calientes')
    INSERT INTO dbo.Categoria (Nombre, Descripcion)
    VALUES (N'Bebidas calientes', N'Café y chocolate');
GO

/* 14. PRODUCTOS DE PRUEBA */
DECLARE @Productos TABLE
(
    Categoria NVARCHAR(50),
    Nombre NVARCHAR(80),
    Precio DECIMAL(10,2)
);

INSERT INTO @Productos (Categoria, Nombre, Precio)
VALUES
(N'Pupusas', N'Pupusa de queso', 0.75),
(N'Pupusas', N'Pupusa de frijol con queso', 0.85),
(N'Pupusas', N'Pupusa de ayote con queso', 1.00),
(N'Pupusas', N'Pupusa revuelta', 1.00),
(N'Pupusas', N'Pupusa de chicharrón', 0.90),
(N'Pupusas', N'Pupusa de loroco con queso', 0.90),
(N'Pupusas', N'Pupusa de ajo', 1.00),
(N'Pupusas', N'Pupusa de jalapeño', 1.00),
(N'Pupusas', N'Pupusa loca', 1.50),
(N'Bebidas calientes', N'Café', 0.75),
(N'Bebidas calientes', N'Chocolate', 1.00),
(N'Refrescos naturales', N'Limonada', 1.00),
(N'Refrescos naturales', N'Jugo de naranja', 1.50),
(N'Refrescos naturales', N'Jugo de fresa', 1.50),
(N'Refrescos naturales', N'Refresco de horchata', 1.00),
(N'Sodas', N'Coca-cola', 1.75),
(N'Sodas', N'Coca-cola zero', 1.75),
(N'Sodas', N'Pepsi', 1.75),
(N'Sodas', N'Mirinda', 1.75);

INSERT INTO dbo.Producto (IdCategoria, Nombre, Precio)
SELECT c.IdCategoria, p.Nombre, p.Precio
FROM @Productos AS p
INNER JOIN dbo.Categoria AS c ON c.Nombre = p.Categoria
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Producto AS existente
    WHERE existente.Nombre = p.Nombre
);
GO

/* 15. VERIFICACION */
SELECT
    t.name AS Tabla,
    SUM(p.rows) AS Filas
FROM sys.tables AS t
INNER JOIN sys.partitions AS p
    ON p.object_id = t.object_id
   AND p.index_id IN (0, 1)
GROUP BY t.name
ORDER BY t.name;

SELECT
    u.IdUsuario,
    u.NombreUsuario,
    u.DebeCambiarClave,
    u.Activo,
    r.Nombre AS Rol
FROM dbo.Usuario AS u
INNER JOIN dbo.Rol AS r ON r.IdRol = u.IdRol;
GO