using Pupuseria.Forms;
using Pupuseria.Modulos;
using Pupuseria.Properties;
using System.Windows.Forms;


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
            // Inicialización requerida para aplicaciones modernas de WinForms en .NET
            ApplicationConfiguration.Initialize();

            // Arranca la aplicación mostrando el Login
            Application.Run(new FrmLogin());
        }
    }
}