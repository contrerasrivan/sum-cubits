
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

        
        public async Task<Reserva?> Get(int reservationId)
        {
            return await _dbContext
                .Set<Reserva>()
                .Include(r => r.Usuario)
                .Include(r => r.Salon)
                .Include(r => r.Turno)
                .Include(r => r.Estado)
                .Where(r => r.ReservaId == reservationId)
                .FirstOrDefaultAsync();
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

        public async Task<List<int>>CheckTurnOcuped(DateOnly fechaReserva, int salonId, int[] turnosIds)
        {
            return await _dbContext
                .Set<Reserva>()
                .Where(r => r.FechaReserva == fechaReserva
                && r.SalonId == salonId
                && r.EstadoId == 5
                && turnosIds.Contains(r.TurnoId ?? 0))
                .Select(r => r.TurnoId ?? 0)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<int>> GetTurnsDisponibili(DateOnly fechaReserva, int salonId, int[] allTurns)
        {
            var turnsOcuped = await _dbContext
                .Set<Reserva>()
                .Where(r => r.FechaReserva == fechaReserva
                && r.SalonId == salonId
                && r.EstadoId == 5)
                .Select(r => r.TurnoId ?? 0)
                .Distinct()
                .ToListAsync();

            return allTurns.Except(turnsOcuped).ToList();
        }

        public async Task Create(Reserva entity)
        {
            entity.EstadoId = 5; // Set status to 'Confirmed'
            entity.FechaSolicitud = DateTime.Now;
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Cancel(Reserva entity)
        {
            var reservationListDay = await _dbContext
                .Set<Reserva>()
                .Where(r => r.UsuarioId == entity.UsuarioId
                && r.FechaReserva == entity.FechaReserva
                && r.EstadoId == 5)
                .ToListAsync();

            if (reservationListDay.Count == 0)
                return;

            foreach(var reservation in reservationListDay)
            {
                reservation.EstadoId = 3;
                reservation.FechaSolicitud = DateTime.Now;
            }
            
            await _dbContext.SaveChangesAsync();

        }
    }
}
