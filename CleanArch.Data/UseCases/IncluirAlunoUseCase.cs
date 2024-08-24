using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using FluentValidation;

namespace CleanArch.Application.UseCases
{
    public class IncluirAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IValidator<Aluno> _validator;

        public IncluirAlunoUseCase(IAlunoRepository alunoRepository, IValidator<Aluno> validator)
        {
            _alunoRepository = alunoRepository;
            _validator = validator;
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

            var result = _validator.Validate(aluno);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _alunoRepository.Incluir(aluno);

            return aluno;
        }
    }
}
