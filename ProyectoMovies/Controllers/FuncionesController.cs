using Microsoft.AspNetCore.Mvc;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionesController : ControllerBase
    {
        private static List<Funcion> funciones = new List<Funcion>();

        [HttpPost]
        public IActionResult RegistrarFuncion([FromBody] Funcion nuevaFuncion)
        {
            funciones.Add(nuevaFuncion);
            return CreatedAtAction(nameof(ObtenerFuncionPorId), new { id = nuevaFuncion.Id }, nuevaFuncion);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerFuncionPorId(int id)
        {
            var funcion = funciones.FirstOrDefault(f => f.Id == id);
            if (funcion == null)
                return NotFound();
            return Ok(funcion);
        }

        [HttpGet]
        public IActionResult ObtenerFunciones()
        {
            return Ok(funciones);
        }

        [HttpDelete("{id}")]
        public IActionResult CancelarFuncion(int id)
        {
            var funcion = funciones.FirstOrDefault(f => f.Id == id);
            if (funcion == null)
                return NotFound();

            funciones.Remove(funcion);
            return NoContent();
        }
    }

}
