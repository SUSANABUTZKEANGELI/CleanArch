using CleanArch.Domain.Entities;
using FluentValidation;

namespace CleanArch.Application.Validators
{
    public class ProfessorUseCaseValidator : AbstractValidator<Professor>
    {
        public ProfessorUseCaseValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o Nome");

            RuleFor(p => p.Nome)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do Nome é de 150 caracteres");
                        
            RuleFor(p => p.Email)
                .MaximumLength(150)
                .WithMessage("Tamanho máximo do E-mail é de 150 caracteres");

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");
        }

    }
}
