using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Apidbcontex
{
    public class Historial
    {
        public int idHistorial { get; set; }
        public string cedulaPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string TipoEnfermedad { get; set; }
        public string Descripcion { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaConsulta { get; set; }
        public string Estado { get; set; }
    }
}
