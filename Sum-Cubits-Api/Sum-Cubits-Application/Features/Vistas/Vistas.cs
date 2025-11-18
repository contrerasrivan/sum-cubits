using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Views
{
    public class Vistas
    {
        public int VistaId { get; set; }
        public string NombreVista { get; set; }
        public string? Icono { get; set; }
        public string? Ruta { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Update { get; set; }
    }
}
