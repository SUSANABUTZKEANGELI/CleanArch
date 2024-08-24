using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;

namespace CleanArch.Application.UseCases
{
    public class AlterarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IValidator<Aluno> _validator;

        public AlterarAlunoUseCase(IAlunoRepository alunoRepository, IValidator<Aluno> validator)
        {
            _alunoRepository = alunoRepository;
            _validator = validator;
        }

        public Aluno AlterarAluno(int id, string nome, string endereco, string email, bool ativo) 
        {
            var aluno = _alunoRepository.SelecionarPorId(id);
            if (aluno == null)
            {
                throw new ValidationException("Aluno Inexistente");                
            }

            aluno.Email = email;
            aluno.Endereco = endereco;
            aluno.Name = nome;
            aluno.Ativo = ativo;

            var result = _validator.Validate(aluno);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _alunoRepository.Alterar(aluno);

            return aluno;
        }
    }
}
