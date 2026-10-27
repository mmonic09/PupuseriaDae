namespace Pupuseria.Forms;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
        pnlUsuario = new Panel();
        pictureBox1 = new PictureBox();
        lblRol = new Label();
        label1 = new Label();
        btnProductos = new Guna.UI2.WinForms.Guna2Button();
        pnlMenu = new Panel();
        btnReportes = new Guna.UI2.WinForms.Guna2Button();
        btnConsultaVentas = new Guna.UI2.WinForms.Guna2Button();
        btnVentas = new Guna.UI2.WinForms.Guna2Button();
        btnUsuarios = new Guna.UI2.WinForms.Guna2Button();
        pnlLogo = new Panel();
        label3 = new Label();
        lblTituloPupuseria = new Label();
        pnlContenido = new Panel();
        pnlHeader = new Panel();
        lblHeaderTitulo = new Label();
        pnlUsuario.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        pnlMenu.SuspendLayout();
        pnlLogo.SuspendLayout();
        pnlHeader.SuspendLayout();
        SuspendLayout();
        // 
        // pnlUsuario
        // 
        pnlUsuario.Controls.Add(pictureBox1);
        pnlUsuario.Controls.Add(lblRol);
        pnlUsuario.Controls.Add(label1);
        pnlUsuario.Dock = DockStyle.Bottom;
        pnlUsuario.Location = new Point(0, 616);
        pnlUsuario.Name = "pnlUsuario";
        pnlUsuario.Size = new Size(231, 80);
        pnlUsuario.TabIndex = 1;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(28, 20);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(33, 33);
        pictureBox1.TabIndex = 2;
        pictureBox1.TabStop = false;
        // 
        // lblRol
        // 
        lblRol.AutoSize = true;
        lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRol.ForeColor = Color.White;
        lblRol.Location = new Point(80, 42);
        lblRol.Name = "lblRol";
        lblRol.Size = new Size(132, 15);
        lblRol.TabIndex = 1;
        lblRol.Text = "Administrador / Cajero";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        label1.ForeColor = Color.White;
        label1.Location = new Point(80, 15);
        label1.Name = "label1";
        label1.Size = new Size(110, 15);
        label1.TabIndex = 0;
        label1.Text = "Nombre Empleado";
        // 
        // btnProductos
        // 
        btnProductos.BackColor = Color.FromArgb(62, 39, 35);
        btnProductos.BorderRadius = 15;
        btnProductos.CustomizableEdges = customizableEdges1;
        btnProductos.DisabledState.BorderColor = Color.DarkGray;
        btnProductos.DisabledState.CustomBorderColor = Color.DarkGray;
        btnProductos.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnProductos.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnProductos.FillColor = Color.FromArgb(62, 39, 35);
        btnProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnProductos.ForeColor = Color.White;
        btnProductos.HoverState.FillColor = Color.FromArgb(93, 64, 55);
        btnProductos.Image = (Image)resources.GetObject("btnProductos.Image");
        btnProductos.ImageAlign = HorizontalAlignment.Left;
        btnProductos.ImageSize = new Size(22, 22);
        btnProductos.Location = new Point(12, 201);
        btnProductos.Name = "btnProductos";
        btnProductos.Padding = new Padding(0, 0, 10, 0);
        btnProductos.ShadowDecoration.CustomizableEdges = customizableEdges2;
        btnProductos.Size = new Size(202, 45);
        btnProductos.TabIndex = 7;
        btnProductos.Text = "Gestión Productos";
        btnProductos.TextAlign = HorizontalAlignment.Right;
        btnProductos.Click += btnProductos_Click_1;
        // 
        // pnlMenu
        // 
        pnlMenu.AutoScroll = true;
        pnlMenu.BackColor = Color.FromArgb(62, 39, 35);
        pnlMenu.Controls.Add(btnReportes);
        pnlMenu.Controls.Add(btnConsultaVentas);
        pnlMenu.Controls.Add(btnVentas);
        pnlMenu.Controls.Add(btnUsuarios);
        pnlMenu.Controls.Add(pnlLogo);
        pnlMenu.Controls.Add(btnProductos);
        pnlMenu.Controls.Add(pnlUsuario);
        pnlMenu.Dock = DockStyle.Left;
        pnlMenu.Location = new Point(0, 0);
        pnlMenu.Margin = new Padding(3, 2, 3, 2);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new Size(231, 696);
        pnlMenu.TabIndex = 0;
        // 
        // btnReportes
        // 
        btnReportes.BackColor = Color.FromArgb(62, 39, 35);
        btnReportes.BorderRadius = 15;
        btnReportes.CustomizableEdges = customizableEdges3;
        btnReportes.DisabledState.BorderColor = Color.DarkGray;
        btnReportes.DisabledState.CustomBorderColor = Color.DarkGray;
        btnReportes.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnReportes.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnReportes.FillColor = Color.FromArgb(62, 39, 35);
        btnReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnReportes.ForeColor = Color.White;
        btnReportes.HoverState.FillColor = Color.FromArgb(93, 64, 55);
        btnReportes.Image = (Image)resources.GetObject("btnReportes.Image");
        btnReportes.ImageAlign = HorizontalAlignment.Left;
        btnReportes.ImageSize = new Size(22, 22);
        btnReportes.Location = new Point(12, 475);
        btnReportes.Name = "btnReportes";
        btnReportes.Padding = new Padding(0, 0, 10, 0);
        btnReportes.ShadowDecoration.CustomizableEdges = customizableEdges4;
        btnReportes.Size = new Size(202, 45);
        btnReportes.TabIndex = 12;
        btnReportes.Text = "Reportes Generales";
        btnReportes.TextAlign = HorizontalAlignment.Right;
        btnReportes.TextOffset = new Point(4, 0);
        btnReportes.Click += btnReportes_Click;
        // 
        // btnConsultaVentas
        // 
        btnConsultaVentas.BackColor = Color.FromArgb(62, 39, 35);
        btnConsultaVentas.BorderRadius = 15;
        btnConsultaVentas.CustomizableEdges = customizableEdges5;
        btnConsultaVentas.DisabledState.BorderColor = Color.DarkGray;
        btnConsultaVentas.DisabledState.CustomBorderColor = Color.DarkGray;
        btnConsultaVentas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnConsultaVentas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnConsultaVentas.FillColor = Color.FromArgb(62, 39, 35);
        btnConsultaVentas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnConsultaVentas.ForeColor = Color.White;
        btnConsultaVentas.HoverState.FillColor = Color.FromArgb(93, 64, 55);
        btnConsultaVentas.Image = (Image)resources.GetObject("btnConsultaVentas.Image");
        btnConsultaVentas.ImageAlign = HorizontalAlignment.Left;
        btnConsultaVentas.ImageSize = new Size(22, 22);
        btnConsultaVentas.Location = new Point(12, 409);
        btnConsultaVentas.Name = "btnConsultaVentas";
        btnConsultaVentas.Padding = new Padding(0, 0, 10, 0);
        btnConsultaVentas.ShadowDecoration.CustomizableEdges = customizableEdges6;
        btnConsultaVentas.Size = new Size(202, 45);
        btnConsultaVentas.TabIndex = 11;
        btnConsultaVentas.Text = "Consulta de Ventas";
        btnConsultaVentas.TextAlign = HorizontalAlignment.Right;
        btnConsultaVentas.TextOffset = new Point(1, 0);
        btnConsultaVentas.Click += btnConsultaVentas_Click;
        // 
        // btnVentas
        // 
        btnVentas.BackColor = Color.FromArgb(62, 39, 35);
        btnVentas.BorderRadius = 15;
        btnVentas.CustomizableEdges = customizableEdges7;
        btnVentas.DisabledState.BorderColor = Color.DarkGray;
        btnVentas.DisabledState.CustomBorderColor = Color.DarkGray;
        btnVentas.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnVentas.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnVentas.FillColor = Color.FromArgb(62, 39, 35);
        btnVentas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnVentas.ForeColor = Color.White;
        btnVentas.HoverState.FillColor = Color.FromArgb(93, 64, 55);
        btnVentas.Image = (Image)resources.GetObject("btnVentas.Image");
        btnVentas.ImageAlign = HorizontalAlignment.Left;
        btnVentas.ImageSize = new Size(22, 22);
        btnVentas.Location = new Point(12, 340);
        btnVentas.Name = "btnVentas";
        btnVentas.Padding = new Padding(0, 0, 10, 0);
        btnVentas.ShadowDecoration.CustomizableEdges = customizableEdges8;
        btnVentas.Size = new Size(202, 45);
        btnVentas.TabIndex = 10;
        btnVentas.Text = "Punto de Venta";
        btnVentas.TextAlign = HorizontalAlignment.Right;
        btnVentas.TextOffset = new Point(-10, 0);
        btnVentas.Click += btnVentas_Click;
        // 
        // btnUsuarios
        // 
        btnUsuarios.BackColor = Color.FromArgb(62, 39, 35);
        btnUsuarios.BorderRadius = 15;
        btnUsuarios.CustomizableEdges = customizableEdges9;
        btnUsuarios.DisabledState.BorderColor = Color.DarkGray;
        btnUsuarios.DisabledState.CustomBorderColor = Color.DarkGray;
        btnUsuarios.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
        btnUsuarios.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
        btnUsuarios.FillColor = Color.FromArgb(62, 39, 35);
        btnUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnUsuarios.ForeColor = Color.White;
        btnUsuarios.HoverState.FillColor = Color.FromArgb(93, 64, 55);
        btnUsuarios.Image = (Image)resources.GetObject("btnUsuarios.Image");
        btnUsuarios.ImageAlign = HorizontalAlignment.Left;
        btnUsuarios.ImageSize = new Size(22, 22);
        btnUsuarios.Location = new Point(12, 273);
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Padding = new Padding(0, 0, 10, 0);
        btnUsuarios.ShadowDecoration.CustomizableEdges = customizableEdges10;
        btnUsuarios.Size = new Size(202, 45);
        btnUsuarios.TabIndex = 9;
        btnUsuarios.Text = "Gestión Usuarios";
        btnUsuarios.TextAlign = HorizontalAlignment.Right;
        btnUsuarios.TextOffset = new Point(-5, 0);
        btnUsuarios.Click += btnUsuarios_Click;
        // 
        // pnlLogo
        // 
        pnlLogo.Controls.Add(label3);
        pnlLogo.Controls.Add(lblTituloPupuseria);
        pnlLogo.Dock = DockStyle.Top;
        pnlLogo.Location = new Point(0, 0);
        pnlLogo.Name = "pnlLogo";
        pnlLogo.Size = new Size(231, 143);
        pnlLogo.TabIndex = 8;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        label3.ForeColor = Color.FromArgb(255, 192, 128);
        label3.Location = new Point(37, 71);
        label3.Name = "label3";
        label3.Size = new Size(153, 19);
        label3.TabIndex = 1;
        label3.Text = "Pupusería y Tradición";
        // 
        // lblTituloPupuseria
        // 
        lblTituloPupuseria.AutoSize = true;
        lblTituloPupuseria.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblTituloPupuseria.ForeColor = Color.White;
        lblTituloPupuseria.Location = new Point(37, 43);
        lblTituloPupuseria.Name = "lblTituloPupuseria";
        lblTituloPupuseria.Size = new Size(143, 28);
        lblTituloPupuseria.TabIndex = 0;
        lblTituloPupuseria.Text = "El Buen Sabor";
        // 
        // pnlContenido
        // 
        pnlContenido.AutoScroll = true;
        pnlContenido.AutoSize = true;
        pnlContenido.BackColor = Color.White;
        pnlContenido.Dock = DockStyle.Fill;
        pnlContenido.Location = new Point(231, 88);
        pnlContenido.Margin = new Padding(3, 2, 3, 2);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Size = new Size(1119, 608);
        pnlContenido.TabIndex = 1;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblHeaderTitulo);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(231, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(1119, 88);
        pnlHeader.TabIndex = 2;
        // 
        // lblHeaderTitulo
        // 
        lblHeaderTitulo.AutoSize = true;
        lblHeaderTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeaderTitulo.ForeColor = Color.FromArgb(62, 39, 35);
        lblHeaderTitulo.Location = new Point(44, 32);
        lblHeaderTitulo.Name = "lblHeaderTitulo";
        lblHeaderTitulo.Size = new Size(183, 25);
        lblHeaderTitulo.TabIndex = 0;
        lblHeaderTitulo.Text = "Dashboard General";
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(251, 249, 246);
        ClientSize = new Size(1350, 696);
        Controls.Add(pnlContenido);
        Controls.Add(pnlHeader);
        Controls.Add(pnlMenu);
        Margin = new Padding(3, 2, 3, 2);
        Name = "FrmPrincipal";
        Text = "FormPrincipal";
        Load += Form2_Load;
        pnlUsuario.ResumeLayout(false);
        pnlUsuario.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        pnlMenu.ResumeLayout(false);
        pnlLogo.ResumeLayout(false);
        pnlLogo.PerformLayout();
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Panel pnlContenido;
    private Panel pnlUsuario;
    private Label lblRol;
    private Label label1;
    private Guna.UI2.WinForms.Guna2Button btnProductos;
    private Panel pnlMenu;
    private Panel pnlHeader;
    private Label lblHeaderTitulo;
    private Panel pnlPrincipal;
    private Panel pnlLogo;
    private Guna.UI2.WinForms.Guna2Button btnUsuarios;
    private Guna.UI2.WinForms.Guna2Button btnConsultaVentas;
    private Guna.UI2.WinForms.Guna2Button btnVentas;
    private Guna.UI2.WinForms.Guna2Button btnReportes;
    private Label label3;
    private Label lblTituloPupuseria;
    private PictureBox pictureBox1;
}