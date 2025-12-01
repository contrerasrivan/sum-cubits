using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Api.Endpoints.Permissions;
using Sum_Cubits_Api.Endpoints.Role;
using Sum_Cubits_Api.Endpoints.Views;
using Sum_Cubits_Application.Features.Permissions;
using Sum_Cubits_Application.Features.Rol;
using Sum_Cubits_Application.Features.Views;

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
            group.MapGet("{roleId:int}", ([FromRoute] int? roleId, [FromServices] QueryRoles queryRole) => GetRole.Handle(roleId, queryRole))
                .WithName("GetRole")
                .Produces<GetRole.Response>(StatusCodes.Status200OK);

            //Get Role List
            group.MapGet("/", GetRoleList.Handle)
                .WithName("GetRoleList")
                .Produces<GetRoleList.Response>(StatusCodes.Status200OK);

            //Get Role Views
            group.MapGet("{roleId:int}/views", ([FromRoute] int? roleId, [FromServices] QueryVistas queryVistas,[FromServices] QueryRoles queryRole) => GetViewList.Handle(roleId,queryVistas,queryRole))
                .WithName("GetRoleViewList")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            //Get Role Permissions
            group.MapGet("{roleId:int}/permissions", ([FromRoute] int roleId, [FromServices] QueryPermisos queryPermisos, QueryRoles queryRoles) => GetPermissionList.Handle(roleId,queryPermisos,queryRoles))
                .WithName("GetRolePermissionList")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
