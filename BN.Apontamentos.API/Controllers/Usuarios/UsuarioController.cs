using BN.Apontamentos.Application.Usuarios.Data;
using BN.Apontamentos.Application.Usuarios.Queries;
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
        /// /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginUsuarioResponse), 200)]
        public async Task<IActionResult> LoginUsuario(
            [FromBody] LoginUsuarioQuery query)
        {
            LoginUsuarioRequest request = new()
            {
                Matricula = query.Matricula,
                Senha = query.Senha
            };

            return Ok(await mediator.Send(request));
        }
    }
}
