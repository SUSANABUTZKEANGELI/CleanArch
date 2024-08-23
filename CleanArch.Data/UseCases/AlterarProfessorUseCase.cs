using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class AlterarProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository;

        public AlterarProfessorUseCase(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public Professor AlterarProfessor(int id, string nome, string email) 
        {
            var professor = _professorRepository.SelecionarPorId(id);
            if (professor == null)
            {
                return null;
                // Professor não existente
            }

            professor.Email = email;
            professor.Nome = nome;

            _professorRepository.Alterar(professor);

            return professor;
        }
    }
}
