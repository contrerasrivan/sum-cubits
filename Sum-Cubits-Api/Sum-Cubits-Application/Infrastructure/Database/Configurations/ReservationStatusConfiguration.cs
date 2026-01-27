using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sum_Cubits_Application.Features.EstadosReserva;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class ReservationStatusConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("EstadosReserva");

            builder.HasKey(er => er.EstadoId);
            builder.Property(er => er.EstadoId);

            builder.Property(er => er.NombreEstado)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(er => er.Descripcion);
        }
    }
}
