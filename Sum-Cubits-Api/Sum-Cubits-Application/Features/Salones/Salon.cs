
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Salones
{
    public class Salon 
    {
        public int SalonId { get; set; }
        public string? Nombre{ get; set; }
        public int? Capacidad { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
    }
}
