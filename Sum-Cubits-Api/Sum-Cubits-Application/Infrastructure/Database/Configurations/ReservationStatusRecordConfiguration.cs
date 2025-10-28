
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Record;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class ReservationStatusRecordConfiguration : IEntityTypeConfiguration<ReservationStatusRecord>
    {
        public void Configure(EntityTypeBuilder<ReservationStatusRecord> builder)
        {
            builder.ToTable("HistorialEstadoReserva");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasColumnName("HistorialId");
            builder.Property(r => r.ReservaId)
                .IsRequired()
                .HasColumnName("ReservaId");
            builder.Property(r => r.EstadoAnterior)
                .IsRequired();
            builder.Property(r => r.EstadoNuevo)
                .IsRequired();
            builder.Property(r => r.FechaCambio)
                .IsRequired();
            builder.Property(r => r.UsuarioModificador)
                .IsRequired();
            builder.Property(r => r.Comentario);
        }
    }
}
