using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Rol;
using Sum_Cubits_Application.Features.Views;

namespace Sum_Cubits_Api.Endpoints.Views
{
    public class GetViewList
    {
        public record Response (List<VistasDto>? ViewDtos);

        public static async Task<Response> Handle([FromQuery] int? RolId ,[FromServices] QueryVistas queryView, [FromServices] QueryRoles queryRole)
        {
            if (RolId.HasValue)
            {
                var roleViewList = await queryRole.GetRoleViewList(RolId.Value);

                var view = roleViewList
                    .Select(rv => new VistasDto
                    {
                        Id = rv.View.VistaId,
                        NombreVista = rv.View.NombreVista,
                        Icono = rv.View.Icono,
                        Ruta = rv.View.Ruta
                    }).ToList();
                return new Response(view);
            }
            var viewList = await queryView.GetList();
            var viewDtoList = viewList
                .Select(view => new VistasDto
                {
                    Id = view.VistaId,
                    NombreVista = view.NombreVista,
                    Icono = view.Icono,
                    Ruta = view.Ruta
                })
                .ToList();
            return new Response(viewDtoList);
        }
    }
}
