using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Api.Endpoints.Role
{
    public static class GetRole
    {
        public record Response(RolesDto? RoleDto);
        public static async Task<IResult> Handle([FromRoute] int RoleId, [FromServices] QueryRoles queryRole)
        {
            var role = await queryRole.Get(RoleId);
            if (role == null)
            {
                return Results.NotFound();
            }
            var roleDto = new RolesDto
            {
                Id = role.Id,
                NombreRol = role.NombreRol
            };
            return Results.Ok(new Response(roleDto));
        }
    }
}
