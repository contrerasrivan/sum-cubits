
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Permissions;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("PermisoId");
            builder.Property(p => p.Accion)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Controlador);
            builder.Property(p => p.Created)
                .HasColumnName("Fecha_Alta");
            builder.Property(p => p.Updated)
                .HasColumnName("Fecha_Modificacion");
            builder.Property(p => p.Updated)
                .HasColumnName("Fecha_Baja");
        }
    }
}
