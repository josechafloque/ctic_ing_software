using cticbackend.data.repositorio.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cticbackend.Controllers
{
    [Route("api/Controller/autenticacion")]
    [ApiController]
    public class autenticacionController : Controller
    {
        public readonly interface_data _autenticacionRepository;
        public autenticacionController(interface_data autenticacionRepository)
        {
            _autenticacionRepository = autenticacionRepository;
        }

        [HttpGet("{id},{correo},{contrasena}")]
        public async Task<IActionResult> Autenticacion_Contrasena(int id, string correo, string contrasena)
        {
            return Ok(await _autenticacionRepository.Autenticacion_Usuario(id, correo, contrasena));
        }
    }
}
