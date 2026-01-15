
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
            builder.HasKey(r => r.ReservaId);
            builder.Property(r => r.ReservaId);
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

            builder.Property(r => r.UsuarioId);
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.SalonId);
            builder.HasOne(r => r.Lounge)
                .WithMany()
                .HasForeignKey(r => r.SalonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.TurnoId);
            builder.HasOne(r => r.Turn)
                .WithMany()
                .HasForeignKey(r => r.TurnoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.EstadoId);
            builder.HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
