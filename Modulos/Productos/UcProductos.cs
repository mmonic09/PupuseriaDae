using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pupuseria.Modulos
{
    public partial class UcProductos : UserControl
    {
        public UcProductos()
        {
            InitializeComponent();
            ConfigurarColumnas();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ConfigurarColumnas ()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("", "ID");
            dgvProductos.Columns.Add("", "Nombre del producto");
            dgvProductos.Columns.Add("", "Categoria");
            dgvProductos.Columns.Add("", "Precio ($)");
            dgvProductos.Columns.Add("", "Estado");

            dgvProductos.Rows.Add("#01", "Pupusa Queso con Loroco", "Pupusas", "$1.25", "");
            dgvProductos.Rows.Add("#02", "Pupusa Revuelta", "Pupusas", "$1.00", "");

            foreach (DataGridViewColumn col in dgvProductos.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
    
}
