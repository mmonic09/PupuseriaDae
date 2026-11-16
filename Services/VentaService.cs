using Microsoft.EntityFrameworkCore;
using Pupuseria.data.contexto;
using Pupuseria.data.entidades;
using Pupuseria.data.Models;
using Pupuseria.data.Models.Pupuseria.data.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.Services
{
    internal class VentaService
    {

        // Registrar venta y sus detalles
        public int crearVenta(Venta venta)
        {
            if (venta.Detalles == null || !venta.Detalles.Any())
                throw new Exception("Debe agregar productos a la venta.");

            using (var db = new PupuseriaDbContext())
            {
                bool usuarioValido = db.Usuarios.Any(u =>
                    u.IdUsuario == venta.IdUsuario && u.Activo);

                if (!usuarioValido)
                    throw new Exception("Seleccione un usuario válido.");

                bool metodoValido = db.MetodosPago.Any(m =>
                    m.IdMetodoPago == venta.IdMetodoPago && m.Activo);

                if (!metodoValido)
                    throw new Exception("Seleccione un método de pago válido.");

                foreach (var detalle in venta.Detalles)
                {
                    if (detalle.Cantidad <= 0 || detalle.PrecioUnitario <= 0)
                        throw new Exception("Hay productos con datos inválidos.");

                    bool productoValido = db.Productos.Any(p =>
                        p.IdProducto == detalle.IdProducto && p.Activo);

                    if (!productoValido)
                        throw new Exception("Uno de los productos no está disponible.");
                }

                venta.Fecha = DateTime.Now;
                venta.Estado = "Completada";
                venta.Total = venta.Detalles.Sum(d =>
                    d.Cantidad * d.PrecioUnitario);

                db.Ventas.Add(venta);
                db.SaveChanges();

                return venta.IdVenta;
            }
        }

        // Obtener venta por ID
        public Venta? obtenerVenta(int id)
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Ventas
                    .Include(v => v.Usuario)
                    .Include(v => v.MetodoPago)
                    .AsNoTracking()
                    .FirstOrDefault(v => v.IdVenta == id);
            }
        }

        // Listar usuarios activos
        public List<Usuario> listarUsuarios()
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Usuarios
                    .Where(u => u.Activo)
                    .ToList();
            }
        }

        // Listar métodos de pago activos
        public List<MetodoPago> listarMetodosPago()
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.MetodosPago
                    .Where(m => m.Activo)
                    .ToList();
            }
        }
    }
}
