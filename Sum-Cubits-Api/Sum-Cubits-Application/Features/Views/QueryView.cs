
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Views
{
    public class QueryView
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryView(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<View>> GetList()
        {
            return _dbContext
                .Set<View>()
                .ToListAsync();
        }

        public async Task CreateBulk(IEnumerable<View> entityList)
        {
            _dbContext.AddRange(entityList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBulk(IEnumerable<View> entityList)
        {
            _dbContext.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
