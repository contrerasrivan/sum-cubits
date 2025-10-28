using Sum_Cubits_Application.Application.Interfaces;
using Sum_Cubits_Application.Features.Permissions;
using Sum_Cubits_Application.Interfaces;

namespace Sum_Cubits_Application.Infrastructure
{
    public class PermissionService : IPermissionService
    {
        private readonly ICacheService _cacheService;
        private readonly IRoleRepository _roleRepository;

        public PermissionService(
            ICacheService cacheService,
            IRoleRepository roleRepository)
        {
            _cacheService = cacheService;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CheckPermission(int roleId, string action, string controller)
        {
            var permissionList = await GetPermissionList(roleId);

            var existsPermission = permissionList?
                .Any(permission => permission.Accion == action &&
                                   permission.Controlador == controller) ?? false;

            return existsPermission;
        }

        public void RemovePermissionListFromCache(int roleId)
        {
            var cacheKey = GetRolePermissionKey(roleId);
            _cacheService.Remove(cacheKey);
        }
        public void RecomePermissionListFromCache(int roleId)
        {
            RemovePermissionListFromCache(roleId);
        }

        private async Task<List<Permission>?> GetPermissionList(int roleId)
        {
            var cacheKey = GetRolePermissionKey(roleId);

            if (_cacheService.Exists(cacheKey))
                return _cacheService.Get<List<Permission>>(cacheKey);

            var rolePermissionList = await _roleRepository.GetRolePermissionList(roleId);

            var permissionList = rolePermissionList
                .Select(rp => rp.Permission!)
                .ToList();

            _cacheService.Set(cacheKey, permissionList);

            return permissionList;
        }

        private static string GetRolePermissionKey(int roleId) => $"ROLE_{roleId}_PERMISSION";
    }
