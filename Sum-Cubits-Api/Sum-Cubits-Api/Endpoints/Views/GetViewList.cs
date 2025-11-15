using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Features.Views;

namespace Sum_Cubits_Api.Endpoints.Views
{
    public class GetViewList
    {
        public record Response (List<ViewDto>? ViewDtos);

        public static async Task<Response> Handle([FromQuery] int? RolId ,[FromServices] QueryView queryView, [FromServices] QueryRole queryRole)
        {
            if (RolId.HasValue)
            {
                var roleViewList = await queryRole.GetRoleViewList(RolId.Value);

                var view = roleViewList
                    .Select(rv => new ViewDto
                    {
                        Id = rv.View.Id,
                        NombreVista = rv.View.NombreVista,
                        Icono = rv.View.Icono,
                        Ruta = rv.View.Ruta
                    }).ToList();
                return new Response(view);
            }
            var viewList = await queryView.GetList();
            var viewDtoList = viewList
                .Select(view => new ViewDto
                {
                    Id = view.Id,
                    NombreVista = view.NombreVista,
                    Icono = view.Icono,
                    Ruta = view.Ruta
                })
                .ToList();
            return new Response(viewDtoList);
        }
    }
}
