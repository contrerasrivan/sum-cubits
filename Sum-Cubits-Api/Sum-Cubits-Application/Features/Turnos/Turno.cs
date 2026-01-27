namespace Sum_Cubits_Application.Features.Turnos
{
    public class Turno 
    {
        public int TurnoId { get; set; }
        public string? NombreTurno { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public string? Descripcion { get; set; }

        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public int? UsuarioModificadorID { get; set; }
    }
}
