using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Roles;

namespace Sum_Cubits_Api.Endpoints.Roles
{
    public static class GetRole
    {
        public record Response(RolDto? RoleDto);
        public static async Task<IResult> Handle(int? roleId, QueryRol queryRole)
        {
            var role = await queryRole.Get(roleId);
            if (role == null)
            {
                return Results.NotFound();
            }
            var roleDto = new RolDto
            {
                Id = role.RolId,
                NombreRol = role.NombreRol,
                FechaCreacion = role.FechaCreacion,
                Fecha_Baja = role.Fecha_Baja
            };
            return Results.Ok(new Response(roleDto));
        }
    }
}