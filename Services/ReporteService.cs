using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pupuseria.data.contexto;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Pupuseria.Services
{
    // intermediario entre el servicio de reportes y sql
    internal class ReporteService


    {
        //cuántas ventas, cuánto dinero y cuál fue el producto más vendido.
        // Solo cuentan las ventas "Completada"; el día final entra completo.
        public (int Transacciones, decimal Ingreso, string ProductoEstrella) ObtenerResumen(DateTime desde, DateTime hasta)
        {
            using var db = new PupuseriaDbContext();
            var ini = desde.Date;
            var fin = hasta.Date.AddDays(1);

            var ventas = db.Ventas.AsNoTracking()
                .Where(v => v.Estado == "Completada" && v.Fecha >= ini && v.Fecha <= fin);

            var detalles = db.DetallesVenta.AsNoTracking()
                .Where(d => d.Venta.Estado == "Completada" && d.Venta.Fecha >= ini && d.Venta.Fecha < fin);

            var estrella = detalles
                .GroupBy(d => d.Producto.Nombre)
                .Select(g => new { Nombre = g.Key, Cantidad = g.Sum(x => x.Cantidad) })
                .OrderByDescending(x => x.Cantidad)
                .FirstOrDefault();

            return (
                ventas.Count(),
                ventas.Sum(v => (decimal?) v.Total) ?? 0,
                estrella?.Nombre ?? "-"
                );
            }

        public List<(int IdVenta, DateTime Fecha, string Vendedor, string MetodoPago, decimal Total)> ObtenerVentas(DateTime desde, DateTime hasta)
        {
            using var db = new PupuseriaDbContext();
            var ini = desde.Date;
            var fin = hasta.Date.AddDays(1);

            var filas = db.Ventas.AsNoTracking()
                .Where(v => v.Estado == "Completada" && v.Fecha >= ini && v.Fecha < fin)
                .OrderByDescending(v => v.Fecha)
                .Select(v => new
                {
                    v.IdVenta,
                    v.Fecha,
                    Vendedor = v.Usuario.Nombre + " " + v.Usuario.Apellido,
                    MetodoPago = v.MetodoPago.Nombre,
                    v.Total
                })
                .ToList();

            return filas.Select(f => (f.IdVenta, f.Fecha, f.Vendedor, f.MetodoPago, f.Total)).ToList();
        }
    }
 }

