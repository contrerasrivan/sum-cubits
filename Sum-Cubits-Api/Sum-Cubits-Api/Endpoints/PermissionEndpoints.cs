using Sum_Cubits_Api.Endpoints.Permissions;

namespace Sum_Cubits_Api.Endpoints
{
    public static class PermissionEndpoints
    {
        public static IEndpointRouteBuilder MapPermissionEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/permissions")
                .WithTags("Permissions")
                .WithOpenApi();

            // Get Permission List
            group.MapGet("/", GetPermissionList.Handle)
                .WithName("GetPermissionList")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
