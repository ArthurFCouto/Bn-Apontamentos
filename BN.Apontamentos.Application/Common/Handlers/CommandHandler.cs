using BN.Apontamentos.Application.Common.Commands;
using BN.Apontamentos.Application.Common.Responses;
using FluentValidation;
using MediatR;

namespace BN.Apontamentos.Application.Common.Handlers
{
    /// <summary>
    /// Classe base abstrata para manipuladores de comandos que não retornam dados (apenas status).
    /// Implementa a interface <see cref="IRequestHandler{TRequest, TResponse}"/> do MediatR.
    /// </summary>
    /// <typeparam name="TCommand">Tipo do comando (requer implementação de IRequest<Response>).</typeparam>
    public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand, Response>
        where TCommand : ICommandRequest
    {
        /// <summary>
        /// Método abstrato onde a lógica principal do comando deve ser implementada.
        /// </summary>
        protected abstract Task<Response> ExecuteAsync(TCommand request, CancellationToken cancellationToken);

        /// <summary>
        /// Implementação da interface do MediatR. Encaminha para o método <see cref="ExecuteAsync"/>.
        /// </summary>
        async Task<Response> IRequestHandler<TCommand, Response>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request, cancellationToken);
        }

        // Métodos auxiliares para facilitar o retorno padronizado

        protected Response Success() => new();

        protected Response BadRequest(string message) => new(ResponseStatus.BadRequest, message);

        protected Response BadRequest(ValidationException ex) => new(ex);

        protected Response NotFound(string message) => new(ResponseStatus.NotFound, message);

        protected Response Forbidden(string message) => new(ResponseStatus.Forbidden, message);

        protected Response Error(Exception ex) => new(ex);
    }

    /// <summary>
    /// Classe base abstrata para manipuladores de comandos que retornam dados (Response com tipo genérico).
    /// </summary>
    /// <typeparam name="TCommand">Tipo do comando (requer implementação de IRequest{Response{TResult}}).</typeparam>
    /// <typeparam name="TResult">Tipo do dado retornado.</typeparam>
    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, Response<TResult>>
        where TCommand : ICommandRequest<TResult>
    {
        /// <summary>
        /// Método abstrato onde a lógica principal do comando deve ser implementada.
        /// </summary>
        protected abstract Task<Response<TResult>> ExecuteAsync(TCommand request, CancellationToken cancellationToken);

        /// <summary>
        /// Implementação da interface do MediatR. Encaminha para o método <see cref="ExecuteAsync"/>.
        /// </summary>

        async Task<Response<TResult>> IRequestHandler<TCommand, Response<TResult>>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(request, cancellationToken);
        }

        // Métodos auxiliares para facilitar o retorno padronizado com dados

        protected Response<TResult> Success(TResult result) => new(result);

        protected Response<TResult> BadRequest(string message) => new(ResponseStatus.BadRequest, message);

        protected Response<TResult> BadRequest(ValidationException ex) => new(ex);

        protected Response<TResult> NotFound(string message) => new(ResponseStatus.NotFound, message);

        protected Response<TResult> Forbidden(string message) => new(ResponseStatus.Forbidden, message);

        protected Response<TResult> Error(Exception ex) => new(ex);
    }
}
