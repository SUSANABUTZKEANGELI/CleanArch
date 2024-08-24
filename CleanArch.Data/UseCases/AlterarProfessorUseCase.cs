using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;

namespace CleanArch.Application.UseCases
{
    public class AlterarProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IValidator<Professor> _validator;

        public AlterarProfessorUseCase(IProfessorRepository professorRepository, IValidator<Professor> validator)
        {
            _professorRepository = professorRepository;
            _validator = validator;
        }

        public Professor AlterarProfessor(int id, string nome, string email) 
        {
            var professor = _professorRepository.SelecionarPorId(id);
            if (professor == null)
            {
                throw new ValidationException("Professor Inexistente");
            }

            professor.Email = email;
            professor.Nome = nome;

            var result = _validator.Validate(professor);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _professorRepository.Alterar(professor);

            return professor;
        }
    }
}
