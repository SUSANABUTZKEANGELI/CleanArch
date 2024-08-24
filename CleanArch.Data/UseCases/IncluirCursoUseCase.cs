using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Application.UseCases
{
    public class IncluirCursoUseCase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IProfessorRepository _professorRepository;

        public IncluirCursoUseCase(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
        {
            _cursoRepository = cursoRepository;
            _professorRepository = professorRepository; 
        }

        public Curso IncluirCurso(string nome, string descricao, DateTime ApplicationInicio, int idProfessor) 
        {
            var professor = _professorRepository.SelecionarPorId(idProfessor);
            if (professor == null)
            {
                return null;
                // professor não cadastrado
            }

            var curso = new Curso()
            {
                Nome = nome,
                Descricao = descricao,
                ApplicationInicio = ApplicationInicio,
                Ativo = true,
                IdProfessor = idProfessor
            };

            _cursoRepository.Incluir(curso);

            return curso;
        }
    }
}
