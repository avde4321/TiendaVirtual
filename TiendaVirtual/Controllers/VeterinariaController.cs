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
    public class VeterinariaController : ControllerBase
    {
        private readonly VeterinariaInterface _veterinariaInterface;
        public VeterinariaController(VeterinariaInterface veterinariaInterface)
        {
            this._veterinariaInterface = veterinariaInterface;
        }

        [HttpGet]
        [Route("GetUsuarioall")]
        public async Task<ActionResult> GetUsuarioall()
        {
            try
            {
                return Ok(await _veterinariaInterface.Getallusarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult> Login(string user, string clave)
        {
            try
            {
                return Ok(await _veterinariaInterface.Login(user,clave));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Postsaveuser")]
        public async Task<ActionResult> Postsaveuser([FromBody] Usuario user)
        {
            try
            {
                return Ok(await _veterinariaInterface.Postsaveuser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
