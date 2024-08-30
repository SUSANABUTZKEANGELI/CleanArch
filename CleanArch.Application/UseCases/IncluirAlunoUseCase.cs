using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;

namespace CleanArch.Application.UseCases
{
    public class IncluirAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public IncluirAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Aluno IncluirAluno(string nome, string endereco, string email) 
        {
            var aluno = new Aluno()
            {
                Name = nome,
                Email = email,
                Endereco = endereco,
                Ativo = true
            };

            _alunoRepository.Incluir(aluno);

            return aluno;
        }
    }
}
