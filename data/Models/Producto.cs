using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.Models
{
    public class Producto
    {
        public Producto() { }

        public Producto(string nombre, decimal precio, bool activo, int categoria)
        {
            Nombre = nombre;
            Precio = precio;
            Activo = activo;
            IdCategoria = categoria;
        }

        public int IdProducto { get; set; }

        public int IdCategoria { get; set; }

        public string Nombre { get; set; } = "";

        public decimal Precio { get; set; }

        public bool Activo { get; set; }

        public Categoria Categoria { get; set; } = null!;

        public ICollection<DetalleVenta> DetallesVenta { get; set; }
            = new List<DetalleVenta>();
    }
}
