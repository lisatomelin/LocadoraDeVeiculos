using FluentValidation;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCobranca
{
    public class ValidadorCobranca : AbstractValidator<Cobranca>, IValidadorCobranca
    {
        public ValidadorCobranca()
        {
            RuleFor(x => x.PrecoDiaria)
                .NotEmpty()
                .NotNull()
                .Must(BeDecimal)
                .WithMessage("O campo Preço Diaria deve conter apenas números válidos."); 

            RuleFor(x => x.TipoPlano)
                .Must(x => x != TipoPlanoEnum.Nenhum).WithMessage("Selecione um Plano de cobrança!");

            RuleFor(x => x.GrupoAutomoveis)
                .NotEmpty()
                .NotNull().WithMessage("É necessário selecionar um grupo de automoveis");

            When(cobranca => cobranca.GrupoAutomoveis != null, () =>
            {
                RuleFor(cobranca => cobranca.TipoPlano)
                    .Must((cobranca, tipoPlano) =>
                    {
                        if (cobranca.Id == Guid.Empty)
                        {
                            return !cobranca.GrupoAutomoveis.listaDeCobrancas.Any(c =>
                                c.TipoPlano == tipoPlano);
                        }
                        else
                        {
                            return !cobranca.GrupoAutomoveis.listaDeCobrancas.Any(c =>
                                c.TipoPlano == tipoPlano && !c.Id.Equals(cobranca.Id));
                        }
                    })
                    .WithMessage("Já existe um plano de cobrança com este tipo no grupo de automóveis.");
            });

            When(x => x.TipoPlano == TipoPlanoEnum.PlanoDiario || x.TipoPlano == TipoPlanoEnum.PlanoControlador, () =>
            {
                RuleFor(x => x.PrecoPorKm)
                    .GreaterThan(0)
                    .NotNull()
                    .WithMessage("O campo PrecoPorKm é obrigatório para o tipo de plano Diário e Controlador.");
            }).Otherwise(() =>
            {
                RuleFor(x => x.PrecoPorKm)
                    .Null()
                    .WithMessage("O campo PrecoPorKm não é aplicável para o tipo de plano Livre.");
            });
        }

        private bool BeDecimal(decimal value)
        {
            return decimal.TryParse(value.ToString(), out _);
        }
    }
}
