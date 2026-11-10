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
    public partial class UcProductos : UserControl
    {
        CategoriaService _serviceCategoria = new();

        ProductoService _serviceProducto = new();

        private int idProductoSeleccionado = 0;
        public UcProductos()
        {

            InitializeComponent();
            cmbCategorias.SelectedIndexChanged += cmbCategorias_SelectedIndexChanged;
            CargarCategorias();
            filtroCategoria();
            txtBuscarProducto.TextChanged += (s, e) => buscarYFiltrar();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }




        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarYFiltrar();
            if (cmbCategorias.SelectedValue == null)
                return;

            if (!int.TryParse(cmbCategorias.SelectedValue.ToString(), out int idCategoria))
                return;

            List<Producto> productos;

            if (idCategoria == 0)
            {
                productos = _serviceProducto.listarProductos();
            }
            else
            {
                productos = _serviceProducto.filtrarPorCategoria(idCategoria);
            }

            dgvProductos.Rows.Clear();

            foreach (var item in productos)
            {
                dgvProductos.Rows.Add(
                    item.IdProducto,
                    item.Nombre,
                    item.Categoria.Nombre,
                    item.Precio
                );
            }
        }

        private void dgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            idProductoSeleccionado = Convert.ToInt32(fila.Cells["idCol"].Value);

            Producto producto = _serviceProducto.obtenerProducto(idProductoSeleccionado);

            if (producto == null)
                return;

            txtNombreProducto.Text = producto.Nombre;
            txtPrecioUnitario.Text = producto.Precio.ToString();

            cmbCategoriaProducto.SelectedValue = producto.IdCategoria;

            chkEstado.Checked = producto.Activo;
        }


        public void filtroCategoria()
        {
            List<Categoria> categorias = _serviceCategoria.ObtenerTodas().ToList();

            // Crear la opción "Todas las categorías"
            categorias.Insert(0, new Categoria
            {
                IdCategoria = 0,
                Nombre = "Todas las categorías"
            });

            cmbCategorias.DataSource = null;
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "IdCategoria";
            cmbCategorias.DataSource = categorias;

            cmbCategorias.SelectedValue = 0;
        }
        private void CargarCategorias()
        {
            cmbCategoriaProducto.DataSource = _serviceCategoria.ObtenerTodas();

            cmbCategoriaProducto.DisplayMember = "Nombre";
            cmbCategoriaProducto.ValueMember = "IdCategoria";

            cmbCategoriaProducto.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtNombreProducto.Clear();
            txtPrecioUnitario.Clear();
            cmbCategoriaProducto.SelectedIndex = -1;
            chkEstado.Checked = true;

            idProductoSeleccionado = 0;
        }


        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Selecciona un producto de la tabla para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string nombre = txtNombreProducto.Text.Trim();
            string precioTexto = txtPrecioUnitario.Text.Trim();

            // Validar campos vacíos
            List<string> faltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(nombre))
                faltantes.Add("Nombre del producto");

            if (cmbCategoriaProducto.SelectedIndex == -1)
                faltantes.Add("Categoría");

            if (string.IsNullOrWhiteSpace(precioTexto))
                faltantes.Add("Precio unitario");

            if (faltantes.Count > 0)
            {
                MessageBox.Show(
                    "Completa los siguientes campos:\n\n- " +
                    string.Join("\n- ", faltantes),
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validar precio
            if (!decimal.TryParse(precioTexto, out decimal precio) || precio <= 0)
            {
                MessageBox.Show(
                    "Introduce un precio numérico mayor que cero.",
                    "Precio inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPrecioUnitario.Focus();
                return;
            }

            // Obtener ID de categoría directamente del ComboBox
            int idCategoria = Convert.ToInt32(cmbCategoriaProducto.SelectedValue);

            // Crear producto utilizando el ID
            Producto producto = new Producto(
                nombre,
                precio,
                chkEstado.Checked,
                idCategoria
            );

            try
            {
                bool actualizado = _serviceProducto.actualizarProducto(
                    idProductoSeleccionado,
                    producto
                );

                if (actualizado)
                {
                    MessageBox.Show(
                        "Producto actualizado correctamente.",
                        "Actualización exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    filtroCategoria();
                    limpiar();
                }
                else
                {
                    MessageBox.Show(
                        "No se encontró el producto que deseas actualizar.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al actualizar el producto:\n\n" +
                    ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Obtener los valores
            string nombre = txtNombreProducto.Text.Trim();
            string precioTexto = txtPrecioUnitario.Text.Trim();

            // 2. Validar campos vacíos
            List<string> camposFaltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(nombre))
                camposFaltantes.Add("Nombre del producto");

            if (cmbCategoriaProducto.SelectedIndex == -1)
                camposFaltantes.Add("Categoría");

            if (string.IsNullOrWhiteSpace(precioTexto))
                camposFaltantes.Add("Precio unitario");

            if (camposFaltantes.Count > 0)
            {
                MessageBox.Show(
                    "Debes completar los siguientes campos:\n\n- " +
                    string.Join("\n- ", camposFaltantes),
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // 3. Validar precio
            if (!decimal.TryParse(precioTexto, out decimal precio))
            {
                MessageBox.Show(
                    "El precio debe ser un valor numérico válido.",
                    "Precio inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPrecioUnitario.Focus();
                return;
            }

            if (precio <= 0)
            {
                MessageBox.Show(
                    "El precio debe ser mayor que cero.",
                    "Precio inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPrecioUnitario.Focus();
                return;
            }

            // 4. Validar que no exista el producto
            if (_serviceProducto.ExisteProducto(nombre))
            {
                MessageBox.Show(
                    "Ya existe un producto registrado con ese nombre.",
                    "Producto duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombreProducto.Focus();
                return;
            }

            // 5. Obtener categoría seleccionada
            int idCategoria = Convert.ToInt32(
                cmbCategoriaProducto.SelectedValue
            );

            // 6. Crear producto
            Producto producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Activo = chkEstado.Checked,
                IdCategoria = idCategoria
            };

            // 7. Registrar
            _serviceProducto.crearProducto(producto);

            MessageBox.Show(
                "Producto registrado correctamente.",
                "Registro exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // 8. Actualizar listado y limpiar campos
            filtroCategoria();

            txtNombreProducto.Clear();
            txtPrecioUnitario.Clear();
            cmbCategoriaProducto.SelectedIndex = -1;
            chkEstado.Checked = true;

            txtNombreProducto.Focus();
        }

        private void buscarYFiltrar()
        {
            string texto = txtBuscarProducto.Text.Trim();

            int idCategoria = 0;

            if (cmbCategorias.SelectedValue != null)
            {
                int.TryParse(
                    cmbCategorias.SelectedValue.ToString(),
                    out idCategoria
                );
            }

            List<Producto> productos =
                _serviceProducto.buscarProductos(texto, idCategoria);

            dgvProductos.Rows.Clear();

            foreach (var item in productos)
            {
                dgvProductos.Rows.Add(
                    item.IdProducto,
                    item.Nombre,
                    item.Categoria.Nombre,
                    item.Precio,
                    item.Activo
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Selecciona un producto de la tabla.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string nombre = txtNombreProducto.Text.Trim();

            DialogResult resultado = MessageBox.Show(
                $"¿Deseas desactivar el producto '{nombre}'?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                bool desactivado = _serviceProducto.desactivarProducto(
                    idProductoSeleccionado
                );

                if (desactivado)
                {
                    MessageBox.Show(
                        "Producto desactivado correctamente.",
                        "Operación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    buscarYFiltrar();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al desactivar el producto:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }


}
