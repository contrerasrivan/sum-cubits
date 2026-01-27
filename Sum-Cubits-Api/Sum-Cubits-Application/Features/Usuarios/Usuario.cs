


using Sum_Cubits_Application.Features.Roles;

namespace Sum_Cubits_Application.Features.Usuarios
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public Rol? Role { get; set; }
        public  string FullName { get; set; }
        public  string Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaBaja { get; set; }
        public  bool Activo { get; set; }
        public int? UsuarioBajaId { get; set; }
    }
}
