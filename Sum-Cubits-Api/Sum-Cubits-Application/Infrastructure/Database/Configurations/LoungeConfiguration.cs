using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Room;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class LoungeConfiguration : IEntityTypeConfiguration<Lounge>
    {
        public void Configure(EntityTypeBuilder<Lounge> builder)
        {
            builder.ToTable("Salones");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NombreSalon)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Capacidad)
                .IsRequired();
            builder.Property(e => e.Descripcion)
                .HasMaxLength(500);
            builder.Property(e => e.PrecioPorturno)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
            builder.Property(e => e.Activo)
                .IsRequired();
        }
    }
}
