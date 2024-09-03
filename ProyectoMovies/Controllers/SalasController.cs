using Microsoft.AspNetCore.Mvc;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private static List<Sala> salas = new List<Sala>();

        [HttpPost]
        public IActionResult RegistrarSala([FromBody] Sala nuevaSala)
        {
            salas.Add(nuevaSala);
            return CreatedAtAction(nameof(ObtenerSalaPorId), new { idSala = nuevaSala.IdSala }, nuevaSala);
        }

        [HttpGet("{idSala}")]
        public IActionResult ObtenerSalaPorId(int idSala)
        {
            var sala = salas.FirstOrDefault(s => s.IdSala == idSala);
            if (sala == null)
                return NotFound();
            return Ok(sala);
        }

        [HttpGet]
        public IActionResult ObtenerSalas()
        {
            return Ok(salas);
        }
    }

}
