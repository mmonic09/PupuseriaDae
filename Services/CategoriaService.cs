using Microsoft.EntityFrameworkCore;
using Pupuseria.data.contexto;
using Pupuseria.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.Services
{
    internal class CategoriaService
    {
        public bool crearCategoria(Categoria categoria)
        {
            using (var db = new PupuseriaDbContext())
            {
                db.Categorias.Add(categoria);

                return db.SaveChanges() > 0;
            }
        }


        public bool existeCategoria(string nombre)
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Categorias.Any(c =>
                    c.Nombre.ToLower() == nombre.ToLower());
            }
        }




        public bool actualizarCategoria(int id, Categoria categoriaActualizada)
        {
            using (var db = new PupuseriaDbContext())
            {
                Categoria? categoria = db.Categorias
                    .FirstOrDefault(c => c.IdCategoria == id);

                if (categoria == null)
                    return false;

                categoria.Nombre = categoriaActualizada.Nombre;
                categoria.Activo = categoriaActualizada.Activo;

                return db.SaveChanges() > 0;
            }
        }




        public List<Categoria> ObtenerTodas()
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Categorias
                    .AsNoTracking()
                    .Where(c => c.Activo)
                    .OrderBy(c => c.Nombre)
                    .ToList();
            }
        }




        public List<Categoria> listarPorEstado(bool? activo)
        {
            using (var db = new PupuseriaDbContext())
            {
                var consulta = db.Categorias
                    .AsNoTracking()
                    .AsQueryable();

                if (activo.HasValue)
                {
                    consulta = consulta.Where(c => c.Activo == activo.Value);
                }

                return consulta.ToList();
            }
        }



        public List<Categoria> buscarPorNombre(string texto)
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Categorias
                    .AsNoTracking()
                    .Where(c => c.Nombre.Contains(texto))
                    .ToList();
            }
        }




        public bool desactivarCategoria(int id)
        {
            using (var db = new PupuseriaDbContext())
            {
                Categoria? categoria = db.Categorias
                    .FirstOrDefault(c => c.IdCategoria == id);

                if (categoria == null)
                    return false;

                categoria.Activo = false;

                return db.SaveChanges() > 0;
            }
        }
    }
}
