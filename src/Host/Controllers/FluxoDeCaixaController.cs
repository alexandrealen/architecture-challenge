using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Net;
using System.Text.Json;
using Domain.Enums;
using Host.Dtos;
using System.Globalization;

namespace Host.Controllers
{
    [ApiController]
    [Route("fluxodecaixa")]
    public class FluxoDeCaixaController : ControllerBase
    {

        private readonly IFluxoDeCaixaService _fluxoDeCaixaService;

        public FluxoDeCaixaController(IFluxoDeCaixaService fluxoDeCaixaService)
        {
            _fluxoDeCaixaService = fluxoDeCaixaService;
        }

        /// <summary>
        /// Retorna um relatorio com o saldo consolidado e os lancamentos de hoje
        /// </summary>
        [HttpGet("relatorio")]
        [ProducesResponseType(typeof(Relatorio), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterRelatorio(CancellationToken ct)
        {
            var relatorio = await _fluxoDeCaixaService.ObterRelatorioAsync(DateTimeOffset.Now, DateTimeOffset.Now, ct);

            return Content(JsonSerializer.Serialize(relatorio));
        }

        /// <summary>
        /// Permite lancar um debito
        /// </summary>
        [HttpPost("debitos")]
        [ProducesResponseType(typeof(IEnumerable<Lancamento>), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LancarDebito([FromBody] LancamentoRequestDto dto, CancellationToken ct)
        {
            var result = await _fluxoDeCaixaService.SalvarLancamentoAsync(Convert.ToDecimal(dto.Valor, new CultureInfo("en-US")), NaturezaLancamento.Debito, ct);

            return StatusCode((int)HttpStatusCode.Created, result);
        }

        /// <summary>
        /// Permite lancar um credito
        /// </summary>
        [HttpPost("creditos")]
        [ProducesResponseType(typeof(Lancamento), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LancarCredito([FromBody] LancamentoRequestDto dto, CancellationToken ct)
        {
            var result = await _fluxoDeCaixaService.SalvarLancamentoAsync(Convert.ToDecimal(dto.Valor, new CultureInfo("en-US")), NaturezaLancamento.Credito, ct);

            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
}