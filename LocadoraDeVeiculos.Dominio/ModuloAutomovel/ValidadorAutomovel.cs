using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Foto)
                .NotNull().WithMessage("Necessario colocar uma foto")
                .Must(x => x == null || x.Length <= 2697000).WithMessage("O tamanho da foto deve ser menor ou igual a 2 MB.");

            RuleFor(x => x.GrupoDoAutomovel)
                .NotNull().WithMessage("O Grupo do Automóvel deve ser informado.");

            RuleFor(x => x.Modelo)
                .NotNull().NotEmpty().WithMessage("O Modelo do Automóvel deve ser informado.");

            RuleFor(x => x.Marca)
                .NotNull().NotEmpty().WithMessage("A Marca do Automóvel deve ser informada.");

            RuleFor(x => x.Cor)
                .NotNull().NotEmpty().WithMessage("A Cor do Automóvel deve ser informada.");

            RuleFor(x => x.TipoCombustivel)
                .NotNull().WithMessage("O Tipo de Combustível do Automóvel deve ser informado.");

            RuleFor(x => x.KmAutomovel)
                .NotNull().WithMessage("O Km do Automóvel deve ser informado.");

            RuleFor(x => x.CapacidadeLitros)
                .NotNull()
                .WithMessage("A Capacidade em Litros do Automóvel deve ser informada.")
                .GreaterThan(20)
                .LessThan(150);

            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("A placa do carro não pode ser vazia.")
                .NotNull().WithMessage("A placa do carro é obrigatória.")
                .Matches(@"^[A-Z]{3}-\d{4}$").WithMessage("A placa do carro deve estar no formato AAA-1234.");
        }
    }
}
