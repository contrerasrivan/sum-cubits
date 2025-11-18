using Sum_Cubits_Api.Endpoints.Permissions;
using Sum_Cubits_Api.Endpoints.Role;
using Sum_Cubits_Api.Endpoints.Views;

namespace Sum_Cubits_Api.Endpoints
{
    public static class RolesEndpoints
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
                .WithName("GetRoleViewList")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            //Get Role Permissions
            group.MapGet("{roleId:int}/permissions", GetPermissionList.Handle)
                .WithName("GetRolePermissionList")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
