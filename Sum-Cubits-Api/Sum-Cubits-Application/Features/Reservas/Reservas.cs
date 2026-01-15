using Sum_Cubits_Application.Features.Room;
using Sum_Cubits_Application.Features.Status;
using Sum_Cubits_Application.Features.Turns;
using Sum_Cubits_Application.Features.Usuarios;


namespace Sum_Cubits_Application.Features.Reservation
{
    public class Reservas
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public UsuariosDto? User { get; set; }
        public int SalonId { get; set; }
        public Salones? Lounge { get; set; }
        public int TurnoId { get; set; }
        public Turnos? Turn { get; set; }
        public int EstadoId { get; set; }
        public EstadosReserva? Estado { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int  CantidadPersonas  { get; set; }
        public string Observaciones { get; set; }
    }
}
