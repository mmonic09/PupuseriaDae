using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Pupuseria.helpers
{
    public static class Validacion
    {
        // Letras (con tildes y ñ) separadas por un espacio, apóstrofe o guion
        private static readonly Regex ReglaPersona = new(@"^\p{L}+([ '\-]\p{L}+)*$", RegexOptions.Compiled);
        private static readonly Regex ReglaUsuario = new(@"^[A-Za-z0-9._\-]+$", RegexOptions.Compiled);

        // Quita espacios al inicio/final y deja un solo espacio entre palabras
        public static string Normalizar(string? valor) =>
            Regex.Replace((valor ?? "").Trim(), @"\s+", " ");

        // ----- Teclas permitidas (se usan en el evento KeyPress) -----
        public static bool TeclaDePersona(char c) =>
            char.IsLetter(c) || c == ' ' || c == '\'' || c == '-' || char.IsControl(c);

        public static bool TeclaDeUsuario(char c) =>
            (c < 128 && char.IsLetterOrDigit(c)) || c == '.' || c == '_' || c == '-' || char.IsControl(c);

        // ----- Validaciones: devuelven el texto del error, o null si todo está bien -----
        public static string? NombrePersona(string? valor)
        {
            var v = Normalizar(valor);
            if (v.Length == 0) return "es obligatorio.";
            if (v.Length < 2) return "debe tener al menos 2 letras.";
            if (v.Length > 100) return "no puede superar los 100 caracteres.";
            if (v.Any(char.IsDigit)) return "no puede contener números.";
            if (!ReglaPersona.IsMatch(v)) return "solo puede contener letras, espacios, apóstrofe (') o guion (-).";
            return null;
        }

        public static string? NombreUsuario(string? valor)
        {
            var v = (valor ?? "").Trim();
            if (v.Length == 0) return "es obligatorio.";
            if (v.Length < 4) return "debe tener al menos 4 caracteres.";
            if (v.Length > 50) return "no puede superar los 50 caracteres.";
            if (v.Contains(' ')) return "no puede contener espacios.";
            if (!ReglaUsuario.IsMatch(v))
                return "solo puede contener letras (sin tildes ni ñ), números, punto, guion y guion bajo.";
            return null;
        }

        public static string? Clave(string? valor)
        {
            var v = valor ?? "";
            if (v.Length == 0) return "es obligatoria.";
            if (v.Length < 8) return "debe tener al menos 8 caracteres.";
            if (v.Length > 64) return "no puede superar los 64 caracteres.";
            if (v.Contains(' ')) return "no puede contener espacios.";
            if (!v.Any(char.IsLetter) || !v.Any(char.IsDigit)) return "debe incluir al menos una letra y un número.";
            return null;
        }
    }
}
