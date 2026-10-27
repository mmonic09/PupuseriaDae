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
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void AbrirModulo(UserControl modulo)
        {
            while (pnlContenido.Controls.Count > 0)
                pnlContenido.Controls[0].Dispose();   // quita el módulo anterior

            modulo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(modulo);
            modulo.BringToFront();
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            AbrirModulo(new UcProductos());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UcUsuarios());
        }

        private void btnConsultaVentas_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UcConsultaVentas());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UcVentas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirModulo(new UcReportes());
        }
    }
}
