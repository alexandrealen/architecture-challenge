using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repositories.Configuration
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable(nameof(FluxoDeCaixaRepository.Lancamentos));

            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.DataLancamento)
                .IsRequired();

            builder.Property(b => b.Valor)
                .IsRequired()
                .HasColumnType("decimal(20,2)");

            builder.Property(b => b.NaturezaLancamento)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (NaturezaLancamento)Enum.Parse(typeof(NaturezaLancamento), v))
                .HasColumnType("nvarchar(20)");
        }
    }
}
