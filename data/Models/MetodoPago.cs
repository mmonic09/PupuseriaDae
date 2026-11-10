using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.data.Models
{
    namespace Pupuseria.data.entidades
    {
        public class MetodoPago
        {
            public int IdMetodoPago { get; set; }
            public string Nombre { get; set; } = "";
            public bool Activo { get; set; }

            public ICollection<Venta> Ventas { get; set; }
                = new List<Venta>();
        }
    }
}
