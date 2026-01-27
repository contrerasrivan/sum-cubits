
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.EstadosReserva 
{
    public class QueryEstado
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryEstado(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
