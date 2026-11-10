using Pupuseria.data.Models;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pupuseria.data.entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreUsuario { get; set; } = "";
        public string ClaveHash { get; set; } = "";
        public bool DebeCambiarClave { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public bool Activo { get; set; }

        public Rol Rol { get; set; } = null!;

        public ICollection<Venta> Ventas { get; set; }
            = new List<Venta>();

        // Solo lectura: EF Core no la guarda en la base de datos
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
