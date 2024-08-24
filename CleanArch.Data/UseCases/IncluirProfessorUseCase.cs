using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;

namespace CleanArch.Application.UseCases
{
    public class IncluirProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IValidator<Professor> _validator;

        public IncluirProfessorUseCase(IProfessorRepository professorRepository, IValidator<Professor> validator)
        {
            _professorRepository = professorRepository;
            _validator = validator;
        }

        public Professor IncluirProfessor(string nome, string email) 
        {
            var professor = new Professor()
            {
                Nome = nome,
                Email = email
            };

            var result = _validator.Validate(professor);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _professorRepository.Incluir(professor);

            return professor;
        }
    }
}
