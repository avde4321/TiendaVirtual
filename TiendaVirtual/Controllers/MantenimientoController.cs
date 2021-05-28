using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Apidbcontex;
using TiendaVirtual.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly MantenimientoInterface _mantenimientoInterface;
        public MantenimientoController(MantenimientoInterface mantenimientoInterface)
        {
            this._mantenimientoInterface = mantenimientoInterface;
        }

        [HttpGet]
        [Route("GetUsuarioall")]
        public async Task<ActionResult> GetUsuarioall()
        {
            try
            {
                return Ok(await _mantenimientoInterface.Getallusarios());
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
                return Ok(await _mantenimientoInterface.Login(user, clave));
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
                return Ok(await _mantenimientoInterface.Postsaveuser(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<ActionResult> SavePerfil([FromBody] Perfiles dato)
        {
            try
            {
                return Ok(await _mantenimientoInterface.);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
