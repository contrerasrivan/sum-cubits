using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Users
{
    public class User : BaseEntty
    {
        public int RolId { get; set; }

        public Role? Role { get; set; }
        public  string NombreCompleto { get; set; }
        public  string Email { get; set; }
        public  bool Activo { get; set; }
        public int UsuarioBajaID { get; set; }
    }
}
