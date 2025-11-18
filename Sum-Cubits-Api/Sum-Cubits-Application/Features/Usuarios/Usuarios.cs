
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Application.Features.Users
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public Roles? Role { get; set; }
        public  string FullName { get; set; }
        public  string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaBaja { get; set; }
        public  bool Activo { get; set; }
        public int UsuarioBajaId { get; set; }
    }
}
