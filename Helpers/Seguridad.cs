using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace Pupuseria.helpers
{
    public static class Seguridad
    {
        //SHA-256 en hexadecimal: es el mismo valor que genera el script SQL para 'admin'
        public static string Hash(string clave) =>
            Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(clave)));
    }
}
