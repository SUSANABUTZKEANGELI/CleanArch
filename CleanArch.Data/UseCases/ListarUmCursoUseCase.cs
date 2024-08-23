using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class ListarUmCursoUseCase
    {
        private readonly ICursoRepository _cursoRepository;

        public ListarUmCursoUseCase(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public Curso ListarUmCurso(int id) 
        {
            return _cursoRepository.SelecionarPorId(id);
        }
    }
}
