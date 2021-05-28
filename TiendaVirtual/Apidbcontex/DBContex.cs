using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Apidbcontex
{
    public class DBContex : DbContext
    {
        public DBContex(DbContextOptions contex) : base(contex)
        {

        }

        public DbSet<Usuario> Usuario { get;set;}
        public DbSet<PerfilesUsuario> PerfilesUsuario { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder ModeloCreador)
        {
            new Usuario.Mapeo(ModeloCreador.Entity<Usuario>());
            new PerfilesUsuario.Mapeo(ModeloCreador.Entity<PerfilesUsuario>());
            new Perfiles.Mapeo(ModeloCreador.Entity<Perfiles>());
        }
    }
}
