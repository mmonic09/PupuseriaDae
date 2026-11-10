USE PupuseriaDB

/* DATOS INICIALES (necesarios para poder usar el sistema) */
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

/* DATOS DE PRUEBA (opcionales) */
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
    (N'Pupusas', N'Pupusa de frijol con queso', 0.85),
    (N'Pupusas', N'Pupusa revuelta',            1.00),
    (N'Pupusas', N'Pupusa de chicharrón',       0.90),
    (N'Pupusas', N'Pupusa de loroco con queso', 0.90),
    (N'Pupusas', N'Pupusa de ajo',              1.00),
    (N'Pupusas', N'Pupusa de jalapeño',         1.00),
    (N'Pupusas', N'Pupusa loca',                1.50),
    (N'Bebidas', N'Refresco de horchata',       1.00),
    (N'Bebidas', N'Café',                       0.75)
) AS v (Categoria, Nombre, Precio)
JOIN Categoria c ON c.Nombre = v.Categoria;
GO