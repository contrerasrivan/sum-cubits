using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Usuarios
{
    public class QueryUsuario
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryUsuario(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetList()
        {
            return await _dbContext.Set<Usuario>()
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<Usuario?> Get(string userEmail)
        {
            return await _dbContext.Set<Usuario>()
                .Where(u => u.Email == userEmail)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Usuario entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Usuario entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
