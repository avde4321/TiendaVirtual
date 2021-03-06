using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Apidbcontex;

namespace TiendaVirtual.Interface
{
    public interface MantenimientoInterface
    {
        Task<ActionResult<List<Usuario>>> Getallusarios();
        Task<Usuario> Postsaveuser([FromBody] Usuario user);
        Task<ActionResult<Usuario>> Login(string user, string clave);
        Task<Perfiles> SavePerfil([FromBody] Perfiles dato);
        Task<ActionResult<List<Perfiles>>> GetAllPerfiles();
        Task<PerfilesUsuario> SavePerfilUsuario([FromBody] PerfilesUsuario dato);
        Task<ActionResult<List<PerfilesUsuario>>> GetAllPerfilUsuario();
        Task<ActionResult<List<Perfiles>>> GetMenu();
        Task<Usuario> EditarUsuario([FromBody] Usuario dato);
    }
}
