using System.ComponentModel.DataAnnotations;

namespace ProyectoMovies.Modelos
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }
        public string NombreSala { get; set; }
        public int IdCine { get; set; }
        public int CapacidadTotal { get; set; }
        public string Descripcion { get; set; }
    }

}

