
using Sum_Cubits_Application.Application.Exceptions;
using Sum_Cubits_Application.Features.Rol;
using Sum_Cubits_Application.Features.Usuarios;

namespace Sum_Cubits_Application.Infrastructure.Services
{
    public class UserService
    {
        private readonly QueryCacheService _queryCacheService;
        private readonly QueryUsuarios _queryUser;
        private readonly QueryRoles _queryRole;

        public UserService(QueryCacheService queryCacheService,QueryUsuarios queryUsuarios, QueryRoles queryRoles)
        {
            _queryCacheService = queryCacheService;
            _queryUser = queryUsuarios;
            _queryRole = queryRoles;
        }
        public async Task<int?> GetRoleId(string? userEmail)
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

        private Usuarios? GetUserFromCache(string userEmail)
        {
            var cacheKey = GetUserKey(userEmail);
            return _queryCacheService.Get<Usuarios?>(cacheKey);
        }

        private async Task<Usuarios?> GetUserFromDatabase(string userEmail)
        {
            return await _queryUser.Get(userEmail);
        }

        private async Task<Usuarios> CreateUser(string? userEmail)
        {
            var role = await GetDefaultRole();

            var entity = new Usuarios
            {
                Email = userEmail,
                RolId = role.RolId
            };

            await _queryUser.Create(entity);

            entity.Role = null;

            return entity;
        }

        private async Task<Roles> GetDefaultRole()
        {
            var role = await _queryRole.GetDefault();
            return role ?? throw new UnhandledException();
        }

        private void AddUserToCache(Usuarios? user)
        {
            var cacheKey = GetUserKey(user?.Email);
            _queryCacheService.Set(cacheKey, user);
        }

        private static string GetUserKey(string userEmail) => $"USER_{userEmail}";

    }
}
