using Sum_Cubits_Application.Features.EstadosReserva;
using Sum_Cubits_Application.Features.Salones;
using Sum_Cubits_Application.Features.Turnos;
using Sum_Cubits_Application.Features.Usuarios;


namespace Sum_Cubits_Application.Features.Reservas
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? SalonId { get; set; }
        public Salon? Salon { get; set; }
        public int? TurnoId { get; set; }
        public Turno? Turno { get; set; }
        public int EstadoId { get; set; }
        public Estado? Estado { get; set; }
        public DateOnly FechaReserva { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public int? CantidadPersonas  { get; set; }
        public string? Observaciones { get; set; }
    }
}
