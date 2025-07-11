using BN.Apontamentos.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BN.Apontamentos.Application.Common.Filters
{
    /// <summary>
    /// Filtro de ação responsável por interceptar a resposta dos endpoints que retornam objetos do tipo <see cref="Response"/>.
    /// Ele converte o objeto <see cref="Response"/> em um <see cref="ObjectResult"/> com o status HTTP apropriado,
    /// extraindo os dados diretamente em caso de sucesso.
    /// </summary>
    public class ResponseActionFilter : IActionFilter, IOrderedFilter
    {
        /// <summary>
        /// Define a ordem de execução do filtro.
        /// Quanto menor o valor, mais cedo o filtro será executado.
        /// Esse valor alto garante que ele rode próximo ao final da cadeia de execução.
        /// </summary>
        public int Order { get; } = int.MaxValue - 10;

        /// <summary>
        /// Executado antes da ação ser chamada.
        /// No momento ainda não faz nenhuma ação.
        /// </summary>
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        /// <summary>
        /// Executado após a execução da ação.
        /// Se o resultado da ação for um <see cref="Response"/>, ajusta o conteúdo e status HTTP da resposta.
        /// </summary>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Verifica se a resposta da ação é um ObjectResult contendo um Response
            if (context.Result is ObjectResult objectResult &&
                objectResult.Value is Response response)
            {
                // Se for um Response de tipo (Response<T>) com sucesso e dados válidos, extrai só os dados
                object result = response.IsSuccess && response is Response<object> typedResponse && typedResponse.Data is not null
                    ? typedResponse.Data
                    : response; // Caso contrário, mantém o Response completo (com status e mensagem de erro)

                // Reatribui o resultado da ação com o status HTTP baseado no status interno do Response
                context.Result = new ObjectResult(result)
                {
                    StatusCode = (int)response.Status
                };
            }
        }
    }
}
