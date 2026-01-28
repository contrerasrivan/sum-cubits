using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Reservas;
using Sum_Cubits_Application.Features.Usuarios;
using Sum_Cubits_Application.Infrastructure.Services;
using System.Security.Claims;

namespace Sum_Cubits_Api.Endpoints.Reservas
{
    public static class CreateReservation
    {
        public record Request(DateOnly FechaReserva,
            int idSalon,
            int[] idTurnos,
            int idEstado);
        public record Response(int[] reservationId);

        [Authorize]
        public static async Task<IResult> Handle([FromBody] Request request,HttpContext httpContext, [FromServices] QueryReserva queryReservation, [FromServices] QueryUsuario queryUsuarios, [FromServices] UserService userService)
        {
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email).Value
                ?? httpContext.User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(userEmail))
                return Results.Unauthorized();

            var userId = await userService.GetUserId(userEmail);
            if (userId == null)
            {
                return Results.NotFound();
            }

            if (request.idTurnos == null || request.idTurnos.Length == 0)
            {
                return Results.BadRequest("Debe seleccionar al menos un turno");
            }

            var turnsOcuped = await queryReservation.CheckTurnOcuped(request.FechaReserva, request.idSalon, request.idTurnos);

            if (turnsOcuped.Any())
            {
                var turnsOcupedStr = string.Join(", ", turnsOcuped);
                return Results.Conflict($"Los siguientes turnos ya están ocupados: {turnsOcupedStr}");
            }

            var reservationIds = new List<int>();

            foreach (var idTurno in request.idTurnos)
            {
                var entity = new Reserva
                {
                    UsuarioId = userId,
                    SalonId = request.idSalon,
                    TurnoId = idTurno,
                    FechaReserva = request.FechaReserva
                };
                await queryReservation.Create(entity);
                reservationIds.Add(entity.ReservaId);
            }
            return Results.Created($"/reservations", new Response(reservationIds.ToArray()));
        }
    }
}
