
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Record
{
    public class QueryRecord
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryRecord(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
