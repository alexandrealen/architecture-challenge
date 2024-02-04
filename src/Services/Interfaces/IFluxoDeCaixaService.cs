using Domain.Enums;
using Domain.Models;

namespace Services.Interfaces
{
    public interface IFluxoDeCaixaService
    {
        Task<Relatorio> ObterRelatorioAsync(DateTimeOffset dataInicio, DateTimeOffset dataFim, CancellationToken ct);

        Task<Lancamento> SalvarLancamentoAsync(decimal valor, NaturezaLancamento natureza, CancellationToken ct);
    }
}
