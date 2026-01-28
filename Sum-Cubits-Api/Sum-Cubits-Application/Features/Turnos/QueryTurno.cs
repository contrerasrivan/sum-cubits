
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Turnos
{
    public class QueryTurno
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryTurno(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Turno>> GetList()
        {
            return await _dbContext
                .Set<Turno>()
                .ToListAsync();
        }
    }
}
