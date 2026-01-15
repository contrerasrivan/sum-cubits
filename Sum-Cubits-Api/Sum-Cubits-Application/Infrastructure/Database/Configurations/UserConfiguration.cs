
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Usuarios;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.UsuarioId);
            builder.Property(u => u.RolId)
                .IsRequired();
            builder.Property(u => u.FullName)
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.Telefono);
            builder.Property(u => u.FechaRegistro)
                .IsRequired();
            builder.Property(u => u.Fecha_Baja);
            builder.Property(u => u.Activo).IsRequired();
            builder.Property(u => u.UsuarioBajaId);

            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
