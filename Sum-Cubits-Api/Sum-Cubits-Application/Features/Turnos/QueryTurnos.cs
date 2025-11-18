
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Turns
{
    public class QueryTurnos
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryTurnos(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
