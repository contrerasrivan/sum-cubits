
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Permisos
{
    public class Permiso 
    {
        public int PermisoId { get; set; }
        public string Accion { get; set; }

        public string Controlador { get; set; }

        public DateTime? Fecha_Alta { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public DateTime? Fecha_Baja { get; set; }
    }
}
