using Microsoft.EntityFrameworkCore;
using Pupuseria.data.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.contexto
{
    //se instancia pupuseria db context
    public class PupuseriaDbContext : DbContext
    {

        private const string Conexion =
            @"Server=PcDaniel\SQLEXPRESS02;Database=PupuseriaDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(Conexion);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().ToTable("Rol").HasKey(r => r.IdRol);

            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuario");
                e.HasKey(u => u.IdUsuario);
                e.HasOne(u => u.Rol).WithMany().HasForeignKey(u => u.IdRol);
            });
        }

    }
}
