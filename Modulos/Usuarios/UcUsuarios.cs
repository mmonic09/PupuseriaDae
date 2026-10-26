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
        public UcUsuarios()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Columns.Add("", "ID");
            dgvUsuarios.Columns.Add("", "Usuario");
            dgvUsuarios.Columns.Add("", "Categoria");
            dgvUsuarios.Columns.Add("", "Precio ($)");
            dgvUsuarios.Columns.Add("", "Estado");

            dgvUsuarios.Rows.Add("#01", "Pupusa Queso con Loroco", "Pupusas", "$1.25", "");
            dgvUsuarios.Rows.Add("#02", "Pupusa Revuelta", "Pupusas", "$1.00", "");

            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void lblPrecioUnitario_Click(object sender, EventArgs e)
        {

        }
    }

}
