using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Application.Repository
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(Contexto contexto) : base(contexto)
        {
        }

        public Task<Curso> SelecionarComMatriculas(int id)
        {
            return _contexto.Set<Curso>()
                .Include(c => c.Matriculas) // Carrega as matrículas associadas               .FirstOrDefaultAsync(c => c.Id == id);
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
