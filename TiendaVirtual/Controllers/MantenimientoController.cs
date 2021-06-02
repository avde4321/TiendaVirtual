using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private ResData res = new ResData();

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
                var dbRes = await _mantenimientoInterface.Getallusarios();

                var json = new {
                    lisData = dbRes.Value
                };

                this.res.Data = json;

                return Ok(res);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error metodo GetUsuarioall{ex.Message}");

                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Error al consultar todos los Usuarios";

                return BadRequest(res);
            }
        }

        [HttpGet]
        [Route("Login/{user}/{clave}")]
        public async Task<ActionResult> Login(string user, string clave)
        {
            try
            {
                var dbRes = await _mantenimientoInterface.Login(user, clave);

                var json = new
                {
                    Token = "kggjhvufjvjygjkgkg",
                    ExisteUsario = dbRes.Value
                };

                if (dbRes.Value.Equals(true))
                {
                    this.res.Data = json;
                    return Ok(res);
                }
                else
                {
                    this.res.Error.CodError = 1;
                    this.res.Error.Mensaje = "Incorrecto";
                    this.res.Data = null;
                    return Unauthorized(res);
                }
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
                var json = new {
                    lisData = await _mantenimientoInterface.Postsaveuser(user)
                };

                this.res.Data = json;

                return Ok(res);
            }
            catch (Exception ex)
            {
                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Incorrecto";
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("SavePerfil")]
        public async Task<ActionResult> SavePerfil([FromBody] Perfiles dato)
        {
            try
            {
                var json = new
                {
                    lisData = await _mantenimientoInterface.SavePerfil(dato)
                };

                this.res.Data = json;

                return Ok(res);
            }
            catch (Exception)
            {
                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Incorrecto";
                return BadRequest(res);
            }
        }

        [HttpGet]
        [Route("GetAllPerfiles")]
        public async Task<ActionResult> GetAllPerfiles()
        {
            try
            {
                var dbRes = await _mantenimientoInterface.GetAllPerfiles();
                var json = new
                {
                    lisData = dbRes.Value
                };

                this.res.Data = json;

                return Ok(res);
            }
            catch (Exception)
            {
                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Incorrecto";
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("SavePerfilUsuario")]
        public async Task<ActionResult> SavePerfilUsuario([FromBody] PerfilesUsuario dato)
        {
            try
            {
                var json = new
                {
                    lisData = await _mantenimientoInterface.SavePerfilUsuario(dato)
                };

                this.res.Data = json;

                return Ok(res);
            }
            catch (Exception)
            {
                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Incorrecto";
                return BadRequest(res);
            }

        }

        [HttpGet]
        [Route("GetAllPerfilUsuario")]
        public async Task<ActionResult> GetAllPerfilUsuario()
        {
            try
            {
                var dbRes = await _mantenimientoInterface.GetAllPerfilUsuario();
                var json = new
                {
                    lisData = dbRes.Value
                };

                this.res.Data = json;
                return Ok(res);
            }
            catch (Exception)
            {
                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Incorrecto";
                return BadRequest(res);
            }
        }

        [HttpGet]
        [Route("GetMenu")]
        public async Task<ActionResult> GetMenu()
        {
            try
            {
                var dbRes = await _mantenimientoInterface.GetMenu();
                var json = new
                {
                    lisData = dbRes.Value
                };

                this.res.Data = json;
                return Ok(res);
            }
            catch (Exception)
            {
                this.res.Error.CodError = 1;
                this.res.Error.Mensaje = "Incorrecto";
                return BadRequest(res);
            }
        }
    }
}