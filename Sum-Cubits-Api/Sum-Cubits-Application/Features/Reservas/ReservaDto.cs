
namespace Sum_Cubits_Application.Features.Reservas
{
    public class ReservaDto
    {
        public int ReservaId { get; set; }
        public DateOnly FechaReserva { get; set; }
        public string? FullNameUsuario { get; set; }

        public string? Estado { get; set; }
    }
}
