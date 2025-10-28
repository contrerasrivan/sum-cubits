
using Sum_Cubits_Application.Features.Views;

namespace Sum_Cubits_Application.Features.Roles
{
    public class RoleView
    {
        public int RolId { get; set; }
        public Role? Role { get; set; }
        public int VistaId { get; set; }
        public View? View { get; set; }
    }
}
