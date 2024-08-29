using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Application.UseCases
{
    public class ListarTodasMatriculasUseCase
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public ListarTodasMatriculasUseCase(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public List<Matricula> ListarMatriculas() 
        {
            return _matriculaRepository.SelecionarTudo();
        }
    }
}
