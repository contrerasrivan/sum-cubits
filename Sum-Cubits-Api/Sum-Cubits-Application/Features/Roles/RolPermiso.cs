
using Sum_Cubits_Application.Features.Permisos;

namespace Sum_Cubits_Application.Features.Roles
{
    public class RolPermiso
    {
        public int RolPermisoId { get; set; }
        public int RolId { get; set; }

        public Rol? Role { get; set; }
        public int PermisoId { get; set; }

        public Permiso? Permission { get; set; }
    }
}
