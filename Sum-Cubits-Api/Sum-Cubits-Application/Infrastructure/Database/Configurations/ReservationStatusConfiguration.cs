
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Status;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class ReservationStatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("EstadosReserva");

            builder.HasKey(er => er.Id);

            builder.Property(er => er.Id)
                .HasColumnName("EstadoId");

            builder.Property(er => er.NombreEstado)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(er => er.Descripcion);
        }
    }
}
