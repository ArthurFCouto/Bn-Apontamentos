using FluentValidation;

namespace BN.Apontamentos.Application.Common.Responses
{
    /// <summary>
    /// Representa uma resposta padrão da aplicação, contendo status e mensagem.
    /// Utilizada para padronizar retornos de comandos, queries e ações da API.
    /// </summary>
    public class Response
    {
        public bool IsSuccess => Status == ResponseStatus.Success;
        public ResponseStatus Status { get; }
        public string Message { get; }

        public Response()
        {
            Status = ResponseStatus.Success;
        }

        public Response(ResponseStatus status, string message = null)
        {
            Status = status;
            Message = message;
        }

        public Response(Exception ex)
        {
            Status = ResponseStatus.InternalServerError;
            Message = ex.Message;
        }

        /// <summary>
        /// Construtor para capturar erros de validação do FluentValidation.
        /// </summary>
        public Response(ValidationException ex)
        {
            Status = ResponseStatus.BadRequest;
            Message = string.Join("; ", ex.Errors.Select(e => e.ErrorMessage));
        }
    }

    /// <summary>
    /// Representa uma resposta com dado do tipo T, estendendo a resposta base.
    /// Usada principalmente para queries ou comandos que retornam dados.
    /// </summary>
    public class Response<T> : Response
    {
        public T Data { get; }

        public Response(T data) : base()
        {
            Data = data;
        }

        public Response(ResponseStatus status, string message = null) : base(status, message) { }

        public Response(Exception ex) : base(ex) { }

        /// <summary>
        /// Construtor para capturar erros de validação do FluentValidation.
        /// </summary>
        public Response(ValidationException ex) : base(ex) { }
    }
}
