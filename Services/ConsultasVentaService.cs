using Microsoft.EntityFrameworkCore;
using Pupuseria.data.contexto;
using Pupuseria.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.Services
{
    internal class ConsultasVentaService
    {
        public List<Venta> ObtenerVentas()
        {
            using (var contexto = new PupuseriaDbContext())
            {
                return contexto.Ventas
                    .Include(v => v.Usuario)
                    .Include(v => v.MetodoPago)
                    .OrderByDescending(v => v.Fecha)
                    .AsNoTracking()
                    .ToList();
            }
        }

        public List<Venta> BuscarVentas(
            DateTime fechaInicial,
            DateTime fechaFinal,
            string numeroVenta,
            string estado)
        {
            using (var contexto = new PupuseriaDbContext())
            {
                var consulta = contexto.Ventas
                    .Include(v => v.Usuario)
                    .Include(v => v.MetodoPago)
                    .AsQueryable();

                // Filtro por fecha
                consulta = consulta.Where(v =>
                    v.Fecha >= fechaInicial.Date &&
                    v.Fecha < fechaFinal.Date.AddDays(1));

                // Filtro por número de venta
                if (!string.IsNullOrWhiteSpace(numeroVenta))
                {
                    if (int.TryParse(numeroVenta, out int idVenta))
                    {
                        consulta = consulta.Where(v => v.IdVenta == idVenta);
                    }
                    else
                    {
                        return new List<Venta>();
                    }
                }

                // Filtro por estado
                if (!string.IsNullOrWhiteSpace(estado))
                {
                    consulta = consulta.Where(v =>
                        v.Estado.Contains(estado));
                }

                return consulta
                    .OrderByDescending(v => v.Fecha)
                    .AsNoTracking()
                    .ToList();
            }
        }
        

        public List<DetalleVenta> ObtenerDetallesVenta(int idVenta)
        {
            using (var contexto = new PupuseriaDbContext())
            {
                return contexto.DetallesVenta
                    .Include(d => d.Producto)
                    .Where(d => d.IdVenta == idVenta)
                    .AsNoTracking()
                    .ToList();
            }
        }
    }

}
