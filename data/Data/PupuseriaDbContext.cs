using Microsoft.EntityFrameworkCore;
using Pupuseria.data.entidades;
using Pupuseria.data.Models;
using Pupuseria.data.Models.Pupuseria.data.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.contexto
{
    //se instancia pupuseria db context
    public class PupuseriaDbContext : DbContext
    {
        private const string Conexion =
            @"Server=PcDaniel\SQLEXPRESS02; Database=PupuseriaDB; Integrated Security=True; TrustServerCertificate=True;";

        // Tablas
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<MetodoPago> MetodosPago => Set<MetodoPago>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();

        protected override void OnConfiguring(
          DbContextOptionsBuilder options)
        {
           options.UseSqlServer(Conexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ==========================================
            // ROL
            // ==========================================

            modelBuilder.Entity<Rol>(e =>
            {
                e.ToTable("Rol");

                e.HasKey(r => r.IdRol);

                e.Property(r => r.IdRol)
                    .UseIdentityColumn();

                e.Property(r => r.Nombre)
                    .HasMaxLength(30)
                    .IsRequired();

                e.Property(r => r.Descripcion)
                    .HasMaxLength(100);

                e.Property(r => r.Activo)
                    .HasDefaultValue(true);

                e.HasIndex(r => r.Nombre)
                    .IsUnique()
                    .HasDatabaseName("UQ_Rol_Nombre");

                e.ToTable(t => t.HasCheckConstraint(
                    "CK_Rol_Nombre",
                    "LEN(LTRIM(RTRIM([Nombre]))) > 0"));
            });

            // ==========================================
            // USUARIO
            // ==========================================

            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuario");

                e.HasKey(u => u.IdUsuario);

                e.Property(u => u.IdUsuario)
                    .UseIdentityColumn();

                e.Property(u => u.NombreUsuario)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(u => u.ClaveHash)
                    .HasMaxLength(256)
                    .IsRequired();

                e.Property(u => u.DebeCambiarClave)
                    .HasDefaultValue(true);

                e.Property(u => u.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();

                e.Property(u => u.Apellido)
                    .HasMaxLength(100)
                    .IsRequired();

                e.Property(u => u.Activo)
                    .HasDefaultValue(true);

                e.Ignore(u => u.NombreCompleto);

                e.HasIndex(u => u.NombreUsuario)
                    .IsUnique()
                    .HasDatabaseName("UQ_Usuario_NombreUsuario");

                e.HasIndex(u => u.IdRol)
                    .HasDatabaseName("IX_Usuario_IdRol");

                e.HasOne(u => u.Rol)
 .WithMany()
 .HasForeignKey(u => u.IdRol);

                e.ToTable(t => t.HasCheckConstraint(
                    "CK_Usuario_NombreUsuario",
                    "LEN(LTRIM(RTRIM([NombreUsuario]))) > 0"));
            });

            // ==========================================
            // CATEGORIA
            // ==========================================

            modelBuilder.Entity<Categoria>(e =>
            {
                e.ToTable("Categoria");

                e.HasKey(c => c.IdCategoria);

                e.Property(c => c.IdCategoria)
                    .UseIdentityColumn();

                e.Property(c => c.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(c => c.Descripcion)
                    .HasMaxLength(100);

                e.Property(c => c.Activo)
                    .HasDefaultValue(true);

                e.HasIndex(c => c.Nombre)
                    .IsUnique()
                    .HasDatabaseName("UQ_Categoria_Nombre");

                e.ToTable(t => t.HasCheckConstraint(
                    "CK_Categoria_Nombre",
                    "LEN(LTRIM(RTRIM([Nombre]))) > 0"));
            });

            // ==========================================
            // METODO DE PAGO
            // ==========================================

            modelBuilder.Entity<MetodoPago>(e =>
            {
                e.ToTable("MetodoPago");

                e.HasKey(m => m.IdMetodoPago);

                e.Property(m => m.IdMetodoPago)
                    .UseIdentityColumn();

                e.Property(m => m.Nombre)
                    .HasMaxLength(30)
                    .IsRequired();

                e.Property(m => m.Activo)
                    .HasDefaultValue(true);

                e.HasIndex(m => m.Nombre)
                    .IsUnique()
                    .HasDatabaseName("UQ_MetodoPago_Nombre");

                e.ToTable(t => t.HasCheckConstraint(
                    "CK_MetodoPago_Nombre",
                    "LEN(LTRIM(RTRIM([Nombre]))) > 0"));
            });

            // ==========================================
            // PRODUCTO
            // ==========================================

            modelBuilder.Entity<Producto>(e =>
            {
                e.ToTable("Producto");

                e.HasKey(p => p.IdProducto);

                e.Property(p => p.IdProducto)
                    .UseIdentityColumn();

                e.Property(p => p.Nombre)
                    .HasMaxLength(80)
                    .IsRequired();

             

                e.Property(p => p.Precio)
                    .HasPrecision(10, 2);

                e.Property(p => p.Activo)
                    .HasDefaultValue(true);

       

                e.HasIndex(p => p.IdCategoria)
                    .HasDatabaseName("IX_Producto_IdCategoria");

                e.HasOne(p => p.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(p => p.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Producto_Categoria");

                e.ToTable(t =>
                {

                    t.HasCheckConstraint(
                        "CK_Producto_Nombre",
                        "LEN(LTRIM(RTRIM([Nombre]))) > 0");

                    t.HasCheckConstraint(
                        "CK_Producto_Precio",
                        "[Precio] > 0");
                });
            });

            // ==========================================
            // VENTA
            // ==========================================

            modelBuilder.Entity<Venta>(e =>
            {
                e.ToTable("Venta", t =>
                {
                    t.HasTrigger("trg_Venta_NoEliminar");

                    t.HasCheckConstraint(
                        "CK_Venta_Total",
                        "[Total] >= 0");

                    t.HasCheckConstraint(
                        "CK_Venta_Estado",
                        "[Estado] IN (N'Completada', N'Anulada')");
                });

                e.HasKey(v => v.IdVenta);

                // La identidad comienza en 1001
                e.Property(v => v.IdVenta)
                    .UseIdentityColumn(1001, 1);

                e.Property(v => v.Fecha)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("SYSDATETIME()");

                e.Property(v => v.Total)
                    .HasPrecision(10, 2)
                    .HasDefaultValue(0);

                e.Property(v => v.Estado)
                    .HasMaxLength(10)
                    .HasDefaultValue("Completada")
                    .IsRequired();

                e.HasIndex(v => v.Fecha)
                    .HasDatabaseName("IX_Venta_Fecha");

                e.HasIndex(v => v.IdUsuario)
                    .HasDatabaseName("IX_Venta_IdUsuario");

                e.HasIndex(v => v.IdMetodoPago)
                    .HasDatabaseName("IX_Venta_IdMetodoPago");

                e.HasOne(v => v.Usuario)
                    .WithMany(u => u.Ventas)
                    .HasForeignKey(v => v.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Venta_Usuario");

                e.HasOne(v => v.MetodoPago)
                    .WithMany(m => m.Ventas)
                    .HasForeignKey(v => v.IdMetodoPago)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Venta_MetodoPago");
            });

            // ==========================================
            // DETALLE DE VENTA
            // ==========================================

            modelBuilder.Entity<DetalleVenta>(e =>
            {
                e.ToTable("DetalleVenta", t =>
                {
                    t.HasTrigger("trg_DetalleVenta_NoEliminar");

                    t.HasCheckConstraint(
                        "CK_DetalleVenta_Cantidad",
                        "[Cantidad] > 0");

                    t.HasCheckConstraint(
                        "CK_DetalleVenta_Precio",
                        "[PrecioUnitario] >= 0");
                });

                e.HasKey(d => d.IdDetalleVenta);

                e.Property(d => d.IdDetalleVenta)
                    .UseIdentityColumn();

                e.Property(d => d.PrecioUnitario)
                    .HasPrecision(10, 2);

                // Columna calculada por SQL Server
                e.Property(d => d.Subtotal)
                    .HasPrecision(12, 2)
                    .HasComputedColumnSql(
                        "CAST([Cantidad] * [PrecioUnitario] AS DECIMAL(12,2))",
                        stored: true);

                e.HasIndex(d => new { d.IdVenta, d.IdProducto })
                    .IsUnique()
                    .HasDatabaseName("UQ_DetalleVenta_Venta_Producto");

                e.HasIndex(d => d.IdProducto)
                    .HasDatabaseName("IX_DetalleVenta_IdProducto");

                e.HasOne(d => d.Venta)
                    .WithMany(v => v.Detalles)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DetalleVenta_Venta");

                e.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallesVenta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_DetalleVenta_Producto");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
