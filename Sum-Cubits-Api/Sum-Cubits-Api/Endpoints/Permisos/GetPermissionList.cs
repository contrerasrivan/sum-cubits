using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Permisos;
using Sum_Cubits_Application.Features.Roles;

namespace Sum_Cubits_Api.Endpoints.Permisos
{
    public class GetPermissionList
    {
        public record Response(List<PermisoDto>? PermissionDtos);

        public static async Task<IResult> Handle(int? roleId, QueryPermiso queryPermission, QueryRol queryRole)
        {
            var permissionList = await queryPermission.GetList();
            var permissionDtoList = permissionList
                .Select(permission => new PermisoDto
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
