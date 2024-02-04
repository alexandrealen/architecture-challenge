using Domain.Enums;

namespace Domain.Models
{
    public class Relatorio
    {
        public decimal SaldoConsolidado { get; private set; }
        public IEnumerable<Lancamento> Lancamentos { get; private set; }

        public Relatorio(IEnumerable<Lancamento> lancamentos)
        {
            Lancamentos = lancamentos ?? new List<Lancamento>();
            SaldoConsolidado = 0;
            foreach (var lancamento in Lancamentos)
            {
                if (lancamento.NaturezaLancamento == NaturezaLancamento.Debito)
                    SaldoConsolidado -= lancamento.Valor;

                else if (lancamento.NaturezaLancamento == NaturezaLancamento.Credito)
                    SaldoConsolidado += lancamento.Valor;
            }
        }
    }
}
