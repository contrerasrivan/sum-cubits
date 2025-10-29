
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Status
{
    public class QueryReservationStatus
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryReservationStatus(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
