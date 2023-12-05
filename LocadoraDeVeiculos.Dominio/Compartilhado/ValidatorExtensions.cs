using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> NaoPodeCaracteresEspeciais<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CaracteresInvalidosValidator<T>());
        }
    }
}
