using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis
{
    public class ValidadorGrupoAutomoveis : AbstractValidator<GrupoAutomoveis>, IValidadorGrupoAutomoveis
    {
        public ValidadorGrupoAutomoveis()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .NaoPodeCaracteresEspeciais();
        }
    }
}
