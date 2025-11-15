using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Status;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("EstadosReserva");
            builder.HasKey(er => er.Id);
            builder.Property(t => t.Id)
                .HasColumnName("EstadoId");
            builder.Property(er => er.NombreEstado)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(er => er.Descripcion);
        }
    }
}
