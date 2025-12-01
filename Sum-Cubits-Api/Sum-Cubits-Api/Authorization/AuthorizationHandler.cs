using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Sum_Cubits_Application.Features.Usuarios;
using Sum_Cubits_Application.Infrastructure;
using Sum_Cubits_Application.Infrastructure.Services;
using System.Security.Claims;

namespace Sum_Cubits_Api.Authorization
{
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly UserService userService;
        private readonly PermissionService permissionService;
        private readonly QueryUsuarios queryUser;

        public async Task HandleAsync(AuthorizationHandlerContext context)
        {
           foreach(var requirement in context.Requirements)
               if (IsAuthenticated(context) && await HavePermission(context))
                    context.Succeed(requirement);
           
        }

        private async Task<bool>HavePermission(AuthorizationHandlerContext context)
        {
            var roleId = await GetUserRoleId(context);
            var action = GetRequestAction(context);
            var controller = GetRequestController(context);

            return await permissionService.CheckPermission(roleId, action, controller);
        }

        private static bool IsAuthenticated(AuthorizationHandlerContext context)
        {
            return context.User.Identity!.IsAuthenticated;
        }

        private static string GetRequestAction(AuthorizationHandlerContext context)
        {
            return ((ControllerActionDescriptor)((ActionContext)context.Resource!).ActionDescriptor).ActionName;
        }

        private static string GetRequestController(AuthorizationHandlerContext context)
        {
            return ((ControllerActionDescriptor)((ActionContext)context.Resource!).ActionDescriptor).ControllerName;
        }

        private async Task<int> GetUserRoleId(AuthorizationHandlerContext context)
        {
            var userEmail = context.User.FindFirstValue(ClaimTypes.Email);

            // Obtener el usuario por email usando UserService
            var userList = await queryUser.GetList();
            var user = userList.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
                throw new Exception("Usuario no encontrado por email.");

            var userId = user.UsuarioId;
            return await userService.GetRoleId(userEmail) ?? throw new Exception("Rol no encontrado para el usuario.");
        }


    }
}
