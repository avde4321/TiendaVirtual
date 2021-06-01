using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Apidbcontex
{
    public class Usuario
    {
        public int id { set; get; }
        public string Usuario1 { set; get; }
        public string Clave { set; get; }
        public string txEmail { set; get; }
        public string txFechaIngreso { set; get; }
        public string Estado { set; get; }
        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Usuario> mapeoUsuario)
            {
                mapeoUsuario.HasKey(x => x.id);
                mapeoUsuario.Property(x => x.Usuario1).HasColumnName("Usuario");
            }
        }
    }
}
