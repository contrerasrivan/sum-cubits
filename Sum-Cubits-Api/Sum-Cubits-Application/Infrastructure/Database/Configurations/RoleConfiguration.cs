using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Roles;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(r => r.RolId);
            builder.Property(r => r.NombreRol)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(r => r.FechaCreacion)
                .IsRequired();
            builder.Property(r => r.Fecha_Baja);
        }
    }
}
