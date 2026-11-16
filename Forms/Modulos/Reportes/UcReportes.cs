using Pupuseria.helpers;
using Pupuseria.Helpers;
using Pupuseria.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pupuseria.Modulos
{
    public partial class UcReportes : UserControl
    {
        private readonly ReporteService _servicio = new();

        //ultimo reporte generado, el pdf exporta exactamente esto
        private bool _hayReporte;
        private DateTime _desde, _hasta;
        private List<(int IdVenta, DateTime Fecha, string Vendedor, string MetodoPago, decimal Total)> _ventas = new();


        public UcReportes()
        {
            InitializeComponent();
        }

        private void UcReportes_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            ConfigurarGrid();

            var hoy = DateTime.Today;
            dtpFechaInicialReporte.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpFechaFinalReporte.Value = hoy;

            ActualizarResumen();

            // Se conectan DESPUÉS de poner las fechas, para que no se disparen al cargar
            dtpFechaInicialReporte.ValueChanged += (_, _) => ActualizarResumen();
            dtpFechaFinalReporte.ValueChanged += (_, _) => ActualizarResumen();
        }



        // ============================ GRID ============================
        private void ConfigurarGrid()
        {
            dgvReporteVentas.Columns.Clear();
            dgvReporteVentas.Columns.Add("colNumero", "No. Venta");
            dgvReporteVentas.Columns.Add("colFecha", "Fecha");
            dgvReporteVentas.Columns.Add("colVendedor", "Vendedor");
            dgvReporteVentas.Columns.Add("colMetodoPago", "Método de pago");
            dgvReporteVentas.Columns.Add("colTotal", "Total");
            dgvReporteVentas.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }




        // ========================= RESUMEN AUTOMÁTICO =========================
        // Se ejecuta al abrir la pantalla y cada vez que cambia una fecha
        private void ActualizarResumen()
        {
            var desde = dtpFechaInicialReporte.Value.Date;
            var hasta = dtpFechaFinalReporte.Value.Date;

            // Rango inválido: se limpian los datos sin alertas (el aviso sale al pulsar Generar)
            if (desde > hasta)
            {
                MostrarResumen(0, 0, "-");
                return;
            }

            try
            {
                var r = _servicio.ObtenerResumen(desde, hasta);
                MostrarResumen(r.Transacciones, r.Ingreso, r.ProductoEstrella);
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }

        private void MostrarResumen(int transacciones, decimal ingreso, string productoEstrella)
        {
            lblIngresoTotal.Text = $"${ingreso:N2}";
            lblTotalOrdenes.Text = transacciones.ToString();
            lblProductoEstrella.Text = productoEstrella;
        }





        /* ============================= DATOS ================================
        private void GenerarReporte()
        {
            var desde = dtpFechaInicialReporte.Value.Date;
            var hasta = dtpFechaFinalReporte.Value.Date;

            if (desde > hasta)
            {
                Mensajes.Aviso("La fecha inicial no puede ser posterior a la fecha final.");
                dtpFechaInicialReporte.Focus();
                return;
            }

            try
            {
                var resumen = _servicio.ObtenerResumen(desde, hasta);
                var categorias = _servicio.ObtenerVentasPorCategoria(desde, hasta);

                _desde = desde;
                _hasta = hasta;
                _transacciones = resumen.Transacciones;
                _ingreso = resumen.Ingreso;
                _productoEstrella = resumen.ProductoEstrella;
                _categorias = categorias;
                _hayReporte = true;

                lblIngresoTotal.Text = $"${_ingreso:N2}";
                lblTotalOrdenes.Text = _transacciones.ToString();
                lblProductoEstrella.Text = _productoEstrella;
                CargarGrafica();
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }*/


        /*private void CargarGrafica()
        {
            var serie = chtGraficaProductosVendidos.Series[0];
            serie.Points.Clear();
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.LabelFormat = "N2";

            foreach (var f in _categorias)
                serie.Points.AddXY(f.Categoria, f.Ingreso);
        }*/




        // =========================== BOTON PARA EXPORTAR REPORTE PDF =====================

        private void btnExportarPdfReporte_Click(object? sender, EventArgs e)
        {
            if (!_hayReporte)
            {
                Mensajes.Aviso("Genere el reporte antes de exportarlo.");
                return;
            }
            if (_ventas.Count == 0)
            {
                Mensajes.Aviso("No hay ventas en el reporte para exportar.");
                return;
            }

            using var dialogo = new SaveFileDialog
            {
                Filter = "Documento PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_Ventas_{_desde:yyyyMMdd}_{_hasta:yyyyMMdd}.pdf"
            };
            if (dialogo.ShowDialog() != DialogResult.OK) return;

            try
            {
                // El resumen se calcula con el mismo rango del reporte generado
                var r = _servicio.ObtenerResumen(_desde, _hasta);

                ReportePdf.Generar(dialogo.FileName, _desde, _hasta,
                    r.Transacciones, r.Ingreso, r.ProductoEstrella, _ventas);

                if (Mensajes.Confirmar("PDF generado correctamente.\n\n¿Desea abrirlo ahora?"))
                    Process.Start(new ProcessStartInfo(dialogo.FileName) { UseShellExecute = true });
            }
            catch (IOException)
            {
                Mensajes.Aviso("No se pudo guardar el archivo. Si ya está abierto en otro programa, ciérrelo e intente de nuevo.");
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }


        
        // ====================== BOTON PARA GENERAR REPORTE ==================

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            var desde = dtpFechaInicialReporte.Value.Date;
            var hasta = dtpFechaFinalReporte.Value.Date;

            if (desde > hasta)
            {
                Mensajes.Aviso("La fecha inicial no puede ser posterior a la fecha final.");
                dtpFechaInicialReporte.Focus();
                return;
            }

            try
            {
                var ventas = _servicio.ObtenerVentas(desde, hasta);

                dgvReporteVentas.Rows.Clear();
                foreach (var v in ventas)
                {
                    dgvReporteVentas.Rows.Add(
                        v.IdVenta,
                        v.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        v.Vendedor,
                        v.MetodoPago,
                        $"${v.Total:N2}");
                }

                _desde = desde;
                _hasta = hasta;
                _ventas = ventas;
                _hayReporte = true;

                ActualizarResumen();

                if (ventas.Count == 0)
                    Mensajes.Info("No hay ventas completadas en ese rango de fechas.");
            }
            catch (Exception ex)
            {
                Mensajes.ErrorDeDatos(ex);
            }
        }
    }
}
