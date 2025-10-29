
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;
using System.Linq.Expressions;

namespace Sum_Cubits_Application.Features.Roles
{
    public class QueryRole
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryRole(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role?> Get(int id)
        {
            return await _dbContext
                .Set<Role>()
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Role?> GetDefault()
        {
            return await _dbContext
                .Set<Role>()
                .FirstOrDefaultAsync();
        }

        public async Task<RoleView?> GetRoleView(int roleId, int viewId)
        {
            return await _dbContext
                .Set<RoleView>()
                .Where(rv => rv.RolId == roleId && rv.VistaId == viewId)
                .FirstOrDefaultAsync();
        }

        public async Task<RolePermission?> GetRolePermission(int roleId, int permissionId)
        {
            return await _dbContext
                .Set<RolePermission>()
                .Where(rp => rp.RolId == roleId && rp.PermisoId == permissionId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<RoleView>> GetRoleViewList()
        {
            return await _dbContext
                .Set<RoleView>()
                .ToListAsync();
        }

        public async Task<List<RolePermission>> GetRolePermissionList()
        {
            return await _dbContext
                .Set<RolePermission>()
                .ToListAsync();
        }

        public async Task<List<RoleView>> GetRoleViewList(int roleId)
        {
            return await _dbContext
                .Set<RoleView>()
                .Include(rp => rp.Role)
                .Include(rp => rp.View)
                .Where(rp => rp.RolId == roleId)
                .ToListAsync();
        }

        public async Task<List<RolePermission>> GetRolePermissionList(int roleId)
        {
            return await _dbContext
                .Set<RolePermission>()
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .Where(rp => rp.RolId == roleId)
                .ToListAsync();
        }

        public async Task<List<Role>> GetList(Expression<Func<Role, bool>> predicate, int skip, int take)
        {
            return await _dbContext
                .Set<Role>()
                .Where(predicate)
                .OrderBy(r => r.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<bool> ExistsByRoleId(int roleId)
        {
            return await _dbContext
                .Set<Role>()
                .Where(r => r.Id == roleId)
                .AnyAsync();
        }

        public async Task<bool> ExistsByName(string? name)
        {
            return await _dbContext
                .Set<Role>()
                .Where(o => o.NombreRol == name)
                .AnyAsync();
        }

        public async Task Create(Role entity)
        {
            entity.Created = DateTime.UtcNow;

            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleView(RoleView entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRolePermission(RolePermission entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleViewBulk(IEnumerable<RoleView> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRolePermissionBulk(IEnumerable<RolePermission> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Role entity)
        {
            entity.Updated = DateTime.UtcNow;

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Role entity)
        {
            entity.Deleted = DateTime.UtcNow;

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleView(RoleView entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRolePermission(RolePermission entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleViewBulk(IEnumerable<RoleView> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRolePermissionBulk(IEnumerable<RolePermission> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
