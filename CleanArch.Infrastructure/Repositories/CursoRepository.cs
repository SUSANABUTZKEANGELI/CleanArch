using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Repository
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(Contexto contexto) : base(contexto)
        {
        }

    }
}
