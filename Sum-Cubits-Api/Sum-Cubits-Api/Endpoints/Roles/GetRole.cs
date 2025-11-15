using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Roles;

namespace Sum_Cubits_Api.Endpoints.Roles
{
    public static class GetRole
    {
        public record Response(RoleDto? RoleDto);
        public static async Task<IResult> Handle([FromRoute] int RoleId, [FromServices] QueryRole queryRole)
        {
            var role = await queryRole.Get(RoleId);
            if (role == null)
            {
                return Results.NotFound();
            }
            var roleDto = new RoleDto
            {
                Id = role.Id,
                NombreRol = role.NombreRol
            };
            return Results.Ok(new Response(roleDto));
        }
    }
}
