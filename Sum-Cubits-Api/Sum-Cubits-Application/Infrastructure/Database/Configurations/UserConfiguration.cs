
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Users;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("UsuarioId");
            builder.Property(u => u.RolId)
                .IsRequired();
            builder.Property(u => u.NombreCompleto)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.Created)
                .HasColumnName("FechaRegistro");
            builder.Property(u => u.Updated)
                .HasColumnName("FechaBaja");
            builder.Property(u => u.Activo)
                .IsRequired();
        }
    }
}
