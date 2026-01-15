using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Room;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class SalonesConfiguration : IEntityTypeConfiguration<Salones>
    {
        public void Configure(EntityTypeBuilder<Salones> builder)
        {
            builder.ToTable("Salones");
            builder.HasKey(e => e.SalonId);
            builder.Property(e => e.SalonId);
            builder.Property(e => e.NombreSalon)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Capacidad)
                .IsRequired();
            builder.Property(e => e.Descripcion)
                .HasMaxLength(500);
            builder.Property(e => e.Activo)
                .IsRequired();
        }
    }
}
