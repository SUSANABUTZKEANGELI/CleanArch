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
             //   .ThenInclude(x => x.Professor)
                .ToList();
        }
    }
}
