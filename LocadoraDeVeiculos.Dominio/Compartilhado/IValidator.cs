using FluentValidation.Results;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IValidator<T> where T : EntidadeBase<T>
    {
        public ValidationResult Validate(T instance);
    }
}
