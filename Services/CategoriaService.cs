using Microsoft.EntityFrameworkCore;
using Pupuseria.data.contexto;
using Pupuseria.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pupuseria.Services
{
    internal class CategoriaService
    {
        
        public List<Categoria> ObtenerTodas()
        {
            using (var db = new PupuseriaDbContext())
            {
                return db.Categorias
                    .AsNoTracking()
                    .Where(c => c.Activo)
                    .OrderBy(c => c.Nombre)
                    .ToList();
            }
        }

        
    }
}
