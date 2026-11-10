using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
using Pupuseria.helpers;
using Pupuseria.Services;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pupuseria.Modulos
{
    public partial class UcReportes : UserControl
    {
        private readonly ReporteService _servicio = new();

        //ultimo reporte generado, el pdf exporta exactamente esto
        private bool _hayReporte;
        private DateTime _desde, _hasta;
        private int _transacciones;
        private decimal _ingreso;
        private string _productoEstrella = "—";
        private List<(string Categoria, int Unidades, decimal Ingreso)> _categorias = new();

        public UcReportes()
        {
            InitializeComponent();
            Load += UcReportes_Load;
            btnGenerarReporte.Click += (_, _) => GenerarReporte();
            btnExportarPdfReporte.Click += btnExportarPdfReporte_Click;
        }

        private void UcReportes_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            var hoy = DateTime.Today;
            dtpFechaInicialReporte.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpFechaFinalReporte.Value = hoy;
            chtGraficaProductosVendidos.Legends[0].Enabled = false;
            GenerarReporte();
        }


        // ============================= DATOS ================================
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
        }


        private void CargarGrafica()
        {
            var serie = chtGraficaProductosVendidos.Series[0];
            serie.Points.Clear();
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.LabelFormat = "N2";

            foreach (var f in _categorias)
                serie.Points.AddXY(f.Categoria, f.Ingreso);
        }



        private void btnExportarPdfReporte_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {

        }
    }
}
