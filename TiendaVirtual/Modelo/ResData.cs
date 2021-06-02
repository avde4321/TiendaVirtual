using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Modelo
{
    public class ResData
    {
        public ResData()
        {
            this.Error = new ErrorData();
            this.Error.CodError = 0;
            this.Error.Mensaje = "Correcto";
        }

        public ErrorData Error  { get; set; } 
        public object Data { get; set; }
    }
}
