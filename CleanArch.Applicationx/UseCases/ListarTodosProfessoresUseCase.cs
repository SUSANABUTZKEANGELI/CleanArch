using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Application.UseCases
{
    public class ListarTodosProfessoresUseCase
    {
        private readonly IProfessorRepository _professorRepository;

        public ListarTodosProfessoresUseCase(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public List<Professor> ListarProfessores() 
        {
            return _professorRepository.SelecionarTudo();
        }
    }
}
