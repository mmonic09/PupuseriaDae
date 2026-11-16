using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pupuseria.Services;

namespace Pupuseria.Modulos
{
    public partial class UcConsultaVentas : UserControl
    {
        private readonly ConsultasVentaService servicio = new();
        public UcConsultaVentas()
        {
            InitializeComponent();

            CargarVentas();
            ConfigurarFormulario();
            btnVerDetalle.Enabled = false;
        }

        private void ConfigurarFormulario()
        {
            // Configurar contador de resultados
            lblCantidadResultadosPorFiltroDgv.AutoSize = true;

            // Configurar número de venta
            txtNumVentas.Text = "";
            txtNumVentas.PlaceholderText = "Ingrese el número de venta";

            // Configurar fechas
            dtpFechaInicial.Value = new DateTime(2020, 1, 1);
            dtpFechaFinal.Value = DateTime.Today;

            // Ajustar posición de la línea separadora
            guna2vSeparator1.Left =
                lblCantidadResultadosPorFiltroDgv.Right + 15;

            // Ajustar posición del contador de seleccionados
            lblCantidadSeleccionadoEnDgv.Left =
                guna2vSeparator1.Right + 15;



        }
        private void CargarVentas()
        {
            try
            {
                var ventas = servicio.ObtenerVentas();

                dgvUsuarios.DataSource = ventas.Select(v => new
                {
                    NumeroVenta = v.IdVenta,
                    Fecha = v.Fecha,
                    Usuario = v.Usuario.NombreCompleto,
                    MetodoPago = v.MetodoPago.Nombre,
                    Total = v.Total,
                    Estado = v.Estado
                }).ToList();

                ActualizarContadorResultados();

                lblCantidadSeleccionadoEnDgv.Text =
                    "Seleccionado: 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las ventas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }




        private void ActualizarContadorResultados()
        {
            int cantidad = dgvUsuarios.Rows.Count;

            lblCantidadResultadosPorFiltroDgv.Text =
                $"Resultados: {cantidad}";

            lblCantidadResultadosPorFiltroDgv.Refresh();
        }





        private void btnBuscarVentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFechaInicial.Value.Date > dtpFechaFinal.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha inicial no puede ser mayor que la fecha final.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var ventas = servicio.BuscarVentas(
                    dtpFechaInicial.Value,
                    dtpFechaFinal.Value,
                    txtNumVentas.Text.Trim(),
                    txtFiltrarEstadoVentas.Text.Trim()
                );

                dgvUsuarios.DataSource = ventas.Select(v => new
                {
                    NumeroVenta = v.IdVenta,
                    Fecha = v.Fecha,
                    Usuario = v.Usuario.NombreCompleto,
                    MetodoPago = v.MetodoPago.Nombre,
                    Total = v.Total,
                    Estado = v.Estado
                }).ToList();

                ActualizarContadorResultados();

                lblCantidadSeleccionadoEnDgv.Text =
                    "Seleccionado: 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar las ventas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }





        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            int cantidad = dgvUsuarios.SelectedRows.Count;

            lblCantidadSeleccionadoEnDgv.Text =
                "Seleccionado: " + cantidad;

            btnVerDetalle.Enabled = cantidad > 0;
        }






        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar una venta.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idVenta = Convert.ToInt32(
                dgvUsuarios.SelectedRows[0].Cells["NumeroVenta"].Value
            );

            var detalles = servicio.ObtenerDetallesVenta(idVenta);

            if (detalles.Count == 0)
            {
                MessageBox.Show(
                    "Esta venta no tiene productos registrados.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            string mensaje = "";

            foreach (var detalle in detalles)
            {
                mensaje +=
                    "Producto: " + detalle.Producto.Nombre + "\n" +
                    "Cantidad: " + detalle.Cantidad + "\n" +
                    "Precio: $" + detalle.PrecioUnitario.ToString("0.00") + "\n" +
                    "Subtotal: $" + detalle.Subtotal.ToString("0.00") + "\n\n";
            }

            MessageBox.Show(
                mensaje,
                "Detalle de la venta #" + idVenta,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

}