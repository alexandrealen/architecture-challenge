using Domain.Enums;

namespace Domain.Models
{
    public class Lancamento
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public DateTimeOffset DataLancamento { get; private set; }
        public NaturezaLancamento NaturezaLancamento { get; private set; }

        public Lancamento(decimal valor, NaturezaLancamento natureza) : this()
        {
            Id = Guid.NewGuid();
            Valor = valor;
            NaturezaLancamento = natureza;
            DataLancamento = DateTimeOffset.Now;
        }

        private Lancamento() { }
    }
}
