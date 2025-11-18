
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolesPermisos>
    {
        public void Configure(EntityTypeBuilder<RolesPermisos> builder)
        {
            builder.ToTable("RolesPemisos");
            builder.HasKey(rp => new { rp.RolId, rp.PermisoId });

            builder.Property(rp => rp.RolId);
            builder.HasOne(rp => rp.Role)
                .WithMany()
                .HasForeignKey(rp => rp.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(rp => rp.PermisoId);
            builder.HasOne(rp => rp.Permission)
                .WithMany()
                .HasForeignKey(rp => rp.PermisoId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
