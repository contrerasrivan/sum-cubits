
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Room
{
    public class QueryLounge
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryLounge(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
