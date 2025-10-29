using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Users
{
    public class QueryUser
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryUser(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetList()
        {
            return await _dbContext.Set<User>()
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User?> Get(string? userId)
        {
            return await _dbContext.Set<User>()
                .Where(u => u.UsuarioId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task Create(User entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
