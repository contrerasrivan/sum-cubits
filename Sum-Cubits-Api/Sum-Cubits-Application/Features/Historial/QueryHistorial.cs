
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Record
{
    public class QueryHistorial
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryHistorial(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
