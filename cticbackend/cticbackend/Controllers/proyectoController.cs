using cticbackend.data.repositorio.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using cticbackend.model;

namespace cticbackend.Controllers
{
    [Route("api/Controller/Proyectos")]
    [ApiController]
    public class proyectoController : Controller
    {

        public readonly interface_data _proyectoRepository;

        public proyectoController(interface_data proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> ObtenerProyectos()
        {
            return Ok(await _proyectoRepository.Obtener_Lista_Proyectos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProyecto(int id)
        {
            return Ok(await _proyectoRepository.Obtener_Proyecto(id));
        }


        [HttpPost()]
        public async Task<IActionResult> IngresarProyecto([FromBody] proyecto proyecto)
        {
            if (proyecto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _proyectoRepository.Ingresar_Proyecto(proyecto);

            return Created("created", created);
        }

        [HttpPut()]
        public async Task<IActionResult> ActualizarProyecto([FromBody] proyecto proyecto)
        {
            if (proyecto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _proyectoRepository.Actualizar_Proyecto(proyecto);

            return NoContent();
        }

    }
}
