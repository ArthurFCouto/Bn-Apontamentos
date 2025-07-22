using BN.Apontamentos.Application.Configuration;
using BN.Apontamentos.Application.Trechos.Queries;
using FluentValidation;

namespace BN.Apontamentos.Application.Trechos.Validators
{
    public class ListarTrechoValidator : BaseValidator<ListarTrechoQuery>
    {
        public ListarTrechoValidator()
        {
            When(x => x.IdPlanoDeCorte.Any(), () =>
            {
                RuleFor(x => x.IdPlanoDeCorte)
                .Must(x => x.All(id => id > 0)).WithMessage("O Id do Plano de Corte deve ser maior que zero.");
            });
        }
    }
}
