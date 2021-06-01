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
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<ActionResult<bool>> Login(string user, string clave)
        {
            try
            {
                bool res = await _DBContex.Usuario.CountAsync(u => u.Usuario1 == user && u.Clave == clave) > 0 ? true : false;
                return res;
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Perfiles> SavePerfil([FromBody] Perfiles dato)
        {
            try
            {
                if (!dato.Equals(null))
                {
                    dato.txFechaIngreso = DateTime.Now.ToString("dd/MM/yyyy").Replace("/","-");
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
