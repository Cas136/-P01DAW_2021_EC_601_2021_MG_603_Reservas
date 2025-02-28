namespace P01_2021_EC_601_2021_MG_603.Models
{
    public class Reservas
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public int EspacioId { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int CantidadHoras { get; set; }
        public string EstadoReserva { get; set; }
        public Usuarios Usuario { get; set; }
        public EspaciosParqueo EspaciosParqueo { get; set; }
    }
}
