
using Sum_Cubits_Application.Infrastructure.Database;

namespace Sum_Cubits_Application.Features.Reservation
{
    public class QueryReservas
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryReservas(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
