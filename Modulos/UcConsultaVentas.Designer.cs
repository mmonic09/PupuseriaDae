namespace Pupuseria.Modulos
{
    partial class UcConsultaVentas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            pnlEncabezado = new Panel();
            lblTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblSubtitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnlFiltro = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblFiltros = new Label();
            lblFechaInicial = new Label();
            dtpFechaInicial = new DateTimePicker();
            lblFechaFinal = new Label();
            dtpFechaFinal = new DateTimePicker();
            lblNumeroVentas = new Label();
            txtVentas = new TextBox();
            btnBuscar = new Guna.UI2.WinForms.Guna2Button();
            pnlTablaVentas = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblHistorial = new Label();
            dgvVentas = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            pnlTotal = new Guna.UI2.WinForms.Guna2Panel();
            lblTotalVenta = new Label();
            btnVerDetalle = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            pnlFiltro.SuspendLayout();
            pnlTablaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            pnlTotal.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(251, 249, 246);
            panel1.Controls.Add(btnVerDetalle);
            panel1.Controls.Add(pnlTotal);
            panel1.Controls.Add(pnlTablaVentas);
            panel1.Controls.Add(pnlFiltro);
            panel1.Controls.Add(pnlEncabezado);
            panel1.Location = new Point(0, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1119, 718);
            panel1.TabIndex = 0;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(62, 39, 36);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(1119, 84);
            pnlEncabezado.TabIndex = 0;
            pnlEncabezado.Paint += pnlEncabezado_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.ForeColor = Color.FromArgb(251, 249, 246);
            lblTitulo.Location = new Point(15, 3);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(259, 43);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Consulta de Ventas";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = Color.Transparent;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(251, 249, 246);
            lblSubtitulo.Location = new Point(15, 47);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(261, 25);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Historial de Venta de la Pupuseria";
            // 
            // pnlFiltro
            // 
            pnlFiltro.BackColor = Color.White;
            pnlFiltro.BorderColor = Color.FromArgb(215, 204, 200);
            pnlFiltro.BorderRadius = 10;
            pnlFiltro.BorderThickness = 1;
            pnlFiltro.Controls.Add(btnBuscar);
            pnlFiltro.Controls.Add(txtVentas);
            pnlFiltro.Controls.Add(lblFechaFinal);
            pnlFiltro.Controls.Add(lblNumeroVentas);
            pnlFiltro.Controls.Add(dtpFechaFinal);
            pnlFiltro.Controls.Add(dtpFechaInicial);
            pnlFiltro.Controls.Add(lblFiltros);
            pnlFiltro.Controls.Add(lblFechaInicial);
            pnlFiltro.CustomizableEdges = customizableEdges9;
            pnlFiltro.Location = new Point(25, 105);
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlFiltro.Size = new Size(1069, 180);
            pnlFiltro.TabIndex = 1;
            // 
            // lblFiltros
            // 
            lblFiltros.AutoSize = true;
            lblFiltros.Font = new Font("Segoe UI", 12F);
            lblFiltros.ForeColor = Color.FromArgb(62, 39, 35);
            lblFiltros.Location = new Point(3, 10);
            lblFiltros.Name = "lblFiltros";
            lblFiltros.Size = new Size(183, 28);
            lblFiltros.TabIndex = 0;
            lblFiltros.Text = "Filtros de Busqueda";
            // 
            // lblFechaInicial
            // 
            lblFechaInicial.AutoSize = true;
            lblFechaInicial.Location = new Point(14, 55);
            lblFechaInicial.Name = "lblFechaInicial";
            lblFechaInicial.Size = new Size(90, 20);
            lblFechaInicial.TabIndex = 2;
            lblFechaInicial.Text = "Fecha Inicial";
            // 
            // dtpFechaInicial
            // 
            dtpFechaInicial.Format = DateTimePickerFormat.Short;
            dtpFechaInicial.Location = new Point(14, 78);
            dtpFechaInicial.Name = "dtpFechaInicial";
            dtpFechaInicial.Size = new Size(220, 27);
            dtpFechaInicial.TabIndex = 3;
            // 
            // lblFechaFinal
            // 
            lblFechaFinal.AutoSize = true;
            lblFechaFinal.Location = new Point(272, 55);
            lblFechaFinal.Name = "lblFechaFinal";
            lblFechaFinal.Size = new Size(82, 20);
            lblFechaFinal.TabIndex = 3;
            lblFechaFinal.Text = "Fecha Final";
            // 
            // dtpFechaFinal
            // 
            dtpFechaFinal.Format = DateTimePickerFormat.Short;
            dtpFechaFinal.Location = new Point(272, 78);
            dtpFechaFinal.Name = "dtpFechaFinal";
            dtpFechaFinal.Size = new Size(220, 27);
            dtpFechaFinal.TabIndex = 4;
            // 
            // lblNumeroVentas
            // 
            lblNumeroVentas.AutoSize = true;
            lblNumeroVentas.Location = new Point(531, 55);
            lblNumeroVentas.Name = "lblNumeroVentas";
            lblNumeroVentas.Size = new Size(131, 20);
            lblNumeroVentas.TabIndex = 4;
            lblNumeroVentas.Text = "Numero de Ventas";
            // 
            // txtVentas
            // 
            txtVentas.Location = new Point(531, 78);
            txtVentas.Name = "txtVentas";
            txtVentas.PlaceholderText = "Ingrese el Numero de Ventas";
            txtVentas.Size = new Size(250, 27);
            txtVentas.TabIndex = 5;
            // 
            // btnBuscar
            // 
            btnBuscar.BorderRadius = 8;
            btnBuscar.CustomizableEdges = customizableEdges7;
            btnBuscar.DisabledState.BorderColor = Color.DarkGray;
            btnBuscar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBuscar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBuscar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBuscar.FillColor = Color.FromArgb(230, 81, 0);
            btnBuscar.Font = new Font("Segoe UI", 9F);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(820, 65);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnBuscar.Size = new Size(225, 56);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar Ventas";
            // 
            // pnlTablaVentas
            // 
            pnlTablaVentas.BackColor = Color.White;
            pnlTablaVentas.BorderColor = Color.FromArgb(215, 204, 200);
            pnlTablaVentas.BorderRadius = 10;
            pnlTablaVentas.BorderThickness = 1;
            pnlTablaVentas.Controls.Add(dgvVentas);
            pnlTablaVentas.Controls.Add(lblHistorial);
            pnlTablaVentas.CustomizableEdges = customizableEdges5;
            pnlTablaVentas.Location = new Point(25, 305);
            pnlTablaVentas.Name = "pnlTablaVentas";
            pnlTablaVentas.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlTablaVentas.Size = new Size(1069, 330);
            pnlTablaVentas.TabIndex = 2;
            // 
            // lblHistorial
            // 
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Segoe UI", 12F);
            lblHistorial.Location = new Point(20, 15);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(174, 28);
            lblHistorial.TabIndex = 3;
            lblHistorial.Text = "Historial de Ventas";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 201, 197);
            dgvVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvVentas.BackgroundColor = Color.FromArgb(251, 249, 246);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(249, 219, 216);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(239, 135, 125);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvVentas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvVentas.GridColor = Color.FromArgb(245, 192, 188);
            dgvVentas.Location = new Point(20, 50);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(1029, 260);
            dgvVentas.TabIndex = 4;
            dgvVentas.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Alizarin;
            dgvVentas.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 201, 197);
            dgvVentas.ThemeStyle.BackColor = Color.FromArgb(251, 249, 246);
            dgvVentas.ThemeStyle.GridColor = Color.FromArgb(245, 192, 188);
            dgvVentas.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(231, 76, 60);
            dgvVentas.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvVentas.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.ThemeStyle.HeaderStyle.Height = 22;
            dgvVentas.ThemeStyle.ReadOnly = true;
            dgvVentas.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(249, 219, 216);
            dgvVentas.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvVentas.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            dgvVentas.ThemeStyle.RowsStyle.Height = 29;
            dgvVentas.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(239, 135, 125);
            dgvVentas.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // Column1
            // 
            Column1.HeaderText = "N° De Ventas";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Fecha";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Total";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Usuario que Registro";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // pnlTotal
            // 
            pnlTotal.BackColor = Color.FromArgb(244, 232, 221);
            pnlTotal.BorderRadius = 8;
            pnlTotal.Controls.Add(lblTotalVenta);
            pnlTotal.CustomizableEdges = customizableEdges3;
            pnlTotal.Location = new Point(25, 650);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlTotal.Size = new Size(420, 50);
            pnlTotal.TabIndex = 3;
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.Font = new Font("Segoe UI", 14F);
            lblTotalVenta.Location = new Point(84, 9);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(245, 32);
            lblTotalVenta.TabIndex = 4;
            lblTotalVenta.Text = "Total de Ventas: $0.00";
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.BorderRadius = 8;
            btnVerDetalle.CustomizableEdges = customizableEdges1;
            btnVerDetalle.DisabledState.BorderColor = Color.DarkGray;
            btnVerDetalle.DisabledState.CustomBorderColor = Color.DarkGray;
            btnVerDetalle.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnVerDetalle.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnVerDetalle.FillColor = Color.FromArgb(230, 81, 0);
            btnVerDetalle.Font = new Font("Segoe UI", 11F);
            btnVerDetalle.ForeColor = Color.White;
            btnVerDetalle.Location = new Point(874, 650);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnVerDetalle.Size = new Size(220, 50);
            btnVerDetalle.TabIndex = 4;
            btnVerDetalle.Text = "Ver Detalle";
            // 
            // UcConsultaVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "UcConsultaVentas";
            Size = new Size(1119, 718);
            panel1.ResumeLayout(false);
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            pnlFiltro.ResumeLayout(false);
            pnlFiltro.PerformLayout();
            pnlTablaVentas.ResumeLayout(false);
            pnlTablaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            pnlTotal.ResumeLayout(false);
            pnlTotal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlEncabezado;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubtitulo;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlFiltro;
        private Label lblFiltros;
        private DateTimePicker dtpFechaInicial;
        private Label lblFechaInicial;
        private Label lblFechaFinal;
        private DateTimePicker dtpFechaFinal;
        private TextBox txtVentas;
        private Label lblNumeroVentas;
        private Guna.UI2.WinForms.Guna2Button btnBuscar;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTablaVentas;
        private Guna.UI2.WinForms.Guna2DataGridView dgvVentas;
        private Label lblHistorial;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Guna.UI2.WinForms.Guna2Panel pnlTotal;
        private Label lblTotalVenta;
        private Guna.UI2.WinForms.Guna2Button btnVerDetalle;
    }
}
