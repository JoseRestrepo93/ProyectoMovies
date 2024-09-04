using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMovies.Datos;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly BdMoviesContext _context;

        public BoletosController(BdMoviesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ComprarBoleto([FromBody] Boleto nuevoBoleto)
        {
            var boletoExistente = await _context.Boletos
                .FirstOrDefaultAsync(b => b.IdFuncion == nuevoBoleto.IdFuncion && b.NumeroAsiento == nuevoBoleto.NumeroAsiento);

            if (boletoExistente != null && boletoExistente.EstaReservado)
                return BadRequest("El asiento ya está reservado.");

            nuevoBoleto.EstaReservado = true;
            nuevoBoleto.FechaHoraCompra = DateTime.Now;
            _context.Boletos.Add(nuevoBoleto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerBoletoPorId), new { id = nuevoBoleto.Id }, nuevoBoleto);
        }

        [HttpGet("estado/{idFuncion}")]
        public async Task<IActionResult> VerificarEstadoAsientos(int idFuncion)
        {
            var boletosFuncion = await _context.Boletos
                .Where(b => b.IdFuncion == idFuncion)
                .ToListAsync();

            var asientosDisponibles = Enumerable.Range(1, 100) // Ejemplo: 100 asientos por sala
                .Select(asiento => new
                {
                    NumeroAsiento = asiento,
                    Estado = boletosFuncion.Any(b => b.NumeroAsiento == asiento && b.EstaReservado)
                        ? "Reservado"
                        : "Disponible"
                }).ToList();

            return Ok(asientosDisponibles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerBoletoPorId(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
                return NotFound();
            return Ok(boleto);
        }
    }

}
