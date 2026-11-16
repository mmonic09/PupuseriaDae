using Pupuseria.data.Models;
using Pupuseria.Services;
using System;
using System.Collections.Generic;
using Pupuseria.data.entidades;   // para Usuario
using Pupuseria.helpers; // para Sesion
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pupuseria.Modulos
{
    public partial class UcVentas : UserControl
    {
        private ProductoService productoService = new ProductoService();
        private List<Producto> productos = new List<Producto>();
        private List<DetalleVenta> detallesVenta = new List<DetalleVenta>();
        private VentaService ventaService = new VentaService();

        public UcVentas()
        {
            InitializeComponent();
            CargarProductos();
            ConfigurarGrid();
            CargarDatosVenta();
        }

        // metodo para separar las bebidas de las pupusas
        private static bool EsPupusa(Producto p) =>
            string.Equals(p.Categoria?.Nombre, "Pupusas", StringComparison.OrdinalIgnoreCase);




        // metodo para cargar productos
        private void CargarProductos()
        {
            productos = productoService.listarProductos()
            .Where(p => p.Activo)
            .ToList();

            var pupusas = productos.Where(p => EsPupusa(p)).OrderBy(p => p.Nombre).ToList();
            var bebidas = productos.Where(p => !EsPupusa(p)).OrderBy(p => p.Nombre).ToList();

            cmbListaPupusas.DataSource = null;
            cmbListaPupusas.DataSource = pupusas;
            cmbListaPupusas.DisplayMember = "Nombre";
            cmbListaPupusas.ValueMember = "IdProducto";
            cmbListaPupusas.SelectedIndex = -1;

            cmbListaBebidas.DataSource = null;
            cmbListaBebidas.DataSource = bebidas;
            cmbListaBebidas.DisplayMember = "Nombre";
            cmbListaBebidas.ValueMember = "IdProducto";
            cmbListaBebidas.SelectedIndex = -1;
        }


        //private void pnlProductos_Paint(object sender, PaintEventArgs e)




        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListaPupusas.SelectedItem is Producto producto)
            {
                txtPrecioUnitarioPupusa.Text = producto.Precio.ToString("0.00");
            }
            else
            {
                txtPrecioUnitarioPupusa.Clear();
            }
        }




        private void ConfigurarGrid()
        {
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.Columns.Clear();

            dgvVentas.Columns.Add("Producto", "Producto");
            dgvVentas.Columns.Add("Cantidad", "Cantidad");
            dgvVentas.Columns.Add("PrecioUnitario", "Precio unitario");
            dgvVentas.Columns.Add("Subtotal", "Subtotal");

            dgvVentas.Columns["Producto"].DataPropertyName = "Producto";
            dgvVentas.Columns["Cantidad"].DataPropertyName = "Cantidad";
            dgvVentas.Columns["PrecioUnitario"].DataPropertyName = "PrecioUnitario";
            dgvVentas.Columns["Subtotal"].DataPropertyName = "Subtotal";

            dgvVentas.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
        }





        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var pupusa = cmbListaPupusas.SelectedItem as Producto;
            var bebida = cmbListaBebidas.SelectedItem as Producto;

            if (pupusa == null && bebida == null)
            {
                MessageBox.Show("Debe seleccionar una pupusa o una bebida.");
                return;
            }

            if (pupusa != null)
            {
                AgregarLinea(pupusa, (int)numCantidadPupusas.Value);
                cmbListaPupusas.SelectedIndex = -1;
                numCantidadPupusas.Value = 1;
                txtPrecioUnitarioPupusa.Clear();
            }

            if (bebida != null)
            {
                AgregarLinea(bebida, (int)numCantidadBebidas.Value);
                cmbListaBebidas.SelectedIndex = -1;
                numCantidadBebidas.Value = 1;
                txtPrecioUnitarioBebida.Clear();
            }

                ActualizarDetalle();
                MessageBox.Show("Producto agregado correctamente.");
                cmbListaBebidas.SelectedIndex = -1;
                cmbListaPupusas.SelectedIndex = -1;
            

            
        }





        //si el producto ya esta en el detalle, suma la cantidad, si no crea una nueva linea
        private void AgregarLinea(Producto producto, int cantidad)
        {
            var existente = detallesVenta.FirstOrDefault(d => d.IdProducto == producto.IdProducto);
            
            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }

            else
            {
                detallesVenta.Add(new DetalleVenta
                {
                    IdProducto = producto.IdProducto,
                    Producto = producto,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                });
            }
        }






        private void ActualizarDetalle()
        {
            dgvVentas.DataSource = null;

            dgvVentas.DataSource = detallesVenta
                .Select(p => new
                {
                    Producto = p.Producto.Nombre,
                    Cantidad = p.Cantidad,
                    PrecioUnitario = p.PrecioUnitario,
                    Subtotal = p.Cantidad * p.PrecioUnitario
                })
                .ToList();

            decimal total = detallesVenta.Sum(p =>
                p.Cantidad * p.PrecioUnitario);

            lblTotal.Text = total.ToString("C2");
        }





        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            int indice = dgvVentas.CurrentRow.Index;

            if (indice >= 0 && indice < detallesVenta.Count)
            {
                detallesVenta.RemoveAt(indice);

                ActualizarDetalle();

                MessageBox.Show("Producto eliminado del detalle.");
            }

        }




        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            try
            {
                // Validar usuario
                if (Sesion.UsuarioActual == null)
                {
                    MessageBox.Show("No hay un usuario con sesion iniciada. ");
                    return;
                }

                // Validar método de pago
                if (cmbMetodoPago.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un método de pago.");
                    return;
                }

                // Validar productos
                if (detallesVenta.Count == 0)
                {
                    MessageBox.Show("Debe agregar productos a la venta.");
                    return;
                }


                // Crear la venta
                Venta nuevaVenta = new Venta
                {
                    IdUsuario = Convert.ToInt32(cmbUsuarios.SelectedValue),
                    IdMetodoPago = Convert.ToInt32(cmbMetodoPago.SelectedValue),
                    Detalles = detallesVenta.Select(d => new DetalleVenta
                    {
                        IdProducto = d.IdProducto,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                };


                // Registrar la venta
                int idVenta = ventaService.crearVenta(nuevaVenta);

                MessageBox.Show(
                    "Venta registrada correctamente.\nNúmero de venta: " + idVenta,
                    "Venta confirmada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiar detalle
                detallesVenta.Clear();
                ActualizarDetalle();


                cmbMetodoPago.SelectedIndex = -1;
                cmbListaPupusas.SelectedIndex = -1;
                cmbListaBebidas.SelectedIndex = -1;
                numCantidadBebidas.Value = 1;
                numCantidadPupusas.Value = 1;
                txtPrecioUnitarioPupusa.Clear();
                txtPrecioUnitarioBebida.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message);
            }
        }





        private void CargarDatosVenta()
        {
            var actual = Sesion.UsuarioActual;
            cmbUsuarios.DataSource = null;

            if (actual != null)
            {
                cmbUsuarios.DataSource = new List<Usuario> { actual };
                cmbUsuarios.DisplayMember = "NombreCompleto";
                cmbUsuarios.ValueMember = "IdUsuario";
                cmbUsuarios.SelectedIndex = 0;
            }

            cmbUsuarios.Enabled = false;


            cmbMetodoPago.DataSource = null;
            cmbMetodoPago.DataSource = ventaService.listarMetodosPago();
            cmbMetodoPago.DisplayMember = "Nombre";
            cmbMetodoPago.ValueMember = "IdMetodoPago";
            cmbMetodoPago.SelectedIndex = -1;
        }





        private void cmbListaBebidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListaBebidas.SelectedItem is Producto bebida)
                txtPrecioUnitarioBebida.Text = bebida.Precio.ToString("0.00");
            else
                txtPrecioUnitarioBebida.Clear();
        }
    }


}
