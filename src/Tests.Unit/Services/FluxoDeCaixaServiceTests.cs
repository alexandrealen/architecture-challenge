using Domain.Enums;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Services;

namespace Tests.Unit.Services
{
    public class FluxoDeCaixaServiceTests
    {
        private FluxoDeCaixaRepository _repository;
        private FluxoDeCaixaService _testingObject;
        private CancellationToken _ct;

        public FluxoDeCaixaServiceTests() 
        {
            _repository = Substitute.For<FluxoDeCaixaRepository>(new DbContextOptions<FluxoDeCaixaRepository>());
            _repository.Lancamentos = Substitute.For<DbSet<Lancamento>>();

            _ct = new CancellationToken();

            _testingObject = new FluxoDeCaixaService(_repository);
        }

        [Fact]
        public async Task Deve_salvar_lancamento_corretamente()
        {
            //Arrange
            var valor = 10.50m;
            var natureza = NaturezaLancamento.Debito;

            //Act
            var result = await _testingObject.SalvarLancamentoAsync(valor, natureza, _ct);

            //Assert
            Assert.Equal(valor, result.Valor);
            Assert.Equal(natureza, result.NaturezaLancamento);

            await _repository
                .Lancamentos
                .ReceivedWithAnyArgs(1)
                .AddAsync(default, default);

            await _repository
                .ReceivedWithAnyArgs(1)
                .SaveChangesAsync(default);
        }
    }
}
