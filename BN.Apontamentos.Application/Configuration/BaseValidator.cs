using FluentValidation;

namespace BN.Apontamentos.Application.Configuration
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected BaseValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Continue;
        }
    }
}
