using Microsoft.AspNetCore.Mvc;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletosController : ControllerBase
    {
        private static List<Boleto> boletos = new List<Boleto>();

        [HttpPost]
        public IActionResult ComprarBoleto([FromBody] Boleto nuevoBoleto)
        {
            var boletoExistente = boletos.FirstOrDefault(b => b.IdFuncion == nuevoBoleto.IdFuncion && b.NumeroAsiento == nuevoBoleto.NumeroAsiento);

            if (boletoExistente != null && boletoExistente.EstaReservado)
                return BadRequest("El asiento ya está reservado.");

            nuevoBoleto.EstaReservado = true;
            nuevoBoleto.FechaHoraCompra = DateTime.Now;
            boletos.Add(nuevoBoleto);
            return CreatedAtAction(nameof(ObtenerBoletoPorId), new { id = nuevoBoleto.Id }, nuevoBoleto);
        }

        [HttpGet("estado/{idFuncion}")]
        public IActionResult VerificarEstadoAsientos(int idFuncion)
        {
            var boletosFuncion = boletos.Where(b => b.IdFuncion == idFuncion).ToList();
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
        public IActionResult ObtenerBoletoPorId(int id)
        {
            var boleto = boletos.FirstOrDefault(b => b.Id == id);
            if (boleto == null)
                return NotFound();
            return Ok(boleto);
        }
    }

}
