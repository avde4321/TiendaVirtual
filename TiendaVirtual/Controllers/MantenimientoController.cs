using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TiendaVirtual.Apidbcontex;
using TiendaVirtual.Interface;
using TiendaVirtual.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly MantenimientoInterface _mantenimientoInterface;
        private readonly ILogger _logger;

        public MantenimientoController(MantenimientoInterface mantenimientoInterface, ILogger<MantenimientoController> logger)
        {
            this._mantenimientoInterface = mantenimientoInterface;
            this._logger = logger;
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

                _logger.LogError($"Error metodo GetUsuarioall{ex.Message}");

                ErrorData error = new ErrorData();
                error.CodError = "1";
                error.Mensaje = "Error al consultar todos los Usuarios";
                
                return BadRequest(error);
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
    }
}
