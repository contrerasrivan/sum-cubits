using Sum_Cubits_Api.Endpoints.Permisos;

namespace Sum_Cubits_Api.Endpoints
{
    public static class PermisosEndpoints
    {
        public static IEndpointRouteBuilder MapPermissionEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/permissions")
                .WithTags("Permissions")
                .WithOpenApi()
                .RequireAuthorization("Default");

            // Get Permission List
            group.MapGet("/", GetPermissionList.Handle)
                .WithName("GetPermissionList")
                .RequireAuthorization("Default")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
