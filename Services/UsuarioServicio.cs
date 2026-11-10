using Microsoft.EntityFrameworkCore;
using Pupuseria.data;
using Pupuseria.data.contexto;
using Pupuseria.data.entidades;
using Pupuseria.helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.Services
{
    public class UsuarioServicio
    {
        // Devuelve el usuario si las credenciales son correctas y está activo; si no, null
        public Usuario? Autenticar(string nombreUsuario, string clave)
        {
            using var db = new PupuseriaDbContext();
            var hash = Seguridad.Hash(clave);

            return db.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario
                                  && u.ClaveHash == hash
                                  && u.Activo
                                  && u.Rol.Activo);
        }

        public List<Rol> RolesActivos()
        {
            using var db = new PupuseriaDbContext();
            return db.Roles.AsNoTracking().Where(r => r.Activo).OrderBy(r => r.Nombre).ToList();
        }

        public List<Usuario> Listar(string? texto, bool? activo)
        {
            using var db = new PupuseriaDbContext();
            var consulta = db.Usuarios.Include(u => u.Rol).AsNoTracking().AsQueryable();

            if (activo.HasValue)
                consulta = consulta.Where(u => u.Activo == activo.Value);

            if (!string.IsNullOrWhiteSpace(texto))
            {
                var t = texto.Trim();
                consulta = consulta.Where(u => u.NombreUsuario.Contains(t)
                                            || u.Nombre.Contains(t)
                                            || u.Apellido.Contains(t));
            }

            return consulta.OrderBy(u => u.NombreUsuario).ToList();
        }

        public Usuario? Obtener(int idUsuario)
        {
            using var db = new PupuseriaDbContext();
            return db.Usuarios.Include(u => u.Rol).AsNoTracking().FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        // excluirId: al editar, se ignora al propio usuario
        public bool ExisteNombreUsuario(string nombreUsuario, int excluirId = 0)
        {
            using var db = new PupuseriaDbContext();
            return db.Usuarios.Any(u => u.NombreUsuario == nombreUsuario && u.IdUsuario != excluirId);
        }

        public void Crear(string nombre, string apellido, string nombreUsuario, int idRol, bool activo, string claveTemporal)
        {
            using var db = new PupuseriaDbContext();
            db.Usuarios.Add(new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                NombreUsuario = nombreUsuario,
                IdRol = idRol,
                Activo = activo,
                ClaveHash = Seguridad.Hash(claveTemporal),
                DebeCambiarClave = true      // la contraseña temporal obliga a cambiarla al entrar
            });
            db.SaveChanges();
        }

        public void Actualizar(int idUsuario, string nombre, string apellido, string nombreUsuario,
                               int idRol, bool activo, string? nuevaClaveTemporal)
        {
            using var db = new PupuseriaDbContext();
            var u = db.Usuarios.Find(idUsuario) ?? throw new InvalidOperationException("El usuario ya no existe.");

            u.Nombre = nombre;
            u.Apellido = apellido;
            u.NombreUsuario = nombreUsuario;
            u.IdRol = idRol;
            u.Activo = activo;

            if (!string.IsNullOrEmpty(nuevaClaveTemporal))
            {
                u.ClaveHash = Seguridad.Hash(nuevaClaveTemporal);
                u.DebeCambiarClave = true;
            }

            db.SaveChanges();
        }

        // No se borra: se desactiva para conservar el historial de ventas
        public void Desactivar(int idUsuario)
        {
            using var db = new PupuseriaDbContext();
            var u = db.Usuarios.Find(idUsuario) ?? throw new InvalidOperationException("El usuario ya no existe.");
            u.Activo = false;
            db.SaveChanges();
        }

        public void CambiarClave(int idUsuario, string nuevaClave)
        {
            if (string.IsNullOrWhiteSpace(nuevaClave))
                throw new ArgumentException("La nueva contraseña está llegando vacía.");

            using var db = new PupuseriaDbContext();
            var u = db.Usuarios.Find(idUsuario) ?? throw new InvalidOperationException("El usuario ya no existe.");
            u.ClaveHash = Seguridad.Hash(nuevaClave);
            u.DebeCambiarClave = false;
            db.SaveChanges();
        }
    }
}
