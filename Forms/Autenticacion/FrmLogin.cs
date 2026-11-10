using Pupuseria.Autenticacion;
using Pupuseria.data.contexto;
using Pupuseria.helpers;
using Pupuseria.Services;
using Pupuseria.Forms;
using Pupuseria.Modulos;



namespace Pupuseria.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioServicio _servicio = new();

        public FrmLogin()
        {
            InitializeComponent();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            Text = "Pupusería - Iniciar sesión";

            txtUsuario.MaxLength = 50;
            txtContrasena.MaxLength = 64;
            txtContrasena.UseSystemPasswordChar = true;

           
            btnLogin.Click += (_, _) => Ingresar();
            txtUsuario.KeyDown += EnterParaIngresar;
            txtContrasena.KeyDown += EnterParaIngresar;

            chkMostrarContrasena.CheckedChanged += (_, _) =>
                txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
        }

        private void EnterParaIngresar(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            Ingresar();
        }

        private void Ingresar()
        {
            var usuario = txtUsuario.Text.Trim();
            var clave = txtContrasena.Text;

            // Cualquier falla de credenciales muestra el MISMO mensaje (no se revela qué dato falló)
            if (usuario.Length == 0 || clave.Length == 0)
            {
                MostrarCredencialesIncorrectas();
                return;
            }

            try
            {
                var user = _servicio.Autenticar(usuario, clave);
                if (user == null)
                {
                    MostrarCredencialesIncorrectas();
                    return;
                }

                // Contraseña temporal: debe cambiarla antes de entrar
                if (user.DebeCambiarClave)
                {
                    using var cambiar = new CambiarContraseña(user);
                    if (cambiar.ShowDialog(this) != DialogResult.OK)
                    {
                        txtContrasena.Clear();
                        txtContrasena.Focus();
                        return;
                    }
                }

                Sesion.UsuarioActual = user;
                txtContrasena.Clear();

                // no cerramos login, solo lo ocultamos y abrimos FrmPrincipal como cuadro de diálogo
                this.Hide();
                using (var principal = new FrmPrincipal())
                {
                    principal.ShowDialog();
                }

                // Al cerrar sesión, el flujo regresa aquí y vuelve a mostrar el login limpio
                this.Show();
                txtUsuario.Clear();
                txtContrasena.Clear();
                txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                // Un fallo técnico (base de datos apagada, etc.) NO es "contraseña incorrecta"
                Mensajes.ErrorDeDatos(ex);
            }
        }

        private void MostrarCredencialesIncorrectas()
        {
            txtContrasena.Clear();                       // Clear dispara TextChanged y borra el mensaje...
            lblMensaje.Text = "Usuario o contraseña incorrectos.";   // ...por eso el mensaje va después
            txtContrasena.Focus();
        }

        // El diseñador conecta este evento; no lo borre
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }

}
