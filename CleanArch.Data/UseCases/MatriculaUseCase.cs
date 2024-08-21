using CleanArch.Data.Repository;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class MatriculaUseCase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaUseCase(ICursoRepository cursoRepository, IAlunoRepository alunoRepository, IMatriculaRepository matriculaRepository)
        {
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
            _matriculaRepository = matriculaRepository;
        }

        public Matricula Matricular(int idCurso, int idAluno) 
        {
            var curso = _cursoRepository.SelecionarPorId(idCurso);
            if (!curso.Ativo ||
                curso.Matriculas.Count() > 29 ||
                curso.DataInicio <= DateTime.UtcNow)
            {
                return null;

                // curso inativo ou 
                // número de alunos excedido ou
                // data de início do curso ultrapassada
            }

            var aluno = _alunoRepository.SelecionarPorId(idAluno);
            if (!aluno.Ativo)
            {
                return null;

                // aluno inativo
            }

            var matricula = _matriculaRepository.SelecionarPorIdAlunoCurso(idAluno, idCurso);

            if (matricula.Id != null && matricula.StatusMatricula == Domain.Entities.Enums.StatusMatricula.Ativa)
            {
                return null;

                // matrícula já realizada
            }

            _matriculaRepository.Incluir(matricula);

            return matricula;
        }
    }
}
