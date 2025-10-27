
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Permissions
{
    public class Permission : BaseEntty
    {
        public string Accion { get; set; }

        public string Controlador { get; set; }

    }
}
