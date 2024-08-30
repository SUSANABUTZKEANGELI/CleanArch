using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class IncluirAlunoHandler : IRequestHandler<IncluirAlunoRequest, Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public IncluirAlunoHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Task<Aluno> Handle(IncluirAlunoRequest request, CancellationToken cancellationToken)
        {
            var aluno = new Aluno()
            {
                Name = request.Nome,
                Email = request.Email,
                Endereco = request.Endereco,
                Ativo = true
            };

            var alunoIncluido = _alunoRepository.Incluir2(aluno);

            return alunoIncluido;
        }
    }
}
