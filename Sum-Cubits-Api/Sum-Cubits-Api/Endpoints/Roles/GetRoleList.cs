using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Roles;
using System.Linq.Expressions;

namespace Sum_Cubits_Api.Endpoints.Roles
{
    public class GetRoleList
    {
        public record Response(List<RolDto>? RoleDtos);

        public static async Task<IResult> Handle(QueryRol queryRole)
        {
            var rolePredicate = BuildFilter();
            var roleList = await queryRole.GetList(rolePredicate);
            var roleDtoList = roleList
                .Select(role => new RolDto
                {
                    Id = role.RolId,
                    NombreRol = role.NombreRol,
                    FechaCreacion = role.FechaCreacion,
                    Fecha_Baja = role.Fecha_Baja
                })
                .ToList();
            return Results.Ok(new Response(roleDtoList));
        }

        private static Expression<Func<Rol, bool>> BuildFilter()
        {
            return PredicateBuilder.New<Rol>(true);
        }
    }
}
