
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Status
{
    public class QueryStatus
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryStatus(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
