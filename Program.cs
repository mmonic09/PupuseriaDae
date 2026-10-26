using System.Windows.Forms;
using Pupuseria.Modulos;

namespace Pupuseria.Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
            //Application.Run(Preview(new UcProductos())); // prueba de los Uc

        }

        /*private static Form Preview(UserControl control)
        {
            control.Dock = DockStyle.Fill;

            var form = new Form
            {
                Text = $"Vista previa - {control.GetType().Name}",
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(1000, 700)
            };
            form.Controls.Add(control);
            return form;
        }*/
    }
}