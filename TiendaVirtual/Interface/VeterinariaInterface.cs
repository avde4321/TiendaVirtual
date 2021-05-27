using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaVirtual.Apidbcontex;

namespace TiendaVirtual.Interface
{
    public interface VeterinariaInterface
    {
        Task<List<Usuario>> Getallusarios();
        Task<Usuario> Postsaveuser([FromBody] Usuario user);
        Task<ActionResult<bool>> Login(string user, string clave);
    }
}
