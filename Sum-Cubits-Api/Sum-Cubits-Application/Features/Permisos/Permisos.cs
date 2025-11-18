
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Permissions
{
    public class Permisos 
    {
        public int PermisoId { get; set; }
        public string Accion { get; set; }

        public string Controlador { get; set; }

        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
    }
}
