using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.Common.Responses;
using BN.Apontamentos.Application.Usuarios.Commands;
using BN.Apontamentos.Application.Usuarios.Data;
using BN.Apontamentos.Infrastructure.Security.Interfaces;

namespace BN.Apontamentos.Service.Usuarios
{
    internal class LoginUsuarioService
        : CommandHandler<LoginUsuarioCommand, LoginUsuarioResponse>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public LoginUsuarioService(IJwtTokenGenerator jwtTokenGenerator)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        protected override async Task<Response<LoginUsuarioResponse>> ExecuteAsync(
            LoginUsuarioCommand request,
            CancellationToken cancellationToken)
        {
            string token = jwtTokenGenerator.GenerateToken(1, request.Matricula, "BN Apontador", "administrador");

            return Success(new LoginUsuarioResponse
            {
                Token = token,
                Nome = "BN Apontador",
                Matricula = request.Matricula
            });
        }
    }
}
