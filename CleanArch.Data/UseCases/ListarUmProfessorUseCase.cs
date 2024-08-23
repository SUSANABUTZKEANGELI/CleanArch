using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class ListarUmProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository;

        public ListarUmProfessorUseCase(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public Professor ListarUmProfessor(int id) 
        {
            return _professorRepository.SelecionarPorId(id);
        }
    }
}
