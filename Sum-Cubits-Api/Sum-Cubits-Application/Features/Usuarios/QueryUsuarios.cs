using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Users
{
    public class QueryUsuarios
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryUsuarios(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuarios>> GetList()
        {
            return await _dbContext.Set<Usuarios>()
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<Usuarios?> Get(int userId)
        {
            return await _dbContext.Set<Usuarios>()
                .Where(u => u.UsuarioId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Usuarios entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Usuarios entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
