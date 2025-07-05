using BN.Apontamentos.Application.Usuarios.Data;
using BN.Apontamentos.Application.Usuarios.Validators;
using FluentAssertions;
using FluentValidation.Results;

namespace BN.Apontamentos.UnitTests.Applications.Usuarios.Validators
{
    public class LoginUsuarioValidatorTests
    {
        private readonly LoginUsuarioValidator validator;

        public LoginUsuarioValidatorTests()
        {
            validator = new LoginUsuarioValidator();
        }

        [Theory(DisplayName = "Quando informar um valor inválido para a matricula")]
        [InlineData(9999999)]
        [InlineData(100000000)]
        public void LoginUsuarioValidator_Matricula_Tests(int matricula)
        {
            // Arrange
            string mensagem = matricula < 10000000 ? "A matrícula deve ser maior que 1.000.000-0." : "A matricula deve ser até 9.999.999-9";
            LoginUsuarioRequest request = new() { Matricula = matricula };

            // Act
            ValidationResult result = validator.Validate(request);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be(mensagem);
        }

        [Theory(DisplayName = "Quando informar um valor inválido para a senha")]
        [InlineData(" ")]
        [InlineData("0")]
        [InlineData("88888888888888888888888888888888x")]
        public void LoginUsuarioValidator_Senha_Tests(string senha)
        {
            // Arrange
            string mensagem = senha switch
            {
                " " => "A senha não pode ser vazia.",
                "0" => "A senha deve ter pelo menos 8 caracteres.",
                _ => "A senha deve ter no máximo 32 caracteres."
            };
            LoginUsuarioRequest request = new()
            {
                Matricula = 88888880,
                Senha = senha
            };

            // Act
            ValidationResult result = validator.Validate(request);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be(mensagem);
        }
    }
}
