using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMovies.Datos;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionesController : ControllerBase
    {
        private readonly BdMoviesContext _context;

        public FuncionesController(BdMoviesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarFuncion([FromBody] Funcion nuevaFuncion)
        {
            _context.Funciones.Add(nuevaFuncion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerFuncionPorId), new { id = nuevaFuncion.Id }, nuevaFuncion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerFuncionPorId(int id)
        {
            var funcion = await _context.Funciones.FindAsync(id);
            if (funcion == null)
                return NotFound();
            return Ok(funcion);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFunciones()
        {
            var funciones = await _context.Funciones.ToListAsync();
            return Ok(funciones);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarFuncion(int id)
        {
            var funcion = await _context.Funciones.FindAsync(id);
            if (funcion == null)
                return NotFound();

            _context.Funciones.Remove(funcion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
