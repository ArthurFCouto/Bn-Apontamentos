using BN.Apontamentos.Application.Common.Responses;
using BN.Apontamentos.Application.Usuarios.Commands;
using BN.Apontamentos.Application.Usuarios.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BN.Apontamentos.API.Controllers.Usuarios
{
    [Authorize]
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;
        public UsuarioController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Faz o login do usuário e retorna o token JWT
        /// </summary>
        /// /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginUsuarioResponse), (int)ResponseStatus.Success)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)ResponseStatus.InternalServerError)]
        public async Task<IActionResult> LoginUsuario(
            [FromBody] LoginUsuarioRequest request)
        {
            LoginUsuarioCommand command = new()
            {
                Matricula = request.Matricula,
                Senha = request.Senha
            };

            return Ok(await mediator.Send(command));
        }
    }
}
