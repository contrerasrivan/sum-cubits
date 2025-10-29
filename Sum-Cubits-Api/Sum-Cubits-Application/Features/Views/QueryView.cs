
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Views
{
    public class QueryView
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryView(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
