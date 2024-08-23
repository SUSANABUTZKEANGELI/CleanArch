using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class ListarTodosAlunosUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public ListarTodosAlunosUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public List<Aluno> ListarAlunos() 
        {
            return _alunoRepository.SelecionarTudo();
        }
    }
}
