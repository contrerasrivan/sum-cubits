
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Turns
{
    public class QueryTurn
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryTurn(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
