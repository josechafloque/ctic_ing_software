using cticbackend.data.repositorio.data;
using cticbackend.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cticbackend.Controllers
{
    [Route("api/Controller/Encargos")]
    [ApiController]
    public class encargoController : Controller
    {
        public readonly interface_data _encargoRepository;

        public encargoController(interface_data encargoRepository)
        {
            _encargoRepository = encargoRepository;
        }

        [HttpGet("Lista_Encargos")]
        public async Task<IActionResult> Obtener_Encargos_Internos()
        {
            return Ok(await _encargoRepository.Obtener_Lista_Encargos());
        }

        [HttpPost("Registrar_Encargo")]
        public async Task<IActionResult> RegistrarEncargoInterno([FromBody] encargo_interno encargo_interno)
        {
            if (encargo_interno == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _encargoRepository.Registrar_Encargo_Interno(encargo_interno);

            return Created("created", created);
        }

        [HttpPut("Registrar_Evaluacion")]
        public async Task<IActionResult> RegistrarEvaluacion([FromBody] observacion_encargo observacion_encargo)
        {
            if (observacion_encargo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _encargoRepository.Registrar_Evaluacion(observacion_encargo);

            return NoContent();
        }

    }
}
