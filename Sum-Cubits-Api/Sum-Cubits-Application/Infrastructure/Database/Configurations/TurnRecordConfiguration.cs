
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Record;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class TurnRecordConfiguration : IEntityTypeConfiguration<TurnRecord>
    {
        public void Configure(EntityTypeBuilder<TurnRecord> builder)
        {
            builder.ToTable("HistorialTurnos");
            builder.HasKey(tr => tr.Id);
            builder.Property(tr => tr.Id)
                .HasColumnName("HistorialTurnoId");
            builder.Property(tr => tr.HoraInicioAnterior)
                .IsRequired();
            builder.Property(tr => tr.HoraFinAnterior)
                .IsRequired();
            builder.Property(tr => tr.HoraInicioNuevo)
                .IsRequired();
            builder.Property(tr => tr.HoraFinNuevo)
                .IsRequired();
            builder.Property(tr => tr.UsuarioModificadorID)
                .IsRequired();
            builder.Property(tr => tr.FechaCambio)
                .IsRequired();
            builder.Property(tr => tr.Motivo)  
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
