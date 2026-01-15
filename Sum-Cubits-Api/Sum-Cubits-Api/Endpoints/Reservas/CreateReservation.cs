using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Reservation;
using Sum_Cubits_Application.Features.Usuarios;

namespace Sum_Cubits_Api.Endpoints.Reservas
{
    public static class CreateReservation
    {
        public record Request(DateTime FechaReserva,
            DateTime FechaSolicitud,
            string UserEmail,
            int IdSalon);
        public record Response(int reservationId);

        public static async Task<IResult> Handle([FromBody]Request request, [FromServices] QueryReservation queryReservation, [FromServices] QueryUsuarios queryUsuarios)
        {
            var usuario = await queryUsuarios.Get(request.UserEmail);
            if (usuario == null)
            {
                return Results.NotFound();
            }
            var entity = new Reservation
            {
                UsuarioId = usuario.UsuarioId,
                SalonId = request.IdSalon,
                FechaReserva = request.FechaReserva,
                FechaSolicitud = request.FechaSolicitud
            };
            await queryReservation.Create(entity);
            return Results.Created($"/reservations/{entity.ReservaId}", new Response(entity.ReservaId));
        }
    }
}
