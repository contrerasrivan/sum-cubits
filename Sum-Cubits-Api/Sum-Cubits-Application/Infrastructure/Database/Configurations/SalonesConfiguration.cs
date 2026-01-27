using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Salones;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class SalonesConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.ToTable("Salones");
            builder.HasKey(e => e.SalonId);
            builder.Property(e => e.SalonId);
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Capacidad);
            builder.Property(e => e.Descripcion)
                .HasMaxLength(500);
            builder.Property(e => e.Activo);
        }
    }
}
