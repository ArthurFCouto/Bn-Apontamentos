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
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListarTrechoResponse), 200)]
        public async Task<IActionResult> ListarTrechos(
            [FromQuery] ListarTrechoQuery query)
        {
            ListarTrechoRequest request = new()
            {
                IdPlanoDeCorte = query.IdPlanoDeCorte
            };

            return Ok(await mediator.Send(request));
        }
    }
}
