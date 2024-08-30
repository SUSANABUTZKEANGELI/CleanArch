using CleanArch.Domain.Entities;
using FluentValidation;

namespace CleanArch.Application.Validators
{
    public class ProfessorUseCaseValidator : AbstractValidator<Professor>
    {
        public ProfessorUseCaseValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o Nome");

            RuleFor(a => a.Nome)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do Nome é de 150 caracteres");

            RuleFor(a => a.Email)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do E-mail é de 150 caracteres");

            RuleFor(a => a.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido");

        }
    }
}
