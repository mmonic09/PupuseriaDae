using Guna.UI2.WinForms;
using Pupuseria.data.entidades;
using Pupuseria.helpers;
using Pupuseria.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pupuseria.Modulos
{
    public partial class UcUsuarios : UserControl
    {
        // Fila que se muestra en la tabla
        private sealed record UsuarioFila(int Id, string NombreUsuario, string NombreCompleto, string Rol, string Estado);

        private readonly UsuarioServicio _servicio = new();
        private readonly ErrorProvider _errores = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        private int _idEditando;        // 0 = usuario nuevo; mayor que 0 = editando ese usuario
        private bool _inicializado;

        public UcUsuarios()
        {
            InitializeComponent();
            ConfigurarControles();
            Load += UcUsuarios_Load;
        }

        // INICIO 
        private void UcUsuarios_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;

            if (!Sesion.EsAdministrador)
            {
                Enabled = false;
                Mensajes.Aviso("Este módulo es exclusivo del Administrador.");
                return;
            }

            try
            {
                CargarRoles();
                cmbFiltrarPorEstado.SelectedIndex = 0;
                _inicializado = true;
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }

        private void ConfigurarControles()
        {
            // Longitudes máximas (iguales a las columnas de la base de datos)
            txtNombre.MaxLength = 100;
            txtApellido.MaxLength = 100;
            txtUsuario.MaxLength = 50;
            txtContrasenaTemporal.MaxLength = 64;
            txtConfirmarContrasenaTemporal.MaxLength = 64;
            txtContrasenaTemporal.UseSystemPasswordChar = true;
            txtConfirmarContrasenaTemporal.UseSystemPasswordChar = true;

            txtBuscarProducto.PlaceholderText = "Buscar por usuario, nombre o apellido";
            btnEliminar.Text = "Desactivar";     // no se borra: se desactiva para conservar el historial
            cmbFiltrarPorEstado.Items.AddRange(new object[] { "Todos", "Activos", "Inactivos" });

            ConfigurarTabla();

            // Bloquea teclas inválidas mientras se escribe
            txtNombre.KeyPress += (_, e) => e.Handled = !Validacion.TeclaDePersona(e.KeyChar);
            txtApellido.KeyPress += (_, e) => e.Handled = !Validacion.TeclaDePersona(e.KeyChar);
            txtUsuario.KeyPress += (_, e) => e.Handled = !Validacion.TeclaDeUsuario(e.KeyChar);
            txtContrasenaTemporal.KeyPress += (_, e) => e.Handled = e.KeyChar == ' ';
            txtConfirmarContrasenaTemporal.KeyPress += (_, e) => e.Handled = e.KeyChar == ' ';

            // También limpia lo que se pegue con Ctrl+V
            txtNombre.TextChanged += (_, _) => Depurar(txtNombre, Validacion.TeclaDePersona);
            txtApellido.TextChanged += (_, _) => Depurar(txtApellido, Validacion.TeclaDePersona);
            txtUsuario.TextChanged += (_, _) => Depurar(txtUsuario, Validacion.TeclaDeUsuario);

            // Quita la marca de error en cuanto el usuario corrige el campo
            foreach (var caja in new[] { txtNombre, txtApellido, txtUsuario, txtContrasenaTemporal, txtConfirmarContrasenaTemporal })
                caja.TextChanged += (s, _) => _errores.SetError((Control)s!, "");
            cmbRol.SelectedIndexChanged += (_, _) => _errores.SetError(cmbRol, "");
            tswEstadoUsuario.CheckedChanged += (_, _) => _errores.SetError(tswEstadoUsuario, "");

            // Botones y filtros
            btnGuardar.Click += btnGuardar_Click;
            btnNuevoOLimpiar.Click += (_, _) => LimpiarFormulario();
            btnEditarSeleccionado.Click += (_, _) => EditarSeleccionado();
            btnEliminar.Click += btnEliminar_Click;
            txtBuscarProducto.TextChanged += (_, _) => CargarUsuarios();
            cmbFiltrarPorEstado.SelectedIndexChanged += (_, _) => CargarUsuarios();
        }

        private void ConfigurarTabla()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Columns.Add(Columna("NombreUsuario", "Usuario", 25));
            dgvUsuarios.Columns.Add(Columna("NombreCompleto", "Nombre completo", 35));
            dgvUsuarios.Columns.Add(Columna("Rol", "Rol", 25));
            dgvUsuarios.Columns.Add(Columna("Estado", "Estado", 15));
            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Tras cargar los datos no queda ninguna fila seleccionada (evita desactivar por accidente la primera)
            dgvUsuarios.DataBindingComplete += (_, _) => { dgvUsuarios.ClearSelection(); ActualizarConteos(); };
            dgvUsuarios.SelectionChanged += (_, _) => ActualizarConteos();
            dgvUsuarios.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) EditarSeleccionado(); };
        }

        private static DataGridViewTextBoxColumn Columna(string propiedad, string titulo, float peso) => new()
        {
            Name = "col" + propiedad,
            DataPropertyName = propiedad,
            HeaderText = titulo,
            FillWeight = peso,
            ReadOnly = true
        };

        // ============================ DATOS ============================
        private void CargarRoles()
        {
            cmbRol.DisplayMember = nameof(Rol.Nombre);
            cmbRol.ValueMember = nameof(Rol.IdRol);
            cmbRol.DataSource = _servicio.RolesActivos();
            cmbRol.SelectedIndex = -1;
        }

        private void CargarUsuarios()
        {
            if (!_inicializado) return;

            try
            {
                bool? activo = cmbFiltrarPorEstado.SelectedIndex switch { 1 => true, 2 => false, _ => null };

                dgvUsuarios.DataSource = _servicio.Listar(txtBuscarProducto.Text, activo)
                    .Select(u => new UsuarioFila(u.IdUsuario, u.NombreUsuario, u.NombreCompleto, u.Rol.Nombre,
                                                 u.Activo ? "Activo" : "Inactivo"))
                    .ToList();
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }

        private void ActualizarConteos()
        {
            lblCantidadResultadosPorFiltroDgv.Text = $"{dgvUsuarios.RowCount} resultados";
            lblCantidadSeleccionadoEnDgv.Text = $"{dgvUsuarios.SelectedRows.Count} seleccionado";

            // Reacomoda el separador y la segunda etiqueta según el ancho del texto
            guna2vSeparator1.Left = lblCantidadResultadosPorFiltroDgv.Right + 10;
            lblCantidadSeleccionadoEnDgv.Left = guna2vSeparator1.Right + 10;
        }

        private UsuarioFila? FilaSeleccionada() =>
            dgvUsuarios.SelectedRows.Count > 0 ? dgvUsuarios.SelectedRows[0].DataBoundItem as UsuarioFila : null;

        // ============================ FORMULARIO ============================
        private void LimpiarFormulario()
        {
            _idEditando = 0;
            _errores.Clear();

            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtContrasenaTemporal.Clear();
            txtConfirmarContrasenaTemporal.Clear();
            cmbRol.SelectedIndex = -1;
            tswEstadoUsuario.Checked = true;

            lblRegistro.Text = "Registro de Personal";
            lblContrasenaTemporal.Text = "Contraseña temporal";
            lblConfirmarContrasenaTemporal.Text = "Confirmar contraseña temporal";
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
        }

        private void EditarSeleccionado()
        {
            var fila = FilaSeleccionada();
            if (fila == null)
            {
                Mensajes.Aviso("Seleccione un usuario de la tabla para editarlo.");
                return;
            }

            try
            {
                var u = _servicio.Obtener(fila.Id);
                if (u == null)
                {
                    Mensajes.Aviso("El usuario ya no existe.");
                    CargarUsuarios();
                    return;
                }

                LimpiarFormulario();
                _idEditando = u.IdUsuario;
                txtNombre.Text = u.Nombre;
                txtApellido.Text = u.Apellido;
                txtUsuario.Text = u.NombreUsuario;
                cmbRol.SelectedValue = u.IdRol;
                tswEstadoUsuario.Checked = u.Activo;

                lblRegistro.Text = $"Editando usuario: {u.NombreUsuario}";
                lblContrasenaTemporal.Text = "Nueva contraseña temporal (opcional)";
                lblConfirmarContrasenaTemporal.Text = "Confirmar nueva contraseña temporal";
                btnGuardar.Text = "Guardar cambios";

                panel1.ScrollControlIntoView(pnlNuevoUsuario);
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }

        // ============================ VALIDACIÓN ============================
        // Marca cada campo con error y muestra un mensaje que dice EXACTAMENTE cuáles fallaron
        private bool ValidarFormulario()
        {
            _errores.Clear();
            var fallos = new List<(Control Control, string Mensaje)>();

            void Fallo(Control control, string campo, string? error)
            {
                if (error == null) return;
                _errores.SetError(control, error);
                fallos.Add((control, $"• {campo}: {error}"));
            }

            var nuevo = _idEditando == 0;

            Fallo(txtNombre, "Nombre", Validacion.NombrePersona(txtNombre.Text));
            Fallo(txtApellido, "Apellido", Validacion.NombrePersona(txtApellido.Text));

            var errorUsuario = Validacion.NombreUsuario(txtUsuario.Text);
            if (errorUsuario == null && _servicio.ExisteNombreUsuario(txtUsuario.Text.Trim(), _idEditando))
                errorUsuario = "ya existe otro usuario con ese nombre. Elija uno distinto.";
            Fallo(txtUsuario, "Usuario", errorUsuario);

            var rol = cmbRol.SelectedItem as Rol;
            if (rol == null)
                Fallo(cmbRol, "Rol del sistema", "seleccione un rol.");

            // La contraseña temporal es obligatoria al crear; al editar solo si se quiere restablecer
            var escribioClave = txtContrasenaTemporal.Text.Length > 0 || txtConfirmarContrasenaTemporal.Text.Length > 0;
            if (nuevo || escribioClave)
            {
                Fallo(txtContrasenaTemporal, "Contraseña temporal", Validacion.Clave(txtContrasenaTemporal.Text));

                if (txtConfirmarContrasenaTemporal.Text.Length == 0)
                    Fallo(txtConfirmarContrasenaTemporal, "Confirmar contraseña temporal", "repita la contraseña temporal.");
                else if (txtConfirmarContrasenaTemporal.Text != txtContrasenaTemporal.Text)
                    Fallo(txtConfirmarContrasenaTemporal, "Confirmar contraseña temporal", "no coincide con la contraseña temporal.");
            }

            // Reglas para que el administrador no se quede sin acceso
            if (!nuevo && _idEditando == Sesion.UsuarioActual?.IdUsuario)
            {
                if (!tswEstadoUsuario.Checked)
                    Fallo(tswEstadoUsuario, "Estado", "no puede desactivar su propio usuario.");

                if (rol != null && !string.Equals(rol.Nombre, "Administrador", StringComparison.OrdinalIgnoreCase))
                    Fallo(cmbRol, "Rol del sistema", "no puede quitarse a sí mismo el rol de Administrador.");
            }

            if (fallos.Count == 0) return true;

            Mensajes.Aviso("Corrija los siguientes campos:\n\n" + string.Join("\n", fallos.Select(f => f.Mensaje)));
            fallos[0].Control.Focus();
            return false;
        }

        // ============================ ACCIONES ============================
        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario()) return;

                var nombre = Validacion.Normalizar(txtNombre.Text);
                var apellido = Validacion.Normalizar(txtApellido.Text);
                var usuario = txtUsuario.Text.Trim();
                var idRol = Convert.ToInt32(cmbRol.SelectedValue);
                var activo = tswEstadoUsuario.Checked;
                var clave = txtContrasenaTemporal.Text;

                if (_idEditando == 0)
                {
                    _servicio.Crear(nombre, apellido, usuario, idRol, activo, clave);
                    Mensajes.Info($"Usuario «{usuario}» creado correctamente.\n\nAl iniciar sesión deberá cambiar su contraseña temporal.");
                }
                else
                {
                    _servicio.Actualizar(_idEditando, nombre, apellido, usuario, idRol, activo,
                                         clave.Length > 0 ? clave : null);
                    Mensajes.Info($"Usuario «{usuario}» actualizado correctamente.");
                }

                LimpiarFormulario();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            var fila = FilaSeleccionada();
            if (fila == null)
            {
                Mensajes.Aviso("Seleccione un usuario de la tabla para desactivarlo.");
                return;
            }

            if (fila.Id == Sesion.UsuarioActual?.IdUsuario)
            {
                Mensajes.Aviso("No puede desactivar su propio usuario.");
                return;
            }

            if (fila.Estado == "Inactivo")
            {
                Mensajes.Aviso($"El usuario «{fila.NombreUsuario}» ya está inactivo.");
                return;
            }

            if (!Mensajes.Confirmar($"¿Desactivar al usuario «{fila.NombreUsuario}»?\n\n" +
                                    "No se borra: se conserva su historial de ventas y podrá reactivarlo después " +
                                    "(Editar seleccionado → Estado → Guardar cambios)."))
                return;

            try
            {
                _servicio.Desactivar(fila.Id);
                if (_idEditando == fila.Id) LimpiarFormulario();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }

        // ============================ UTILIDADES ============================
        // Quita de la caja los caracteres no permitidos (por ejemplo, números pegados con Ctrl+V)
        private static void Depurar(Guna2TextBox caja, Func<char, bool> permitido)
        {
            var limpio = new string(caja.Text.Where(permitido).ToArray());
            if (limpio == caja.Text) return;

            var posicion = caja.SelectionStart;
            caja.Text = limpio;
            caja.SelectionStart = Math.Min(posicion, limpio.Length);
        }

        // El diseñador conecta este evento; no lo borre
        private void lblPrecioUnitario_Click(object sender, EventArgs e)
        {
        }
    }

}
