using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Apidbcontex
{
    public class PerfilesUsuario
    {
        public int idperUsuario { get; set; }
        public int idUsuario { get; set; }
        public int idPerfil { get; set; }
        public string txFechaIngreso { get; set; }
        public string txfechaActualizacion { get; set; }
        public string Estado { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<PerfilesUsuario> mapeoPerfilesUsuario)
            {
                mapeoPerfilesUsuario.HasKey(x => x.idperUsuario);
            }
        }
    }
}
