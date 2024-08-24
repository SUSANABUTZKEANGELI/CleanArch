using CleanArch.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Validators
{
    public class CursoUseCaseValidator : AbstractValidator<Curso>
    {
        public CursoUseCaseValidator() 
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Obrigatório informar o Nome");

            RuleFor(p => p.Nome)
                .MaximumLength(100)
                .WithMessage("Tamanho máximo do Nome é de 100 caracteres");

            RuleFor(p => p.Descricao)
                .MaximumLength(500)
                .WithMessage("Tamanho máximo da Descrição é de 500 caracteres");

            RuleFor(p => p.IdProfessor)
                .NotEqual(0)                
                .WithMessage("Obrigatório informar o Professor");

        }
    }
}
