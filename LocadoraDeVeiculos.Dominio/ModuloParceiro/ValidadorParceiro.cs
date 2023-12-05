using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class ValidadorParceiro : AbstractValidator<Parceiro>, IValidadorParceiro
    {
        public ValidadorParceiro()
        {
            RuleFor(x => x.Nome)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(3)
                    .NaoPodeCaracteresEspeciais();
        }
    }
}
