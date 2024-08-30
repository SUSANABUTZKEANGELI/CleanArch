using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;

namespace CleanArch.Application.QueryHandlers.Alunos
{
    public class AlterarAlunoHandler : IRequestHandler<AlterarAlunoRequest, Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlterarAlunoHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Task<Aluno> Handle(AlterarAlunoRequest request, CancellationToken cancellationToken)
        {
            var aluno = _alunoRepository.SelecionarPorId2(request.Id);

            if (aluno == null)
            {
                return null;
                // aluno não cadastrado
            }

            var alunoAAlterar = new Aluno()
            {
                Id = request.Id,
                Name = request.Nome,
                Email = request.Email,
                Endereco = request.Endereco,
                Ativo = true
            };
    
            var alunoAlterado = _alunoRepository.Alterar2(alunoAAlterar);

            return alunoAlterado;
        }
    }
}
