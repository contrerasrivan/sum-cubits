using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Reservas;
using Sum_Cubits_Application.Features.Usuarios;
using Sum_Cubits_Application.Infrastructure.Services;

namespace Sum_Cubits_Api.Endpoints.Reservas
{
    public static class CreateReservation
    {
        public record Request(DateOnly FechaReserva,
            DateTime FechaSolicitud,
            string userEmail,
            int idSalon,
            int idTurno,
            int idEstado);
        public record Response(int reservationId);

        public static async Task<IResult> Handle([FromBody]Request request, [FromServices] QueryReserva queryReservation, [FromServices] QueryUsuario queryUsuarios, [FromServices] UserService userService)
        {
            var userId = await userService.GetUserId(request.userEmail);
            if (userId == null)
            {
                return Results.NotFound();
            }
            var entity = new Reserva
            {
                UsuarioId = userId,
                SalonId = request.idSalon,
                TurnoId = request.idTurno,
                EstadoId = request.idEstado,
                FechaReserva = request.FechaReserva,
                FechaSolicitud = request.FechaSolicitud
            };
            await queryReservation.Create(entity);
            return Results.Created($"/reservations/{entity.ReservaId}", new Response(entity.ReservaId));
        }
    }
}
