using Pupuseria.data.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.helpers
{
    // Guarda quién inició sesión mientras la aplicación está abierta
    public static class Sesion
    {
        public static Usuario? UsuarioActual { get; set; }

        public static bool EsAdministrador =>
            string.Equals(UsuarioActual?.Rol?.Nombre, "Administrador", StringComparison.OrdinalIgnoreCase);
    }
}
