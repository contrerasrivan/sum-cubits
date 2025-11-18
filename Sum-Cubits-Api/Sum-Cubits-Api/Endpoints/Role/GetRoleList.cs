using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Rol;
using System.Linq.Expressions;

namespace Sum_Cubits_Api.Endpoints.Role
{
    public class GetRoleList
    {
        public record Response(List<RolesDto>? RoleDtos);

        public static async Task<IResult> Handle(
            [FromQuery] int Page,
            [FromQuery] int Size,
            [FromQuery]int? roleId,
            [FromServices] QueryRoles queryRole)
        {
            var take = Size;
            var skip = Size * Page;
            var rolePredicate = BuildFilter(Page, Size, roleId);
            var roleList = await queryRole.GetList(rolePredicate,skip,take);
            var roleDtoList = roleList
                .Select(role => new RolesDto
                {
                    Id = role.Id,
                    NombreRol = role.NombreRol,
                    Created = role.Created,
                    Update = role.Updated,
                    Deleted = role.Deleted
                })
                .ToList();
            return Results.Ok(new Response(roleDtoList));
        }

        private static Expression<Func<Roles, bool>> BuildFilter(int? page,int? size,int? roleId)
        {
            return PredicateBuilder.New<Roles>(true);
        }
    }
}
