using BN.Apontamentos.Application.Common.Queries;
using BN.Apontamentos.Application.Common.Responses;
using MediatR;

namespace BN.Apontamentos.Application.Common.Handlers
{
    /// <summary>
    /// Classe base abstrata para manipuladores de queries (consultas) com retorno de dados.
    /// Aplica o padrão CQRS integrando com MediatR e um padrão de resposta consistente.
    /// </summary>
    /// <typeparam name="TQuery">Tipo da query, que deve implementar IQueryRequest{TResult}.</typeparam>
    /// <typeparam name="TResult">Tipo dos dados esperados como resultado da query.</typeparam>
    public abstract class QueryHandler<TQuery, TResult> : IRequestHandler<TQuery, Response<TResult>>
        where TQuery : IQueryRequest<TResult>
    {
        /// <summary>
        /// Método abstrato onde a lógica principal da consulta deve ser implementada.
        /// Esse método é chamado automaticamente ao processar a query via MediatR.
        /// </summary>
        /// <param name="request">Query recebida.</param>
        /// <param name="cancellationToken">Token de cancelamento da requisição.</param>
        /// <returns>Resultado da consulta.</returns>
        protected abstract Task<TResult> ExecuteAsync(TQuery request, CancellationToken cancellationToken);

        /// <summary>
        /// Implementação da interface IRequestHandler.
        /// Executa a consulta e encapsula o resultado no objeto de resposta padrão.
        /// </summary>
        async Task<Response<TResult>> IRequestHandler<TQuery, Response<TResult>>.Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = await ExecuteAsync(request, cancellationToken);
            Response<TResult> response = result is null ?
                          new Response<TResult>(ResponseStatus.NoContent) :
                          new Response<TResult>(result);

            return response;
        }
    }
}
