using Sum_Cubits_Application.Features.Room;
using Sum_Cubits_Application.Features.Status;
using Sum_Cubits_Application.Features.Turns;
using Sum_Cubits_Application.Features.Users;
using Sum_Cubits_Application.Infrastructure.Database;


namespace Sum_Cubits_Application.Features.Reservation
{
    public class Reservation : BaseEntty
    {
        public int UsuarioId { get; set; }
        public User? User { get; set; }
        public int SalonId { get; set; }
        public Lounge? Lounge { get; set; }
        public int TurnoId { get; set; }
        public Turn? Turn { get; set; }
        public int EstadoId { get; set; }
        public ReservationStatus? Estado { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int  CantidadPersonas  { get; set; }
        public string Observaciones { get; set; }
    }
}
