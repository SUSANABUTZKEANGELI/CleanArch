using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure;

namespace CleanArch.Application.Repository
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
         public AlunoRepository(Contexto contexto) : base(contexto) 
        { 
        }
    }
}
