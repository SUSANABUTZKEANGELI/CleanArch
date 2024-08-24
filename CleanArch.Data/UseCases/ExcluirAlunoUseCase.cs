using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Application.UseCases
{
    public class ExcluirAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public ExcluirAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void ExcluirAluno(int id) 
        {
            var aluno = _alunoRepository.SelecionarPorId(id);
            if (aluno != null)
            {
                _alunoRepository.Excluir(id);
            }
        }
    }
}
