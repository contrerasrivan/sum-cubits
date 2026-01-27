using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Api.Endpoints.Reservas;
using Sum_Cubits_Application.Features.Reservas;
using Sum_Cubits_Application.Infrastructure.Services;

namespace Sum_Cubits_Api.Endpoints
{
    public static class ReservationEndpoints
    {
        public static IEndpointRouteBuilder MapReservationEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/reservations")
                .WithTags("Reservations")
                .WithOpenApi();

            //GetReservationsList
            group.MapGet("", GetReservationList.Handle)
                .WithName("GetReservationsList")
                .Produces<GetReservationList.Response>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            //Create Reservation
            group.MapPost("",CreateReservation.Handle)
                .WithName("CreateReservation")
                .Produces<CreateReservation.Response>(StatusCodes.Status201Created);

            return app;
        }
    }


    //(HttpContext context, [FromServices] QueryReserva queryReserva,
    //            [FromServices] UserService userService) => GetReservationList.Handle(context, queryReserva, userService)
}
