using Microsoft.AspNetCore.Mvc;
using Sum_Cubits_Application.Features.Usuarios;

namespace Sum_Cubits_Api.Endpoints.User
{
    public class GetUserList
    {
        public record Response(List<UsuariosDto> userDto);
        public static async Task<IResult> Handle(QueryUsuarios queryUsuarios)
        {
            var userList = await queryUsuarios.GetList();
            var userDtoList = userList
                .Select(user => new UsuariosDto
            {
                Id = user.UsuarioId,
                FullName = user.FullName,
                Email = user.Email,
                Telefono = user.Telefono
                }).ToList();
            return Results.Ok(new Response(userDtoList));
        }
    }
}
