
using Sum_Cubits_Application.Application.Exceptions;
using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Features.Usuarios;

namespace Sum_Cubits_Application.Infrastructure.Services
{
    public class UserService
    {
        private readonly QueryCacheService _queryCacheService;
        private readonly QueryUsuario _queryUser;
        private readonly QueryRol _queryRole;

        public UserService(QueryCacheService queryCacheService,QueryUsuario queryUsuarios, QueryRol queryRoles)
        {
            _queryCacheService = queryCacheService;
            _queryUser = queryUsuarios;
            _queryRole = queryRoles;
        }
        public async Task<int?> GetRoleId(string userEmail)
        {
            var user = GetUserFromCache(userEmail);

            if (user != null)
            {
                return user.RolId;
            }

            user = await GetUserFromDatabase(userEmail);

            if (user != null)
            {
                AddUserToCache(user);
                return user.RolId;
            }

            if (string.IsNullOrEmpty(userEmail))
                return null;

            user = await CreateUser(userEmail);
            AddUserToCache(user);

            return user.RolId;
        }

        public async Task<int> GetUserId(string userEmail)
        {
            var user = GetUserFromCache(userEmail);

            if (user != null)
                return user.UsuarioId;

            user = await GetUserFromDatabase(userEmail);

            if (user != null)
            {
                AddUserToCache(user);
                return user.UsuarioId;
            }

            return user.UsuarioId;
        }

        private Usuario? GetUserFromCache(string userEmail)
        {
            var cacheKey = GetUserKey(userEmail);
            return _queryCacheService.Get<Usuario?>(cacheKey);
        }

        private async Task<Usuario?> GetUserFromDatabase(string userEmail)
        {
            return await _queryUser.Get(userEmail);
        }

        private async Task<Usuario> CreateUser(string userEmail)
        {
            var role = await GetDefaultRole();

            var entity = new Usuario
            {
                Email = userEmail,
                RolId = role.RolId
            };

            await _queryUser.Create(entity);

            entity.Role = null;

            return entity;
        }

        private async Task<Rol> GetDefaultRole()
        {
            var role = await _queryRole.GetDefault();
            return role ?? throw new UnhandledException();
        }

        private void AddUserToCache(Usuario? user)
        {
            var cacheKey = GetUserKey(user?.Email);
            _queryCacheService.Set(cacheKey, user);
        }

        private static string GetUserKey(string userEmail) => $"USER_{userEmail}";

    }
}
