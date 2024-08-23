using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class ListarTodosCursosUseCase
    {
        private readonly ICursoRepository _cursoRepository;

        public ListarTodosCursosUseCase(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public List<Curso> ListarCursos() 
        {
            return _cursoRepository.SelecionarTudo();
        }
    }
}
