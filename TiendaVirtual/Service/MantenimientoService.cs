using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Apidbcontex;
using TiendaVirtual.Interface;
using TiendaVirtual.Util;

namespace TiendaVirtual.Service
{
    public class MantenimientoService : VariablesGlobales, MantenimientoInterface
    {
        private readonly DBContex _DBContex;
        public MantenimientoService(DBContex dBContex)
        {
            _DBContex = dBContex;
        }

        public async Task<Usuario> EditarUsuario([FromBody] Usuario dato)
        {
            try
            {
                if (!dato.Equals(null))
                {
                    var update = _DBContex.Usuario.FirstOrDefault(u => u.id == dato.id);

                    if (!update.Usuario1.Equals(dato.Usuario1) && dato.Usuario1 != null && update.Usuario1 != null) { update.Usuario1 = dato.Usuario1; }
                    if (!update.Clave.Equals(dato.Clave) && dato.Clave != null && update.Clave != null) { update.Clave = dato.Clave; }
                    if (!update.txEmail.Equals(dato.txEmail) && dato.txEmail != null && update.txEmail != null) { update.txEmail = dato.txEmail; }
                    if (!update.Estado.Equals(dato.Estado) && dato.Estado != null && update.Estado != null) { update.Estado = dato.Estado; }

                    await _DBContex.SaveChangesAsync();
                }

                return dato;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<ActionResult<List<Perfiles>>> GetAllPerfiles()
        {
            try
            {
                var table = await _DBContex.Perfiles.ToListAsync();

                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult<List<PerfilesUsuario>>> GetAllPerfilUsuario()
        {
            try
            {
                var table = await _DBContex.PerfilesUsuario.ToListAsync();
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult<List<Usuario>>> Getallusarios()
        {
            try
            {
                var data = await _DBContex.Usuario.ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ActionResult<List<Perfiles>>> GetMenu()
        {
            try
            {
                var data = await _DBContex.Perfiles.Select(t => new Perfiles
                {
                    descripcion = t.descripcion,
                    url = t.url
                }).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ActionResult<Usuario>> Login(string user, string clave)
        {
            try
            {
                var res = await _DBContex.Usuario.FirstOrDefaultAsync(u => u.Usuario1 == user && u.Clave == clave);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> Postsaveuser([FromBody] Usuario user)
        {
            try
            {
                if (!user.Equals(null))
                {
                    user.txFechaIngreso = DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "-");
                    user.Estado = Activo;

                    _DBContex.Usuario.Add(user);
                    await _DBContex.SaveChangesAsync();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Perfiles> SavePerfil([FromBody] Perfiles dato)
        {
            try
            {
                if (!dato.Equals(null))
                {
                    dato.txFechaIngreso = DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "-");
                    dato.Estado = Activo;

                    _DBContex.Perfiles.Add(dato);
                    await _DBContex.SaveChangesAsync();
                }
                return dato;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PerfilesUsuario> SavePerfilUsuario([FromBody] PerfilesUsuario dato)
        {
            try
            {
                if (!dato.Equals(null))
                {
                    dato.txFechaIngreso = DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "-");
                    dato.Estado = Activo;

                    _DBContex.PerfilesUsuario.Add(dato);
                    await _DBContex.SaveChangesAsync();
                }
                return dato;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
