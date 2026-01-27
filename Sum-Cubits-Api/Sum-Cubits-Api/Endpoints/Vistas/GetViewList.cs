
using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Features.Vistas;

namespace Sum_Cubits_Api.Endpoints.Vistas
{
    public class GetViewList
    {
        public record Response(List<VistaDto>? ViewDtos);

        public static async Task<IResult> Handle(int? roleId, QueryVista queryView, QueryRol queryRole)
        {
            if (roleId.HasValue)
            {
                var roleViewList = await queryRole.GetRoleViewList(roleId);
                var roleViewListDto = roleViewList
                    .Select(rv => new VistaDto
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
                .Select(view => new VistaDto
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