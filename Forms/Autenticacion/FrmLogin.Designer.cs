namespace Pupuseria.Forms
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            txtContraseña = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            guna2vSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
            guna2vSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            pictureBox2 = new PictureBox();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(62, 39, 35);
            label1.Location = new Point(684, 107);
            label1.Name = "label1";
            label1.Size = new Size(301, 88);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 11.25F);
            label2.Location = new Point(667, 136);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 2;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 11.25F);
            label3.Location = new Point(667, 213);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(62, 39, 35);
            label4.Location = new Point(736, 195);
            label4.Name = "label4";
            label4.Size = new Size(193, 20);
            label4.TabIndex = 6;
            label4.Text = "Inicia sesión para continuar ";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderColor = Color.Black;
            txtUsuario.BorderRadius = 10;
            txtUsuario.CustomizableEdges = customizableEdges1;
            txtUsuario.DefaultText = "";
            txtUsuario.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsuario.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsuario.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsuario.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsuario.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsuario.Location = new Point(684, 279);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.SelectedText = "";
            txtUsuario.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUsuario.Size = new Size(310, 45);
            txtUsuario.TabIndex = 7;
            // 
            // txtContraseña
            // 
            txtContraseña.BorderColor = Color.Black;
            txtContraseña.BorderRadius = 10;
            txtContraseña.CustomizableEdges = customizableEdges3;
            txtContraseña.DefaultText = "";
            txtContraseña.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtContraseña.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtContraseña.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtContraseña.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtContraseña.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContraseña.Location = new Point(684, 348);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PlaceholderText = "Contraseña";
            txtContraseña.SelectedText = "";
            txtContraseña.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtContraseña.Size = new Size(310, 45);
            txtContraseña.TabIndex = 8;
            // 
            // btnLogin
            // 
            btnLogin.BorderRadius = 10;
            btnLogin.CustomizableEdges = customizableEdges5;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(62, 39, 35);
            btnLogin.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.ImageAlign = HorizontalAlignment.Left;
            btnLogin.Location = new Point(684, 440);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLogin.Size = new Size(310, 40);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Iniciar sesión";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(guna2Separator4);
            guna2Panel1.Controls.Add(guna2Separator1);
            guna2Panel1.Controls.Add(guna2Panel2);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(btnLogin);
            guna2Panel1.Controls.Add(label4);
            guna2Panel1.Controls.Add(txtContraseña);
            guna2Panel1.Controls.Add(txtUsuario);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(1190, 696);
            guna2Panel1.TabIndex = 10;
            // 
            // guna2Separator4
            // 
            guna2Separator4.FillColor = Color.FromArgb(62, 39, 35);
            guna2Separator4.Location = new Point(532, 201);
            guna2Separator4.Name = "guna2Separator4";
            guna2Separator4.Size = new Size(177, 14);
            guna2Separator4.TabIndex = 12;
            // 
            // guna2Separator1
            // 
            guna2Separator1.FillColor = Color.FromArgb(62, 39, 35);
            guna2Separator1.Location = new Point(950, 201);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(177, 14);
            guna2Separator1.TabIndex = 11;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.FromArgb(62, 39, 35);
            guna2Panel2.Controls.Add(guna2vSeparator2);
            guna2Panel2.Controls.Add(guna2vSeparator1);
            guna2Panel2.Controls.Add(guna2Separator3);
            guna2Panel2.Controls.Add(guna2Separator2);
            guna2Panel2.Controls.Add(pictureBox2);
            guna2Panel2.CustomizableEdges = customizableEdges7;
            guna2Panel2.Location = new Point(0, 0);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel2.Size = new Size(469, 693);
            guna2Panel2.TabIndex = 10;
            // 
            // guna2vSeparator2
            // 
            guna2vSeparator2.Location = new Point(18, 38);
            guna2vSeparator2.Name = "guna2vSeparator2";
            guna2vSeparator2.Size = new Size(10, 609);
            guna2vSeparator2.TabIndex = 15;
            // 
            // guna2vSeparator1
            // 
            guna2vSeparator1.Location = new Point(440, 38);
            guna2vSeparator1.Name = "guna2vSeparator1";
            guna2vSeparator1.Size = new Size(10, 609);
            guna2vSeparator1.TabIndex = 14;
            // 
            // guna2Separator3
            // 
            guna2Separator3.BackColor = Color.Transparent;
            guna2Separator3.FillColor = Color.White;
            guna2Separator3.Location = new Point(38, 644);
            guna2Separator3.Name = "guna2Separator3";
            guna2Separator3.Size = new Size(396, 30);
            guna2Separator3.TabIndex = 13;
            // 
            // guna2Separator2
            // 
            guna2Separator2.BackColor = Color.Transparent;
            guna2Separator2.FillColor = Color.White;
            guna2Separator2.Location = new Point(38, 12);
            guna2Separator2.Name = "guna2Separator2";
            guna2Separator2.Size = new Size(396, 25);
            guna2Separator2.TabIndex = 12;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(120, 182);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 250);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 235, 221);
            ClientSize = new Size(1190, 696);
            Controls.Add(guna2Panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmLogin";
            Text = "Form1";
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtUsuario;
        private Guna.UI2.WinForms.Guna2TextBox txtContraseña;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2VSeparator guna2vSeparator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private Guna.UI2.WinForms.Guna2VSeparator guna2vSeparator2;
    }
}
