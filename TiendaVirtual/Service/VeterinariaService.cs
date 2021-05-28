using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Apidbcontex;
using TiendaVirtual.Interface;

namespace TiendaVirtual.Service
{
    public class VeterinariaService : VeterinariaInterface
    {
        private readonly DBContex _DBContex;
        public VeterinariaService(DBContex dBContex)
        {
            _DBContex = dBContex;
        }

        
    }
}
