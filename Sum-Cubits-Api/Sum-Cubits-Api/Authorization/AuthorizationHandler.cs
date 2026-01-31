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
        private readonly QueryUsuario queryUser;

        public AuthorizationHandler(UserService _userService, PermissionService _permissionService, QueryUsuario _queryUsuario, ILogger<AuthorizationHandler> logger)
        {
            userService = _userService;
            permissionService = _permissionService;
            queryUser = _queryUsuario;
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

            return await permissionService.CheckPermission(roleId, action, controller);
        }

        private static bool IsAuthenticated(AuthorizationHandlerContext context)
        {
            return context.User.Identity!.IsAuthenticated;
        }

        private static string GetRequestAction(AuthorizationHandlerContext context)
        {
            if (context.Resource is HttpContext httpContext)
            {
                var endpoint = httpContext.GetEndpoint();
                var actionName = endpoint?.Metadata.GetMetadata<EndpointNameMetadata>()?.EndpointName;
                if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() is ControllerActionDescriptor descriptor)
                {
                    return descriptor.ActionName;
                }

                return actionName ?? httpContext.Request.RouteValues["action"]?.ToString() ?? httpContext.Request.Path.ToString();
            }

            if (context.Resource is ActionContext actionContext)
            {
                return ((ControllerActionDescriptor)actionContext.ActionDescriptor).ActionName;
            }
            throw new InvalidOperationException("No se pudo determinar la acción desde el contexto de autorización");
        }

        private static string GetRequestController(AuthorizationHandlerContext context)
        {
            // Para Minimal APIs, extraer desde HttpContext
            if (context.Resource is HttpContext httpContext)
            {
                var endpoint = httpContext.GetEndpoint();

                // Si hay un ControllerActionDescriptor (MVC), úsalo
                if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() is ControllerActionDescriptor descriptor)
                {
                    return descriptor.ControllerName;
                }

                // Para Minimal APIs, extraer del primer segmento de ruta después del dominio
                var path = httpContext.Request.Path.ToString().Trim('/');
                var segments = path.Split('/');

                // Tomar el primer segmento como controlador (ej: /roles/1 -> "roles")
                if (segments.Length > 0 && !string.IsNullOrEmpty(segments[0]))
                {
                    return char.ToUpper(segments[0][0]) + segments[0].Substring(1).ToLower(); // "Roles"
                }

                // Fallback
                return httpContext.Request.RouteValues["controller"]?.ToString() ?? "Api";
            }

            // Fallback para MVC tradicional (ActionContext)
            if (context.Resource is ActionContext actionContext)
            {
                return ((ControllerActionDescriptor)actionContext.ActionDescriptor).ControllerName;
            }

            throw new InvalidOperationException("No se pudo determinar el controlador desde el contexto de autorización.");
        }

        private async Task<int> GetUserRoleId(AuthorizationHandlerContext context)
        {
            var userEmail = context.User.FindFirstValue(ClaimTypes.Email);

            // Obtener el usuario por email usando UserService
            var userList = await queryUser.Get(userEmail);

            if (userList == null)
                throw new Exception("Usuario no encontrado por email.");

            var userId = userList.UsuarioId;
            return await userService.GetRoleId(userEmail) ?? throw new Exception("Rol no encontrado para el usuario.");
        }


    }
}
