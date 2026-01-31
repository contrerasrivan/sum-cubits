using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Infrastructure.Services;
using System.Security.Claims;

namespace Sum_Cubits_Api.Endpoints.Users
{
    public class GetUserRolId
    {
        public record Response(int RoleId);
        public static async Task<IResult> Handle(
            HttpContext httpContext,
            [FromServices] UserService userService)
        {
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email).Value
                ?? httpContext.User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(userEmail))
                return Results.Unauthorized();

            var roleId = await userService.GetUserId(userEmail);

            if (roleId == null || roleId == 0)
            {
                return Results.NotFound("Usuario no encontrado");
            }

            if (roleId == null)
                return Results.NotFound("Rol no encontrado para el usuario.");

            return Results.Ok(new Response(roleId));
        }
    }
}