using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasColumnName("RolId");
            builder.Property(r => r.NombreRol)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(r => r.Created)
                    .HasColumnName("FechaCreacion");
            builder.Property(r => r.Updated)
                    .HasColumnName("FechaBaja");
        }
    }
}
