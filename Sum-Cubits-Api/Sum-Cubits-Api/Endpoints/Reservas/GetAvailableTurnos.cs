using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Reservas;
using Sum_Cubits_Application.Features.Turnos;

namespace Sum_Cubits_Api.Endpoints.Reservas
{
    public static class GetAvailableTurnos
    {
        public record Response(int turnoId, string nombre, bool disponibili);

        public static async Task<IResult> Handle(
            [FromQuery] DateOnly fechaReserva,
            [FromQuery] int salonId,
            [FromServices] QueryReserva queryReserva,
            [FromServices] QueryTurno queryTurno)
        {
            var allTurns = await queryTurno.GetList();

            var dayOfWeek = fechaReserva.DayOfWeek;
            var isWeekend = dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;

            var turnsPermited = isWeekend
                ? allTurns
                : allTurns.Where(t => t.NombreTurno.Equals("Noche", StringComparison.OrdinalIgnoreCase)).ToList();

            var turnsPermitedIds = turnsPermited.Select(t => t.TurnoId).ToArray();

            var turnsDisponibili = await queryReserva.GetTurnsDisponibili(fechaReserva, salonId, turnsPermitedIds);

            var response = allTurns
                .Select(t => new Response(
                    t.TurnoId,
                    t.NombreTurno,
                    turnsDisponibili.Contains(t.TurnoId)
                )).ToList();

            return Results.Ok(response);
        }
    }
}
