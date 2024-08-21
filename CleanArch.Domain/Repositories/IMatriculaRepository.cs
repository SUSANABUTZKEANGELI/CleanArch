using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Repositories
{
    public interface IMatriculaRepository : IBaseRepository<Matricula>
    {
        Matricula SelecionarPorIdAlunoCurso(int idAluno, int idCurso);
    }
}
