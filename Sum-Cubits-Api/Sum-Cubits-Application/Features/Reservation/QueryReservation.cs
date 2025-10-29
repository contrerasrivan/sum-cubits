
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Reservation
{
    public class QueryReservation
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryReservation(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
