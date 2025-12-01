using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Usuarios
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

        public async Task<Usuarios?> Get(string userEmail)
        {
            return await _dbContext.Set<Usuarios>()
                .Where(u => u.Email == userEmail)
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
