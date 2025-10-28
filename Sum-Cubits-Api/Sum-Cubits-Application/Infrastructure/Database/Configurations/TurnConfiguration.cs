
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Turns;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder.ToTable("Turnos");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("TurnoId");

            builder.Property(t => t.NombreTurno)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.HoraInicio)
                .IsRequired();
            builder.Property(t => t.HoraFin)
                .IsRequired();
            builder.Property(t => t.Descripcion);   
            builder.Property(t => t.Activo)
                .IsRequired();
            builder.Property(t => t.Created)
                .HasColumnName("FechaCreacion");
            builder.Property(t => t.Updated)
                .HasColumnName("FechaModificacion");
            builder.Property(t => t.UsuarioModificadorID)
                .IsRequired();
        }
    }
}
