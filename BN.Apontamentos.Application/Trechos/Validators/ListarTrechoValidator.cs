using BN.Apontamentos.Application.Configuration;
using BN.Apontamentos.Application.Trechos.Data;
using FluentValidation;

namespace BN.Apontamentos.Application.Trechos.Validators
{
    public class ListarTrechoValidator : BaseValidator<ListarTrechoRequest>
    {
        public ListarTrechoValidator()
        {
            When(x => x.IdPlanoDeCorte.HasValue, () =>
            {
                RuleFor(x => x.IdPlanoDeCorte)
                    .GreaterThan(0).WithMessage("O Id do Plano de Corte deve ser maior que zero.");
            });
        }
    }
}
