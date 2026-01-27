
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Infrastructure.Database;
using System.Linq.Expressions;

namespace Sum_Cubits_Application.Features.Reservas
{
    public class QueryReserva
    {
        private readonly SqlServerDbContext _dbContext;

        public QueryReserva(
            SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Reserva>> GetList(Expression<Func<Reserva,bool>> predicate)
        {
            return await _dbContext
                .Set<Reserva>()
                .Include(r => r.Usuario)
                .Include(r => r.Salon)
                .Include(r => r.Turno)
                .Include(r => r.Estado)
                .Where(predicate)
                .OrderBy(r => r.FechaReserva)
                .ToListAsync();
        }

        public async Task Create(Reserva entity)
        {
            entity.EstadoId = 5; // Set status to 'Confirmed'
            entity.FechaSolicitud = DateTime.Now;
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Reserva entity)
        {
            entity.EstadoId = 3; // Set status to 'Cancelled'
            entity.FechaSolicitud = DateTime.Now;
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }
    }
}
