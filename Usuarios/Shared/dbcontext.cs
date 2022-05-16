using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Compartidos.database;

namespace Usuarios.Compartidos
{
    public class dbcontext : DbContext
    {
        public DbSet<Usuario> Usuary { get; set; }
        public DbSet<Proyecto> Projects { get; set; }
        public DbSet<Tarea> Work { get; set; }
        public dbcontext(DbContextOptions<dbcontext> opcions)
            : base(opcions)
        {

        }
    }
}
