using System.ComponentModel.DataAnnotations;

namespace ProyectoMovies.Modelos
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }
        public int IdFuncion { get; set; }
        public int NumeroAsiento { get; set; }
        public bool EstaReservado { get; set; }
        public DateTime FechaHoraCompra { get; set; }
    }

}
