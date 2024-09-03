using Microsoft.AspNetCore.Mvc;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private static List<Pelicula> peliculas = new List<Pelicula>();

        [HttpPost]
        public IActionResult CrearPelicula([FromBody] Pelicula nuevaPelicula)
        {
            peliculas.Add(nuevaPelicula);
            return CreatedAtAction(nameof(ObtenerPeliculaPorId), new { id = nuevaPelicula.Id }, nuevaPelicula);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPeliculaPorId(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
            if (pelicula == null)
                return NotFound();
            return Ok(pelicula);
        }

        [HttpGet]
        public IActionResult ObtenerPeliculas()
        {
            return Ok(peliculas);
        }
    }

}
