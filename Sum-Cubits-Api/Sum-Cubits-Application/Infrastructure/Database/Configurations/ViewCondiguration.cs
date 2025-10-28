﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sum_Cubits_Application.Features.Views;

namespace Sum_Cubits_Application.Infrastructure.Database.Configurations
{
    public class ViewCondiguration : IEntityTypeConfiguration<View>
    {
        public void Configure(EntityTypeBuilder<View> builder)
        {
            builder.ToTable("Vistas");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasColumnName("VistaId");
            builder.Property(v => v.NombreVista)
                .HasMaxLength(100);
            builder.Property(v => v.Icono)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(v => v.Ruta)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(v => v.Created)
                .HasColumnName("Fecha_Alta");
            builder.Property(v => v.Updated)
                .HasColumnName("Fecha_Modificacion");
            builder.Property(v => v.Updated)
                .HasColumnName("Fecha_Baja");

        }
    }
}
