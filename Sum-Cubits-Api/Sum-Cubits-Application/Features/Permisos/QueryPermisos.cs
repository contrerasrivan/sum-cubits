
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Permissions
{
    public class QueryPermisos
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryPermisos(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Permisos>> GetList()
        {
            return await _dbContext
                .Set<Permisos>()
                .ToListAsync();
        }

        public async Task CreateBulk(IEnumerable<Permisos> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBulk(IEnumerable<Permisos> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
