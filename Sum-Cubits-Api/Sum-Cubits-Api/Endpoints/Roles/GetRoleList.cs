using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Roles;
using System.Linq.Expressions;

namespace Sum_Cubits_Api.Endpoints.Roles
{
    public class GetRoleList
    {
        public record Response(List<RoleDto>? RoleDtos);

        public static async Task<IResult> Handle(
            [FromQuery] int Page,
            [FromQuery] int Size,
            [FromQuery]int? roleId,
            [FromServices] QueryRole queryRole)
        {
            var take = Size;
            var skip = Size * Page;
            var rolePredicate = BuildFilter(Page, Size, roleId);
            var roleList = await queryRole.GetList(rolePredicate,skip,take);
            var roleDtoList = roleList
                .Select(role => new RoleDto
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

        private static Expression<Func<Role, bool>> BuildFilter(int? page,int? size,int? roleId)
        {
            return PredicateBuilder.New<Role>(true);
        }
    }
}
