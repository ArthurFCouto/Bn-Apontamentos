using BN.Apontamentos.Application.Usuarios.Data;
using BN.Apontamentos.Infrastructure.Security.Interfaces;
using MediatR;

namespace BN.Apontamentos.Service.Usuarios
{
    public class LoginUsuarioService
    : IRequestHandler<LoginUsuarioRequest, LoginUsuarioResponse>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public LoginUsuarioService(IJwtTokenGenerator jwtTokenGenerator)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<LoginUsuarioResponse> Handle(
            LoginUsuarioRequest request,
            CancellationToken cancellationToken)
        {
            string token = jwtTokenGenerator.GenerateToken(1, 10000000, "BN Apontador", "administrador");

            return Task.FromResult(new LoginUsuarioResponse
            {
                Token = token,
                Nome = "Nome",
                Matricula = request.Matricula
            });
        }
    }
}
