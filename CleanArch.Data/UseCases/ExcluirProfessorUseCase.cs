using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class ExcluirProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository;

        public ExcluirProfessorUseCase(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public void ExcluirProfessor(int id) 
        {
            var professor = _professorRepository.SelecionarPorId(id);
            if (professor != null)
            {
                _professorRepository.Excluir(id);
            }
        }
    }
}
