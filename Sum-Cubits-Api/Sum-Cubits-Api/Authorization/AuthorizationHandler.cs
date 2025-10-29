using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Sum_Cubits_Application.Infrastructure;
using Sum_Cubits_Application.Infrastructure.Services;
using System.Security.Claims;

namespace Sum_Cubits_Api.Authorization
{
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly UserService userService;
        private readonly PermissionService permissionService;


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
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await userService.GetRoleId(userId, userEmail) ?? throw new Exception();
        }


    }
}
