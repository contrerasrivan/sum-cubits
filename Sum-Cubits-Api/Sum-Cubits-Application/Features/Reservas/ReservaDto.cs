using Sum_Cubits_Application.Features.Turnos;

namespace Sum_Cubits_Application.Features.Reservas
{
    public class ReservaDto
    {
        public DateOnly fechaReserva { get; set; }
        public List<TurnoDto>? TurnosDisponibles { get; set; }
    }
}
