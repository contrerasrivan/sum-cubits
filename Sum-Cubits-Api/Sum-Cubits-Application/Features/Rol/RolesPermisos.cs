
using Sum_Cubits_Application.Features.Permissions;

namespace Sum_Cubits_Application.Features.Rol
{
    public class RolesPermisos
    {
        public int RolPermisoId { get; set; }
        public int RolId { get; set; }

        public Roles? Role { get; set; }
        public int PermisoId { get; set; }

        public Permisos? Permission { get; set; }
    }
}
