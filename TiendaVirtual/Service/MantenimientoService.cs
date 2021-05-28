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
    public class MantenimientoService : MantenimientoInterface
    {
        private readonly DBContex _DBContex;
        public MantenimientoService(DBContex dBContex)
        {
            _DBContex = dBContex;
        }

        public async Task<List<Usuario>> Getallusarios()
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
                string dia = string.Empty;
                string mes = string.Empty;
                if (!user.Equals(null))
                {
                    dia = DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
                    mes = DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();

                    user.txFechaIngreso = Convert.ToString(dia + "-" + mes + "-" + DateTime.Now.Year);

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
                _DBContex.Perfiles.Add(dato);
                await _DBContex.SaveChangesAsync();

                return dato;
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
