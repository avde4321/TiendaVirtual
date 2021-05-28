using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Apidbcontex
{
    public class Perfiles
    {
        public int idPerfil { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string Vista { get; set; }
        public string txFechaIngreso { get; set; }
        public string Estado { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Perfiles> mapeoidPerfil)
            {
                mapeoidPerfil.HasKey(x => x.idPerfil);
            }
        }

    }
}
