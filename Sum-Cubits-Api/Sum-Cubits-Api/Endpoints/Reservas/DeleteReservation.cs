using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Reservas;
using Sum_Cubits_Application.Infrastructure.Services;
using System.Security.Claims;

namespace Sum_Cubits_Api.Endpoints.Reservas
{
    public static class DeleteReservation
    {
        public record Request(DateOnly fechaReserva);
        public record Response();

        public static async Task<IResult> Handle([FromBody]Request request,HttpContext httpContext, [FromServices] QueryReserva queryReserva, [FromServices] UserService userService)
        {
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email).Value
                ?? httpContext.User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(userEmail))
                return Results.Unauthorized();

            var userId = await userService.GetUserId(userEmail);

            var entity = new Reserva
            {
                UsuarioId = userId,
                FechaReserva = request.fechaReserva
            };

            await queryReserva.Cancel(entity);
            return Results.Ok(new Response());
        }
    }
}
