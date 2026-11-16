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
        // Convierte los errores técnicos de la base de datos en mensajes entendibles
        public static void ErrorDeDatos(Exception ex)
        {
            var raiz = ex.GetBaseException();

            if (raiz is SqlException sql)
            {
                if (EsDuplicado(sql.Number))
                {
                    if (sql.Message.Contains("UQ_Usuario_NombreUsuario"))
                        Aviso("Usuario: ya existe otro usuario con ese nombre.");
                    else
                        Aviso("Ya existe un registro con ese valor. No se permiten datos duplicados.");
                    return;
                }

                if (EsErrorDeConexion(sql.Number))
                {
                    Error("No se pudo conectar con la base de datos.\n\n" +
                          "Verifique que SQL Server esté en ejecución y que la cadena de conexión " +
                          "(Data/PupuseriaDbContext.cs) sea correcta.");
                    return;
                }
            }

            Error("Ocurrió un error inesperado:\n\n" + raiz.Message);
        }

        // 2601 y 2627: se intentó guardar un valor que ya existe
        private static bool EsDuplicado(int numero) =>
            numero is 2601 or 2627;

        // Todos estos números significan "no se pudo llegar a SQL Server o entrar a él"
        private static bool EsErrorDeConexion(int numero) =>
            numero is -1 or 2 or 26 or 40 or 53 or 233 or 4060 or 10060 or 18456;
    }
}

