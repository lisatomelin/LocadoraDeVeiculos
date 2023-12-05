using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
    {
        public ValidadorCupom()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();

            RuleFor(x => x.Valor)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.DataValidade)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Parceiro)
                .NotNull()
                .NotEmpty();
        }
    }
}
