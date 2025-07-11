using BN.Apontamentos.Application.Apontamentos.Commands;
using BN.Apontamentos.Application.Apontamentos.Data;
using BN.Apontamentos.Application.Common.Handlers;
using BN.Apontamentos.Application.Common.Responses;
using BN.Apontamentos.Domain.Apontamentos.Schemas;
using BN.Apontamentos.Domain.Trechos.Queries;
using BN.Apontamentos.Domain.Trechos.Schemas;
using BN.Apontamentos.Domain.UnitOfWork;
using MediatR;

namespace BN.Apontamentos.Service.Apontamentos
{
    public class CadastrarApontamentoService
        : CommandHandler<CadastrarApontamentoCommand, CadastrarApontamentoResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public CadastrarApontamentoService(
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        protected override async Task<Response<CadastrarApontamentoResponse>> ExecuteAsync(
            CadastrarApontamentoCommand request,
            CancellationToken cancellationToken)
        {
            Trecho trecho = await ObterTrechoPorIdAsync(request.IdTrecho);

            if (trecho is null)
            {
                return BadRequest("O trecho informado não está cadastrado");
            }

            Apontamento apontamento = new Apontamento(
                planoDeCorte: trecho.PlanoDeCorte,
                trecho: trecho,
                matriculaUsuario: request.MatriculaUsuario,
                tagReal: request.TagReal,
                metragemInicio: request.MetragemInicio,
                metragemFim: request.MetragemFim,
                observacao: request.Observacao,
                dataLancamento: request.DataLancamento
                );

            unitOfWork.Add(apontamento);

            await unitOfWork.CommitAsync();

            return Success(new CadastrarApontamentoResponse()
            {
                IdApontamento = apontamento.IdApontamento,
            });
        }

        internal async Task<Trecho> ObterTrechoPorIdAsync(int id)
        {
            ObterTrechoPorIdModelQuery query = new()
            {
                IdTrecho = id,
                IncluirCircuito = true,
                IncluirBobina = true,
                IncluirOrigem = true,
                IncluirDestino = true
            };

            return await mediator.Send(query);
        }
    }
}
