using FluentValidation;

namespace BN.Apontamentos.Application.Configuration
{
    /// <summary>
    /// Classe base para todos os validadores da aplicação.
    /// Herda de AbstractValidator do FluentValidation e define comportamentos padrão de validação.
    /// </summary>
    /// <typeparam name="T">Tipo do objeto a ser validado.</typeparam>
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected BaseValidator()
        {
            // Quando uma regra falha, as demais regras da mesma propriedade NÃO serão avaliadas.
            RuleLevelCascadeMode = CascadeMode.Stop;
            // Mesmo se uma propriedade falhar, as outras propriedades continuarão sendo validadas.
            ClassLevelCascadeMode = CascadeMode.Continue;
        }
    }
}
