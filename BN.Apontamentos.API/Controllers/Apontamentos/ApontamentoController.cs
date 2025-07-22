using BN.Apontamentos.Application.Apontamentos.Commands;
using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Apontamentos.Queries;
using BN.Apontamentos.Application.Common.Records;
using BN.Apontamentos.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BN.Apontamentos.API.Controllers.Apontamentos
{
    [Authorize]
    [Route("apontamento")]
    [ApiController]
    public class ApontamentoController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApontamentoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Cadastrar apontamento.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CadastrarApontamentoResponse), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.InternalServerError)]
        public async Task<IActionResult> CadastrarApontamento(
            [FromBody] CadastrarApontamentoCommand request)
        {
            return Ok(await mediator.Send(request));
        }

        /// <summary>
        /// Retorna uma lista de apontamentos.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Record<ListarApontamentoResponse>), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.NoContent)]
        public async Task<IActionResult> ListarApontamentos(
            [FromQuery] ListarApontamentoRequest request)
        {
            ListarApontamentoQuery query = new()
            {
                IdTrecho = request.IdTrecho is null
                    ? Enumerable.Empty<int>()
                    : request.IdTrecho.Where(x => x.HasValue).Select(x => x.Value).ToArray(),
                IdPlanoDeCorte = request.IdPlanoDeCorte is null
                    ? Enumerable.Empty<int>()
                    : request.IdPlanoDeCorte.Where(x => x.HasValue).Select(x => x.Value).ToArray(),
                PaginaAtual = request.PaginaAtual,
                QuantidadePorPagina = request.QuantidadePorPagina
            };

            return Ok(await mediator.Send(query));
        }
    }
}
