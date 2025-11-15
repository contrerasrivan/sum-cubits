
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Permissions
{
    public class QueryPermission
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryPermission(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Permission>> GetList()
        {
            return await _dbContext
                .Set<Permission>()
                .ToListAsync();
        }

        public async Task CreateBulk(IEnumerable<Permission> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBulk(IEnumerable<Permission> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
