
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Salones
{
    public class QuerySalon
    {
        private readonly SqlServerDbContext _dbContext;

        public QuerySalon(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
