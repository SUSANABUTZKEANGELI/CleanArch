using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class ListarUmAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public ListarUmAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno ListarUmAluno(int id) 
        {
            return _alunoRepository.SelecionarPorId(id);
        }
    }
}
