using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome não pode ser vazio.")
                .NotNull().WithMessage("O campo Nome é obrigatório.")
                .MinimumLength(6).WithMessage("O campo Nome deve ter no mínimo 6 caracteres.")
                .Matches("^[A-Za-zÀ-ÿ ]+$").WithMessage("O campo Nome deve conter apenas letras.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo Email não pode ser vazio.")
                .NotNull().WithMessage("O campo Email é obrigatório.")
                .EmailAddress().WithMessage("O campo Email deve ser um endereço de email válido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O campo Telefone não pode ser vazio.")
                .NotNull().WithMessage("O campo Telefone é obrigatório.")
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").WithMessage("O campo Telefone deve estar no formato (99) 99999-9999.");

            When(x => x.TipoCliente == TipoClienteEnum.PessoaJuridica, () =>
            {
                RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("O campo CNPJ não pode ser vazio.")
                .NotNull().WithMessage("O campo CNPJ é obrigatório.")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$").WithMessage("O campo CNPJ deve estar no formato 99.999.999/9999-99.");
            });

            When(x => x.TipoCliente == TipoClienteEnum.PessoaFisica, () =>
            {
                RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo CPF não pode ser vazio.")
                .NotNull().WithMessage("O campo CPF é obrigatório.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("O campo CPF deve estar no formato 999.999.999-99.");
            });

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O campo Estado não pode ser vazio.")
                .NotNull().WithMessage("O campo Estado é obrigatório.")
                .Length(2).WithMessage("O campo Estado deve ter 2 caracteres.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("O campo Cidade não pode ser vazio.")
                .NotNull().WithMessage("O campo Cidade é obrigatório.");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("O campo Bairro não pode ser vazio.")
                .NotNull().WithMessage("O campo Bairro é obrigatório.");

            RuleFor(x => x.Rua)
                .NotEmpty().WithMessage("O campo Rua não pode ser vazio.")
                .NotNull().WithMessage("O campo Rua é obrigatório.");

            RuleFor(x => x.NumeroCasa)
                .NotEmpty().WithMessage("O campo Número da Casa não pode ser vazio.")
                .NotNull().WithMessage("O campo Número da Casa é obrigatório.");

        }
    }
}
