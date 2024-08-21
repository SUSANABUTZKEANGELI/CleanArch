using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repository
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(Contexto contexto) : base(contexto)
        {
        }

        public List<Matricula> SelecionarTudoCompleto()
        {
            return _contexto.Matricula
                .Include(x => x.Aluno)
                .Include(x => x.Curso)
                .ToList();
        }

        public Matricula SelecionarPorIdAlunoCurso(int idAluno, int idCurso)
        {
            return _contexto.Set<Matricula>()
                .FirstOrDefault(x => x.IdAluno == idAluno && x.IdCurso == idCurso);
        }

    }
}
