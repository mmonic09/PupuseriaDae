using Pupuseria.data.entidades;
using Pupuseria.data.Models.Pupuseria.data.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Completada";

        public Usuario Usuario { get; set; } = null!;
        public MetodoPago MetodoPago { get; set; } = null!;

        public ICollection<DetalleVenta> Detalles { get; set; }
            = new List<DetalleVenta>();
    }
}
