using CleanArch.Domain.Entities;
using FluentValidation;

namespace CleanArch.Application.Validators
{
    public class AlunoUseCaseValidator : AbstractValidator<Aluno>
    {
        public AlunoUseCaseValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o Nome");

            RuleFor(a => a.Name)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do Nome é de 150 caracteres");

            RuleFor(a => a.Endereco)
               .NotEmpty()
               .NotNull()
               .WithMessage("Obrigatório informar o Endereço");

            RuleFor(a => a.Endereco)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do Endereço é de 150 caracteres");

            RuleFor(a => a.Email)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do E-mail é de 150 caracteres");

            RuleFor(a => a.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");

        }
    }
}
