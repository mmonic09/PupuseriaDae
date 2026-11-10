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

        public List<(string Categoria, int Unidades, decimal Ingreso)> ObtenerVentasPorCategoria(DateTime desde, DateTime hasta)
        {
            using var db = new PupuseriaDbContext();
            var ini = desde.Date;
            var fin = hasta.Date.AddDays(1);

            var filas = db.DetallesVenta.AsNoTracking()
                .Where(d => d.Venta.Estado == "Completada" && d.Venta.Fecha >= ini && d.Venta.Fecha < fin)
                .GroupBy(d => d.Producto.Categoria.Nombre)
                .Select(g => new

                {
                    Categoria = g.Key,
                    Unidades = g.Sum(x => x.Cantidad),
                    Ingreso = g.Sum(x => x.Cantidad * x.PrecioUnitario)
                })
                .OrderByDescending(x => x.Ingreso)
                .ToList();

            return filas.Select(f => (f.Categoria, f.Unidades, f.Ingreso)).ToList();
        }
     }
 }

