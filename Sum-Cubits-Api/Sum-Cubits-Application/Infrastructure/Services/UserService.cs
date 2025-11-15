
using Sum_Cubits_Application.Application.Exceptions;
using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Features.Users;

namespace Sum_Cubits_Application.Infrastructure.Services
{
    public class UserService
    {
        private readonly QueryCacheService queryCacheService;
        private readonly QueryUser queryUser;
        private readonly QueryRole queryRole;

        public async Task<int?> GetRoleId(int userId, string? userEmail)
        {
            var user = GetUserFromCache(userId);

            if (user != null)
            {
                return user.RolId;
            }

            user = await GetUserFromDatabase(userId);

            if (user != null)
            {
                AddUserToCache(user);
                return user.RolId;
            }

            if (string.IsNullOrEmpty(userEmail))
                return null;

            user = await CreateUser(userId, userEmail);
            AddUserToCache(user);

            return user.RolId;
        }

        private User? GetUserFromCache(int userId)
        {
            var cacheKey = GetUserKey(userId);
            return queryCacheService.Get<User?>(cacheKey);
        }

        private async Task<User?> GetUserFromDatabase(int userId)
        {
            return await queryUser.Get(userId);
        }

        private async Task<User> CreateUser(int userId, string? userEmail)
        {
            var role = await GetDefaultRole();

            var entity = new User
            {
                UsuarioId = userId,
                Email = userEmail,
                RolId = role.Id
            };

            await queryUser.Create(entity);

            entity.Role = null;

            return entity;
        }

        private async Task<Role> GetDefaultRole()
        {
            var role = await queryRole.GetDefault();
            return role ?? throw new UnhandledException();
        }

        private void AddUserToCache(User? user)
        {
            var cacheKey = GetUserKey(user?.UsuarioId);
            queryCacheService.Set(cacheKey, user);
        }

        private static string GetUserKey(int? userId) => $"USER_{userId}";

    }
}
