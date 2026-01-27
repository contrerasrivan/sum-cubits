
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Reservas;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
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
                .HasColumnType("date")
                .IsRequired();
            builder.Property(r => r.FechaSolicitud)
                .IsRequired(false);
            builder.Property(r => r.CantidadPersonas);
            builder.Property(r => r.Observaciones)
                .HasMaxLength(500);

            builder.HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Salon)
                .WithMany()
                .HasForeignKey(r => r.SalonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Turno)
                .WithMany()
                .HasForeignKey(r => r.TurnoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Estado)
                .WithMany()
                .HasForeignKey(r => r.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
