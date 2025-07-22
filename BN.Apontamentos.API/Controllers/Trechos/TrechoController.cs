using BN.Apontamentos.Application.Common.Responses;
using BN.Apontamentos.Application.Trechos.Data;
using BN.Apontamentos.Application.Trechos.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BN.Apontamentos.API.Controllers.Trechos
{
    [Authorize]
    [Route("trecho")]
    [ApiController]
    public class TrechoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TrechoController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Busca os trechos cadastrados.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListarTrechoResponse>), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.NoContent)]
        public async Task<IActionResult> ListarTrechos(
            [FromQuery] ListarTrechoRequest request)
        {
            ListarTrechoQuery query = new()
            {
                IdPlanoDeCorte = request.IdPlanoDeCorte is null
                    ? Enumerable.Empty<int>()
                    : request.IdPlanoDeCorte.Where(x => x.HasValue).Select(x => x.Value).ToArray()
            };
            return Ok(await mediator.Send(query));
        }

        /// <summary>
        /// Obtem um trecho por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ObterTrechoPorIdResponse>), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.NoContent)]
        public async Task<IActionResult> ObterTrechoPorId(
            [FromRoute] string id)
        {
            ObterTrechoPorIdQuery query = new()
            {
                Id = int.TryParse(id, out int resultado) ? resultado : 0
            };

            return Ok(await mediator.Send(query));
        }
    }
}
