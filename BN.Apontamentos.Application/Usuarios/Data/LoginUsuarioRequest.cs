using MediatR;

namespace BN.Apontamentos.Application.Usuarios.Data
{
    public class LoginUsuarioRequest
        : IRequest<LoginUsuarioResponse>
    {
        public int Matricula { get; set; }
        public string Senha { get; set; }
    }
}
