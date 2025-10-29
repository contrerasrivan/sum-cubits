﻿using Sum_Cubits_Application.Features.Permissions;
using Sum_Cubits_Application.Features.Roles;
using Sum_Cubits_Application.Infrastructure.Services;

namespace Sum_Cubits_Application.Infrastructure
{
    public class PermissionService 
    {
        private readonly QueryCacheService _queryCacheService;
        private readonly QueryRole _queryRole;

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
            _queryCacheService.Remove(cacheKey);
        }
        public void RecomePermissionListFromCache(int roleId)
        {
            RemovePermissionListFromCache(roleId);
        }

        private async Task<List<Permission>?> GetPermissionList(int roleId)
        {
            var cacheKey = GetRolePermissionKey(roleId);

            if (_queryCacheService.Exists(cacheKey))
                return _queryCacheService.Get<List<Permission>>(cacheKey);

            var rolePermissionList = await _queryRole.GetRolePermissionList(roleId);

            var permissionList = rolePermissionList
                .Select(rp => rp.Permission!)
                .ToList();

            _queryCacheService.Set(cacheKey, permissionList);

            return permissionList;
        }

        private static string GetRolePermissionKey(int roleId) => $"ROLE_{roleId}_PERMISSION";
    }
}
