using BN.Apontamentos.Application.Apontamentos.Commands;
using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Apontamentos.Queries;
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
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListarApontamentoResponse>), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.NoContent)]
        public async Task<IActionResult> ListarApontamentos(
            [FromBody] ListarApontamentoQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}
