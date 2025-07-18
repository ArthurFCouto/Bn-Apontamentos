using BN.Apontamentos.Application.Apontamentos.Commands;
using BN.Apontamentos.Application.Apontamentos.Validators;
using FluentAssertions;
using FluentValidation.Results;

namespace BN.Apontamentos.UnitTests.Applications.Apontamentos.Validators
{
    public class CadastrarApotamentoValidatorTest
    {
        private readonly CadastrarApontamentoValidator validator;

        public CadastrarApotamentoValidatorTest()
        {
            validator = new CadastrarApontamentoValidator();
        }

        [Theory(DisplayName = "Quando enviar um IdTrecho menor ou igual a zero")]
        [InlineData(-1)]
        [InlineData(0)]
        public void CadastrarApontamentoValidator_IdTrecho_Tests(int id)
        {
            // Arrange
            CadastrarApontamentoCommand command = new()
            {
                IdTrecho = id,
                MatriculaUsuario = 12345678,
                TagReal = "Tag123",
                MetragemInicio = 500,
                MetragemFim = 250,
                Observacao = "Teste",
                DataLancamento = DateTime.Now
            };

            // Act
            ValidationResult result = validator.Validate(command);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be("O Id do trecho deve ser maior que zero.");
        }

        [Fact(DisplayName = "Quando enviar uma MatriculaUsuario menor ou igual a zero")]
        public void CadastrarApontamentoValidator_MatriculaUsuario_Tests()
        {
            // Arrange
            CadastrarApontamentoCommand command = new()
            {
                IdTrecho = 1,
                MatriculaUsuario = 0,
                TagReal = "Tag123",
                MetragemInicio = 500,
                MetragemFim = 250,
                Observacao = "Teste",
                DataLancamento = DateTime.Now
            };

            // Act
            ValidationResult result = validator.Validate(command);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be("A matrícula deve ser informada.");
        }

        [Fact(DisplayName = "Quando enviar uma TagReal vazia")]
        public void CadastrarApontamentoValidator_TagReal_Tests()
        {
            // Arrange
            CadastrarApontamentoCommand command = new()
            {
                IdTrecho = 1,
                MatriculaUsuario = 12345678,
                TagReal = string.Empty,
                MetragemInicio = 500,
                MetragemFim = 250,
                Observacao = "Teste",
                DataLancamento = DateTime.Now
            };

            // Act
            ValidationResult result = validator.Validate(command);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be("A tag real não pode ser vazia.");
        }

        [Theory(DisplayName = "Quando enviar uma MetragemInicio menor ou igual a zero")]
        [InlineData(-1)]
        [InlineData(0)]
        public void CadastrarApontamentoValidator_MetragemInicio_Tests(decimal metragemInicio)
        {
            // Arrange
            CadastrarApontamentoCommand command = new()
            {
                IdTrecho = 1,
                MatriculaUsuario = 12345678,
                TagReal = "Tag123",
                MetragemInicio = metragemInicio,
                MetragemFim = 250,
                Observacao = "Teste",
                DataLancamento = DateTime.Now
            };

            // Act
            ValidationResult result = validator.Validate(command);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be("A metragem de início deve ser informada.");
        }

        [Fact(DisplayName = "Quando enviar uma MetragemFim maior que a MetragemInicio")]
        public void CadastrarApontamentoValidator_MetragemFim_Tests()
        {
            // Arrange
            CadastrarApontamentoCommand command = new()
            {
                IdTrecho = 1,
                MatriculaUsuario = 12345678,
                TagReal = "Tag123",
                MetragemInicio = 500,
                MetragemFim = 600,
                Observacao = "Teste",
                DataLancamento = DateTime.Now
            };

            // Act
            ValidationResult result = validator.Validate(command);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be("A metragem de fim deve ser menor que a metragem de início.");
        }
    }
}
