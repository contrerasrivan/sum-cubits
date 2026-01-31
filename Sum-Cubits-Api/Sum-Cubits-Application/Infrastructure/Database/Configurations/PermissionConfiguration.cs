
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Permisos;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permisos");
            builder.HasKey(p => p.PermisoId);
            builder.Property(p => p.Accion)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Controlador);
            builder.Property(p => p.Fecha_Alta);
            builder.Property(p => p.Fecha_Modificacion);
            builder.Property(p => p.Fecha_Baja);
        }
    }
}
