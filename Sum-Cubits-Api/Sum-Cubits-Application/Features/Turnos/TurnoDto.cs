
namespace Sum_Cubits_Application.Features.Turnos
{
    public class TurnoDto
    {
        public int TurnoId { get; set; }
        public int ReservaId { get; set; }
        public string? NombreTurno { get; set; }
        public string? NombreSalon { get; set; }
        public bool Disponibili { get; set; }


        public TurnoDto(int reservaId, string? nombreTurno, string? nombreSalon)
        {
            ReservaId = reservaId;
            NombreTurno = nombreTurno;
            NombreSalon = nombreSalon;
        }

        public TurnoDto(int turnoId, string? nombreTurno, bool disponibili)
        {
            TurnoId = turnoId;
            NombreTurno = nombreTurno;
            Disponibili = disponibili;
        }
    }
}
