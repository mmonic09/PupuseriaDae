using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        public ICollection<Producto> Productos { get; set; }
            = new List<Producto>();
    }
}
