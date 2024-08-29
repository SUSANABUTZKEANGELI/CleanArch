using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Application.UseCases
{
    public class IncluirMatriculaUseCase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public IncluirMatriculaUseCase(ICursoRepository cursoRepository, IAlunoRepository alunoRepository, IMatriculaRepository matriculaRepository)
        {
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
            _matriculaRepository = matriculaRepository;
        }

        public Matricula Matricular(int idCurso, int idAluno) 
        {
            var curso = _cursoRepository.SelecionarComMatriculas(idCurso);
            if (curso == null)
            {
                return null;
                // curso não encontrado
            }

            if (curso.Result.Matriculas != null)
            {
                var totalAlunosMatriculados = curso.Result.Matriculas.Count();
                if (totalAlunosMatriculados >= 30)
                {
                    return null;
                    // número de alunos excedido 
                }
            }

            if (!curso.Result.Ativo ||
                curso.Result.DataInicio <= DateTime.UtcNow)
            {
                return null;
                // curso inativo ou 
                // Application de início do curso ultrapassada
            }

            var aluno = _alunoRepository.SelecionarPorId(idAluno);
            if (aluno == null ||
                !aluno.Ativo)
            {
                return null;
                // aluno não encontrado
                // aluno inativo
            }

            var matriculaTeste = _matriculaRepository.SelecionarPorIdAlunoCurso(idAluno, idCurso);

            if (matriculaTeste != null && matriculaTeste.StatusMatricula == Domain.Entities.Enums.StatusMatricula.Ativa)
            {
                return null;
                // matrícula já realizada
            }

            var matricula = new Matricula()
            {
                IdAluno = idAluno,
                IdCurso = idCurso,
                StatusMatricula = Domain.Entities.Enums.StatusMatricula.Ativa
            };

            _matriculaRepository.Incluir(matricula);

            return matricula;
        }
    }
}
