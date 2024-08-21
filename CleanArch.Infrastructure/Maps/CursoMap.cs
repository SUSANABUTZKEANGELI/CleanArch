﻿using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Maps
{
    internal class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.DataInicio)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.Property(x => x.IdProfessor)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(t => t.Professor)
                .WithMany(tp => tp.Cursos)
                .HasForeignKey(i => i.IdProfessor);
        }
    }
}
