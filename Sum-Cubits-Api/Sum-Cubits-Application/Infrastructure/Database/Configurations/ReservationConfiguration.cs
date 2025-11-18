
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Reservation;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservas>
    {
        public void Configure(EntityTypeBuilder<Reservas> builder)
        {
            builder.ToTable("Reservas");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasColumnName("ReservaId");
            builder.Property(r => r.UsuarioId)
                .IsRequired();
            builder.Property(r => r.SalonId)
                .IsRequired();
            builder.Property(r => r.TurnoId)
                .IsRequired();
            builder.Property(r => r.EstadoId)
                .IsRequired();
            builder.Property(r => r.FechaReserva)
                .IsRequired();
            builder.Property(r => r.FechaSolicitud)
                .IsRequired();
            builder.Property(r => r.CantidadPersonas);
            builder.Property(r => r.Observaciones)
                .HasMaxLength(500);
        }
    }
}
