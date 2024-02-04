using Domain.Enums;
using Domain.Models;

namespace Tests.Unit.Domain
{
    public class RelatorioTests
    {
        [Theory]
        [InlineData(10, 10, 0)]
        [InlineData(100, 10, -90)]
        [InlineData(9.95, 10, 0.05)]
        public void Deve_consolidar_saldo_corretamente(decimal debito, decimal credito, decimal consolidado)
        {
            //Arrange
            var lancamentos = new List<Lancamento>(2)
            {
                new Lancamento(debito, NaturezaLancamento.Debito),
                new Lancamento(credito, NaturezaLancamento.Credito)
            };

            //Act
            var result = new Relatorio(lancamentos);

            //Assert
            Assert.Equal(consolidado, result.SaldoConsolidado);
            Assert.Equivalent(lancamentos, result.Lancamentos);
        }

        [Fact]
        public void Deve_criar_relatorio_sem_lancamentos_corretamente()
        {
            //Act
            var result = new Relatorio(null);

            //Assert
            Assert.Equal(0, result.SaldoConsolidado);
            Assert.Empty(result.Lancamentos);
        }
    }
}
