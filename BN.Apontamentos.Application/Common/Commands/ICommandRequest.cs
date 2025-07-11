using BN.Apontamentos.Application.Common.Responses;
using MediatR;

namespace BN.Apontamentos.Application.Common.Commands
{
    /// <summary>
    /// Interface base para comandos que não retornam um tipo específico.
    /// Utilizada como contrato para comandos do MediatR com retorno padrão <see cref="Response"/>.
    /// </summary>
    public interface ICommandRequest : IRequest<Response> { }

    /// <summary>
    /// Interface base para comandos que retornam um tipo específico no response.
    /// Utilizada como contrato para comandos do MediatR com retorno do tipo <see cref="Response{TResponse}"/>.
    /// </summary>
    /// <typeparam name="TResponse">Tipo de dado retornado após o comando ser processado.</typeparam>
    public interface ICommandRequest<TResponse> : IRequest<Response<TResponse>> { }
}
