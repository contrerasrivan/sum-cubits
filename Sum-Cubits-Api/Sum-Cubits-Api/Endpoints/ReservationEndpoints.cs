using Sum_Cubits_Api.Endpoints.Reservas;

namespace Sum_Cubits_Api.Endpoints
{
    public static class ReservationEndpoints
    {
        public static IEndpointRouteBuilder MapReservationEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/reservations")
                .WithTags("Reservations")
                .WithOpenApi();

            //Create Reservation
            group.MapPost("",CreateReservation.Handle)
                .WithName("CreateReservation")
                .Produces<CreateReservation.Response>(StatusCodes.Status201Created);
            return app;
        }
    }
}
