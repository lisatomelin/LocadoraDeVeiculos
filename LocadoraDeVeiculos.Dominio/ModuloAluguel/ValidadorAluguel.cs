using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(x => x.Funcionario)
                .NotNull().WithMessage("O Funcionário deve ser informado.");

            RuleFor(x => x.Cliente)
                .NotNull().WithMessage("O Cliente deve ser informado.");

            RuleFor(x => x.GrupoAutomoveis)
                .NotNull().WithMessage("O Grupo de Automóveis deve ser informado.");

            RuleFor(x => x.Cobranca)
                .NotNull().WithMessage("A Cobrança deve ser informada.");

            RuleFor(x => x.Condutor)
                .NotNull().WithMessage("O Condutor deve ser informado.");

            RuleFor(x => x.Automovel)
                .NotNull().WithMessage("O Automóvel deve ser informado.");

            RuleFor(x => x.KmAutomovel)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do Km do Automóvel deve ser maior ou igual a 0.");

            RuleFor(x => x.DataLocacao)
                .NotNull().WithMessage("A Data de Locação deve ser informada.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A Data de Locação não pode ser no futuro.");

            RuleFor(x => x.DevolucaoPrevista)
                .NotNull().WithMessage("A Data de Devolução Prevista deve ser informada.")
                .GreaterThanOrEqualTo(x => x.DataLocacao).WithMessage("A Devolução Prevista deve ser após a Data de Locação.");

            RuleFor(x => x.ValorTotalPrevisto)
                .GreaterThanOrEqualTo(0).WithMessage("O Valor Total Previsto deve ser maior ou igual a 0.");
        }
    }

}



