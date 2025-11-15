using Sum_Cubits_Api.Endpoints.Permissions;
using Sum_Cubits_Api.Endpoints.Roles;
using Sum_Cubits_Api.Endpoints.Views;

namespace Sum_Cubits_Api.Endpoints
{
    public static class RoleEndpoints
    {
        public static IEndpointRouteBuilder MapRoleEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/roles")
                .WithTags("Roles")
                .WithOpenApi();

            //Get Rol
            group.MapGet("{roleId:int}",GetRole.Handle)
                .WithName("GetRole")
                .Produces<GetRole.Response>(StatusCodes.Status200OK);

            //Get Role List
            group.MapGet("/", GetRoleList.Handle)
                .WithName("GetRoleList")
                .Produces<GetRoleList.Response>(StatusCodes.Status200OK);

            //Get Role Views
            group.MapGet("{roleId:int}/views", GetViewList.Handle)
                .WithName("GetViewList")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            //Get Role Permissions
            group.MapGet("{roleId:int}/permissions", GetPermissionList.Handle)
                .WithName("GetPermissionList")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
