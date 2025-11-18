
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Views
{
    public class QueryVistas
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryVistas(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Vistas>> GetList()
        {
            return _dbContext
                .Set<Vistas>()
                .ToListAsync();
        }

        public async Task CreateBulk(IEnumerable<Vistas> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBulk(IEnumerable<Vistas> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
