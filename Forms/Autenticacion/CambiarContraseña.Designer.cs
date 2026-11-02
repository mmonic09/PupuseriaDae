namespace Pupuseria.Autenticacion
{
    partial class CambiarContraseña : System.Windows.Forms.Form
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            btnGuardarContrasena = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtConfirmacion = new Guna.UI2.WinForms.Guna2TextBox();
            txtContrasenaNueva = new Guna.UI2.WinForms.Guna2TextBox();
            txtContrasenaActual = new Guna.UI2.WinForms.Guna2TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 235, 221);
            panel1.Controls.Add(btnGuardarContrasena);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtConfirmacion);
            panel1.Controls.Add(txtContrasenaNueva);
            panel1.Controls.Add(txtContrasenaActual);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 364);
            panel1.TabIndex = 0;
            // 
            // btnGuardarContrasena
            // 
            btnGuardarContrasena.BorderColor = Color.FromArgb(62, 39, 35);
            btnGuardarContrasena.BorderRadius = 10;
            btnGuardarContrasena.BorderThickness = 1;
            btnGuardarContrasena.Cursor = Cursors.Hand;
            btnGuardarContrasena.CustomizableEdges = customizableEdges1;
            btnGuardarContrasena.DisabledState.BorderColor = Color.DarkGray;
            btnGuardarContrasena.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGuardarContrasena.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGuardarContrasena.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGuardarContrasena.FillColor = Color.FromArgb(62, 39, 35);
            btnGuardarContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarContrasena.ForeColor = Color.White;
            btnGuardarContrasena.HoverState.FillColor = Color.FromArgb(93, 64, 55);
            btnGuardarContrasena.ImageOffset = new Point(-2, 0);
            btnGuardarContrasena.ImageSize = new Size(14, 14);
            btnGuardarContrasena.Location = new Point(24, 298);
            btnGuardarContrasena.Name = "btnGuardarContrasena";
            btnGuardarContrasena.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGuardarContrasena.Size = new Size(155, 36);
            btnGuardarContrasena.TabIndex = 23;
            btnGuardarContrasena.Text = "Guardar contraseña";
            btnGuardarContrasena.Click += btnGuardar;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(27, 213);
            label4.Name = "label4";
            label4.Size = new Size(130, 15);
            label4.TabIndex = 7;
            label4.Text = "Confirmar contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(24, 139);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 6;
            label3.Text = "Contraseña nueva:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 16);
            label2.Name = "label2";
            label2.Size = new Size(183, 25);
            label2.TabIndex = 4;
            label2.Text = "Cambiar contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(24, 70);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 3;
            label1.Text = "Contraseña actual";
            // 
            // txtConfirmacion
            // 
            txtConfirmacion.BorderColor = Color.FromArgb(93, 64, 55);
            txtConfirmacion.BorderRadius = 8;
            txtConfirmacion.CustomizableEdges = customizableEdges3;
            txtConfirmacion.DefaultText = "";
            txtConfirmacion.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtConfirmacion.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtConfirmacion.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmacion.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmacion.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtConfirmacion.Font = new Font("Segoe UI", 9F);
            txtConfirmacion.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtConfirmacion.Location = new Point(24, 231);
            txtConfirmacion.Name = "txtConfirmacion";
            txtConfirmacion.PlaceholderText = "";
            txtConfirmacion.SelectedText = "";
            txtConfirmacion.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtConfirmacion.Size = new Size(261, 30);
            txtConfirmacion.TabIndex = 2;
            txtConfirmacion.UseSystemPasswordChar = true;
            // 
            // txtContrasenaNueva
            // 
            txtContrasenaNueva.BorderColor = Color.FromArgb(93, 64, 55);
            txtContrasenaNueva.BorderRadius = 8;
            txtContrasenaNueva.CustomizableEdges = customizableEdges5;
            txtContrasenaNueva.DefaultText = "";
            txtContrasenaNueva.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtContrasenaNueva.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtContrasenaNueva.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtContrasenaNueva.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtContrasenaNueva.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContrasenaNueva.Font = new Font("Segoe UI", 9F);
            txtContrasenaNueva.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContrasenaNueva.Location = new Point(24, 157);
            txtContrasenaNueva.Name = "txtContrasenaNueva";
            txtContrasenaNueva.PlaceholderText = "";
            txtContrasenaNueva.SelectedText = "";
            txtContrasenaNueva.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtContrasenaNueva.Size = new Size(261, 30);
            txtContrasenaNueva.TabIndex = 1;
            txtContrasenaNueva.UseSystemPasswordChar = true;
            // 
            // txtContrasenaActual
            // 
            txtContrasenaActual.BorderColor = Color.FromArgb(93, 64, 55);
            txtContrasenaActual.BorderRadius = 8;
            txtContrasenaActual.CustomizableEdges = customizableEdges7;
            txtContrasenaActual.DefaultText = "";
            txtContrasenaActual.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtContrasenaActual.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtContrasenaActual.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtContrasenaActual.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtContrasenaActual.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContrasenaActual.Font = new Font("Segoe UI", 9F);
            txtContrasenaActual.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtContrasenaActual.Location = new Point(24, 88);
            txtContrasenaActual.Name = "txtContrasenaActual";
            txtContrasenaActual.PlaceholderText = "";
            txtContrasenaActual.SelectedText = "";
            txtContrasenaActual.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtContrasenaActual.Size = new Size(261, 30);
            txtContrasenaActual.TabIndex = 0;
            txtContrasenaActual.UseSystemPasswordChar = true;
            // 
            // CambiarContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 364);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CambiarContraseña";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmacion;
        private Guna.UI2.WinForms.Guna2TextBox txtContrasenaNueva;
        private Guna.UI2.WinForms.Guna2TextBox txtContrasenaActual;
        private Label label4;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Button btnGuardarContrasena;
        //private Guna.UI2.WinForms.Guna2Button btnGuardarContrasena;
        //private Guna.UI2.WinForms.Guna2Button btnGuardar;
    }
}
