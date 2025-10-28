using System.Linq.Expressions;

namespace Sum_Cubits_Application.Interfaces;

public interface IRoleRepository
{
    Task<Role?> Get(int id);
    Task<Role?> GetDefault();
    Task<RoleView?> GetRoleView(int roleId, int viewId);
    Task<RolePermission?> GetRolePermission(int roleId, int permissionId);
    Task<List<RoleView>> GetRoleViewList();
    Task<List<RolePermission>> GetRolePermissionList();
    Task<List<RoleView>> GetRoleViewList(int roleId);
    Task<List<RolePermission>> GetRolePermissionList(int roleId);
    Task<PaginatedResult<Role>> GetList(Expression<Func<Role, bool>> predicate, int skip = 0, int take = 25);
    Task<bool> ExistsByName(string? name);
    Task<bool> ExistsByRoleId(int roleId);
    Task Create(Role entity);
    Task CreateRoleView(RoleView entity);
    Task CreateRoleViewBulk(IEnumerable<RoleView> entityList);
    Task CreateRolePermissionBulk(IEnumerable<RolePermission> entityList);
    Task CreateRolePermission(RolePermission entity);
    Task Update(Role entity);
    Task Delete(Role entity);
    Task DeleteRoleView(RoleView entity);
    Task DeleteRolePermission(RolePermission entity);
    Task DeleteRoleViewBulk(IEnumerable<RoleView> entityList);
    Task DeleteRolePermissionBulk(IEnumerable<RolePermission> entityList);
}