
using Sum_Cubits_Application.Features.Turns;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Record
{
    public class HistorialTurnos : BaseEntty
    {
        public int TurnoId { get; set; }
        public Turnos? Turn { get; set; }

        public DateTime HoraInicioAnterior { get; set; }
        public DateTime HoraFinAnterior { get; set; }
        public DateTime HoraInicioNuevo { get; set; }
        public DateTime HoraFinNuevo { get; set; }
        public int UsuarioModificadorId { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Motivo { get; set; }
    }
}
