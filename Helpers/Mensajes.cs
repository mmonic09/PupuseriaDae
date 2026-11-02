using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.helpers
{
    public static class Mensajes
    {
        private const string Titulo = "Pupusería";

        public static void Info(string texto) =>
            MessageBox.Show(texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Aviso(string texto) =>
            MessageBox.Show(texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void Error(string texto) =>
            MessageBox.Show(texto, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool Confirmar(string texto) =>
            MessageBox.Show(texto, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        // Convierte los errores técnicos de la base de datos en mensajes entendibles
        public static void ErrorDeDatos(Exception ex)
        {
            var raiz = ex.GetBaseException();

            if (raiz is SqlException sql)
            {
                switch (sql.Number)
                {
                    case 2601:
                    case 2627:   // valor duplicado
                        if (sql.Message.Contains("UQ_Usuario_NombreUsuario"))
                            Aviso("Usuario: ya existe otro usuario con ese nombre.");
                        else
                            Aviso("Ya existe un registro con ese valor. No se permiten datos duplicados.");
                        return;

                    case -1:
                    case 2:
                    case 26:
                    case 40:
                    case 53:
                    case 233:
                    case 4060:
                    case 10060:
                    case 18456:  // no se puede conectar / iniciar sesión en SQL Server
                        Error("No se pudo conectar con la base de datos.\n\n" +
                              "Verifique que SQL Server esté en ejecución y que la cadena de conexión " +
                              "(Data/PupuseriaDbContext.cs) sea correcta.");
                        return;
                }
            }

            Error("Ocurrió un error inesperado:\n\n" + raiz.Message);
        }
    }
}
