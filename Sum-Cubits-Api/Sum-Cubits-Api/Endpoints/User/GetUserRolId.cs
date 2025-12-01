using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Infrastructure.Services;

namespace Sum_Cubits_Api.Endpoints.User
{
    public class GetUserRolId
    {
        public record Response(int RoleId);
        public static async Task<IResult> Handle(
            [FromRoute] string userEmail,
            [FromServices] UserService userService)
        {
            var roleId = await userService.GetRoleId(userEmail);

            if (roleId == null)
                return Results.NotFound("Rol no encontrado para el usuario.");

            return Results.Ok(new Response(roleId.Value));
        }
    }
}