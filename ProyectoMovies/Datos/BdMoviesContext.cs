using Microsoft.EntityFrameworkCore;
using ProyectoMovies.Modelos;

namespace ProyectoMovies.Datos
{
    public class BdMoviesContext :DbContext
    {

        public BdMoviesContext(DbContextOptions<BdMoviesContext> options) :base(options)
        {
            
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Boleto> Boletos { get; set; }

    }
}
