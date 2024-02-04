using Domain.Enums;
using Domain.Models;

namespace Tests.Unit.Domain
{
    public class LancamentoTests
    {
        private readonly Random _rng; 
        public LancamentoTests() 
        {
            _rng = new Random();
        }

        [Fact]
        public void Deve_criar_debitos_corretamente() 
        { 
            //Arrange
            var valor = new decimal(_rng.Next() + _rng.NextDouble());
            var natureza = NaturezaLancamento.Debito;

            //Act
            var result = new Lancamento(valor, natureza);

            //Assert
            Assert.Equal(valor, result.Valor);
            Assert.Equal(natureza, result.NaturezaLancamento);
            Assert.True(Guid.TryParse(result.Id.ToString(), out var guidResult));
            Assert.NotEqual(DateTimeOffset.MinValue, result.DataLancamento);
        }

        [Fact]
        public void Deve_criar_creditos_corretamente()
        {
            //Arrange
            var valor = new decimal(_rng.Next() + _rng.NextDouble());
            var natureza = NaturezaLancamento.Credito;

            //Act
            var result = new Lancamento(valor, natureza);

            //Assert
            Assert.Equal(valor, result.Valor);
            Assert.Equal(natureza, result.NaturezaLancamento);
            Assert.True(Guid.TryParse(result.Id.ToString(), out var guidResult));
            Assert.NotEqual(DateTimeOffset.MinValue, result.DataLancamento);
        }
    }
}
