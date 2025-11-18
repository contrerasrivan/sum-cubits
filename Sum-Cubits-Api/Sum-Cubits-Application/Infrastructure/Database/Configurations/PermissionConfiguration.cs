
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Permissions;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permisos>
    {
        public void Configure(EntityTypeBuilder<Permisos> builder)
        {
            builder.ToTable("Permisos");
            builder.HasKey(p => p.PermisoId);
            builder.Property(p => p.Accion)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Controlador);
            builder.Property(p => p.Created)
                .HasColumnName("Fecha_Alta");
            builder.Property(p => p.Update)
                .HasColumnName("Fecha_Modificacion");
            builder.Property(p => p.Update)
                .HasColumnName("Fecha_Baja");
        }
    }
}
