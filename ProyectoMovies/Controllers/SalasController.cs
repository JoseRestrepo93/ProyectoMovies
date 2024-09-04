using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMovies.Datos;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly BdMoviesContext _context;

        public SalasController(BdMoviesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarSala([FromBody] Sala nuevaSala)
        {
            _context.Salas.Add(nuevaSala);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerSalaPorId), new { idSala = nuevaSala.IdSala }, nuevaSala);
        }

        [HttpGet("{idSala}")]
        public async Task<IActionResult> ObtenerSalaPorId(int idSala)
        {
            var sala = await _context.Salas.FindAsync(idSala);
            if (sala == null)
                return NotFound();
            return Ok(sala);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerSalas()
        {
            var salas = await _context.Salas.ToListAsync();
            return Ok(salas);
        }
    }

}
