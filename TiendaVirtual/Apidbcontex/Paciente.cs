using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Apidbcontex
{
    public class Paciente
    {
        public int idPaciente { set; get; }
        public string CedulaPapa { set; get; }
        public string Nombre { set; get; }
        public string Raza { set; get; }
        public string Color { set; get; }
        public string FechaNecimiento { set; get; }
        public string Edad { set; get; }
        public string Estado { set; get; }
    }
}
