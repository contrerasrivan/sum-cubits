
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Room
{
    public class Salones 
    {
        public int SalonId { get; set; }
        public string NombreSalon { get; set; }
        public int Capacidad { get; set; }
        public string Descripcion { get; set; }

        public decimal PrecioPorturno { get; set; }
        public bool Activo { get; set; }
    }
}
