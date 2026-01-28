using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Reservas;
using Sum_Cubits_Application.Infrastructure.Services;
using System.Security.Claims;

namespace Sum_Cubits_Api.Endpoints.Reservas
{
    public class GetReservationList
    {
        public record ReservationByDateDto(DateOnly fechaReserva,
            List<TurnoConfirmadoDto> TurnosConfirmados);

        public record TurnoConfirmadoDto(
            int reservaId,
            string? nombreTurno,
            string? nombreSalon
            );

        public record Response(List<ReservationByDateDto>? ReservationByDates);

        [Authorize]
        public static async Task<IResult> Handle(HttpContext httpContext,
            [FromServices]QueryReserva queryReserva, 
            [FromServices] UserService userService)
        {
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email).Value
                ?? httpContext.User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(userEmail))
                return Results.Unauthorized();

            var userId = await userService.GetUserId(userEmail);

            if (userId == null || userId == 0)
            {
                return Results.NotFound("Usuario no encontrado");
            }


                var reservationListPredicate = PredicateBuilder
                    .New<Reserva>()
                    .And(r => r.UsuarioId == userId);

                var reservationList = await queryReserva.GetList(reservationListPredicate);

                var reservationDtos = reservationList
                    .Where(r => r.Estado?.NombreEstado == "Confirmada")
                    .GroupBy(r => r.FechaReserva)
                    .Select(g => new ReservationByDateDto(
                        g.Key,
                        g.Select(r => new TurnoConfirmadoDto(
                            r.ReservaId,
                            r.Turno?.NombreTurno,
                            r.Salon?.Nombre
                            )).ToList()
                        ))
                    .OrderBy(x => x.fechaReserva)
                    .ToList();
                return Results.Ok(new Response(reservationDtos));
        }
    }
}
