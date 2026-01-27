
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Turnos;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.ToTable("Turnos");

            builder.HasKey(t => t.TurnoId);
            builder.Property(t => t.TurnoId);

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
            builder.Property(t => t.FechaCreacion);
            builder.Property(t => t.FechaModificacion);
            builder.Property(t => t.UsuarioModificadorID);
        }
    }
}
