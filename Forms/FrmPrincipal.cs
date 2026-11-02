using Pupuseria.helpers;
using Pupuseria.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pupuseria.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            MostrarDatosDeSesion();
        }

        private void MostrarDatosDeSesion()
        {
            var u = Sesion.UsuarioActual;
            if (u == null) return;

            label1.Text = u.NombreCompleto;                 // antes: "Nombre Empleado"
            lblRol.Text = u.Rol.Nombre;                     // antes: "Administrador / Cajero"
            btnUsuarios.Visible = Sesion.EsAdministrador;   // módulo exclusivo del administrador
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void AbrirModulo(UserControl modulo, string titulo)
        {
            while (pnlContenido.Controls.Count > 0)
                pnlContenido.Controls[0].Dispose();   // quita el módulo anterior

            modulo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(modulo);
            lblHeaderTitulo.Text = titulo;
            modulo.BringToFront();
        }

        private void btnProductos_Click_1(object sender, EventArgs e) => AbrirModulo(new UcProductos(), "Gestion de Productos");
        private void btnUsuarios_Click(object sender, EventArgs e) => AbrirModulo(new UcUsuarios(), "Gestion de Usuarios");
        private void btnConsultaVentas_Click(object sender, EventArgs e) => AbrirModulo(new UcConsultaVentas(), "Consulta de Ventas");
        private void btnVentas_Click(object sender, EventArgs e) => AbrirModulo(new UcVentas(), "Nueva venta");
        private void btnReportes_Click(object sender, EventArgs e) => AbrirModulo(new UcReportes(), "Reportes del sistema");


        //cerrar sesion
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Preguntar si desea cerrar sesión
            var resultado = MessageBox.Show("¿Estas seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Creamos y mostramos la pantalla de Login nuevamente
                //FrmLogin login = new FrmLogin();
                //login.Show();

                // Cerramos por completo el formulario principal actual
                this.Close();
            }
        }
    }
}
