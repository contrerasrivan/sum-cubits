using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Views
{
    public class View : BaseEntty
    {
        public string? NombreVista { get; set; }
        public string Icono { get; set; }
        public string Ruta { get; set; }
    }
}
