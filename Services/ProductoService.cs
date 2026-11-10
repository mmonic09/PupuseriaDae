using Microsoft.EntityFrameworkCore;
using Pupuseria.data.contexto;
using Pupuseria.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.Services
{
    internal class ProductoService
    {

        public void crearProducto(Producto producto)
        {
            using (var db = new PupuseriaDbContext())
            {

                db.Productos.Add(producto);

                db.SaveChanges();
            }
        }

        public Producto? obtenerProducto(int id)
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Productos
                    .Include(p => p.Categoria)
                    .AsNoTracking()
                    .FirstOrDefault(p => p.IdProducto == id);
            }
        }

        public bool actualizarProducto(int id, Producto productoActualizado)
        {

            using (var db = new PupuseriaDbContext())
            {
                // Buscar el producto existente
                Producto? producto = db.Productos
                    .FirstOrDefault(p => p.IdProducto == id);

                if (producto == null)
                {
                    return false;
                }

                // Comprobar si otro producto tiene el mismo nombre
                bool existe = db.Productos.Any(p =>
                    p.Nombre.ToLower() == productoActualizado.Nombre.ToLower()
                    && p.IdProducto != id);

                if (existe)
                {
                    throw new Exception("Ya existe otro producto con ese nombre.");
                }


                // Actualizar propiedades
                producto.Nombre = productoActualizado.Nombre;
                producto.Categoria = productoActualizado.Categoria;
                producto.Precio = productoActualizado.Precio;
                producto.Activo = productoActualizado.Activo;

                return db.SaveChanges() > 0;
            }
        }

        public bool ExisteProducto(string nombre)
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Productos
                    .Any(p => p.Nombre.ToLower() == nombre.ToLower());
            }
        }

        public List<Producto> listarProductos()
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Productos
                    .AsNoTracking()
                    .Include(p => p.Categoria)
                    .ToList();
            }
        }

        public List<Producto> filtrarPorCategoria(int idCategoria)
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Productos
                    .Include(p => p.Categoria)
                    .AsNoTracking()
                    .Where(p => p.IdCategoria == idCategoria)
                    .ToList();
            }
        }

        public List<Producto> buscarProductos(string texto, int idCategoria = 0)
        {
            using (var db = new PupuseriaDbContext())
            {
                var consulta = db.Productos
                    .Include(p => p.Categoria)
                    .AsNoTracking()
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    consulta = consulta.Where(p =>
                        p.Nombre.Contains(texto));
                }

                if (idCategoria != 0)
                {
                    consulta = consulta.Where(p =>
                        p.IdCategoria == idCategoria);
                }

                return consulta.ToList();
            }
        }

        public bool desactivarProducto(int id)
        {
            using (var db = new PupuseriaDbContext())
            {
                Producto? producto = db.Productos
                    .FirstOrDefault(p => p.IdProducto == id);

                if (producto == null)
                    return false;

                producto.Activo = false;

                return db.SaveChanges() > 0;
            }
        }
    }

   
    }
