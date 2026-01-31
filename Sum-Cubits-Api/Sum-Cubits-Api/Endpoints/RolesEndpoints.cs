using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Api.Endpoints.Permisos;
using Sum_Cubits_Api.Endpoints.Roles;
using Sum_Cubits_Api.Endpoints.Vistas;
using Sum_Cubits_Application.Features.Permisos;
using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Features.Vistas;

namespace Sum_Cubits_Api.Endpoints
{
    public static class RolesEndpoints
    {
        public static IEndpointRouteBuilder MapRoleEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/roles")
                .WithTags("Roles")
                .WithOpenApi()
                .RequireAuthorization("Default");

            //Get Rol
            group.MapGet("{roleId:int}", GetRole.Handle)
                .WithName("GetRole")
                .RequireAuthorization("Default")
                .Produces<GetRole.Response>(StatusCodes.Status200OK);

            //Get Role List
            group.MapGet("/", GetRoleList.Handle)
                .WithName("GetRoleList")
                .RequireAuthorization("Default")
                .Produces<GetRoleList.Response>(StatusCodes.Status200OK);

            //Get Role Views
            group.MapGet("{roleId:int}/views", GetViewList.Handle)
                .WithName("GetRoleViewList")
                .RequireAuthorization("Default")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            //Get Role Permissions
            group.MapGet("{roleId:int}/permissions", GetPermissionList.Handle)
                .WithName("GetRolePermissionList")
                .RequireAuthorization("Default")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
