using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Permissions;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Api.Endpoints.Permissions
{
    public class GetPermissionList
    {
        public record Response(List<PermisosDto>? PermissionDtos);

        public static async Task<IResult> Handle(int? roleId, QueryPermisos queryPermission, QueryRoles queryRole)
        {
            var permissionList = await queryPermission.GetList();
            var permissionDtoList = permissionList
                .Select(permission => new PermisosDto
                {
                    Id = permission.PermisoId,
                    Accion = permission.Accion,
                    Controlador = permission.Controlador
                })
                .ToList();
            return Results.Ok(new Response(permissionDtoList));
        }
    }
}
