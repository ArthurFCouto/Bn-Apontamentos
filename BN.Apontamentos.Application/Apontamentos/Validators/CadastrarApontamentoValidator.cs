using BN.Apontamentos.Application.Apontamentos.Commands;
using BN.Apontamentos.Application.Configuration;
using FluentValidation;

namespace BN.Apontamentos.Application.Apontamentos.Validators
{
    public class CadastrarApontamentoValidator : BaseValidator<CadastrarApontamentoCommand>
    {
        public CadastrarApontamentoValidator()
        {
            RuleFor(x => x.IdTrecho)
                .GreaterThan(0)
                .WithMessage("O Id do trecho deve ser maior que zero.");

            RuleFor(x => x.MatriculaUsuario)
                .GreaterThan(0)
                .WithMessage("A matrícula deve ser informada.");

            RuleFor(x => x.TagReal)
                .NotEmpty()
                .WithMessage("A tag real não pode ser vazia.");

            RuleFor(x => x.MetragemInicio)
                .GreaterThan(0)
                .WithMessage("A metragem de início deve ser informada.");

            RuleFor(x => x.MetragemFim)
                .Must((x, metragemFim) => metragemFim <= x.MetragemInicio)
                .WithMessage("A metragem de fim deve ser menor que a metragem de início.");

            RuleFor(x => x.DataLancamento)
                .NotEmpty()
                .WithMessage("A data de lançamento não pode ser vazia.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de lançamento não pode ser futura.");
        }
    }
}
