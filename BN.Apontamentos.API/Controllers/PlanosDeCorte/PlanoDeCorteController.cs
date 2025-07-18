using BN.Apontamentos.Application.Common.Responses;
using BN.Apontamentos.Application.PlanosDeCorte.Data;
using BN.Apontamentos.Application.PlanosDeCorte.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BN.Apontamentos.API.Controllers.PlanosDeCorte
{
    [Authorize]
    [Route("plano-de-corte")]
    [ApiController]
    public class PlanoDeCorteController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlanoDeCorteController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Busca os planos de corte cadastrados.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListarPlanoDeCorteResponse>), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.NoContent)]
        public async Task<IActionResult> ListarPlanoDeCorte(
            [FromQuery] ListarPlanoDeCorteQuery query)
        {
            return Ok(await mediator.Send(query));
        }

        /// <summary>
        /// Busca os planos de corte cadastrados com os trechos.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("trecho")]
        [ProducesResponseType(typeof(IEnumerable<ListarPlanoDeCorteComTrechoResponse>), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.NoContent)]
        public async Task<IActionResult> ListarPlanoDeCorteComTrecho(
            [FromQuery] ListarPlanoDeCorteComTrechoQuery query)
        {
            return Ok(await mediator.Send(query));
        }
    }
}
