using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;

namespace CleanArch.Application.UseCases
{
    public class IncluirCursoUseCase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IValidator<Curso> _validator;

        public IncluirCursoUseCase(ICursoRepository cursoRepository, IProfessorRepository professorRepository, IValidator<Curso> validator)
        {
            _cursoRepository = cursoRepository;
            _professorRepository = professorRepository; 
            _validator = validator;
        }

        public Curso IncluirCurso(string nome, string descricao, DateTime dataInicio, int idProfessor) 
        {
            var professor = _professorRepository.SelecionarPorId(idProfessor);
            if (professor == null)
            {
                throw new ValidationException("Professor Inexistente");
            }

            var curso = new Curso()
            {
                Nome = nome,
                Descricao = descricao,
                DataInicio = dataInicio,
                Ativo = true,
                IdProfessor = idProfessor
            };

            var result = _validator.Validate(curso);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _cursoRepository.Incluir(curso);

            return curso;
        }
    }
}
