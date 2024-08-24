using CleanArch.Application.Repository;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;

namespace CleanArch.Application.UseCases
{
    public class AlterarCursoUseCase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IValidator<Curso> _validator;


        public AlterarCursoUseCase(ICursoRepository cursoRepository, IProfessorRepository professorRepository, IValidator<Curso> validator)
        {
            _cursoRepository = cursoRepository;
            _professorRepository = professorRepository;
            _validator = validator;
        }

        public Curso AlterarCurso(int id, string nome, string descricao, DateTime dataInicio, bool ativo, int idProfessor) 
        {
            var curso = _cursoRepository.SelecionarPorId(id);
            if (curso == null)
            {
                throw new ValidationException("Curso Inexistente");
            }

            var professor = _professorRepository.SelecionarPorId(idProfessor);
            if (professor == null)
            {
                throw new ValidationException("Professor Inexistente");
            }

            curso.Nome = nome;
            curso.Descricao = descricao;
            curso.DataInicio = dataInicio;
            curso.Ativo = ativo;
            curso.IdProfessor = idProfessor;

            var result = _validator.Validate(curso);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _cursoRepository.Alterar(curso);

            return curso;
        }
    }
}
