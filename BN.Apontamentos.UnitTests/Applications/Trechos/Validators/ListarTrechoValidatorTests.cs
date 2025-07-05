using BN.Apontamentos.Application.Trechos.Data;
using BN.Apontamentos.Application.Trechos.Validators;
using FluentAssertions;
using FluentValidation.Results;

namespace BN.Apontamentos.UnitTests.Applications.Trechos.Validators
{
    public class ListarTrechoValidatorTests
    {
        private readonly ListarTrechoValidator validator;

        public ListarTrechoValidatorTests()
        {
            validator = new ListarTrechoValidator();
        }

        [Theory(DisplayName = "Quando enviar um valor menor ou igual a zero no id plano de corte")]
        [InlineData(-1)]
        [InlineData(0)]
        public void ListarTrechoValidator_IdPlanoDeCorte_Tests(int id)
        {
            // Arrange
            ListarTrechoRequest request = new() { IdPlanoDeCorte = id };

            // Act
            ValidationResult result = validator.Validate(request);
            ValidationFailure error = result.Errors[0];

            // Assert
            error.ErrorMessage.Should().Be("O Id do Plano de Corte deve ser maior que zero.");
        }
    }
}
