using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Rol;
using System.Linq.Expressions;

namespace Sum_Cubits_Api.Endpoints.Role
{
    public class GetRoleList
    {
        public record Response(List<RolesDto>? RoleDtos);

        public static async Task<IResult> Handle(QueryRoles queryRole)
        {
            var rolePredicate = BuildFilter();
            var roleList = await queryRole.GetList(rolePredicate);
            var roleDtoList = roleList
                .Select(role => new RolesDto
                {
                    Id = role.RolId,
                    NombreRol = role.NombreRol,
                    FechaCreacion = role.FechaCreacion,
                    FechaBaja = role.Fecha_Baja
                })
                .ToList();
            return Results.Ok(new Response(roleDtoList));
        }

        private static Expression<Func<Roles, bool>> BuildFilter()
        {
            return PredicateBuilder.New<Roles>(true);
        }
    }
}
