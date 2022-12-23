using cticbackend.data.repositorio.data;
using cticbackend.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cticbackend.Controllers
{
    [Route("api/Controller/Usuarios")]
    [ApiController]
    public class usuarioController : Controller
    {
        public readonly interface_data _usuarioRepository;

        public usuarioController(interface_data usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            return Ok(await _usuarioRepository.Obtener_Lista_Usuarios());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            return Ok(await _usuarioRepository.Obtener_Usuario(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            await _usuarioRepository.Borrar_Usuario(new usuario { id = id });

            return NoContent();
        }

        [HttpPost()]
        public async Task<IActionResult> IngresarUsuario([FromBody] usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _usuarioRepository.Ingresar_Usuario(usuario);

            return Created("created", created);
        }

        [HttpPut()]
        public async Task<IActionResult> ActualizarUsuario([FromBody] usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioRepository.Actualizar_Usuario(usuario);

            return NoContent();
        }

    }
}
