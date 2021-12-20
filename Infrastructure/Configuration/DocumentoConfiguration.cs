using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<DocumentoCL>
    {
        public void Configure(EntityTypeBuilder<DocumentoCL> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Descricao).IsRequired();

            builder
                .HasOne(u => u.Anexo)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
