using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Apidbcontex;
using TiendaVirtual.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariaController : BaseApiController
    {
        private readonly VeterinariaInterface _veterinariaInterface;
        public VeterinariaController(VeterinariaInterface veterinariaInterface)
        {
            this._veterinariaInterface = veterinariaInterface;
        }

        
    }
}
