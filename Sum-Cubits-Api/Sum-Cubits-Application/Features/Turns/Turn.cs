
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Turns
{
    public class Turn : BaseEntty
    {
        public string NombreTurno { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public int UsuarioModificadorID { get; set; }
    }
}
