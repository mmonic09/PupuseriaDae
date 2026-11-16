using Pupuseria.data.Models;
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
    public partial class UcCategorias : UserControl
    {
        CategoriaService _serviceCategoria = new();
        private int idCategoriaSeleccionada = 0;


        public UcCategorias()
        {
            InitializeComponent();

            configurarFiltroEstado();
            aplicarFiltros();
        }

        private void configurarFiltroEstado()
        {
            cmbFiltroEstado.Items.Clear();

            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activas");
            cmbFiltroEstado.Items.Add("Inactivas");

            cmbFiltroEstado.SelectedIndex = 0;

            cmbFiltroEstado.SelectedIndexChanged +=
                cmbFiltroEstado_SelectedIndexChanged;
        }



        private void aplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();

            bool? activo = null;

            if (cmbFiltroEstado.SelectedItem?.ToString() == "Activas")
                activo = true;
            else if (cmbFiltroEstado.SelectedItem?.ToString() == "Inactivas")
                activo = false;

            List<Categoria> categorias =
                _serviceCategoria.listarPorEstado(activo);

            if (!string.IsNullOrWhiteSpace(texto))
            {
                categorias = categorias
                    .Where(c => c.Nombre.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            mostrarCategorias(categorias);
        }



        private void mostrarCategorias(List<Categoria> categorias)
        {
            dgvCategorias.Rows.Clear();

            foreach (var item in categorias)
            {
                dgvCategorias.Rows.Add(
                    item.IdCategoria,
                    item.Nombre,
                    item.Activo ? "Activa" : "Inactiva"
                );
            }
        }




        private void cmbFiltroEstado_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            aplicarFiltros();
        }




        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            aplicarFiltros();
        }




        private void dgvCategorias_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];

            idCategoriaSeleccionada = Convert.ToInt32(
                fila.Cells["idCol"].Value
            );

            txtNombreCategoria.Text = fila.Cells["nombreCol"].Value.ToString();

            string estado = fila.Cells["estadoCol"].Value.ToString();

            tglEstado.Checked = estado == "Activa";
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una categoría primero.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas desactivar esta categoría?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                bool resultado = _serviceCategoria.desactivarCategoria(
                    idCategoriaSeleccionada
                );

                if (resultado)
                {
                    MessageBox.Show("Categoría desactivada correctamente.");

                    idCategoriaSeleccionada = 0;
                    aplicarFiltros();
                }
                else
                {
                    MessageBox.Show("No se pudo desactivar la categoría.");
                }
            }
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresa el nombre de la categoría.");
                return;
            }
            if (_serviceCategoria.existeCategoria(nombre))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre.");
                return;
            }
            Categoria categoria = new Categoria
            {
                Nombre = nombre,
                Activo = tglEstado.Checked
            };



            bool resultado = _serviceCategoria.crearCategoria(categoria);

            if (resultado)
            {
                MessageBox.Show("Categoría registrada correctamente.");

                txtNombreCategoria.Clear();

                tglEstado.Checked = true;

                aplicarFiltros();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la categoría.");
            }
        }




        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una categoría primero.");
                return;
            }

            string nombre = txtNombreCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.");
                return;
            }

            Categoria categoria = new Categoria
            {
                Nombre = nombre,
                Activo = tglEstado.Checked
            };

            bool resultado = _serviceCategoria.actualizarCategoria(
                idCategoriaSeleccionada,
                categoria
            );

            if (resultado)
            {
                MessageBox.Show("Categoría modificada correctamente.");

                idCategoriaSeleccionada = 0;
                txtNombreCategoria.Clear();
                tglEstado.Checked = true;

                aplicarFiltros();
            }
            else
            {
                MessageBox.Show("No se pudo modificar la categoría.");
            }
        }
    }
}
