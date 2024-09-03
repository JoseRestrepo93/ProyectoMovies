namespace ProyectoMovies.Modelos
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Duracion { get; set; } // Duración en minutos
        public string Sinopsis { get; set; }
        public int AñoEstreno { get; set; }
        public string ClasificacionEdad { get; set; }
    }

}


