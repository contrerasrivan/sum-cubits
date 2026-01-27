
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Roles
{
    public class Rol 
    {
        public int RolId { get; set; }
        public string NombreRol { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? Fecha_Baja { get; set; }
    }
}
