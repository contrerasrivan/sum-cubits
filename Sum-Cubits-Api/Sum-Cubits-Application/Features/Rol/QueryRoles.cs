
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;
using System.Linq.Expressions;

namespace Sum_Cubits_Application.Features.Rol
{
    public class QueryRoles
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryRoles(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Roles?> Get(int? id)
        {
            return await _dbContext
                .Set<Roles>()
                .Where(r => r.RolId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Roles?> GetDefault()
        {
            return await _dbContext
                .Set<Roles>()
                .FirstOrDefaultAsync();
        }

        public async Task<RolesVistas?> GetRoleView(int? roleId, int viewId)
        {
            return await _dbContext
                .Set<RolesVistas>()
                .Where(rv => rv.RolId == roleId && rv.VistaId == viewId)
                .FirstOrDefaultAsync();
        }

        public async Task<RolesPermisos?> GetRolePermission(int roleId, int permissionId)
        {
            return await _dbContext
                .Set<RolesPermisos>()
                .Where(rp => rp.RolId == roleId && rp.PermisoId == permissionId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<RolesVistas>> GetRoleViewList()
        {
            return await _dbContext
                .Set<RolesVistas>()
                .ToListAsync();
        }

        public async Task<List<RolesPermisos>> GetRolePermissionList()
        {
            return await _dbContext
                .Set<RolesPermisos>()
                .ToListAsync();
        }

        public async Task<List<RolesVistas>> GetRoleViewList(int? roleId)
        {
            return await _dbContext
                .Set<RolesVistas>()
                .Include(rp => rp.Role)
                .Include(rp => rp.View)
                .Where(rp => rp.RolId == roleId)
                .ToListAsync();
        }

        public async Task<List<RolesPermisos>> GetRolePermissionList(int roleId)
        {
            return await _dbContext
                .Set<RolesPermisos>()
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .Where(rp => rp.RolId == roleId)
                .ToListAsync();
        }

        public async Task<List<Roles>> GetList(Expression<Func<Roles, bool>> predicate)
        {
            return await _dbContext
                .Set<Roles>()
                .Where(predicate)
                .OrderBy(r => r.RolId)
                .ToListAsync();
        }

        public async Task<bool> ExistsByRoleId(int roleId)
        {
            return await _dbContext
                .Set<Roles>()
                .Where(r => r.RolId == roleId)
                .AnyAsync();
        }

        public async Task<bool> ExistsByName(string? name)
        {
            return await _dbContext
                .Set<Roles>()
                .Where(o => o.NombreRol == name)
                .AnyAsync();
        }

        public async Task Create(Roles entity)
        {
            entity.FechaCreacion = DateTime.Now;

            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleView(RolesVistas entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRolePermission(RolesPermisos entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleViewBulk(IEnumerable<RolesVistas> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRolePermissionBulk(IEnumerable<RolesPermisos> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Roles entity)
        {
            entity.Fecha_Baja = DateTime.Now;

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleView(RolesVistas entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRolePermission(RolesPermisos entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleViewBulk(IEnumerable<RolesVistas> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRolePermissionBulk(IEnumerable<RolesPermisos> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
