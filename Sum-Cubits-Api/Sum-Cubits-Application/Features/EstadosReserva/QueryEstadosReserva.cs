
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Status
{
    public class QueryEstadosReserva
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryEstadosReserva(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
