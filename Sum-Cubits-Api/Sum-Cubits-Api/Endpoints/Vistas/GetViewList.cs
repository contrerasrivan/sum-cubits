using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sum_Cubits_Application.Features.Rol;
using Sum_Cubits_Application.Features.Views;

namespace Sum_Cubits_Api.Endpoints.Views
{
    public class GetViewList
    {
        public record Response(List<VistasDto>? ViewDtos);

        public static async Task<IResult> Handle(int? roleId, QueryVistas queryView, QueryRoles queryRole)
        {
            if (roleId.HasValue)
            {
                var roleViewList = await queryRole.GetRoleViewList(roleId);
                var roleViewListDto = roleViewList
                    .Select(rv => new VistasDto
                    {
                        Id = rv.VistaId,
                        NombreVista = rv.View.NombreVista,
                        Icono = rv.View.Icono,
                        Ruta = rv.View.Ruta
                    })
                    .ToList();
                return Results.Ok(new Response(roleViewListDto));
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
            return Results.Ok(new Response(viewDtoList));
        }
    }
}