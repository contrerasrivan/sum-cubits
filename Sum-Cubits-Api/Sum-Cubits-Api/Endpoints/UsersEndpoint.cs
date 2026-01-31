using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Api.Endpoints.Users;
using Sum_Cubits_Application.Infrastructure.Services;

namespace Sum_Cubits_Api.Endpoints
{
    public static class UsersEndpoint
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/users")
                .WithTags("Users")
                .WithOpenApi();
            //Get User List
            group.MapGet("/", GetUserList.Handle)
                .WithName("GetUserList")
                .Produces<GetUserList.Response>(StatusCodes.Status200OK);

            //Get User Rol Id
            group.MapGet("/rol", GetUserRolId.Handle)
                .WithName("GetUserRolId")
                .Produces<GetUserRolId.Response>(StatusCodes.Status200OK);


            return app;
        }
    }
}
