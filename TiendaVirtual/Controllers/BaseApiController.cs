using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.ApiFilter;

namespace TiendaVirtual.Controllers
{
    [ApiController]
    [TypeFilter(typeof(Filter))]
    public class BaseApiController : ControllerBase
    {
    }
}
