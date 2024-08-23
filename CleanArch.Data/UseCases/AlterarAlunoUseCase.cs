using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Data.UseCases
{
    public class AlterarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlterarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno AlterarAluno(int id, string nome, string endereco, string email, bool ativo) 
        {
            var aluno = _alunoRepository.SelecionarPorId(id);
            if (aluno == null)
            {
                return null;
                // aluno não existente
            }

            aluno.Email = email;
            aluno.Endereco = endereco;
            aluno.Name = nome;
            aluno.Ativo = ativo;

            _alunoRepository.Alterar(aluno);

            return aluno;
        }
    }
}
