using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.Models
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; private set; }

        public Venta Venta { get; set; } = null!;
        public Producto Producto { get; set; } = null!;
    }
}
