
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Room
{
    public class QuerySalones
    {
        private readonly SqlServerDbContext _dbContext;

        public QuerySalones(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
