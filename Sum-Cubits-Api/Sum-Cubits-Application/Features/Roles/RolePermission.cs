
using Sum_Cubits_Application.Features.Permissions;

namespace Sum_Cubits_Application.Features.Roles
{
    public class RolePermission
    {
        public int RolPermisoId { get; set; }
        public int RolId { get; set; }

        public Role? Role { get; set; }
        public int PermisoId { get; set; }

        public Permission? Permission { get; set; }
    }
}
