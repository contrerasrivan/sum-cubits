using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Api.Endpoints.Role
{
    public static class GetRole
    {
        public record Response(RolesDto? RoleDto);
        public static async Task<IResult> Handle(int? roleId, QueryRoles queryRole)
        {
            var role = await queryRole.Get(roleId);
            if (role == null)
            {
                return Results.NotFound();
            }
            var roleDto = new RolesDto
            {
                Id = role.RolId,
                NombreRol = role.NombreRol,
                FechaCreacion = role.FechaCreacion,
                FechaBaja = role.Fecha_Baja
            };
            return Results.Ok(new Response(roleDto));
        }
    }
}