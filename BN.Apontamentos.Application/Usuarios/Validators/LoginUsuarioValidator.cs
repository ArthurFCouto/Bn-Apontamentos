using BN.Apontamentos.Application.Configuration;
using BN.Apontamentos.Application.Usuarios.Data;
using FluentValidation;

namespace BN.Apontamentos.Application.Usuarios.Validators
{
    public class LoginUsuarioValidator : BaseValidator<LoginUsuarioRequest>
    {
        public LoginUsuarioValidator()
        {
            RuleFor(x => x.Matricula)
                .GreaterThan(9999999).WithMessage("A matrícula deve ser maior que 1.000.000-0.")
                .LessThan(100000000).WithMessage("A matricula deve ser até 9.999.999-9");

            RuleFor(x => x.Senha)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("A senha não pode ser vazia.")
                .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres.")
                .MaximumLength(32).WithMessage("A senha deve ter no máximo 32 caracteres.");
        }
    }
}
