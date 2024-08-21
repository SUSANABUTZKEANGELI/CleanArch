using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Maps
{
    internal class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();
        }
    }
}
