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
                .WithOpenApi();

            //Get Rol
            group.MapGet("{roleId:int}", ([FromRoute] int? roleId, [FromServices] QueryRol queryRole) => GetRole.Handle(roleId, queryRole))
                .WithName("GetRole")
                .Produces<GetRole.Response>(StatusCodes.Status200OK);

            //Get Role List
            group.MapGet("/", GetRoleList.Handle)
                .WithName("GetRoleList")
                .Produces<GetRoleList.Response>(StatusCodes.Status200OK);

            //Get Role Views
            group.MapGet("{roleId:int}/views", ([FromRoute] int? roleId, [FromServices] QueryVista queryVistas,[FromServices] QueryRol queryRole) => GetViewList.Handle(roleId,queryVistas,queryRole))
                .WithName("GetRoleViewList")
                .Produces<GetViewList.Response>(StatusCodes.Status200OK);

            //Get Role Permissions
            group.MapGet("{roleId:int}/permissions", ([FromRoute] int roleId, [FromServices] QueryPermiso queryPermisos, QueryRol queryRoles) => GetPermissionList.Handle(roleId,queryPermisos,queryRoles))
                .WithName("GetRolePermissionList")
                .Produces<GetPermissionList.Response>(StatusCodes.Status200OK);

            return app;
        }
    }
}
