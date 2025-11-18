using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Permissions;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Api.Endpoints.Permissions
{
    public class GetPermissionList
    {
        public record Response(List<PermisosDto>? PermissionDtos);

        public static async Task<Response> Handle([FromQuery] int? RoleId, [FromServices] QueryPermisos queryPermission, [FromServices] QueryRoles queryRole)
        {
            if (RoleId.HasValue)
            {
                var rolePermissionList = await queryRole.GetRolePermissionList(RoleId.Value);

                var permission = rolePermissionList
                    .Select(rp => new PermisosDto
                    {
                        Id = rp.Permission.PermisoId,
                        Accion = rp.Permission.Accion,
                        Controlador = rp.Permission.Controlador
                    }).ToList();

                return new Response(permission);
            }

            var permissionList = await queryPermission.GetList();
            var permissionDtoList = permissionList
                .Select(permission => new PermisosDto
                {
                    Id = permission.PermisoId,
                    Accion = permission.Accion,
                    Controlador = permission.Controlador
                })
                .ToList();
            return new Response(permissionDtoList);
        }
    }
}
