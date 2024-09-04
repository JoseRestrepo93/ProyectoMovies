using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMovies.Datos;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        //private static List<Pelicula> peliculas = new List<Pelicula>();

        private readonly BdMoviesContext _context;

        public PeliculasController(BdMoviesContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CrearPelicula([FromBody] Pelicula nuevaPelicula)
        {
            _context.Peliculas.Add(nuevaPelicula);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerPeliculaPorId), new { id = nuevaPelicula.Id }, nuevaPelicula);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPeliculaPorId(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
                return NotFound();
            return Ok(pelicula);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPeliculas()
        {
            var peliculas = await _context.Peliculas.ToListAsync();
            return Ok(peliculas);
        }
    }
}


