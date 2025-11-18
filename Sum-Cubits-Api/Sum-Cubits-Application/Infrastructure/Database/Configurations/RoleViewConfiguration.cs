
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Rol;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class RoleViewConfiguration : IEntityTypeConfiguration<RolesVistas>
    {
        public void Configure(EntityTypeBuilder<RolesVistas> builder)
        {
            builder.ToTable("RolesVistas");
            builder.HasKey(rv => new { rv.RolId, rv.VistaId });
            builder.Property(rv => rv.RolId);
            builder.HasOne(rv => rv.Role)
                .WithMany()
                .HasForeignKey(rv => rv.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(rv => rv.VistaId);
            builder.HasOne(rv => rv.View)
                .WithMany()
                .HasForeignKey(rv => rv.VistaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
