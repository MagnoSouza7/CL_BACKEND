using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class ConsultaPublicaConfiguration : IEntityTypeConfiguration<ConsultaPublica>
    {
        public void Configure(EntityTypeBuilder<ConsultaPublica> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder
                .Property(c => c.NumConsulta)
                .IsRequired();

            builder
                .Property(c => c.Objeto)
                .IsRequired();

            builder
                .HasOne(c => c.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Empresa)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.DataResposta)
                .IsRequired();

            builder
                .HasOne(c => c.Anexo)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
