namespace pupus
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMenu = new Panel();
            btnDetalleVenta = new Button();
            button4 = new Button();
            btnUsuarios = new Button();
            btnProductos = new Button();
            pnlLogo = new Panel();
            picLogo = new PictureBox();
            pnlContenido = new Panel();
            btnInicio = new Guna.UI2.WinForms.Guna2Button();
            pnlMenu.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.AutoScroll = true;
            pnlMenu.BackColor = Color.FromArgb(73, 53, 43);
            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Controls.Add(btnDetalleVenta);
            pnlMenu.Controls.Add(button4);
            pnlMenu.Controls.Add(btnUsuarios);
            pnlMenu.Controls.Add(btnProductos);
            pnlMenu.Controls.Add(pnlLogo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(3, 2, 3, 2);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(249, 861);
            pnlMenu.TabIndex = 0;
            // 
            // btnDetalleVenta
            // 
            btnDetalleVenta.FlatAppearance.BorderSize = 0;
            btnDetalleVenta.FlatStyle = FlatStyle.Flat;
            btnDetalleVenta.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDetalleVenta.ForeColor = SystemColors.ButtonHighlight;
            btnDetalleVenta.Location = new Point(12, 401);
            btnDetalleVenta.Margin = new Padding(3, 2, 3, 2);
            btnDetalleVenta.Name = "btnDetalleVenta";
            btnDetalleVenta.Size = new Size(219, 34);
            btnDetalleVenta.TabIndex = 5;
            btnDetalleVenta.Text = "DetalleVentas";
            btnDetalleVenta.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(12, 363);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(219, 34);
            button4.TabIndex = 4;
            button4.Text = "Ventas";
            button4.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Constantia", 10F);
            btnUsuarios.ForeColor = SystemColors.ButtonHighlight;
            btnUsuarios.Location = new Point(12, 315);
            btnUsuarios.Margin = new Padding(3, 2, 3, 2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(219, 34);
            btnUsuarios.TabIndex = 3;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Constantia", 10F);
            btnProductos.ForeColor = SystemColors.ButtonHighlight;
            btnProductos.Location = new Point(12, 256);
            btnProductos.Margin = new Padding(3, 2, 3, 2);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(219, 34);
            btnProductos.TabIndex = 2;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(picLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Margin = new Padding(3, 2, 3, 2);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(249, 165);
            pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(12, 11);
            picLogo.Margin = new Padding(3, 2, 3, 2);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(219, 89);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pnlContenido
            // 
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(249, 0);
            pnlContenido.Margin = new Padding(3, 2, 3, 2);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(1135, 861);
            pnlContenido.TabIndex = 1;
            // 
            // btnInicio
            // 
            btnInicio.BorderRadius = 15;
            btnInicio.CustomizableEdges = customizableEdges3;
            btnInicio.DisabledState.BorderColor = Color.DarkGray;
            btnInicio.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInicio.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInicio.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInicio.FillColor = Color.FromArgb(73, 53, 43);
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.Image = (Image)resources.GetObject("btnInicio.Image");
            btnInicio.ImageAlign = HorizontalAlignment.Left;
            btnInicio.Location = new Point(34, 206);
            btnInicio.Name = "btnInicio";
            btnInicio.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnInicio.Size = new Size(180, 45);
            btnInicio.TabIndex = 6;
            btnInicio.Text = "Inicio";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 235, 221);
            ClientSize = new Size(1384, 861);
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPrincipal";
            Text = "Form2";
            Load += Form2_Load;
            pnlMenu.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlLogo;
        private PictureBox picLogo;
        private Button button4;
        private Button btnUsuarios;
        private Button btnProductos;
        private Button btnDetalleVenta;
        private Panel pnlContenido;
        private Guna.UI2.WinForms.Guna2Button btnInicio;
    }
}