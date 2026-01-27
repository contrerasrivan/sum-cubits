using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Usuarios;

namespace Sum_Cubits_Api.Endpoints.Users
{
    public class GetUserList
    {
        public record Response(List<UsuarioDto> userDto);
        public static async Task<IResult> Handle(QueryUsuario queryUsuarios)
        {
            var userList = await queryUsuarios.GetList();
            var userDtoList = userList
                .Select(user => new UsuarioDto
            {
                FullName = user.FullName,
                Email = user.Email
                }).ToList();
            return Results.Ok(new Response(userDtoList));
        }
    }
}
