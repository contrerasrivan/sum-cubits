
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Status
{
    public class ReservationStatus : BaseEntty
    {
        public string NombreEstado { get; set; }
        public string Descripcion { get; set; }
    }
}
