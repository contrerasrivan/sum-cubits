
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Vistas
{
    public class QueryVista
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryVista(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Vista>> GetList()
        {
            return _dbContext
                .Set<Vista>()
                .ToListAsync();
        }

        public async Task CreateBulk(IEnumerable<Vista> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBulk(IEnumerable<Vista> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
