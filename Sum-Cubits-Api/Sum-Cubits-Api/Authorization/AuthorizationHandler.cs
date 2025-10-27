using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Sum_Cubits_Application.Interfaces;
using System.Security.Claims;

namespace Sum_Cubits_Api.Authorization
{
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public AuthorizationHandler(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

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

            return await _permissionService.CheckPermission(roleId, action, controller);
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
            return await _userService.GetRoleId(userId, userEmail) ?? throw new Exception();
        }


    }
}
