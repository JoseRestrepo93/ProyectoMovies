using System.ComponentModel.DataAnnotations;

namespace ProyectoMovies.Modelos
{
    public class Funcion
    {
        [Key]
        public int Id { get; set; }
        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }

}
