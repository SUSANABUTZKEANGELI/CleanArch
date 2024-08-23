using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Repositories
{
    public interface ICursoRepository : IBaseRepository<Curso>
    {
        Task<Curso> SelecionarComMatriculas(int id);
    }
}
