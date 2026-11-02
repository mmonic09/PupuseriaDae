using BCrypt.Net; // Necesario para usar las funciones de BCrypt
using Pupuseria.data.contexto;
using Pupuseria.data.entidades;
using Pupuseria.Forms;
using Pupuseria.helpers;
using Pupuseria.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pupuseria.Autenticacion
{
    public partial class CambiarContraseña : Form
    {
        private readonly Usuario _usuario;
        private readonly UsuarioServicio _servicio = new();
        private readonly ErrorProvider _errores = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        private readonly TextBox _txtNueva = new() { UseSystemPasswordChar = true, MaxLength = 64 };
        private readonly TextBox _txtConfirmar = new() { UseSystemPasswordChar = true, MaxLength = 64 };
        private readonly int _idUsuario;

        public CambiarContraseña(Usuario usuario)
        {
            InitializeComponent(); // ¡ESTO ES LO QUE FALTABA! Carga todo el diseño visual.
            _usuario = usuario;

            //_txtNueva.TextChanged += (_, _) => _errores.SetError(_txtNueva, "");
            //_txtConfirmar.TextChanged += (_, _) => _errores.SetError(_txtConfirmar, "");
        }

        private void btnGuardar (object? sender, EventArgs e)
        {
            _errores.Clear();
            var fallos = new List<string>();
            Control? primero = null;

            void Fallo(Control control, string campo, string? error)
            {
                if (error == null) return;
                _errores.SetError(control, error);
                fallos.Add($"• {campo}: {error}");
                primero ??= control;
            }

            var errorNueva = Validacion.Clave(_txtNueva.Text);
            if (errorNueva == null && Seguridad.Hash(_txtNueva.Text) == _usuario.ClaveHash)
                errorNueva = "debe ser distinta de la contraseña temporal.";
            Fallo(_txtNueva, "Nueva contraseña", errorNueva);

            if (_txtConfirmar.Text.Length == 0)
                Fallo(_txtConfirmar, "Confirmar nueva contraseña", "repita la nueva contraseña.");
            else if (_txtConfirmar.Text != _txtNueva.Text)
                Fallo(_txtConfirmar, "Confirmar nueva contraseña", "no coincide con la nueva contraseña.");

            if (fallos.Count > 0)
            {
                Mensajes.Aviso("Corrija los siguientes campos:\n\n" + string.Join("\n", fallos));
                primero?.Focus();
                return;
            }

            try
            {
                _servicio.CambiarClave(_usuario.IdUsuario, _txtNueva.Text);
                Mensajes.Info("Contraseña actualizada correctamente.");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }
    }
}
