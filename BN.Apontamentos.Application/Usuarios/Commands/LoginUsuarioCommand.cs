using BN.Apontamentos.Application.Common.Commands;
using BN.Apontamentos.Application.Usuarios.Data;

namespace BN.Apontamentos.Application.Usuarios.Commands
{
    public class LoginUsuarioCommand
        : ICommandRequest<LoginUsuarioResponse>
    {
        public int Matricula { get; set; }
        public string Senha { get; set; }
    }
}
