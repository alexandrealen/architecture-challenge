using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Domain.Enums;

namespace Services
{
    public class FluxoDeCaixaService : IFluxoDeCaixaService
    {
        public FluxoDeCaixaRepository _repository;
        public FluxoDeCaixaService(FluxoDeCaixaRepository repository) 
        {
            _repository = repository;
        }

        public async Task<Lancamento> SalvarLancamentoAsync(decimal valor, NaturezaLancamento natureza, CancellationToken ct)
        {
            var lancamento = new Lancamento(valor, natureza);

            await _repository
                .Lancamentos
                .AddAsync(lancamento, ct);

            await _repository
                .SaveChangesAsync(ct);

            return lancamento;
        }

        public async Task<Relatorio> ObterRelatorioAsync(DateTimeOffset dataInicio, DateTimeOffset dataFim, CancellationToken ct)
        {
            var lancamentos = await _repository
                .Lancamentos
                .Where(x => x.DataLancamento.Date >= dataInicio.Date && x.DataLancamento.Date <= dataFim.Date)
                .ToListAsync(ct);

            return new Relatorio(lancamentos);
        }

    }
}
