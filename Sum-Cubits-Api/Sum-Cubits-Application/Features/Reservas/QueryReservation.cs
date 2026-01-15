
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

        public async Task Create(Reservation entity)
        {
            entity.EstadoId = 5; // Set status to 'Confirmed'
            entity.FechaSolicitud = DateTime.Now;
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Reservation entity)
        {
            entity.EstadoId = 3; // Set status to 'Cancelled'
            entity.FechaSolicitud = DateTime.Now;
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }
    }
}
