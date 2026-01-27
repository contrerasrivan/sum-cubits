
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;
using System.Linq.Expressions;

namespace Sum_Cubits_Application.Features.Roles
{
    public class QueryRol
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryRol(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rol?> Get(int? id)
        {
            return await _dbContext
                .Set<Rol>()
                .Where(r => r.RolId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Rol?> GetDefault()
        {
            return await _dbContext
                .Set<Rol>()
                .FirstOrDefaultAsync();
        }

        public async Task<RolVista?> GetRoleView(int? roleId, int viewId)
        {
            return await _dbContext
                .Set<RolVista>()
                .Where(rv => rv.RolId == roleId && rv.VistaId == viewId)
                .FirstOrDefaultAsync();
        }

        public async Task<RolPermiso?> GetRolePermission(int roleId, int permissionId)
        {
            return await _dbContext
                .Set<RolPermiso>()
                .Where(rp => rp.RolId == roleId && rp.PermisoId == permissionId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<RolVista>> GetRoleViewList()
        {
            return await _dbContext
                .Set<RolVista>()
                .ToListAsync();
        }

        public async Task<List<RolPermiso>> GetRolePermissionList()
        {
            return await _dbContext
                .Set<RolPermiso>()
                .ToListAsync();
        }

        public async Task<List<RolVista>> GetRoleViewList(int? roleId)
        {
            return await _dbContext
                .Set<RolVista>()
                .Include(rp => rp.Role)
                .Include(rp => rp.View)
                .Where(rp => rp.RolId == roleId)
                .ToListAsync();
        }

        public async Task<List<RolPermiso>> GetRolePermissionList(int roleId)
        {
            return await _dbContext
                .Set<RolPermiso>()
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .Where(rp => rp.RolId == roleId)
                .ToListAsync();
        }

        public async Task<List<Rol>> GetList(Expression<Func<Rol, bool>> predicate)
        {
            return await _dbContext
                .Set<Rol>()
                .Where(predicate)
                .OrderBy(r => r.RolId)
                .ToListAsync();
        }

        public async Task<bool> ExistsByRoleId(int roleId)
        {
            return await _dbContext
                .Set<Rol>()
                .Where(r => r.RolId == roleId)
                .AnyAsync();
        }

        public async Task<bool> ExistsByName(string? name)
        {
            return await _dbContext
                .Set<Rol>()
                .Where(o => o.NombreRol == name)
                .AnyAsync();
        }

        public async Task Create(Rol entity)
        {
            entity.FechaCreacion = DateTime.Now;

            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleView(RolVista entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRolePermission(RolPermiso entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRoleViewBulk(IEnumerable<RolVista> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRolePermissionBulk(IEnumerable<RolPermiso> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Rol entity)
        {
            entity.Fecha_Baja = DateTime.Now;

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleView(RolVista entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRolePermission(RolPermiso entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleViewBulk(IEnumerable<RolVista> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRolePermissionBulk(IEnumerable<RolPermiso> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
