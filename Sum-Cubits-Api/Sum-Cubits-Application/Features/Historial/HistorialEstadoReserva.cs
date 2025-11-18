
using Sum_Cubits_Application.Features.Reservation;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Record
{
    public class HistorialEstadoReserva : BaseEntty
    {
        public int ReservaId { get; set; }

        //public Reservation? Reservation { get; set; }

        public int EstadoAnterior { get; set; }
        public int EstadoNuevo { get; set; }
        public DateTime FechaCambio { get; set; }
        public int UsuarioModificador { get; set; }
        public string? Comentario { get; set; }
    }
}
