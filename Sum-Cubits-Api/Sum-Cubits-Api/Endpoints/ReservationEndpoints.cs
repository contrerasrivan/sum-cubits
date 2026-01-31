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
                .WithOpenApi()
                .RequireAuthorization("Default");


            //GetReservationsList
            group.MapGet("", GetReservationList.Handle)
                .WithName("GetReservationsList")
                .RequireAuthorization("Default")
                .Produces<GetReservationList.Response>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            //GetAvailableTurnos
            group.MapGet("available-turns", GetAvailableTurnos.Handle)
                .WithName("GetAvailableTurnos")
                .RequireAuthorization("Default")
                .Produces<GetAvailableTurnos.Response>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            //Create Reservation
            group.MapPost("",CreateReservation.Handle)
                .WithName("CreateReservation")
                .RequireAuthorization("Default")
                .Produces<CreateReservation.Response>(StatusCodes.Status201Created);

            //Delete Reservation
            group.MapDelete("", DeleteReservation.Handle)
                .WithName("DeleteReservation")
                .RequireAuthorization("Default")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            return app;
        }
    }


    //(HttpContext context, [FromServices] QueryReserva queryReserva,
    //            [FromServices] UserService userService) => GetReservationList.Handle(context, queryReserva, userService)
}
