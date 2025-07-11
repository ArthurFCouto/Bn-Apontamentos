using BN.Apontamentos.Application.Common.Responses;
using MediatR;

namespace BN.Apontamentos.Application.Common.Queries
{
    /// <summary>
    /// Interface base para representar uma "Query" (consulta) que retorna um objeto de resposta tipado.
    /// Implementa o padrão CQRS, sendo usada junto ao MediatR para tratamento de requisições de leitura.
    /// </summary>
    /// <typeparam name="TResponse">
    /// Tipo da resposta esperada pela consulta. Será encapsulado dentro de um objeto Response{TResponse}.
    /// </typeparam>
    public interface IQueryRequest<TResponse> : IRequest<Response<TResponse>> { }
}
